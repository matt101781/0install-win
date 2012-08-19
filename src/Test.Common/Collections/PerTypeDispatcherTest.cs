﻿/*
 * Copyright 2006-2012 Bastian Eicher
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

using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Collections
{
    /// <summary>
    /// Contains test methods for <see cref="PerTypeDispatcherTest"/>.
    /// </summary>
    [TestFixture]
    public class PerTypeDispatcherTest
    {
        private abstract class Base
        {}

        private class Sub1 : Base
        {}

        private class Sub2 : Base
        {}

        private class Sub3 : Base
        {}

        [Test]
        public void TestDispatch()
        {
            var sub1Orig = new Sub1();
            Sub1 sub1Dispatched = null;
            var sub2Orig = new Sub2();
            Sub2 sub2Dispatched = null;

            var dispatcher = new PerTypeDispatcher<Base>
            {
                (Sub1 sub1) => sub1Dispatched = sub1,
                (Sub2 sub2) => sub2Dispatched = sub2
            };

            dispatcher.Dispatch(sub1Orig);
            Assert.AreSame(sub1Orig, sub1Dispatched);

            dispatcher.Dispatch(sub2Orig);
            Assert.AreSame(sub2Orig, sub2Dispatched);

            Assert.Throws<KeyNotFoundException>(() => dispatcher.Dispatch(new Sub3()));
        }
    }
}
