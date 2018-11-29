using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Controls;

using System;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.NUI.res.SwitchRenderer.xaml", "SwitchRenderer.xaml", typeof(Tizen.NUI.Renderers.SwitchRenderer))]

namespace Tizen.NUI.Renderers
{
    public class SwitchRenderer : BaseRenderer
    {
        public SwitchRenderer() : base()
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
            Console.WriteLine("SwitchRender OnStateChanged");
            switchImageView.State = state;
        }

        private ImageView switchImageView;

        private string[] onImageArray = null;
        private string[] offImageArray = null;
    }
}

