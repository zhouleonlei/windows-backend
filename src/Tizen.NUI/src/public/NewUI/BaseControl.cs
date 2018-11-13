using System;
using System.Collections.Generic;

namespace Tizen.NUI.BaseComponents
{
    public abstract class BaseControl : View
    {
        public BaseControl() : base()
        {
            Initialize(null);
        }
        public BaseControl(string style) : base()
        {
            Initialize(style);
        }
        public static void RegisterStyle(string style, Type renderType)
        {
            if (styleToRender.ContainsKey(style))
            {
                throw new InvalidOperationException(string.Format($"[RegisterStyle] [{style}] already be used"));
            }

            styleToRender.Add(style, renderType);
        }

        public new States State
        {
            get
            {
                return state;
            }
            set
            {
                if(State != value)
                {
                    state = value;
                    renderer.OnStateChanged(State);
                }
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
                KeyEvent -= OnKey;
                Relayout -= OnRelayout;
                FocusGained -= OnFocusGained;
                FocusLost -= OnFocusLost;
                TouchEvent -= OnTouch;
                tapGestureDetector.Detected -= OnTapGestureDetected;
            }
            base.Dispose(type);
        }

        protected BaseRenderer renderer;
        protected abstract BaseRenderer GetRenderer();

        protected virtual bool OnKey(object source, KeyEventArgs e)
        {
            return false;
        }
        protected virtual void OnRelayout(object sender, EventArgs e)
        {
        }
        protected virtual void OnFocusGained(object sender, EventArgs e)
        {
        }
        protected virtual void OnFocusLost(object sender, EventArgs e)
        {
        }
        protected virtual void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
        }
        protected virtual bool OnTouch(object source, TouchEventArgs e)
        {
            return false;
        }

        private void Initialize(string style)
        {
            IsCreateByXaml = true;
            instance = this;
            renderer = (style == null) ? GetRenderer() : GetRender(style);
            renderer.Root = this;

            State = States.Normal;
            renderer.OnStateChanged(State);

            KeyEvent += OnKey;
            Relayout += OnRelayout;
            FocusGained += OnFocusGained;
            FocusLost += OnFocusLost;

            LeaveRequired = true;
            TouchEvent += OnTouch;

            tapGestureDetector.Attach(this);
            tapGestureDetector.Detected += OnTapGestureDetected;
        }

        static internal BaseControl Instance
        {
            get
            {
                return instance;
            }
        }

        private BaseRenderer GetRender(string style)
        {
            return Activator.CreateInstance(styleToRender[style]) as BaseRenderer;
        }
        private static Dictionary<string, Type> styleToRender = new Dictionary<string, Type>();
        private static BaseControl instance = null;

        private TapGestureDetector tapGestureDetector = new TapGestureDetector();

        private States state = States.Normal;
    }
}
