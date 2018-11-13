using System;
using System.Collections.Generic;
using System.Reflection;

using Tizen.NUI.Xaml;

namespace Tizen.NUI.Binding
{
    [ContentProperty("Setters")]
    // [ProvideCompiled("Xamarin.Forms.Core.XamlC.PassthroughValueProvider")]
    [AcceptEmptyServiceProvider]
    internal sealed class Trigger : TriggerBase, IValueProvider
    {
        public Trigger([TypeConverter(typeof(TypeTypeConverter))] [Parameter("TargetType")] Type targetType) : base(new XamlPropertyCondition(), targetType)
        {
        }

        private string targetObjectName;
        public string TargetObjectName
        {
            get { return targetObjectName; }
            set
            {
                targetObjectName = value;
                targetObject = NameScopeExtensions.FindByNameInCurrentNameScope<BindableObject>(targetObjectName);

                if (null != targetObject && null != ((XamlPropertyCondition)Condition).Property && null != ((XamlPropertyCondition)Condition).Value)
                {
                    OnAttachedTo(targetObject);
                }
            }
        }

        public BindableProperty Property
        {
            get { return ((XamlPropertyCondition)Condition).Property; }
            set
            {
                if (((XamlPropertyCondition)Condition).Property == value)
                    return;
                if (IsSealed)
                    throw new InvalidOperationException("Can not change Property once the Trigger has been applied.");
                OnPropertyChanging();
                ((XamlPropertyCondition)Condition).Property = value;
                OnPropertyChanged();

                if (null != targetObject && null != ((XamlPropertyCondition)Condition).Property && null != ((XamlPropertyCondition)Condition).Value)
                {
                    OnAttachedTo(targetObject);
                }
            }
        }

        public new IList<Setter> Setters
        {
            get { return base.Setters; }
        }

        public object Value
        {
            get { return ((XamlPropertyCondition)Condition).Value; }
            set
            {
                if (((XamlPropertyCondition)Condition).Value == value)
                    return;
                if (IsSealed)
                    throw new InvalidOperationException("Can not change Value once the Trigger has been applied.");
                OnPropertyChanging();
                ((XamlPropertyCondition)Condition).Value = value;
                OnPropertyChanged();

                if (null != targetObject && null != ((XamlPropertyCondition)Condition).Property && null != ((XamlPropertyCondition)Condition).Value)
                {
                    OnAttachedTo(targetObject);
                }
            }
        }

        object IValueProvider.ProvideValue(IServiceProvider serviceProvider)
        {
            //This is no longer required
            return this;
        }
    }
}
