﻿/*
 * Copyright 2010-2014 Bastian Eicher
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.IO;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using NanoByte.Common.Native;
using NanoByte.Common.Storage;
using NanoByte.Common.Streams;
using NanoByte.Common.Tasks;
using NUnit.Framework;
using ZeroInstall.Services;

namespace ZeroInstall.Store.Implementations
{
    /// <summary>
    /// Contains test methods for <see cref="Manifest"/>.
    /// </summary>
    [TestFixture]
    public class ManifestTest : TestWithMocks
    {
        #region Helpers
        /// <summary>
        /// Creates a <see cref="Manifest"/> from a temporary directory.
        /// </summary>
        private static Manifest CreateTestManifest()
        {
            using (var packageDir = new TemporaryDirectory("0install-unit-tests"))
            {
                new PackageBuilder().AddFolder("subdir")
                    .AddFile("file", "AAA", new DateTime(2000, 1, 1))
                    .WritePackageInto(packageDir);
                return GenerateManifest(packageDir, ManifestFormat.Sha1New, new MockTaskHandler());
            }
        }

        private static Manifest GenerateManifest(string path, ManifestFormat format, ITaskHandler handler)
        {
            var generator = new ManifestGenerator(path, format);
            handler.RunTask(generator);
            return generator.Result;
        }

        /// <summary>
        /// Generates a manifest for a directory in the filesystem and writes the manifest to a file named Manifest.ManifestFile in that directory.
        /// </summary>
        /// <param name="path">The path of the directory to analyze.</param>
        /// <param name="format">The format of the manifest (which file details are listed, which digest method is used, etc.).</param>
        /// <param name="handler">A callback object used when the the user is to be informed about progress.</param>
        /// <returns>The manifest digest.</returns>
        /// <exception cref="IOException">A problem occurs while writing the file.</exception>
        /// <remarks>
        /// The exact format is specified here: http://0install.net/manifest-spec.html
        /// </remarks>
        public static string CreateDotFile([NotNull] string path, [NotNull] ManifestFormat format, [NotNull] ITaskHandler handler)
        {
            #region Sanity checks
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("path");
            if (format == null) throw new ArgumentNullException("format");
            if (handler == null) throw new ArgumentNullException("handler");
            #endregion

            var generator = new ManifestGenerator(path, format);
            handler.RunTask(generator);
            return generator.Result.Save(Path.Combine(path, Manifest.ManifestFile));
        }
        #endregion

        [Test(Description = "Ensures that Manifest is correctly generated, serialized and deserialized.")]
        public void TestSaveLoad()
        {
            Manifest manifest1 = CreateTestManifest(), manifest2;
            using (var tempFile = new TemporaryFile("0install-unit-tests"))
            {
                // Generate manifest, write it to a file and read the file again
                manifest1.Save(tempFile);
                manifest2 = Manifest.Load(tempFile, ManifestFormat.Sha1New);
            }

            // Ensure data stayed the same
            Assert.AreEqual(manifest1, manifest2);
        }

        [Test(Description = "Ensures damaged manifest lines are correctly identified.")]
        public void TestLoadException()
        {
            Assert.Throws<FormatException>(() => Manifest.Load("test".ToStream(), ManifestFormat.Sha1));
            Assert.Throws<FormatException>(() => Manifest.Load("test".ToStream(), ManifestFormat.Sha1New));
            Assert.Throws<FormatException>(() => Manifest.Load("test".ToStream(), ManifestFormat.Sha256));
            Assert.Throws<FormatException>(() => Manifest.Load("test".ToStream(), ManifestFormat.Sha256New));

            Assert.Throws<FormatException>(() => Manifest.Load("D /test".ToStream(), ManifestFormat.Sha1));
            Assert.DoesNotThrow(() => Manifest.Load("D /test".ToStream(), ManifestFormat.Sha1New));
            Assert.DoesNotThrow(() => Manifest.Load("D /test".ToStream(), ManifestFormat.Sha256));
            Assert.DoesNotThrow(() => Manifest.Load("D /test".ToStream(), ManifestFormat.Sha256New));

            Assert.DoesNotThrow(() => Manifest.Load("F abc123 1200000000 128 test".ToStream(), ManifestFormat.Sha1));
            Assert.DoesNotThrow(() => Manifest.Load("F abc123 1200000000 128 test".ToStream(), ManifestFormat.Sha1New));
            Assert.DoesNotThrow(() => Manifest.Load("F abc123 1200000000 128 test".ToStream(), ManifestFormat.Sha256));
            Assert.DoesNotThrow(() => Manifest.Load("F abc123 1200000000 128 test".ToStream(), ManifestFormat.Sha256New));

            Assert.Throws<FormatException>(() => Manifest.Load("F abc123 128 test".ToStream(), ManifestFormat.Sha1));
            Assert.Throws<FormatException>(() => Manifest.Load("F abc123 128 test".ToStream(), ManifestFormat.Sha1New));
            Assert.Throws<FormatException>(() => Manifest.Load("F abc123 128 test".ToStream(), ManifestFormat.Sha256));
            Assert.Throws<FormatException>(() => Manifest.Load("F abc123 128 test".ToStream(), ManifestFormat.Sha256New));
        }

        [Test]
        public void TestCalculateDigest()
        {
            using (var packageDir = new TemporaryDirectory("0install-unit-tests"))
            {
                new PackageBuilder().AddFolder("subdir")
                    .AddFile("file", "AAA", new DateTime(2000, 1, 1))
                    .WritePackageInto(packageDir);

                Assert.AreEqual(
                    CreateDotFile(packageDir, ManifestFormat.Sha1, new MockTaskHandler()),
                    GenerateManifest(packageDir, ManifestFormat.Sha1, new MockTaskHandler()).CalculateDigest(),
                    "sha1 dot file and digest should match");
                Assert.AreEqual(
                    CreateDotFile(packageDir, ManifestFormat.Sha1New, new MockTaskHandler()),
                    GenerateManifest(packageDir, ManifestFormat.Sha1New, new MockTaskHandler()).CalculateDigest(),
                    "sha1new dot file and digest should match");
                Assert.AreEqual(
                    CreateDotFile(packageDir, ManifestFormat.Sha256, new MockTaskHandler()),
                    GenerateManifest(packageDir, ManifestFormat.Sha256, new MockTaskHandler()).CalculateDigest(),
                    "sha256 dot file and digest should match");
                Assert.AreEqual(
                    CreateDotFile(packageDir, ManifestFormat.Sha256New, new MockTaskHandler()),
                    GenerateManifest(packageDir, ManifestFormat.Sha256New, new MockTaskHandler()).CalculateDigest(),
                    "sha256new dot file and digest should match");
            }
        }

        [Test(Description = "Ensures that ToXmlString() correctly outputs a serialized form of the manifest.")]
        public void TestToString()
        {
            using (var packageDir = new TemporaryDirectory("0install-unit-tests"))
            {
                new PackageBuilder().AddFolder("subdir")
                    .AddFile("file", "AAA", new DateTime(2000, 1, 1))
                    .WritePackageInto(packageDir);

                var manifest = GenerateManifest(packageDir, ManifestFormat.Sha1New, new MockTaskHandler());
                Assert.AreEqual("D /subdir\nF 606ec6e9bd8a8ff2ad14e5fade3f264471e82251 946684800 3 file\n", manifest.ToString().Replace(Environment.NewLine, "\n"));
            }
        }

        // ReSharper disable AssignNullToNotNullAttribute
        [Test]
        public void ShouldListNormalWindowsExeWithFlagF()
        {
            using (var package = new TemporaryDirectory("0install-unit-tests"))
            {
                string filePath = Path.Combine(package, "test.exe");
                string manifestPath = Path.Combine(package, Manifest.ManifestFile);

                File.WriteAllText(filePath, @"xxxxxxx");
                CreateDotFile(package, ManifestFormat.Sha256, new MockTaskHandler());

                using (var manifest = File.OpenText(manifestPath))
                {
                    string firstLine = manifest.ReadLine();
                    Assert.True(Regex.IsMatch(firstLine, @"^F \w+ \d+ \d+ test.exe$"), "Manifest didn't match expected format");
                }
            }
        }

        [Test]
        public void ShouldListFilesInXbitWithFlagX()
        {
            using (var package = new TemporaryDirectory("0install-unit-tests"))
            {
                string filePath = Path.Combine(package, "test.exe");
                string manifestPath = Path.Combine(package, Manifest.ManifestFile);

                File.WriteAllText(filePath, "target");
                if (WindowsUtils.IsWindows)
                {
                    string flagPath = Path.Combine(package, FlagUtils.XbitFile);
                    File.WriteAllText(flagPath, @"/test.exe");
                }
                else FileUtils.SetExecutable(filePath, true);
                CreateDotFile(package, ManifestFormat.Sha256, new MockTaskHandler());

                using (var manifest = File.OpenText(manifestPath))
                {
                    string firstLine = manifest.ReadLine();
                    Assert.True(Regex.IsMatch(firstLine, @"^X \w+ \d+ \d+ test.exe$"), "Manifest didn't match expected format");
                }
            }
        }

        [Test]
        public void ShouldListFilesInSymlinkWithFlagS()
        {
            using (var package = new TemporaryDirectory("0install-unit-tests"))
            {
                string sourcePath = Path.Combine(package, "test");
                string manifestPath = Path.Combine(package, Manifest.ManifestFile);

                if (WindowsUtils.IsWindows)
                {
                    File.WriteAllText(sourcePath, "target");
                    string flagPath = Path.Combine(package, FlagUtils.SymlinkFile);
                    File.WriteAllText(flagPath, @"/test");
                }
                else FileUtils.CreateSymlink(sourcePath, "target");
                CreateDotFile(package, ManifestFormat.Sha256, new MockTaskHandler());

                using (var manifest = File.OpenText(manifestPath))
                {
                    string firstLine = manifest.ReadLine();
                    Assert.True(Regex.IsMatch(firstLine, @"^S \w+ \d+ test$"), "Manifest didn't match expected format");
                }
            }
        }

        [Test]
        public void ShouldListNothingForEmptyPackage()
        {
            using (var package = new TemporaryDirectory("0install-unit-tests"))
            {
                CreateDotFile(package, ManifestFormat.Sha256, new MockTaskHandler());
                using (var manifestFile = File.OpenRead(Path.Combine(package, Manifest.ManifestFile)))
                    Assert.AreEqual(0, manifestFile.Length, "Empty package directory should make an empty manifest");
            }
        }

        [Test]
        public void ShouldHandleSubdirectoriesWithExecutables()
        {
            using (var package = new TemporaryDirectory("0install-unit-tests"))
            {
                string innerPath = Path.Combine(package, "inner");
                Directory.CreateDirectory(innerPath);

                string innerExePath = Path.Combine(innerPath, "inner.exe");
                string manifestPath = Path.Combine(package, Manifest.ManifestFile);
                File.WriteAllText(innerExePath, @"xxxxxxx");
                if (WindowsUtils.IsWindows)
                {
                    string flagPath = Path.Combine(package, FlagUtils.XbitFile);
                    File.WriteAllText(flagPath, @"/inner/inner.exe");
                }
                else FileUtils.SetExecutable(innerExePath, true);
                CreateDotFile(package, ManifestFormat.Sha256, new MockTaskHandler());
                using (var manifestFile = File.OpenText(manifestPath))
                {
                    string currentLine = manifestFile.ReadLine();
                    Assert.True(Regex.IsMatch(currentLine, @"^D /inner$"), "Manifest didn't match expected format:\n" + currentLine);
                    currentLine = manifestFile.ReadLine();
                    Assert.True(Regex.IsMatch(currentLine, @"^X \w+ \w+ \d+ inner.exe$"), "Manifest didn't match expected format:\n" + currentLine);
                }
            }
        }

        [Test]
        public void ShouldHandleSha1()
        {
            using (var package = new TemporaryDirectory("0install-unit-tests"))
            {
                string innerPath = Path.Combine(package, "inner");
                Directory.CreateDirectory(innerPath);

                string manifestPath = Path.Combine(package, Manifest.ManifestFile);
                string innerExePath = Path.Combine(innerPath, "inner.exe");
                File.WriteAllText(innerExePath, @"xxxxxxx");
                if (WindowsUtils.IsWindows)
                {
                    string flagPath = Path.Combine(package, FlagUtils.XbitFile);
                    File.WriteAllText(flagPath, @"/inner/inner.exe");
                }
                else FileUtils.SetExecutable(innerExePath, true);
                CreateDotFile(package, ManifestFormat.Sha1, new MockTaskHandler());
                using (var manifestFile = File.OpenText(manifestPath))
                {
                    string currentLine = manifestFile.ReadLine();
                    Assert.True(Regex.IsMatch(currentLine, @"^D \w+ /inner$"), "Manifest didn't match expected format:\n" + currentLine);
                    currentLine = manifestFile.ReadLine();
                    Assert.True(Regex.IsMatch(currentLine, @"^X \w+ \w+ \d+ inner.exe$"), "Manifest didn't match expected format:\n" + currentLine);
                }
            }
        }

        // ReSharper restore AssignNullToNotNullAttribute

        [Test]
        public void ShouldNotFollowDirectorySymlinks()
        {
            if (!UnixUtils.IsUnix) Assert.Ignore("Can only test symlinks on Unixoid system");

            using (var package = new TemporaryDirectory("0install-unit-tests"))
            {
                Directory.CreateDirectory(Path.Combine(package, "target"));
                FileUtils.CreateSymlink(Path.Combine(package, "source"), "target");
                var manifest = GenerateManifest(package, ManifestFormat.Sha256New, new MockTaskHandler());

                Assert.IsTrue(manifest[0] is ManifestSymlink, "Unexpected manifest:\n" + manifest);
                Assert.AreEqual("source", ((ManifestSymlink)manifest[0]).SymlinkName, "Unexpected manifest:\n" + manifest);
                Assert.IsTrue(manifest[1] is ManifestDirectory, "Unexpected manifest:\n" + manifest);
                Assert.AreEqual("/target", ((ManifestDirectory)manifest[1]).FullPath, "Unexpected manifest:\n" + manifest);
            }
        }
    }
}
