﻿using Tizen.NUI.Components;
using Tizen.NUI;

namespace Tizen.FH.NUI.Controls
{
    internal class BasicLongToastStyle : StyleBase
    {
        protected internal override Attributes GetAttributes()
        {
            ToastAttributes attributes = new ToastAttributes
            {
                Size = new Tizen.NUI.Size(1000, 132),
               
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector
                    {
                        All = CommonResource.Instance.GetFHResourcePath() + "12. Toast Popup/toast_background.png",
                    },
                    Border = new RectangleSelector
                    {
                        All = new Tizen.NUI.Rectangle(64, 64, 4, 4)
                    }
                },

                TextAttributes = new TextAttributes
                {
                    PaddingTop = 38,
                    PaddingBottom = 38,
                    PaddingLeft = 204,
                    PaddingRight = 96,
                    PointSize = new FloatSelector { All = 26, },
                    TextColor = new ColorSelector { All = Color.White },
                }
            };
            return attributes;
        }
    }
}
