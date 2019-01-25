using Tizen.NUI.Binding;

namespace Tizen.NUI.Xaml
{
    [ContentProperty("Content")]
    public class StyleContainer : Element, IResourcesProvider
    {
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(object), typeof(StyleContainer), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            // var self = (IControlTemplated)bindable;
            // var newElement = (Element)newValue;
            // if (self.ControlTemplate == null)
            // {
            //  while (self.InternalChildren.Count > 0)
            //  {
            //      self.InternalChildren.RemoveAt(self.InternalChildren.Count - 1);
            //  }

            // 	if (newValue != null)
            //      self.InternalChildren.Add(newElement);
            // }
            // else
            // {
            // 	if (newElement != null)
            // 	{
            //      BindableObject.SetInheritedBindingContext(newElement, bindable.BindingContext);
            // 	}
            // }
            var self = (StyleContainer)bindable;
            self.Content = newValue;
        });

        public StyleContainer()
        {
            IsCreateByXaml = true;
        }

        public bool IsResourcesCreated
        {
            get
            {
                return Application.Current.IsResourcesCreated;
            }
        }

        public ResourceDictionary XamlResources
        {
            get
            {
                return Application.Current.XamlResources;
            }
            set
            {
                Application.Current.XamlResources = value;
            }
        }

        public object Content
        {
            get;
            set;
        }
    }
}

