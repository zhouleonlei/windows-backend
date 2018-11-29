using System;
using System.Collections.Generic;

namespace Tizen.NUI.Controls
{

    /// <summary>
    /// The CheckboxGroup class is used to group together a set of CheckBox control
    /// </summary>
    /// <code>
    /// CheckBoxGroup checkGroup = new CheckBoxGroup();
    /// CheckBox check1 = new CheckBox();
    /// CheckBox check2 = new CheckBox();
    /// checkGroup.Add(check1);
    /// checkGroup.Add(check2);
    /// </code>
    public class CheckBoxGroup : SelectionGroup
    {
        /// <summary>
        /// Construct CheckBoxGroup
        /// </summary>
        public CheckBoxGroup()
        {

        }

        /// <summary>
        /// Add CheckBox to the end of CheckBoxGroup.
        /// </summary>
        /// <param name="check">The CheckBox to be added to the CheckBoxGroup</param>
        public void Add(CheckBox check)
        {
            base.AddSelection(check);
            check.ItemGroup = this;
        }

        /// <summary>
        /// Remove CheckBox from the CheckBoxGroup.
        /// </summary>
        /// <param name="check">The CheckBox to remove from the CheckBoxGroup</param>
        public void Remove(CheckBox check)
        {
            base.RemoveSelection(check);
            check.ItemGroup = null;
        }

        /// <summary>
        /// Get the CheckBox object at the specified index.
        /// </summary>
        /// <param name="index">The item index</param>
        /// <returns>CheckBox</returns>
        public CheckBox GetItemByIndex(int index)
        {
            return itemGroup[index] as CheckBox;
        }

        /// <summary>
        /// Get the index array of checked items.
        /// </summary>
        /// <returns>The array of index</returns>
        public int[] GetCheckedIndexArray()
        {
            List<int> selectedItemsList = new List<int>();
            for (int i = 0; i < itemGroup.Count; i++)
            {
                if (itemGroup[i].CheckState)
                {
                    selectedItemsList.Add(i);
                }
            }

            return selectedItemsList.ToArray();
        }


        /// <summary>
        /// Get the CheckBox array of checked items.
        /// </summary>
        /// <returns>The array of CheckBox</returns>
        public CheckBox[] GetCheckedItemArray()
        {
            List<CheckBox> selectedList = new List<CheckBox>();

            foreach (CheckBox check in itemGroup)
            {
                if (check.CheckState)
                {
                    selectedList.Add(check);
                }
            }

            return selectedList.ToArray();
        }

        /// <summary>
        /// Determines whether every checkboxes in the CheckBoxGroup are checked
        /// </summary>
        /// <returns>If all of CheckBoxes are checked, return true. otherwise false</returns>
        public bool IsCheckedAll()
        {
            foreach (CheckBox cb in itemGroup)
            {
                if (!cb.CheckState)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check or Uncheck all of child checkboxes by the specified value
        /// </summary>
        /// <param name="state">The boolean state of the check box</param>
        public void CheckingAll(bool state)
        {
            foreach (CheckBox cb in itemGroup)
            {
                cb.CheckState = state;
            }
        }
    }

}
