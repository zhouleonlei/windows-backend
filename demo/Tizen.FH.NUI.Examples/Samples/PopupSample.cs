﻿using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.NUI.Samples
{
    public class Popup : IExample
    {
        private SampleLayout root;
        private static readonly Size2D Padding = new Size2D(50, 50);

        private Tizen.NUI.Components.Popup popup = null;
        private TextLabel contentText = null;
        private Tizen.NUI.Components.Button[] button = new Tizen.NUI.Components.Button[3];
        private int num = 3;

        private static string[] mode = new string[]
        {
            "No Title",
            "No title with No button",
            "Title with button",
        };

        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.White;
            root = new SampleLayout();
            root.HeaderText = "Popup";

            CreateBasePopup();

            for (int i = 0; i < num; i++)
            {
                button[i] = new Tizen.NUI.Components.Button("ServiceButton");
                button[i].Size2D = new Size2D(240, 80);
                button[i].Position2D = new Position2D(160 + i * 260, 700);
                button[i].Text = mode[i];
                button[i].PointSize = 11;
                button[i].ClickEvent += ButtonClickEvent;
                root.Add(button[i]);
            }
        }

        private void CreateBasePopup()
        {
            DestoryPopup();

            popup = new Tizen.NUI.Components.Popup("Popup");
            popup.Size2D = new Size2D(1032, 500);
            popup.Position2D = new Position2D(24, 50);
            popup.TitleText = "Popup Title";
            popup.ButtonCount = 2;
            popup.SetButtonText(0, "Yes");
            popup.SetButtonText(1, "Exit");
            popup.PopupButtonClickEvent += PopupButtonClickedEvent;

            contentText = new TextLabel();
            contentText.Size2D = new Size2D(800, 200);
            contentText.PointSize = 20;
            contentText.Text = "Content area";
            contentText.HorizontalAlignment = HorizontalAlignment.Begin;
            contentText.VerticalAlignment = VerticalAlignment.Center;
            popup.ContentView.Add(contentText);
            popup.ContentView.BackgroundColor = new Color(0, 0, 0, 0.1f);
            root.Add(popup);
        }

        private void CreatePopupWithoutTitle()
        {
            DestoryPopup();

            popup = new Tizen.NUI.Components.Popup("Popup");
            popup.Size2D = new Size2D(1032, 500);
            popup.Position2D = new Position2D(24, 50);
            popup.ButtonCount = 2;
            popup.SetButtonText(0, "Yes");
            popup.SetButtonText(1, "Exit");
            popup.PopupButtonClickEvent += PopupButtonClickedEvent;

            contentText = new TextLabel();
            contentText.WidthResizePolicy = ResizePolicyType.FillToParent;
            contentText.HeightResizePolicy = ResizePolicyType.FillToParent;
            contentText.PointSize = 20;
            contentText.Text = "Content area in center";
            contentText.HorizontalAlignment = HorizontalAlignment.Center;
            contentText.VerticalAlignment = VerticalAlignment.Center;
            popup.ContentView.Add(contentText);
            popup.ContentView.BackgroundColor = new Color(0, 0, 0, 0.1f);
            root.Add(popup);
        }

        private void CreatePopupWithoutTitleAndButton()
        {
            DestoryPopup();

            popup = new Tizen.NUI.Components.Popup("Popup");
            popup.Size2D = new Size2D(1032, 200);
            popup.Position2D = new Position2D(24, 50);

            contentText = new TextLabel();
            contentText.WidthResizePolicy = ResizePolicyType.FillToParent;
            contentText.HeightResizePolicy = ResizePolicyType.FillToParent;
            contentText.PointSize = 20;
            contentText.Text = "Content area in center";
            contentText.HorizontalAlignment = HorizontalAlignment.Center;
            contentText.VerticalAlignment = VerticalAlignment.Center;
            popup.ContentView.Add(contentText);
            popup.ContentView.BackgroundColor = new Color(0, 0, 0, 0.1f);
            root.Add(popup);
        }

        private void PopupButtonClickedEvent(object sender, Tizen.NUI.Components.Popup.ButtonClickEventArgs e)
        {
            contentText.Text = "Button index " + e.ButtonIndex + " is clicked";
        }

        private void ButtonClickEvent(object sender, Tizen.NUI.Components.Button.ClickEventArgs e)
        {
            Tizen.NUI.Components.Button btn = sender as Tizen.NUI.Components.Button;
            if (button[0] == btn)
            {
                CreatePopupWithoutTitle();
            }
            else if (button[1] == btn)
            {
                CreatePopupWithoutTitleAndButton();
            }
            else if (button[2] == btn)
            {
                CreateBasePopup();
            }
        }

        private void DestoryPopup()
        {
            if (popup != null)
            {
                if (contentText != null)
                {
                    popup.ContentView.Remove(contentText);
                    contentText.Dispose();
                    contentText = null;
                }

                root.Remove(popup);
                popup.Dispose();
                popup = null;
            }
        }

        public void Deactivate()
        {
            if (root != null)
            {
                DestoryPopup();

                for (int i = 0; i < num; i++)
                {
                    if (button[i] != null)
                    {
                        root.Remove(button[i]);
                        button[i].Dispose();
                        button[i] = null;
                    }
                }

                root.Dispose();
            }
        }
    }
}
