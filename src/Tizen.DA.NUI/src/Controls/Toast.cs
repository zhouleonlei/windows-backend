using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using Tizen.NUI;
using System;

namespace Tizen.FH.NUI.Controls
{
    public class Toast : Tizen.NUI.Controls.Toast
    {
        private ImageView toastIcon;
        private ToastAttributes toastAttributes;

        public enum ToastType
        {
            SHORT,
            LONG
        };

        public Toast(ToastType type) : this(null, type) { }
        public Toast(string style, ToastType type) : base(style)
        {
            Initialize(type);
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (toastIcon != null)
                {
                    this.Remove(toastIcon);
                    toastIcon.Dispose();
                    toastIcon = null;
                }

            }

            base.Dispose(type);
        }

        protected override void OnUpdate(Attributes attributes)
        {
            toastAttributes = attributes as ToastAttributes;
            if (toastAttributes == null)
            {
                return;
            }

            ///////////////////// Icon ///////////////////////////////
            ApplyAttributes(toastIcon, toastAttributes.IconAttributes);

            base.OnUpdate(attributes);
        }

        protected override void OnRelayout(object sender, EventArgs e)
        {
            OnUpdate(attributes);

            base.OnRelayout(sender, e);
        }

        private void Initialize(ToastType type)
        {
            toastAttributes = attributes as ToastAttributes;
            if (toastAttributes == null)
            {
                throw new Exception("Toast attribute parse error.");
            }

            if (type == ToastType.LONG)
            {
                if (toastAttributes.IconAttributes != null)
                {
                    toastIcon = new ImageView();

                    this.Add(toastIcon);
                }
            }
        }
    }
}
