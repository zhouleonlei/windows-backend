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
    public class EventHandlerDemoPage : ContentPage
    {

        public EventHandlerDemoPage(Window win) : base(win)
        {
        }


        private bool OnClicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = sender as Button;
                button.LabelText = "Click Me";
            }
            return true;
        }

        private bool OnKeyEvent(object source, View.KeyEventArgs e)
        {
            Button button = source as Button;
            
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Right")
                {
                    button.LabelText = "Right";
                }
                else if(e.Key.KeyPressedName == "Left")
                {
                    button.LabelText = "Left";
                }
                else if(e.Key.KeyPressedName == "Up")
                {
                    button.LabelText = "Up";
                }
                else if(e.Key.KeyPressedName == "Down")
                {
                    button.LabelText = "Down";
                }
            }

            return false;
        }



        public new void SetFocus()
        {
            base.SetFocus();
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

            base.Dispose(type);
        }
    }
}