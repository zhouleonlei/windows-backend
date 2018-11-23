using System;
using Tizen.NUI;
using Tizen.NUI.Controls;
using Tizen.NUI.Renderers;
using Tizen.DA.NUI.Renderers;

namespace Tizen.DA.NUI.Controls
{
    /// <summary>
    /// The class of the Slider component.
    /// </summary>
    public class Slider : Tizen.NUI.Controls.Slider
    {
        static Slider()
        {
            RegisterStyle("Default", typeof(SliderDefaultRenderer));
            RegisterStyle("1Text", typeof(Slider1TextRenderer));
            RegisterStyle("2Text", typeof(Slider2TextRenderer));
        }
        /// <summary>
        /// The constructor.
        /// </summary>
        public Slider() : base()
        {
        }

        public Slider(string style) : base(style)
        {
        }

        public string SubText
        {
            get
            {
                return subText;
            }
            set
            {
                if (value != null)
                {
                    subText = value;
                    UpdateSubText();
                }
            }
        }

        public string LeftSubText
        {
            get
            {
                return leftSubText;
            }
            set
            {
                if (value != null)
                {
                    leftSubText = value;
                    UpdateLeftSubText();
                }
            }
        }

        public string RightSubText
        {
            get
            {
                return rightSubText;
            }
            set
            {
                if (value != null)
                {
                    rightSubText = value;
                    UpdateRightSubText();
                }
            }
        }

        protected override void OnFocusGained(object sender, EventArgs e)
        {
            State = States.Focused;
            base.OnFocusGained(sender, e);
        }

        protected override void OnFocusLost(object sender, EventArgs e)
        {
            State = States.Normal;
            base.OnFocusLost(sender, e);
        }

        private void UpdateSubText()
        {
            renderer.OnPropertyChanged(Slider1TextRenderer.SubTextChanged, this);
        }

        private void UpdateLeftSubText()
        {
            renderer.OnPropertyChanged(Slider2TextRenderer.LeftSubTextChanged, this);
        }

        private void UpdateRightSubText()
        {
            renderer.OnPropertyChanged(Slider2TextRenderer.RightSubTextChanged, this);
        }

        private string subText = string.Empty;
        private string leftSubText = string.Empty;
        private string rightSubText = string.Empty;
    }
}
