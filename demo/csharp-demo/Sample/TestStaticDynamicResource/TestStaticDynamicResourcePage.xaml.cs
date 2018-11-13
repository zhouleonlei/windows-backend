/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.Windows;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace Tizen.NUI.Examples
{
    public class TestIcon : UIElement
    {

    }

    public class TestStaticDynamicResourcePage : ContentPage
    {

        public TestStaticDynamicResourcePage(Window win) : base (win)
        {
            //Content.BackgroundImage = "E:/Dali/dali-windows-backend/csharp-demo/res/images/ambient/photoduo_img_bg_01_no9patch.png";
            ClearEvent += OnClearEvent;
        }

        /// <summary>
        /// To make the ContentPage instance be disposed.
        /// </summary>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
            }

            ClearEvent -= OnClearEvent;

            base.Dispose(type);
        }
        
        public new void SetFocus()
        {
            base.SetFocus();
        }

        private void OnClearEvent(object obj, EventArgs e)
        {
            Content.BackgroundImage = "E:/Dali/dali-windows-backend/csharp-demo/res/images/ambient/photoduo_img_bg_01_no9patch.png";
        }
    }
}