using Tizen.NUI.Renderers;
using Tizen.VD.NUI.Renderers;

namespace Tizen.VD.NUI.Controls
{
    public class Switch : Tizen.NUI.Controls.Switch
    {
        //static constructor used to register internal style
        static Switch()
        {
            RegisterStyle("C_Switch", typeof(CSwitchRenderer));
        }

        public Switch() : base() { }
        public Switch(string style) : base(style) { }

        protected override BaseRenderer GetRenderer()
        {
            return new CSwitchRenderer();
        }


    }
}
