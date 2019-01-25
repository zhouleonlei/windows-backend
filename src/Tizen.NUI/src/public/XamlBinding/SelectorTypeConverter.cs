using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

using Tizen.NUI;
using Tizen.NUI.Controls;

namespace Tizen.NUI.Binding
{
    [Xaml.ProvideCompiled("Xamarin.Forms.Xaml.Core.XamlC.StringSelectorConverter")]
    [Xaml.TypeConversion(typeof(StringSelector))]
    public class StringSelectorConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                value = value.Trim();
                StringSelector selector = new StringSelector();

                selector.All = value;
                return selector;
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(StringSelector)}");
        }
    }

    [Xaml.TypeConversion(typeof(IntSelector))]
    public class IntSelectorConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                value = value.Trim();
                IntSelector selector = new IntSelector();

                selector.All = Int32.Parse(value, CultureInfo.InvariantCulture);
                return selector;
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(IntSelector)}");
        }
    }

    [Xaml.TypeConversion(typeof(FloatSelector))]
    public class FloatSelectorConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                value = value.Trim();
                FloatSelector selector = new FloatSelector();

                selector.All = Single.Parse(value, CultureInfo.InvariantCulture);
                return selector;
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(FloatSelector)}");
        }
    }

    [Xaml.TypeConversion(typeof(BoolSelector))]
    public class BoolSelectorConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                value = value.Trim();
                BoolSelector selector = new BoolSelector();

                selector.All = (value == "true" || value == "True") ? true : false;
                return selector;
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(BoolSelector)}");
        }
    }

    [Xaml.TypeConversion(typeof(RectangleSelector))]
    public class RectangleSelectorConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                value = value.Trim();
                RectangleSelector selector = new RectangleSelector();

                double x, y, w, h;
                string[] xywh = value.Split(',');
                if (xywh.Length == 4 && double.TryParse(xywh[0], NumberStyles.Number, CultureInfo.InvariantCulture, out x) && double.TryParse(xywh[1], NumberStyles.Number, CultureInfo.InvariantCulture, out y) &&
                    double.TryParse(xywh[2], NumberStyles.Number, CultureInfo.InvariantCulture, out w) && double.TryParse(xywh[3], NumberStyles.Number, CultureInfo.InvariantCulture, out h))
                {
                    selector.All = new Rectangle((int)x, (int)y, (int)w, (int)h);
                }

                return selector;
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(RectangleSelector)}");
        }
    }

    [Xaml.TypeConversion(typeof(ColorSelector))]
    public class ColorSelectorConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                value = value.Trim();
                ColorSelector selector = new ColorSelector();
                value = value.Trim();
                if (value.StartsWith("#", StringComparison.Ordinal))
                {
                    selector.All = FromHex(value);
                }
                else
                {
                    string[] parts = value.Split(',');
                    if (parts.Length == 1) //like Red or Color.Red
                    {
                        parts = value.Split('.');
                        if (parts.Length == 1 || (parts.Length == 2 && parts[0] == "Color"))
                        {
                            string color = parts[parts.Length - 1];
                            switch (color)
                            {
                                case "Black":
                                    selector.All = Color.Black;
                                    break;
                                case "White":
                                    selector.All = Color.White;
                                    break;
                                case "Red":
                                    selector.All = Color.Red;
                                    break;
                                case "Green":
                                    selector.All = Color.Green;
                                    break;
                                case "Blue":
                                    selector.All = Color.Blue;
                                    break;
                                case "Yellow":
                                    selector.All = Color.Yellow;
                                    break;
                                case "Magenta":
                                    selector.All = Color.Magenta;
                                    break;
                                case "Cyan":
                                    selector.All = Color.Cyan;
                                    break;
                                case "Transparent":
                                    selector.All = Color.Transparent;
                                    break;
                            }
                        }
                    }
                    else if (parts.Length == 4) //like 0.5,0.5,0.5,0.5
                    {
                        selector.All = new Color(float.Parse(parts[0].Trim()), float.Parse(parts[1].Trim()), float.Parse(parts[2].Trim()), float.Parse(parts[3].Trim()));
                    }
                }

                return selector;
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(ColorSelector)}");
        }
        static uint ToHex(char c)
        {
            ushort x = (ushort)c;
            if (x >= '0' && x <= '9')
                return (uint)(x - '0');

            x |= 0x20;
            if (x >= 'a' && x <= 'f')
                return (uint)(x - 'a' + 10);
            return 0;
        }

        static uint ToHexD(char c)
        {
            var j = ToHex(c);
            return (j << 4) | j;
        }

        public static Color FromRgba(int r, int g, int b, int a)
        {
            float red = (float)r / 255;
            float green = (float)g / 255;
            float blue = (float)b / 255;
            float alpha = (float)a / 255;
            return new Color(red, green, blue, alpha);
        }

        public static Color FromRgb(int r, int g, int b)
        {
            return FromRgba(r, g, b, 255);
        }

        static Color FromHex(string hex)
        {
            // Undefined
            if (hex.Length < 3)
                return Color.Black;
            int idx = (hex[0] == '#') ? 1 : 0;

            switch (hex.Length - idx)
            {
                case 3: //#rgb => ffrrggbb
                    var t1 = ToHexD(hex[idx++]);
                    var t2 = ToHexD(hex[idx++]);
                    var t3 = ToHexD(hex[idx]);

                    return FromRgb((int)t1, (int)t2, (int)t3);

                case 4: //#argb => aarrggbb
                    var f1 = ToHexD(hex[idx++]);
                    var f2 = ToHexD(hex[idx++]);
                    var f3 = ToHexD(hex[idx++]);
                    var f4 = ToHexD(hex[idx]);
                    return FromRgba((int)f2, (int)f3, (int)f4, (int)f1);

                case 6: //#rrggbb => ffrrggbb
                    return FromRgb((int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                            (int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                            (int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx])));

                case 8: //#aarrggbb
                    var a1 = ToHex(hex[idx++]) << 4 | ToHex(hex[idx++]);
                    return FromRgba((int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                            (int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                            (int)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx])),
                            (int)a1);

                default: //everything else will result in unexpected results
                    return Color.Black;
            }
        }
    }

    [Xaml.TypeConversion(typeof(Size2DSelector))]
    public class Size2DSelectorConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                Size2DSelector selector = new Size2DSelector();
                string[] parts = value.Split(',');
                if (parts.Length == 2)
                {
                    selector.All = new Size2D(Int32.Parse(parts[0].Trim(), CultureInfo.InvariantCulture),
                                    Int32.Parse(parts[1].Trim(), CultureInfo.InvariantCulture));
                    return selector;
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Size2DSelector)}");
        }
    }

    [Xaml.TypeConversion(typeof(Position2DSelector))]
    public class Position2DSelectorConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                Position2DSelector selector = new Position2DSelector();
                selector.All = Position2D.ConvertFromString(value);
                return selector;
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Position2DSelector)}");
        }
    }

    [Xaml.TypeConversion(typeof(PositionSelector))]
    public class PositionSelectorConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                PositionSelector selector = new PositionSelector();
                string[] parts = value.Split('.');
                if (parts.Length == 1 || (parts.Length == 2 && (parts[0].Trim() == "ParentOrigin" || parts[0].Trim() == "PivotPoint")))
                {
                    string position = parts[parts.Length - 1].Trim();

                    switch (position)
                    {
                        case "TopLeft":
                            selector.All = ParentOrigin.TopLeft;
                            break;
                        case "TopCenter":
                            selector.All = ParentOrigin.TopCenter;
                            break;
                        case "TopRight":
                            selector.All = ParentOrigin.TopRight;
                            break;
                        case "CenterLeft":
                            selector.All = ParentOrigin.CenterLeft;
                            break;
                        case "Center":
                            selector.All = ParentOrigin.Center;
                            break;
                        case "CenterRight":
                            selector.All = ParentOrigin.CenterRight;
                            break;
                        case "BottomLeft":
                            selector.All = ParentOrigin.BottomLeft;
                            break;
                        case "BottomCenter":
                            selector.All = ParentOrigin.BottomCenter;
                            break;
                        case "BottomRight":
                            selector.All = ParentOrigin.BottomRight;
                            break;
                    }
                }

                parts = value.Split(',');
                if (parts.Length == 3)
                {
                    selector.All = new Position(Single.Parse(parts[0].Trim(), CultureInfo.InvariantCulture),
                                    Single.Parse(parts[1].Trim(), CultureInfo.InvariantCulture),
                                    Single.Parse(parts[2].Trim(), CultureInfo.InvariantCulture));
                }
                return selector;
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(PositionSelector)}");
        }
    }
    [Xaml.TypeConversion(typeof(Vector2Selector))]
    public class Vector2SelectorConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                Vector2Selector selector = new Vector2Selector();
                string[] parts = value.Split(',');
                if (parts.Length == 2)
                {
                    selector.All = new Vector2(Single.Parse(parts[0].Trim(), CultureInfo.InvariantCulture),
                                       Single.Parse(parts[1].Trim(), CultureInfo.InvariantCulture));
                    return selector.All;
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Vector2Selector)}");
        }
    }

    [Xaml.TypeConversion(typeof(Vector3Selector))]
    public class Vector3SelectorConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                Vector3Selector selector = new Vector3Selector();
                string[] parts = value.Split(',');
                if (parts.Length == 3)
                {
                    selector.All = new Vector3(Single.Parse(parts[0].Trim(), CultureInfo.InvariantCulture),
                                       Single.Parse(parts[1].Trim(), CultureInfo.InvariantCulture),
                                       Single.Parse(parts[2].Trim(), CultureInfo.InvariantCulture));
                    return selector.All;
                }
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Vector3Selector)}");
        }
    }

    [Xaml.TypeConversion(typeof(HorizontalAlignmentSelector))]
    public class HorizontalAlignmentSelectorConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                HorizontalAlignmentSelector selector = new HorizontalAlignmentSelector();
                value = value.Trim();
                switch (value)
                {
                    case "Begin":
                        selector.All = HorizontalAlignment.Begin;
                        break;
                    case "Center":
                        selector.All = HorizontalAlignment.Center;
                        break;
                    case "End":
                        selector.All = HorizontalAlignment.End;
                        break;
                }
                return selector;
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(HorizontalAlignmentSelector)}");
        }
    }
    [Xaml.TypeConversion(typeof(VerticalAlignmentSelector))]
    public class VerticalAlignmentSelectorConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                VerticalAlignmentSelector selector = new VerticalAlignmentSelector();
                value = value.Trim();
                switch (value)
                {
                    case "Begin":
                        selector.All = VerticalAlignment.Top;
                        break;
                    case "Center":
                        selector.All = VerticalAlignment.Center;
                        break;
                    case "End":
                        selector.All = VerticalAlignment.Bottom;
                        break;
                }
                return selector;
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(VerticalAlignmentSelector)}");
        }
    }

    [Xaml.TypeConversion(typeof(AutoScrollStopModeSelector))]
    public class AutoScrollStopModeSelectorConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                AutoScrollStopModeSelector selector = new AutoScrollStopModeSelector();
                value = value.Trim();
                switch (value)
                {
                    case "FinishLoop":
                        selector.All = AutoScrollStopMode.FinishLoop;
                        break;
                    case "Immediate":
                        selector.All = AutoScrollStopMode.Immediate;
                        break;
                }
                return selector;
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(AutoScrollStopModeSelector)}");
        }
    }

    [Xaml.TypeConversion(typeof(ResizePolicyTypeSelector))]
    public class ResizePolicyTypeSelectorConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value != null)
            {
                ResizePolicyTypeSelector selector = new ResizePolicyTypeSelector();
                value = value.Trim();
                switch (value)
                {
                    case "Fixed":
                        selector.All = ResizePolicyType.Fixed;
                        break;
                    case "UseNaturalSize":
                        selector.All = ResizePolicyType.UseNaturalSize;
                        break;
                    case "FillToParent":
                        selector.All = ResizePolicyType.FillToParent;
                        break;
                    case "SizeRelativeToParent":
                        selector.All = ResizePolicyType.SizeRelativeToParent;
                        break;
                    case "SizeFixedOffsetFromParent":
                        selector.All = ResizePolicyType.SizeFixedOffsetFromParent;
                        break;
                    case "FitToChildren":
                        selector.All = ResizePolicyType.FitToChildren;
                        break;
                    case "DimensionDependency":
                        selector.All = ResizePolicyType.DimensionDependency;
                        break;
                    case "UseAssignedSize":
                        selector.All = ResizePolicyType.UseAssignedSize;
                        break;
                }
                return selector;
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(ResizePolicyTypeSelector)}");
        }
    }
}
