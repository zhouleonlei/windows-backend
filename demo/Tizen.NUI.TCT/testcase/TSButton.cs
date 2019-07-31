using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.UIComponents.Button Tests")]
    public class ButtonTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ButtonTests");
            App.MainTitleChangeBackgroundColor(null);

        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test ForegroundVisualPadding.Check whether ForegroundVisualPadding is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.ForegroundVisualPadding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ForegroundVisualPadding_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();
            button.ForegroundVisualPadding = new Vector4(0, 0, 0, 0);
            Vector4 vector = button.ForegroundVisualPadding;
            Assert.AreEqual(0, vector.X, "Should be equals to the value set");
            Assert.AreEqual(0, vector.Y, "Should be equals to the value set");
            Assert.AreEqual(0, vector.Z, "Should be equals to the value set");
            Assert.AreEqual(0, vector.W, "Should be equals to the value set");
        }


        [Test]
        [Category("P1")]
        [Description("Test UnselectedVisual.Check whether UnselectedVisual is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.UnselectedVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void UnselectedVisual_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();
            PropertyMap map = new PropertyMap();
            map.Insert("visualType", new PropertyValue("COLOR"));
            Vector4 color = new Vector4(1.0f, 1.0f, 0.0f, 1.0f);
            map.Insert("mixColor", new PropertyValue(color));
            button.UnselectedVisual = map;

            Vector4 color_get = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            button.UnselectedVisual.Find((int)Tizen.NUI.ColorVisualProperty.MixColor).Get(color_get);
            Assert.AreEqual(color.X, color_get.X, "Should be equals to the color.X set");
            Assert.AreEqual(color.Y, color_get.Y, "Should be equals to the color.Y set");
            Assert.AreEqual(color.Z, color_get.Z, "Should be equals to the color.Z set");
            Assert.AreEqual(color.W, color_get.W, "Should be equals to the color.W set");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectedVisual.Check whether SelectedVisual is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.SelectedVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectedVisual_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();

            PropertyMap map = new PropertyMap();
            map.Insert("visualType", new PropertyValue("COLOR"));
            Vector4 color = new Vector4(1.0f, 1.0f, 0.0f, 1.0f);
            map.Insert("mixColor", new PropertyValue(color));
            button.SelectedVisual = map;

            Vector4 color_get = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            button.SelectedVisual.Find((int)Tizen.NUI.ColorVisualProperty.MixColor).Get(color_get);
            Assert.AreEqual(color.X, color_get.X, "Should be equals to the color.X set");
            Assert.AreEqual(color.Y, color_get.Y, "Should be equals to the color.Y set");
            Assert.AreEqual(color.Z, color_get.Z, "Should be equals to the color.Z set");
            Assert.AreEqual(color.W, color_get.W, "Should be equals to the color.W set");
        }

        [Test]
        [Category("P1")]
        [Description("Test DisabledSelectedVisual.Check whether UnselectedVisual is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.DisabledSelectedVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void DisabledSelectedVisual_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();

            PropertyMap map = new PropertyMap();
            map.Insert("visualType", new PropertyValue("COLOR"));
            Vector4 color = new Vector4(1.0f, 1.0f, 0.0f, 1.0f);
            map.Insert("mixColor", new PropertyValue(color));
            button.DisabledSelectedVisual = map;

            Vector4 color_get = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            button.DisabledSelectedVisual.Find((int)Tizen.NUI.ColorVisualProperty.MixColor).Get(color_get);
            Assert.AreEqual(color.X, color_get.X, "Should be equals to the color.X set");
            Assert.AreEqual(color.Y, color_get.Y, "Should be equals to the color.Y set");
            Assert.AreEqual(color.Z, color_get.Z, "Should be equals to the color.Z set");
            Assert.AreEqual(color.W, color_get.W, "Should be equals to the color.W set");
        }

        [Test]
        [Category("P1")]
        [Description("Test DisabledUnselectedVisual.Check whether DisabledUnselectedVisual is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.DisabledUnselectedVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void DisabledUnselectedVisual_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();

            PropertyMap map = new PropertyMap();
            map.Insert("visualType", new PropertyValue("COLOR"));
            Vector4 color = new Vector4(1.0f, 1.0f, 0.0f, 1.0f);
            map.Insert("mixColor", new PropertyValue(color));
            button.DisabledUnselectedVisual = map;

            Vector4 color_get = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            button.DisabledUnselectedVisual.Find((int)Tizen.NUI.ColorVisualProperty.MixColor).Get(color_get);
            Assert.AreEqual(color.X, color_get.X, "Should be equals to the color.X set");
            Assert.AreEqual(color.Y, color_get.Y, "Should be equals to the color.Y set");
            Assert.AreEqual(color.Z, color_get.Z, "Should be equals to the color.Z set");
            Assert.AreEqual(color.W, color_get.W, "Should be equals to the color.W set");
        }

        [Test]
        [Category("P1")]
        [Description("Test UnselectedBackgroundVisual.Check whether UnselectedBackgroundVisual is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.UnselectedBackgroundVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void UnselectedBackgroundVisual_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();

            PropertyMap map = new PropertyMap();
            map.Insert("visualType", new PropertyValue("COLOR"));
            Vector4 color = new Vector4(1.0f, 1.0f, 0.0f, 1.0f);
            map.Insert("mixColor", new PropertyValue(color));
            button.UnselectedBackgroundVisual = map;

            Vector4 color_get = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            button.UnselectedBackgroundVisual.Find((int)Tizen.NUI.ColorVisualProperty.MixColor).Get(color_get);
            Assert.AreEqual(color.X, color_get.X, "Should be equals to the color.X set");
            Assert.AreEqual(color.Y, color_get.Y, "Should be equals to the color.Y set");
            Assert.AreEqual(color.Z, color_get.Z, "Should be equals to the color.Z set");
            Assert.AreEqual(color.W, color_get.W, "Should be equals to the color.W set");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectedBackgroundVisual.Check whether SelectedBackgroundVisual is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.SelectedBackgroundVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectedBackgroundVisual_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();

            PropertyMap map = new PropertyMap();
            map.Insert("visualType", new PropertyValue("COLOR"));
            Vector4 color = new Vector4(1.0f, 1.0f, 0.0f, 1.0f);
            map.Insert("mixColor", new PropertyValue(color));
            button.SelectedBackgroundVisual = map;

            Vector4 color_get = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            button.SelectedBackgroundVisual.Find((int)Tizen.NUI.ColorVisualProperty.MixColor).Get(color_get);
            Assert.AreEqual(color.X, color_get.X, "Should be equals to the color.X set");
            Assert.AreEqual(color.Y, color_get.Y, "Should be equals to the color.Y set");
            Assert.AreEqual(color.Z, color_get.Z, "Should be equals to the color.Z set");
            Assert.AreEqual(color.W, color_get.W, "Should be equals to the color.W set");
        }

        [Test]
        [Category("P1")]
        [Description("Test DisabledUnselectedBackgroundVisual.Check whether DisabledUnselectedBackgroundVisual is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.DisabledUnselectedBackgroundVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void DisabledUnselectedBackgroundVisual_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();

            PropertyMap map = new PropertyMap();
            map.Insert("visualType", new PropertyValue("COLOR"));
            Vector4 color = new Vector4(1.0f, 1.0f, 0.0f, 1.0f);
            map.Insert("mixColor", new PropertyValue(color));
            button.DisabledUnselectedBackgroundVisual = map;

            Vector4 color_get = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            button.DisabledUnselectedBackgroundVisual.Find((int)Tizen.NUI.ColorVisualProperty.MixColor).Get(color_get);
            Assert.AreEqual(color.X, color_get.X, "Should be equals to the color.X set");
            Assert.AreEqual(color.Y, color_get.Y, "Should be equals to the color.Y set");
            Assert.AreEqual(color.Z, color_get.Z, "Should be equals to the color.Z set");
            Assert.AreEqual(color.W, color_get.W, "Should be equals to the color.W set");
        }

        [Test]
        [Category("P1")]
        [Description("Test DisabledSelectedBackgroundVisual.Check whether DisabledSelectedBackgroundVisual is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.DisabledSelectedBackgroundVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void DisabledSelectedBackgroundVisual_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();

            PropertyMap map = new PropertyMap();
            map.Insert("visualType", new PropertyValue("COLOR"));
            Vector4 color = new Vector4(1.0f, 1.0f, 0.0f, 1.0f);
            map.Insert("mixColor", new PropertyValue(color));
            button.DisabledSelectedBackgroundVisual = map;

            Vector4 color_get = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            button.DisabledSelectedBackgroundVisual.Find((int)Tizen.NUI.ColorVisualProperty.MixColor).Get(color_get);
            Assert.AreEqual(color.X, color_get.X, "Should be equals to the color.X set");
            Assert.AreEqual(color.Y, color_get.Y, "Should be equals to the color.Y set");
            Assert.AreEqual(color.Z, color_get.Z, "Should be equals to the color.Z set");
            Assert.AreEqual(color.W, color_get.W, "Should be equals to the color.W set");
        }

        [Test]
        [Category("P1")]
        [Description("Test LabelRelativeAlignment.Check whether LabelRelativeAlignment is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.LabelRelativeAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void LabelRelativeAlignment_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();

            button.LabelRelativeAlignment = Button.Align.End;

            Assert.AreEqual(Button.Align.End, button.LabelRelativeAlignment, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test LabelPadding.Check whether LabelPadding is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.LabelPadding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void LabelPadding_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();
            Vector4 padding = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            button.LabelPadding = padding;

            Assert.AreEqual(padding.R, button.LabelPadding.R, "Should be equals to the padding.R set");
            Assert.AreEqual(padding.G, button.LabelPadding.G, "Should be equals to the padding.G set");
            Assert.AreEqual(padding.B, button.LabelPadding.B, "Should be equals to the padding.B set");
            Assert.AreEqual(padding.A, button.LabelPadding.A, "Should be equals to the padding.A set");
        }

        [Test]
        [Category("P1")]
        [Description("Create a Button object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.Button C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Button_INIT()
        {
            /* TEST CODE */
            var button = new PushButton();
            Assert.IsNotNull(button, "Can't create success object Button");
        }

        [Test]
        [Category("P1")]
        [Description("Test AutoRepeating.Check whether AutoRepeating is readable and writeable")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.AutoRepeating A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void AutoRepeating_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();
            button.AutoRepeating = true;
            Assert.AreEqual(true, button.AutoRepeating, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test InitialAutoRepeatingDelay. Check whether InitialAutoRepeatingDelay is readable and writeable")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.InitialAutoRepeatingDelay A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InitialAutoRepeatingDelay_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();
            button.InitialAutoRepeatingDelay = 1.0f;
            Assert.AreEqual(1.0f, button.InitialAutoRepeatingDelay, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test LabelText. Check whether LabelText is readable and writeable")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.LabelText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void LabelText_SET_GET_VALUE()
        {
            /* TEST CODE */
            PushButton button = new PushButton();

            button.LabelText = "Test LabelText";
            Assert.AreEqual("Test LabelText", button.LabelText, "Should be equals to the set value of text");
        }

        [Test]
        [Category("P1")]
        [Description("Test NextAutoRepeatingDelay. Check whether NextAutoRepeatingDelay is readable and writeable")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.NextAutoRepeatingDelay A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void NextAutoRepeatingDelay_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();
            button.NextAutoRepeatingDelay = 1.0f;
            Assert.AreEqual(1.0f, button.NextAutoRepeatingDelay, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Togglable. Check whether Togglable is readable and writeable")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.Togglable A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Togglable_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();

            button.Togglable = true;
            Assert.AreEqual(true, button.Togglable, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Selected. Check whether Selected is readable and writeable")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.Selected A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Selected_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();
            button.Size2D = new Size2D(200, 50);
            Window.Instance.GetDefaultLayer().Add(button);
            button.Togglable = true;
            button.Selected = true;

            Assert.AreEqual(true, button.Selected, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test UnselectedColor. Check whether UnselectedColor is readable and writeable")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.UnselectedColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void UnselectedColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();
            button.Size2D = new Size2D(200, 50);
            Window.Instance.GetDefaultLayer().Add(button);
            Color color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            button.UnselectedColor = color;

            Assert.AreEqual(color.R, button.UnselectedColor.R, "Should be equals to the color.R set");
            Assert.AreEqual(color.G, button.UnselectedColor.G, "Should be equals to the color.G set");
            Assert.AreEqual(color.B, button.UnselectedColor.B, "Should be equals to the color.B set");
            Assert.AreEqual(color.A, button.UnselectedColor.A, "Should be equals to the color.A set");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectedColor. Check whether SelectedColor is readable and writeable")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.SelectedColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectedColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();
            button.Size2D = new Size2D(200, 50);
            Window.Instance.GetDefaultLayer().Add(button);
            Color color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            button.SelectedColor = color;

            Assert.AreEqual(color.R, button.SelectedColor.R, "Should be equals to the color.R set");
            Assert.AreEqual(color.G, button.SelectedColor.G, "Should be equals to the color.G set");
            Assert.AreEqual(color.B, button.SelectedColor.B, "Should be equals to the color.B set");
            Assert.AreEqual(color.A, button.SelectedColor.A, "Should be equals to the color.A set");
        }

        [Test]
        [Category("P1")]
        [Description("Test Label. Check whether Label is readable and writeable")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.Label A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Label_SET_GET_VALUE()
        {
            /* TEST CODE */
            Button button = new PushButton();

            PropertyMap map = new PropertyMap();
            map.Insert("visualType", new PropertyValue("TEXT"));
            map.Insert("pointSize", new PropertyValue(15.0f));
            map.Insert("text", new PropertyValue("Test Label"));
            button.Label = map;

            PropertyMap propertyMap = button.Label;

            String text = "";
            (propertyMap.Find((int)Tizen.NUI.TextVisualProperty.Text)).Get(out text);
            Assert.AreEqual("Test Label", text, "Should be equals to the set value of text");
        }

        [Test]
        [Category("P1")]
        [Description("Test StateChanged Event.Check whether StateChanged defined in the spec is callable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Button.StateChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void StateChanged_CHECK_EVENT()
        {
            Button button = new PushButton();
            Window.Instance.GetDefaultLayer().Add(button);

            bool flag = false;
            button.StateChanged += (obj, e) =>
            {
                flag = true;

                return true;
            };

            button.Togglable = true;
            button.Selected = true;

            Assert.IsTrue(flag, "StateChanged is not be called");
        }
    }
}
