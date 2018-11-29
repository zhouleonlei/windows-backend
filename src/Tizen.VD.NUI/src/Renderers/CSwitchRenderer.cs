using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;
using Tizen.VD.NUI.Controls;
using System;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.VD.NUI.res.CSwitchRenderer.xaml", "CSwitchRenderer.xaml", typeof(Tizen.VD.NUI.Renderers.CSwitchRenderer))]


namespace Tizen.VD.NUI.Renderers
{
    public class CSwitchRenderer : Tizen.NUI.Renderers.BaseRenderer
    {
        public CSwitchRenderer() : base()
        {
            switchImageView = NameScopeExtensions.FindByName<ImageView>(layout, "switch");
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            Switch s = sender as Switch;

            switch (type)
            {
                case "Size":
                    break;
                case "OnImageArray":
                    onImageArray = s.OnImageArray;
                    break;
                case "OffImageArray":
                    offImageArray = s.OffImageArray;
                    break;
                case "CurrentState":
                    if (s.CurrentState == Switch.OnOffStates.OnState)
                    {
                        switchImageView.ResourceUrl = onImageArray[0];
                    }
                    else if (s.CurrentState == Switch.OnOffStates.OffState)
                    {
                        switchImageView.ResourceUrl = offImageArray[0];
                    }
                    break;
                case "SwitchSize2D":
                    switchImageView.Size2D = s.SwitchSize2D;
                    break;
                default:
                    break;

            }

        }

        public override void OnStateChanged(States state)
        {
            Console.WriteLine("CSwitchRender OnStateChanged");
            if (state == States.Disabled)
            {
                switchImageView.Opacity = 0.4f;
            }
        }

        private ImageView switchImageView;

        private string[] onImageArray = null;
        private string[] offImageArray = null;
    }
}
