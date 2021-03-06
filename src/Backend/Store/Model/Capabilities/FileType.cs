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
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using NanoByte.Common.Collections;

namespace ZeroInstall.Store.Model.Capabilities
{
    /// <summary>
    /// An application's ability to open a certain file type.
    /// </summary>
    [Description("An application's ability to open a certain file type.")]
    [Serializable]
    [XmlRoot("file-type", Namespace = CapabilityList.XmlNamespace), XmlType("file-type", Namespace = CapabilityList.XmlNamespace)]
    public sealed class FileType : VerbCapability, IEquatable<FileType>
    {
        #region Properties
        /// <inheritdoc/>
        [XmlIgnore]
        public override bool WindowsMachineWideOnly { get { return false; } }

        private readonly List<FileTypeExtension> _extensions = new List<FileTypeExtension>();

        /// <summary>
        /// A list of all file extensions associated with this file type.
        /// </summary>
        [Browsable(false)]
        [XmlElement("extension")]
        public List<FileTypeExtension> Extensions { get { return _extensions; } }

        /// <inheritdoc/>
        [XmlIgnore]
        public override IEnumerable<string> ConflictIDs { get { return new[] {"progid:" + ID}; } }
        #endregion

        //--------------------//

        #region Conversion
        /// <summary>
        /// Returns the capability in the form "ID". Not safe for parsing!
        /// </summary>
        public override string ToString()
        {
            return ID;
        }
        #endregion

        #region Clone
        /// <inheritdoc/>
        public override Capability Clone()
        {
            var capability = new FileType {UnknownAttributes = UnknownAttributes, UnknownElements = UnknownElements, ID = ID, ExplicitOnly = ExplicitOnly};
            capability.Descriptions.AddRange(Descriptions.CloneElements());
            capability.Icons.AddRange(Icons);
            capability.Verbs.AddRange(Verbs.CloneElements());
            capability.Extensions.AddRange(Extensions);
            return capability;
        }
        #endregion

        #region Equality
        /// <inheritdoc/>
        public bool Equals(FileType other)
        {
            if (other == null) return false;
            return base.Equals(other) && Extensions.SequencedEquals(other.Extensions);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is FileType && Equals((FileType)obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode() * 397) ^ Extensions.GetSequencedHashCode();
            }
        }
        #endregion
    }
}
