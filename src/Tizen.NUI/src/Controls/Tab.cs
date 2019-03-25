using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    public class Tab : Control
    {
        private const int aniTime = 100; // will be defined in const file later
        private List<TabItem> itemList = new List<TabItem>();
        private int curIndex = 0;
        private View underline = null;
        private EventHandler<ItemChangeEventArgs> itemChangeHander;
        private TabAttributes tabAttributes = null;
        private Animation underlineAni = null;
        private bool isNeedAnimation = false;

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
                return tabAttributes.IsNatureTextWidth;
            }
            set
            {
                tabAttributes.IsNatureTextWidth = value;
                RelayoutRequest();
            }
        }

        public int ItemGap
        {
            get
            {
                return tabAttributes.ItemGap;
            }
            set
            {
                tabAttributes.ItemGap = value;
                RelayoutRequest();
            }
        }

        public int LeftSpace
        {
            get
            {
                return (int)tabAttributes.Space.X;
            }
            set
            {
                tabAttributes.Space.X = value;
                RelayoutRequest();
            }
        }

        public int BottomSpace
        {
            get
            {
                return (int)tabAttributes.Space.W;
            }
            set
            {
                tabAttributes.Space.W = value;
                RelayoutRequest();
            }
        }

        public int RightSpace
        {
            get
            {
                return (int)tabAttributes.Space.Y;
            }
            set
            {
                tabAttributes.Space.Y = value;
                RelayoutRequest();
            }
        }

        public int TopSpace
        {
            get
            {
                return (int)tabAttributes.Space.Z;
            }
            set
            {
                tabAttributes.Space.Z = value;
                RelayoutRequest();
            }
        }

        public Size2D UnderLineSize2D
        {
            get
            {
                return tabAttributes.UnderLineAttributes?.Size2D;
            }
            set
            {
                if (value != null)
                {
                    CreateUnderLineAttributes();
                    tabAttributes.UnderLineAttributes.Size2D = value;
                    RelayoutRequest();
                }
            }
        }

        public Color UnderLineBackgroundColor
        {
            get
            {
                return tabAttributes.UnderLineAttributes?.BackgroundColor?.All;
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
                return tabAttributes.TextAttributes?.PointSize?.All ?? 0;
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
                return tabAttributes.TextAttributes?.FontFamily;
            }
            set
            {
                CreateTextAttributes();
                tabAttributes.TextAttributes.FontFamily = value;
                RelayoutRequest();
            }
        }

        public Color TextColor
        {
            get
            {
                return tabAttributes.TextAttributes?.TextColor?.All;
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
                return tabAttributes.TextAttributes.TextColor;
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

        public void AddItem(TabItemData itemData)
        {
            int h = 0;
            int topSpace = (int)tabAttributes.Space.Z;
            if(tabAttributes.UnderLineAttributes != null && tabAttributes.UnderLineAttributes.Size2D != null)
            {
                h = tabAttributes.UnderLineAttributes.Size2D.Height;
            }
            Tab.TabItem item = new TabItem();          
            ApplyAttributes(item.TextItem, tabAttributes.TextAttributes);
            item.TextItem.Text = itemData.Text;
            item.Size2D.Height = Size2D.Height - h - topSpace;
            item.Position2D.Y = topSpace;
            item.TouchEvent += ItemTouchEvent;
            Add(item);
            item.Index = itemList.Count;
            itemList.Add(item);

            LayoutChild();
            itemList[curIndex].State = States.Selected;
            itemList[curIndex].UpdateItemText(tabAttributes.TextAttributes);
            UpdateUnderLinePos();
        }

        public void DeleteItem(int itemIndex)
        {
            if(itemIndex < 0 || itemIndex >= itemList.Count)
            {
                return;
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
                if(underlineAni != null)
                {
                    if(underlineAni.State == Animation.States.Playing)
                    {
                        underlineAni.Stop();
                    }
                    underlineAni.Dispose();
                    underlineAni = null;
                }
                if (underline != null)
                {
                    Remove(underline);
                    underline.Dispose();
                    underline = null;
                }

                if(itemList != null)
                {
                    for(int i = 0; i < itemList.Count; i++)
                    {
                        Remove(itemList[i]);
                        itemList[i].Dispose();
                    }
                    itemList.Clear();
                    itemList = null;
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

            if (tabAttributes.UnderLineAttributes != null)
            {
                if (underline == null)
                {
                    underline = new View()
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                    };
                    Add(underline);
                    CreateUnderLineAnimation();
                }
                ApplyAttributes(underline, tabAttributes.UnderLineAttributes);
            }

            if (tabAttributes.TextAttributes != null)
            {
                if (curIndex < itemList.Count)
                {
                    itemList[curIndex].UpdateItemText(tabAttributes.TextAttributes);
                }
            }

            LayoutChild();
        }

        protected override Attributes GetAttributes()
        {
            return new TabAttributes();
        }

        protected virtual void LayoutChild()
        {
            if (tabAttributes == null)
            {
                return;
            }
            int totalNum = itemList.Count;
            if (totalNum == 0)
            {
                return;
            }

            int preX = (int)tabAttributes.Space.X;
            int preW = 0;
            int itemGap = tabAttributes.ItemGap;

            if (LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                if (tabAttributes.IsNatureTextWidth == true)
                {
                    for (int i = 0; i < totalNum; i++)
                    {
                        preW = itemList[i].TextItem.NaturalSize2D.Width;
                        itemList[i].Position2D.X = preX;
                        itemList[i].Size2D.Width = preW;
                        preX = itemList[i].Position2D.X + preW + itemGap;
                    }
                }
                else
                {
                    preW = (Size2D.Width - (int)tabAttributes.Space.X - (int)tabAttributes.Space.Y) / totalNum;
                    for (int i = 0; i < totalNum; i++)
                    {
                        itemList[i].Position2D.X = preX;
                        itemList[i].Size2D.Width = preW;
                        preX = itemList[i].Position2D.X + preW + itemGap;
                    }
                }
            }
            else
            {
                preX = (int)tabAttributes.Space.Y;
                if (tabAttributes.IsNatureTextWidth == true)
                {
                    int w = Size2D.Width;
                    for (int i = 0; i < totalNum; i++)
                    {
                        preW = itemList[i].TextItem.NaturalSize2D.Width;
                        itemList[i].Position2D.X = w - preW - preX;
                        itemList[i].Size2D.Width = preW;
                        preX = w - itemList[i].Position2D.X + itemGap;
                    }
                }
                else
                {
                    preW = (Size2D.Width - (int)tabAttributes.Space.X - (int)tabAttributes.Space.Y) / totalNum;
                    for (int i = totalNum - 1; i >= 0; i--)
                    {
                        itemList[i].Position2D.X = preX;
                        itemList[i].Size2D.Width = preW;
                        preX = itemList[i].Position2D.X + preW + itemGap;
                    }
                }
            }
            UpdateUnderLinePos();
        }

        private void Initialize()
        {
            ApplyAttributes(this, tabAttributes);
            LayoutDirectionChanged += OnLayoutDirectionChanged;
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            LayoutChild();
        }

        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            TabAttributes tempAttributes = StyleManager.Instance.GetAttributes(style) as TabAttributes;
            if (tempAttributes != null)
            {
                tempAttributes.IsNatureTextWidth = tabAttributes.IsNatureTextWidth; // keep IsNatureTextWidth as original
                attributes = tabAttributes = tempAttributes;              
                RelayoutRequest();
            }
        }

        private void CreateUnderLineAttributes()
        {
            if (tabAttributes.UnderLineAttributes == null)
            {
                tabAttributes.UnderLineAttributes = new ViewAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                };
            }
        }

        private void CreateTextAttributes()
        {
            if (tabAttributes.TextAttributes == null)
            {
                tabAttributes.TextAttributes = new TextAttributes()
                {
                    PositionUsesPivotPoint =  true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    WidthResizePolicy =  ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
            }
        }

        private void CreateUnderLineAnimation()
        {
            if (underlineAni == null)
            {
                underlineAni = new Animation(aniTime);
            }
        }
        
        private void UpdateUnderLinePos()
        {
            if (underline == null || tabAttributes.UnderLineAttributes == null || tabAttributes.UnderLineAttributes.Size2D == null)
            {
                return;
            }
            tabAttributes.UnderLineAttributes.Size2D.Width = itemList[curIndex].Size2D.Width;

            underline.Size2D = new Size2D(itemList[curIndex].Size2D.Width, tabAttributes.UnderLineAttributes.Size2D.Height);
            underline.BackgroundColor = tabAttributes.UnderLineAttributes.BackgroundColor.All;
            if (isNeedAnimation)
            {
                CreateUnderLineAnimation();
                if (underlineAni.State == Animation.States.Playing)
                {
                    underlineAni.Stop();
                }
                underlineAni.Clear();
                underlineAni.AnimateTo(underline, "PositionX", itemList[curIndex].Position2D.X);
                underlineAni.Play();
            }
            else
            {
                underline.Position2D.X = itemList[curIndex].Position2D.X;
                isNeedAnimation = true;
            }
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

        internal class TabItem : Control
        {
            public TabItem() : base()
            {
                TextItem = new TextLabel()
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    PositionUsesPivotPoint = true,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                Add(TextItem);
            }

            public string Text
            {
                get
                {
                    return TextItem.Text;
                }
                set
                {
                    TextItem.Text = value;
                }
            }

            internal int Index
            {
                get;
                set;
            }

            internal TextLabel TextItem
            {
                get;
                set;
            }

            protected override void Dispose(DisposeTypes type)
            {
                if (disposed)
                {
                    return;
                }

                if (type == DisposeTypes.Explicit)
                {
                    if (TextItem != null)
                    {
                        Remove(TextItem);
                        TextItem.Dispose();
                        TextItem = null;
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
                ApplyAttributes(TextItem, attrs);
            }
        }

        public class TabItemData
        {
            public string Text
            {
                get;
                set;
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
