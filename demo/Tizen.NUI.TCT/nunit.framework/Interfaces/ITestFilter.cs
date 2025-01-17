// ***********************************************************************
// Copyright (c) 2007 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************
#define PORTABLE
#define TIZEN
#define NUNIT_FRAMEWORK
#define NUNITLITE
#define NET_4_5
#define PARALLEL
using System;

namespace NUnit.Framework.Interfaces
{
    /// <summary>
    /// Interface to be implemented by filters applied to tests.
    /// The filter applies when running the test, after it has been
    /// loaded, since this is the only time an ITest exists.
    /// </summary>
    public interface ITestFilter : IXmlNodeBuilder
    {
        /// <summary>
        /// Determine if a particular test passes the filter criteria. Pass
        /// may examine the parents and/or descendants of a test, depending
        /// on the semantics of the particular filter
        /// </summary>
        /// <param name="test">The test to which the filter is applied</param>
        /// <returns>True if the test passes the filter, otherwise false</returns>
        bool Pass(ITest test);

        /// <summary>
        /// Determine if a test matches the filter expicitly. That is, it must
        /// be a direct match of the test itself or one of it's children.
        /// </summary>
        /// <param name="test">The test to which the filter is applied</param>
        /// <returns>True if the test matches the filter explicityly, otherwise false</returns>
        bool IsExplicitMatch(ITest test);
    }
}
