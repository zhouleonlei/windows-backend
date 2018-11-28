using System;
using Tizen.NUI.Renderers;

namespace Tizen.NUI.Controls
{
    /// <summary>
    /// CheckBox is the Class that describe the control which can be checked or unchecked by user.
    /// It supports multiple choices.
    /// </summary>
    /// <code>
    /// CheckBox check = new CheckBox("C_Checkbox_WhiteText");
    /// check.Size = new Size(200, 64, 0);
    /// check.Position = new Position(500, posY, 0);
    /// check.Text = "CheckBox";
    /// check.Focusable = true;
    /// </code>
    public class CheckBox : Selection
    {
        static CheckBox()
        {
            RegisterStyle("CheckBox", typeof(SelectionRenderer));
        }

        /// <summary>
        /// 
        /// </summary>
        public CheckBox() : base() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="style"></param>
        public CheckBox(string style) : base(style) { }

        /// <summary>
        /// Get CheckBoxGroup to which this CheckBox belong.
        /// </summary>
        public CheckBoxGroup ItemGroup
        {
            get
            {
                return itemGroup as CheckBoxGroup;
            }
            internal set
            {
                itemGroup = value;
            }
        }

        /// <summary>
        /// Change CheckState to the inverse of its current state after selecting CheckBox.
        /// </summary>
        protected override void OnSelected()
        {
            CheckState = !CheckState;
        }

    }
}
