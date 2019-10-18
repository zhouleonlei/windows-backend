using Tizen.NUI.Components;
namespace Tizen.FH.NUI.Controls
{
    internal class KitchenBasicButtonStyle : TextButtonStyle
    {
        protected internal override Attributes GetAttributes()
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
