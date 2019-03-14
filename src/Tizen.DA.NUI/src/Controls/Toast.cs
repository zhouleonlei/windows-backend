using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using Tizen.NUI;
using System;

namespace Tizen.FH.NUI.Controls
{
    public class Toast : Tizen.NUI.Controls.Toast
    {
        public enum ToastLengthType
        {
            SHORT,
            LONG,
            CUSTOM
        };
        //private ImageView toastIcon;
        private Loading loading;
        private ToastAttributes toastAttributes;
        private ToastLengthType lengthType = ToastLengthType.CUSTOM;
        private bool loadingEnable = false;
        public ToastLengthType LengthType
        {
            get
            {
                return lengthType;
            }
            set
            {
                if (value != lengthType)
                {
                    if (value == ToastLengthType.LONG)
                    {
                        this.SizeWidth = 1000;
                    }
                    else if (value == ToastLengthType.SHORT)
                    {
                        this.SizeWidth = 512;
                    }

                    lengthType = value;
                }

            }
        }

        public bool LoadingEnable
        {
            get
            {
                return loadingEnable;
            }
            set
            {
                if (value != loadingEnable)
                {
                    if (value == true)
                    {
                        AddLoading();
                    }
                    else
                    {
                        RemoveLoading();
                    }

                    loadingEnable = value;
                }
                Console.WriteLine(toastText.Position2D.X.ToString()) ;
            }
        }

        public Toast() : base()
        {
            toastAttributes = attributes as ToastAttributes;
            if (toastAttributes == null)
            {
                throw new Exception("Toast attribute parse error.");
            }
        }

        public Toast(string style) : base(style)
        {
            toastAttributes = attributes as ToastAttributes;
            if (toastAttributes == null)
            {
                throw new Exception("Toast attribute parse error.");
            }
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (loading != null)
                {
                    this.Remove(loading);
                    loading.Dispose();
                    loading = null;
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

            ///////////////////// Loading ///////////////////////////////
            if (loadingEnable)
            {
                ApplyAttributes(loading, toastAttributes.LoadingAttributes);
            }

            base.OnUpdate(attributes);
            Console.WriteLine("text wid = "+toastText.SizeWidth.ToString());

        }

        protected override void OnRelayout(object sender, EventArgs e)
        {
            OnUpdate(attributes);

            base.OnRelayout(sender, e);
        }

        private void AddLoading()
        {
            loading= new Loading("DefaultLoading");
            this.Add(loading);
            loading.Position2D.X = 96;
            loading.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
            loading.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
            loading.Size2D = new Size2D(100, 100);

            loading.PositionUsesPivotPoint = true;

            toastAttributes.TextAttributes.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
            toastAttributes.TextAttributes.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
            toastAttributes.TextAttributes.Position2D.X = 204;
            toastAttributes.TextAttributes.HorizontalAlignment = HorizontalAlignment.Begin;
            OnUpdate(toastAttributes);
        }

        private void RemoveLoading()
        {
            if (loading != null)
            {
                this.Remove(loading);
                loading.Dispose();
            }

            toastAttributes.TextAttributes.Position2D.X = 0;
            toastAttributes.TextAttributes.HorizontalAlignment = HorizontalAlignment.Center;
            toastAttributes.TextAttributes.ParentOrigin = Tizen.NUI.ParentOrigin.Center;
            toastAttributes.TextAttributes.PivotPoint = Tizen.NUI.PivotPoint.Center;
            OnUpdate(toastAttributes);
        }
    }
}
