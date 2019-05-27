using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class ItemAlignListItemAttributes : StyleBase
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
                SpaceBetweenLeftItemAndText = 24,
                SpaceBetweenRightItemAndText = 56,
                CheckBoxStyle = "CheckBox",
                StyleType = ListItem.StyleTypes.ItemAlign,
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
                LeftItemRootViewAttributes = new ViewAttributes
                {
                },
                
                RightItemRootViewAttributes = new ViewAttributes
                {
                },

                LeftIconAttributes = new ImageAttributes
                {
                },
                RightTextAttributes = new TextAttributes
                {
                    HorizontalAlignment = HorizontalAlignment.End,
                    VerticalAlignment = VerticalAlignment.Center,
                    PointSize = new FloatSelector
                    {
                        All = 30,
                    },
                    FontFamily = "SamsungOne 500",
                    TextColor = new ColorSelector
                    {
                        All = new Color(0, 0, 0, 1),
                    },
                }
            };

            return attributes;
        }
    }
}
