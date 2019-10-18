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
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using StyleManager = Tizen.NUI.Components.StyleManager;
using System.ComponentModel;

namespace Tizen.FH.NUI.Controls
{
    /// <summary>
    /// Navigation is one kind of common component, it can be used as instruction, guide or direction.
    /// User can handle Navigation by adding/inserting/deleting NavigationItem.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Navigation : Control
    {
        private const int aniTime = 100; // will be defined in const file later
        private List<NavigationItem> itemList = new List<NavigationItem>();
        private List<View> dividerLineList = new List<View>();
        private int curIndex = -1;
        private NavigationAttributes navigationAttributes = null;
        private ImageView shadowImage;
        private ImageView backgroundImage;
        private View rootView;
        private EventHandler<TouchEventArgs> itemTouchHander;

        /// <summary>
        /// Creates a new instance of a Navigation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Navigation() : base()
        {
            Initialize();
        }
        /// <summary>
        /// Creates a new instance of a Navigation with style.
        /// </summary>
        /// <param name="style">Create Navigation by special style defined in UX.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Navigation(string style) : base(style)
        {
            Initialize();
        }
        /// <summary>
        /// Creates a new instance of a Navigation with attributes.
        /// </summary>
        /// <param name="attributes">Create Navigation by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Navigation(NavigationAttributes attributes) : base(attributes)
        {
            Initialize();
        }

        /// <summary>
        /// An event for the item changed signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ItemChangeEventArgs> ItemChangedEvent;

        /// <summary>
        /// An event for the item touch signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        public event EventHandler<TouchEventArgs> ItemTouchEvent
        {
            add
            {
                itemTouchHander += value;
            }
            remove
            {
                itemTouchHander -= value;
            }
        }

        /// <summary>
        /// Selected item's index in Navigation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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

        /// <summary>
        /// Gap between items.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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

        /// <summary>
        /// Left space in Navigation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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

        /// <summary>
        /// Bottom space in Navigation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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

        /// <summary>
        /// Right space in Navigation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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

        /// <summary>
        /// Top space in Navigation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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

        /// <summary>
        /// Shadow image's size in Navigation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size ShadowImageSize
        {
            get
            {
                return navigationAttributes.ShadowImageAttributes?.Size;
            }
            set
            {
                if (value != null)
                {
                    CreateShadowImageAttributes();
                    navigationAttributes.ShadowImageAttributes.Size = value;
                }
            }
        }

        /// <summary>
        /// Shadow image's resource url in Navigation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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

        /// <summary>
        /// Background image's resource url in Navigation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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

        /// <summary>
        /// Shadow image's border in Navigation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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

        /// <summary>
        /// Divider line's color in Navigation.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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

        /// <summary>
        /// Flag to decide Navigation's size is fill with all navigation items' size or not.
        /// True is fit, false is none. If false, then Navigation's size can be updated by user.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
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

        /// <summary>
        /// Add navigation item by item data. The added item will be added to end of all items automatically.
        /// </summary>
        /// <param name="itemData">Item data which will apply to navigaiton item view.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddItem(NavigationItemData itemData)
        {
            AddItemByIndex(itemData, itemList.Count);
        }

        /// <summary>
        /// Insert navigation item by item data. The inserted item will be added to the special position by index automatically.
        /// </summary>
        /// <param name="itemData">Item data which will apply to navigaiton item view.</param>
        /// <param name="index">Position index where will be inserted.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void InsertItem(NavigationItemData itemData, int index)
        {
            AddItemByIndex(itemData, index);
        }

        /// <summary>
        /// Delete navigation item by index.
        /// </summary>
        /// <param name="itemIndex">Position index where will be deleted.</param>
        /// <since_tizen> 5.5 </since_tizen>
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

        /// <summary>
        /// Update Navigation by attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            UpdateItem();
        }

        /// <summary>
        /// Dispose Navigation and all children on it.
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

        /// <summary>
        /// Get Navigation attribues.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new NavigationAttributes();
        }

        private void Initialize()
        {
            navigationAttributes = attributes as NavigationAttributes;
            if (navigationAttributes == null)
            {
                throw new Exception("Navigation attribute parse error.");
            }

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
            item.TouchEvent += OnItemTouchEvent;
            rootView.Add(item);
            item.Size = itemData.ItemAttributes.Size;
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
                    Position = new Position(0, 0),
                    Size = new Size(0, 0)
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
                    Position = new Position(0, 0),
                    Size = new Size(0, 0)
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
                Position = new Position(0, 0)
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
            int parentW = (int)itemList[0].Size.Width + leftSpace + rightSpace;
            int parentH = topSpace + bottomSpace;
            int itemGap = navigationAttributes.ItemGap;
            for (int i = 0; i < totalNum; i++)
            {

                itemList[i].Index = i;
                itemList[i].Name = "Item" + i;
                itemList[i].Position = new Position(preX, preY);
                dividerLineList[i].Size = new Size(itemList[i].Size.Width, itemGap);
                dividerLineList[i].Position = new Position(preX, preY + itemList[i].Size.Height);
                parentH += (int)itemList[i].Size.Height;
                preY += (int)itemList[i].Size.Height + itemGap;

                dividerLineList[i].BackgroundColor = navigationAttributes.DividerLineColor;
                dividerLineList[i].Show();
            }
            dividerLineList[totalNum - 1].Hide();

            if (rootView.Size.EqualTo(new Size(parentW, parentH)) == false)
            {
                rootView.Size = new Size(parentW, parentH);
            }

            if (navigationAttributes.IsFitWithItems == true)
            {
                if (Size.EqualTo(new Size(parentW, parentH)) == false)
                {
                    Size = new Size(parentW, parentH);
                }
            }
            else
            {
                rootView.PositionY = (Size.Height - rootView.Size.Height) / 2;
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
            ItemChangedEvent?.Invoke(this, e);

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
            navigationAttributes.ShadowImageAttributes.Position = new Position(-navigationAttributes.ShadowImageAttributes.Size.Width, 0);
            ApplyAttributes(shadowImage, navigationAttributes.ShadowImageAttributes);
        }

        private void UpdateBackgroundImage()
        {
            if (navigationAttributes.BackgroundImageAttributes == null)
            {
                return;
            }
            navigationAttributes.BackgroundImageAttributes.Size = new Size(Size.Width, Size.Height);
            ApplyAttributes(backgroundImage, navigationAttributes.BackgroundImageAttributes);
        }

        private bool OnItemTouchEvent(object source, TouchEventArgs e)
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

            itemTouchHander?.Invoke(this, e);

            return true;
        }

        internal class NavigationItem : Button
        {
            private TextLabel subText;
            private View dividerLine;
            private NavigationItemAttributes itemAttributes;

            public NavigationItem(NavigationItemAttributes attributes) : base(attributes)
            {
                Initialize();
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

            protected override void OnUpdate()
            {
                LayoutIconAndText();

                base.OnUpdate();
                if (subText != null)
                {
                    ApplyAttributes(subText, itemAttributes.SubTextAttributes);
                }

                if (dividerLine != null)
                {
                    ApplyAttributes(dividerLine, itemAttributes.DividerLineAttributes);
                }
            }

            private void Initialize()
            {
                itemAttributes = attributes as NavigationItemAttributes;
                if (itemAttributes == null)
                {
                    throw new Exception("NavigationItem attribute parse error.");
                }

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

                    int w = (int)Size.Width;
                    int h = (int)Size.Height;
                    int iconX = (int)((w - itemAttributes.IconAttributes.Size.Width) / 2);
                    int iconY = topSpace;
                    itemAttributes.IconAttributes.Position = new Position(iconX, iconY);
                    int textPosX = leftSpace;
                    int textPosY = (int)(iconY + itemAttributes.IconAttributes.Size.Height);
                    if (itemAttributes.TextAttributes != null)
                    {
                        itemAttributes.TextAttributes.Position = new Position(textPosX, textPosY);
                        if (itemAttributes.TextAttributes.Size != null)
                        {
                            textPosY += (int)itemAttributes.TextAttributes.Size.Height;
                        }
                    }
                    if (itemAttributes.SubTextAttributes != null)
                    {
                        itemAttributes.SubTextAttributes.Position = new Position(textPosX, textPosY);
                    }
                }
            }
        }

        /// <summary>
        /// NavigationItemData is a class to record all data which will be applied to Navigation item.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class NavigationItemData : Button
        {
            /// <summary>
            /// Creates a new instance of a NavigationItemData.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public NavigationItemData() : base()
            {
                Initalize();
            }

            /// <summary>
            /// Creates a new instance of a NavigationItemData with style.
            /// </summary>
            /// <param name="style">Create NavigationItemData by special style defined in UX.</param>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public NavigationItemData(string style) : base(style)
            {
                Initalize();
            }

            /// <summary>
            /// Creates a new instance of a NavigationItemData with attributes.
            /// </summary>
            /// <param name="attributes">Create NavigationItemData by attributes customized by user.</param>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public NavigationItemData(NavigationItemAttributes attributes) : base(attributes)
            {
                Initalize();
            }

            /// <summary>
            /// Navigation item size.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public new Size Size
            {
                get
                {
                    return ItemAttributes.Size;
                }
                set
                {
                    ItemAttributes.Size = value;
                }
            }

            /// <summary>
            /// Space in Navigation item view, including left, right, top and bottom space.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
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

            /// <summary>
            /// Left space in Navigation item view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
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

            /// <summary>
            /// Bottom space in Navigation item view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
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

            /// <summary>
            /// Right space in Navigation item view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
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

            /// <summary>
            /// Top space in Navigation item view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
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

            /// <summary>
            /// Sub text string in Navigation item view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
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

            /// <summary>
            /// Text size in Navigation item view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size TextSize
            {
                get
                {
                    return ItemAttributes.TextAttributes?.Size;
                }
                set
                {
                    CreateTextAttributes();
                    ItemAttributes.TextAttributes.Size = value;
                }
            }

            /// <summary>
            /// Sub text size in Navigation item view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size SubTextSize
            {
                get
                {
                    return ItemAttributes.SubTextAttributes?.Size;
                }
                set
                {
                    CreateSubTextAttributes();
                    ItemAttributes.SubTextAttributes.Size = value;
                }
            }

            /// <summary>
            /// Sub text point size in Navigation item view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
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

            /// <summary>
            /// Sub text font family in Navigation item view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
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

            /// <summary>
            /// Sub text color in Navigation item view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
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

            /// <summary>
            /// Sub text color selector in Navigation item view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
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

            /// <summary>
            /// Icon size in Navigation item view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size IconSize
            {
                get
                {
                    return ItemAttributes.IconAttributes?.Size;
                }
                set
                {
                    ItemAttributes.IconAttributes.Size = value;
                }
            }

            /// <summary>
            /// Divider line color in Navigation item view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
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

            /// <summary>
            /// Divider line size in Navigation item view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size DividerLineSize
            {
                get
                {
                    return ItemAttributes.DividerLineAttributes?.Size;
                }
                set
                {
                    CreateDividerLineAttributes();
                    ItemAttributes.DividerLineAttributes.Size = value;
                }
            }

            /// <summary>
            /// Divider line's position in Navigation item view.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Position DividerLinePosition
            {
                get
                {
                    return ItemAttributes.DividerLineAttributes?.Position;
                }
                set
                {
                    CreateDividerLineAttributes();
                    ItemAttributes.DividerLineAttributes.Position = value;
                }
            }

            /// <summary>
            /// Flag to decide icon is in center or not in Navigation item view.
            /// If true, icon image will in the center of NavigationItem, if false, it will be decided by TopSpace.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
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

            /// <summary>
            /// Get attributes.
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected override Attributes GetAttributes()
            {
                return new NavigationItemAttributes();
            }

            /// <summary>
            /// Update item data by attributes.
            /// </summary>
            /// <param name="attributtes">Item data attributes.</param>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            protected override void OnUpdate()
            {
                
            }

            private void Initalize()
            {
                ItemAttributes = attributes as NavigationItemAttributes;
                if (ItemAttributes == null)
                {
                    throw new Exception("NavigationItem attribute parse error.");
                }

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
                        Size = new Size(0, 0),
                    };
                }
            }
        }

        /// <summary>
        /// ItemChangeEventArgs is a class to record item change event arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ItemChangeEventArgs : EventArgs
        {
            /// <summary> previous selected index of Navigation </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int PreviousIndex;
            /// <summary> current selected index of Navigation </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int CurrentIndex;
        }
    }
}
