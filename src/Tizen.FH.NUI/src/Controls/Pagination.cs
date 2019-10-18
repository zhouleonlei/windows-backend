/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI;

namespace Tizen.FH.NUI.Controls
{
    /// <summary>
    /// Pagination shows the number of pages available and the currently active page.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Pagination : Tizen.NUI.Components.Pagination
    {
        private PaginationAttributes paginationAttributes;
        private ImageView returnArrow;
        private ImageView nextArrow;

        private int indicatorCount;
        private int selectedIndex;
        private int maxCountOnePage = 10;

        private TapGestureDetector tapGestureDetector;

        private EventHandler<SelectChangeEventArgs> selectChangeEventHandlers;

        /// <summary>
        /// Creates a new instance of a Pagination.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Pagination() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Pagination using style.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Pagination(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Select indicator changed event.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<SelectChangeEventArgs> SelectChangeEvent
        {
            add
            {
                selectChangeEventHandlers += value;
            }

            remove
            {
                selectChangeEventHandlers -= value;
            }
        }

        /// <summary>
        /// Gets or sets the resource of return arrow button.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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

        /// <summary>
        /// Gets or sets the resource of next arrow button.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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

        /// <summary>
        /// Gets or sets the size of return arrow button.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size ReturnArrowSize
        {
            get
            {
                return paginationAttributes?.ReturnArrowAttributes?.Size;
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
                paginationAttributes.ReturnArrowAttributes.Size = value;
            }
        }

        /// <summary>
        /// Gets or sets the size of next arrow button.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size NextArrowSize
        {
            get
            {
                return paginationAttributes?.NextArrowAttributes?.Size;
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
                paginationAttributes.NextArrowAttributes.Size = value;
            }
        }

        /// <summary>
        /// Gets or sets the count of the pages/indicators.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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

        /// <summary>
        /// Gets or sets the index of the select indicator.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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
                if (selectedIndex == value)
                {
                    return;
                }
                int previousIndex = selectedIndex;

                selectedIndex = value;

                LayoutUpdate();

                SelectChangeEventArgs args = new SelectChangeEventArgs();
                args.PreviousIndex = previousIndex;
                args.CurrentIndex = selectedIndex;
                OnSelectChangeEvent(this, args);

            }
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        /// <since_tizen> 5.5 </since_tizen>
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
                    tapGestureDetector.Detected -= OnTapGestureDetected;
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

        /// <summary>
        /// you can override it to create your own default attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new PaginationAttributes();
        }

        /// <summary>
        /// you can override it to update your own resources.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            base.OnUpdate();

            ApplyAttributes(returnArrow, paginationAttributes.ReturnArrowAttributes);
            ApplyAttributes(nextArrow, paginationAttributes.NextArrowAttributes);

            int maxCount = GetMaxCountOnePage();
            if (maxCountOnePage != maxCount)
            {
                maxCountOnePage = maxCount;
                LayoutUpdate();
            }
        }

        /// <summary>
        /// you can override it to handle the tap gesture.
        /// </summary>
        /// <param name="source">TapGestureDetector</param>
        /// <param name="e">DetectedEventArgs</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
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
            else
            {
                Vector2 selectIndicatorPosition = GetIndicatorPosition(selectedIndex % maxCountOnePage);
                if (e.TapGesture.LocalPoint.X < selectIndicatorPosition.X)
                {
                    if (selectedIndex > 0)
                    {
                        SelectedIndex = selectedIndex - 1;
                    }
                }
                else if (e.TapGesture.LocalPoint.X > selectIndicatorPosition.X + paginationAttributes.IndicatorSize.Width)
                {
                    if (selectedIndex < indicatorCount - 1)
                    {
                        SelectedIndex = selectedIndex + 1;
                    }
                }
            }
        }

        private void Initialize()
        {
            paginationAttributes = attributes as PaginationAttributes;
            if (paginationAttributes == null)
            {
                throw new Exception("Pagination attributes parse error.");
            }

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
            tapGestureDetector.Detected += OnTapGestureDetected;
            tapGestureDetector.Attach(returnArrow);
            tapGestureDetector.Attach(nextArrow);
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
                if (paginationAttributes.ReturnArrowAttributes != null && paginationAttributes.ReturnArrowAttributes.Size != null)
                {
                    returnArrowWidth = (int)paginationAttributes.ReturnArrowAttributes.Size.Width;
                }
                if (paginationAttributes.NextArrowAttributes != null && paginationAttributes.NextArrowAttributes.Size != null)
                {
                    nextArrowWidth = (int)paginationAttributes.NextArrowAttributes.Size.Width;
                }
                int indicatorWidth = 0, indicatorHeight = 0;
                int indicatorSpacing = 0;
                if (paginationAttributes.IndicatorSize != null)
                {
                    indicatorWidth = (int)paginationAttributes.IndicatorSize.Width;
                    indicatorHeight = (int)paginationAttributes.IndicatorSize.Height;
                }
                indicatorSpacing = paginationAttributes.IndicatorSpacing;

                count = (int)((this.SizeWidth - returnArrowWidth - nextArrowWidth) / (indicatorWidth + indicatorSpacing));
            }
            return count;
        }

        private void OnSelectChangeEvent(object sender, SelectChangeEventArgs e)
        {
            selectChangeEventHandlers?.Invoke(sender, e);
        }


        /// <summary>
        /// SelectChange Event Arguments.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class SelectChangeEventArgs : EventArgs
        {
            /// <summary>
            /// Previous select indicator index.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int PreviousIndex;

            /// <summary>
            /// Previous select indicator index.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int CurrentIndex;
        }

    }
}
