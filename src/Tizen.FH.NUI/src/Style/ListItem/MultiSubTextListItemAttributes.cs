using Tizen.NUI;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Controls
{
    internal class MultiSubTextListItemAttributes : StyleBase
    {
        protected internal override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            ListItemAttributes attributes = new ListItemAttributes
            {
                LeftSpace = 56,
                RightSpace = 56,
                MainTextAttributes = new TextAttributes
                {
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Center,
                    PointSize = new FloatSelector
                    {
                        All = 44,
                    },
                    FontFamily = "SamsungOne 400",
                    TextColor = new ColorSelector
                    {
                        All = new Color(0, 0, 0, 1),
                    },
                },
                SubTextAttributes = new TextAttributes
                {
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Center,
                    PointSize = new FloatSelector
                    {
                        All = 30,
                    },
                    FontFamily = "SamsungOne 500C",
                    TextColor = new ColorSelector
                    {
                        All = new Color(0, 0, 0, 0.75f),
                    }
                },
                DividerViewAttributes = new ImageAttributes
                {
                    Size = new Size(0, 1),
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0, 0, 0, 0.1f),
                    }
                }

            };

            return attributes;
        }
    }
}
