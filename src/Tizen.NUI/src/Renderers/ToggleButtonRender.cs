using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Controls;

using System;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.NUI.res.ToggleButtonRenderer.xaml", "ToggleButtonRenderer.xaml", typeof(Tizen.NUI.Renderers.ToggleButtonRenderer))]

namespace Tizen.NUI.Renderers
{
    public class ToggleButtonRenderer : BaseRenderer
    {
        public ToggleButtonRenderer() : base()
        {
            toggleView = NameScopeExtensions.FindByName<ImageView>(layout, "toggle");
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            Controls.ToggleButton toggleButton = sender as Controls.ToggleButton;
            //toggleButton.Tooltip

            switch (type)
            {
                case "Size":
                    break;
                case "IconURL":
                    iconURL = toggleButton.IconURL;
                    break;
                case "Text":
                    text = toggleButton.Text;
                    break;
                case "CurrentStateIndex":
                    currentStateIndex = toggleButton.CurrentStateIndex;
                    toggleView.ResourceUrl = iconURL[currentStateIndex];
                    toggleView.TooltipText = text[currentStateIndex];
                    break;
                default:
                    break;

            }
        }

        public override void OnStateChanged(States state)
        {
            Console.WriteLine("textLabel OnStateChanged");
            toggleView.State = state;
        }

        private ImageView toggleView;

        private string[] iconURL;
        private string[] text;
        private int currentStateIndex;
    }
}
