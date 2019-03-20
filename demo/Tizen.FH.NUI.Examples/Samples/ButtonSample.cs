using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.FH.NUI.Samples
{
    public class ButtonSample : IExample
    {
        private SampleLayout root;

        public void Activate()
        {
            Window window = Window.Instance;
            root = new SampleLayout();
            root.HeaderText = "Button";

          
            window.Add(root);
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
