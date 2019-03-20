using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using StyleManager = Tizen.NUI.Controls.StyleManager;

namespace Tizen.FH.NUI.Samples
{
    public class SampleLayout : ImageView
    {
        private Header LayoutHeader;

        private Button UtilityButton;
        private Button FoodButton;
        private Button FamilyButton;
        private Button KitchenButton;

        private View Content;
        public string HeaderText
        {
            get
            {
                return LayoutHeader.HeaderText;
            }

            set
            {
                LayoutHeader.HeaderText = value;
            }
        }

        public new void Add(View view)
        {
            Content.Add(view);
        }


        public SampleLayout()
        {
            Size2D = new Size2D(Window.Instance.Size.Width, Window.Instance.Size.Height);
            Window.Instance.Add(this);
            LayoutHeader = new Header("DefaultHeader");
            base.Add(LayoutHeader);

            ButtonAttributes buttonAttributes = new ButtonAttributes
            {
                IsSelectable = true,
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { All = CommonResource.GetFHResourcePath() + "3. Button/rectangle_point_btn_normal.png" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                },

                ShadowImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { All = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                },

                OverlayImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { Pressed = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png", Other = "" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) },
                },

                TextAttributes = new TextAttributes
                {
                    PointSize = new FloatSelector { All = 30 },
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,

                    TextColor = new ColorSelector
                    {
                        All = new Color(0, 0, 0, 1),
                    },
                }
            };

            UtilityButton = new Button(buttonAttributes);
            UtilityButton.Size2D = new Size2D(200, 80);
            UtilityButton.Position2D = new Position2D(56, 150);
            UtilityButton.Text = "Utility";
            UtilityButton.ClickEvent += UtilityButton_ClickEvent;
            base.Add(UtilityButton);

            buttonAttributes.BackgroundImageAttributes.ResourceURL.All = CommonResource.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_ec7510.png";
            FoodButton = new Button(buttonAttributes);
            FoodButton.Size2D = new Size2D(200, 80);
            FoodButton.Position2D = new Position2D(312, 150);
            FoodButton.Text = "Food";
            FoodButton.ClickEvent += FoodButton_ClickEvent;
            base.Add(FoodButton);

            buttonAttributes.BackgroundImageAttributes.ResourceURL.All = CommonResource.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_24c447.png";
            FamilyButton = new Button(buttonAttributes);
            FamilyButton.Size2D = new Size2D(200, 80);
            FamilyButton.Position2D = new Position2D(578, 150);
            FamilyButton.Text = "Family";
            FamilyButton.ClickEvent += FamilyButton_ClickEvent;
            base.Add(FamilyButton);

            buttonAttributes.BackgroundImageAttributes.ResourceURL.All = CommonResource.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_9762d9.png";
            KitchenButton = new Button(buttonAttributes);
            KitchenButton.Size2D = new Size2D(200, 80);
            KitchenButton.Position2D = new Position2D(834, 150);
            KitchenButton.Text = "Kitchen";
            KitchenButton.ClickEvent += KitchenButton_ClickEvent;
            base.Add(KitchenButton);

            Content = new View
            {
                Size2D = new Size2D(Window.Instance.Size.Width, Window.Instance.Size.Height - 128 - 150),
                Position2D = new Position2D(0, 128 + 150),
            };

            base.Add(Content);

            //this.ResourceUrl = CommonResource.GetFHResourcePath() + "0. BG/background_default_overlay.png";
        }

        private void KitchenButton_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            StyleManager.Instance.Theme = "Kitchen";
        }

        private void FamilyButton_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            StyleManager.Instance.Theme = "Family";
        }

        private void FoodButton_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            StyleManager.Instance.Theme = "Food";
        }

        private void UtilityButton_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            StyleManager.Instance.Theme = "Utility";
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                Remove(Content);
                Content.Dispose();
                Remove(LayoutHeader);
                LayoutHeader.Dispose();

                Remove(UtilityButton);
                UtilityButton.Dispose();
                Remove(FoodButton);
                FoodButton.Dispose();
                Remove(FamilyButton);
                FamilyButton.Dispose();
                Remove(KitchenButton);
                KitchenButton.Dispose();

                Window.Instance.Remove(this);
            }

            base.Dispose(type);
        }
    }
}
