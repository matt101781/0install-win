﻿/*
 * Copyright 2010 Bastian Eicher
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
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Common.Helpers;
using ZeroInstall.Store.Properties;

namespace ZeroInstall.Store.Implementation
{
    /// <summary>
    /// This manifest lists every file, directory and symlink in the tree using the new manifest format and contains a hash of each file's content.
    /// </summary>
    /// <remarks>
    /// The exact format is specified here: http://0install.net/manifest-spec.html
    /// </remarks>
    public sealed class NewManifest : Manifest, IEquatable<NewManifest>
    {
        #region Constructor
        /// <summary>
        /// Creates a new manifest.
        /// </summary>
        /// <param name="nodes">A list of all elements in the tree this manifest represents.</param>
        /// <param name="hashAlgorithm">The hash algorithm used for <see cref="FileBase.Hash"/> and <see cref="Save"/>.</param>
        private NewManifest(IList<ManifestNode> nodes, HashAlgorithm hashAlgorithm) : base(nodes, hashAlgorithm)
        {}
        #endregion

        #region Static access
        /// <summary>
        /// Generates a manifest using the new format for a directory in the file system.
        /// </summary>
        /// <param name="path">The path of the directory to analyze.</param>
        /// <param name="hashAlgorithm">The hash algorithm used for <see cref="FileBase.Hash"/> and <see cref="Save"/>.</param>
        /// <returns>A manifest for the directory.</returns>
        /// <exception cref="IOException">Thrown if the directory could not be processed.</exception>
        public static NewManifest Generate(string path, HashAlgorithm hashAlgorithm)
        {
            var nodes = new List<ManifestNode>();
            AddToList(nodes, hashAlgorithm, path, path);
            return new NewManifest(nodes, hashAlgorithm);
        }
        #endregion

        //--------------------//

        #region Storage
        /// <summary>
        /// Parses a manifest file created using the new format.
        /// </summary>
        /// <param name="path">The path of the file to load.</param>
        /// <param name="hashAlgorithm">The hash algorithm that was used for creating the file.</param>
        /// <returns>A set of <see cref="ManifestNode"/>s containing the parsed content of the file.</returns>
        /// <exception cref="IOException">Thrown if the manifest file could not be read.</exception>
        /// <exception cref="FormatException">Thrown if the file specified is not a valid manifest file.</exception>
        public static NewManifest Load(string path, HashAlgorithm hashAlgorithm)
        {
            var nodes = new List<ManifestNode>();

            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.StartsWith("F")) nodes.Add(File.FromString(line));
                    else if (line.StartsWith("X")) nodes.Add(ExecutableFile.FromString(line));
                    else if (line.StartsWith("S")) nodes.Add(Symlink.FromString(line));
                    else if (line.StartsWith("D")) nodes.Add(Directory.FromString(line));
                    else throw new FormatException(Resources.InvalidLinesInManifest);
                }
            }

            return new NewManifest(nodes, hashAlgorithm);
        }

        /// <summary>
        /// Writes the manifest to a file using the new format and calculates its hash.
        /// </summary>
        /// <param name="path">The path of the file to write.</param>
        /// <returns>The hash value of the file.</returns>
        public override string Save(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                foreach (ManifestNode node in Nodes)
                    writer.WriteLine(node.ToString());
            }
            return FileHelper.ComputeHash(path, HashAlgorithm);
        }
        #endregion

        //--------------------//

        #region Equality
        public bool Equals(NewManifest other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof(NewManifest) && Equals((NewManifest)obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
