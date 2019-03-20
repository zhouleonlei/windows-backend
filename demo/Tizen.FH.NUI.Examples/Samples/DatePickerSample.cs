using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;


namespace Tizen.FH.NUI.Samples
{
    public class DatePickerSample : IExample
    {
		private static string[] buttonStyles = new string[]
        {
            "UtilityPopupButton",
            "FamilyPopupButton",
            "FoodPopupButton",
            "KitchenPopupButton",
        };
		
        private View root;
		private Popup popup;
		private Picker datePicker;
        private int index = 0;
        public void Activate()
        {
            Window window = Window.Instance;
            
			root = new View()
			{
				Size2D = new Size2D(1920, 1080),
				BackgroundColor = Color.Cyan,
			};


			popup = new Popup("DAPopup");
            popup.ButtonStyle = buttonStyles[index];
            popup.Size2D = new Size2D(1032, 982);
            popup.TitleText = "Set Date";
            popup.ButtonCount = 2;
            popup.SetButtonText(0, "Yes");
            popup.SetButtonText(1, "Exit");
            popup.PopupButtonClickedEvent += PopupButtonClickedEvent;
			root.Add(popup);

			datePicker = new Picker("DAPicker");
			datePicker.Size2D = new Size2D(1032, 724);
			datePicker.Position2D = new Position2D(0, 0);
			datePicker.CurDate = new DateTime(2012, 12, 12);
			popup.ContentView.Add(datePicker);
			
			window.Add(root);
			Console.WriteLine("month" + DateTime.Now.ToString("MMMM", new CultureInfo("en-us")));
        }

		private void PopupButtonClickedEvent(object sender, Popup.ButtonClickEventArgs e)
        {
                     
        }
        public void Deactivate()
        {
			if (datePicker != null)
			{
				root.Remove(datePicker);
				datePicker.Dispose();
				datePicker = null;
			}

            if (root != null)
            {
                Window.Instance.Remove(root);
                root.Dispose();
				root = null;
            }
        }
    }
}
