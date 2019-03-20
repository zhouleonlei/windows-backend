using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.FH.NUI.Samples
{
    public class NavigationSample : IExample
    {
        private View root;
        private TextLabel text = null;
        private Navigation whiteNavigation = null;
        private Navigation blackNavigation = null;
        private Navigation conditionNavigation = null;
        private Navigation blackConditionNavigation = null;
        private Navigation whiteEditNavigation = null;
        private Navigation blackEditNavigation = null;

        private static string[] itemPressImage = new string[]
        {
            CommonResource.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_slideshow_press.png",
            CommonResource.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_calendar_press.png",
            CommonResource.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_copy_press.png",
        };
        private static string[] itemNormalImage = new string[]
        {
            CommonResource.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_slideshow.png",
            CommonResource.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_calendar.png",
            CommonResource.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_copy.png",
        };
        private static string[] itemDimImage = new string[]
        {
            CommonResource.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_slideshow_dim.png",
            CommonResource.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_calendar_dim.png",
            CommonResource.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_copy_dim.png",
        };

        private static string[] itemBlackPressImage = new string[]
        {
            CommonResource.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_copy_b_press.png",
            CommonResource.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_play_b_press.png",
            CommonResource.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_search_b_press.png",
        };
        private static string[] itemBlackNormalImage = new string[]
        {
            CommonResource.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_copy_b.png",
            CommonResource.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_play_b.png",
            CommonResource.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_search_b.png",
        };
        private static string[] itemBlackDimImage = new string[]
        {
            CommonResource.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_copy_b_dim.png",
            CommonResource.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_play_b_dim.png",
            CommonResource.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_search_b_dim.png",
        };

        public void Activate()
        {
            Window window = Window.Instance;

            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
            };
            window.Add(root);

            text = new TextLabel();
            text.Text = "Create Navigation by style";
            text.Size2D = new Size2D(450, 100);
            text.Position2D = new Position2D(500, 60);
            text.MultiLine = true;
            root.Add(text);

            ////////white navigation//////////
            #region WhiteNaviagtion
            whiteNavigation = new Navigation("Back");
            whiteNavigation.Position2D = new Position2D(100, 150);

            root.Add(whiteNavigation);

            Navigation.NavigationItem backItem = new Navigation.NavigationItem("WhiteBackItem");
            whiteNavigation.AddItem(backItem);
            #endregion

            ////////black navigation//////////
            #region BlackNavigation
            blackNavigation = new Navigation("Back");
            blackNavigation.Position2D = new Position2D(300, 150);

            root.Add(blackNavigation);

            Navigation.NavigationItem blackBackItem = new Navigation.NavigationItem("BlackBackItem");
            blackNavigation.AddItem(blackBackItem);
            #endregion

            //////condition navigation//////////
            #region WhiteConditionNavigation
            conditionNavigation = new Navigation("WhiteCondition");
            conditionNavigation.Position2D = new Position2D(500, 150);
            conditionNavigation.ItemChangedEvent += NavigationItemChangedEvent;
            root.Add(conditionNavigation);

            for (int i = 0; i < 3; i++)
            {
                Navigation.NavigationItem conditionItem = new Navigation.NavigationItem("WhiteConditionItem");
                conditionItem.Text = "Text " + i;
                conditionItem.SubText = "SubText " + i;
                conditionItem.IconURLSelector = new StringSelector
                {
                    Pressed = itemPressImage[i],
                    Disabled = itemDimImage[i],
                    DisabledFocused = itemDimImage[i],
                    DisabledSelected = itemDimImage[i],
                    Other = itemNormalImage[i]
                };
                conditionNavigation.AddItem(conditionItem);
            }
            #endregion

            //////black condition navigation//////////
            #region BlackConditionNavigation
            blackConditionNavigation = new Navigation("BlackCondition");
            blackConditionNavigation.Position2D = new Position2D(700, 150);
            blackConditionNavigation.ItemChangedEvent += NavigationItemChangedEvent;
            root.Add(blackConditionNavigation);

            for (int i = 0; i < 3; i++)
            {
                Navigation.NavigationItem conditionItem = new Navigation.NavigationItem("BlackConditionItem");
                conditionItem.Text = "Text " + i;
                conditionItem.SubText = "SubText " + i;
                conditionItem.IconURLSelector = new StringSelector
                {
                    Pressed = itemBlackPressImage[i],
                    Disabled = itemBlackDimImage[i],
                    DisabledFocused = itemBlackDimImage[i],
                    DisabledSelected = itemBlackDimImage[i],
                    Other = itemBlackNormalImage[i]
                };
                blackConditionNavigation.AddItem(conditionItem);
            }
            #endregion

            //////////White Edit Mode///////////////
            #region WhiteEditModeNavigation
            whiteEditNavigation = new Navigation("WhiteEditMode");
            whiteEditNavigation.Size2D = new Size2D(178, 800);
            whiteEditNavigation.Position2D = new Position2D(900, 150);
            whiteEditNavigation.ItemChangedEvent += NavigationItemChangedEvent;
            root.Add(whiteEditNavigation);

            Navigation.NavigationItem firstEditItem = new Navigation.NavigationItem("WhiteEditModeFirstItem");            
            firstEditItem.Text = "1";
            firstEditItem.SubText = "SELECTED";
            whiteEditNavigation.AddItem(firstEditItem);

            for (int i = 0; i < 2; i++)
            {
                Navigation.NavigationItem editItem = new Navigation.NavigationItem("WhiteEditModeItem");
                editItem.Text = "Text " + i;
                editItem.IconURLSelector = new StringSelector
                {
                    Pressed = itemPressImage[i],
                    Disabled = itemDimImage[i],
                    DisabledFocused = itemDimImage[i],
                    DisabledSelected = itemDimImage[i],
                    Other = itemNormalImage[i]
                };
                whiteEditNavigation.AddItem(editItem);
            }
            Navigation.NavigationItem editLastItem = new Navigation.NavigationItem("WhiteEditModeLastItem");
            editLastItem.Text = "Cancel";
            editLastItem.IconURLSelector = new StringSelector
            {
                Pressed = CommonResource.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_cancel_press.png",
                Disabled = CommonResource.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_cancel_dim.png",
                DisabledFocused = CommonResource.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_cancel_dim.png",
                DisabledSelected = CommonResource.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_cancel_dim.png",
                Other = CommonResource.GetFHResourcePath() + "2. Side Navigation/sidenavi_btn_cancel.png"
            };
            whiteEditNavigation.AddItem(editLastItem);
            #endregion

            //////////Black Edit Mode///////////////
            #region BlackEditModeNavigation
            blackEditNavigation = new Navigation("BlackEditMode");
            blackEditNavigation.Size2D = new Size2D(178, 800);
            blackEditNavigation.Position2D = new Position2D(1100, 150);
            blackEditNavigation.ItemChangedEvent += NavigationItemChangedEvent;
            root.Add(blackEditNavigation);

            Navigation.NavigationItem firstEditItem2 = new Navigation.NavigationItem("BlackEditModeFirstItem");
            firstEditItem2.Text = "1";
            firstEditItem2.SubText = "SELECTED";
            blackEditNavigation.AddItem(firstEditItem2);

            for (int i = 0; i < 2; i++)
            {
                Navigation.NavigationItem editItem = new Navigation.NavigationItem("BlackEditModeItem");
                editItem.Text = "Text " + i;
                editItem.IconURLSelector = new StringSelector
                {
                    Pressed = itemBlackPressImage[i],
                    Disabled = itemBlackDimImage[i],
                    DisabledFocused = itemBlackDimImage[i],
                    DisabledSelected = itemBlackDimImage[i],
                    Other = itemBlackNormalImage[i]
                };
                blackEditNavigation.AddItem(editItem);
            }
            Navigation.NavigationItem editLastItem2 = new Navigation.NavigationItem("BlackEditModeLastItem");
            editLastItem2.Text = "Cancel";
            editLastItem2.IconURLSelector = new StringSelector
            {
                Pressed = CommonResource.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_cancel_b_press.png",
                Disabled = CommonResource.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_cancel_b_dim.png",
                DisabledFocused = CommonResource.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_cancel_b_dim.png",
                DisabledSelected = CommonResource.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_cancel_b_dim.png",
                Other = CommonResource.GetFHResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_cancel_b.png"
            };
            blackEditNavigation.AddItem(editLastItem2);
            #endregion
        }

        private void NavigationItemChangedEvent(object sender, Navigation.ItemChangeEventArgs e)
        {
            text.Text = "Create Navigation just by properties, Selected index from " + e.PreviousIndex + " to " + e.CurrentIndex;
        }

        public void Deactivate()
        {
            if (root != null)
            {
                if (text != null)
                {
                    root.Remove(text);
                    text.Dispose();
                    text = null;
                }

                if (whiteNavigation != null)
                {
                    root.Remove(whiteNavigation);
                    whiteNavigation.Dispose();
                    whiteNavigation = null;
                }
                if (blackNavigation != null)
                {
                    root.Remove(blackNavigation);
                    blackNavigation.Dispose();
                    blackNavigation = null;
                }
                if (conditionNavigation != null)
                {
                    root.Remove(conditionNavigation);
                    conditionNavigation.Dispose();
                    conditionNavigation = null;
                }
                if (blackConditionNavigation != null)
                {
                    root.Remove(blackConditionNavigation);
                    blackConditionNavigation.Dispose();
                    blackConditionNavigation = null;
                }

                if (whiteEditNavigation != null)
                {
                    root.Remove(whiteEditNavigation);
                    whiteEditNavigation.Dispose();
                    whiteEditNavigation = null;
                }

                if (blackEditNavigation != null)
                {
                    root.Remove(blackEditNavigation);
                    blackEditNavigation.Dispose();
                    blackEditNavigation = null;
                }
                Window.Instance.Remove(root);
                root.Dispose();
                root = null;
            }
        }
    }
}
