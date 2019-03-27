using Tizen.NUI;
using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.ListItem.NextDepthListItemAttributes.xaml", "NextDepthListItemAttributes.xaml", typeof(Tizen.FH.NUI.Controls.NextDepthListItemAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class NextDepthListItemAttributes : StyleBase
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
                    Size2D = new Size2D(48, 48),
                },

                RightIconAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(48, 48),
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
