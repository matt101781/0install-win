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

using Moq;
using NUnit.Framework;

namespace ZeroInstall
{
    /// <summary>
    /// Common base class for test fixtures that use a <see cref="MockRepository"/>.
    /// </summary>
    public abstract class TestWithMocks
    {
        protected MockRepository MockRepository;

        [SetUp]
        public virtual void SetUp()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);
        }

        [TearDown]
        public virtual void TearDown()
        {
            MockRepository.VerifyAll();
        }
    }
}
