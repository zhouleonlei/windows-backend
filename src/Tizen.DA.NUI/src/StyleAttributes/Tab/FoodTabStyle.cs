using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class FoodTabStyle : StyleBase
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
                    BackgroundColor = new ColorSelector { All = Utility.Hex2Color(Constants.APP_COLOR_FOOD, 1) },
                },
                TextAttributes = new TextAttributes
                {
                    PointSize = new FloatSelector { All = 25 },
                    TextColor = new ColorSelector
                    {
                        Normal = Color.Black,
                        Selected = Utility.Hex2Color(Constants.APP_COLOR_FOOD, 1),
                    },
                },
            };
            return attributes;
        }
    }
}
