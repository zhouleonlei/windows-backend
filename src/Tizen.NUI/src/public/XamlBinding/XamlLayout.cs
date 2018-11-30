using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    [ContentProperty("Content")]
    public class XamlLayout : VisualView
    {
        public XamlLayout()
        {
            IsCreateByXaml = true;
            WidthResizePolicy = ResizePolicyType.FillToParent;
            HeightResizePolicy = ResizePolicyType.FillToParent;
        }

        internal VisualView Root
        {
            get
            {
                return this;
            }
        }

        internal object Content
        {
            get
            {
                return null;
            }
            set
            {
                if (value is VisualMap visualMap)
                {
                    Root.AddVisual("123", visualMap);
                }
                else if (value is View view)
                {
                    Root.Add(view);
                }
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
