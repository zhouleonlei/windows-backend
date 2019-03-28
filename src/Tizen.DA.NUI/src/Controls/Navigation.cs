using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;
using StyleManager = Tizen.NUI.CommonUI.StyleManager;
using System.ComponentModel;

namespace Tizen.FH.NUI.Controls
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Navigation() : base()
        {
            navigationAttributes = attributes as NavigationAttributes;
            if (navigationAttributes == null)
            {
                throw new Exception("Navigation attribute parse error.");
            }
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Navigation(string style) : base(style)
        {
            navigationAttributes = attributes as NavigationAttributes;
            if (navigationAttributes == null)
            {
                throw new Exception("Navigation attribute parse error.");
            }
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Navigation(NavigationAttributes attributes) : base()
        {
            this.attributes = navigationAttributes = attributes.Clone() as NavigationAttributes;
            if (navigationAttributes == null)
            {
                throw new Exception("Navigation attribute parse error.");
            }
            Initialize();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float LeftSpace
        {
            get
            {
                return navigationAttributes.Space.X;
            }
            set
            {
                navigationAttributes.Space.X = value;
                RelayoutRequest();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float BottomSpace
        {
            get
            {
                return navigationAttributes.Space.W;
            }
            set
            {
                navigationAttributes.Space.W = value;
                RelayoutRequest();
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddItem(NavigationItemData itemData)
        {
            AddItemByIndex(itemData, itemList.Count);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InsertItem(NavigationItemData itemData, int index)
        {
            AddItemByIndex(itemData, index);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteItem(int itemIndex)
        {
            if (itemList == null || itemIndex < 0 || itemIndex >= itemList.Count)
            {
                return;
            }


            if (curIndex > itemIndex || (curIndex == itemIndex && itemIndex == itemList.Count - 1))
            {
                curIndex--;
            }

            Remove(itemList[itemIndex]);
            itemList[itemIndex].Dispose();
            itemList.RemoveAt(itemIndex);

            UpdateItem();
            if (curIndex != -1)
            {
                itemList[curIndex].State = ControlStates.Selected;
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate(Attributes attributes)
        {
            UpdateItem();
        }

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

                if (rootView != null)
                {
                    if (dividerLineList != null)
                    {
                        for (int i = 0; i < dividerLineList.Count; i++)
                        {
                            if (dividerLineList[i] != null)
                            {
                                rootView.Remove(dividerLineList[i]);
                                dividerLineList[i].Dispose();
                                dividerLineList[i] = null;
                            }
                        }
                        dividerLineList.Clear();
                        dividerLineList = null;
                    }

                    if (itemList != null)
                    {
                        for (int i = 0; i < itemList.Count; i++)
                        {
                            if (itemList[i] != null)
                            {
                                rootView.Remove(itemList[i]);
                                itemList[i].Dispose();
                                itemList[i] = null;
                            }
                        }
                        itemList.Clear();
                        itemList = null;
                    }

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

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        private void AddItemByIndex(NavigationItemData itemData, int index)
        {
            NavigationItem item = new NavigationItem(itemData.ItemAttributes);
            item.TouchEvent += ItemTouchEvent;
            rootView.Add(item);
            item.Size2D = itemData.ItemAttributes.Size2D;
            if (index >= itemList.Count)
            {
                itemList.Add(item);
            }
            else
            {
                itemList.Insert(index, item);
            }

            AddDividerLine();

            UpdateItem();
            if (curIndex != -1)
            {
                itemList[curIndex].State = ControlStates.Selected;
            }
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
            if (totalNum == 0)
            {
                return;
            }
            int leftSpace = (int)navigationAttributes.Space.X;
            int topSpace = (int)navigationAttributes.Space.Z;
            int bottomSpace = (int)navigationAttributes.Space.W;
            int rightSpace = (int)navigationAttributes.Space.Y;

            int preX = leftSpace;
            int preY = topSpace;
            int parentW = itemList[0].Size2D.Width + leftSpace + rightSpace;
            int parentH = topSpace + bottomSpace;
            int itemGap = navigationAttributes.ItemGap;
            for (int i = 0; i < totalNum; i++)
            {

                itemList[i].Index = i;
                itemList[i].Name = "Item" + i;
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
            if (item == null || curIndex == item.Index)
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
                itemList[curIndex].State = ControlStates.Normal;
            }
            curIndex = item.Index;
            itemList[curIndex].State = ControlStates.Selected;
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
            if (navigationAttributes.BackgroundImageAttributes == null)
            {
                return;
            }
            navigationAttributes.BackgroundImageAttributes.Size2D = new Size2D(Size2D.Width, Size2D.Height);
            ApplyAttributes(backgroundImage, navigationAttributes.BackgroundImageAttributes);
        }

        private bool ItemTouchEvent(object source, TouchEventArgs e)
        {
            NavigationItem item = source as NavigationItem;
            if (item == null)
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

        internal class NavigationItem : Button
        {
            private TextLabel subText;
            private View dividerLine;
            private NavigationItemAttributes itemAttributes;

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

            internal int Index
            {
                get;
                set;
            }

            protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
            {
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

            protected override void LayoutChild()
            {

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
                if (subText != null)
                {
                    ApplyAttributes(subText, itemAttributes.SubTextAttributes);
                }

                if (dividerLine != null)
                {
                    ApplyAttributes(dividerLine, itemAttributes.DividerLineAttributes);
                }
            }

            private void InitializeItem()
            {
                CreateSubText();
                CreateDividerLine();
                ApplyAttributes(this, itemAttributes);
            }

            private void CreateSubText()
            {
                if (itemAttributes.SubTextAttributes != null)
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

            private void CreateDividerLine()
            {
                if (itemAttributes.DividerLineAttributes != null)
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
                if (itemAttributes.IconAttributes == null)
                {
                    return;
                }

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
                        if (itemAttributes.TextAttributes.Size2D != null)
                        {
                            textPosY += itemAttributes.TextAttributes.Size2D.Height;
                        }
                    }
                    if (itemAttributes.SubTextAttributes != null)
                    {
                        itemAttributes.SubTextAttributes.Position2D = new Position2D(textPosX, textPosY);
                    }
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class NavigationItemData : Button
        {
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public NavigationItemData() : base()
            {
                ItemAttributes = attributes as NavigationItemAttributes;
                if (ItemAttributes == null)
                {
                    throw new Exception("NavigationItem attribute parse error.");
                }
                Initalize();
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public NavigationItemData(string style) : base(style)
            {
                ItemAttributes = attributes as NavigationItemAttributes;
                if (ItemAttributes == null)
                {
                    throw new Exception("NavigationItem attribute parse error.");
                }
                Initalize();
            }
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public NavigationItemData(NavigationItemAttributes attributes) : base()
            {
                this.attributes = ItemAttributes = attributes.Clone() as NavigationItemAttributes;
                if (ItemAttributes == null)
                {
                    throw new Exception("NavigationItem attribute parse error.");
                }
                Initalize();
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public new Size2D Size2D
            {
                get
                {
                    return ItemAttributes.Size2D;
                }
                set
                {
                    ItemAttributes.Size2D = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Vector4 Space
            {
                get
                {
                    return ItemAttributes.Space;
                }
                set
                {
                    ItemAttributes.Space = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int LeftSpace
            {
                get
                {
                    return (int)ItemAttributes.Space.X;
                }
                set
                {
                    ItemAttributes.Space.X = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int BottomSpace
            {
                get
                {
                    return (int)ItemAttributes.Space.W;
                }
                set
                {
                    ItemAttributes.Space.W = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int RightSpace
            {
                get
                {
                    return (int)ItemAttributes.Space.Y;
                }
                set
                {
                    ItemAttributes.Space.Y = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int TopSpace
            {
                get
                {
                    return (int)ItemAttributes.Space.Z;
                }
                set
                {
                    ItemAttributes.Space.Z = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string SubText
            {
                get
                {
                    return ItemAttributes.SubTextAttributes?.Text?.All;
                }
                set
                {
                    if (value != null)
                    {
                        CreateSubTextAttributes();
                        if (ItemAttributes.SubTextAttributes.Text == null)
                        {
                            ItemAttributes.SubTextAttributes.Text = new StringSelector();
                        }
                        ItemAttributes.SubTextAttributes.Text.All = value;
                    }
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size2D TextSize2D
            {
                get
                {
                    return ItemAttributes.TextAttributes?.Size2D;
                }
                set
                {
                    CreateTextAttributes();
                    ItemAttributes.TextAttributes.Size2D = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size2D SubTextSize2D
            {
                get
                {
                    return ItemAttributes.SubTextAttributes?.Size2D;
                }
                set
                {
                    CreateSubTextAttributes();
                    ItemAttributes.SubTextAttributes.Size2D = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float SubTextPointSize
            {
                get
                {
                    return ItemAttributes.SubTextAttributes?.PointSize?.All ?? 0;
                }
                set
                {
                    CreateSubTextAttributes();
                    if (ItemAttributes.SubTextAttributes.PointSize == null)
                    {
                        ItemAttributes.SubTextAttributes.PointSize = new FloatSelector();
                    }
                    ItemAttributes.SubTextAttributes.PointSize.All = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string SubTextFontFamily
            {
                get
                {
                    return ItemAttributes.SubTextAttributes?.FontFamily;
                }
                set
                {
                    CreateSubTextAttributes();
                    ItemAttributes.SubTextAttributes.FontFamily = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Color SubTextColor
            {
                get
                {
                    return ItemAttributes.SubTextAttributes?.TextColor?.All;
                }
                set
                {
                    CreateSubTextAttributes();
                    if (ItemAttributes.SubTextAttributes.TextColor == null)
                    {
                        ItemAttributes.SubTextAttributes.TextColor = new ColorSelector();
                    }
                    ItemAttributes.SubTextAttributes.TextColor.All = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ColorSelector SubTextColorSelector
            {
                get
                {
                    return ItemAttributes.SubTextAttributes?.TextColor;
                }
                set
                {
                    CreateSubTextAttributes();
                    if (value != null)
                    {
                        ItemAttributes.SubTextAttributes.TextColor = value.Clone() as ColorSelector;
                    }
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size2D IconSize2D
            {
                get
                {
                    return ItemAttributes.IconAttributes?.Size2D;
                }
                set
                {
                    ItemAttributes.IconAttributes.Size2D = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Color DividerLineColor
            {
                get
                {
                    return ItemAttributes.DividerLineAttributes?.BackgroundColor?.All;
                }
                set
                {
                    CreateDividerLineAttributes();
                    if (ItemAttributes.DividerLineAttributes.BackgroundColor == null)
                    {
                        ItemAttributes.DividerLineAttributes.BackgroundColor = new ColorSelector();
                    }
                    ItemAttributes.DividerLineAttributes.BackgroundColor.All = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size2D DividerLineSize2D
            {
                get
                {
                    return ItemAttributes.DividerLineAttributes?.Size2D;
                }
                set
                {
                    CreateDividerLineAttributes();
                    ItemAttributes.DividerLineAttributes.Size2D = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Position2D DividerLinePosition2D
            {
                get
                {
                    return ItemAttributes.DividerLineAttributes?.Position2D;
                }
                set
                {
                    CreateDividerLineAttributes();
                    ItemAttributes.DividerLineAttributes.Position2D = value;
                }
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool EnableIconCenter
            {
                get
                {
                    return ItemAttributes.EnableIconCenter;
                }
                set
                {
                    ItemAttributes.EnableIconCenter = value;
                }
            }

            internal NavigationItemAttributes ItemAttributes
            {
                get;
                set;
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected override Attributes GetAttributes()
            {
                return new NavigationItemAttributes();
            }

            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected override void OnUpdate(Attributes attributtes)
            {
                
            }

            private void Initalize()
            {
                base.Initialize();
                CreateIconAttributes();
                CreateTextAttributes();
            }

            private void CreateTextAttributes()
            {
                if (ItemAttributes.TextAttributes == null)
                {
                    ItemAttributes.TextAttributes = new TextAttributes()
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
                if (ItemAttributes.SubTextAttributes == null)
                {
                    ItemAttributes.SubTextAttributes = new TextAttributes()
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };
                }
            }         

            private void CreateDividerLineAttributes()
            {
                if (ItemAttributes.DividerLineAttributes == null)
                {
                    ItemAttributes.DividerLineAttributes = new ViewAttributes()
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    };
                }
            }

            private void CreateIconAttributes()
            {
                if (ItemAttributes.IconAttributes == null)
                {
                    ItemAttributes.IconAttributes = new ImageAttributes()
                    {
                        Size2D = new Size2D(0, 0),
                    };
                }
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ItemChangeEventArgs : EventArgs
        {
            /// <summary> previous selected index of Navigation </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int PreviousIndex;
            /// <summary> current selected index of Navigation </summary>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int CurrentIndex;
        }
    }
}
