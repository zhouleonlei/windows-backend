using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.CommonUI
{
    public class Pagination: Control
    {
        protected VisualView container;
        protected ImageVisual selectIndicator;

        private int indicatorCount = 0;
        private int selectedIndex = -1;

        private List<ImageVisual> indicatorList = new List<ImageVisual>();

        private PaginationAttributes paginationAttributes;

        public Pagination() : base()
        {
            Initialize();
        }

        public Pagination(string style) : base(style)
        {
            Initialize();
        }

        public Size2D IndicatorSize
        {
            get
            {
                return (Size2D)paginationAttributes?.IndicatorSize;
            }
            set
            {
                if (value == null || paginationAttributes == null)
                {
                    return;
                }
                paginationAttributes.IndicatorSize = value;
                RelayoutRequest();
            }
        }

        public string IndicatorBackgroundURL
        {
            get
            {
                return (string)paginationAttributes?.IndicatorBackgroundURL;
            }
            set
            {
                if (value == null || paginationAttributes == null)
                {
                    return;
                }
                paginationAttributes.IndicatorBackgroundURL = value;
                RelayoutRequest();
            }
        }

        public string IndicatorSelectURL
        {
            get
            {
                return (string)paginationAttributes?.IndicatorSelectURL;
            }
            set
            {
                if (value == null || paginationAttributes == null)
                {
                    return;
                }
                paginationAttributes.IndicatorSelectURL = value;
                RelayoutRequest();
            }
        }

        public int IndicatorSpacing
        {
            get
            {
                return (int)paginationAttributes?.IndicatorSpacing;
            }
            set
            {
                if (paginationAttributes == null)
                {
                    return;
                }
                paginationAttributes.IndicatorSpacing = value;
                RelayoutRequest();
            }
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
            return new PaginationAttributes();
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

            for (int i = 0; i < indicatorList.Count; i++)
            {
                ImageVisual indicator = indicatorList[i];
                indicator.URL = paginationAttributes.IndicatorBackgroundURL;
                indicator.Size = paginationAttributes.IndicatorSize;
                indicator.Position = new Position2D((int)(paginationAttributes.IndicatorSize.Width + paginationAttributes.IndicatorSpacing) * i, 0);
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
                throw new Exception("Pagination attributes is null.");
            }
        }

        private void CreateIndicator()
        {
            if (paginationAttributes == null)
            {
                return;
            }
            ImageVisual indicator = new ImageVisual
            {
                URL = paginationAttributes.IndicatorBackgroundURL,
                Size = paginationAttributes.IndicatorSize
            };
            indicator.Position = new Position2D((int)(paginationAttributes.IndicatorSize.Width + paginationAttributes.IndicatorSpacing) * indicatorList.Count, 0);
            container.AddVisual("Indicator" + indicatorList.Count, indicator);
            indicatorList.Add(indicator);
        }

        private void UpdateContainer()
        {
            if (paginationAttributes == null)
            {
                return;
            }
            if (indicatorList.Count > 0)
            {
                container.SizeWidth = (paginationAttributes.IndicatorSize.Width + paginationAttributes.IndicatorSpacing) * indicatorList.Count - paginationAttributes.IndicatorSpacing;
            }
            else
            {
                container.SizeWidth = 0;
            }
            container.SizeHeight = paginationAttributes.IndicatorSize.Height;
            container.PositionX = (int)((this.SizeWidth - container.SizeWidth) / 2);
        }
    }
}
