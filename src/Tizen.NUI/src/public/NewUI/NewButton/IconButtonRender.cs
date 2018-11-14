using Tizen.NUI.Binding;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.NUI.res.IconButtonRenderer.xaml", "IconButtonRenderer.xaml", typeof(Tizen.NUI.BaseComponents.IconButtonRenderer))]

namespace Tizen.NUI.BaseComponents
{
    public class IconButtonRenderer : BaseRenderer
    {
        public IconButtonRenderer() : base()
        {
            icon = NameScopeExtensions.FindByName<ImageView>(layout, "icon");
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            NewButton button = sender as NewButton;
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

        public override void OnStateChanged(View.States state)
        {
            icon.State = state;
        }

        private ImageView icon;
    }

}
