using Tizen.NUI;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Controls
{
    internal class DefaultSearchBarStyle : StyleBase
    {
        protected internal override Attributes GetAttributes()
        {
            if (Content != null)
            {
                return (Content as Attributes).Clone();
            }
            SearchBarAttributes attributes = new SearchBarAttributes
            {
                Space = 56,
                SearchBoxAttributes = new InputFieldAttributes(),
                ResultListAttributes = new ViewAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0.8f, 0.8f, 0.8f, 0.8f),
                    }
                },
            };

            return attributes;
        }
    }
}
