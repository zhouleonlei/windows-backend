using Tizen.NUI;
using Tizen.NUI.CommonUI;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Pagination.BasicPaginationStyle.xaml", "BasicPaginationStyle.xaml", typeof(Tizen.FH.NUI.Controls.BasicPaginationStyle))]
namespace Tizen.FH.NUI.Controls
{
    internal class BasicPaginationStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            PaginationAttributes attributes = new PaginationAttributes
            {
                IndicatorSize = new Size2D(26, 26),
                IndicatorBackgroundURL = CommonResource.Instance.GetFHResourcePath() + "9. Controller/pagination_ic_nor.png",
                IndicatorSelectURL = CommonResource.Instance.GetFHResourcePath() + "9. Controller/pagination_ic_sel.png",
                IndicatorSpacing = 8,
                ReturnArrowAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/pagination_ic_return.png"
                    },
                    Size2D = new Size2D(26, 26),
                    ParentOrigin = ParentOrigin.CenterLeft,
                    PivotPoint = PivotPoint.CenterLeft,
                    PositionUsesPivotPoint = true
                },
                NextArrowAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/pagination_ic_next.png"
                    },
                    Size2D = new Size2D(26, 26),
                    ParentOrigin = ParentOrigin.CenterRight,
                    PivotPoint = PivotPoint.CenterRight,
                    PositionUsesPivotPoint = true
                }
            };
            return attributes;
        }
    }
}

