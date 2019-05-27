using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class DefaultListItemStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            ListItemAttributes attributes = new ListItemAttributes
            {
                LeftSpace = 56,
                RightSpace = 56,
                StyleType = ListItem.StyleTypes.Effect,
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
                DividerViewAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(0, 1),
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
