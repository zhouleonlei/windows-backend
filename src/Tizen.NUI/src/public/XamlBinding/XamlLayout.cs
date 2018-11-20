using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    [ContentProperty("Content")]
    public class XamlLayout : View
    {
        public XamlLayout()
        {
            IsCreateByXaml = true;
            WidthResizePolicy = ResizePolicyType.FillToParent;
            HeightResizePolicy = ResizePolicyType.FillToParent;
        }

        internal View Root
        {
            get
            {
                return this;
            }
        }

        internal View Content
        {
            get
            {
                return null;
            }
            set
            {
                Root.Add(value);
            }
        }

        internal View RelateView
        {
            get
            {
                return relateView;
            }
            set
            {
                relateView = value;
                relateView.Add(Root);
            }
        }

        private View relateView;
    }
}
