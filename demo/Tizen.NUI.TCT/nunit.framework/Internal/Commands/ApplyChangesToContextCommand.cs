﻿// ***********************************************************************
// Copyright (c) 2012 Charlie Poole
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
using System.Threading;
using NUnit.Framework.Interfaces;

namespace NUnit.Framework.Internal.Commands
{
    /// <summary>
    /// ContextSettingsCommand applies specified changes to the
    /// TestExecutionContext prior to running a test. No special
    /// action is needed after the test runs, since the prior
    /// context will be restored automatically.
    /// </summary>
    class ApplyChangesToContextCommand : DelegatingTestCommand
    {
        private IEnumerable<IApplyToContext> _changes;

        public ApplyChangesToContextCommand(TestCommand innerCommand, IEnumerable<IApplyToContext> changes)
            : base(innerCommand)
        {
            _changes = changes;
        }

        public override TestResult Execute(TestExecutionContext context)
        {
            try
            {
                foreach (IApplyToContext change in _changes)
                    change.ApplyToContext(context);

                context.CurrentResult = innerCommand.Execute(context);
            }
            catch (Exception ex)
            {
#if !NETCF && !SILVERLIGHT && !PORTABLE
                if (ex is ThreadAbortException)
                    Thread.ResetAbort();
#endif
                context.CurrentResult.RecordException(ex);
            }

            return context.CurrentResult;
        }
    }
}
