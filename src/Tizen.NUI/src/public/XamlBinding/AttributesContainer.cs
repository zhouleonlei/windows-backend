using Tizen.NUI.Binding;
using Tizen.NUI.Controls;

namespace Tizen.NUI.Xaml
{
    [ContentProperty("Content")]
    public class AttributesContainer : Element, IResourcesProvider
    {
        public AttributesContainer()
        {
            IsCreateByXaml = true;
            InitializeComponent();
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

        public Attributes GetAttributes()
        {
            return Content as Attributes;
        }

        private void InitializeComponent()
        {
            Extensions.LoadFromXaml(this, GetType());
        }
    }
}

