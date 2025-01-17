﻿// **********************************************************************************
// The MIT License (MIT)
// 
// Copyright (c) 2014 Charlie Poole
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
// **********************************************************************************
#define PORTABLE
#define TIZEN
#define NUNIT_FRAMEWORK
#define NUNITLITE
#define NET_4_5
#define PARALLEL

#region Using Directives

using System;
using NUnit.Framework.Internal;

#endregion

namespace NUnit.Framework
{
    /// <summary>
    /// Provides the Author of a test or test fixture. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = false, Inherited=false)]
    public class AuthorAttribute : PropertyAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorAttribute"/> class.
        /// </summary>
        /// <param name="name">The name of the author.</param>
        public AuthorAttribute(string name) 
            : base(PropertyNames.Author, name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorAttribute"/> class.
        /// </summary>
        /// <param name="name">The name of the author.</param>
        /// <param name="email">The email address of the author.</param>
        public AuthorAttribute(string name, string email)
            : base(PropertyNames.Author, string.Format("{0} <{1}>", name, email))
        {
        }
    }
}
