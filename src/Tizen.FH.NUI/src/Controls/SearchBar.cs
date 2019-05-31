/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;
using System.ComponentModel;
using StyleManager = Tizen.NUI.CommonUI.StyleManager;

namespace Tizen.FH.NUI.Controls
{
    /// <summary>
    /// SearchBar is a component which allow you input text and show the match results
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SearchBar : Control
    {
        private InputField inputField = null;
        private View resultListRoot = null;
        //private Animation expandAni, shrinkAni;

        private SearchBarAttributes searchBarAttrs = null;

        private bool isEnabled = true;
        private uint resultListHeight = 0;

        private EventHandler<InputField.ButtonClickArgs> cancelBtnClickHandler;
        private EventHandler<InputField.ButtonClickArgs> searchBtnClickHandler;
        /// <summary>
        /// Initializes a new instance of the SearchBar class.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchBar() : base()
        {
            Initialize();
        }
        /// <summary>
        /// Initializes a new instance of the SearchBar class.
        /// </summary>
        /// <param name="style">Create Header by special style defined in UX.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SearchBar(string style) : base(style)
        {
            Initialize();
        }
        /// <summary>
        /// The Click Event attached to the Cancel Button
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<InputField.ButtonClickArgs> CancelButtonClickEvent
        {
            add
            {
                cancelBtnClickHandler += value;
            }
            remove
            {
                cancelBtnClickHandler -= value;
            }
        }
        /// <summary>
        /// The Click Event attached to the Search Button
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<InputField.ButtonClickArgs> SearchButtonClickEvent
        {
            add
            {
                searchBtnClickHandler += value;
            }
            remove
            {
                searchBtnClickHandler -= value;
            }
        }
        /// <summary>
        /// Set the status of the Search Bar editable or not
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool StateEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled == value)
                {
                    return;
                }
                isEnabled = value;
            }
        }
        /// <summary>
        /// The inputed Text that showed in the Search Bar
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Text
        {
            get
            {
                return inputField.Text;
            }
            set
            {
                if (inputField != null)
                {
                    inputField.Text = value;
                }
            }
        }
        /// <summary>
        /// The Hint Text that showed before you input
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HintText
        {
            get
            {
                return inputField.HintText;
            }
            set
            {
                if (inputField != null)
                {
                    inputField.HintText = value;
                }
            }
        }
        /// <summary>
        /// The Color of the Text that showed in the Search Bar
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TextColor
        {
            get
            {
                return inputField.TextColor;
            }
            set
            {
                if (inputField != null)
                {
                    inputField.TextColor = value;
                }
            }
        }
        /// <summary>
        /// The Height of the Result List
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint ResultListHeight
        {
            get
            {
                return resultListHeight;
            }
            set
            {
                resultListHeight = value;
                if (resultListRoot != null)
                {
                    resultListRoot.SizeHeight = resultListHeight;
                }
            }
        }
        /// <summary>
        /// Expand the Search List Height
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ExpandSearchList(bool enableAni = false)
        {
            if (resultListRoot != null)
            {
                resultListRoot.Size2D.Height = (int)resultListHeight;
            }
        }
        /// <summary>
        /// Shrink the Search List
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ShrinkSearchList(bool enableAni = false)
        {
            if (resultListRoot != null)
            {
                resultListRoot.Size2D.Height = 0;
            }
        }

        /// <summary>
        /// Dispose Search Bar and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
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
                if (resultListRoot != null)
                {
                    this.Remove(resultListRoot);
                    resultListRoot.Dispose();
                    resultListRoot = null;
                }
                if (inputField != null)
                {
                    inputField.SearchButtonClickEvent -= OnSearchButtonClickEvent;
                    inputField.CancelButtonClickEvent -= OnCancelButtonClickEvent;
                    this.Remove(inputField);
                    inputField.Dispose();
                    inputField = null;
                }
            }
            base.Dispose(type);
        }
        /// <summary>
        /// Get Search Bar attribues.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new SearchBarAttributes();
        }
        /// <summary>
        /// Update Search Bar by attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            inputField.LayoutDirection = LayoutDirection;
            ApplyAttributes(this, searchBarAttrs);
            ApplyAttributes(inputField, searchBarAttrs.SearchBoxAttributes);
            ApplyAttributes(resultListRoot, searchBarAttrs.ResultListAttributes);
            RelayoutComponents();
        }
        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            SearchBarAttributes tempAttributes = StyleManager.Instance.GetAttributes(base.style) as SearchBarAttributes;
            if (tempAttributes != null)
            {
                attributes = searchBarAttrs = tempAttributes;
                RelayoutRequest();
            }
        }

        private void Initialize()
        {
            searchBarAttrs = attributes as SearchBarAttributes;
            if (searchBarAttrs == null)
            {
                throw new Exception("SearchBar attribute parse error.");
            }
            if (searchBarAttrs.SearchBoxAttributes != null && inputField == null)
            {
                inputField = new InputField("DefaultSearchInputField")
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopCenter,
                    PivotPoint = Tizen.NUI.PivotPoint.TopCenter,
                    PositionUsesPivotPoint = true
                };
                this.Add(inputField);
                inputField.SearchButtonClickEvent += OnSearchButtonClickEvent;
                inputField.CancelButtonClickEvent += OnCancelButtonClickEvent;
            }
            if (searchBarAttrs.ResultListAttributes != null && resultListRoot == null)
            {
                resultListRoot = new View()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.Fixed,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopCenter,
                    PivotPoint = Tizen.NUI.PivotPoint.TopCenter,
                    PositionUsesPivotPoint = true
                };
                this.Add(resultListRoot);
            }
        }

        private void RelayoutComponents()
        {
            inputField.Size2D = new Size2D(Size2D.Width - Space() * 2, Size2D.Height);

            resultListRoot.Size2D.Height = 0;// (int)resultListHeight;
            resultListRoot.PositionY = Size2D.Height;
        }

        private int Space()
        {
            int space = 0;
            if (searchBarAttrs != null && searchBarAttrs.Space != null)
            {
                space = searchBarAttrs.Space.Value;
            }
            return space;
        }

        private void OnSearchButtonClickEvent(object source, InputField.ButtonClickArgs e)
        {
            if (searchBtnClickHandler != null)
            {
                InputField.ButtonClickArgs args = new InputField.ButtonClickArgs();
                args.State = e.State;
                searchBtnClickHandler(this, args);
            }
        }

        private void OnCancelButtonClickEvent(object source, InputField.ButtonClickArgs e)
        {
            if (cancelBtnClickHandler != null)
            {
                InputField.ButtonClickArgs args = new InputField.ButtonClickArgs();
                args.State = e.State;
                cancelBtnClickHandler(this, args);
            }
        }
    }
}
