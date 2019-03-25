using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.CommonUI
{
    public class Pagination: Control
    {
        protected int indicatorWidth = 0;
        protected int indicatorHeight = 0;
        protected int indicatorSpacing = 0;

        protected VisualView container;
        protected ImageVisual selectIndicator;

        private int indicatorCount = 0;
        private int selectedIndex = -1;

        private string indicatorBackgroundURL = " ";

        private List<ImageVisual> indicatorList = new List<ImageVisual>();

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
                        ImageVisual indicator = indicatorList[i];
                        container.RemoveVisual("Indicator" + i);
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

        protected virtual void SelectOut(VisualMap selectOutIndicator)
        {

        }

        protected virtual void SelectIn(VisualMap selectInIndicator)
        {
            selectIndicator.Position = selectInIndicator.Position;
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
                container.RemoveAll();    
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
                ImageVisual indicator = indicatorList[i];
                indicator.URL = paginationAttributes.IndicatorBackgroundURL;
                indicator.Size = paginationAttributes.IndicatorSize;
                indicator.Position = new Position2D((int)(indicatorWidth + indicatorSpacing) * i, 0);
            }

            selectIndicator.URL = paginationAttributes.IndicatorSelectURL;
            selectIndicator.Size = paginationAttributes.IndicatorSize;

            //UpdateContainer();
        }

        private void Initialize()
        {
            container = new VisualView()
            {
                Name = "Container",
                ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                PositionUsesPivotPoint = true,
                //BackgroundColor = Color.Yellow
            };
            this.Add(container);

            selectIndicator = new ImageVisual()
            {
                URL = " "
            };
            container.AddVisual("SelectIndicator", selectIndicator);

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
            ImageVisual indicator = new ImageVisual
            {
                URL = indicatorBackgroundURL,
                Size = new Size2D(indicatorWidth, indicatorHeight)
            };
            indicator.Position = new Position2D((int)(indicatorWidth + indicatorSpacing) * indicatorList.Count, 0);
            container.AddVisual("Indicator" + indicatorList.Count, indicator);
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
