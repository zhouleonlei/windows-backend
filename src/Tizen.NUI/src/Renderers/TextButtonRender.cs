using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Controls;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.NUI.res.TextButtonRenderer.xaml", "TextButtonRenderer.xaml", typeof(Tizen.NUI.Renderers.TextButtonRenderer))]

namespace Tizen.NUI.Renderers
{
    public class TextButtonRenderer : BaseRenderer
    {
        public TextButtonRenderer() : base()
        {
            textLabel = NameScopeExtensions.FindByName<TextLabel>(layout, "textLabel");
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            Button button = sender as Button;
            switch (type)
            {
                case "Size":
                    textLabel.Size2D = button.Size2D ;
                    break;
                case "Text":
                    textLabel.Text = button.Text;
                    break;
                default:
                    break;
            }
        }

        public override void OnStateChanged(View.States state)
        {
            textLabel.State = state;
        }

        private TextLabel textLabel;
    }

}
