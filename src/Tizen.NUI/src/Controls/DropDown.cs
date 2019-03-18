using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    public class DropDown : Control
    {
        private Button button;
        private TextLabel headerText;
        private TextLabel buttonText;
        private FlexibleView list;
        private DropDownListBridge adapter;
        List<DropDownItemData> dataList = new List<DropDownItemData>();
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

        public void AddItem(DropDownItemData item)
        {
            dataList.Add(item);
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
            
            button.Position2D.X = (int)dropDownAttributes.Space.X;        
            button.SizeWidth = dropDownAttributes.ButtonAttributes.IconAttributes.Size2D.Width + dropDownAttributes.SpaceBetweenButtonTextAndIcon + buttonText.NaturalSize2D.Width;
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

                if (button != null)
                {
                    Remove(button);
                    button.Dispose();
                    button = null;
                }

                if (list != null)
                {
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
            headerText = new TextLabel();
            headerText.Name = "DropDownHeaderText";
            Add(headerText);

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
            button.Add(buttonText);
            buttonText.Hide();

            list = new FlexibleView();
            list.Name = "DropDownList";
            Add(list);

            adapter = new DropDownListBridge(dataList);
            list.SetAdapter(adapter);
        }

        private void ButtonClickEvent(object sender, Button.ClickEventArgs e)
        {
            throw new NotImplementedException();
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

        public class DropDownItemView : View
        {
            private TextLabel mText;
            private ImageView mIcon;

            public DropDownItemView()
            {
                mText = new TextLabel();
                Add(mText);

                mIcon = new ImageView();
                Add(mIcon);
            }

            public string Text
            {
                get
                {
                    return mText.Text;
                }
                set
                {
                    mText.Text = value;
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
                    mIcon.ResourceUrl = value;
                }
            }
        }

        public class DropDownListBridge : FlexibleView.Adapter
        {
            private List<DropDownItemData> mDatas;

            public DropDownListBridge(List<DropDownItemData> datas)
            {
                mDatas = datas;
            }

            public void InsertData(int position)
            {
                mDatas.Insert(position, new DropDownItemData());
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
                //Console.WriteLine($"OnBindItemView... position: {position}");
                holder.Padding = new Vector4(1, 1, 1, 1);
                holder.SizeWidth = 150;
                holder.SizeHeight = 60;

                DropDownItemData listItemData = mDatas[position];

                DropDownItemView listItemView = holder.ItemView as DropDownItemView;
                listItemView.Name = "Item" + position;
                //Random rd = new Random();
                //listItemView.SizeHeight = 60;
                if (listItemView != null)
                {
                    listItemView.Text = String.Format("{0:D2}", position) + " : " + listItemData.Text;
                }
                //listItemView.Margin = new Extents(1, 1, 1, 1);
                if (position % 2 == 0)
                    listItemView.BackgroundColor = Color.Cyan;
                else
                    listItemView.BackgroundColor = Color.Yellow;
            }

            public override int GetItemCount()
            {
                return mDatas.Count;
            }

            public override void OnFocusChange(FlexibleView.ViewHolder previousFocus, FlexibleView.ViewHolder currentFocus)
            {
                if (previousFocus != null)
                {
                    //Console.WriteLine($"previousFocus {previousFocus.AdapterPosition}");
                    if (previousFocus.AdapterPosition % 2 == 0)
                        previousFocus.ItemView.BackgroundColor = Color.Cyan;
                    else
                        previousFocus.ItemView.BackgroundColor = Color.Yellow;
                    //previousFocus.SizeWidth = 150;
                    //previousFocus.SizeHeight = 60;
                    //NotifyItemChanged(previousFocus.AdapterPosition);
                }
                if (currentFocus != null)
                {
                    //Console.WriteLine($"currentFocus {currentFocus.AdapterPosition}");
                    currentFocus.ItemView.BackgroundColor = Color.Magenta;
                    //currentFocus.SizeWidth = 200;
                    //currentFocus.SizeHeight = 100;
                    //NotifyItemChanged(currentFocus.AdapterPosition);
                }
            }

        }
    }
}
