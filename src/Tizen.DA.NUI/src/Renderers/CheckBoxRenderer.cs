using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.DA.NUI.res.CheckBoxRenderer.xaml", "CheckBoxRenderer.xaml", typeof(Tizen.DA.NUI.Renderers.CheckBoxRenderer))]

namespace Tizen.DA.NUI.Renderers
{
    public class CheckBoxRenderer : Tizen.NUI.Renderers.SelectionRenderer
    {
        public CheckBoxRenderer() : base()
        {
            shadowImage = NameScopeExtensions.FindByName<ImageView>(layout, "shadowImage");
            checkBGImage = NameScopeExtensions.FindByName<ImageView>(layout, "checkBGImage");
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            Tizen.DA.NUI.Controls.CheckBox selection = sender as Tizen.DA.NUI.Controls.CheckBox;
            switch (type)
            {
                case "CheckBoxSize2D":
                    shadowImage.Size2D = selection.SelectBoxSize2D;
                    shadowImage.State = States.Normal;
                    checkBGImage.Size2D = selection.SelectBoxSize2D;
                    checkBGImage.State = States.Normal;
                    break;
                default:
                    break;
            }
            base.OnPropertyChanged(type, sender);
            if(selection.CheckState == true)
            {
                shadowImage.State = States.Focused;
                checkBGImage.State = States.Focused;
            }
            else
            {
                shadowImage.State = States.Normal;
                checkBGImage.State = States.Normal;
            }
        }

        public override void OnStateChanged(States state)
        {
            base.OnStateChanged(state);
        }

        private ImageView shadowImage;
        private ImageView checkBGImage;
    }

}
