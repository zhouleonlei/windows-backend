﻿using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    internal class UtilityCheckBoxStyle : StyleBase
    {
        protected override Attributes GetAttributes()
        {
            SelectButtonAttributes attributes = new SelectButtonAttributes
            {
                IsSelectable = true,
                CheckBackgroundImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(48, 48),
                    Position2D = new Position2D(0, 0),
                    ResourceURL = new StringSelector
                    {
                        Normal = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                        Selected = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_check_on.png",
                        Disabled = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                        DisabledSelected = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_check_on.png",
                    },
                    Opacity = new FloatSelector
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                },
                CheckImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(48, 48),
                    Position2D = new Position2D(0, 0),
                    ResourceURL = new StringSelector
                    {
                        Normal = "",
                        Selected = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_check.png",
                        Disabled = "",
                        DisabledSelected = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_check.png",
                    },
                    Opacity = new FloatSelector
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                },
                CheckShadowImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(48, 48),
                    Position2D = new Position2D(0, 0),
                    ResourceURL = new StringSelector
                    {
                        Normal = "",
                        Selected = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_check_shadow.png",
                        Disabled = "",
                        DisabledSelected = CommonResource.Instance.GetFHResourcePath() + "9. Controller/controller_btn_check_shadow.png",
                    },
                    Opacity = new FloatSelector
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                },
            };

            return attributes;
        }
    }
}