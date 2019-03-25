using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Samples
{
    public class TimePickerSample : IExample
    {
        private static string[] buttonStyles = new string[]
        {
            "UtilityPopupButton",
            "FamilyPopupButton",
            "FoodPopupButton",
            "KitchenPopupButton",
        };

        private View[] root;
        private View FHView;
        private Popup popup;
        private TimePicker timePicker;
        
        private View FHViewAMPM;
        private Popup popupAMPM;
        private TimePicker timePickerAMPM;
        
        private View FHViewRepeat;
        private Popup popupRepeat;
        private TimePicker timePickerRepeat;
        private int index = 0;
        public void Activate()
        {
            Window window = Window.Instance;

            root = new View[3];

            FHView = new View()
            {
                Size2D = new Size2D(1920, 1080),
                BackgroundColor = Color.White,
            };
            root[0] = FHView;

            popup = new Popup("Popup");
            popup.Size2D = new Size2D(1032, 776);
            popup.TitleText = "Timer 01";
            popup.ButtonCount = 2;
            popup.SetButtonText(0, "Cancel");
            popup.SetButtonText(1, "OK");
            popup.PopupButtonClickedEvent += PopupButtonClickedEvent;
            FHView.Add(popup);
 
            timePicker = new TimePicker("DATimePicker");
            timePicker.Size2D = new Size2D(1032, 524);
            timePicker.Position2D = new Position2D(0, 0);
            popup.ContentView.Add(timePicker);
            window.Add(FHView);
            

            FHViewAMPM = new View()
            {
                Size2D = new Size2D(1920, 1080),
                BackgroundColor = Color.Cyan,
            };
            root[1] = FHViewAMPM;
            
            popupAMPM = new Popup("Popup");
            popupAMPM.Size2D = new Size2D(1032, 776);
            popupAMPM.TitleText = "Timer 02";
            popupAMPM.ButtonCount = 2;
            popupAMPM.SetButtonText(0, "Cancel");
            popupAMPM.SetButtonText(1, "OK");
            popupAMPM.PopupButtonClickedEvent += PopupButtonClickedEvent;
            FHViewAMPM.Add(popupAMPM);
 
            timePickerAMPM = new TimePicker("DATimePickerAMPM");
            timePickerAMPM.Size2D = new Size2D(1032, 524);
            timePickerAMPM.Position2D = new Position2D(0, 0);
            popupAMPM.ContentView.Add(timePickerAMPM);
            window.Add(FHViewAMPM);

            FHViewRepeat = new View()
            {
                Size2D = new Size2D(1920, 1080),
                BackgroundColor = Color.Cyan,
            };
            root[2] = FHViewRepeat;

            popupRepeat = new Popup("Popup");
            popupRepeat.Size2D = new Size2D(1032, 1064);
            popupRepeat.TitleText = "Time Setting";
            popupRepeat.ButtonCount = 2;
            popupRepeat.SetButtonText(0, "Cancel");
            popupRepeat.SetButtonText(1, "OK");
            popupRepeat.PopupButtonClickedEvent += PopupButtonClickedEvent;
            FHViewRepeat.Add(popupRepeat);
 
            timePickerRepeat = new TimePicker("DATimePickerRepeat");
            timePickerRepeat.Size2D = new Size2D(1032, 812);
            timePickerRepeat.Position2D = new Position2D(0, 0);
            popupRepeat.ContentView.Add(timePickerRepeat);
            window.Add(FHViewRepeat);
            
            index = 0;
            root[0].Show();
            root[1].Hide();
            root[2].Hide();
        }

        private void PopupButtonClickedEvent(object sender, Popup.ButtonClickEventArgs e)
        {
            if (e.ButtonIndex == 1)
            {
                root[index].Hide();
                index = (index+1)%3;
                root[index].Show();            
            }
        }
        public void Deactivate()
        {
            if (FHView != null)
            {
                if (timePicker != null)
                {
                    FHView.Remove(timePicker);
                    timePicker.Dispose();
                    timePicker = null;
                }
                Window.Instance.Remove(FHView);
                FHView.Dispose();
                FHView = null;
            }

            if (FHViewAMPM != null)
            {
                if (timePickerAMPM != null)
                {
                    FHViewAMPM.Remove(timePickerAMPM);
                    timePickerAMPM.Dispose();
                    timePickerAMPM = null;
                }
                Window.Instance.Remove(FHViewAMPM);
                FHViewAMPM.Dispose();
                FHViewAMPM = null;
            }

            if (FHViewRepeat != null)
            {
                if (timePickerRepeat != null)
                {
                    FHViewRepeat.Remove(timePickerRepeat);
                    timePickerRepeat.Dispose();
                    timePickerRepeat = null;
                }
                Window.Instance.Remove(FHViewRepeat);
                FHViewRepeat.Dispose();
                FHViewRepeat = null;
            }
        }
    }
}
