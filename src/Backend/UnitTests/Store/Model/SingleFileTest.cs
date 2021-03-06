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
using NUnit.Framework;

namespace ZeroInstall.Store.Model
{
    /// <summary>
    /// Contains test methods for <see cref="SingleFile"/>.
    /// </summary>
    [TestFixture]
    public class SingleFileTest
    {
        #region Helpers
        /// <summary>
        /// Creates a fictive test <see cref="SingleFile"/>.
        /// </summary>
        internal static SingleFile CreateTestSingleFile()
        {
            return new SingleFile {Href = new Uri("http://0install.de/files/test/test.exe"), Size = 128, Destination = "dest"};
        }
        #endregion

        /// <summary>
        /// Ensures that the class can be correctly cloned.
        /// </summary>
        [Test]
        public void TestClone()
        {
            var singleFile1 = CreateTestSingleFile();
            var singleFile2 = singleFile1.CloneRecipeStep();

            // Ensure data stayed the same
            Assert.AreEqual(singleFile1, singleFile2, "Cloned objects should be equal.");
            Assert.AreEqual(singleFile1.GetHashCode(), singleFile2.GetHashCode(), "Cloned objects' hashes should be equal.");
            Assert.IsFalse(ReferenceEquals(singleFile1, singleFile2), "Cloning should not return the same reference.");
        }
    }
}
