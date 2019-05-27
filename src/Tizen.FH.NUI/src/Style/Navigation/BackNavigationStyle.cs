using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class BackNavigationStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            NavigationAttributes attributes = new NavigationAttributes
            {
                IsFitWithItems = true,
            };

            return attributes;
        }
    }
}
