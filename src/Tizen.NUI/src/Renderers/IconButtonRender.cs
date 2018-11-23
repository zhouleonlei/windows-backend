using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Controls;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.NUI.res.IconButtonRenderer.xaml", "IconButtonRenderer.xaml", typeof(Tizen.NUI.Renderers.IconButtonRenderer))]

namespace Tizen.NUI.Renderers
{
    public class IconButtonRenderer : BaseRenderer
    {
        public IconButtonRenderer() : base()
        {
            icon = NameScopeExtensions.FindByName<ImageView>(layout, "icon");
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            Button button = sender as Button;
            switch (type)
            {
                case "Size":
                    break;
                case "IconURL":
                    icon.ResourceUrl = button.IconURL;
                    icon.ParentOrigin = ParentOrigin.Center;
                    break;
                case "IconSize2D":
                    icon.Size2D = button.IconSize2D;
                    break;
                default:
                    break;
            }
        }

        public override void OnStateChanged(States state)
        {
            icon.State = state;
        }

        private ImageView icon;
    }

}
