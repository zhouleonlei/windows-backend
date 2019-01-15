using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    public class Pagination: Control
    {
        protected int indicatorWidth = 0;
        protected int indicatorHeight = 0;
        protected int indicatorSpacing = 0;

        protected View container;
        protected ImageView selectIndicator;

        private int indicatorCount = 0;
        private int selectedIndex = -1;

        private string indicatorBackgroundURL;

        private List<ImageView> indicatorList = new List<ImageView>();

        private PaginationAttributes paginationAttributes;

        public Pagination() : this(null) { }
        public Pagination(string style) : base(style)
        {
            Initialize();
        }

        public int IndicatorCount
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
                if (indicatorCount < value)
                {
                    for (int i = indicatorCount; i < value; i++)
                    {
                        CreateIndicator();
                    }
                }
                else
                {
                    for (int i = value; i < indicatorCount; i++)
                    {
                        ImageView indicator = indicatorList[i];
                        container.Remove(indicator);
                        indicator.Dispose();
                    }
                    indicatorList.RemoveRange(value, indicatorCount - value);
                }
                indicatorCount = value;

                UpdateContainer();
            }
        }

        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                if (selectedIndex == value)
                {
                    return;
                }
                if (selectedIndex >= 0 && selectedIndex < indicatorCount)
                {
                    SelectOut(indicatorList[selectedIndex]);
                }
                selectedIndex = value;
                if (selectedIndex >= 0 && selectedIndex < indicatorCount)
                {
                    SelectIn(indicatorList[selectedIndex]);
                }
            }
        }

        protected virtual void SelectOut(View selectOutIndicator)
        {

        }

        protected virtual void SelectIn(View selectInIndicator)
        {
            selectInIndicator.Add(selectIndicator);
        }

        protected override Attributes GetAttributes()
        {
            return null;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (selectIndicator != null)
                {
                    selectIndicator.GetParent()?.Remove(selectIndicator);
                    selectIndicator.Dispose();
                    selectIndicator = null;
                }

                foreach(ImageView indicator in indicatorList)
                {
                    container.Remove(indicator);
                    indicator.Dispose();
                }
                indicatorList.Clear();

                this.Remove(container);
                container.Dispose();
                container = null;
            }

            base.Dispose(type);
        }

        protected override void OnUpdate(Attributes attributtes)
        {
            paginationAttributes = attributes as PaginationAttributes;
            if (paginationAttributes == null)
            {
                return;
            }

            if (paginationAttributes.IndicatorSize != null)
            {
                indicatorWidth = paginationAttributes.IndicatorSize.Width;
                indicatorHeight = paginationAttributes.IndicatorSize.Height;
            }
            if (paginationAttributes.IndicatorSpacing != null)
            {
                indicatorSpacing = paginationAttributes.IndicatorSpacing.Value;
            }

            indicatorBackgroundURL = paginationAttributes.IndicatorBackgroundURL;
            for (int i = 0; i < indicatorList.Count; i++)
            {
                ImageView indicator = indicatorList[i];
                indicator.ResourceUrl = paginationAttributes.IndicatorBackgroundURL;
                indicator.Size2D = paginationAttributes.IndicatorSize;
                indicator.PositionX = (int)(indicatorWidth + indicatorSpacing) * i;
            }

            selectIndicator.ResourceUrl = paginationAttributes.IndicatorSelectURL;
            selectIndicator.Size2D = paginationAttributes.IndicatorSize;

            //UpdateContainer();
        }

        private void Initialize()
        {
            container = new View()
            {
                Name = "Container",
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                PositionUsesPivotPoint = true,
                //BackgroundColor = Color.Yellow
            };
            this.Add(container);

            selectIndicator = new ImageView()
            {
                Name = "SelectIndicator"
            };

            paginationAttributes = attributes as PaginationAttributes;
            if (paginationAttributes == null)
            {
                return;
            }

            if (paginationAttributes.IndicatorSize != null)
            {
                indicatorWidth = paginationAttributes.IndicatorSize.Width;
                indicatorHeight = paginationAttributes.IndicatorSize.Height;
            }
            if (paginationAttributes.IndicatorSpacing != null)
            {
                indicatorSpacing = paginationAttributes.IndicatorSpacing.Value;
            }
        }

        private void CreateIndicator()
        {
            ImageView indicator = new ImageView
            {
                Name = "Indicator",
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                PositionUsesPivotPoint = true
            };
            indicator.ResourceUrl = indicatorBackgroundURL;
            indicator.PositionX = (int)(indicatorWidth + indicatorSpacing) * indicatorList.Count;
            container.Add(indicator);
            indicatorList.Add(indicator);
        }

        private void UpdateContainer()
        {
            if (indicatorList.Count > 0)
            {
                container.SizeWidth = (indicatorWidth + indicatorSpacing) * indicatorList.Count - indicatorSpacing;
            }
            else
            {
                container.SizeWidth = 0;
            }
            container.SizeHeight = indicatorHeight;
            container.PositionX = (int)((this.SizeWidth - container.SizeWidth) / 2);
        }
    }
}
