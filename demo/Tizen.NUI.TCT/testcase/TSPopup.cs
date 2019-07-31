using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.UIComponents.Popup Tests")]
    public class PopupTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("PopupTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        private void OnTouchedOutside(object obj, EventArgs e)
        { }

        [Test]
        [Category("P1")]
        [Description("Create a popup object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.Popup C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Popup_INIT()
        {
            /* TEST CODE */
            var popup = new Popup();

            Assert.IsNotNull(popup, "Can't create success object Popup");
            Assert.IsInstanceOf<Popup>(popup, "Should be an instance of Popup type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test SetTitle.Check whether Title is set successfully.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.SetTitle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SetTitle_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                Popup popup = new Popup();
                TextLabel label = new TextLabel("setTitle");
                popup.SetTitle(label);
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
        [Description("Test SetContent.Check whether Content is set successfully.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.SetContent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SetContent_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                Popup popup = new Popup();
                TextLabel label = new TextLabel("SetContent");
                popup.SetContent(label);
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
        [Description("Test SetFooter.Check whether Footer is set successfully.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.SetFooter M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SetFooter_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                Popup popup = new Popup();
                TextLabel label = new TextLabel("SetFooter");
                popup.SetTitle(label);
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
        [Description("Test Title.Check whether Title is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.Title A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Title_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.AnimationDuration = 0.0f;
            popup.SetDisplayState(Popup.DisplayStateType.Shown);
            TextLabel label = new TextLabel("test title");
            PropertyMap map = new PropertyMap();
            map.Add("type", new PropertyValue(label.GetTypeName()));
            map.Add("text", new PropertyValue("test title"));
            popup.Title = map;

            PropertyMap propertyMap = popup.Title;
            String type = "";
            (propertyMap.Find(0, "type")).Get(out type);
            Assert.AreEqual("TextLabel", type, "Should be equals to the set value of type");
            String text = "";
            (propertyMap.Find(1, "text")).Get(out text);
            Assert.AreEqual("test title", text, "Should be equals to the set value of text");
        }

        [Test]
        [Category("P1")]
        [Description("Test Content.Check whether Content is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.Content A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Content_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.AnimationDuration = 0.0f;
            popup.SetDisplayState(Popup.DisplayStateType.Shown);
            TextLabel label = new TextLabel("test title");
            PropertyMap map = new PropertyMap();
            map.Add("type", new PropertyValue(label.GetTypeName()));
            map.Add("text", new PropertyValue("test content"));
            popup.Content = map;

            PropertyMap propertyMap = popup.Content;
            String type = "";
            (propertyMap.Find(0, "type")).Get(out type);
            Assert.AreEqual("TextLabel", type, "Should be equals to the set value of type");
            String text = "";
            (propertyMap.Find(1, "text")).Get(out text);
            Assert.AreEqual("test content", text, "Should be equals to the set value of text");
        }

        [Test]
        [Category("P1")]
        [Description("Test Footer.Check whether Footer is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.Footer A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Footer_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.AnimationDuration = 0.0f;
            popup.SetDisplayState(Popup.DisplayStateType.Shown);
            TextLabel label = new TextLabel("test title");
            PropertyMap map = new PropertyMap();
            map.Add("type", new PropertyValue(label.GetTypeName()));
            map.Add("text", new PropertyValue("test Footer"));
            popup.Footer = map;

            PropertyMap propertyMap = popup.Footer;
            String type = "";
            (propertyMap.Find(0, "type")).Get(out type);
            Assert.AreEqual("TextLabel", type, "Should be equals to the set value of type");
            String text = "";
            (propertyMap.Find(1, "text")).Get(out text);
            Assert.AreEqual("test Footer", text, "Should be equals to the set value of text");
        }

        [Test]
        [Category("P1")]
        [Description("Test ExitAnimation.Check whether ExitAnimation is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.ExitAnimation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public async Task ExitAnimation_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.PositionUsesPivotPoint = true;
            popup.AnimationDuration = 1.0f;
            popup.AnimationMode = Popup.AnimationModeType.Custom;
            TextLabel label = new TextLabel("text");
            popup.SetContent(label);

            PropertyMap animationMapExit = new PropertyMap();
            animationMapExit.Insert("actor", new PropertyValue("customAnimationPopup"));
            animationMapExit.Insert("property", new PropertyValue("position"));
            Vector3 EixAnimationDestination = new Vector3(-300.0f, -200.0f, 0.0f);
            animationMapExit.Insert("value", new PropertyValue(EixAnimationDestination));
            animationMapExit.Insert("alphaFunction", new PropertyValue("EASE_IN"));
            PropertyArray timePeriodMapExit = new PropertyArray();
            timePeriodMapExit.PushBack(new PropertyValue(0.0f));
            timePeriodMapExit.PushBack(new PropertyValue(1.0f));
            animationMapExit.Insert("timePeriod", new PropertyValue(timePeriodMapExit));
            popup.ExitAnimation = animationMapExit;

            Window.Instance.GetDefaultLayer().Add(popup);
            popup.SetDisplayState(Popup.DisplayStateType.Shown);
            await Task.Delay(20);

            Assert.IsNotNull(popup);
            Assert.IsNotNull(popup.ExitAnimation);
        }

        [Test]
        [Category("P1")]
        [Description("Test EntryAnimation.Check whether EntryAnimation is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.EntryAnimation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public async Task EntryAnimation_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.PositionUsesPivotPoint = true;
            popup.AnimationDuration = 1.0f;
            popup.AnimationMode = Popup.AnimationModeType.Custom;
            TextLabel label = new TextLabel("text");
            popup.SetContent(label);

            PropertyMap animationMapEntry = new PropertyMap();
            animationMapEntry.Insert("actor", new PropertyValue("customAnimationPopup"));
            animationMapEntry.Insert("property", new PropertyValue("position"));
            Vector3 entryAnimationDestination = new Vector3(300.0f, 200.0f, 0.0f);
            animationMapEntry.Insert("value", new PropertyValue(entryAnimationDestination));
            animationMapEntry.Insert("alphaFunction", new PropertyValue("EASE_OUT"));
            PropertyArray timePeriodMapEntry = new PropertyArray();
            timePeriodMapEntry.PushBack(new PropertyValue(0.0f));
            timePeriodMapEntry.PushBack(new PropertyValue(1.0f));
            animationMapEntry.Insert("timePeriod", new PropertyValue(timePeriodMapEntry));
            popup.EntryAnimation = animationMapEntry;

            Window.Instance.GetDefaultLayer().Add(popup);
            popup.SetDisplayState(Popup.DisplayStateType.Shown);
            await Task.Delay(20);

            Assert.IsNotNull(popup);
            Assert.IsNotNull(popup.EntryAnimation);
        }

        [Test]
        [Category("P1")]
        [Description("Test SetDisplayState.Check whether set DisplayState successfully")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.SetDisplayState M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SetDisplayState_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                Popup popup = new Popup();
                popup.AnimationDuration = 0.0f;
                popup.SetDisplayState(Popup.DisplayStateType.Shown);
                Assert.AreEqual(Popup.DisplayStateType.Shown, popup.DisplayState, "Should be equals to the set value of DisplayState");
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
        [Description("Test Shown.Check whether Shown will be triggered successfully")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.Shown E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Shown_CHECK_STATE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.AnimationDuration = 0.0f;
            bool flag = false;
            popup.Shown += (obj, ee) =>
            {
                flag = true;
            };
            popup.SetDisplayState(Popup.DisplayStateType.Shown);
            await Task.Delay(120);
            Assert.IsTrue(flag, "Shown Should be triggered!");

        }

        [Test]
        [Category("P1")]
        [Description("Test Showing.Check whether Showing will be triggered successfully")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.Showing E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Showing_CHECK_STATE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.AnimationDuration = 0.1f;
            bool flag = false;
            popup.Showing += (obj, ee) =>
            {
                flag = true;
            };
            popup.SetDisplayState(Popup.DisplayStateType.Showing);

            Assert.IsTrue(flag, "Showing Should be triggered!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Hidden.Check whether Hidden will be triggered successfully")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.Hidden E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Hidden_CHECK_STATE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.AnimationDuration = 0.1f;
            bool flag = false;
            popup.Hidden += (obj, ee) =>
            {
                flag = true;
            };
            popup.SetDisplayState(Popup.DisplayStateType.Shown);
            await Task.Delay(1200);
            popup.SetDisplayState(Popup.DisplayStateType.Hidden);
            await Task.Delay(1200);
            Assert.IsTrue(flag, "Hidden Should be triggered!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Hiding.Check whether Hiding will be triggered successfully")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.Hiding E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Hiding_CHECK_STATE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.AnimationDuration = 0.1f;
            bool flag = false;
            popup.Hiding += (obj, ee) =>
            {
                flag = true;
            };
            popup.SetDisplayState(Popup.DisplayStateType.Shown);
            popup.SetDisplayState(Popup.DisplayStateType.Hidden);

            Assert.IsTrue(flag, "Hiding Should be triggered!");
        }

        [Test]
        [Category("P1")]
        [Description("Test DisplayState.Check whether DisplayState is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.DisplayState A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void DisplayState_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.AnimationDuration = 0.0f;
            popup.DisplayState = Popup.DisplayStateType.Shown;
            Assert.AreEqual(Popup.DisplayStateType.Shown, popup.DisplayState, "Should be equals to the set value of DisplayState");
        }

        [Test]
        [Category("P1")]
        [Description("Test TouchTransparent.Check whether TouchTransparent is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.TouchTransparent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TouchTransparent_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.TouchTransparent = true;
            Assert.AreEqual(true, popup.TouchTransparent, "Should be equals to the set value of TouchTransparent");
        }

        [Test]
        [Category("P1")]
        [Description("Test TailVisibility.Check whether TailVisibility is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.TailVisibility A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TailVisibility_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.TailVisibility = true;
            Assert.AreEqual(true, popup.TailVisibility, "Should be equals to the set value of TailVisibility");
        }

        [Test]
        [Category("P1")]
        [Description("Test TailPosition.Check whether TailPosition is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.TailPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TailPosition_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();

            Vector3 vector3 = new Vector3(10.0f, 20.0f, 30.0f);
            popup.TailPosition = vector3;

            Assert.AreEqual(vector3.X, popup.TailPosition.X, "Should be equals to the set value of TailPosition.X");
            Assert.AreEqual(vector3.Y, popup.TailPosition.Y, "Should be equals to the set value of TailPosition.Y");
            Assert.AreEqual(vector3.Z, popup.TailPosition.Z, "Should be equals to the set value of TailPosition.Z");
        }

        [Test]
        [Category("P1")]
        [Description("Test ContextualMode.Check whether ContextualMode is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.ContextualMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ContextualMode_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.ContextualMode = Popup.ContextualModeType.NonContextual;
            Assert.AreEqual(Popup.ContextualModeType.NonContextual, popup.ContextualMode, "Should be equals to the set value of ContextualMode");
        }

        [Test]
        [Category("P1")]
        [Description("Test AnimationDuration.Check whether ContextualMode is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.AnimationDuration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void AnimationDuration_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.AnimationDuration = 0.6f;
            Assert.AreEqual(0.6f, popup.AnimationDuration, "Should be equals to the set value of AnimationDuration");
        }

        [Test]
        [Category("P1")]
        [Description("Test AnimationMode.Check whether AnimationMode is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.AnimationMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void AnimationMode_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.AnimationMode = Popup.AnimationModeType.Custom;
            Assert.AreEqual(Popup.AnimationModeType.Custom, popup.AnimationMode, "Should be equals to the set value of AnimationMode");
        }

        [Test]
        [Category("P1")]
        [Description("Test AutoHideDelay.Check whether AutoHideDelay is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.AutoHideDelay A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void AutoHideDelay_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.AutoHideDelay = 10;
            Assert.AreEqual(10, popup.AutoHideDelay, "Should be equals to the set value of AutoHideDelay");
        }

        [Test]
        [Category("P1")]
        [Description("Test BackingEnabled.Check whether BackingEnabled is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.BackingEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void BackingEnabled_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            popup.BackingEnabled = true;
            Assert.AreEqual(true, popup.BackingEnabled, "Should be equals to the set value of BackingEnabled");
        }

        [Test]
        [Category("P1")]
        [Description("Test BackingColor.Check whether BackingColor is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.BackingColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void BackingColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            Vector4 color = new Vector4(1.0f, 1.0f, 0.0f, 0.0f);
            popup.BackingColor = color;

            Assert.AreEqual(color.R, popup.BackingColor.R, "Should be equals to the set value of BackingColor.R");
            Assert.AreEqual(color.G, popup.BackingColor.G, "Should be equals to the set value of BackingColor.G");
            Assert.AreEqual(color.B, popup.BackingColor.B, "Should be equals to the set value of BackingColor.B");
            Assert.AreEqual(color.A, popup.BackingColor.A, "Should be equals to the set value of BackingColor.A");
        }

        [Test]
        [Category("P1")]
        [Description("Test PopupBackgroundImage.Check whether PopupBackgroundImage is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.PopupBackgroundImage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PopupBackgroundImage_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            ImageView imageView = new ImageView(image_path);
            string imageString = imageView.ResourceUrl;
            popup.PopupBackgroundImage = imageString;
            Assert.AreEqual(imageString, popup.PopupBackgroundImage, "Should be equals to the set value of PopupBackgroundImage");
        }

        [Test]
        [Category("P1")]
        [Description("Test PopupBackgroundBorder.Check whether PopupBackgroundBorder is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.PopupBackgroundBorder A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PopupBackgroundBorder_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            Rectangle boreder = new Rectangle(1, 1, 0, 0);
            popup.PopupBackgroundBorder = boreder;

            Assert.AreEqual(1, popup.PopupBackgroundBorder.X, "Should be equals to the set value of PopupBackgroundBorder.x");
            Assert.AreEqual(1, popup.PopupBackgroundBorder.Y, "Should be equals to the set value of PopupBackgroundBorder.y");
            Assert.AreEqual(0, popup.PopupBackgroundBorder.Width, "Should be equals to the set value of PopupBackgroundBorder.width");
            Assert.AreEqual(0, popup.PopupBackgroundBorder.Height, "Should be equals to the set value of PopupBackgroundBorder.height");
        }

        [Test]
        [Category("P1")]
        [Description("Test TailUpImage.Check whether TailUpImage is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.TailUpImage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TailUpImage_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            ImageView imageView = new ImageView(image_path);
            string imageString = imageView.ResourceUrl;
            popup.TailUpImage = imageString;
            Assert.AreEqual(imageString, popup.TailUpImage, "Should be equals to the set value of TailUpImage");
        }

        [Test]
        [Category("P1")]
        [Description("Test TailDownImage.Check whether TailDownImage is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.TailDownImage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TailDownImage_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            ImageView imageView = new ImageView(image_path);
            string imageString = imageView.ResourceUrl;
            popup.TailDownImage = imageString;
            Assert.AreEqual(imageString, popup.TailDownImage, "Should be equals to the set value of TailDownImage");
        }

        [Test]
        [Category("P1")]
        [Description("Test TailLeftImage.Check whether TailLeftImage is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.TailLeftImage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TailLeftImage_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            ImageView imageView = new ImageView(image_path);
            string imageString = imageView.ResourceUrl;
            popup.TailLeftImage = imageString;
            Assert.AreEqual(imageString, popup.TailLeftImage, "Should be equals to the set value of TailLeftImage");
        }

        [Test]
        [Category("P1")]
        [Description("Test TailRightImage.Check whether TailRightImage is readable and writeable.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.TailRightImage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TailRightImage_SET_GET_VALUE()
        {
            /* TEST CODE */
            Popup popup = new Popup();
            ImageView imageView = new ImageView(image_path);
            string imageString = imageView.ResourceUrl;
            popup.TailRightImage = imageString;
            Assert.AreEqual(imageString, popup.TailRightImage, "Should be equals to the set value of TailRightImage");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the Popup.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.Popup.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Popup popup = new Popup();
                popup.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
    }
}
