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
using System.Collections.Generic;
using NUnit.Framework.Internal.Commands;
using NUnit.Framework.Interfaces;

namespace NUnit.Framework
{
    /// <summary>
    /// Summary description for MaxTimeAttribute.
    /// </summary>
    [AttributeUsage( AttributeTargets.Method, AllowMultiple=false, Inherited=false )]
    public sealed class MaxTimeAttribute : PropertyAttribute, IWrapSetUpTearDown
    {
        private int _milliseconds;
        /// <summary>
        /// Construct a MaxTimeAttribute, given a time in milliseconds.
        /// </summary>
        /// <param name="milliseconds">The maximum elapsed time in milliseconds</param>
        public MaxTimeAttribute( int milliseconds )
            : base( milliseconds )
        {
            _milliseconds = milliseconds;
        }

        #region ICommandWrapper Members

        TestCommand ICommandWrapper.Wrap(TestCommand command)
        {
            return new MaxTimeCommand(command, _milliseconds);
        }

        #endregion
    }
}
