using System;
using System.Collections.Generic;

namespace Tizen.NUI.Controls
{

    /// <summary>
    /// SelectionGroup is the base class of CheckBoxGroup and RadioButtonGroup.
    /// It defines a group that is set of selections and enables the user to choose one or multiple selection.
    /// </summary>
    /// <code>
    /// Refer to CheckBoxGroup and RadioButtonGroup
    /// </code>
    public abstract class SelectionGroup
    {
        /// <summary>
        /// Selection group event arguments
        /// </summary>
        public class SelectionGroupEventArgs : EventArgs
        {
            /// <summary>The index of selected item</summary>
            public int SelectedIndex;
        }

        /// <summary>
        /// Get the number of items in the SelectionGroup.
        /// </summary>
        public int Count
        {
            get
            {
                return itemGroup.Count;
            }
        }

        /// <summary>
        /// Get the index of currently or latest selected item.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
        }

        /// <summary>
        /// Construct SelectionGroup
        /// </summary>
        protected SelectionGroup()
        {
            itemGroup = new List<Selection>();
        }

        /// <summary>
        /// Determine whether selection is in the SelectionGroup
        /// </summary>
        /// <param name="selection">selection in the SelectionGroup</param>
        /// <returns>true if selection is found in the SelectionGroup; otherwise, false.</returns>
        public bool Contains(Selection selection)
        {
            return itemGroup.Contains(selection);
        }

        /// <summary>
        /// Get the index of given selection.
        /// </summary>
        /// <param name="selection">selection in the SelectionGroup</param>
        /// <returns>The index of the selection in selection group if found; otherwise, return -1</returns>
        public int GetIndex(Selection selection)
        {
            return itemGroup.IndexOf(selection);
        }

        /// <summary>
        /// Event for state change signal which can be used to subscribe/unsubscribe the event handler provided by the user.
        /// </summary>
        public event EventHandler<SelectionGroupEventArgs> SelectionGroupEvent
        {
            add
            {
                selectionGroupHandlers += value;
            }
            remove
            {
                selectionGroupHandlers -= value;
            }
        }

        /// <summary>
        /// Adds an selection to the end of the SelectionGroup
        /// </summary>
        /// <param name="selection">The selection to be added to the end of the SelectionGroup</param>
        protected void AddSelection(Selection selection)
        {
            if (itemGroup.Contains(selection))
            {
                return;
            }
            itemGroup.Add(selection);
            selection.SelectEvent += OnSelectionEvent;
        }

        /// <summary>
        /// Removes an selection to the end of the SelectionGroup
        /// </summary>
        /// <param name="selection">The selection to remove from the SelectionGroup</param>
        protected void RemoveSelection(Selection selection)
        {
            if (!itemGroup.Contains(selection))
            {
                return;
            }
            selection.SelectEvent -= OnSelectionEvent;
            itemGroup.Remove(selection);
        }


        /// <summary>
        /// Overrides this method if want to handle behavior after pressing return key by user.
        /// </summary>
        /// <param name="selection">The selection selected by user</param>
        protected virtual void SelectionHandler(Selection selection)
        {

        }

        private void OnSelectionEvent(object sender, Selection.SelectEventArgs args)
        {
            Selection selection = sender as Selection;
            if (selection != null)
            {
                if (args.CheckState == true)
                {
                    selectedIndex = selection.Index;
                    SelectionHandler(selection);
                }
            }
        }

        /// <summary> Selection group composed of items </summary>
        protected List<Selection> itemGroup;
        /// <summary> Selected item index</summary>
        protected int selectedIndex;
        private EventHandler<SelectionGroupEventArgs> selectionGroupHandlers = null;
    }
}
