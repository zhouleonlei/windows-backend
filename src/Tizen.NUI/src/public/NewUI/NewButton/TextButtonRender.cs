using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    public class TextButtonRenderer : BaseRenderer
    {
        public TextButtonRenderer() : base()
        {
            textLabel = NameScopeExtensions.FindByName<TextLabel>(layout, "textLabel");
        }

        public override void OnPropertyChanged(string type, View sender)
        {
            NewButton button = sender as NewButton;
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
