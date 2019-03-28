using Tizen.NUI.CommonUI;
namespace Tizen.FH.NUI.Controls
{
    internal class KitchenBasicButtonStyle : TextButtonStyle
    {
        protected override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            ButtonAttributes attributes = base.GetAttributes() as ButtonAttributes;
            attributes.TextAttributes.TextColor.Selected = Utility.Hex2Color(Constants.APP_COLOR_KITCHEN, 1);
            return attributes;
        }
    }
}
