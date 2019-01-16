using System;
using System.Collections.Generic;

namespace Tizen.NUI.Controls
{
    /// <summary>
    /// The RadioButtonGroup class is used to group together a set of RadioButton control
    /// It enables the user to select exclusively single radio button of group.
    /// </summary>
    /// <code>
    /// RadioButtonGroup radioGroup = new RadioButtonGroup();
    /// RadioButton radio1 = new RadioButton();
    /// RadioButton radio2 = new RadioButton();
    /// radioGroup.Add(radio1);
    /// radioGroup.Add(radio2);
    /// </code>
    public class RadioButtonGroup : SelectGroup
    {
        /// <summary>
        /// Construct RadioButtonGroup
        /// </summary>
        public RadioButtonGroup() : base()
        {

        }

        /// <summary>
        /// Get the RadioButton object at the specified index.
        /// </summary>
        /// <param name="index">item index</param>
        /// <returns>RadioButton</returns>
        public RadioButton GetItemByIndex(int index)
        {
            return itemGroup[index] as RadioButton;
        }

        /// <summary>
        /// Add RadioButton to the end of RadioButtonGroup.
        /// </summary>
        /// <param name="radio">The RadioButton to be added to the RadioButtonGroup</param>
        public void Add(RadioButton radio)
        {
            base.AddSelection(radio);
            radio.ItemGroup = this;
        }


        /// <summary>
        /// Remove RadioButton from the RadioButtonGroup.
        /// </summary>
        /// <param name="radio">The RadioButton to remove from the RadioButtonGroup</param>
        public void Remove(RadioButton radio)
        {
            base.RemoveSelection(radio);
            radio.ItemGroup = null;
        }

        /// <summary>
        /// Handle user's select action. Turn on check state of selected RadioButton,
        /// and turn out check state of other RadioButtons in RadioButtonGroup
        /// </summary>
        /// <param name="selection">The selection selected by user</param>
        protected override void SelectionHandler(SelectButton selection)
        {
            RadioButton radio = selection as RadioButton;
            if (!itemGroup.Contains(radio))
            {
                return;
            }

            foreach (RadioButton btn in itemGroup)
            {
                if (btn != radio)
                {
                    btn.IsSelected = false;
                }
            }
        }
    }
}
