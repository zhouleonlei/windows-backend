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
using System.Threading;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal.Commands;
using NUnit.Framework.TUnit;

namespace NUnit.Framework.Internal.Execution
{
    /// <summary>
    /// A SimpleWorkItem represents a single test case and is
    /// marked as completed immediately upon execution. This
    /// class is also used for skipped or ignored test suites.
    /// </summary>
    public class SimpleWorkItem : WorkItem
    {
        private TestCommand _command;

        /// <summary>
        /// Construct a simple work item for a test.
        /// </summary>
        /// <param name="test">The test to be executed</param>
        /// <param name="filter">The filter used to select this test</param>
        public SimpleWorkItem(TestMethod test, ITestFilter filter) : base(test)
        {
            _command = test.RunState == RunState.Runnable || test.RunState == RunState.Explicit && filter.IsExplicitMatch(test)
                ? CommandBuilder.MakeTestCommand(test)
                : CommandBuilder.MakeSkipCommand(test);
        }

        /// <summary>
        /// Method that performs actually performs the work.
        /// </summary>
        protected override void PerformWork()
        {
            try
            {
                Result = _command.Execute(Context);
                // [DuongNT]: Write out the method's results
                if (!TSettings.GetInstance().IsSlaveMode && !TSettings.GetInstance().IsManual)
                {
                    TLogger.Write("##### Result of ["+ Result.FullName + "] TC : " + Result.ResultState.ToString());
                }
            }
            finally
            {
                WorkItemComplete();
            }
        }

    }
}
