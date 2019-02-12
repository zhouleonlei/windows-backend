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
                underLine.RaiseToTop();
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

            underLine.Size2D = new Size2D(itemList[curIndex].Size2D.Width, tabAttributes.UnderLineAttributes.Size2D.All.Height);
            underLine.Position2D.X = itemList[curIndex].Position2D.X;

            underLine.RaiseToTop();
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
