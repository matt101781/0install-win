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
using System.Runtime.Serialization;
using ZeroInstall.Store.Model.Selection;

namespace ZeroInstall.Services.Injector
{
    /// <summary>
    /// Indicates the <see cref="IExecutor"/> was unable to process the <see cref="Selections"/>.
    /// </summary>
    [Serializable]
    public sealed class ExecutorException : Exception
    {
        /// <summary>
        /// Creates a new missing main exception.
        /// </summary>
        public ExecutorException()
        {}

        /// <summary>
        /// Creates a new missing main exception.
        /// </summary>
        public ExecutorException(string message) : base(message)
        {}

        /// <summary>
        /// Creates a new missing main exception.
        /// </summary>
        public ExecutorException(string message, Exception innerException) : base(message, innerException)
        {}

        /// <summary>
        /// Deserializes an exception.
        /// </summary>
        private ExecutorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {}
    }
}
