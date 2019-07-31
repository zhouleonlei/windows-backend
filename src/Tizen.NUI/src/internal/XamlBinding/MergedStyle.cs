using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tizen.NUI.StyleSheets;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Binding
{
    internal sealed class MergedStyle : IStyle
    {
        ////If the base type is one of these, stop registering dynamic resources further
        ////The last one (typeof(Element)) is a safety guard as we might be creating VisualElement directly in internal code
        static readonly IList<Type> s_stopAtTypes = new List<Type> { typeof(View), typeof(Element) };

        IList<BindableProperty> _classStyleProperties;

        readonly List<BindableProperty> _implicitStyles = new List<BindableProperty>();

        IList<Style> _classStyles;

        IStyle _implicitStyle;

        IStyle _style;

        IList<string> _styleClass;

        public MergedStyle(Type targetType, BindableObject target)
        {
            Target = new WeakReference(target);
            TargetType = targetType;
            RegisterImplicitStyles();
            Apply((Target.Target as BindableObject));
        }

        public IStyle Style
        {
            get { return _style; }
            set { SetStyle(ImplicitStyle, ClassStyles, value); }
        }

        public IList<string> StyleClass
        {
            get { return _styleClass; }
            set
            {
                if (_styleClass == value)
                    return;

                if (_styleClass != null && _classStyles != null)
                    foreach (var classStyleProperty in _classStyleProperties)
                        (Target.Target as BindableObject).RemoveDynamicResource(classStyleProperty);

                _styleClass = value;

                if (_styleClass != null) {
                    _classStyleProperties = new List<BindableProperty> ();
                    foreach (var styleClass in _styleClass) {
                        var classStyleProperty = BindableProperty.Create ("ClassStyle", typeof(IList<Style>), typeof(View), default(IList<Style>),
                            propertyChanged: (bindable, oldvalue, newvalue) => ((View)bindable)._mergedStyle.OnClassStyleChanged());
                        _classStyleProperties.Add (classStyleProperty);
                        (Target.Target as BindableObject).OnSetDynamicResource (classStyleProperty, Tizen.NUI.Binding.Style.StyleClassPrefix + styleClass);
                    }
                }
            }
        }

        public WeakReference Target { get; }

        IList<Style> ClassStyles
        {
            get { return _classStyles; }
            set { SetStyle(ImplicitStyle, value, Style); }
        }

        IStyle ImplicitStyle
        {
            get { return _implicitStyle; }
            set { SetStyle(value, ClassStyles, Style); }
        }

        public void Apply(BindableObject bindable)
        {
            ImplicitStyle?.Apply(bindable);
            if (ClassStyles != null)
                foreach (var classStyle in ClassStyles)
                    ((IStyle)classStyle)?.Apply(bindable);
            Style?.Apply(bindable);
        }

        public Type TargetType { get; }

        public void UnApply(BindableObject bindable)
        {
            Style?.UnApply(bindable);
            if (ClassStyles != null)
                foreach (var classStyle in ClassStyles)
                    ((IStyle)classStyle)?.UnApply(bindable);
            ImplicitStyle?.UnApply(bindable);
        }

        void OnClassStyleChanged()
        {
            ClassStyles = _classStyleProperties.Select (p => ((Target.Target as BindableObject).GetValue (p) as IList<Style>)?.FirstOrDefault (s => s.CanBeAppliedTo (TargetType))).ToList ();
        }

        void OnImplicitStyleChanged()
        {
            var first = true;
            foreach (BindableProperty implicitStyleProperty in _implicitStyles)
            {
                var implicitStyle = (Style)(Target.Target as BindableObject).GetValue(implicitStyleProperty);
                if (implicitStyle != null)
                {
                    if (first || implicitStyle.ApplyToDerivedTypes)
                    {
                        ImplicitStyle = implicitStyle;
                        return;
                    }
                }
                first = false;
            }
        }

        void RegisterImplicitStyles()
        {
            Type type = TargetType;
            while (true)
            {
                BindableProperty implicitStyleProperty = BindableProperty.Create("ImplicitStyle", typeof(Style), typeof(View), default(Style),
                        propertyChanged: (bindable, oldvalue, newvalue) => OnImplicitStyleChanged());
                _implicitStyles.Add(implicitStyleProperty);
                (Target.Target as BindableObject).SetDynamicResource(implicitStyleProperty, type.FullName);
                type = type.GetTypeInfo().BaseType;
                if (s_stopAtTypes.Contains(type))
                    return;
            }
        }

        void SetStyle(IStyle implicitStyle, IList<Style> classStyles, IStyle style)
        {
            bool shouldReApplyStyle = implicitStyle != ImplicitStyle || classStyles != ClassStyles || Style != style;
            bool shouldReApplyClassStyle = implicitStyle != ImplicitStyle || classStyles != ClassStyles;
            bool shouldReApplyImplicitStyle = implicitStyle != ImplicitStyle && (Style as Style == null || ((Style)Style).CanCascade);

            if (shouldReApplyStyle)
                Style?.UnApply((Target.Target as BindableObject));
            if (shouldReApplyClassStyle && ClassStyles != null)
                foreach (var classStyle in ClassStyles)
                    ((IStyle)classStyle)?.UnApply((Target.Target as BindableObject));
            if (shouldReApplyImplicitStyle)
                ImplicitStyle?.UnApply((Target.Target as BindableObject));

            _implicitStyle = implicitStyle;
            _classStyles = classStyles;
            _style = style;

            if (shouldReApplyImplicitStyle)
                ImplicitStyle?.Apply((Target.Target as BindableObject));
            if (shouldReApplyClassStyle && ClassStyles != null)
                foreach (var classStyle in ClassStyles)
                    ((IStyle)classStyle)?.Apply((Target.Target as BindableObject));
            if (shouldReApplyStyle)
                Style?.Apply((Target.Target as BindableObject));
        }
    }
}