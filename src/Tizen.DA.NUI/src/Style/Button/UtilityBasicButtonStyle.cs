using Tizen.NUI.CommonUI;
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
