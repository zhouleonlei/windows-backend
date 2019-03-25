using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.CommonUI
{
    [ContentProperty("Content")]
    public class AttributesContainer : Element, IResourcesProvider
    {
        public AttributesContainer()
        {
            IsCreateByXaml = true;
            //InitializeComponent();
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

        protected object Content
        {
            get;
            set;
        }

        protected internal virtual Attributes GetAttributes()
        {
            return Content as Attributes;
        }

        private void InitializeComponent()
        {
            Extensions.LoadFromXaml(this, GetType());
        }
    }
}

