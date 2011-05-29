﻿/*
 * Copyright 2010-2011 Bastian Eicher
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
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Xml.Serialization;
using Common;
using Common.Storage;
using ZeroInstall.Model.Properties;

namespace ZeroInstall.Model.Capabilities
{
    /// <summary>
    /// Groups a number of <see cref="Capability"/>s that can be registered in a desktop environment.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "C5 collections don't need to be disposed.")]
    [Serializable]
    [XmlRoot("capabilities", Namespace = Capability.XmlNamespace)]
    [XmlType("capabilities", Namespace = Capability.XmlNamespace)]
    public sealed class CapabilityList : XmlUnknown, ICloneable, IEquatable<CapabilityList>
    {
        #region Properties
        /// <summary>
        /// Determines for which operating systems the <see cref="Capability"/>s are aplicable.
        /// </summary>
        [Description("Determines for which operating systems the capabilities are aplicable.")]
        [XmlIgnore]
        public Architecture Architecture { get; set; }

        /// <summary>Used for XML serialization.</summary>
        /// <seealso cref="Architecture"/>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [XmlAttribute("arch"), DefaultValue("*-*")]
        public string ArchitectureString
        {
            get { return Architecture.ToString(); }
            set { Architecture = new Architecture(value); }
        }

        // Preserve order
        private readonly C5.ArrayList<Capability> _entries = new C5.ArrayList<Capability>();
        /// <summary>
        /// A list of <see cref="Capability"/>s.
        /// </summary>
        [Description("A list of capabilities.")]
        [XmlElement(typeof(FileType)), XmlElement(typeof(AutoPlay))]
        // Note: Can not use ICollection<T> interface because of XML Serialization
        public C5.ArrayList<Capability> Entries { get { return _entries; } }
        #endregion

        //--------------------//

        #region Storage
        /// <summary>
        /// Loads a <see cref="CapabilityList"/> from an XML file.
        /// </summary>
        /// <param name="path">The file to load from.</param>
        /// <returns>The loaded <see cref="CapabilityList"/>.</returns>
        /// <exception cref="IOException">Thrown if a problem occurs while reading the file.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown if read access to the file is not permitted.</exception>
        /// <exception cref="InvalidOperationException">Thrown if a problem occurs while deserializing the XML data.</exception>
        public static CapabilityList Load(string path)
        {
            try { return XmlStorage.Load<CapabilityList>(path); }
            #region Error handling
            catch (InvalidOperationException ex)
            {
                // Write additional diagnostic information to log
                if (ex.Source == "System.Xml")
                {
                    string message = string.Format(Resources.ProblemLoading, path) + "\n" + ex.Message;
                    if (ex.InnerException != null) message += "\n" + ex.InnerException.Message;
                    Log.Error(message);
                }

                throw;
            }
            #endregion
        }

        /// <summary>
        /// Loads a <see cref="CapabilityList"/> from a stream containing an XML file.
        /// </summary>
        /// <param name="stream">The stream to load from.</param>
        /// <returns>The loaded <see cref="CapabilityList"/>.</returns>
        public static CapabilityList Load(Stream stream)
        {
            return XmlStorage.Load<CapabilityList>(stream);
        }

        /// <summary>
        /// Saves this <see cref="CapabilityList"/> to an XML file.
        /// </summary>
        /// <param name="path">The file to save in.</param>
        /// <exception cref="IOException">Thrown if a problem occurs while writing the file.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown if write access to the file is not permitted.</exception>
        public void Save(string path)
        {
            XmlStorage.Save(path, this);
        }

        /// <summary>
        /// Saves this <see cref="CapabilityList"/> to a stream as an XML file).
        /// </summary>
        /// <param name="stream">The stream to save in.</param>
        public void Save(Stream stream)
        {
            XmlStorage.Save(stream, this);
        }
        #endregion

        //--------------------//

        #region Clone
        /// <summary>
        /// Creates a deep copy of this <see cref="CapabilityList"/> instance.
        /// </summary>
        /// <returns>The new copy of the <see cref="CapabilityList"/>.</returns>
        public CapabilityList CloneCapabilityList()
        {
            var capabilityList = new CapabilityList {Architecture = Architecture};
            foreach (var entry in Entries) capabilityList.Entries.Add(entry.CloneCapability());

            return capabilityList;
        }

        /// <summary>
        /// Creates a deep copy of this <see cref="CapabilityList"/> instance.
        /// </summary>
        /// <returns>The new copy of the <see cref="CapabilityList"/>.</returns>
        public object Clone()
        {
            return CloneCapabilityList();
        }
        #endregion

        #region Conversion
        /// <summary>
        /// Returns the capability list in the form "Capabilities for Architecture". Not safe for parsing!
        /// </summary>
        public override string ToString()
        {
            return string.Format("Capabilities for {0}", Architecture);
        }
        #endregion

        #region Equality
        /// <inheritdoc/>
        public bool Equals(CapabilityList other)
        {
            if (other == null) return false;

            if (Architecture != other.Architecture) return false;
            if (!Entries.SequencedEquals(other.Entries)) return false;
            return true;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof(CapabilityList) && Equals((CapabilityList)obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = Architecture.GetHashCode();
                result = (result * 397) ^ Entries.GetSequencedHashCode();
                return result;
            }
        }
        #endregion
    }
}