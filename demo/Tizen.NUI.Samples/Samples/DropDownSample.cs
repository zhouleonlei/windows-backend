using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.NUI.Samples
{
    public class DropDownSample : IExample
    {
        private View root;

        private TextLabel[] createText = new TextLabel[2];

        private DropDown dropDown = null;
        private DropDown dropDown2 = null;

        private Button button = null;
        private Button button2 = null;
        private int index = 0;

        private static string[] mode = new string[]
        {
            "Utility DropDown",
            "Family DropDown",
            "Food DropDown",
            "Kitchen DropDown",
        };
        private static Color[] color = new Color[]
        {
        new Color(0.05f, 0.63f, 0.9f, 1),//#ff0ea1e6 Utility
        new Color(0.14f, 0.77f, 0.28f, 1),//#ff24c447 Family
        new Color(0.75f, 0.46f, 0.06f, 1),//#ffec7510 Food
        new Color(0.59f, 0.38f, 0.85f, 1),//#ff9762d9 Kitchen
        };
        public void Activate()
        {
            Window window = Window.Instance;

            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
            };
            window.Add(root);

            ///////////////////////////////////////////////Create by Property//////////////////////////////////////////////////////////
            createText[0] = new TextLabel();
            createText[0].Text = "Create DropDown just by properties";
            createText[0].Size2D = new Size2D(450, 100);
            createText[0].Position2D = new Position2D(200, 100);
            createText[0].MultiLine = true;
            root.Add(createText[0]);

            dropDown = new DropDown();
            dropDown.Size2D = new Size2D(1000, 108);
            dropDown.Position2D = new Position2D(100, 300);
            dropDown.HeaderText = "TitleArea";
            dropDown.HeaderTextColor = new Color(0, 0, 0, 1);
            dropDown.HeaderTextPointSize = 28;
            dropDown.HeaderTextFontFamily = "SamsungOneUI 500C";
            dropDown.ButtonText = "DropDown Text";
            dropDown.ButtonTextColor = new Color(0, 0, 0, 1);
            dropDown.ButtonTextPointSize = 20;
            dropDown.ButtonTextFontFamily = "SamsungOneUI 500";
            dropDown.ButtonIconImageURL = CommonReosurce.GetFHResourcePath() + "6. List/list_ic_dropdown.png";
            dropDown.ButtonIconSize2D = new Size2D(48, 48);
            dropDown.LeftSpace = 56;
            dropDown.SpaceBetweenButtonTextAndIcon = 8;
            dropDown.ListBackgroundImageURL = CommonReosurce.GetFHResourcePath() + "10. Drop Down/dropdown_bg.png";
            dropDown.ListBackgroundImageBorder = new Rectangle(51, 51, 51, 51);
            dropDown.ListLeftMargin = 20;
            dropDown.ListTopMargin = 20;
            dropDown.BackgroundColor = new Color(1, 1, 1, 1);

            root.Add(dropDown);

            for (int i = 0; i < 3; i++)
            {
                DropDown.DropDownItemData item = new DropDown.DropDownItemData();
                item.Text = "DropDown " + i;
                dropDown.AddItem(item);
            }

            ///////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            //createText[1] = new TextLabel();
            //createText[1].Text = "Create DropDown just by Attributes";
            //createText[1].Size2D = new Size2D(450, 100);
            //createText[1].Position2D = new Position2D(1000, 100);
            //createText[1].MultiLine = true;
            //root.Add(createText[1]);

            //DropDownAttributes attrs = new DropDownAttributes
            //{
            //    IsNatureTextWidth = false,
            //    Space = new Vector4(56, 56, 1, 0),
            //    UnderLineAttributes = new ViewAttributes
            //    {
            //        Size2D = new Size2D(1, 3),
            //        PositionUsesPivotPoint = true,
            //        ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
            //        PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
            //        BackgroundColor = new ColorSelector { All = color[0]},
            //    },
            //    TextAttributes = new TextAttributes
            //    {
            //        PointSize = new FloatSelector { All = 25 },
            //        TextColor = new ColorSelector
            //        {
            //            Normal = Color.Black,
            //            Selected = color[0],
            //        },
            //    },                
            //};

            //dropDown2 = new DropDown(attrs);
            //dropDown2.Size2D = new Size2D(500, 108);
            //dropDown2.Position2D = new Position2D(900, 300);
            //dropDown2.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            //dropDown2.ItemChangedEvent += DropDown2ItemChangedEvent;
            //root.Add(dropDown2);

            //for (int i = 0; i < 3; i++)
            //{
            //    DropDown.DropDownItem item = new DropDown.DropDownItem();
            //    item.Text = "DropDown " + i;
            //    dropDown2.AddItem(item);
            //}
            //dropDown2.SelectedItemIndex = 0;

            //button = new Button();
            //button.BackgroundImageURL = CommonReosurce.GetTVResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            //button.BackgroundImageBorder = new Rectangle(4, 4, 5, 5);
            //button.Size2D = new Size2D(280, 80);
            //button.Position2D = new Position2D(500, 700);
            //button.Text = mode[index];
            //button.ClickEvent += ButtonClickEvent;
            //root.Add(button);

            //button2 = new Button();
            //button2.BackgroundImageURL = CommonReosurce.GetTVResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            //button2.BackgroundImageBorder = new Rectangle(4, 4, 5, 5);
            //button2.Size2D = new Size2D(580, 80);
            //button2.Position2D = new Position2D(800, 500);
            //button2.Text = "LayoutDirection is left to right";
            //button2.ClickEvent += ButtonClickEvent2;
            //root.Add(button2);
        }

        public void Deactivate()
        {
            if (root != null)
            {
                if (button != null)
                {
                    root.Remove(button);
                    button.Dispose();
                    button = null;
                }

                if (button2 != null)
                {
                    root.Remove(button2);
                    button2.Dispose();
                    button2 = null;
                }

                if (dropDown != null)
                {
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

                if (createText[0] != null)
                {
                    root.Remove(createText[0]);
                    createText[0].Dispose();
                    createText[0] = null;
                }
                if (createText[1] != null)
                {
                    root.Remove(createText[1]);
                    createText[1].Dispose();
                    createText[1] = null;
                }

                Window.Instance.Remove(root);
                root.Dispose();
                root = null;
            }
        }
    }
}
