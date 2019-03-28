using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SwitchAttributes : ButtonAttributes
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SwitchAttributes() : base() { }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SwitchAttributes(SwitchAttributes attributes) : base(attributes)
        {
            if(attributes == null)
            {
                return;
            }
            if (attributes.SwitchHandlerImageAttributes != null)
            {
                SwitchHandlerImageAttributes = attributes.SwitchHandlerImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.SwitchBackgroundImageAttributes != null)
            {
                SwitchBackgroundImageAttributes = attributes.SwitchBackgroundImageAttributes.Clone() as ImageAttributes;
            }
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes SwitchHandlerImageAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes SwitchBackgroundImageAttributes
        {
            get;
            set;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new SwitchAttributes(this);
        }
    }
}
