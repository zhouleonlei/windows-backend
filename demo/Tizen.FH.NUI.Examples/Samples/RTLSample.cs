using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.FH.NUI.Samples
{
    public class RTLSample : IExample
    {
        private View root;

        private View view1;
        private View view2;

        private Animation animation1 = new Animation(3000);

        public void Activate()
        {
            Window window = Window.Instance;
            window.KeyEvent += Window_KeyEvent;

            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
            };

            window.Add(root);


            view1 = new View
            {
                BackgroundColor = Color.Green,
                Position2D = new Position2D(500, 200),
                Size2D = new Size2D(500, 500)
            };

            root.Add(view1);

            view2 = new View
            {
                BackgroundColor = Color.Red,
                Position2D = new Position2D(0, 0),
                Size2D = new Size2D(100, 100),
                //Reversable = true,
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.TopLeft,
                //LayoutDirection = ViewLayoutDirectionType.RTL
            };

            view1.Add(view2);

            animation1.Finished += Animation1_Finished;

        }

        private void Animation1_Finished(object sender, global::System.EventArgs e)
        {
            float pos = view2.PositionX;
            int test = 1;
            
        }

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if(e.Key.State == Key.StateType.Down)
            {
                switch(e.Key.KeyPressedName)
                {
                    case "0":
                        view2.LayoutDirection = ViewLayoutDirectionType.RTL;
                        break;
                    case "1":
                        view2.LayoutDirection = ViewLayoutDirectionType.LTR;
                        break;
                    case "2":
                        view2.ParentOrigin = ParentOrigin.TopLeft;
                        view2.PivotPoint = PivotPoint.TopLeft;
                        break;
                    case "3":
                        view2.ParentOrigin = ParentOrigin.TopCenter;
                        view2.PivotPoint = ParentOrigin.TopCenter;
                        break;
                    case "4":
                        if (animation1.State == Animation.States.Playing) animation1.Stop();
                        animation1.Clear();
                        animation1.AnimateTo(view2, "PositionX", 300);
                        float pox = view2.PositionX;

                        animation1.Play();
                        pox = view2.PositionX;

                        break;
                    case "5":
                        animation1.Stop(Animation.EndActions.Cancel);
                        //float pox = view2.PositionX;
                        //animation1.Clear();
                        break;
                    case "6":

                        break;
                    case "7":

                        break;
                    case "8":

                        break;
                    case "9":

                        break;
                }
            }
        }

        public void Deactivate()
        {

            if (root != null)
            {
                Window.Instance.Remove(root);
                root.Dispose();
            }
        }
    }
}
