using Tizen.NUI.Binding;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    public class NaviFrameAttributes : ViewAttributes
    {
        public static readonly BindableProperty NaviHeaderAttributesProperty = BindableProperty.Create("NaviHeaderAttributes", typeof(ViewAttributes), typeof(NaviFrameAttributes), default(ViewAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (NaviFrameAttributes)bindable;
            if (newValue != null)
            {
                attrs.naviHeaderAttributes = (ViewAttributes)newValue;
            }
        },
       defaultValueCreator: (bindable) =>
       {
           var attrs = (NaviFrameAttributes)bindable;
           return (object)attrs.naviHeaderAttributes;
       });

        public static readonly BindableProperty ContentAttributesProperty = BindableProperty.Create("ContentAttributes", typeof(ViewAttributes), typeof(NaviFrameAttributes), default(ViewAttributes), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var attrs = (NaviFrameAttributes)bindable;
            if (newValue != null)
            {
                attrs.contentAttributes = (ViewAttributes)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var attrs = (NaviFrameAttributes)bindable;
            return (object)attrs.contentAttributes;
        });     


        private ViewAttributes naviHeaderAttributes;
        private ViewAttributes contentAttributes;

        public NaviFrameAttributes() : base() { }
        public NaviFrameAttributes(NaviFrameAttributes attributes) : base(attributes)
        {
            if (attributes.naviHeaderAttributes != null)
            {
                naviHeaderAttributes = attributes.naviHeaderAttributes.Clone() as ViewAttributes;
            }
            if (attributes.contentAttributes != null)
            {
                contentAttributes = attributes.contentAttributes.Clone() as ViewAttributes;
            }

        }

        public ViewAttributes NaviHeaderAttributes
        {
            get
            {
                return (ViewAttributes)GetValue(NaviHeaderAttributesProperty);
            }
            set
            {
                SetValue(NaviHeaderAttributesProperty, value);
            }
        }

        public ViewAttributes ContentAttributes
        {
            get
            {
                return (ViewAttributes)GetValue(ContentAttributesProperty);
            }
            set
            {
                SetValue(ContentAttributesProperty, value);
            }
        }

        public override Attributes Clone()
        {
            return new NaviFrameAttributes(this);
        }
    }
}
