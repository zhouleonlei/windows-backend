using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Controls
{
    internal class BackNavigationStyle : StyleBase
    {
        protected internal override Attributes GetAttributes()
        {
            NavigationAttributes attributes = new NavigationAttributes
            {
                IsFitWithItems = true,
            };

            return attributes;
        }
    }
}
