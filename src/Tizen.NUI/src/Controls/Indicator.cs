using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.Renderers;

namespace Tizen.NUI.Controls
{
    public class Indicator : BaseControl
    {
        //static constructor used to register internal style
        static Indicator()
        {
        }

        public Indicator() : base() { }
        public Indicator(string style) : base(style) { }

        protected override BaseRenderer GetRenderer()
        {
            return new IndicatorRenderer();
        }

    }
}
