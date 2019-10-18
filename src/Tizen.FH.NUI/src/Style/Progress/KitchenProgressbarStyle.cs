using Tizen.NUI.Components;
using Tizen.NUI;

namespace Tizen.FH.NUI.Controls
{
    internal class KitchenProgressbarStyle : StyleBase
    {
        protected internal override Attributes GetAttributes()
        {
            ProgressAttributes attributes = new ProgressAttributes
            {
                TrackImageAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0.0f, 0.0f, 0.0f, 0.1f),
                    }
                },
                ProgressImageAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = Utility.Hex2Color(Constants.APP_COLOR_KITCHEN, 1)
                    }
                },
            };
            return attributes;
        }
    }
}
