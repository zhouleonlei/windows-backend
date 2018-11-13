using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public class ImageScalePolicyTest : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            ImageView view = new ImageView()
            {
                Size2D = new Size2D(300, 600),
                BackgroundColor = Color.Cyan,
                PivotPoint = PivotPoint.Center,
                ParentOrigin = ParentOrigin.Center,
                PositionUsesPivotPoint = true,
                SizeScalePolicy = SizeScalePolicyType.UseSizeSet,
                ResourceUrl = "*DemoRes*/images/picture_mod.png",
            };
            window.Add(view);

            Size2D si = view.Size2D;
            Console.WriteLine($"\n width: {si.Width}, height: {si.Height}");
            window.KeyEvent += (obj, e) =>
            {
                if (e.Key.State == Key.StateType.Down)
                {
                    if (e.Key.KeyPressedName == "1")
                    {
                        view.SizeScalePolicy = SizeScalePolicyType.FitWithAspectRatio;
                        view.Size2D = new Size2D(500, 500);
                        Size2D si1 = view.Size2D;
                        Vector3 v1 = view.WorldScale;
                        Size2D c1 = view.CurrentSize;
                        Console.WriteLine($"\n 111 width: {si1.Width}, height: {si1.Height}");
                        Console.WriteLine($"\n c111 width: {c1.Width}, height: {c1.Height}");
                    }
                    else if (e.Key.KeyPressedName == "2")
                    {
                        view.SizeScalePolicy = SizeScalePolicyType.FitWithAspectRatio;
                        view.Size2D = new Size2D(900, 300);
                        Size2D si2 = view.Size2D;

                        Console.WriteLine($"\n 222 width: {si2.Width}, height: {si2.Height}");
                    }
                    else if (e.Key.KeyPressedName == "3")
                    {
                        view.SizeScalePolicy = SizeScalePolicyType.FillWithAspectRatio;
                        view.Size2D = new Size2D(900, 300);
                        Size2D si3 = view.Size2D;

                        Console.WriteLine($"\n 333 width: {si3.Width}, height: {si3.Height}");
                    }
                    else if (e.Key.KeyPressedName == "4")
                    {
                        view.SizeScalePolicy = SizeScalePolicyType.FillWithAspectRatio;
                        view.Size2D = new Size2D(500, 500);
                        Size2D si4 = view.Size2D;

                        Console.WriteLine($"\n 444 width: {si4.Width}, height: {si4.Height}");
                    }
                    else if (e.Key.KeyPressedName == "5")
                    {
                        Size2D size = view.Size2D;
                        Console.WriteLine($"\n 555 width: {size.Width}, height: {size.Height}");
                    }
                }
            };
        }
    }
}
