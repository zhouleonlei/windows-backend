using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Samples
{
    public class HeaderSample : IExample
    {

        private View root1;
        private View root2;
        private View root3;
        public void Activate()
        {
           Window window = Window.Instance;

            root1 = new View()
            {
                SizeWidth = 1080,
                Position2D = new Position2D(0, 0),
                BackgroundColor = new Color(1.0f, 1.0f, 0, 0.7f),
                SizeHeight = 200,
                
             };

            Header header1 = new Header();
            header1.Position2D = new Position2D(0, 0);
            header1.BackgroundColor = new Color(255, 255, 255, 1);
            header1.Size2D = new Size2D(1080, 128);
            header1.HeaderText = "Title Area Default";
            header1.HeaderTextColor = new Color(0, 0, 0, 1); //black
            header1.LinebackgroundColor = new Color(0, 0, 0, 0.2f);//white

            root1.Add(header1);
            window.Add(root1);

            root2 = new View()
            {
                SizeWidth = 1080,
                Position2D = new Position2D(0, 210),
                BackgroundColor = new Color(1.0f, 1.0f, 0, 0.7f),
                SizeHeight = 200,
            };

            Header header2 = new Header();
            header2.Position2D = new Position2D(0, 0);
            header2.Size2D = new Size2D(1080, 128);
            header1.BackgroundColor = new Color(255, 255, 255, 0.7f);
            header2.HeaderText = "Title Area Opqaue";
            header2.HeaderTextColor = new Color(0, 0, 0, 1); //black
            header2.LinebackgroundColor = new  Color(0, 0, 0, 0.2f); //black


            root2.Add(header2);
            window.Add(root2);

            root3 = new View()
            {
                SizeWidth = 1080,
                Position2D = new Position2D(0, 420),
                BackgroundColor = new Color(0, 0, 0, 1),
                SizeHeight = 200,
            };

            Header header3 = new Header();
            header3.Position2D = new Position2D(0, 0);
            header3.Size2D = new Size2D(1080,128);
            header3.HeaderText = "Title Area Transparency";
            header3.HeaderTextColor = new Color(255, 255, 255, 1); //white
            header3.LinebackgroundColor = new Color(255, 255, 255, 0.2f);//white


            root3.Add(header3);
            window.Add(root3);
        }

        public void Deactivate()
        {
            if (root1 != null)
            {
                Window.Instance.Remove(root1);
                root1.Dispose();
            }
            if (root2 != null)
            {
                Window.Instance.Remove(root2);
                root2.Dispose();
            }
            if (root3 != null)
            {
                Window.Instance.Remove(root3);
                root3.Dispose();
            }
        }
    }
}
