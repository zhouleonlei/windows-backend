using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;
using Tizen.NUI;
using System.ComponentModel;

namespace Tizen.FH.NUI.Controls
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Pagination : Tizen.NUI.CommonUI.Pagination
    {
        private PaginationAttributes paginationAttributes;
        private ImageView returnArrow;
        private ImageView nextArrow;

        private int indicatorCount;
        private int selectedIndex;
        private int maxCountOnePage = 10;

        private TapGestureDetector tapGestureDetector;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Pagination() : base()
        {
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Pagination(string style) : base(style)
        {
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector ReturnArrowURLs
        {
            get
            {
                return paginationAttributes?.ReturnArrowAttributes?.ResourceURL;
            }
            set
            {
                if (value == null || paginationAttributes == null)
                {
                    return;
                }
                if (paginationAttributes.ReturnArrowAttributes == null)
                {
                    paginationAttributes.ReturnArrowAttributes = new ImageAttributes
                    {
                        ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                        PositionUsesPivotPoint = true
                    };
                }
                paginationAttributes.ReturnArrowAttributes.ResourceURL = value;
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector NextArrowURLs
        {
            get
            {
                return paginationAttributes?.NextArrowAttributes?.ResourceURL;
            }
            set
            {
                if (value == null || paginationAttributes == null)
                {
                    return;
                }
                if (paginationAttributes.NextArrowAttributes == null)
                {
                    paginationAttributes.NextArrowAttributes = new ImageAttributes
                    {
                        ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                        PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                        PositionUsesPivotPoint = true
                    };
                }
                paginationAttributes.NextArrowAttributes.ResourceURL = value;
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D ReturnArrowSize
        {
            get
            {
                return paginationAttributes?.ReturnArrowAttributes?.Size2D;
            }
            set
            {
                if (value == null || paginationAttributes == null)
                {
                    return;
                }
                if (paginationAttributes.ReturnArrowAttributes == null)
                {
                    paginationAttributes.ReturnArrowAttributes = new ImageAttributes
                    {
                        ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                        PositionUsesPivotPoint = true
                    };
                }
                paginationAttributes.ReturnArrowAttributes.Size2D = value;
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D NextArrowSize
        {
            get
            {
                return paginationAttributes?.NextArrowAttributes?.Size2D;
            }
            set
            {
                if (value == null || paginationAttributes == null)
                {
                    return;
                }
                if (paginationAttributes.NextArrowAttributes == null)
                {
                    paginationAttributes.NextArrowAttributes = new ImageAttributes
                    {
                        ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                        PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                        PositionUsesPivotPoint = true
                    };
                }
                paginationAttributes.NextArrowAttributes.Size2D = value;
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int IndicatorCount
        {
            get
            {
                return indicatorCount;
            }
            set
            {
                if (indicatorCount == value)
                {
                    return;
                }
                indicatorCount = value;

                LayoutUpdate();
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;

                LayoutUpdate();
            }
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (tapGestureDetector != null)
                {
                    tapGestureDetector.Detected -= OnMyTapGestureDetected;
                    tapGestureDetector.Dispose();
                    tapGestureDetector = null;
                }

                if (returnArrow != null)
                {
                    this.Remove(returnArrow);
                    returnArrow.Dispose();
                    returnArrow = null;
                }
                if (nextArrow != null)
                {
                    this.Remove(nextArrow);
                    nextArrow.Dispose();
                    nextArrow = null;
                }
            }

            base.Dispose(type);
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new PaginationAttributes();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate(Attributes attributtes)
        {
            base.OnUpdate(attributtes);

            paginationAttributes = attributes as PaginationAttributes;
            if (paginationAttributes == null)
            {
                return;
            }

            ApplyAttributes(returnArrow, paginationAttributes.ReturnArrowAttributes);
            ApplyAttributes(nextArrow, paginationAttributes.NextArrowAttributes);

            int maxCount = GetMaxCountOnePage();
            if (maxCountOnePage != maxCount)
            {
                maxCountOnePage = maxCount;
                LayoutUpdate();
            }
        }

        private void Initialize()
        {
            returnArrow = new ImageView()
            {
                Name = "ReturnArrow",
                //BackgroundColor = Color.Cyan
            };
            this.Add(returnArrow);

            nextArrow = new ImageView()
            {
                Name = "NextArrow",
                //BackgroundColor = Color.Cyan
            };
            this.Add(nextArrow);

            tapGestureDetector = new TapGestureDetector();
            tapGestureDetector.Detected += OnMyTapGestureDetected;
            tapGestureDetector.Attach(returnArrow);
            tapGestureDetector.Attach(nextArrow);
            tapGestureDetector.Attach(container);

            paginationAttributes = attributes as PaginationAttributes;
            if (paginationAttributes == null)
            {
                throw new Exception("Pagination attributes is null.");
            }
        }

        private void OnMyTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            if (e.View == returnArrow)
            {
                if (selectedIndex > 0)
                {
                    SelectedIndex = selectedIndex - 1;
                }
            }
            else if (e.View == nextArrow)
            {
                if (selectedIndex < indicatorCount - 1)
                {
                    SelectedIndex = selectedIndex + 1;
                }
            }
            else if (e.View == container)
            {
                if (e.TapGesture.LocalPoint.X < selectIndicator.Position.X)
                {
                    if (selectedIndex > 0)
                    {
                        SelectedIndex = selectedIndex - 1;
                    }
                }
                else if (e.TapGesture.LocalPoint.X > selectIndicator.Position.X + paginationAttributes.IndicatorSize.Width)
                {
                    if (selectedIndex < indicatorCount - 1)
                    {
                        SelectedIndex = selectedIndex + 1;
                    }
                }
            }
        }

        private void LayoutUpdate()
        {
            int pageCount = (indicatorCount + maxCountOnePage - 1) / maxCountOnePage;
            int pageIndex = selectedIndex / maxCountOnePage;
            if (pageIndex == pageCount - 1)
            {
                base.IndicatorCount = indicatorCount % maxCountOnePage;
            }
            else
            {
                base.IndicatorCount = maxCountOnePage;
            }
            base.SelectedIndex = selectedIndex % maxCountOnePage;

            if (pageIndex == 0)
            {
                returnArrow.Hide();
            }
            else
            {
                returnArrow.Show();
            }

            if (pageIndex == pageCount - 1)
            {
                nextArrow.Hide();
            }
            else
            {
                nextArrow.Show();
            }
        }

        private int GetMaxCountOnePage()
        {
            int count = 10;
            if (paginationAttributes != null)
            {
                int returnArrowWidth = 0, nextArrowWidth = 0;
                if (paginationAttributes.ReturnArrowAttributes != null && paginationAttributes.ReturnArrowAttributes.Size2D != null)
                {
                    returnArrowWidth = paginationAttributes.ReturnArrowAttributes.Size2D.Width;
                }
                if (paginationAttributes.NextArrowAttributes != null && paginationAttributes.NextArrowAttributes.Size2D != null)
                {
                    nextArrowWidth = paginationAttributes.NextArrowAttributes.Size2D.Width;
                }
                int indicatorWidth = 0, indicatorHeight = 0;
                int indicatorSpacing = 0;
                if (paginationAttributes.IndicatorSize != null)
                {
                    indicatorWidth = paginationAttributes.IndicatorSize.Width;
                    indicatorHeight = paginationAttributes.IndicatorSize.Height;
                }
                indicatorSpacing = paginationAttributes.IndicatorSpacing;

                count = (int)((this.SizeWidth - returnArrowWidth - nextArrowWidth) / (indicatorWidth + indicatorSpacing));
            }
            return count;
        }
    }
}
