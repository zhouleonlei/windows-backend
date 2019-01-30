using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using System;
using Tizen.NUI;

namespace Tizen.FH.NUI.Samples
{
    public class SearchBarSample : IExample
    {
        private View rootView = null;
        private Tizen.FH.NUI.Controls.SearchBar searchBar = null;
        private TextLabel guideText = null;

        public void Activate()
        {
            CreateRootView();
            CreateSearchBar();
            CreateGuideText();
            Window.Instance.KeyEvent += OnWindowsKeyEvent;
        }

        private void CreateRootView()
        {
            rootView = new View();
            rootView.WidthResizePolicy = ResizePolicyType.FillToParent;
            rootView.HeightResizePolicy = ResizePolicyType.FillToParent;
            rootView.BackgroundColor = new Color(78.0f / 255.0f, 216.0f / 255.0f, 231.0f / 255.0f, 1.0f);
            rootView.Focusable = true;
            Window.Instance.Add(rootView);
            rootView.TouchEvent += OnRootViewTouchEvent;
        }

        private void CreateSearchBar()
        {
            searchBar = new FH.NUI.Controls.SearchBar("DefaultSearchBar");
            searchBar.Size2D = new Size2D(1600, 95);
            searchBar.Position2D = new Position2D(100, 350);
            searchBar.HintText = "DefaultSearchBar";
            searchBar.ResultListHeight = 536;
            rootView.Add(searchBar);
            searchBar.BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 0.8f);
            searchBar.SearchButtonClickEvent += OnSearchButtonClickEvent;
            searchBar.CancelButtonClickEvent += OnCancelButtonClickEvent;
        }

        private void CreateGuideText()
        {
            guideText = new TextLabel();
            guideText.Size2D = new Size2D(1100, 300);
            guideText.Position2D = new Position2D(30, 30);
            guideText.TextColor = Color.Blue;
            guideText.BackgroundColor = Color.White;
            guideText.PointSize = 15;
            guideText.MultiLine = true;
            rootView.Add(guideText);
            guideText.Text =
                "Tips: \n" +
                "User can input text after press on the InputBox; \n" +
                "User can press Return key to finish input. Then, the search icon will appear; \n" +
                "User can press on the search icon to search the inputted text, there are two result:  \n" +
                "#1, success, the search result list will appear; \n" +
                "#2, failed, this example if the length of the inputted text is greater than 10, text color will cahnged to Red. \n" +
                "User can press on the cancel icon to cancel the inputted text.";
        }

        private void OnWindowsKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Left")
                {
                }
                else if (e.Key.KeyPressedName == "Right")
                {
                }
            }
        }

        private bool OnRootViewTouchEvent(object sender, View.TouchEventArgs e)
        {
            FocusManager.Instance.SetCurrentFocusView(rootView);
            return false;
        }

        private void OnCancelButtonClickEvent(object sender, Tizen.FH.NUI.Controls.InputField.ButtonClickArgs args)
        {
            if (sender is Tizen.FH.NUI.Controls.SearchBar)
            {
                Tizen.FH.NUI.Controls.SearchBar searchBarObj = sender as Tizen.FH.NUI.Controls.SearchBar;
                Console.WriteLine("-------, name: " + searchBarObj.Name + ", args.State = " + args.State);
                if (args.State == FH.NUI.Controls.InputField.ButtonClickState.BounceUp)
                {
                    //if (searchBarObj.Text == "ERROR")
                    //{
                        searchBarObj.TextColor = Color.Black;
                    //}
                    searchBarObj.Text = "";
                    searchBarObj.ShrinkSearchList();
                }
            }
        }

        private void OnSearchButtonClickEvent(object sender, Tizen.FH.NUI.Controls.InputField.ButtonClickArgs args)
        {
            if (sender is Tizen.FH.NUI.Controls.SearchBar)
            {
                Tizen.FH.NUI.Controls.SearchBar searchBarObj = sender as Tizen.FH.NUI.Controls.SearchBar;
                Console.WriteLine("-------, name: " + searchBarObj.Name + ", args.State = " + args.State);
                if (args.State == FH.NUI.Controls.InputField.ButtonClickState.BounceUp)
                {
                    if (searchBarObj.Text.Length > 10)
                    {
                        searchBarObj.TextColor = Color.Red;
                    }
                    else
                    {
                        searchBarObj.ExpandSearchList();
                    }
                }
                
            }
        }

        public void Deactivate()
        {
            Window window = Window.Instance;
            window.KeyEvent -= OnWindowsKeyEvent;
            
            if (searchBar != null)
            {
                searchBar.SearchButtonClickEvent -= OnSearchButtonClickEvent;
                searchBar.CancelButtonClickEvent -= OnCancelButtonClickEvent;
                rootView.Remove(searchBar);
                searchBar.Dispose();
                searchBar = null;
            }
            if (guideText != null)
            {
                rootView.Remove(guideText);
                guideText.Dispose();
                guideText = null;
            }
            if (rootView != null)
            {
                rootView.TouchEvent -= OnRootViewTouchEvent;
                Window.Instance.Remove(rootView);
                rootView.Dispose();
                rootView = null;
            }
        }
    }
}
