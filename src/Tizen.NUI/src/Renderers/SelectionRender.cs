using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Controls;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.NUI.res.SelectionRenderer.xaml", "SelectionRenderer.xaml", typeof(Tizen.NUI.Renderers.SelectionRenderer))]

namespace Tizen.NUI.Renderers
{
    public class SelectionRenderer : BaseRenderer
    {
        public SelectionRenderer() : base()
        {
            textLabel = NameScopeExtensions.FindByName<TextLabel>(layout, "textLabel");
            backgroundImage = NameScopeExtensions.FindByName<ImageView>(layout, "backgroundImage");
            checkImage = NameScopeExtensions.FindByName<ImageView>(layout, "checkImage");
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            Selection selection = sender as Selection;
            switch (type)
            {
                case "Size":
                    backgroundImage.Size2D = selection.Size2D ;
                    break;
                case "Text":                  
                    textLabel.Size2D = new Size2D(selection.Size2D.Width - selection.CheckBoxSize2D.Width, selection.Size2D.Height);
                    textLabel.Text = selection.Text;
                    break; 
                case "CheckImageURL":
                    checkImage.ResourceUrl = selection.CheckImageURL;
                    break;
                case "BackgroundImageURL":
                    backgroundImage.ResourceUrl = selection.BackgroundImageURL;
                    break;
                case "CheckBoxSize2D":
                    checkImage.Size2D = selection.CheckBoxSize2D;
                    //checkImage.ParentOrigin = ParentOrigin.Center;
                    checkImage.State = States.Normal;
                    break;
                case "CheckState":
                    if(selection.CheckState == true)
                    {
                        checkImage.State = States.Focused;
                    }
                    else
                    {
                        checkImage.State = States.Normal;
                    }
                    break;
                default:
                    break;
            }
        }

        public override void OnStateChanged(States state)
        {
            backgroundImage.State = state;
            textLabel.State = state;
        }

        private TextLabel textLabel;
        private ImageView backgroundImage;
        private ImageView checkImage;
    }

}
