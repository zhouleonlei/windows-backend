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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;

namespace Tizen.NUI.Examples
{
    public class StaticDateTimePage : ContentPage
    {
        private Slider _slider = null;
        public StaticDateTimePage(Window win) : base (win)
        {
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

            // FocusManager.Instance.PreFocusChange -= OnPreFocusChange;

            base.Dispose(type);
        }

        public override void SetFocus()
        {
            // _slider = Content.FindChildByName("slider") as Slider;
        }

        private bool OnClicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = sender as Button;
                float temp = _slider.Value + 10f;
                _slider.Value =  temp > _slider.UpperBound ? temp -_slider.UpperBound : temp ;
            }
            return true;
        }

        private void OnFocusGained(object obj, EventArgs e)
        {
            View view = obj as View;
            view.Scale = new Vector3(1.2f, 1.1f, 1.0f);
            Console.WriteLine("==================  button focus gained !!!! ==================");
        }

        private void OnFocusLost(object obj, EventArgs e)
        {
            View view = obj as View;
            view.Scale = new Vector3(1.0f, 1.0f, 1.0f);
            Console.WriteLine("==================  button focus lost !!!! ==================");
        }

    }
}