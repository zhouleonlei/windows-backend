using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.FH.NUI
{
    internal class CommonResource
    {
        private CommonResource() { }
        public static CommonResource Instance { get; } = new CommonResource();

        public string GetFHResourcePath()
        {
            return @"../../../demo/csharp-demo/res/images/FH3/";
        }
    }
}
