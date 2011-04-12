﻿/*
 * Copyright 2006-2011 Bastian Eicher, Simon E. Silva Lauinger
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.IO;
using System.Security.Cryptography;
using Common.Storage;
using NUnit.Framework;
using NUnit.Mocks;

namespace Common.Utils
{
    /// <summary>
    /// Contains test methods for <see cref="FileUtils"/>.
    /// </summary>
    [TestFixture]
    public class FileUtilsTest
    {
        #region Hash
        private const string Sha1ForEmptyString = "da39a3ee5e6b4b0d3255bfef95601890afd80709";

        /// <summary>
        /// Ensures <see cref="FileUtils.ComputeHash(string,HashAlgorithm)"/> can correctly hash files using SHA1.
        /// </summary>
        [Test]
        public void TestComputeHashFile()
        {
            // Create and hash an empty file
            using (var tempFile = new TemporaryFile("unit-tests"))
                Assert.AreEqual(Sha1ForEmptyString, FileUtils.ComputeHash(tempFile.Path, SHA1.Create()));
        }

        /// <summary>
        /// Ensures <see cref="FileUtils.ComputeHash(Stream,HashAlgorithm)"/> can correctly hash files using SHA1.
        /// </summary>
        [Test]
        public void TestComputeHashStream()
        {
            Assert.AreEqual(Sha1ForEmptyString, FileUtils.ComputeHash(new MemoryStream(), SHA1.Create()));
        }
        #endregion

        #region Time
        /// <summary>
        /// Ensures <see cref="FileUtils.ToUnixTime"/> correctly converts a <see cref="DateTime"/> value to a Unix epoch value.
        /// </summary>
        [Test]
        public void TestToUnixTime()
        {
            // 12677 days = 12677 x 86400 seconds = 1095292800 seconds
            Assert.AreEqual(1095292800, FileUtils.ToUnixTime(new DateTime(2004, 09, 16)));
        }

        /// <summary>
        /// Ensures <see cref="FileUtils.FromUnixTime"/> correctly converts a Unix epoch value to a <see cref="DateTime"/> value.
        /// </summary>
        [Test]
        public void TestFromUnixTime()
        {
            // 12677 days = 12677 x 86400 seconds = 1095292800 seconds
            Assert.AreEqual(new DateTime(2004, 09, 16), FileUtils.FromUnixTime(1095292800));
        }
        #endregion

        #region Temp
        /// <summary>
        /// Creates a temporary fileusing <see cref="FileUtils.GetTempFile"/>, ensures it is empty and deletes it again.
        /// </summary>
        [Test]
        public void TestGetTempFile()
        {
            string path = FileUtils.GetTempFile("unit-tests");
            Assert.IsNotNullOrEmpty(path);
            Assert.IsTrue(File.Exists(path));
            Assert.AreEqual("", File.ReadAllText(path));
            File.Delete(path);
        }

        /// <summary>
        /// Creates a temporary directory using <see cref="FileUtils.GetTempDirectory"/>, ensures it is empty and deletes it again.
        /// </summary>
        [Test]
        public void TestGetTempDirectory()
        {
            string path = FileUtils.GetTempDirectory("unit-tests");
            Assert.IsNotNullOrEmpty(path);
            Assert.IsTrue(Directory.Exists(path));
            Assert.IsEmpty(Directory.GetFileSystemEntries(path));
            Directory.Delete(path);
        }
        #endregion

        #region Copy
        /// <summary>
        /// Ensures <see cref="FileUtils.CopyDirectory"/> correctly copies a directories from one location to another and detects usage errors.
        /// </summary>
        [Test]
        public void TestCopyDirectory()
        {
            string temp1 = FileUtils.GetTempDirectory("unit-tests");
            string subdir1 = Path.Combine(temp1, "subdir");
            Directory.CreateDirectory(subdir1);
            File.WriteAllText(Path.Combine(subdir1, "file"), "A");
            File.SetLastWriteTimeUtc(Path.Combine(subdir1, "file"), new DateTime(2000, 1, 1));
            Directory.SetLastWriteTimeUtc(subdir1, new DateTime(2000, 1, 1));

            string temp2 = FileUtils.GetTempDirectory("unit-tests");
            Directory.Delete(temp2);
            string subdir2 = Path.Combine(temp2, "subdir");
            
            try
            {
                Assert.Throws<ArgumentException>(() => FileUtils.CopyDirectory(temp1, temp1, false));
                Assert.Throws<DirectoryNotFoundException>(() => FileUtils.CopyDirectory(temp2, temp1, false));

                FileUtils.CopyDirectory(temp1, temp2, false);
                FileAssert.AreEqual(Path.Combine(subdir1, "file"), Path.Combine(subdir2, "file"));
                Assert.AreEqual(new DateTime(2000, 1, 1), Directory.GetLastWriteTimeUtc(subdir2), "Last-write time for copied directory is invalid");
                Assert.AreEqual(new DateTime(2000, 1, 1), File.GetLastWriteTimeUtc(Path.Combine(subdir2, "file")), "Last-write time for copied file is invalid");

                Assert.Throws<IOException>(() => FileUtils.CopyDirectory(temp1, temp2, false));
            }
            finally
            {
                Directory.Delete(temp1, true);
                Directory.Delete(temp2, true);
            }
        }

        /// <summary>
        /// Ensures <see cref="FileUtils.CopyDirectory"/> correctly copies a directory on top another.
        /// </summary>
        [Test]
        public void TestCopyDirectoryOverwrite()
        {
            string temp1 = FileUtils.GetTempDirectory("unit-tests");
            string subdir1 = Path.Combine(temp1, "subdir");
            Directory.CreateDirectory(subdir1);
            File.WriteAllText(Path.Combine(subdir1, "file"), @"A");
            File.SetLastWriteTimeUtc(Path.Combine(subdir1, "file"), new DateTime(2000, 1, 1));
            Directory.SetLastWriteTimeUtc(subdir1, new DateTime(2000, 1, 1));

            string temp2 = FileUtils.GetTempDirectory("unit-tests");
            string subdir2 = Path.Combine(temp2, "subdir");
            Directory.CreateDirectory(subdir2);
            File.WriteAllText(Path.Combine(subdir2, "file"), @"B");
            File.SetLastWriteTimeUtc(Path.Combine(subdir2, "file"), new DateTime(2002, 1, 1));
            Directory.SetLastWriteTimeUtc(subdir2, new DateTime(2002, 1, 1));

            try
            {
                FileUtils.CopyDirectory(temp1, temp2, true);
                FileAssert.AreEqual(Path.Combine(subdir1, "file"), Path.Combine(subdir2, "file"));
                Assert.AreEqual(new DateTime(2000, 1, 1), Directory.GetLastWriteTimeUtc(subdir2), "Last-write time for copied directory is invalid");
                Assert.AreEqual(new DateTime(2000, 1, 1), File.GetLastWriteTimeUtc(Path.Combine(subdir2, "file")), "Last-write time for copied file is invalid");
            }
            finally
            {
                Directory.Delete(temp1, true);
                Directory.Delete(temp2, true);
            }
        }
        #endregion

        #region Unix
        [Test]
        public void TestIsRegularFile()
        {
            using (var tempFile = new TemporaryFile("unit-tests"))
                Assert.IsTrue(FileUtils.IsRegularFile(tempFile.Path), "Regular file should be detected as such");
        }

        [Test]
        public void TestIsSymlink()
        {
            using (var tempFile = new TemporaryFile("unit-tests"))
            {
                string contents;
                Assert.IsFalse(FileUtils.IsSymlink(tempFile.Path, out contents), "File was incorrectly identified as symlink");
                Assert.IsNull(contents);
            }
        }

        [Test]
        public void TestCreateSymlink()
        {
            if (!MonoUtils.IsUnix) throw new InconclusiveException("Unable to test symlinks on non-Unix-like system");

            using (var tempDir = new TemporaryDirectory("unit-tests"))
            {
                string symlinkPath = Path.Combine(tempDir.Path, "symlink");

                // Create an empty file and symlink to it using a relative path
                File.WriteAllText(Path.Combine(tempDir.Path, "target"), "");
                MonoUtils.CreateSymlink(symlinkPath, "target");
                
                string contents;
                Assert.IsTrue(FileUtils.IsSymlink(symlinkPath, out contents), "Should detect symlink as such");
                Assert.AreEqual(contents, "target", "Should get relative link target");

                Assert.IsFalse(FileUtils.IsRegularFile(symlinkPath), "Should not detect symlink as regular file");
            }
        }
        
        [Test]
        public void TestIsExecutable()
        {
            using (var tempFile = new TemporaryFile("unit-tests"))
                Assert.IsFalse(FileUtils.IsExecutable(tempFile.Path), "File was incorrectly identified as executable");
        }

        [Test]
        public void TestSetExecutable()
        {
            if (!MonoUtils.IsUnix) throw new InconclusiveException("Unable to test executable bit on non-Unix-like system");

            using (var tempFile = new TemporaryFile("unit-tests"))
            {
                Assert.IsFalse(FileUtils.IsExecutable(tempFile.Path), "File should not be executable yet");

                FileUtils.SetExecutable(tempFile.Path, true);
                Assert.IsTrue(FileUtils.IsExecutable(tempFile.Path), "File should now be executable");
                Assert.IsTrue(FileUtils.IsRegularFile(tempFile.Path), "File should still be considered a regular file");

                FileUtils.SetExecutable(tempFile.Path, false);
                Assert.IsFalse(FileUtils.IsExecutable(tempFile.Path), "File should no longer be executable");
            }
        }
        #endregion

        #region Directory walking
        // Interfaces used for mocking delegates
        private interface IActionSimulator<T> { void Invoke(T obj); }

        [Test]
        public void TestWalkDirectory()
        {
            using (var tempDir = new TemporaryDirectory("unit-tests"))
            {
                string subDirPath = Path.Combine(tempDir.Path, "subdir");
                Directory.CreateDirectory(subDirPath);
                string filePath = Path.Combine(subDirPath, "file");
                File.WriteAllText(filePath, "");

                // Set up delegate mocks
                var dirCallbackMock = new DynamicMock(typeof(IActionSimulator<string>));
                dirCallbackMock.Expect("Invoke", tempDir.Path);
                dirCallbackMock.Expect("Invoke", subDirPath);
                var dirCallback = (IActionSimulator<string>)dirCallbackMock.MockInstance;
                var fileCallbackMock = new DynamicMock(typeof(IActionSimulator<string>));
                fileCallbackMock.Expect("Invoke", filePath);
                var fileCallback = (IActionSimulator<string>)fileCallbackMock.MockInstance;

                FileUtils.WalkDirectory(new DirectoryInfo(tempDir.Path), subDir => dirCallback.Invoke(subDir.FullName), file => fileCallback.Invoke(file.FullName));

                dirCallbackMock.Verify();
                fileCallbackMock.Verify();
            }
        }
        #endregion
    }
}
