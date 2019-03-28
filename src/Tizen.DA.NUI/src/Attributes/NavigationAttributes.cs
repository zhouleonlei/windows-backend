using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    public class NavigationAttributes : ViewAttributes
    {     
        public NavigationAttributes() : base()
        {
            DividerLineColor = new Color(0, 0, 0, 0.1f);
            ItemGap = 0;
            Space = new Vector4(0, 0, 0, 0);
            IsFitWithItems = false;
        }
        public NavigationAttributes(NavigationAttributes attributes) : base(attributes)
        {
            if (attributes.ShadowImageAttributes != null)
            {
                ShadowImageAttributes = attributes.ShadowImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.BackgroundImageAttributes != null)
            {
                BackgroundImageAttributes = attributes.BackgroundImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.DividerLineColor != null)
            {
                DividerLineColor = new Color(attributes.DividerLineColor.R, attributes.DividerLineColor.G, attributes.DividerLineColor.B, attributes.DividerLineColor.A);
            }

            if (attributes.Space != null)
            {
                Space = new Vector4(attributes.Space.X, attributes.Space.Y, attributes.Space.Z, attributes.Space.W);
            }

            ItemGap = attributes.ItemGap;
            IsFitWithItems = attributes.IsFitWithItems;
        }

        public ImageAttributes ShadowImageAttributes
        {
            get;
            set;
        }

        public ImageAttributes BackgroundImageAttributes
        {
            get;
            set;
        }

        public Color DividerLineColor
        {
            get;
            set;
        }

        public int ItemGap
        {
            get;
            set;
        }

        public Vector4 Space
        {
            get;
            set;
        }

        public bool IsFitWithItems
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new NavigationAttributes(this);
        }
    }

    public class NavigationItemAttributes : ButtonAttributes
    {
        public NavigationItemAttributes() : base()
        {
            Space = new Vector4(0, 0, 0, 0);
            EnableIconCenter = false;
        }
        public NavigationItemAttributes(NavigationItemAttributes attributes) : base(attributes)
        {
            if (attributes.SubTextAttributes != null)
            {
                SubTextAttributes = attributes.SubTextAttributes.Clone() as TextAttributes;
            }

            if (attributes.DividerLineAttributes != null)
            {
                DividerLineAttributes = attributes.DividerLineAttributes.Clone() as ViewAttributes;
            }

            if (attributes.Space != null)
            {
                Space = new Vector4(attributes.Space.X, attributes.Space.Y, attributes.Space.Z, attributes.Space.W);
            }

            EnableIconCenter = attributes.EnableIconCenter;
        }

        public TextAttributes SubTextAttributes
        {
            get;
            set;
        }

        public ViewAttributes DividerLineAttributes
        {
            get;
            set;
        }

        public Vector4 Space
        {
            get;
            set;
        }

        public bool EnableIconCenter
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new NavigationItemAttributes(this);
        }
    }
}
