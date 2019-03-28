using Tizen.NUI.CommonUI;
using Tizen.NUI.Xaml;
namespace Tizen.FH.NUI.Controls
{
    internal class UtilityBasicButtonStyle : TextButtonStyle
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
