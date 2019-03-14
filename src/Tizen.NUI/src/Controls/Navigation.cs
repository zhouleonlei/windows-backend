using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    public class Navigation : Control
    {
        private const int aniTime = 100; // will be defined in const file later
        private List<NavigationItem> itemList = new List<NavigationItem>();
        private List<View> dividerLineList = new List<View>();
        private int curIndex = -1;
        private EventHandler<ItemChangeEventArgs> itemChangeHander;
        private NavigationAttributes navigationAttributes = null;
        private ImageView shadowImage;
        private ImageView backgroundImage;
        private View rootView;

        public Navigation() : base()
        {
            navigationAttributes = attributes as NavigationAttributes;
            if (navigationAttributes == null)
            {
                throw new Exception("Navigation attribute parse error.");
            }
            Initialize();
        }
        public Navigation(string style) : base(style)
        {
            navigationAttributes = attributes as NavigationAttributes;
            if (navigationAttributes == null)
            {
                throw new Exception("Navigation attribute parse error.");
            }
            Initialize();
        }
        public Navigation(NavigationAttributes attributes) : base()
        {
            this.attributes = navigationAttributes = attributes.Clone() as NavigationAttributes;
            if (navigationAttributes == null)
            {
                throw new Exception("Navigation attribute parse error.");
            }
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

        public int ItemGap
        {
            get
            {
                if (navigationAttributes == null)
                {
                    return 0;
                }
                return navigationAttributes.ItemGap;
            }
            set
            {
                navigationAttributes.ItemGap = value;
            }
        }

        public float LeftSpace
        {
            get
            {
                if (navigationAttributes == null)
                {
                    return 0;
                }
                return navigationAttributes.Space.X;
            }
            set
            {
                navigationAttributes.Space.X = value;
                RelayoutRequest();
            }
        }

        public float BottomSpace
        {
            get
            {
                if (navigationAttributes == null)
                {
                    return 0;
                }
                return navigationAttributes.Space.W;
            }
            set
            {
                navigationAttributes.Space.W = value;
                RelayoutRequest();
            }
        }

        public float RightSpace
        {
            get
            {
                return navigationAttributes.Space.Y;
            }
            set
            {
                navigationAttributes.Space.Y = value;
                RelayoutRequest();
            }
        }

        public float TopSpace
        {
            get
            {
                return navigationAttributes.Space.Z;
            }
            set
            {
                navigationAttributes.Space.Z = value;
                RelayoutRequest();
            }
        }

        public Size2D ShadowImageSize2D
        {
            get
            {
                return navigationAttributes.ShadowImageAttributes?.Size2D;
            }
            set
            {
                if (value != null)
                {
                    CreateShadowImageAttributes();
                    navigationAttributes.ShadowImageAttributes.Size2D = value;
                }
            }
        }

        public string ShadowImageURL
        {
            get
            {
                return navigationAttributes.ShadowImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateShadowImageAttributes();
                    if (navigationAttributes.ShadowImageAttributes.ResourceURL == null)
                    {
                        navigationAttributes.ShadowImageAttributes.ResourceURL = new StringSelector();
                    }
                    navigationAttributes.ShadowImageAttributes.ResourceURL.All = value;
                }
            }
        }

        public string BackgroundImageURL
        {
            get
            {
                return navigationAttributes.BackgroundImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateBackgroundImageAttributes();
                    if (navigationAttributes.BackgroundImageAttributes.ResourceURL == null)
                    {
                        navigationAttributes.BackgroundImageAttributes.ResourceURL = new StringSelector();
                    }
                    navigationAttributes.BackgroundImageAttributes.ResourceURL.All = value;
                }
            }
        }

        public Rectangle BackgroundImageBorder
        {
            get
            {
                return navigationAttributes.BackgroundImageAttributes?.Border?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateBackgroundImageAttributes();
                    if (navigationAttributes.BackgroundImageAttributes.Border == null)
                    {
                        navigationAttributes.BackgroundImageAttributes.Border = new RectangleSelector();
                    }
                    navigationAttributes.BackgroundImageAttributes.Border.All = value;
                }
            }
        }

        public Color DividerLineColor
        {
            get
            {
                return navigationAttributes.DividerLineColor;
            }
            set
            {
                navigationAttributes.DividerLineColor = value;
            }
        }

        public bool IsFitWithItems
        {
            get
            {
                return navigationAttributes.IsFitWithItems;
            }
            set
            {
                navigationAttributes.IsFitWithItems = value;
            }
        }

        public void AddItem(NavigationItem item)
        {
            item.TouchEvent += ItemTouchEvent;
            rootView.Add(item);
            item.Index = itemList.Count;
            item.Name = "Item" + item.Index;
            itemList.Add(item);

            AddDividerLine();

            UpdateItem();
            if (curIndex != -1)
            {
                itemList[curIndex].State = States.Selected;
            }
        }

        protected override void OnUpdate(Attributes attributes)
        {
            UpdateItem();
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                for (int i = 0; i < dividerLineList.Count; i++)
                {
                    if(dividerLineList[i] != null)
                    {
                        rootView.Remove(dividerLineList[i]);
                        dividerLineList[i].Dispose();
                        dividerLineList[i] = null;
                    }
                }
                dividerLineList.Clear();

                for (int i = 0; i < itemList.Count; i++)
                {
                    if (itemList[i] != null)
                    {
                        rootView.Remove(itemList[i]);
                        itemList[i] = null;
                    }
                }
                itemList.Clear(); // Each item will be disposed by user

                if (rootView != null)
                {
                    Remove(rootView);
                    rootView.Dispose();
                    rootView = null;
                }

                if (backgroundImage != null)
                {
                    Remove(backgroundImage);
                    backgroundImage.Dispose();
                    backgroundImage = null;
                }
            }

            base.Dispose(type);
        }

        protected override Attributes GetAttributes()
        {
            return new NavigationAttributes();
        }

        private void Initialize()
        {
            shadowImage = new ImageView();
            shadowImage.Name = "ShadowImage";
            Add(shadowImage);

            backgroundImage = new ImageView();
            backgroundImage.Name = "Background";
            Add(backgroundImage);

            rootView = new View();
            rootView.Name = "RootView";
            Add(rootView);
        }

        private void CreateShadowImageAttributes()
        {
            if (navigationAttributes.ShadowImageAttributes == null)
            {
                navigationAttributes.ShadowImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    Position2D = new Position2D(0, 0),
                    Size2D = new Size2D(0, 0)
                };
            }
        }

        private void CreateBackgroundImageAttributes()
        {
            if (navigationAttributes.BackgroundImageAttributes == null)
            {
                navigationAttributes.BackgroundImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    Position2D = new Position2D(0, 0),
                    Size2D = new Size2D(0, 0)
                };
            }
        }

        private void AddDividerLine()
        {
            View dividerLine = new View()
            {
                BackgroundColor = navigationAttributes.DividerLineColor,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                Position2D = new Position2D(0, 0)
            };
            dividerLine.Name = "DividerLine " + dividerLineList.Count;
            rootView.Add(dividerLine);
            dividerLineList.Add(dividerLine);
        }

        private void UpdateItem()
        {
            int totalNum = itemList.Count;
            if(totalNum == 0)
            {
                return;
            }
            int leftSpace = (int)navigationAttributes.Space.X;
            int topSpace= (int)navigationAttributes.Space.Z;
            int bottomSpace = (int)navigationAttributes.Space.W;
            int rightSpace = (int)navigationAttributes.Space.Y;

            int preX = leftSpace;
            int preY = topSpace;
            int parentW = itemList[0].Size2D.Width + leftSpace + rightSpace;
            int parentH = topSpace + bottomSpace;
            int itemGap = navigationAttributes.ItemGap;
            for (int i = 0; i < totalNum; i++)
            {
                itemList[i].Position2D = new Position2D(preX, preY);
                dividerLineList[i].Size2D = new Size2D(itemList[i].Size2D.Width, itemGap);
                dividerLineList[i].Position2D = new Position2D(preX, preY + itemList[i].Size2D.Height);
                parentH += itemList[i].Size2D.Height;
                preY += itemList[i].Size2D.Height + itemGap;

                dividerLineList[i].BackgroundColor = navigationAttributes.DividerLineColor;
                dividerLineList[i].Show();
            }
            dividerLineList[totalNum - 1].Hide();

            if (rootView.Size2D.EqualTo(new Size2D(parentW, parentH)) == false)
            {
                rootView.Size2D = new Size2D(parentW, parentH);
            }

            if (navigationAttributes.IsFitWithItems == true)
            {               
                if (Size2D.EqualTo(new Size2D(parentW, parentH)) == false)
                {
                    Size2D = new Size2D(parentW, parentH);
                }              
            }
            else
            {
                rootView.PositionY = (Size2D.Height - rootView.Size2D.Height) / 2;
            }

            UpdateBackgroundImage();
            UpdateShadowImage();
        }      

        private void UpdateSelectedItem(NavigationItem item)
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

            if (curIndex != -1)
            {
                itemList[curIndex].State = States.Normal;
            }
            curIndex = item.Index;
            itemList[curIndex].State = States.Selected;
        }

        private void UpdateShadowImage()
        {
            if (navigationAttributes.ShadowImageAttributes == null)
            {
                return;
            }
            navigationAttributes.ShadowImageAttributes.Position2D = new Position2D(-navigationAttributes.ShadowImageAttributes.Size2D.Width, 0);
            ApplyAttributes(shadowImage, navigationAttributes.ShadowImageAttributes);
        }

        private void UpdateBackgroundImage()
        {
            if(navigationAttributes.BackgroundImageAttributes == null)
            {
                return;
            }
            navigationAttributes.BackgroundImageAttributes.Size2D = new Size2D(Size2D.Width, Size2D.Height);
            ApplyAttributes(backgroundImage, navigationAttributes.BackgroundImageAttributes);
        }

        private bool ItemTouchEvent(object source, TouchEventArgs e)
        {
            NavigationItem item = source as NavigationItem;
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

        public class NavigationItem : Button
        {
            private TextLabel subText;
            private View dividerLine;
            private NavigationItemAttributes itemAttributes;

            public NavigationItem() : base()
            {
                itemAttributes = attributes as NavigationItemAttributes;
                if (itemAttributes == null)
                {
                    throw new Exception("NavigationItem attribute parse error.");
                }
                InitializeItem();
            }

            public NavigationItem(string style) : base(style)
            {
                itemAttributes = attributes as NavigationItemAttributes;
                if (itemAttributes == null)
                {
                    throw new Exception("NavigationItem attribute parse error.");
                }
                InitializeItem();
            }
            public NavigationItem(NavigationItemAttributes attributes) : base()
            {
                this.attributes = itemAttributes = attributes.Clone() as NavigationItemAttributes;
                if (itemAttributes == null)
                {
                    throw new Exception("NavigationItem attribute parse error.");
                }
                base.Initialize();
                InitializeItem();
            }

            public Vector4 Space
            {
                get
                {
                    return itemAttributes.Space;
                }
                set
                {
                    itemAttributes.Space = value;
                    RelayoutRequest();
                }
            }

            public int LeftSpace
            {
                get
                {
                    if (itemAttributes == null)
                    {
                        return 0;
                    }
                    return (int)itemAttributes.Space.X;
                }
                set
                {
                    itemAttributes.Space.X = value;
                    RelayoutRequest();
                }
            }

            public int BottomSpace
            {
                get
                {
                    if (itemAttributes == null)
                    {
                        return 0;
                    }
                    return (int)itemAttributes.Space.W;
                }
                set
                {
                    itemAttributes.Space.W = value;
                    RelayoutRequest();
                }
            }

            public int RightSpace
            {
                get
                {
                    if (itemAttributes == null)
                    {
                        return 0;
                    }
                    return (int)itemAttributes.Space.Y;
                }
                set
                {
                    itemAttributes.Space.Y = value;
                    RelayoutRequest();
                }
            }

            public int TopSpace
            {
                get
                {
                    if (itemAttributes == null)
                    {
                        return 0;
                    }
                    return (int)itemAttributes.Space.Z;
                }
                set
                {
                    itemAttributes.Space.Z = value;
                    RelayoutRequest();
                }
            }           

            public string SubText
            {
                get
                {
                    return itemAttributes.SubTextAttributes?.Text?.All;
                }
                set
                {
                    if (value != null)
                    {
                        CreateSubTextAttributes();
                        if (itemAttributes.SubTextAttributes.Text == null)
                        {
                            itemAttributes.SubTextAttributes.Text = new StringSelector();
                        }
                        itemAttributes.SubTextAttributes.Text.All = value;

                        RelayoutRequest();
                    }
                }
            }

            public Size2D TextSize2D
            {
                get
                {
                    return itemAttributes.TextAttributes?.Size2D;
                }
                set
                {
                    itemAttributes.TextAttributes.Size2D = value;
                    RelayoutRequest();
                }
            }

            public Size2D SubTextSize2D
            {
                get
                {
                    return itemAttributes.SubTextAttributes?.Size2D;
                }
                set
                {
                    CreateSubTextAttributes();
                    itemAttributes.SubTextAttributes.Size2D = value;
                    RelayoutRequest();
                }
            }

            public float SubTextPointSize
            {
                get
                {
                    return itemAttributes.SubTextAttributes?.PointSize?.All ?? 0;
                }
                set
                {
                    CreateSubTextAttributes();
                    if (itemAttributes.SubTextAttributes.PointSize == null)
                    {
                        itemAttributes.SubTextAttributes.PointSize = new FloatSelector();
                    }
                    itemAttributes.SubTextAttributes.PointSize.All = value;
                    RelayoutRequest();
                }
            }

            public string SubTextFontFamily
            {
                get
                {
                    return itemAttributes.SubTextAttributes?.FontFamily;
                }
                set
                {
                    CreateSubTextAttributes();
                    itemAttributes.SubTextAttributes.FontFamily = value;
                    RelayoutRequest();
                }
            }

            public Color SubTextColor
            {
                get
                {
                    return itemAttributes.SubTextAttributes?.TextColor?.All;
                }
                set
                {
                    CreateSubTextAttributes();
                    if (itemAttributes.SubTextAttributes.TextColor == null)
                    {
                        itemAttributes.SubTextAttributes.TextColor = new ColorSelector();
                    }
                    itemAttributes.SubTextAttributes.TextColor.All = value;
                    RelayoutRequest();
                }
            }

            public ColorSelector SubTextColorSelector
            {
                get
                {
                    return itemAttributes.SubTextAttributes?.TextColor;
                }
                set
                {
                    CreateSubTextAttributes();
                    if (value != null)
                    {
                        itemAttributes.SubTextAttributes.TextColor = value.Clone() as ColorSelector;
                        RelayoutRequest();
                    }
                }
            }

            public Size2D IconSize2D
            {
                get
                {
                    return itemAttributes.IconAttributes?.Size2D;
                }
                set
                {
                    itemAttributes.IconAttributes.Size2D = value;
                    RelayoutRequest();
                }
            }

            public Color DividerLineColor
            {
                get
                {
                    return itemAttributes.DividerLineAttributes?.BackgroundColor?.All;
                }
                set
                {
                    CreateDividerLineAttributes();
                    if (itemAttributes.DividerLineAttributes.BackgroundColor == null)
                    {
                        itemAttributes.DividerLineAttributes.BackgroundColor = new ColorSelector();
                    }
                    itemAttributes.DividerLineAttributes.BackgroundColor.All = value;
                    RelayoutRequest();
                }
            }

            public Size2D DividerLineSize2D
            {
                get
                {
                    return itemAttributes.DividerLineAttributes?.Size2D;
                }
                set
                {
                    CreateDividerLineAttributes();
                    itemAttributes.DividerLineAttributes.Size2D = value;
                    RelayoutRequest();
                }
            }

            public Position2D DividerLinePosition2D
            {
                get
                {
                    return itemAttributes.DividerLineAttributes?.Position2D;
                }
                set
                {
                    CreateDividerLineAttributes();
                    itemAttributes.DividerLineAttributes.Position2D = value;
                    RelayoutRequest();
                }
            }

            public bool EnableIconCenter
            {
                get
                {
                    return itemAttributes.EnableIconCenter;
                }
                set
                {
                    itemAttributes.EnableIconCenter = value;
                }
            }

            internal int Index
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
                    if (subText != null)
                    {
                        Remove(subText);
                        subText.Dispose();
                        subText = null;
                    }

                    if (dividerLine != null)
                    {
                        Remove(dividerLine);
                        dividerLine.Dispose();
                        dividerLine = null;
                    }
                }

                base.Dispose(type);
            }

            protected override Attributes GetAttributes()
            {
                return new NavigationItemAttributes();
            }

            protected override void OnUpdate(Attributes attrs)
            {
                itemAttributes = attrs as NavigationItemAttributes;
                if (itemAttributes == null)
                {
                    return;
                }

                LayoutIconAndText();

                base.OnUpdate(attrs);
                Console.WriteLine("!!!!!! text is " + base.Text);
                if (subText != null)
                {
                    ApplyAttributes(subText, itemAttributes.SubTextAttributes);
                    Console.WriteLine("!!!!!! subtext is " + subText.Text);
                }

                if (dividerLine != null)
                {
                    ApplyAttributes(dividerLine, itemAttributes.DividerLineAttributes);
                }
            }

            private void InitializeItem()
            {
                if (itemAttributes.IconAttributes == null)
                {
                    itemAttributes.IconAttributes = new ImageAttributes();
                    itemAttributes.IconAttributes.Size2D = new Size2D(0, 0);
                }
                CreateTextAttributes();
                CreateSubTextAttributes();
                CreateDividerLineAttributes();
            }

            private void CreateTextAttributes()
            {
                if (itemAttributes.TextAttributes == null)
                {
                    itemAttributes.TextAttributes = new TextAttributes()
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Top,
                    };
                }
            }

            private void CreateSubTextAttributes()
            {
                if (itemAttributes.SubTextAttributes == null)
                {
                    itemAttributes.SubTextAttributes = new TextAttributes()
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };                    
                }
                if (subText == null)
                {
                    subText = new TextLabel()
                    {
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        PositionUsesPivotPoint = true,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };
                    Add(subText);
                }
            }

            private void CreateDividerLineAttributes()
            {
                if (itemAttributes.DividerLineAttributes == null)
                {
                    itemAttributes.DividerLineAttributes = new ViewAttributes()
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    };
                }

                if(dividerLine == null)
                {
                    dividerLine = new View()
                    {
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        PositionUsesPivotPoint = true,
                    };
                    Add(dividerLine);
                }
            }

            private void LayoutIconAndText()
            {
                int leftSpace = (int)itemAttributes.Space.X;
                int rightSpace = (int)itemAttributes.Space.Y;
                int topSpace = (int)itemAttributes.Space.Z;
                int bottomSpace = (int)itemAttributes.Space.W;
                itemAttributes.IconAttributes.PositionUsesPivotPoint = true;
                if (itemAttributes.EnableIconCenter == true)
                {
                    itemAttributes.IconAttributes.ParentOrigin = Tizen.NUI.ParentOrigin.Center;
                    itemAttributes.IconAttributes.PivotPoint = Tizen.NUI.PivotPoint.Center;
                }
                else
                {
                    itemAttributes.IconAttributes.ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft;
                    itemAttributes.IconAttributes.PivotPoint = Tizen.NUI.PivotPoint.TopLeft;

                    int w = Size2D.Width;
                    int h = Size2D.Height;
                    int iconX = (w - itemAttributes.IconAttributes.Size2D.Width) / 2;
                    int iconY = topSpace;
                    itemAttributes.IconAttributes.Position2D = new Position2D(iconX, iconY);
                    int textPosX = leftSpace;
                    int textPosY = iconY + itemAttributes.IconAttributes.Size2D.Height;
                    if (itemAttributes.TextAttributes != null)
                    {
                        itemAttributes.TextAttributes.Position2D = new Position2D(textPosX, textPosY);
                        textPosY += itemAttributes.TextAttributes.Size2D.Height;
                    }
                    if (itemAttributes.SubTextAttributes != null)
                    {
                        itemAttributes.SubTextAttributes.Position2D = new Position2D(textPosX, textPosY);
                    }
                }
            }
        }

        public class ItemChangeEventArgs : EventArgs
        {
            /// <summary> previous selected index of Navigation </summary>
            public int PreviousIndex;
            /// <summary> current selected index of Navigation </summary>
            public int CurrentIndex;
        }
    }
}
