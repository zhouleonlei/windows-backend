namespace Tizen.NUI.CommonUI
{
    public class DropDownAttributes : ViewAttributes
    {      
        public DropDownAttributes() : base()
        {
            SpaceBetweenButtonTextAndIcon = 0;
            Space = new Vector4(0, 0, 0, 0);
            ListRelativeOrientation = DropDown.ListOrientation.Left;
            ListMargin = new Vector4(0, 0, 0, 0);
            FocusedItemIndex = 0;
        }
        public DropDownAttributes(DropDownAttributes attributes) : base(attributes)
        {
            if (attributes.ButtonAttributes != null)
            {
                ButtonAttributes = attributes.ButtonAttributes.Clone() as ButtonAttributes;
            }

            if (attributes.HeaderTextAttributes != null)
            {
                HeaderTextAttributes = attributes.HeaderTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.ListBackgroundImageAttributes != null)
            {
                ListBackgroundImageAttributes = attributes.ListBackgroundImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.Space != null)
            {
                Space = new Vector4(attributes.Space.X, attributes.Space.Y, attributes.Space.Z, attributes.Space.W);
            }

            if (attributes.ListMargin != null)
            {
                ListMargin = new Vector4(attributes.ListMargin.X, attributes.ListMargin.Y, attributes.ListMargin.Z, attributes.ListMargin.W);
            }

            if (attributes.ListSize2D != null)
            {
                ListSize2D = new Size2D(attributes.ListSize2D.Width, attributes.ListSize2D.Height);
            }

            if (attributes.ListPadding != null)
            {
                ListPadding = attributes.ListPadding;
            }

            SpaceBetweenButtonTextAndIcon = attributes.SpaceBetweenButtonTextAndIcon;
            ListRelativeOrientation = attributes.ListRelativeOrientation;
            FocusedItemIndex = attributes.FocusedItemIndex;
        }

        public ButtonAttributes ButtonAttributes
        {
            get;
            set;
        }

        public TextAttributes HeaderTextAttributes
        {
            get;
            set;
        }

        public int SpaceBetweenButtonTextAndIcon
        {
            get;
            set;
        }

        public ImageAttributes ListBackgroundImageAttributes
        {
            get;
            set;
        }
		
		public Vector4 Space
        {
            get;
            set;
        }

        public DropDown.ListOrientation ListRelativeOrientation
        {
            get;
            set;
        }

        public Vector4 ListMargin
        {
            get;
            set;
        }

        public int FocusedItemIndex
        {
            get;
            set;
        }

        public Size2D ListSize2D
        {
            get;
            set;
        }

        public Extents ListPadding
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new DropDownAttributes(this);
        }
    }

    public class DropDownItemAttributes : ViewAttributes
    {       
        public DropDownItemAttributes() : base() { }
        public DropDownItemAttributes(DropDownItemAttributes attributes) : base(attributes)
        {
            if (attributes.TextAttributes != null)
            {
                TextAttributes = attributes.TextAttributes.Clone() as TextAttributes;
            }

            if (attributes.IconAttributes != null)
            {
                IconAttributes = attributes.IconAttributes.Clone() as ImageAttributes;
            }

            if (attributes.CheckImageAttributes != null)
            {
                CheckImageAttributes = attributes.CheckImageAttributes.Clone() as ImageAttributes;
            }

            CheckImageRightSpace = attributes.CheckImageRightSpace;
            IsSelected = attributes.IsSelected;
        }

        public TextAttributes TextAttributes
        {
            get;
            set;
        }

        public ImageAttributes IconAttributes
        {
            get;
            set;
        }

        public ImageAttributes CheckImageAttributes
        {
            get;
            set;
        }

        public int CheckImageRightSpace
        {
            get;
            set;
        }

        public bool IsSelected
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new DropDownItemAttributes(this);
        }
    }
}
