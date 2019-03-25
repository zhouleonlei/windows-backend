using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;
using System;
using Tizen.NUI;

namespace Tizen.FH.NUI.Samples
{
    public class SearchBarSample : IExample
    {
        private SampleLayout rootView = null;
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
            rootView = new SampleLayout();
            rootView.HeaderText = "SearchBar";
        }

        private void CreateSearchBar()
        {
            searchBar = new FH.NUI.Controls.SearchBar("DefaultSearchBar");
            searchBar.HintText = "DefaultSearchBar";
            searchBar.ResultListHeight = 536;
            rootView.Add(searchBar);
            searchBar.SearchButtonClickEvent += OnSearchButtonClickEvent;
            searchBar.CancelButtonClickEvent += OnCancelButtonClickEvent;
            rootView.AttachSearchBar(searchBar);
        }

        private void CreateGuideText()
        {
            guideText = new TextLabel();
            guideText.Size2D = new Size2D(1000, 280);
            guideText.Position2D = new Position2D(40, 30);
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
                "User can press on the cancel icon to cancel the inputted text." +
                "User can exit the sample by press \"Esc\" key after touch on any area except the InputField.";
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
                rootView.Dispose();
                rootView = null;
            }
        }
    }
}
