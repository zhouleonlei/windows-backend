using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.Renderers;
using Tizen.DA.NUI.Renderers;

namespace Tizen.DA.NUI.Controls
{
    public class Indicator: Tizen.NUI.Controls.Indicator
    {
        //static constructor used to register internal style
        static Indicator()
        {
        }

        public Indicator() : base() { }
        public Indicator(string style) : base(style) { }

        protected override BaseRenderer GetRenderer()
        {
            return new Tizen.DA.NUI.Renderers.IndicatorRenderer();
        }
    }
}
