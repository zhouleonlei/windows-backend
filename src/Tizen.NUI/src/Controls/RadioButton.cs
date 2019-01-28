
namespace Tizen.NUI.Controls
{
    /// <summary>
    /// RadioButton is the Class that describe the control which can be checked, but not cleared by a user.
    /// </summary>
    /// <code>
    /// RadioButton radio = new RadioButton("C_RadioButton_WhiteText");
    /// radio.Size = new Size(200, 64, 0);
    /// radio.Position = new Position(500, posY, 0);
    /// radio.Text = "RadioButton";
    /// radio.Focusable = true;
    /// </code>
    public class RadioButton : SelectButton
    {
        /// <summary>
        /// 
        /// </summary>
        public RadioButton() : base() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="style"></param>
        public RadioButton(string style) : base(style) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attrs"></param>
        public RadioButton(SelectButtonAttributes attrs) : base(attrs) { }
        /// <summary>
        /// Get RadioButtonGroup to which this selections belong.
        /// </summary>
        public RadioButtonGroup ItemGroup
        {
            get
            {
                return itemGroup as RadioButtonGroup;
            }
            internal set
            {
                itemGroup = value;
            }
        }

        /// <summary>
        /// Set CheckState to true after selecting RadioButton.
        /// </summary>
        protected override void OnSelected()
        {
            if (!IsSelected)
            {
                IsSelected = true;
            }
        }
    }
}
