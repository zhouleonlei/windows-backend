using System;
using System.Collections.Generic;
using System.Reflection;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Controls
{
    public abstract class Control : VisualView
    {
        public new static readonly BindableProperty StateProperty = BindableProperty.Create("State", typeof(States), typeof(Attributes), States.Normal, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (Control)bindable;
            if (newValue != null)
            {
                control.state = (States)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var control = (Control)bindable;
            return control.state;
        });
        private States state;
        private bool isFocused = false;

        public Control() : base()
        {
            Initialize(null);
        }
        public Control(string style) : base()
        {
            Initialize(style);
        }

        public new States State
        {
            get
            {
                return (States)GetValue(StateProperty);
            }
            set
            {
                if(state != value)
                {
                    SetValue(StateProperty, value);
                }
            }
        }

        internal bool StateFocusableOnTouchMode
        {
            get;
            set;
        }

        internal bool IsFocused
        {
            get
            {
                return isFocused || HasFocus();
            }
        }
        public static void RegisterStyle(string style, Type attributeType)
        {
            if (styleToAttributes.ContainsKey(style))
            {
                throw new InvalidOperationException(string.Format($"[RegisterStyle] [{style}] already be used"));
            }

            styleToAttributes.Add(style, attributeType);
        }

        protected  void ApplyAttributes(View view, ViewAttributes attrs)
        {
            if (view == null || attrs == null)
            {
                return;
            }

            if (attrs.Position2D?.GetValue(State) != null)
            {
                view.Position2D = attrs.Position2D.GetValue(State);
            }
            if (attrs.Size2D?.GetValue(State) != null)
            {
                view.Size2D = attrs.Size2D.GetValue(State);
            }
            if (attrs.MinimumSize?.GetValue(State) != null)
            {
                view.MinimumSize = attrs.MinimumSize.GetValue(State);
            }
            if (attrs.BackgroundColor?.GetValue(State) != null)
            {
                view.BackgroundColor = attrs.BackgroundColor.GetValue(State);
            }
            if (attrs.PositionUsesPivotPoint?.GetValue(State) != null)
            {
                view.PositionUsesPivotPoint = attrs.PositionUsesPivotPoint.GetValue(State).Value;
            }
            if (attrs.ParentOrigin?.GetValue(State) != null)
            {
                view.ParentOrigin = attrs.ParentOrigin.GetValue(State);
            }
            if (attrs.PivotPoint?.GetValue(State) != null)
            {
                view.PivotPoint = attrs.PivotPoint.GetValue(State);
            }
            if (attrs.WidthResizePolicy?.GetValue(State) != null)
            {
                view.WidthResizePolicy = attrs.WidthResizePolicy.GetValue(State).Value;
            }
            if (attrs.HeightResizePolicy?.GetValue(State) != null)
            {
                view.HeightResizePolicy = attrs.HeightResizePolicy.GetValue(State).Value;
            }
            if (attrs.SizeModeFactor?.GetValue(State) != null)
            {
                view.SizeModeFactor = attrs.SizeModeFactor.GetValue(State);
            }
            if (attrs.Opacity?.GetValue(State) != null)
            {
                view.Opacity = attrs.Opacity.GetValue(State).Value;
            }

            ImageView image = view as ImageView;
            ImageAttributes imageAttrs = attrs as ImageAttributes;
            if (image != null && imageAttrs != null)
            {
                if (imageAttrs.ResourceURL?.GetValue(State) != null)
                {
                    image.ResourceUrl = imageAttrs.ResourceURL.GetValue(State);
                }
                if (imageAttrs.Border?.GetValue(State) != null)
                {
                    image.Border = imageAttrs.Border.GetValue(State);
                }
      
            }

            TextLabel text = view as TextLabel;
            TextAttributes textAttrs = attrs as TextAttributes;
            if (text != null && textAttrs != null)
            {
                if (textAttrs.Text?.GetValue(State) != null )
                {
                    text.Text = textAttrs.Text.GetValue(State);
                }
                if (textAttrs.TranslatableText?.GetValue(State) != null)
                {
                    text.TranslatableText = textAttrs.TranslatableText.GetValue(State);
                }
                if (textAttrs.MultiLine?.GetValue(State) != null)
                {
                    text.MultiLine = textAttrs.MultiLine.GetValue(State).Value;
                }
                if (textAttrs.HorizontalAlignment?.GetValue(State) != null)
                {
                    text.HorizontalAlignment = textAttrs.HorizontalAlignment.GetValue(State).Value;
                }
                if (textAttrs.VerticalAlignment?.GetValue(State) != null)
                {
                    text.VerticalAlignment = textAttrs.VerticalAlignment.GetValue(State).Value;
                }
                if (textAttrs.EnableMarkup?.GetValue(State) != null)
                {
                    text.EnableMarkup = textAttrs.EnableMarkup.GetValue(State).Value;
                }
                if (textAttrs.AutoScrollLoopCount?.GetValue(State) != null)
                {
                    text.AutoScrollLoopCount = textAttrs.AutoScrollLoopCount.GetValue(State).Value;
                }
                if (textAttrs.AutoScrollSpeed?.GetValue(State) != null)
                {
                    text.AutoScrollSpeed = textAttrs.AutoScrollSpeed.GetValue(State).Value;
                }
                if (textAttrs.AutoScrollGap != null)
                {
                    text.AutoScrollGap = textAttrs.AutoScrollGap.GetValue(State).Value;
                }
                if (textAttrs.AutoScrollLoopDelay?.GetValue(State) != null)
                {
                    text.AutoScrollLoopDelay = textAttrs.AutoScrollLoopDelay.GetValue(State).Value;
                }
                if (textAttrs.AutoScrollStopMode?.GetValue(State) != null)
                {
                    text.AutoScrollStopMode = textAttrs.AutoScrollStopMode.GetValue(State).Value;
                }
                if (textAttrs.LineSpacing?.GetValue(State) != null)
                {
                    text.LineSpacing = textAttrs.LineSpacing.GetValue(State).Value;
                }
                if (textAttrs.TextColor?.GetValue(State) != null)
                {
                    text.TextColor = textAttrs.TextColor.GetValue(State);
                }
                if (textAttrs.FontFamily?.GetValue(State) != null)
                {
                    text.FontFamily = textAttrs.FontFamily.GetValue(State);
                }
                if (textAttrs.PointSize?.GetValue(State) != null)
                {
                    text.PointSize = textAttrs.PointSize.GetValue(State).Value;
                }

                int thickness = 0;

                if (textAttrs.OutstrokeThickness?.GetValue(State) != null)
                {
                    thickness = textAttrs.OutstrokeThickness.GetValue(State).Value;
                }
                if (textAttrs.OutstrokeColor?.GetValue(State) != null)
                {
                    Color outstrokeColor = textAttrs.OutstrokeColor.GetValue(State);
                    PropertyMap outlineMap = new PropertyMap();
                    outlineMap.Add("color", new PropertyValue(new Color(outstrokeColor.R, outstrokeColor.G, outstrokeColor.B, outstrokeColor.R)));
                    outlineMap.Add("width", new PropertyValue(thickness));
                    text.Outline = outlineMap;
                }
                else
                {
                    text.Outline = new PropertyMap();
                }
            }

            TextField textField = view as TextField;
            TextFieldAttributes textFieldAttrs = attrs as TextFieldAttributes;
            if (textField != null && textFieldAttrs != null)
            {
                if (textFieldAttrs.Text?.GetValue(State) != null)
                {
                    textField.Text = textFieldAttrs.Text.GetValue(State);
                }
                if (textFieldAttrs.PlaceholderText?.GetValue(State) != null)
                {
                    textField.PlaceholderText = textFieldAttrs.PlaceholderText.GetValue(State);
                }
                if (textFieldAttrs.TranslatablePlaceholderText?.GetValue(State) != null)
                {
                    textField.TranslatablePlaceholderText = textFieldAttrs.TranslatablePlaceholderText.GetValue(State);
                }
                if (textFieldAttrs.HorizontalAlignment?.GetValue(State) != null)
                {
                    textField.HorizontalAlignment = textFieldAttrs.HorizontalAlignment.GetValue(State).Value;
                }
                if (textFieldAttrs.VerticalAlignment?.GetValue(State) != null)
                {
                    textField.VerticalAlignment = textFieldAttrs.VerticalAlignment.GetValue(State).Value;
                }
                if (textFieldAttrs.EnableMarkup?.GetValue(State) != null)
                {
                    textField.EnableMarkup = textFieldAttrs.EnableMarkup.GetValue(State).Value;
                }
                if (textFieldAttrs.TextColor?.GetValue(State) != null)
                {
                    textField.TextColor = textFieldAttrs.TextColor.GetValue(State);
                }
                if (textFieldAttrs.PlaceholderTextColor?.GetValue(State) != null)
                {
                    textField.TextColor = textFieldAttrs.PlaceholderTextColor.GetValue(State);
                }
                if (textFieldAttrs.PrimaryCursorColor?.GetValue(State) != null)
                {
                    textField.PrimaryCursorColor = textFieldAttrs.PrimaryCursorColor.GetValue(State);
                }
                if (textFieldAttrs.SecondaryCursorColor?.GetValue(State) != null)
                {
                    textField.SecondaryCursorColor = textFieldAttrs.SecondaryCursorColor.GetValue(State);
                }
                if (textFieldAttrs.FontFamily?.GetValue(State) != null)
                {
                    textField.FontFamily = textFieldAttrs.FontFamily.GetValue(State);
                }
                if (textFieldAttrs.PointSize?.GetValue(State) != null)
                {
                    textField.PointSize = textFieldAttrs.PointSize.GetValue(State).Value;
                }
                if (textFieldAttrs.EnableCursorBlink?.GetValue(State) != null)
                {
                    textField.EnableCursorBlink = textFieldAttrs.EnableCursorBlink.GetValue(State).Value;
                }
                if (textFieldAttrs.EnableSelection?.GetValue(State) != null)
                {
                    textField.EnableSelection = textFieldAttrs.EnableSelection.GetValue(State).Value;
                }
                if (textFieldAttrs.CursorWidth?.GetValue(State) != null)
                {
                    textField.CursorWidth = textFieldAttrs.CursorWidth.GetValue(State).Value;
                }
                if (textFieldAttrs.EnableEllipsis?.GetValue(State) != null)
                {
                    textField.Ellipsis = textFieldAttrs.EnableEllipsis.GetValue(State).Value;
                }
            }
        }

        //protected void ApplyAttributes(VisualMap visual, ViewAttributes attrs)
        //{
        //    if (visual == null || attrs == null)
        //    {
        //        return;
        //    }

        //    if (attrs.Position2D?.GetValue(State) != null)
        //    {
        //        visual.PositionPolicy = VisualTransformPolicyType.Absolute;
        //        visual.Position = attrs.Position2D.GetValue(State);
        //    }

        //    if (attrs.Size2D?.GetValue(State) != null)
        //    {
        //        visual.SizePolicy = VisualTransformPolicyType.Absolute;
        //        visual.Size = attrs.Size2D.GetValue(State);
        //    }
    
        //    if (attrs.ParentOrigin?.GetValue(State) != null)
        //    {
        //        switch(attrs.ParentOrigin.GetValue(State))
        //        {
        //            case ParentOrigin.TopLeft:
        //                visual.Origin = Visual.AlignType.TopBegin;
        //                break;
        //        }
        //    }
        //    if (attrs.PivotPoint?.GetValue(State) != null)
        //    {
        //        switch (attrs.PivotPoint.GetValue(State))
        //        {
        //            case NUI.PivotPoint.TopLeft:
        //                visual.AnchorPoint = Visual.AlignType.TopBegin;
        //                break;
        //        }
        //    }

        //    if (attrs.WidthResizePolicy?.GetValue(State) != null)
        //    {
        //        view.WidthResizePolicy = attrs.WidthResizePolicy.GetValue(State).Value;
        //    }
        //    if (attrs.HeightResizePolicy?.GetValue(State) != null)
        //    {
        //        view.HeightResizePolicy = attrs.HeightResizePolicy.GetValue(State).Value;
        //    }
        //    if (attrs.SizeModeFactor?.GetValue(State) != null)
        //    {
        //        view.SizeModeFactor = attrs.SizeModeFactor.GetValue(State);
        //    }
        //    if (attrs.Opacity?.GetValue(State) != null)
        //    {
        //        view.Opacity = attrs.Opacity.GetValue(State).Value;
        //    }

        //    ImageView image = view as ImageView;
        //    ImageAttributes imageAttrs = attrs as ImageAttributes;
        //    if (image != null && imageAttrs != null)
        //    {
        //        if (imageAttrs.ResourceURL?.GetValue(State) != null)
        //        {
        //            image.ResourceUrl = imageAttrs.ResourceURL.GetValue(State);
        //        }
        //        if (imageAttrs.Border?.GetValue(State) != null)
        //        {
        //            image.Border = imageAttrs.Border.GetValue(State);
        //        }

        //    }
        //}

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
                tapGestureDetector.Detach(this);
            }
            base.Dispose(type);
        }

        protected Attributes attributes;
        protected abstract Attributes GetAttributes();

        protected virtual bool OnKey(object source, KeyEventArgs e)
        {
            return false;
        }
        protected virtual void OnRelayout(object sender, EventArgs e)
        {
            OnUpdate(attributes);
        }
        protected virtual void OnFocusGained(object sender, EventArgs e)
        {
            isFocused = true;
        }
        protected virtual void OnFocusLost(object sender, EventArgs e)
        {
            isFocused = false;
        }
        protected virtual void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
        }
        protected virtual bool OnTouch(object source, TouchEventArgs e)
        {
            return false;
        }

        protected virtual void OnUpdate(Attributes attributtes)
        {
        }

        private void Initialize(string style)
        {
            IsCreateByXaml = true;
            attributes = (style == null) ? GetAttributes() : GetAttributes(style);
            State = States.Normal;

            KeyEvent += OnKey;
            Relayout += OnRelayout;
            FocusGained += OnFocusGained;
            FocusLost += OnFocusLost;

            LeaveRequired = true;
            TouchEvent += OnTouch;

            StateFocusableOnTouchMode = false;

            tapGestureDetector.Attach(this);
            tapGestureDetector.Detected += OnTapGestureDetected;
        }

        private Attributes GetAttributes(string style)
        {
            return Attributes.GetAttributes(styleToAttributes[style]);
        }
        private static Dictionary<string, Type> styleToAttributes = new Dictionary<string, Type>();

        private TapGestureDetector tapGestureDetector = new TapGestureDetector();
    }
}
