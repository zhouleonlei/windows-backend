using Tizen.NUI;

namespace Tizen.FH.NUI
{
    public class Utility
    {
        /// <summary>
        /// Transfer color value(#rgb) to Color.
        /// </summary>
        /// <param name="hex">rgb value</param>
        /// <param name="a">alpha value</param>
        /// <returns>Transfered color</returns>
        public static Color Hex2Color(int hex, float a)
        {
            float r = 0, g = 0, b = 0;
            b = (hex & 0xff) / 255.0f;
            g = (hex >> 8 & 0xff) / 255.0f;
            r = (hex >> 16 & 0xff) / 255.0f;

            return new Color(r, g, b, a);
        }
    }
}
