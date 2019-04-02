using Tizen.NUI.CommonUI;
using Tizen.NUI;

namespace Tizen.FH.NUI.Controls
{
    internal class KitchenDatePickerStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return base.GetAttributes();
                
            }
            PickerAttributes attributes = new PickerAttributes
            {
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center,
                PositionUsesPivotPoint = true,
                YearRange = new Vector2(1900, 2099),
                BackgroundImageAttributes = new ImageAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    PositionUsesPivotPoint = true,
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "0. BG/background_default_overlay.png" }
                },
                FocusImageAttributes = new ImageAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                    Size2D = new Size2D(80, 80),
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/picker_date_select_9762d9.png" }
                },
                EndSelectedImageAttributes = new ImageAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                    Size2D = new Size2D(80, 80),
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_date_endscheduling.png" }
                },
                LeftArrowImageAttributes = new ImageAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                    Size2D = new Size2D(48, 48),
                    Position2D = new Position2D(344, 42),
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_spin_btn_back.png" }
                },
                RightArrowImageAttributes = new ImageAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 1, 1) },
                    Size2D = new Size2D(48, 48),
                    Position2D = new Position2D(640, 42),
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/picker_spin_btn_next.png" }
                },
                MonthTextAttributes = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 30 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Size2D = new Size2D(248, 68),
                    Position2D = new Position2D(392, 32),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                DateViewAttributes = new ViewAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    Size2D = new Size2D(1032, 528),
                    Position2D = new Position2D(0, 132)
                },
                SunTextAttributes = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 20 },
                    TextColor = new ColorSelector { All = Color.Red },
                    Text = new StringSelector { All = "Sun" },
                    Size2D = new Size2D(147, 88),
                    Position2D = new Position2D(0, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                MonTextAttributes = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 20 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Text = new StringSelector { All = "Mon" },
                    Size2D = new Size2D(147, 88),
                    Position2D = new Position2D(147, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                TueTextAttributes = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 20 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Text = new StringSelector { All = "Tue" },
                    Size2D = new Size2D(147, 88),
                    Position2D = new Position2D(295, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                WenTextAttributes = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 20 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Text = new StringSelector { All = "Wen" },
                    Size2D = new Size2D(147, 88),
                    Position2D = new Position2D(442, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                ThuTextAttributes = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 20 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Text = new StringSelector { All = "Thu" },
                    Size2D = new Size2D(147, 88),
                    Position2D = new Position2D(590, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                FriTextAttributes = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 20 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Text = new StringSelector { All = "Fri" },
                    Size2D = new Size2D(147, 88),
                    Position2D = new Position2D(737, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                SatTextAttributes = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 20 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Text = new StringSelector { All = "Sat" },
                    Size2D = new Size2D(147, 88),
                    Position2D = new Position2D(885, 0),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                DateTextAttributes = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 20 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Size2D = new Size2D(147, 88),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                DateText2Attributes = new TextAttributes
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    PositionUsesPivotPoint = true,
                    PointSize = new FloatSelector { All = 20 },
                    TextColor = new ColorSelector { All = Color.Black },
                    Size2D = new Size2D(148, 88),
                    HorizontalAlignment = Tizen.NUI.HorizontalAlignment.Center,
                    VerticalAlignment = Tizen.NUI.VerticalAlignment.Center
                },
                YearDropDownAttributes = new DropDownAttributes
                {
                    ButtonAttributes = new ButtonAttributes
                    {
                        TextAttributes = new TextAttributes
                        {
                            Text = new StringSelector { All = "Year" },
                            PointSize = new FloatSelector { All = 30 },
                            TextColor = new ColorSelector { All = new Color(0, 0, 0, 1) },
                            FontFamily = "SamsungOneUI 500",
                            PositionUsesPivotPoint = true,
                            ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                            PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                            WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                            HeightResizePolicy = ResizePolicyType.FillToParent,
                            Position2D = new Position2D(0, 0),
                            HorizontalAlignment = HorizontalAlignment.End,
                            VerticalAlignment = VerticalAlignment.Center,
                        },
                        IconAttributes = new ImageAttributes
                        {
                            Size2D = new Size2D(48, 48),
                            ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "6. List/list_ic_dropdown.png" },
                            PositionUsesPivotPoint = true,
                            ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                            PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                        },
                    },
                    ListBackgroundImageAttributes = new ImageAttributes
                    {
                        ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "10. Drop Down/dropdown_bg.png" },
                        Border = new RectangleSelector { All = new Rectangle(51, 51, 51, 51) },
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        WidthResizePolicy = ResizePolicyType.FitToChildren,
                        HeightResizePolicy = ResizePolicyType.FitToChildren,
                    },
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    Space = new Vector4(100, 0, 0, 0),
                    SpaceBetweenButtonTextAndIcon = 20,
                    ListMargin = new Vector4(20, 0, 20, 0),
                    BackgroundColor = new ColorSelector { All = new Color(1, 1, 1, 1) },
                    ListSize2D = new Size2D(304, 500),
                    ListPadding = new Extents(4, 4, 4, 4),
                    Size2D = new Size2D(288, 68),
                    Position2D = new Position2D(688, 32),
                    FocusedItemIndex = 0
                },
                YearDropDownItemAttributes = new DropDownItemAttributes
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    Size2D = new Size2D(250, 80),
                    CheckImageRightSpace = 16,
                    TextAttributes = new TextAttributes
                    {
                        Position2D = new Position2D(28, 0),
                        PointSize = new FloatSelector { All = 18 }
                    },
                    CheckImageAttributes = new ImageAttributes
                    {
                        Size2D = new Size2D(40, 40),
                        ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "10. Drop Down/dropdown_checkbox_on.png" },
                    },
                    BackgroundColor = new ColorSelector { Pressed = new Color(0, 0, 0, 0.4f), Other = new Color(1, 1, 1, 0)},
                }
            };
            return attributes;
        }
    }
}
