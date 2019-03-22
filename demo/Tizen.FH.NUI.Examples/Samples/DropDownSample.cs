using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.FH.NUI.Samples
{
    public class DropDownSample : IExample
    {
        private SampleLayout root;
        private DropDown dropDown = null;
        private DropDown dropDown2 = null;
        private ScrollBar scrollBar = null;

        private static string[] iconImage = new string[]
        {
            CommonResource.GetFHResourcePath() + "10. Drop Down/img_dropdown_fahrenheit.png",
            CommonResource.GetFHResourcePath() + "10. Drop Down/img_dropdown_celsius.png",
        };

        public void Activate()
        {
            root = new SampleLayout();
            root.HeaderText = "DropDown";

            dropDown = new DropDown("HeaderDropDown");
            dropDown.Size2D = new Size2D(1080, 108);
            dropDown.Position2D = new Position2D(0, 10);
            dropDown.ListSize2D = new Size2D(360, 500);
            dropDown.HeaderText = "Header area";
            dropDown.ButtonText = "Normal list 1";
            root.Add(dropDown);

            for (int i = 0; i < 8; i++)
            {
                DropDown.DropDownItemData item = new DropDown.DropDownItemData("TextListItem");
                item.Size2D = new Size2D(360, 96);
                item.Text = "Normal list " + i;
                dropDown.AddItem(item);
            }

            dropDown.SelectedItemIndex = 1;
            ////////Attach scrollbar///////////
            scrollBar = new ScrollBar();
            scrollBar.Direction = ScrollBar.DirectionType.Vertical;
            scrollBar.Position2D = new Position2D(394, 2);
            scrollBar.Size2D = new Size2D(4, 446);
            scrollBar.TrackColor = Color.Green;
            scrollBar.ThumbSize = new Size(4.0f, 30.0f, 0.0f);
            scrollBar.ThumbColor = Color.Yellow;
            scrollBar.TrackImageURL = CommonResource.GetFHResourcePath() + "component/c_progressbar/c_progressbar_white_buffering.png";
            dropDown.AttachScrollBar(scrollBar);

            //////////////////ListSpinner DropDown////////////////////////
            dropDown2 = new DropDown("ListDropDown");
            dropDown2.Size2D = new Size2D(1080, 108);
            dropDown2.Position2D = new Position2D(0, 200);
            dropDown2.ListSize2D = new Size2D(360, 192);
            dropDown2.HeaderText = "List area";
            dropDown2.ButtonText = "Menu";
            root.Add(dropDown2);

            for (int i = 0; i < 2; i++)
            {
                DropDown.DropDownItemData item = new DropDown.DropDownItemData("IconListItem");
                item.Size2D = new Size2D(360, 96);
                item.IconResourceUrl = iconImage[i];
                dropDown2.AddItem(item);
            }

            dropDown2.SelectedItemIndex = 0;

            dropDown.RaiseToTop();
        }

        public void Deactivate()
        {
            if (root != null)
            {
                if (dropDown != null)
                {
                    if (scrollBar != null)
                    {
                        dropDown.DetachScrollBar();
                        scrollBar.Dispose();
                        scrollBar = null;
                    }

                    root.Remove(dropDown);
                    dropDown.Dispose();
                    dropDown = null;
                }

                if (dropDown2 != null)
                {
                    root.Remove(dropDown2);
                    dropDown2.Dispose();
                    dropDown2 = null;
                }

                root.Dispose();
            }
        }

        private void ButtonClickEvent(object sender, Button.ClickEventArgs e)
        {
            Button btn = sender as Button;
           
        }
    }
}
