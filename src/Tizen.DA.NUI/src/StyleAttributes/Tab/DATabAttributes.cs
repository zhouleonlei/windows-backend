using Tizen.NUI.Xaml;
using Tizen.NUI;
using Tizen.NUI.Controls;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Tab.TabAttributes.xaml", "TabAttributes.xaml", typeof(Tizen.FH.NUI.Controls.DATabAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class DATabAttributes : AttributesContainer
    {
        protected override Attributes GetAttributes()
        {
            TabAttributes attributes = new TabAttributes
            {
                IsNatureTextWidth = false,
                Space = new Vector4(56, 56, 1, 0),
                UnderLineAttributes = new ViewAttributes
                {
                    Size2D = new Size2D(1, 3),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                    BackgroundColor = new ColorSelector { All = new Color(0.05f, 0.63f, 0.9f, 1) },
                },
                TextAttributes = new TextAttributes
                {
                    PointSize = new FloatSelector { All = 25 },
                    TextColor = new ColorSelector
                    {
                        Normal = Color.Black,
                        Selected = new Color(0.05f, 0.63f, 0.9f, 1),
                    },
                },
            };
            return attributes;
        }
    }
}
