using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{
    /// <summary>
    /// LoadingAttributes is a class which saves Loading's ux data.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LoadingAttributes : ViewAttributes
    {
        /// <summary>
        /// Creates a new instance of a LoadingAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LoadingAttributes() : base() { }

        /// <summary>
        /// Creates a new instance of a LoadingAttributes with attributes.
        /// </summary>
        /// <param name="attributes">Create LoadingAttributes by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LoadingAttributes(LoadingAttributes attributes) : base(attributes)
        {
            if(attributes == null)
            {
                return;
            }

            if (attributes.LoadingImageURLPrefix != null)
            {
                LoadingImageURLPrefix = attributes.LoadingImageURLPrefix.Clone() as StringSelector;
            }
            if (attributes.FPS != null)
            {
                FPS = attributes.FPS.Clone() as IntSelector;
            }
            if (attributes.LoadingImageAttributes != null)
            {
                LoadingImageAttributes = attributes.LoadingImageAttributes.Clone() as ImageAttributes;
            }
        }

        /// <summary>
        /// Loading Image resource URL Prefix.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector LoadingImageURLPrefix
        {
            get;
            set;
        }

        /// <summary>
        /// Loading frame per second.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IntSelector FPS
        {
            get;
            set;
        }

        /// <summary>
        /// Loading Image's attributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes LoadingImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new LoadingAttributes(this);
        }

    }
}
