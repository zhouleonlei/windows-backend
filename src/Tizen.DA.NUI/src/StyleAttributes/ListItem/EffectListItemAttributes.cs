using Tizen.NUI;
using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.ListItem.EffectListItemAttributes.xaml", "EffectListItemAttributes.xaml", typeof(Tizen.FH.NUI.Controls.EffectListItemAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class EffectListItemAttributes : StyleBase
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
                        Normal = new Color(0, 0, 0, 1),
                        Pressed = new Color(0, 0, 0, 1),
                        Selected = Utility.Hex2Color(Constants.APP_COLOR_UTILITY, 1),
                        Disabled = new Color(0, 0, 0, 0.4f),
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
