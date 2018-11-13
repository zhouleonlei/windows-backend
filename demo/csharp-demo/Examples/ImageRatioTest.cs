using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public class ImageRatioTest : NUIApplication
    {
        private string ImagePath = "*DemoRes*/images/picture_mod.png";

        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            ImageVisual imagev = new ImageVisual();
            imagev.URL = "*DemoRes*/images/weather.png";//gallery-0.jpg";
            //imagev.AlphaMaskURL = "*DemoRes*/images/camera_snapshot_mask.png";
            //imagev.DesiredHeight = 400;
            //imagev.DesiredWidth = 200;
            imagev.FittingMode = FittingModeType.ShrinkToFit;

            ImageView image = new ImageView()
            {
                //BackgroundColor = Color.Green,
                Size2D = new Size2D(400, 200),
                Position2D = new Position2D(100, 100),
                //Image = imagev.OutputVisualMap,
                ResourceUrl = "*DemoRes*/images/gallery-0.jpg",
                Name = "ImageVisual",
                //ClippingMode = ClippingModeType.ClipToBoundingBox,
                //BackgroundImage = "*DemoRes*/images/weather.png",
                //Background = imagev.OutputVisualMap,
            };
            //image.SetImage();
            window.Add(image);

            TextLabel label = new TextLabel("Hello");
            //label.BackgroundColor = Color.Cyan;
            //label.BackgroundImage = "*DemoRes*/images/gallery-0.jpg";
            label.Background = imagev.OutputVisualMap;
            image.Add(label);
            //image.ResourceReady += (obj, e) => {
            //    ImageView img = obj as ImageView;
            //    Console.WriteLine($"\n Loading Status: {img.LoadingStatus}\n");
            //};

            window.KeyEvent += (obj, e) => {
                if (e.Key.State == Key.StateType.Down)
                {
                    if (e.Key.KeyPressedName == "1")
                    {
                        //image.BackgroundImage = "*DemoRes*/images/weather.png";
                        Console.WriteLine($"window receive key: {e.Key.KeyPressedName}");
                       
                        imagev.MixColor = new Color(0.3f, 0.3f, 0.6f, 0.3f);
                        image.Image = imagev.OutputVisualMap;
                    }
                    if (e.Key.KeyPressedName == "2")
                    {
                        //image.BackgroundImage = "*DemoRes*/images/weather.png";
                        Console.WriteLine($"window receive key: {e.Key.KeyPressedName}");
                       
                        imagev.MixColor = null;
                        image.Image = imagev.OutputVisualMap;
                    }
                    if (e.Key.KeyPressedName == "3")
                    {
                        //image.BackgroundImage = "*DemoRes*/images/weather.png";
                        Console.WriteLine($"window receive key: {e.Key.KeyPressedName}");

                        label.ClearBackground();
                    }
                }
            };
        }

        public static void _Main(string[] args)
        {
            TempTest p = new TempTest();
            p.Run(args);
        }
    }
}
