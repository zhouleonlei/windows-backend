using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.DA.NUI.Controls;
using System;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.DA.NUI.res.CToggleButtonRenderer.xaml", "CToggleButtonRenderer.xaml", typeof(Tizen.DA.NUI.Renderers.CToggleButtonRenderer))]

namespace Tizen.DA.NUI.Renderers
{
    public class CToggleButtonRenderer : Tizen.NUI.Renderers.BaseRenderer
    {
        public CToggleButtonRenderer() : base()
        {
            textLabel = NameScopeExtensions.FindByName<TextLabel>(layout, "toggle");
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            Controls.ToggleButton toggleButton = sender as Controls.ToggleButton;
            //toggleButton.Tooltip

            switch (type)
            {
                case "Size":
                    break;
                case "Text":
                    text = toggleButton.Text;
                    break;
                case "CurrentStateIndex":
                    currentStateIndex = toggleButton.CurrentStateIndex;
                    textLabel.Text = text[currentStateIndex];
                    break;
                default:
                    break;

            }
        }

        public override void OnStateChanged(States state)
        {
            Console.WriteLine("CToggleButtonRender OnStateChanged");
            textLabel.State = state;
        }

        private TextLabel textLabel;
        private string[] text;
        private int currentStateIndex;


    }
}
