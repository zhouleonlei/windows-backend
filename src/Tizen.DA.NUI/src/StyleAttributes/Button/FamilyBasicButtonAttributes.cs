using Tizen.NUI.Xaml;

[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Button.FamilyBasicButtonAttributes.xaml", "FamilyBasicButtonAttributes.xaml", typeof(Tizen.FH.NUI.Controls.FamilyBasicButtonAttributesContainer))]
namespace Tizen.FH.NUI.Controls
{
    public partial class FamilyBasicButtonAttributesContainer : StyleContainer
    {
        static private StyleContainer instance = null;
        static internal StyleContainer Container
        {
            get
            {
                if (null == instance)
                {
                    instance = new FamilyBasicButtonAttributesContainer();
                }

                return instance;
            }
        }

        public FamilyBasicButtonAttributesContainer()
        {
            InitializeComponent();
        }
    }
}
