using Tizen.NUI;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Controls
{
    internal class DefaultPaginationStyle : StyleBase
    {
        protected internal override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            PaginationAttributes attributes = new PaginationAttributes
            {
                IndicatorSize = new Size(26, 26),
                IndicatorBackgroundURL = CommonResource.Instance.GetFHResourcePath() + "9. Controller/pagination_ic_nor.png",
                IndicatorSelectURL = CommonResource.Instance.GetFHResourcePath() + "9. Controller/pagination_ic_sel.png",
                IndicatorSpacing = 8,
                ReturnArrowAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "9. Controller/pagination_ic_return.png"
                    },
                    Size = new Size(26, 26),
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
                    Size = new Size(26, 26),
                    ParentOrigin = ParentOrigin.CenterRight,
                    PivotPoint = PivotPoint.CenterRight,
                    PositionUsesPivotPoint = true
                }
            };
            return attributes;
        }
    }
}

