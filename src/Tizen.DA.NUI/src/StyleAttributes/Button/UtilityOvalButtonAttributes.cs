using Tizen.NUI.CommonUI;
[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Button.UtilityOvalButtonAttributes.xaml", "UtilityOvalButtonAttributes.xaml", typeof(Tizen.FH.NUI.Controls.UtilityOvalButtonAttributes))]
namespace Tizen.FH.NUI.Controls
{
    internal class UtilityOvalButtonAttributes : IconButtonAttributes
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            return base.GetAttributes();
        }
    }
}
