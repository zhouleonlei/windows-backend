using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class GroupIndexListItemAttributes : StyleBase
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
                SpaceBetweenRightItemAndText = 0,
                BackgroundColor = new ColorSelector
                {
                    All = Utility.Hex2Color(0x282828, 0.05f),
                },
                SwitchStyle = "ListIndexSwitch",
                StyleType = ListItem.StyleTypes.GroupIndex,
                MainTextAttributes = new TextAttributes
                {
                    HorizontalAlignment = HorizontalAlignment.Begin,
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
                },
                MainText2Attributes = new TextAttributes
                {
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Center,
                    PointSize = new FloatSelector
                    {
                        All = 24,
                    },
                    FontFamily = "SamsungOne 500C",
                    TextColor = new ColorSelector
                    {
                        All = new Color(0, 0, 0, 1),
                    }
                },
                RightItemRootViewAttributes = new ViewAttributes
                {

                },

                RightIconAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "6. List/list_index_next_button.png"
                    }
                }
            };

            return attributes;
        }
    }
}
