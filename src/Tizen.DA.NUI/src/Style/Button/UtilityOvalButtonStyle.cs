using Tizen.NUI.CommonUI;
[assembly: Tizen.NUI.Xaml.XamlResourceId("Tizen.FH.NUI.res.Button.UtilityOvalButtonStyle.xaml", "UtilityOvalButtonStyle.xaml", typeof(Tizen.FH.NUI.Controls.UtilityOvalButtonStyle))]
namespace Tizen.FH.NUI.Controls
{
    internal class UtilityOvalButtonStyle : IconButtonStyle
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
