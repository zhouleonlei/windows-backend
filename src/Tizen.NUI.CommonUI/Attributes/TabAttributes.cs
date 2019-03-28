using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TabAttributes : ViewAttributes
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabAttributes() : base()
        {
            Space = new Vector4(0, 0, 0, 0);
            IsNatureTextWidth = false;
            ItemGap = 0;
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TabAttributes(TabAttributes attributes) : base(attributes)
        {
            if (attributes.UnderLineAttributes != null)
            {
                UnderLineAttributes = attributes.UnderLineAttributes.Clone() as ViewAttributes;
            }

            if (attributes.TextAttributes != null)
            {
                TextAttributes = attributes.TextAttributes.Clone() as TextAttributes;
            }

            if (attributes.Space != null)
            {
                Space = new Vector4(attributes.Space.X, attributes.Space.Y, attributes.Space.Z, attributes.Space.W);
            }
            else
            {
                Space = new Vector4(0, 0, 0, 0);
            }
            ItemGap = attributes.ItemGap;
            IsNatureTextWidth = attributes.IsNatureTextWidth;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewAttributes UnderLineAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextAttributes TextAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsNatureTextWidth
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int ItemGap
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 Space
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new TabAttributes(this);
        }
    }
}
