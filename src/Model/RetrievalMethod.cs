﻿/*
 * Copyright 2010-2013 Bastian Eicher
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
using System.Xml.Serialization;

namespace ZeroInstall.Model
{
    /// <summary>
    /// A retrieval method is a way of getting a copy of an <see cref="Model.Implementation"/>.
    /// </summary>
    [XmlType("retrieval-method", Namespace = Feed.XmlNamespace)]
    public abstract class RetrievalMethod : FeedElement, ICloneable
    {
        /// <summary>
        /// Sets missing default values.
        /// </summary>
        public virtual void Normalize()
        {}

        /// <summary>
        /// Creates a deep copy of this <see cref="RetrievalMethod"/> instance.
        /// </summary>
        /// <returns>The new copy of the <see cref="RetrievalMethod"/>.</returns>
        public abstract RetrievalMethod Clone();

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
