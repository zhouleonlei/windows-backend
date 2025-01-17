﻿using Tizen.NUI;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Controls
{
    internal class BlackConditionNavigationStyle : StyleBase
    {
        protected internal override Attributes GetAttributes()
        {
            NavigationAttributes attributes = new NavigationAttributes
            {
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { All = CommonResource.Instance.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_bg_b.png" },
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 103, 103) },
                },
                Space = new Vector4(8, 0, 40, 40),
                ItemGap = 2,
                DividerLineColor = new Color(1, 1, 1, 0.1f),
                IsFitWithItems = true,
            };

            return attributes;
        }
    }
}
