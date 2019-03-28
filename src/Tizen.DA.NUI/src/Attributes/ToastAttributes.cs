using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class ToastAttributes : Tizen.NUI.CommonUI.ToastAttributes
    {

        public ToastAttributes() : base() { }
        public ToastAttributes(ToastAttributes attributes) : base(attributes)
        {
            if(attributes.LoadingAttributes != null)
            {
                LoadingAttributes = attributes.LoadingAttributes.Clone() as LoadingAttributes;
            }
        }
      
        public LoadingAttributes LoadingAttributes
        {
            get;
            set;
        }

        public override Attributes Clone()
        {
            return new ToastAttributes(this);
        }
    }
}
