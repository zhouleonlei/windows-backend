// ***********************************************************************
// Copyright (c) 2014 Charlie Poole
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
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace NUnit.Framework
{
    /// <summary>
    /// ParallelizableAttribute is used to mark tests that may be run in parallel.
    /// </summary>
    [AttributeUsage( AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple=false, Inherited=false )]
    public sealed class ParallelizableAttribute : PropertyAttribute, IApplyToContext
    {
        private ParallelScope _scope;

        /// <summary>
        /// Construct a ParallelizableAttribute using default ParallelScope.Self.
        /// </summary>
        public ParallelizableAttribute() : this(ParallelScope.Self) { }

        /// <summary>
        /// Construct a ParallelizableAttribute with a specified scope.
        /// </summary>
        /// <param name="scope">The ParallelScope associated with this attribute.</param>
        public ParallelizableAttribute(ParallelScope scope) : base()
        {
            _scope = scope;

            Properties.Add(PropertyNames.ParallelScope, scope);
        }

        #region IApplyToContext Interface

        /// <summary>
        /// Modify the context to be used for child tests
        /// </summary>
        /// <param name="context">The current TestExecutionContext</param>
        public void ApplyToContext(TestExecutionContext context)
        {
            // Don't reflect Self in the context, since it will be
            // used for descendant tests.
            context.ParallelScope = _scope & ~ParallelScope.Self;
        }

        #endregion
    }
}
