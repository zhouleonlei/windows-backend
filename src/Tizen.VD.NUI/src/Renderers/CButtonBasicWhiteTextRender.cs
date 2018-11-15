using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Controls;
using Tizen.NUI.Renderers;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.VD.NUI.res.CButtonBasicWhiteTextRenderer.xaml", "CButtonBasicWhiteTextRenderer.xaml", typeof(Tizen.VD.NUI.Renderers.CButtonBasicWhiteTextRenderer))]

namespace Tizen.VD.NUI.Renderers
{
    public class CButtonBasicWhiteTextRenderer : TextButtonRenderer
    {
        public CButtonBasicWhiteTextRenderer() : base()
        {
            backgroundImage = NameScopeExtensions.FindByName<ImageView>(layout, "backgroundImage");
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            var button = sender as Button;
            switch (type)
            {
                case "Size":
                    controlSize2D = button.Size2D;
                    OnStateChanged(button.State);
                    break;
                default:
                    break;
            }
            base.OnPropertyChanged(type, sender);
        }

        public override void OnStateChanged(View.States state)
        {
            backgroundImage.State = state;
            switch(state)
            {
                case View.States.Focused:
                    backgroundImage.Size2D = new Size2D(controlSize2D.Width + 14, controlSize2D.Height + 24);
                    break;
                default:
                    backgroundImage.Size2D = new Size2D(controlSize2D.Width, controlSize2D.Height);
                    break;
            }
            base.OnStateChanged(state);
        }

        private Size2D controlSize2D = new Size2D(0, 0);
        private ImageView backgroundImage;
    }

}
