using Tizen.NUI.CommonUI;
using Tizen.NUI;

namespace Tizen.FH.NUI.Controls
{
    internal class UtilityProgressbarStyle : StyleBase
    {
        protected override Attributes GetAttributes()
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
                        All = Utility.Hex2Color(Constants.APP_COLOR_UTILITY, 1)
                    }
                },
            };
            return attributes;
        }
    }
}
