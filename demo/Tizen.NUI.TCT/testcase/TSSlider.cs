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
    [Description("Tizen.NUI.UIComponents.Slider Tests")]
    public class SliderTests
    {
        private bool checkValue;
        private bool checkFinish;
        public bool checkMark;
        private string TAG = "TCT";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        public SliderTests()
        {
            checkValue = false;
            checkFinish = false;
            checkMark = false;
        }

        ~SliderTests()
        {
        }

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("SliderTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        public bool OnSlidingFinish(object obj, Slider.SlidingFinishedEventArgs args)
        {
            checkFinish = true;
            return true;
        }
        public bool OnMarkReach(object obj, Slider.MarkReachedEventArgs args)
        {
            checkMark = true;
            return true;
        }
        public bool OnSliderValueChange(object testObj, Slider.ValueChangedEventArgs args)
        {
            checkValue = true;
            return true;
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check whether Slider construct.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.Slider C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void Slider_INIT()
        {
            var slider = new Slider();
            Assert.IsInstanceOf<Slider>(slider, "Costruct Test Fail");
        }

        [Test]
        [Category("P1")]
        [Description("Test ValueChanged. Check Event Handler of Value Change.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.ValueChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void ValueChanged_CHECK_EVENT()
        {
            Slider slider = new Slider();
            checkValue = false;

            EventHandlerWithReturnType<object, Slider.ValueChangedEventArgs, bool> changePtr = new EventHandlerWithReturnType<object, Slider.ValueChangedEventArgs, bool>(OnSliderValueChange);
            slider.ValueChanged += changePtr;
            slider.ValueChanged += (obj, e) =>
            {
                return true;

            };
            slider.Value = 3.0f;

            Assert.IsTrue(checkValue, " Value Change add error");

            checkValue = false;
            slider.ValueChanged -= changePtr;
            Assert.IsFalse(checkValue, " Value Change remove error");
        }

        [Test]
        [Category("P1")]
        [Description("Test LowerBound. Check LowerBound Read & Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.LowerBound A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void LowerBound_SET_GET_VALUE()
        {
            Slider slider = new Slider();
            slider.LowerBound = 1.0f;
            Assert.AreEqual(1.0f, slider.LowerBound, "Lower Bound Test Fali.");
        }

        [Test]
        [Category("P1")]
        [Description("Test UpperBound. Check UpperBound Read & Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.UpperBound A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void UpperBound_SET_GET_VALUE()
        {
            Slider slider = new Slider();
            slider.UpperBound = 5.0f;
            Assert.AreEqual(5.0f, slider.UpperBound, "Upper Bound Test Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Value. Check Value Read & Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.Value A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void Value_SET_GET_VALUE()
        {
            Slider slider = new Slider();
            slider.Value = 5.0f;
            Assert.AreEqual(5.0f, slider.Value, "Slider Value Test Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test TrackVisual. Check TrackVisual Read & Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.TrackVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void TrackVisual_SET_GET_VALUE()
        {
            Slider slider = new Slider();
            PropertyMap map = new PropertyMap();
            map.Add("visualType", new PropertyValue("IMAGE"));
            map.Add("size", new PropertyValue(new Vector2(200, 200)));
            map.Add("url", new PropertyValue("track2.png"));
            slider.TrackVisual = map;
            string url = "";
            slider.TrackVisual.Find(2, "url").Get(out url);
            Assert.AreEqual("track2.png", url, "track visual test  fail.");
        }


        [Test]
        [Category("P1")]
        [Description("Test HandleVisual. Check HandleVisual Read & Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.HandleVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void HandleVisual_SET_GET_VALUE()
        {
            Slider slider = new Slider();
            PropertyMap map = new PropertyMap();
            map.Add("visualType", new PropertyValue("IMAGE"));
            map.Add("size", new PropertyValue(new Vector2(200, 200)));
            map.Add("url", new PropertyValue("handle2.png"));
            slider.HandleVisual = map;
            string url = "";
            slider.HandleVisual.Find(2, "url").Get(out url);
            Assert.AreEqual("handle2.png", url, "Handle Visual Test Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ProgressVisual. Check ProgressVisual Read & Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.ProgressVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void ProgressVisual_SET_GET_VALUE()
        {
            Slider slider = new Slider();
            PropertyMap map = new PropertyMap();
            map.Add("visualType", new PropertyValue("IMAGE"));
            map.Add("size", new PropertyValue(new Vector2(200, 200)));
            map.Add("url", new PropertyValue("progress2.png"));
            slider.ProgressVisual = map;
            string url = "";
            slider.ProgressVisual.Find(2, "url").Get(out url);
            Assert.AreEqual("progress2.png", url, "Progress Visual Test Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test DisabledColor. Check DisabledColor Read & Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.DisabledColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void DisabledColor_SET_GET_VALUE()
        {
            Slider slider = new Slider();
            Window.Instance.GetDefaultLayer().Add(slider);
            slider.DisabledColor = new Vector4(255, 255, 255, 255);
            Assert.AreEqual(255, slider.DisabledColor.R, "Slider Disable Color R Test Fail.");
            Assert.AreEqual(255, slider.DisabledColor.G, "Slider Disable Color G Test Fail.");
            Assert.AreEqual(255, slider.DisabledColor.B, "Slider Disable Color B Test Fail.");
            Assert.AreEqual(255, slider.DisabledColor.A, "Slider Disable Color A Test Fail.");
        }


        [Test]
        [Category("P1")]
        [Description("Test ValuePrecision. Check ValuePrecision Read & Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.ValuePrecision A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void ValuePrecision_SET_GET_VALUE()
        {
            Slider slider = new Slider();
            slider.ValuePrecision = 4;
            Assert.AreEqual(4, slider.ValuePrecision, "Slider ValuePrecision Test Fail.");
        }


        [Test]
        [Category("P1")]
        [Description("Test ShowPopup. Check ShowPopup Read & Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.ShowPopup A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void ShowPopup_SET_GET_VALUE()
        {
            Slider slider = new Slider();
            slider.ShowPopup = false;
            Assert.IsFalse(slider.ShowPopup, "Slider Show Popup Test Fail.");
        }


        [Test]
        [Category("P1")]
        [Description("Test ShowValue. Check ShowValue Read & Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.ShowValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void ShowValue_SET_GET_VALUE()
        {
            Slider slider = new Slider();
            slider.ShowValue = false;
            Assert.IsFalse(slider.ShowValue, "Slider Show Value Test Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test SnapToMarks. Check SnapToMarks Read & Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.SnapToMarks A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void SnapToMarks_SET_GET_VALUE()
        {
            Slider slider = new Slider();
            slider.SnapToMarks = false;
            Assert.IsFalse(slider.SnapToMarks, "Slider SnapToMarks Test Fail.");
        }


        [Test]
        [Category("P1")]
        [Description("Test MarkTolerance. Check MarkTolerance Read & Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.MarkTolerance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void MarkTolerance_SET_GET_VALUE()
        {
            Slider slider = new Slider();
            slider.MarkTolerance = 0.2f;
            Assert.AreEqual(0.2f, slider.MarkTolerance, "Slider Show Value Test Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Slider.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            try
            {
                Slider slider = new Slider();
                slider.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Marks. Check Marks Read & Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.Marks A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void Marks_SET_GET_VALUE()
        {
            Slider slider = new Slider();
            slider.LowerBound = 1.0f;
            slider.UpperBound = 5.0f;

            PropertyArray marks = new PropertyArray();
            marks.Add(new PropertyValue(1));
            marks.Add(new PropertyValue(2));
            marks.Add(new PropertyValue(3));
            slider.Marks = marks;
            int markValue = 0;
            slider.Marks[1].Get(out markValue);
            Assert.AreEqual(2, markValue, "Get Marks Error");
        }

        [Test]
        [Category("P1")]
        [Description("Test PopupVisual. Check PopupVisual Read & Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.PopupVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void PopupVisual_SET_GET_VALUE()
        {
            Slider slider = new Slider();
            slider.ShowPopup = true;
            PropertyMap map = new PropertyMap();
            map.Add("visualType", new PropertyValue("IMAGE"));
            map.Add("size", new PropertyValue(new Vector2(200, 200)));
            map.Add("url", new PropertyValue(image_path));
            slider.PopupVisual = map;
            string url = "";
            slider.PopupVisual.Find(2, "url").Get(out url);
            Assert.AreEqual(image_path, url, "Popup Visual Test Fail.");
        }


        [Test]
        [Category("P1")]
        [Description("Test PopupArrowVisual. Check ProgressVisual Read & Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.PopupArrowVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void PopupArrowVisual_SET_GET_VALUE()
        {
            Slider slider = new Slider();
            slider.ShowPopup = true;
            PropertyMap map = new PropertyMap();
            map.Add("visualType", new PropertyValue("IMAGE"));
            map.Add("size", new PropertyValue(new Vector2(200, 200)));
            map.Add("url", new PropertyValue(image_path));
            slider.PopupArrowVisual = map;
            string url = "";
            slider.PopupArrowVisual.Find(2, "url").Get(out url);
            Assert.AreEqual(image_path, url, "Popup Arrow Visual Test Fail.");
        }

        [Test]
        [Category("P1")]
        [Description("Test DownCast. Get the Slider instance from handle instance.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Slider.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void DownCast_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            BaseHandle handle = new Slider();
            var slider = Slider.DownCast(handle);
            Assert.IsInstanceOf<Slider>(slider);
        }
    }
}
