using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;

namespace Tizen.FH.NUI.Samples
{
    public class ToastSample : IExample
    {
        Toast shortToast, longToast;

        public void Activate()
        {
            Window window = Window.Instance;

            shortToast = new FH.NUI.Controls.Toast("BasicToast", Controls.Toast.ToastType.SHORT);
            shortToast.Text = "Tizen NUI short text Tizen NUI short text Tizen NUI short text Tizen NUI short text Tizen NUI short text";
            shortToast.Size2D = new Size2D(512, 110);
            shortToast.Position2D = new Position2D(600, 200);

            longToast = new FH.NUI.Controls.Toast("BasicToast", Controls.Toast.ToastType.LONG);
            longToast.Text = "Tizen NUI long text Tizen NUI long text Tizen NUI long text Tizen NUI long text Tizen NUI long text";
            longToast.Size2D = new Size2D(512, 110);
            longToast.Position2D = new Position2D(600, 400);

            window.Add(shortToast);
            window.Add(longToast);

            shortToast.Show(3000, false);
            longToast.Show(3000, false);

        }

        public void Deactivate()
        {
            if (shortToast != null)
            {
                Window.Instance.Remove(shortToast);
                shortToast.Dispose();
            }

            if (longToast != null)
            {
                Window.Instance.Remove(longToast);
                longToast.Dispose();
            }
        }
    }
}
