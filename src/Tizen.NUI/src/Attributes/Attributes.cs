using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Controls
{
    public class Attributes : Element
    {
        public static readonly BindableProperty StyleProperty = BindableProperty.Create("Style", typeof(Style), typeof(Attributes), default(Style), propertyChanged: (bindable, oldvalue, newvalue) =>
        {
             ((Attributes)bindable)._mergedStyle.Style = (Style)newvalue;
         });

        internal readonly MergedStyle _mergedStyle;

        public Attributes()
        {
            _mergedStyle = new MergedStyle(GetType(), this);
        }

        internal Style Style
        {
            get
            {
                return (Style)GetValue(StyleProperty);
            }
            set
            {
                SetValue(StyleProperty, value);
            }
        }

        public static Attributes GetAttributes(Type type)
        {
            AttributesContainer container = type.Assembly.CreateInstance(type.FullName) as AttributesContainer;

            if (container == null)
            {
                throw new Exception("xaml parse failed");
            }

            return container.GetAttributes().Clone();
        }

        public virtual Attributes Clone()
        {
            return new Attributes();
        }

    }
}
