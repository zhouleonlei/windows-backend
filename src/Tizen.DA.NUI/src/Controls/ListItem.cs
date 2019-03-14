using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.FH.NUI.Controls
{
    public class ListItem : Tizen.NUI.Controls.Control
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
        /// Type for item align style
        /// </summary>
        public enum ItemAlignTypes
        {
            Icon,
            CheckIcon
        }

        /// <summary>
        /// Type for group index style
        /// </summary>
        public enum GroupIndexTypes
        {
            None,
            DropDown,
            Next,
            Switch
        }

        /// <summary>
        /// Type for style
        /// </summary>
        public enum StyleTypes
        {
            None,
            Default,
            MultiSubText,
            Effect,
            ItemAlign,
            NextDepth,
            GroupIndex,
            DropDown
        }
        
        static ListItem()
        {
            RegisterStyle("Default", typeof(ListItemAttributes));
        }

        public ListItem() : this("Default")
        {
            Initialize();
        }

        public ListItem(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Property for type in item align style, only useful in ItemAlignListItem style
        /// </summary>
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
        public void BindObjectToRight(object obj)
        {
            if (rightItemRootView == null || obj == null)
            {
                return;
            }
            rightItemRootView.Add(obj as View);
        }

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

        protected override Attributes GetAttributes()
        {
            return null;
        }

        protected override void OnUpdate(Attributes attributtes)
        {
            listItemAttrs = attributes as ListItemAttributes;
            if (listItemAttrs == null)
            {
                return;
            }
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
                throw new Exception("Fail to get the ListItem attributes.");
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
                textRootView.Size2D = new Size2D(rootWidth, heightSum);
                textRootView.Position2D = new Position2D(LeftSpaceValue() + LeftItemRootViewWidth() + SpaceBetweenLeftItemAndTextValue(), 0);
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
            leftItemRootView.Position2D = new Position2D(LeftSpaceValue(), 0);
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
            rightItemRootView.Position2D = new Position2D(-RightSpaceValue(), 0);
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
