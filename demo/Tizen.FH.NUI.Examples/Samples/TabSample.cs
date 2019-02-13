using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.FH.NUI.Samples
{
    public class TabSample : IExample
    {
        private Tab tab = null;

        public void Activate()
        {
            Window window = Window.Instance;

            tab = new Tab("DATab");
            tab.IsNatureTextWidth = false;
            tab.Size2D = new Size2D(1000, 108);
            tab.Position2D = new Position2D(200, 300);
            window.Add(tab);

            for (int i = 0; i < 3; i++)
            {
                Tab.TabItem item = new Tab.TabItem();
                item.Text = "Tab " + i;
                tab.AddItem(item);
            }            

            FocusManager.Instance.SetCurrentFocusView(tab);
        }       

        public void Deactivate()
        {           
            if(tab != null)
            {
                Window.Instance.Remove(tab);
                tab.Dispose();
                tab = null;
            }
        }
    }
}
