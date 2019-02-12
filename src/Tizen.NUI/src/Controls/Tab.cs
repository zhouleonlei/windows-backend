using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    public class Tab : Control
    {
        private List<TabItem> itemList = new List<TabItem>();
        private int curIndex = 0;
        private View underLine = null;
        private EventHandler<ItemChangeEventArgs> itemChangeHander;
        private TabAttributes tabAttributes = null;

        public Tab() : base()
        {
            tabAttributes = attributes as TabAttributes;
            if (tabAttributes == null)
            {
                throw new Exception("Tab attribute parse error.");
            }
            Initialize();
        }
        public Tab(string style) : base(style)
        {
            tabAttributes = attributes as TabAttributes;
            if (tabAttributes == null)
            {
                throw new Exception("Tab attribute parse error.");
            }
            Initialize();
        }
        public Tab(TabAttributes attributes) : base()
        {
            this.attributes = tabAttributes = attributes.Clone() as TabAttributes;
            Initialize();
        }

        public event EventHandler<ItemChangeEventArgs> ItemChangedEvent
        {
            add
            {
                itemChangeHander += value;
            }
            remove
            {
                itemChangeHander -= value;
            }
        }

        public int SelectedItemIndex
        {
            get
            {
                return curIndex;
            }
            set
            {
                if (value < itemList.Count)
                {
                    UpdateSelectedItem(itemList[value]);
                }
            }
        }

        public bool IsNatureTextWidth
        {
            get
            {
                if(tabAttributes == null)
                {
                    return false;
                }
                return tabAttributes.IsNatureTextWidth;
            }
            set
            {
                if (tabAttributes == null)
                {
                    tabAttributes.IsNatureTextWidth = value;
                    RelayoutRequest();
                }
            }
        }

        public int PaddingLeft
        {
            get
            {
                if (tabAttributes == null)
                {
                    return 0;
                }
                return tabAttributes.PaddingLeft.All.Value;
            }
            set
            {
                if(tabAttributes.PaddingLeft == null)
                {
                    tabAttributes.PaddingLeft = new IntSelector { All = value };
                }
                tabAttributes.PaddingLeft.All = value;
                RelayoutRequest();
            }
        }

        public int PaddingBottom
        {
            get
            {
                if (tabAttributes == null)
                {
                    return 0;
                }
                return tabAttributes.PaddingBottom.All.Value;
            }
            set
            {
                if (tabAttributes.PaddingBottom == null)
                {
                    tabAttributes.PaddingBottom = new IntSelector { All = value };
                }
                tabAttributes.PaddingBottom.All = value;
                RelayoutRequest();
            }
        }

        public int PaddingRight
        {
            get
            {
                if (tabAttributes == null)
                {
                    return 0;
                }
                return tabAttributes.PaddingRight.All.Value;
            }
            set
            {
                if (tabAttributes.PaddingRight == null)
                {
                    tabAttributes.PaddingRight = new IntSelector { All = value };
                }
                tabAttributes.PaddingRight.All = value;
                RelayoutRequest();
            }
        }

        public int PaddingTop
        {
            get
            {
                if (tabAttributes == null)
                {
                    return 0;
                }
                return tabAttributes.PaddingTop.All.Value;
            }
            set
            {
                if (tabAttributes.PaddingTop == null)
                {
                    tabAttributes.PaddingTop = new IntSelector { All = value };
                }
                tabAttributes.PaddingTop.All = value;
                RelayoutRequest();
            }
        }

        public Size2D UnderLineSize2D
        {
            get
            {
                return tabAttributes?.UnderLineAttributes?.Size2D?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateUnderLineAttributes();
                    if (tabAttributes.UnderLineAttributes.Size2D == null)
                    {
                        tabAttributes.UnderLineAttributes.Size2D = new Size2DSelector();
                    }
                    tabAttributes.UnderLineAttributes.Size2D.All = value;
                    RelayoutRequest();
                }
            }
        }

        public Color UnderLineBackgroundColor
        {
            get
            {
                return tabAttributes?.UnderLineAttributes?.BackgroundColor?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateUnderLineAttributes();
                    if (tabAttributes.UnderLineAttributes.BackgroundColor == null)
                    {
                        tabAttributes.UnderLineAttributes.BackgroundColor = new ColorSelector();
                    }
                    tabAttributes.UnderLineAttributes.BackgroundColor.All = value;
                    RelayoutRequest();
                }
            }
        }

        public float PointSize
        {
            get
            {
                return tabAttributes?.TextAttributes?.PointSize?.All ?? 0;
            }
            set
            {
                CreateTextAttributes();
                if (tabAttributes.TextAttributes.PointSize == null)
                {
                    tabAttributes.TextAttributes.PointSize = new FloatSelector();
                }
                tabAttributes.TextAttributes.PointSize.All = value;
                RelayoutRequest();
            }
        }

        public string FontFamily
        {
            get
            {
                return tabAttributes?.TextAttributes?.FontFamily?.All;
            }
            set
            {
                CreateTextAttributes();
                if (tabAttributes.TextAttributes.FontFamily == null)
                {
                    tabAttributes.TextAttributes.FontFamily = new StringSelector();
                }
                tabAttributes.TextAttributes.FontFamily.All = value;
                RelayoutRequest();
            }
        }

        public Color TextColor
        {
            get
            {
                return tabAttributes?.TextAttributes?.TextColor?.All;
            }
            set
            {
                CreateTextAttributes();
                if (tabAttributes.TextAttributes.TextColor == null)
                {
                    tabAttributes.TextAttributes.TextColor = new ColorSelector();
                }
                tabAttributes.TextAttributes.TextColor.All = value;
                RelayoutRequest();
            }
        }

        public ColorSelector TextColorSelector
        {
            get
            {
                return tabAttributes?.TextAttributes.TextColor;
            }
            set
            {
                if (value != null)
                {
                    CreateTextAttributes();
                    tabAttributes.TextAttributes.TextColor = value.Clone() as ColorSelector;
                    RelayoutRequest();
                }
            }
        }

        public void AddItem(TabItem item)
        {
            int h = 0;
            int paddingTop = 0;
            if(tabAttributes.UnderLineAttributes != null && tabAttributes.UnderLineAttributes.Size2D != null)
            {
                h = tabAttributes.UnderLineAttributes.Size2D.All.Height;
            }
            if(tabAttributes.PaddingTop != null)
            {
                paddingTop = tabAttributes.PaddingTop.All.Value;
            }
            item.Size2D.Height = Size2D.Height - h - paddingTop;
            item.Position2D.Y = paddingTop;
            ApplyAttributes(item.TextItem, tabAttributes.TextAttributes);
            item.TouchEvent += ItemTouchEvent;
            Add(item);
            item.Index = itemList.Count;
            itemList.Add(item);

            UpdateItem();
            itemList[curIndex].State = States.Selected;
            itemList[curIndex].UpdateItemText(tabAttributes.TextAttributes);

            UpdateUnderLinePos();
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (underLine != null)
                {
                    Remove(underLine);
                    underLine.Dispose();
                    underLine = null;
                }
            }

            base.Dispose(type);
        }

        protected override void OnUpdate(Attributes attributtes)
        {
            tabAttributes = attributes as TabAttributes;
            if (tabAttributes == null)
            {
                return;
            }

            ApplyAttributes(this, tabAttributes);

            if (tabAttributes.UnderLineAttributes != null)
            {
                if (underLine == null)
                {
                    underLine = new View();
                    Add(underLine);
                }
                UpdateUnderLinePos();
                ApplyAttributes(underLine, tabAttributes.UnderLineAttributes);               
            }
        }

        protected override Attributes GetAttributes()
        {
            return new TabAttributes();
        }

        private void Initialize()
        {
            CreateUnderLine();
        }

        private void CreateUnderLine()
        {
            if (tabAttributes.UnderLineAttributes != null)
            {
                if (underLine == null)
                {
                    underLine = new View();
                    Add(underLine);
                }
                ApplyAttributes(underLine, tabAttributes.UnderLineAttributes);
            }
        }

        private void CreateUnderLineAttributes()
        {
            if (tabAttributes.UnderLineAttributes == null)
            {
                tabAttributes.UnderLineAttributes = new ViewAttributes()
                {
                    PositionUsesPivotPoint = new BoolSelector { All = true },
                    ParentOrigin = new PositionSelector { All = Tizen.NUI.ParentOrigin.BottomLeft },
                    PivotPoint = new PositionSelector { All = Tizen.NUI.PivotPoint.BottomLeft },
                };
            }
        }

        private void CreateTextAttributes()
        {
            if (tabAttributes.TextAttributes == null)
            {
                tabAttributes.TextAttributes = new TextAttributes()
                {
                    PositionUsesPivotPoint = new BoolSelector { All = true },
                    ParentOrigin = new PositionSelector { All = Tizen.NUI.ParentOrigin.Center },
                    PivotPoint = new PositionSelector { All = Tizen.NUI.PivotPoint.Center },
                    HorizontalAlignment = new HorizontalAlignmentSelector { All = HorizontalAlignment.Center },
                    VerticalAlignment = new VerticalAlignmentSelector { All = VerticalAlignment.Center },
                    WidthResizePolicy = new ResizePolicyTypeSelector { All = ResizePolicyType.FillToParent },
                    HeightResizePolicy = new ResizePolicyTypeSelector { All = ResizePolicyType.FillToParent }
                };
            }
        }

        private void UpdateItem()
        {
            int totalNum = itemList.Count;
            if(totalNum == 0)
            {
                return;
            }
            int preX = tabAttributes.PaddingLeft.All.Value;
            int preW = 0;
            if (tabAttributes.IsNatureTextWidth == true)
            {                
                for (int i = 0; i < totalNum; i++)
                {
                    preW = itemList[i].GetNaturalSize().Width;
                    itemList[i].Position2D.X = preX;
                    itemList[i].Size2D.Width = preW;
                    preX = itemList[i].Position2D.X + preW;
                }
            }
            else
            {
                preW = (Size2D.Width - tabAttributes.PaddingLeft.All.Value - tabAttributes.PaddingRight.All.Value) / totalNum;
                for (int i = 0; i < totalNum; i++)
                {
                    itemList[i].Position2D.X = preX;
                    itemList[i].Size2D.Width = preW;
                    preX = itemList[i].Position2D.X + preW;
                }
            }          
        }

        private void UpdateUnderLinePos()
        {
            if (underLine == null || tabAttributes.UnderLineAttributes == null || tabAttributes.UnderLineAttributes.Size2D == null)
            {
                return;
            }
            tabAttributes.UnderLineAttributes.Size2D.All.Width = itemList[curIndex].Size2D.Width;

            underLine.Size2D = new Size2D(itemList[curIndex].Size2D.Width, tabAttributes.UnderLineAttributes.Size2D.All.Height);
            underLine.Position2D.X = itemList[curIndex].Position2D.X;
        }

        private void UpdateSelectedItem(TabItem item)
        {
            if(item == null || curIndex == item.Index)
            {
                return;
            }

            ItemChangeEventArgs e = new ItemChangeEventArgs
            {
                PreviousIndex = curIndex,
                CurrentIndex = item.Index
            };
            itemChangeHander?.Invoke(this, e);

            itemList[curIndex].State = States.Normal;
            itemList[curIndex].UpdateItemText(tabAttributes.TextAttributes);
            curIndex = item.Index;
            itemList[curIndex].State = States.Selected;
            itemList[curIndex].UpdateItemText(tabAttributes.TextAttributes);

            UpdateUnderLinePos();
        }

        private bool ItemTouchEvent(object source, TouchEventArgs e)
        {
            TabItem item = source as TabItem;
            if(item == null)
            {
                return false;
            }
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Up)
            {
                UpdateSelectedItem(item);
            }

            return true;
        }

        public class TabItem : Control
        {
            private TextLabel text;
            private int index;

            public TabItem() : base()
            {
                text = new TextLabel()
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    PositionUsesPivotPoint = true,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                Add(text);
            }

            public string Text
            {
                get
                {
                    return text.Text;
                }
                set
                {
                    text.Text = value;
                }
            }

            internal int Index
            {
                get
                {
                    return index;
                }
                set
                {
                    index = value;
                }
            }

            internal TextLabel TextItem
            {
                get
                {
                    return text;
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
                    if (text != null)
                    {
                        Remove(text);
                        text.Dispose();
                        text = null;
                    }
                }

                base.Dispose(type);
            }

            protected override Attributes GetAttributes()
            {
                return null;
            }

            internal void UpdateItemText(TextAttributes attrs)
            {
                ApplyAttributes(text, attrs);
            }
        }

        public class ItemChangeEventArgs : EventArgs
        {
            /// <summary> previous selected index of Tab </summary>
            public int PreviousIndex;
            /// <summary> current selected index of Tab </summary>
            public int CurrentIndex;
        }
    }
}
