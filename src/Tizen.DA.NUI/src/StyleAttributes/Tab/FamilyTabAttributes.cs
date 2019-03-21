using Tizen.NUI.Xaml;
using Tizen.NUI;
using Tizen.NUI.Controls;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Tab.FamilyTabAttributes.xaml", "FamilyTabAttributes.xaml", typeof(Tizen.FH.NUI.Controls.FamilyTabAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class FamilyTabAttributes : AttributesContainer
    {
        protected override Attributes GetAttributes()
        {
            TabAttributes attributes = new TabAttributes
            {
                Space = new Vector4(56, 56, 1, 0),
                UnderLineAttributes = new ViewAttributes
                {
                    Size2D = new Size2D(1, 3),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                    BackgroundColor = new ColorSelector { All = Utility.Hex2Color(Constants.APP_COLOR_FAMILY, 1) },
                },
                TextAttributes = new TextAttributes
                {
                    PointSize = new FloatSelector { All = 25 },
                    TextColor = new ColorSelector
                    {
                        Normal = Color.Black,
                        Selected = Utility.Hex2Color(Constants.APP_COLOR_FAMILY, 1),
                    },
                },
            };
            return attributes;
        }
    }
}
