
namespace Tizen.NUI.Controls
{
    public class CheckBox : SelectButton
    {
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
        /// 
        /// </summary>
        /// <param name="attrs"></param>
        public CheckBox(SelectButtonAttributes attrs) : base(attrs) { }

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
            //IsSelected = !IsSelected;
        }
    }
}
