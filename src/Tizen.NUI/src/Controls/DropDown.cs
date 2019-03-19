using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    public class DropDown : Control
    {
        #region DropDown
        public enum ListOrientation
        {
            Left,
            Right,
        }

        private Button button;
        private TextLabel headerText;
        private TextLabel buttonText;
        private ImageView listBackgroundImage;
        private FlexibleView list;
        private DropDownListBridge adapter;
        private DropDownAttributes dropDownAttributes;

        public DropDown() : base()
        {
            dropDownAttributes = attributes as DropDownAttributes;
            if (dropDownAttributes == null)
            {
                throw new Exception("DropDown attribute parse error.");
            }
            Initialize();
        }
        public DropDown(string style) : base(style)
        {
            dropDownAttributes = attributes as DropDownAttributes;
            if (dropDownAttributes == null)
            {
                throw new Exception("DropDown attribute parse error.");
            }
            Initialize();
        }
        public DropDown(DropDownAttributes attributes) : base()
        {
            this.attributes = dropDownAttributes = attributes.Clone() as DropDownAttributes;
            if (dropDownAttributes == null)
            {
                throw new Exception("DropDown attribute parse error.");
            }
            Initialize();
        }

        public string HeaderText
        {
            get
            {
                return dropDownAttributes.HeaderTextAttributes?.Text.All;
            }
            set
            {
                if (value != null)
                {
                    CreateHeaderTextAttributes();
                    if (dropDownAttributes.HeaderTextAttributes.Text == null)
                    {
                        dropDownAttributes.HeaderTextAttributes.Text = new StringSelector();
                    }
                    dropDownAttributes.HeaderTextAttributes.Text.All = value;
                    RelayoutRequest();
                }
            }
        }

        public float HeaderTextPointSize
        {
            get
            {
                return dropDownAttributes.HeaderTextAttributes?.PointSize?.All ?? 0;
            }
            set
            {
                CreateHeaderTextAttributes();
                if (dropDownAttributes.HeaderTextAttributes.PointSize == null)
                {
                    dropDownAttributes.HeaderTextAttributes.PointSize = new FloatSelector();
                }
                dropDownAttributes.HeaderTextAttributes.PointSize.All = value;
                RelayoutRequest();
            }
        }

        public string HeaderTextFontFamily
        {
            get
            {
                return dropDownAttributes.HeaderTextAttributes?.FontFamily;
            }
            set
            {
                CreateHeaderTextAttributes();
                dropDownAttributes.HeaderTextAttributes.FontFamily = value;
                RelayoutRequest();
            }
        }

        public Color HeaderTextColor
        {
            get
            {
                return dropDownAttributes.HeaderTextAttributes?.TextColor?.All;
            }
            set
            {
                CreateHeaderTextAttributes();
                if (dropDownAttributes.HeaderTextAttributes.TextColor == null)
                {
                    dropDownAttributes.HeaderTextAttributes.TextColor = new ColorSelector();
                }
                dropDownAttributes.HeaderTextAttributes.TextColor.All = value;
                RelayoutRequest();
            }
        }

        public ColorSelector HeaderTextColorSelector
        {
            get
            {
                return dropDownAttributes.HeaderTextAttributes?.TextColor;
            }
            set
            {
                CreateHeaderTextAttributes();
                if (value != null)
                {
                    dropDownAttributes.HeaderTextAttributes.TextColor = value.Clone() as ColorSelector;
                    RelayoutRequest();
                }
            }
        }

        public string ButtonText
        {
            get
            {
                return dropDownAttributes.ButtonAttributes?.TextAttributes?.Text.All;
            }
            set
            {
                if (value != null)
                {
                    CreateButtonTextAttributes();
                    if (dropDownAttributes.ButtonAttributes.TextAttributes.Text == null)
                    {
                        dropDownAttributes.ButtonAttributes.TextAttributes.Text = new StringSelector();
                    }
                    dropDownAttributes.ButtonAttributes.TextAttributes.Text.All = value;

                    button.Text = value;

                    RelayoutRequest();
                }
            }
        }

        public float ButtonTextPointSize
        {
            get
            {
                return dropDownAttributes.ButtonAttributes?.TextAttributes?.PointSize?.All ?? 0;
            }
            set
            {
                CreateButtonTextAttributes();
                if (dropDownAttributes.ButtonAttributes.TextAttributes.PointSize == null)
                {
                    dropDownAttributes.ButtonAttributes.TextAttributes.PointSize = new FloatSelector();
                }
                dropDownAttributes.ButtonAttributes.TextAttributes.PointSize.All = value;

                button.PointSize = value;

                RelayoutRequest();
            }
        }

        public string ButtonTextFontFamily
        {
            get
            {
                return dropDownAttributes.ButtonAttributes?.TextAttributes?.FontFamily;
            }
            set
            {
                CreateButtonTextAttributes();
                dropDownAttributes.ButtonAttributes.TextAttributes.FontFamily = value;

                button.FontFamily = value;

                RelayoutRequest();
            }
        }

        public Color ButtonTextColor
        {
            get
            {
                return dropDownAttributes.ButtonAttributes?.TextAttributes?.TextColor?.All;
            }
            set
            {
                CreateButtonTextAttributes();
                if (dropDownAttributes.ButtonAttributes.TextAttributes.TextColor == null)
                {
                    dropDownAttributes.ButtonAttributes.TextAttributes.TextColor = new ColorSelector();
                }
                dropDownAttributes.ButtonAttributes.TextAttributes.TextColor.All = value;

                button.TextColor = value;

                RelayoutRequest();
            }
        }

        public ColorSelector ButtonTextColorSelector
        {
            get
            {
                return dropDownAttributes.ButtonAttributes?.TextAttributes?.TextColor;
            }
            set
            {
                CreateButtonTextAttributes();
                if (value != null)
                {
                    dropDownAttributes.ButtonAttributes.TextAttributes.TextColor = value.Clone() as ColorSelector;

                    button.TextColorSelector = value;

                    RelayoutRequest();
                }
            }
        }

        public string ButtonIconImageURL
        {
            get
            {
                return dropDownAttributes.ButtonAttributes?.IconAttributes?.ResourceURL.All;
            }
            set
            {
                if (value != null)
                {
                    CreateButtonIconAttributes();
                    if (dropDownAttributes.ButtonAttributes.IconAttributes.ResourceURL == null)
                    {
                        dropDownAttributes.ButtonAttributes.IconAttributes.ResourceURL = new StringSelector();
                    }
                    dropDownAttributes.ButtonAttributes.IconAttributes.ResourceURL.All = value;

                    button.IconURL = value;

                    RelayoutRequest();
                }
            }
        }

        public Size2D ButtonIconSize2D
        {
            get
            {
                return dropDownAttributes.ButtonAttributes?.IconAttributes?.Size2D;
            }
            set
            {
                if (value != null)
                {
                    CreateButtonIconAttributes();
                    dropDownAttributes.ButtonAttributes.IconAttributes.Size2D = value;
                    RelayoutRequest();
                }
            }
        }
        
        public int SpaceBetweenButtonTextAndIcon
        {
            get
            {
                return dropDownAttributes.SpaceBetweenButtonTextAndIcon;
            }
            set
            {
                dropDownAttributes.SpaceBetweenButtonTextAndIcon = value;
                RelayoutRequest();
            }
        }

        public int LeftSpace
        {
            get
            {
                return (int)dropDownAttributes.Space.X;
            }
            set
            {
                dropDownAttributes.Space.X = value;
                RelayoutRequest();
            }
        }

        public int RightSpace
        {
            get
            {
                return (int)dropDownAttributes.Space.Y;
            }
            set
            {
                dropDownAttributes.Space.Y = value;
                RelayoutRequest();
            }
        }

        public string ListBackgroundImageURL
        {
            get
            {
                return dropDownAttributes.ListBackgroundImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateListBackgroundAttributes();
                    if (dropDownAttributes.ListBackgroundImageAttributes.ResourceURL == null)
                    {
                        dropDownAttributes.ListBackgroundImageAttributes.ResourceURL = new StringSelector();
                    }
                    dropDownAttributes.ListBackgroundImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }

        public Rectangle ListBackgroundImageBorder
        {
            get
            {
                return dropDownAttributes.ListBackgroundImageAttributes?.Border?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateListBackgroundAttributes();
                    if (dropDownAttributes.ListBackgroundImageAttributes.Border == null)
                    {
                        dropDownAttributes.ListBackgroundImageAttributes.Border = new RectangleSelector();
                    }
                    dropDownAttributes.ListBackgroundImageAttributes.Border.All = value;
                    RelayoutRequest();
                }
            }
        }

        public ListOrientation ListRelativeOrientation
        {
            get
            {
                return dropDownAttributes.ListRelativeOrientation;
            }
            set
            {
                dropDownAttributes.ListRelativeOrientation = value;
                RelayoutRequest();
            }
        }

        public int ListLeftMargin
        {
            get
            {
                return (int)dropDownAttributes.ListMargin.X;
            }
            set
            {
                dropDownAttributes.ListMargin.X = value;
                RelayoutRequest();
            }
        }

        public int ListRigthMargin
        {
            get
            {
                return (int)dropDownAttributes.ListMargin.Y;
            }
            set
            {
                dropDownAttributes.ListMargin.Y = value;
                RelayoutRequest();
            }
        }

        public int ListTopMargin
        {
            get
            {
                return (int)dropDownAttributes.ListMargin.Z;
            }
            set
            {
                dropDownAttributes.ListMargin.Z = value;
                RelayoutRequest();
            }
        }

        public void AddItem(DropDownItemData item)
        {
            adapter.InsertData(-1, item);
        }

        protected override void OnUpdate(Attributes attributes)
        {
            dropDownAttributes = attributes as DropDownAttributes;
            if (dropDownAttributes == null)
            {
                return;
            }

            ApplyAttributes(headerText, dropDownAttributes.HeaderTextAttributes);
            ApplyAttributes(buttonText, dropDownAttributes.ButtonAttributes.TextAttributes);
            ApplyAttributes(listBackgroundImage, dropDownAttributes.ListBackgroundImageAttributes);

            button.Position2D.X = (int)dropDownAttributes.Space.X;        
            button.SizeWidth = dropDownAttributes.ButtonAttributes.IconAttributes.Size2D.Width + dropDownAttributes.SpaceBetweenButtonTextAndIcon + buttonText.NaturalSize2D.Width;
            if (dropDownAttributes.ListRelativeOrientation == ListOrientation.Left)
            {
                listBackgroundImage.Position2D = new Position2D((int)dropDownAttributes.ListMargin.X, (int)dropDownAttributes.ListMargin.Z);
            }
            else if (dropDownAttributes.ListRelativeOrientation == ListOrientation.Right)
            {
                listBackgroundImage.Position2D = new Position2D(Size2D.Width - list.Size2D.Width - (int)dropDownAttributes.ListMargin.Y, (int)dropDownAttributes.ListMargin.Z);
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
                if (headerText != null)
                {
                    Remove(headerText);
                    headerText.Dispose();
                    headerText = null;
                }

                if (buttonText != null)
                {
                    Remove(buttonText);
                    buttonText.Dispose();
                    buttonText = null;
                }

                if (button != null)
                {
                    Remove(button);
                    button.Dispose();
                    button = null;
                }

                if (list != null)
                {
                    if (listBackgroundImage != null)
                    {
                        list.Remove(listBackgroundImage);
                        listBackgroundImage.Dispose();
                        listBackgroundImage = null;
                    }

                    Remove(list);
                    list.Dispose();
                    list = null;
                }
            }

            base.Dispose(type);
        }

        protected override Attributes GetAttributes()
        {
            return new DropDownAttributes();
        }

        private void Initialize()
        {
            CreateHeaderText();
            CreateButton();         
            CreateListBackgroundImage();
            CreateList();
        }

        private void CreateHeaderText()
        {
            headerText = new TextLabel();
            headerText.Name = "DropDownHeaderText";
            Add(headerText);
        }

        private void CreateButton()
        {
            button = new Button()
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                IconRelativeOrientation = Button.IconOrientation.Right,
            };
            button.Name = "DropDownButton";
            button.ClickEvent += ButtonClickEvent;
            Add(button);

            buttonText = new TextLabel()
            {
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            buttonText.Name = "DropDownButtonText";
            Add(buttonText);
            buttonText.Hide();
        }

        private void CreateList()
        {
            list = new FlexibleView();
            list.Name = "DropDownList";
            LinearLayoutManager layoutManager = new LinearLayoutManager(LinearLayoutManager.VERTICAL);
            list.SetLayoutManager(layoutManager);
            adapter = new DropDownListBridge();
            list.SetAdapter(adapter);
            list.Focusable = true;
            list.FocusedItemIndex = 0;
            list.Size2D = new Size2D(400, 500);
            list.Padding = new Extents(4, 4, 4, 4);
            listBackgroundImage.Add(list);
            listBackgroundImage.Hide();
        }

        private void CreateListBackgroundImage()
        {
            listBackgroundImage = new ImageView
            {
                Name = "ListBackgroundImage",
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                WidthResizePolicy = ResizePolicyType.FitToChildren,
                HeightResizePolicy = ResizePolicyType.FitToChildren,
            };
            Add(listBackgroundImage);
        }

        private void ButtonClickEvent(object sender, Button.ClickEventArgs e)
        {
            button.Hide();
            listBackgroundImage.Show();
        }

        private void CreateHeaderTextAttributes()
        {
            if (dropDownAttributes.HeaderTextAttributes == null)
            {
                dropDownAttributes.HeaderTextAttributes = new TextAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };
            }
        }

        private void CreateButtonAttributes()
        {
            if (dropDownAttributes.ButtonAttributes == null)
            {
                dropDownAttributes.ButtonAttributes = new ButtonAttributes();
            }
        }

        private void CreateButtonTextAttributes()
        {
            CreateButtonAttributes();

            if (dropDownAttributes.ButtonAttributes.TextAttributes == null)
            {
                dropDownAttributes.ButtonAttributes.TextAttributes = new TextAttributes
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    Position2D = new Position2D(0, 0),
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Center,
                };
            }
        }

        private void CreateButtonIconAttributes()
        {
            CreateButtonAttributes();

            if (dropDownAttributes.ButtonAttributes.IconAttributes == null)
            {
                dropDownAttributes.ButtonAttributes.IconAttributes = new ImageAttributes
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight,
                    PivotPoint = Tizen.NUI.PivotPoint.CenterRight,
                };
            }
        }

        private void CreateListBackgroundAttributes()
        {
            if (dropDownAttributes.ListBackgroundImageAttributes == null)
            {
                dropDownAttributes.ListBackgroundImageAttributes = new ImageAttributes
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                };
            }
        }
        #endregion

        #region DropDownItemData
        public class DropDownItemData
        {
            public DropDownItemData()
            {               
            }

            public string Text
            {
                get;
                set;
            }

            public string IconResourceUrl
            {
                get;
                set;
            }
        }
        #endregion

        #region DropDownItemView
        public class DropDownItemView : View
        {
            private TextLabel mText = null;
            private ImageView mIcon = null;
            private ImageView mCheck = null;

            public DropDownItemView() { }

            public string Text
            {
                get
                {
                    return mText.Text;
                }
                set
                {
                    CreateText();
                    mText.Text = value;
                }
            }

            public string FontFamily
            {
                get
                {
                    return mText.FontFamily;
                }
                set
                {
                    CreateText();
                    mText.FontFamily = value;
                }
            }

            public float PointSize
            {
                get
                {
                    return mText.PointSize;
                }
                set
                {
                    CreateText();
                    mText.PointSize = value;
                }
            }

            public Color TextColor
            {
                get
                {
                    return mText.TextColor;
                }
                set
                {
                    CreateText();
                    mText.TextColor = value;
                }
            }

            public Position2D TextPosition2D
            {
                get
                {
                    return mText.Position2D;
                }
                set
                {
                    CreateText();
                    mText.Position2D = value;
                }
            }

            public string IconResourceUrl
            {
                get
                {
                    return mIcon.ResourceUrl;
                }
                set
                {
                    CreateIcon();
                    mIcon.ResourceUrl = value;
                }
            }

            public Position2D IconPosition2D
            {
                get
                {
                    return mIcon.Position2D;
                }
                set
                {
                    CreateIcon();
                    mIcon.Position2D = value;
                }
            }

            public string CheckResourceUrl
            {
                get
                {
                    return mCheck.ResourceUrl;
                }
                set
                {
                    CreateCheckImage();
                    mCheck.ResourceUrl = value;
                }
            }

            public Position2D CheckPosition2D
            {
                get
                {
                    return mCheck.Position2D;
                }
                set
                {
                    CreateCheckImage();
                    mCheck.Position2D = value;
                }
            }

            public Size2D CheckImageSize2D
            {
                get
                {
                    return mCheck.Size2D;
                }
                set
                {
                    CreateCheckImage();
                    mCheck.Size2D = value;
                }
            }

            public bool ShowCheckImage
            {
                get
                {
                    return mCheck.Visibility;
                }
                set
                {
                    CreateCheckImage();
                    if(value)
                    {
                        mCheck.Show();
                    }
                    else
                    {
                        mCheck.Hide();
                    }
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
                    if (mText != null)
                    {
                        Remove(mText);
                        mText.Dispose();
                        mText = null;
                    }

                    if (mIcon != null)
                    {
                        Remove(mIcon);
                        mIcon.Dispose();
                        mIcon = null;
                    }

                    if (mCheck != null)
                    {
                        Remove(mCheck);
                        mCheck.Dispose();
                        mCheck = null;
                    }
                }
                base.Dispose(type);
            }

            private void CreateIcon()
            {
                if(mIcon == null)
                {
                    mIcon = new ImageView();
                    Add(mIcon);
                }
            }

            private void CreateText()
            {
                if (mText == null)
                {
                    mText = new TextLabel()
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Begin,
                    };
                    Add(mText);
                }
            }

            private void CreateCheckImage()
            {
                if (mCheck == null)
                {
                    mCheck = new ImageView()
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    };
                    Add(mCheck);
                }
            }
        }
        #endregion

        #region DropDownListBridge

        public class DropDownListBridge : FlexibleView.Adapter
        {
            private List<DropDownItemData> mDatas = new List<DropDownItemData>();

            public DropDownListBridge()
            {
            }

            public void InsertData(int position, DropDownItemData data)
            {
                if(position == -1)
                {
                    position = mDatas.Count;
                }
                mDatas.Insert(position, data);
                NotifyItemInserted(position);
            }

            public void RemoveData(int position)
            {
                mDatas.RemoveAt(position);
                NotifyItemRemoved(position);
            }

            public override FlexibleView.ViewHolder OnCreateViewHolder(int viewType)
            {
                FlexibleView.ViewHolder viewHolder = new FlexibleView.ViewHolder(new DropDownItemView());

                return viewHolder;
            }

            public override void OnBindViewHolder(FlexibleView.ViewHolder holder, int position)
            {
                //holder.Padding = new Vector4(0, 2, 0, 2);
                holder.SizeWidth = 400;
                holder.SizeHeight = 96;

                DropDownItemData listItemData = mDatas[position];

                DropDownItemView listItemView = holder.ItemView as DropDownItemView;
                listItemView.Name = "Item" + position;

                if (listItemView != null)
                {
                    listItemView.Text = String.Format("{0:D2}", position) + " : " + listItemData.Text;
                    listItemView.PointSize = 12;
                    listItemView.TextPosition2D = new Position2D(28, 0); //listItemView.BackgroundColor = Color.Green;

                    listItemView.CheckResourceUrl = @"../../../demo/csharp-demo/res/images/FH3/10. Drop Down/dropdown_checkbox_on.png";
                    listItemView.CheckImageSize2D = new Size2D(40, 40);
                    listItemView.CheckPosition2D = new Position2D(listItemView.Size2D.Width - 16 - listItemView.CheckImageSize2D.Width, (listItemView.Size2D.Height - listItemView.CheckImageSize2D.Height) / 2);
                }              
            }

            public override int GetItemCount()
            {
                return mDatas.Count;
            }

            public override void OnFocusChange(FlexibleView.ViewHolder previousFocus, FlexibleView.ViewHolder currentFocus)
            {
                if (previousFocus != null)
                {
                    DropDownItemView listItemView = previousFocus.ItemView as DropDownItemView;
                    if (listItemView != null)
                    {
                        listItemView.ShowCheckImage = false;
                        NotifyItemChanged(previousFocus.AdapterPosition);
                    }
                }
                if (currentFocus != null)
                {
                    DropDownItemView listItemView = currentFocus.ItemView as DropDownItemView;
                    if (listItemView != null)
                    {
                        listItemView.ShowCheckImage = true;
                        NotifyItemChanged(currentFocus.AdapterPosition);
                    }
                }
            }
        }
        #endregion
    }
}
