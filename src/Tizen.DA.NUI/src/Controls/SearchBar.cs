using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;
using StyleManager = Tizen.NUI.CommonUI.StyleManager;

namespace Tizen.FH.NUI.Controls
{
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

        static SearchBar()
        {
            RegisterStyle("DADefaultSearchBar", typeof(SearchBarAttributes));
        }

        public SearchBar() : this("DADefaultSearchBar")
        {
            Initialize();
        }

        public SearchBar(string style) : base(style)
        {
            Initialize();
        }

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

        public void ExpandSearchList(bool enableAni = false)
        {
            if (resultListRoot != null)
            {
                resultListRoot.Size2D.Height = (int)resultListHeight;
            }
        }

        public void ShrinkSearchList(bool enableAni = false)
        {
            if (resultListRoot != null)
            {
                resultListRoot.Size2D.Height = 0;
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

        protected override Attributes GetAttributes()
        {
            return null;
        }

        protected override void OnUpdate(Attributes attributtes)
        {
            searchBarAttrs = attributes as SearchBarAttributes;
            if (searchBarAttrs == null)
            {
                return;
            }
            ApplyAttributes(this, searchBarAttrs);
            ApplyAttributes(inputField, searchBarAttrs.SearchBoxAttributes);
            ApplyAttributes(resultListRoot, searchBarAttrs.ResultListAttributes);
            RelayoutComponents();
        }
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
                throw new Exception("Fail to get the base searchBar attributes.");
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
