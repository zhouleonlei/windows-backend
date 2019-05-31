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

namespace Tizen.FH.NUI.Controls
{
    /// <summary>
    /// ListItem is a component which is the item of list
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ListItem : Tizen.NUI.CommonUI.Control
    {
        private View textRootView = null;
        private TextLabel mainTextLabel = null;
        private TextLabel[] subTextLabelArray = null;
        private ImageView dividerView = null;
        private View leftItemRootView = null;
        private View rightItemRootView = null;
        private ImageView leftIcon = null;
        private ImageView rightIcon = null;
        private TextLabel rightText = null;

        private ListItemAttributes listItemAttrs = null;

        private uint subTextCount = 0;
        private uint? leftSpace = null;
        private uint? rightSpace = null;
        private uint? spaceBetweenLeftItemAndText = null;
        private uint? spaceBetweenRightItemAndText = null;
        private Size2D leftItemRootSize = null;
        private Size2D rightItemRootSize = null;

        private bool isSelected = false;
        private bool isEnabled = true;
        private bool isPressed = false;
        private ItemAlignTypes itemAlignType = ItemAlignTypes.Icon;
        private GroupIndexTypes groupIndexType = GroupIndexTypes.None;
        private StyleTypes styleType = StyleTypes.None;
        private CheckBox checkBoxObj = null;
        private Switch switchObj = null;
        /// <summary>
        /// Initializes a new instance of the ListItem class.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ListItem() : base()
        {
            Initialize();
        }
        /// <summary>
        /// Initializes a new instance of the ListItem class.
        /// </summary>
        /// <param name="style">Create Header by special style defined in UX.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ListItem(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Type for item align style
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ItemAlignTypes
        {
            /// <summary>
            /// Icon type for item align style
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Icon,
            /// <summary>
            /// Check Icon type for item align style
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            CheckIcon
        }

        /// <summary>
        /// Type for group index style
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum GroupIndexTypes
        {
            /// <summary>
            /// Have no group index style
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            None,
            /// <summary>
            /// Drop down type for group index style
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            DropDown,
            /// <summary>
            /// Next type for group index style
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Next,
            /// <summary>
            /// Switch type for group index style
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Switch
        }

        /// <summary>
        /// Type for style
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum StyleTypes
        {
            /// <summary>
            /// have no  style type
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            None,
            /// <summary>
            /// default style type
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Default,
            /// <summary>
            /// mutil sub text style type
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            MultiSubText,
            /// <summary>
            /// effect style type
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Effect,
            /// <summary>
            /// item align style type
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            ItemAlign,
            /// <summary>
            /// next depth style type
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            NextDepth,
            /// <summary>
            /// group index style type
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            GroupIndex,
            /// <summary>
            /// drop down style type
            /// </summary>
            /// <since_tizen> 5.5 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            DropDown
        }

        /// <summary>
        /// Property for type in item align style, only useful in ItemAlignListItem style
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ItemAlignTypes ItemAlignType
        {
            set
            {
                if (value == itemAlignType)
                {
                    return;
                }
                itemAlignType = value;
                if (styleType == StyleTypes.ItemAlign)
                {
                    RelayoutComponents();
                }
            }
        }

        /// <summary>
        /// Property for type in group index style, only useful in GroupIndexListItem style
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GroupIndexTypes GroupIndexType
        {
            set
            {
                if (value == groupIndexType)
                {
                    return;
                }
                groupIndexType = value;
                if (styleType == StyleTypes.GroupIndex)
                {
                    ApplyMainTextAttributes();
                    RelayoutComponents();
                }
            }
        }

        /// <summary>
        /// Property for selected state
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool StateSelectedEnabled
        {
            get
            {
                return isSelected;
            }
            set
            {
                if (isSelected == value)
                {
                    return;
                }
                isSelected = value;
                UpdateState();
            }
        }

        /// <summary>
        /// Property for enabled state
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
                UpdateState();
            }
        }

        /// <summary>
        /// Property for the content of the main textlabel
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MainText
        {
            get
            {
                if (mainTextLabel != null)
                {
                    return mainTextLabel.Text;
                }
                return null;
            }
            set
            {
                if (mainTextLabel != null)
                {
                    mainTextLabel.Text = value;
                    RelayoutTextComponents();
                }
            }
        }

        /// <summary>
        /// Property for the count of the sub textlabel
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint SubTextCount
        {
            get
            {
                return subTextCount;
            }
            set
            {
                if (value == 0 || subTextCount > 0)
                {
                    return;
                }
                subTextCount = value;
                InitializeSubText();
                ApplySubTextAttributes();
            }
        }

        /// <summary>
        /// Property for the string array of the array of the sub textlabel
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string[] SubTextContentArray
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                int length = value.Length;
                if (subTextCount != length)
                {
                    return;
                }
                for (int i = 0; i < subTextCount; ++i)
                {
                    if (subTextLabelArray[i] != null)
                    {
                        subTextLabelArray[i].Text = value[i];
                    }
                }
                RelayoutTextComponents();
            }
        }

        /// <summary>
        /// Property for the enabled state of the divider
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool StateDividerEnabled
        {
            set
            {
                if (dividerView != null)
                {
                    if (value)
                    {
                        dividerView.Show();
                    }
                    else
                    {
                        dividerView.Hide();
                    }
                }
            }
        }

        /// <summary>
        /// Property for the left space
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint LeftSpace
        {
            set
            {
                if (leftSpace == value)
                {
                    return;
                }
                leftSpace = value;
                RelayoutTextComponents();
                RelayoutLeftItemRootView();
            }
        }

        /// <summary>
        /// Property for the right space
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint RightSpace
        {
            set
            {
                if (rightSpace == value)
                {
                    return;
                }
                rightSpace = value;
                RelayoutTextComponents();
                RelayoutRightItemRootView();
            }
        }

        /// <summary>
        /// Property for the size of the left item root view
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D LeftItemRootViewSize
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                leftItemRootSize = value;
                ResizeLeftItemRootView();
                RelayoutTextComponents();
            }
        }

        /// <summary>
        /// Property for the size of the right item root view
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D RightItemRootViewSize
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                rightItemRootSize = value;
                ResizeRightItemRootView();
                RelayoutTextComponents();
            }
        }

        /// <summary>
        /// Property for the space between left item and text
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint SpaceBetweenLeftItemAndText
        {
            set
            {
                if (spaceBetweenLeftItemAndText == value)
                {
                    return;
                }
                spaceBetweenLeftItemAndText = value;
                RelayoutTextComponents();
            }
        }

        /// <summary>
        /// Property for the space between right item and text
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint SpaceBetweenRightItemAndText
        {
            set
            {
                if (spaceBetweenRightItemAndText == value)
                {
                    return;
                }
                spaceBetweenRightItemAndText = value;
                RelayoutTextComponents();
            }
        }

        /// <summary>
        /// Property for the resource url of the left icon, only useful in ItemAlign style in icon type
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LeftIconURL
        {
            set
            {
                InitializeLeftIcon();
                if (listItemAttrs != null)
                {
                    ApplyAttributes(leftIcon, listItemAttrs.LeftIconAttributes);
                }
                if (leftIcon != null)
                {
                    leftIcon.ResourceUrl = value;
                }
            }
        }

        /// <summary>
        /// Property for the content of the right text, only useful in ItemAlign style in CheckIcon type
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string RightText
        {
            set
            {
                InitializeRightText();
                if (listItemAttrs != null)
                {
                    ApplyAttributes(rightText, listItemAttrs.RightTextAttributes);
                }
                if (rightText != null)
                {
                    rightText.Text = value;
                }
            }
        }

        /// <summary>
        /// Function for user to add object to the left item root view customized
        /// </summary>
        /// <param name="obj"> The object will be added </param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void BindObjectToLeft(object obj)
        {
            if (leftItemRootView == null || obj == null)
            {
                return;
            }
            leftItemRootView.Add(obj as View);
        }

        /// <summary>
        /// Function for user to add object to the right item root view customized
        /// </summary>
        /// <param name="obj"> The object will be added </param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void BindObjectToRight(object obj)
        {
            if (rightItemRootView == null || obj == null)
            {
                return;
            }
            rightItemRootView.Add(obj as View);
        }
        /// <summary>
        /// Dispose List Item and all children on it.
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
                this.TouchEvent -= OnTouchEvent;

                if (mainTextLabel != null)
                {
                    if (textRootView != null)
                    {
                        textRootView.Remove(mainTextLabel);
                    }
                    mainTextLabel.Dispose();
                    mainTextLabel = null;
                }
                if (subTextLabelArray != null)
                {
                    for (int i = 0; i < subTextCount; ++i)
                    {
                        if (subTextLabelArray[i] != null)
                        {
                            if (textRootView != null)
                            {
                                textRootView.Remove(subTextLabelArray[i]);
                            }
                            subTextLabelArray[i].Dispose();
                            subTextLabelArray[i] = null;
                        }
                    }
                    subTextLabelArray = null;
                }
                if (textRootView != null)
                {
                    this.Remove(textRootView);
                    textRootView.Dispose();
                    textRootView = null;
                }
                if (dividerView != null)
                {
                    this.Remove(dividerView);
                    dividerView.Dispose();
                    dividerView = null;
                }
                if (leftIcon != null)
                {
                    if (leftItemRootView != null)
                    {
                        leftItemRootView.Remove(leftIcon);
                    }
                    leftIcon.Dispose();
                    leftIcon = null;
                }
                if (rightIcon != null)
                {
                    if (rightItemRootView != null)
                    {
                        rightItemRootView.Remove(rightIcon);
                    }
                    rightIcon.Dispose();
                    rightIcon = null;
                }
                if (rightText != null)
                {
                    if (rightItemRootView != null)
                    {
                        rightItemRootView.Remove(rightText);
                    }
                    rightText.Dispose();
                    rightText = null;
                }
                if (checkBoxObj != null)
                {
                    if (leftItemRootView != null)
                    {
                        leftItemRootView.Remove(checkBoxObj);
                    }
                    checkBoxObj.Dispose();
                    checkBoxObj = null;
                }
                if (switchObj != null)
                {
                    if (rightItemRootView != null)
                    {
                        rightItemRootView.Remove(switchObj);
                    }
                    switchObj.Dispose();
                    switchObj = null;
                }
                if (leftItemRootView != null)
                {
                    uint childCount = leftItemRootView.ChildCount;
                    for (uint i = 0; i < childCount; ++i)
                    {
                        View childObj = leftItemRootView.GetChildAt(i);
                        if (childObj != null)
                        {
                            leftItemRootView.Remove(childObj);
                            childObj.Dispose();
                            childObj = null;
                        }
                    }
                    this.Remove(leftItemRootView);
                    leftItemRootView.Dispose();
                    leftItemRootView = null;
                }
                if (rightItemRootView != null)
                {
                    uint childCount = rightItemRootView.ChildCount;
                    for (uint i = 0; i < childCount; ++i)
                    {
                        View childObj = rightItemRootView.GetChildAt(i);
                        if (childObj != null)
                        {
                            rightItemRootView.Remove(childObj);
                            childObj.Dispose();
                            childObj = null;
                        }
                    }
                    this.Remove(rightItemRootView);
                    rightItemRootView.Dispose();
                    rightItemRootView = null;
                }
            }
            base.Dispose(type);
        }
        /// <summary>
        /// Get List Item attribues.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new ListItemAttributes();
        }
        /// <summary>
        /// Update List Item by attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            CurrentStyleType();
            ApplyAttributes(this, listItemAttrs);
            ApplyMainTextAttributes();
            ApplySubTextAttributes();
            ApplyAttributes(dividerView, listItemAttrs.DividerViewAttributes);
            ApplyAttributes(leftItemRootView, listItemAttrs.LeftItemRootViewAttributes);
            ApplyAttributes(rightItemRootView, listItemAttrs.RightItemRootViewAttributes);
            ApplyAttributes(leftIcon, listItemAttrs.LeftIconAttributes);
            ApplyAttributes(rightIcon, listItemAttrs.RightIconAttributes);
            ApplyAttributes(rightText, listItemAttrs.RightTextAttributes);
            RelayoutComponents();
            OnLayoutDirectionChanged();
        }

        private void ApplyMainTextAttributes()
        {
            if (listItemAttrs == null)
            {
                return;
            }
            if (styleType == StyleTypes.GroupIndex && groupIndexType == GroupIndexTypes.None)
            {
                ApplyAttributes(mainTextLabel, listItemAttrs.MainText2Attributes);
            }
            else
            {
                ApplyAttributes(mainTextLabel, listItemAttrs.MainTextAttributes);
            }
        }

        private void Initialize()
        {
            listItemAttrs = attributes as ListItemAttributes;
            if (listItemAttrs == null)
            {
                throw new Exception("ListItem attributes parse error.");
            }
            if (textRootView == null)
            {
                textRootView = new View()
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                    PositionUsesPivotPoint = true
                };
                this.Add(textRootView);
            }
            if (listItemAttrs.MainTextAttributes != null && mainTextLabel == null)
            {
                mainTextLabel = new TextLabel();
                textRootView.Add(mainTextLabel);
            }
            if (listItemAttrs.DividerViewAttributes != null && dividerView == null)
            {
                dividerView = new ImageView()
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.BottomCenter,
                    PivotPoint = Tizen.NUI.PivotPoint.BottomCenter,
                    PositionUsesPivotPoint = true
                };
                this.Add(dividerView);
            }
            if (listItemAttrs.LeftItemRootViewAttributes != null && leftItemRootView == null)
            {
                leftItemRootView = new View()
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                    PositionUsesPivotPoint = true
                };
                this.Add(leftItemRootView);
            }
            if (listItemAttrs.RightItemRootViewAttributes != null && rightItemRootView == null)
            {
                rightItemRootView = new View()
                {
                    ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                    PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                    PositionUsesPivotPoint = true
                };
                this.Add(rightItemRootView);
            }
            InitializeRightIcon();
            this.TouchEvent += OnTouchEvent;
        }

        private void OnLayoutDirectionChanged()
        {
            if (listItemAttrs == null)
            {
                return;
            }
            if (LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                for (int i = 0; i < subTextCount; ++i)
                {
                    if(subTextLabelArray[i])
                    {
                        subTextLabelArray[i].LayoutDirection = ViewLayoutDirectionType.LTR;
                        subTextLabelArray[i].HorizontalAlignment = HorizontalAlignment.Begin;
                    }
                }
                if (listItemAttrs.SubTextAttributes != null)
                    listItemAttrs.SubTextAttributes.HorizontalAlignment = HorizontalAlignment.Begin;
                if (textRootView)
                {
                    textRootView.LayoutDirection = ViewLayoutDirectionType.LTR;
                    textRootView.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                    textRootView.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                    textRootView.PositionUsesPivotPoint = true;
                }
                if(mainTextLabel)
                {
                    if (styleType == StyleTypes.GroupIndex && groupIndexType == GroupIndexTypes.None)
                    {
                        if(listItemAttrs.MainText2Attributes != null)
                            listItemAttrs.MainText2Attributes.HorizontalAlignment = HorizontalAlignment.Begin;
                    }
                    else
                    {
                        if(listItemAttrs.MainTextAttributes != null)
                           listItemAttrs.MainTextAttributes.HorizontalAlignment = HorizontalAlignment.Begin;
                    }
                    mainTextLabel.LayoutDirection = ViewLayoutDirectionType.LTR;
                    mainTextLabel.HorizontalAlignment = HorizontalAlignment.Begin;
                }

                if (leftItemRootView)
                {
                    if(listItemAttrs.LeftItemRootViewAttributes != null)
                    {
                        listItemAttrs.LeftItemRootViewAttributes.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                        listItemAttrs.LeftItemRootViewAttributes.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                        listItemAttrs.LeftItemRootViewAttributes.PositionUsesPivotPoint = true;
                    }
                    leftItemRootView.LayoutDirection = ViewLayoutDirectionType.LTR;
                    leftItemRootView.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                    leftItemRootView.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                    leftItemRootView.PositionUsesPivotPoint = true;
                }
                if(rightItemRootView)
                {
                    if(listItemAttrs.RightItemRootViewAttributes != null)
                    {
                        listItemAttrs.RightItemRootViewAttributes.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
                        listItemAttrs.RightItemRootViewAttributes.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
                        listItemAttrs.RightItemRootViewAttributes.PositionUsesPivotPoint = true;
                    }
                    rightItemRootView.LayoutDirection = ViewLayoutDirectionType.LTR;
                    rightItemRootView.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
                    rightItemRootView.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
                    rightItemRootView.PositionUsesPivotPoint = true;
                }
            }
            else
            {
                for (int i = 0; i < subTextCount; ++i)
                {
                    if (subTextLabelArray[i])
                    {
                        subTextLabelArray[i].LayoutDirection = ViewLayoutDirectionType.RTL;
                        subTextLabelArray[i].HorizontalAlignment = HorizontalAlignment.End;
                    }
                }
                if(listItemAttrs.SubTextAttributes !=null )
                    listItemAttrs.SubTextAttributes.HorizontalAlignment = HorizontalAlignment.End;
                if (textRootView)
                {
                    textRootView.LayoutDirection = ViewLayoutDirectionType.RTL;
                    textRootView.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
                    textRootView.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
                    textRootView.PositionUsesPivotPoint = true;
                }
                if (mainTextLabel)
                {
                    if (styleType == StyleTypes.GroupIndex && groupIndexType == GroupIndexTypes.None)
                    {
                        if(listItemAttrs.MainText2Attributes != null)
                            listItemAttrs.MainText2Attributes.HorizontalAlignment = HorizontalAlignment.End;
                    }
                    else
                    {
                        if(listItemAttrs.MainTextAttributes != null)
                            listItemAttrs.MainTextAttributes.HorizontalAlignment = HorizontalAlignment.End;
                    }
                    mainTextLabel.LayoutDirection = ViewLayoutDirectionType.RTL;
                    mainTextLabel.HorizontalAlignment = HorizontalAlignment.End;
                }
                if (leftItemRootView)
                {
                    if (listItemAttrs.LeftItemRootViewAttributes != null)
                    {
                        listItemAttrs.LeftItemRootViewAttributes.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
                        listItemAttrs.LeftItemRootViewAttributes.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
                        listItemAttrs.LeftItemRootViewAttributes.PositionUsesPivotPoint = true;
                    }
                    leftItemRootView.LayoutDirection = ViewLayoutDirectionType.RTL;
                    leftItemRootView.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
                    leftItemRootView.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
                    leftItemRootView.PositionUsesPivotPoint = true;
                }
                if (rightItemRootView)
                {
                    if (listItemAttrs.RightItemRootViewAttributes != null)
                    {
                        listItemAttrs.RightItemRootViewAttributes.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                        listItemAttrs.RightItemRootViewAttributes.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                        listItemAttrs.RightItemRootViewAttributes.PositionUsesPivotPoint = true;
                    }
                    rightItemRootView.LayoutDirection = ViewLayoutDirectionType.RTL;
                    rightItemRootView.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                    rightItemRootView.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                    rightItemRootView.PositionUsesPivotPoint = true;
                }
            }
        }

        private void InitializeSubText()
        {
            if (subTextLabelArray != null || subTextCount == 0)
            {
                return;
            }
            subTextLabelArray = new TextLabel[subTextCount];
            for (int i = 0; i < subTextCount; ++i)
            {
                subTextLabelArray[i] = new TextLabel();
                if (textRootView != null)
                {
                    textRootView.Add(subTextLabelArray[i]);
                }
            }
        }

        private void InitializeLeftIcon()
        {
            if (listItemAttrs.LeftIconAttributes != null && leftIcon == null && leftItemRootView != null)
            {
                leftIcon = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
                leftItemRootView.Add(leftIcon);
            }
        }

        private void InitializeRightIcon()
        {
            if (listItemAttrs.RightIconAttributes != null && rightIcon == null && rightItemRootView != null)
            {
                rightIcon = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
                rightItemRootView.Add(rightIcon);
            }
        }

        private void InitializeRightText()
        {
            if (listItemAttrs.RightTextAttributes != null && rightText == null && rightItemRootView != null)
            {
                rightText = new TextLabel()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
                rightItemRootView.Add(rightText);
            }
        }

        private void ApplySubTextAttributes()
        {
            if (subTextCount == 0 || subTextLabelArray == null || listItemAttrs == null)
            {
                return;
            }
            for (int i = 0; i < subTextCount; ++i)
            {
                ApplyAttributes(subTextLabelArray[i], listItemAttrs.SubTextAttributes);
            }
        }

        private void RelayoutComponents()
        {
            RelayoutTextComponents();
            ResizeLeftItemRootView();
            RelayoutLeftItemRootView();
            ResizeRightItemRootView();
            RelayoutRightItemRootView();
            RelayoutDivider();

            UpdateTypeForItemAlignStyle();
            UpdateTypeForGroupIndexStyle();
        }

        private void RelayoutTextComponents()
        {
            int heightSum = 0;
            int rootWidth = TextRootViewWidth();
            if (mainTextLabel != null)
            {
                int height = mainTextLabel.NaturalSize2D.Height;
                mainTextLabel.Size2D = new Size2D(rootWidth, height);
                mainTextLabel.Position2D = new Position2D(0, 0);
                heightSum += height;
            }
            if (subTextLabelArray != null)
            {
                int length = subTextLabelArray.Length;
                for (int i = 0; i < length; ++i)
                {
                    if (subTextLabelArray[i] != null)
                    {
                        int height = subTextLabelArray[i].NaturalSize2D.Height;
                        subTextLabelArray[i].Size2D = new Size2D(rootWidth, height);
                        subTextLabelArray[i].Position2D = new Position2D(0, heightSum);
                        heightSum += height;
                    }
                }
            }
            if (textRootView != null)
            {
                int testrootx = LeftSpaceValue() + LeftItemRootViewWidth() + SpaceBetweenLeftItemAndTextValue();
                textRootView.Size2D = new Size2D(rootWidth, heightSum);
                if (this.LayoutDirection == ViewLayoutDirectionType.LTR)
                    textRootView.Position2D = new Position2D(testrootx, 0);
                else
                    textRootView.Position2D = new Position2D(-testrootx, 0);
            }
        }

        private void RelayoutDivider()
        {
            if (dividerView == null)
            {
                return;
            }
            Size2D size = this.Size2D;
            dividerView.Size2D = new Size2D(size.Width - LeftSpaceValue() - RightSpaceValue(), DividerSize().Height);
        }

        private void ResizeLeftItemRootView()
        {
            if (leftItemRootView == null || leftItemRootSize == null)
            {
                return;
            }
            leftItemRootView.Size2D = leftItemRootSize;
        }

        private void RelayoutLeftItemRootView()
        {
            if (leftItemRootView == null)
            {
                return;
            }
            int leftspace = LeftSpaceValue();
            if (this.LayoutDirection == ViewLayoutDirectionType.LTR)
                leftItemRootView.Position2D = new Position2D(leftspace, 0);
            else
                leftItemRootView.Position2D = new Position2D(-leftspace, 0);
        }

        private void ResizeRightItemRootView()
        {
            if (rightItemRootView == null || rightItemRootSize == null)
            {
                return;
            }
            rightItemRootView.Size2D = rightItemRootSize;
        }

        private void RelayoutRightItemRootView()
        {
            if (rightItemRootView == null)
            {
                return;
            }
            int rightspace = RightSpaceValue();
            if (this.LayoutDirection == ViewLayoutDirectionType.LTR)
                rightItemRootView.Position2D = new Position2D(-rightspace, 0);
            else
                rightItemRootView.Position2D = new Position2D(rightspace, 0);
        }

        private int TextRootViewWidth()
        {
            int width = 0;
            int leftPartSpace = 0;
            if (leftItemRootView != null)
            {
                leftPartSpace = LeftItemRootViewWidth() + SpaceBetweenLeftItemAndTextValue();
            }
            int rightPartSpace = 0;
            if (styleType == StyleTypes.ItemAlign)
            {
                if (itemAlignType == ItemAlignTypes.CheckIcon)
                {
                    if (rightItemRootView != null)
                    {
                        rightPartSpace = RightItemRootViewWidth() + SpaceBetweenRightItemAndTextValue();
                    }
                }
                else if (itemAlignType == ItemAlignTypes.Icon)
                {
                    // in icon type, there is no right part
                }
            }
            else if (styleType == StyleTypes.GroupIndex)
            {
                if (groupIndexType == GroupIndexTypes.None)
                {
                    // in none type, there is no right part
                }
                else
                {
                    if (rightItemRootView != null)
                    {
                        rightPartSpace = RightItemRootViewWidth();
                    }
                }
            }
            else
            {
                if (rightItemRootView != null)
                {
                    rightPartSpace = RightItemRootViewWidth() + SpaceBetweenRightItemAndTextValue();
                }
            }

            width = this.Size2D.Width - LeftSpaceValue() - RightSpaceValue() - leftPartSpace - rightPartSpace;
            return width;
        }

        private int LeftSpaceValue()
        {
            int space = 0;
            if (leftSpace != null)
            {
                space = (int)leftSpace.Value;
            }
            else
            {
                if (listItemAttrs != null && listItemAttrs.LeftSpace != null)
                {
                    space = (int)listItemAttrs.LeftSpace.Value;
                }
            }
            return space;
        }

        private int RightSpaceValue()
        {
            int space = 0;
            if (rightSpace != null)
            {
                space = (int)rightSpace.Value;
            }
            else
            {
                if (listItemAttrs != null && listItemAttrs.RightSpace != null)
                {
                    space = (int)listItemAttrs.RightSpace.Value;
                }
            }
            return space;
        }

        private int SpaceBetweenLeftItemAndTextValue()
        {
            int space = 0;
            if (spaceBetweenLeftItemAndText != null)
            {
                space = (int)spaceBetweenLeftItemAndText.Value;
            }
            else
            {
                if (listItemAttrs != null && listItemAttrs.SpaceBetweenLeftItemAndText != null)
                {
                    space = (int)listItemAttrs.SpaceBetweenLeftItemAndText.Value;
                }
            }
            return space;
        }

        private int SpaceBetweenRightItemAndTextValue()
        {
            int space = 0;
            if (spaceBetweenRightItemAndText != null)
            {
                space = (int)spaceBetweenRightItemAndText.Value;
            }
            else
            {
                if (listItemAttrs != null && listItemAttrs.SpaceBetweenRightItemAndText != null)
                {
                    space = (int)listItemAttrs.SpaceBetweenRightItemAndText.Value;
                }
            }
            return space;
        }

        private int LeftItemRootViewWidth()
        {
            int width = 0;
            if (leftItemRootSize != null)
            {
                width = leftItemRootSize.Width;
            }
            else
            {
                if (listItemAttrs != null && listItemAttrs.LeftItemRootViewAttributes != null && listItemAttrs.LeftItemRootViewAttributes.Size2D != null)
                {
                    width = listItemAttrs.LeftItemRootViewAttributes.Size2D.Width;
                }
            }
            return width;
        }

        private int RightItemRootViewWidth()
        {
            int width = 0;
            if (rightItemRootSize != null)
            {
                width = rightItemRootSize.Width;
            }
            else
            {
                if (listItemAttrs != null && listItemAttrs.RightItemRootViewAttributes != null && listItemAttrs.RightItemRootViewAttributes.Size2D != null)
                {
                    width = listItemAttrs.RightItemRootViewAttributes.Size2D.Width;
                }
            }
            return width;
        }

        private Size2D DividerSize()
        {
            Size2D size = new Size2D(0, 0);
            if (listItemAttrs != null && listItemAttrs.DividerViewAttributes != null && listItemAttrs.DividerViewAttributes.Size2D != null)
            {
                size = listItemAttrs.DividerViewAttributes.Size2D;
            }
            return size;
        }

        private bool OnTouchEvent(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            Console.WriteLine("Hi, tommy! Touch state is " + state + ", isEnabled = " + isEnabled);
            if (!isEnabled)
            {
                return false;
            }
            if (state == PointStateType.Down)
            {
                isPressed = true;
                UpdateState();
            }
            else if (state == PointStateType.Finished)
            {
                isPressed = false;
                UpdateState();
            }
            return false;
        }

        private void UpdateTypeForItemAlignStyle()
        {
            if (styleType != StyleTypes.ItemAlign || listItemAttrs == null)
            {
                return;
            }

            if (itemAlignType == ItemAlignTypes.Icon)
            {
                if (leftIcon != null)
                {
                    leftIcon.Show();
                }
                if (checkBoxObj != null)
                {
                    checkBoxObj.Hide();
                }

                if (rightItemRootView != null)
                {
                    rightItemRootView.Hide();
                }
            }
            else
            {
                if (checkBoxObj == null && listItemAttrs.CheckBoxStyle != null && leftItemRootView != null)
                {
                    checkBoxObj = new CheckBox(listItemAttrs.CheckBoxStyle)
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };
                    leftItemRootView.Add(checkBoxObj);
                }
                if (checkBoxObj != null)
                {
                    checkBoxObj.Show();
                }
                if (leftIcon != null)
                {
                    leftIcon.Hide();
                }

                if (rightItemRootView != null)
                {
                    rightItemRootView.Show();
                }
            }
        }

        private void UpdateTypeForGroupIndexStyle()
        {
            if (styleType != StyleTypes.GroupIndex || listItemAttrs == null)
            {
                return;
            }
            if (groupIndexType == GroupIndexTypes.None)
            {
                // 56 + text + 56
                if (rightItemRootView != null)
                {
                    rightItemRootView.Hide();
                }
            }
            else if (groupIndexType == GroupIndexTypes.Next)
            {
                // 56 + text + right icon(48) + 56
                if (rightItemRootView != null)
                {
                    rightItemRootView.Show();
                }
                if (switchObj != null)
                {
                    switchObj.Hide();
                }
                if (rightIcon != null)
                {
                    rightIcon.Show();
                }
            }
            else if (groupIndexType == GroupIndexTypes.Switch)
            {
                if (switchObj == null && listItemAttrs.SwitchStyle != null && rightItemRootView != null)
                {
                    switchObj = new Switch(listItemAttrs.SwitchStyle)
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };
                    rightItemRootView.Add(switchObj);
                }
                // 56 + text + switch(72) + 56
                if (rightItemRootView != null)
                {
                    rightItemRootView.Show();
                }
                if (rightIcon != null)
                {
                    rightIcon.Hide();
                }
                if (switchObj != null)
                {
                    switchObj.Show();
                }
            }
            else if (groupIndexType == GroupIndexTypes.DropDown)
            {
                // 56 + text + drop down(48) + 56
                if (rightItemRootView != null)
                {
                    rightItemRootView.Show();
                }
                if (rightIcon != null)
                {
                    rightIcon.Hide();
                }
                if (switchObj != null)
                {
                    switchObj.Hide();
                }
            }
        }

        private void CurrentStyleType()
        {
            if (listItemAttrs != null)
            {
                styleType = listItemAttrs.StyleType;
            }
        }

        private void UpdateState()
        {
            if (styleType != StyleTypes.Effect)
            {
                return;
            }
            if (mainTextLabel == null || listItemAttrs == null)
            {
                return;
            }
            if (!isEnabled)
            {
                if (listItemAttrs.MainTextAttributes != null && listItemAttrs.MainTextAttributes.TextColor != null)
                {
                    mainTextLabel.TextColor = listItemAttrs.MainTextAttributes.TextColor.Disabled;
                }
                if (listItemAttrs.BackgroundColor != null)
                {
                    this.BackgroundColor = listItemAttrs.BackgroundColor.Disabled;
                }
            }
            else
            {
                if (isPressed)
                {
                    if (listItemAttrs.MainTextAttributes != null && listItemAttrs.MainTextAttributes.TextColor != null)
                    {
                        mainTextLabel.TextColor = listItemAttrs.MainTextAttributes.TextColor.Pressed;
                    }
                    if (listItemAttrs.BackgroundColor != null)
                    {
                        this.BackgroundColor = listItemAttrs.BackgroundColor.Pressed;
                    }
                }
                else
                {
                    if (isSelected)
                    {
                        if (listItemAttrs.MainTextAttributes != null && listItemAttrs.MainTextAttributes.TextColor != null)
                        {
                            mainTextLabel.TextColor = listItemAttrs.MainTextAttributes.TextColor.Selected;
                        }
                        if (listItemAttrs.BackgroundColor != null)
                        {
                            this.BackgroundColor = listItemAttrs.BackgroundColor.Selected;
                        }
                    }
                    else
                    {
                        if (listItemAttrs.MainTextAttributes != null && listItemAttrs.MainTextAttributes.TextColor != null)
                        {
                            mainTextLabel.TextColor = listItemAttrs.MainTextAttributes.TextColor.Normal;
                        }
                        if (listItemAttrs.BackgroundColor != null)
                        {
                            this.BackgroundColor = listItemAttrs.BackgroundColor.Normal;
                        }
                    }
                }
            }
        }
    }
}
