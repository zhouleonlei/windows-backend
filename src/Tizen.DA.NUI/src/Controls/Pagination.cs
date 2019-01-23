using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using Tizen.NUI;

namespace Tizen.FH.NUI.Controls
{
    public class Pagination : Tizen.NUI.Controls.Pagination
    {
        private PaginationAttributes paginationAttributes;
        private ImageView returnArrow;
        private ImageView nextArrow;

        private int indicatorCount;
        private int selectedIndex;
        private int maxCountOnePage = 10;

        private TapGestureDetector tapGestureDetector;

        public Pagination() : this(null) { }
        public Pagination(string style) : base(style)
        {
            Initialize();
        }

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
                else if (e.TapGesture.LocalPoint.X > selectIndicator.Position.X + indicatorWidth)
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
                    returnArrowWidth = paginationAttributes.ReturnArrowAttributes.Size2D.All.Width;
                }
                if (paginationAttributes.NextArrowAttributes != null && paginationAttributes.NextArrowAttributes.Size2D != null)
                {
                    nextArrowWidth = paginationAttributes.NextArrowAttributes.Size2D.All.Width;
                }
                int indicatorWidth = 0, indicatorHeight = 0;
                int indicatorSpacing = 0;
                if (paginationAttributes.IndicatorSize != null)
                {
                    indicatorWidth = paginationAttributes.IndicatorSize.Width;
                    indicatorHeight = paginationAttributes.IndicatorSize.Height;
                }
                if (paginationAttributes.IndicatorSpacing != null)
                {
                    indicatorSpacing = paginationAttributes.IndicatorSpacing.Value;
                }

                count = (int)((this.SizeWidth - returnArrowWidth - nextArrowWidth) / (indicatorWidth + indicatorSpacing));
            }
            return count;
        }
    }
}
