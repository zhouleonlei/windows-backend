using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{
    /// <summary>
    /// ScrollBarAttributes is a class which saves Scrollbar's ux data.
    /// </summary>
    /// <since_tizen> 5.5 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ScrollBarAttributes : ViewAttributes
    {
        /// <summary>
        /// Creates a new instance of a ScrollBarAttributes.
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBarAttributes() : base()
        {
            Direction = ScrollBar.DirectionType.Horizontal;
        }

        /// <summary>
        /// Creates a new instance of a ScrollBarAttributes with attributes.
        /// </summary>
        /// <param name="attrs">Create ScrollBarAttributes by attributes customized by user.</param>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBarAttributes(ScrollBarAttributes attributes) : base(attributes)
        {
            if (attributes.TrackImageAttributes != null)
            {
                TrackImageAttributes = attributes.TrackImageAttributes.Clone() as ImageAttributes;
            }

            if (attributes.ThumbImageAttributes != null)
            {
                ThumbImageAttributes = attributes.ThumbImageAttributes.Clone() as ImageAttributes;
            }

            Direction = attributes.Direction;
            MaxValue = attributes.MaxValue;
            MinValue = attributes.MinValue;
            CurValue = attributes.CurValue;
            Duration = attributes.Duration;
        }

        /// <summary>
        /// Get or set track image attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes TrackImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set thumb image attributes
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageAttributes ThumbImageAttributes
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set direction type
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBar.DirectionType? Direction
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set maximum value
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint MaxValue
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set minim value
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint MinValue
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set current value
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint CurValue
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set duration
        /// </summary>
        /// <since_tizen> 5.5 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Duration
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
            return new ScrollBarAttributes(this);
        }

    }
}
