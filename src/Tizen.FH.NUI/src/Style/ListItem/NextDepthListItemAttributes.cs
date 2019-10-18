using Tizen.NUI;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Controls
{
    internal class NextDepthListItemAttributes : StyleBase
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
                SpaceBetweenRightItemAndText = 0,
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
                
                RightItemRootViewAttributes = new ViewAttributes
                {
                    Size = new Size(48, 48),
                },

                RightIconAttributes = new ImageAttributes
                {
                    Size = new Size(48, 48),
                    ResourceURL = new StringSelector
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "6. List/list_ic_arrow_right.png"
                    }
                }
            };

            return attributes;
        }
    }
}
