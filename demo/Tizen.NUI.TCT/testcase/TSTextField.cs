using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.TextField Tests")]
    public class TextFieldTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("TextFieldTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a TextField object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.TextField C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextField_INIT()
        {
            /* TEST CODE */
            var textField = new TextField();
            Assert.IsNotNull(textField, "Can't create success object CheckBoxButton");
            Assert.IsInstanceOf<TextField>(textField, "Should be an instance of CheckBoxButton type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Text. Check whether Text is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.Text A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Text_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.Text = "test Text";
            Assert.AreEqual("test Text", textField.Text, "Retrieved Text should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PlaceholderText. Check whether PlaceholderText is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.PlaceholderText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PlaceholderText_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.PlaceholderText = "test PlaceholderText";
            Assert.AreEqual("test PlaceholderText", textField.PlaceholderText, "Retrieved PlaceholderText should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Placeholder. Check whether Placeholder is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.Placeholder A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Placeholder_SET_GET_VALUE()
        {
            /* TEST CODE */
            PropertyMap map = new PropertyMap();
            map.Add("text", new PropertyValue("Setting Placeholder Text"));
            map.Add("textFocused", new PropertyValue("Setting Placeholder Text Focused"));
            map.Add("color", new PropertyValue(Color.Red));
            map.Add("fontFamily", new PropertyValue("Arial"));
            map.Add("pointSize", new PropertyValue(12.0f));

            TextField textField = new TextField();
            textField.Placeholder = map;
            PropertyMap propertyMap = textField.Placeholder;

            string text = "";
            bool ret = (propertyMap.Find(0, "text")).Get(out text);
            Tizen.Log.Debug(TAG, "gotten text=" + text + " return of get=" + ret);

            Assert.AreEqual("Setting Placeholder Text", text, "Should be equals to the set value of text");
        }

        [Test]
        [Category("P1")]
        [Description("Test EnableSelection. Check whether EnableSelection is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.EnableSelection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EnableSelection_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.EnableSelection = false;
            Assert.IsFalse(textField.EnableSelection, "Retrieved EnableSelection count should be equal to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Ellipsis. Check whether Ellipsis is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.Ellipsis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Ellipsis_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.Ellipsis = false;
            Assert.IsFalse(textField.Ellipsis, "Retrieved Ellipsis value should be equal to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test HiddenInputSettings. Check whether HiddenInputSettings is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.HiddenInputSettings A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void HiddenInputSettings_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            PropertyMap hiddenMap = new PropertyMap();
            hiddenMap.Add(HiddenInputProperty.Mode, new PropertyValue((int)HiddenInputModeType.ShowLastCharacter));
            hiddenMap.Add(HiddenInputProperty.ShowLastCharacterDuration, new PropertyValue(2));
            hiddenMap.Add(HiddenInputProperty.SubstituteCount, new PropertyValue(4));
            hiddenMap.Add(HiddenInputProperty.SubstituteCharacter, new PropertyValue(0x23));
            textField.HiddenInputSettings = hiddenMap;

            PropertyMap map = textField.HiddenInputSettings;
            int substituteCount = 0;
            map.Find(HiddenInputProperty.SubstituteCount).Get(out substituteCount);
            Assert.AreEqual(4, substituteCount, "Should be equal to the setted value!");
        }

        [Test]
        [Category("P1")]
        [Description("Test PlaceholderTextFocused. Check whether PlaceholderTextFocused is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.PlaceholderTextFocused A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PlaceholderTextFocused_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.PlaceholderText = "test PlaceholderTextFocused";
            Assert.AreEqual("test PlaceholderTextFocused", textField.PlaceholderText, "Retrieved PlaceholderTextFocused should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test FontFamily. Check whether FontFamily is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.FontFamily A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void FontFamily_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.FontFamily = "test FontFamily";
            Assert.AreEqual("test FontFamily", textField.FontFamily, "Retrieved FontFamily should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test FontStyle. Check whether FontStyle is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.FontStyle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void FontStyle_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            PropertyMap map = new PropertyMap();
            map.Clear();
            PropertyValue value = new PropertyValue("bold");
            map.Add("weight", value);
            value = new PropertyValue("condensed");
            map.Add("width", value);
            value = new PropertyValue("italic");
            map.Add("slant", value);
            textField.FontStyle = map;

            //This is for MDC-Solis TCT: MCD-Solis has different fonts installed so it needs seperated test case. (There is no condition or definition for specific target) 
            if (map.Count() != textField.FontStyle.Count())
            {
                map.Clear();
                value = new PropertyValue("bold");
                map.Insert("weight", value);
                value = new PropertyValue("normal");
                map.Insert("width", value);
                value = new PropertyValue("italic");
                map.Insert("slant", value);
                textField.FontStyle = map;
            }

            Assert.AreEqual(map.Count(), textField.FontStyle.Count(), "Retrieved FontStyle' count should be equal to set value");
            string str1, str2;
            for (uint index = 0u; index < map.Count(); index++)
            {
                map.GetValue(index).Get(out str1);
                textField.FontStyle.GetValue(index).Get(out str2);
                Assert.AreEqual(str1, str2);
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test PointSize. Check whether PointSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.PointSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PointSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            float size = 0.5f;
            textField.PointSize = size;
            Assert.AreEqual(size, textField.PointSize, "Retrieved PointSize should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test MaxLength. Check whether MaxLength is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.MaxLength A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void MaxLength_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.MaxLength = 20;
            Assert.AreEqual(20, textField.MaxLength, "Retrieved MaxLength should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ExceedPolicy. Check whether ExceedPolicy is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.ExceedPolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ExceedPolicy_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.ExceedPolicy = 10;
            Assert.AreEqual(10, textField.ExceedPolicy, "Retrieved ExceedPolicy should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test HorizontalAlignment. Check whether HorizontalAlignment is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.HorizontalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void HorizontalAlignment_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.HorizontalAlignment = HorizontalAlignment.End;
            Assert.AreEqual(HorizontalAlignment.End, textField.HorizontalAlignment, "Retrieved HorizontalAlignment should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test VerticalAlignment. Check whether VerticalAlignment is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.VerticalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void VerticalAlignment_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.VerticalAlignment = VerticalAlignment.Center;
            Assert.AreEqual(VerticalAlignment.Center, textField.VerticalAlignment, "Retrieved VerticalAlignment should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test TranslatablePlaceholderText.Check whether TranslatablePlaceholderText is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.TranslatablePlaceholderText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void TranslatablePlaceholderText_CHECK_EVENT()
        {
            TextField textField = new TextField();
            if (NUIApplication.MultilingualResourceManager != null)
            {
                textField.TranslatablePlaceholderText = "TextField";
                string translatablePlaceholderText = textField.TranslatablePlaceholderText;
                Assert.AreEqual("TextField", textField.TranslatablePlaceholderText, "TranslatablePlaceholderText is not equal to the set value!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test TranslatableText.Check whether TranslatableText is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.TranslatableText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void TranslatableText_CHECK_EVENT()
        {
            TextField textField = new TextField();
            if (NUIApplication.MultilingualResourceManager != null)
            {
                textField.TranslatableText = "TextField";
                string translatablePlaceholderText = textField.TranslatableText;
                Assert.AreEqual("TextField", textField.TranslatableText, "TranslatableText is not equal to the set value!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test TextColor. Check whether TextColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.TextColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            Color color = Color.Blue;
            textField.TextColor = color;
            Assert.AreEqual(color.R, textField.TextColor.R, "Retrieved TextColor.R should be equal to set value");
            Assert.AreEqual(color.G, textField.TextColor.G, "Retrieved TextColor.G should be equal to set value");
            Assert.AreEqual(color.B, textField.TextColor.B, "Retrieved TextColor.B should be equal to set value");
            Assert.AreEqual(color.A, textField.TextColor.A, "Retrieved TextColor.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PlaceholderTextColor. Check whether PlaceholderTextColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.PlaceholderTextColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PlaceholderTextColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            Vector4 color = new Vector4(0.1f, 0.2f, 0.3f, 0.4f);
            textField.PlaceholderTextColor = color;
            Assert.AreEqual(color.R, textField.PlaceholderTextColor.R, "Retrieved PlaceholderTextColor.R should be equal to set value");
            Assert.AreEqual(color.G, textField.PlaceholderTextColor.G, "Retrieved PlaceholderTextColor.G should be equal to set value");
            Assert.AreEqual(color.B, textField.PlaceholderTextColor.B, "Retrieved PlaceholderTextColor.B should be equal to set value");
            Assert.AreEqual(color.A, textField.PlaceholderTextColor.A, "Retrieved PlaceholderTextColor.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ShadowOffset. Check whether ShadowOffset is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.ShadowOffset A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ShadowOffset_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            Vector2 offset = new Vector2(1.0f, 1.0f);
            textField.ShadowOffset = offset;
            Assert.AreEqual(offset.X, textField.ShadowOffset.X, "Retrieved ShadowOffset.X should be equal to set value");
            Assert.AreEqual(offset.Y, textField.ShadowOffset.Y, "Retrieved ShadowOffset.Y should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ShadowColor. Check whether ShadowColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.ShadowColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ShadowColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            Vector4 color = new Vector4(0.1f, 0.2f, 0.3f, 0.4f);
            textField.ShadowColor = color;
            Assert.AreEqual(color.R, textField.ShadowColor.R, "Retrieved ShadowColor.R should be equal to set value");
            Assert.AreEqual(color.G, textField.ShadowColor.G, "Retrieved ShadowColor.G should be equal to set value");
            Assert.AreEqual(color.B, textField.ShadowColor.B, "Retrieved ShadowColor.B should be equal to set value");
            Assert.AreEqual(color.A, textField.ShadowColor.A, "Retrieved ShadowColor.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PrimaryCursorColor. Check whether PrimaryCursorColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.PrimaryCursorColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PrimaryCursorColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            Vector4 color = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
            textField.PrimaryCursorColor = color;
            Assert.AreEqual(color.R, textField.PrimaryCursorColor.R, "Retrieved PrimaryCursorColor should be equal to set value");
            Assert.AreEqual(color.G, textField.PrimaryCursorColor.G, "Retrieved PrimaryCursorColor should be equal to set value");
            Assert.AreEqual(color.B, textField.PrimaryCursorColor.B, "Retrieved PrimaryCursorColor should be equal to set value");
            Assert.AreEqual(color.A, textField.PrimaryCursorColor.A, "Retrieved PrimaryCursorColor should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SecondaryCursorColor. Check whether SecondaryCursorColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.SecondaryCursorColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SecondaryCursorColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            Vector4 color = new Vector4(0.1f, 0.2f, 0.3f, 0.4f);
            textField.SecondaryCursorColor = color;
            Assert.AreEqual(color.R, textField.SecondaryCursorColor.R, "Retrieved SecondaryCursorColor.R should be equal to set value");
            Assert.AreEqual(color.G, textField.SecondaryCursorColor.G, "Retrieved SecondaryCursorColor.G should be equal to set value");
            Assert.AreEqual(color.B, textField.SecondaryCursorColor.B, "Retrieved SecondaryCursorColor.B should be equal to set value");
            Assert.AreEqual(color.A, textField.SecondaryCursorColor.A, "Retrieved SecondaryCursorColor.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test EnableCursorBlink. Check whether EnableCursorBlink is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.EnableCursorBlink A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void EnableCursorBlink_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.EnableCursorBlink = true;
            Assert.AreEqual(true, textField.EnableCursorBlink, "Retrieved EnableCursorBlink should be equal to set value");
            textField.EnableCursorBlink = false;
            Assert.AreEqual(false, textField.EnableCursorBlink, "Retrieved EnableCursorBlink should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test CursorBlinkInterval. Check whether CursorBlinkInterval is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.CursorBlinkInterval A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void CursorBlinkInterval_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.CursorBlinkInterval = 1.0f;
            Assert.AreEqual(1.0f, textField.CursorBlinkInterval, "Retrieved CursorBlinkInterval should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test CursorBlinkDuration. Check whether CursorBlinkDuration is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.CursorBlinkDuration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void CursorBlinkDuration_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.CursorBlinkDuration = 10.0f;
            Assert.AreEqual(10.0f, textField.CursorBlinkDuration, "Retrieved CursorBlinkDuration should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test CursorWidth. Check whether CursorWidth is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.CursorWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void CursorWidth_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.CursorWidth = 5;
            Assert.AreEqual(5, textField.CursorWidth, "Retrieved CursorWidth should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetInputMethodContext. Check whether GetInputMethodContext works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.GetInputMethodContext M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void GetInputMethodContext_RETURN_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            var inputMethodContext = textField.GetInputMethodContext();
            Assert.IsInstanceOf<InputMethodContext>(inputMethodContext, "Should be the instance of InputMethodContext Type");
        }

        [Test]
        [Category("P1")]
        [Description("Test GrabHandleImage. Check whether GrabHandleImage is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.GrabHandleImage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GrabHandleImage_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.GrabHandleImage = image_path;
            Assert.AreEqual(image_path, textField.GrabHandleImage, "Retrieved GrabHandleImage should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test GrabHandlePressedImage. Check whether GrabHandlePressedImage is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.GrabHandlePressedImage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GrabHandlePressedImage_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.GrabHandlePressedImage = image_path;
            Assert.AreEqual(image_path, textField.GrabHandlePressedImage, "Retrieved GrabHandlePressedImage should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollThreshold. Check whether ScrollThreshold is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.ScrollThreshold A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ScrollThreshold_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            float scrollThreshold = 0.5f;
            textField.ScrollThreshold = scrollThreshold;
            Assert.AreEqual(scrollThreshold, textField.ScrollThreshold, "Retrieved ScrollThreshold should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollSpeed. Check whether ScrollSpeed is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.ScrollSpeed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ScrollSpeed_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            float scrollSpeed = 0.5f;
            textField.ScrollSpeed = scrollSpeed;
            Assert.AreEqual(scrollSpeed, textField.ScrollSpeed, "Retrieved ScrollSpeed should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectionHandleImageLeft. Check whether SelectionHandleImageLeft is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.SelectionHandleImageLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectionHandleImageLeft_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            PropertyMap map = new PropertyMap();
            PropertyValue value = new PropertyValue("SelectionHandleImageLeft");
            map.Add("filename", value);
            textField.SelectionHandleImageLeft = map;
            string str1, str2;
            map.Find(0, "filename").Get(out str1);
            textField.SelectionHandleImageLeft.Find(0, "filename").Get(out str2);
            Assert.AreEqual(str1, str2, "Retrieved SelectionHandleImageLeft should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectionHandleImageRight. Check whether SelectionHandleImageRight is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.SelectionHandleImageRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectionHandleImageRight_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            PropertyMap map = new PropertyMap();
            PropertyValue value = new PropertyValue("SelectionHandleImageRight");
            map.Add("filename", value);
            textField.SelectionHandleImageRight = map;
            string str1, str2;
            map.Find(0, "filename").Get(out str1);
            textField.SelectionHandleImageRight.Find(0, "filename").Get(out str2);
            Assert.AreEqual(str1, str2, "Retrieved SelectionHandleImageRight should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectionHandlePressedImageLeft. Check whether SelectionHandlePressedImageLeft is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.SelectionHandlePressedImageLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectionHandlePressedImageLeft_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            PropertyMap map = new PropertyMap();
            PropertyValue value = new PropertyValue("SelectionHandlePressedImageLeft");
            map.Add("filename", value);
            textField.SelectionHandlePressedImageLeft = map;
            string str1, str2;
            map.Find(0, "filename").Get(out str1);
            textField.SelectionHandlePressedImageLeft.Find(0, "filename").Get(out str2);
            Assert.AreEqual(str1, str2, "Retrieved SelectionHandlePressedImageLeft should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectionHandlePressedImageRight. Check whether SelectionHandlePressedImageRight is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.SelectionHandlePressedImageRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectionHandlePressedImageRight_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            PropertyMap map = new PropertyMap();
            PropertyValue value = new PropertyValue("SelectionHandlePressedImageRight");
            map.Add("filename", value);
            textField.SelectionHandlePressedImageRight = map;
            string str1, str2;
            map.Find(0, "filename").Get(out str1);
            textField.SelectionHandlePressedImageRight.Find(0, "filename").Get(out str2);
            Assert.AreEqual(str1, str2, "Retrieved SelectionHandlePressedImageRight should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectionHandleMarkerImageLeft. Check whether SelectionHandleMarkerImageLeft is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.SelectionHandleMarkerImageLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectionHandleMarkerImageLeft_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            PropertyMap map = new PropertyMap();
            PropertyValue value = new PropertyValue("SelectionHandleMarkerImageLeft");
            map.Add("filename", value);
            textField.SelectionHandleMarkerImageLeft = map;
            string str1, str2;
            map.Find(0, "filename").Get(out str1);
            textField.SelectionHandleMarkerImageLeft.Find(0, "filename").Get(out str2);
            Assert.AreEqual(str1, str2, "Retrieved SelectionHandleMarkerImageLeft should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectionHandleMarkerImageRight. Check whether SelectionHandleMarkerImageRight is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.SelectionHandleMarkerImageRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectionHandleMarkerImageRight_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            PropertyMap map = new PropertyMap();
            PropertyValue value = new PropertyValue("SelectionHandleMarkerImageRight");
            map.Add("filename", value);
            textField.SelectionHandleMarkerImageRight = map;
            string str1, str2;
            map.Find(0, "filename").Get(out str1);
            textField.SelectionHandleMarkerImageRight.Find(0, "filename").Get(out str2);
            Assert.AreEqual(str1, str2, "Retrieved SelectionHandleMarkerImageRight should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectionHighlightColor. Check whether SelectionHighlightColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.SelectionHighlightColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectionHighlightColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            Vector4 color = new Vector4(0.1f, 0.2f, 0.3f, 0.4f);
            textField.SelectionHighlightColor = color;
            Assert.AreEqual(color.R, textField.SelectionHighlightColor.R, "Retrieved GrabHandlePressedImage.R should be equal to set value");
            Assert.AreEqual(color.G, textField.SelectionHighlightColor.G, "Retrieved GrabHandlePressedImage.G should be equal to set value");
            Assert.AreEqual(color.B, textField.SelectionHighlightColor.B, "Retrieved GrabHandlePressedImage.B should be equal to set value");
            Assert.AreEqual(color.A, textField.SelectionHighlightColor.A, "Retrieved GrabHandlePressedImage.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test DecorationBoundingBox. Check whether DecorationBoundingBox is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.DecorationBoundingBox A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void DecorationBoundingBox_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            Rectangle temp = new Rectangle(0, 0, 1, 1);
            textField.DecorationBoundingBox = temp;
            Assert.AreEqual(temp.X, textField.DecorationBoundingBox.X, "Retrieved DecorationBoundingBox.x should be equal to set value");
            Assert.AreEqual(temp.Y, textField.DecorationBoundingBox.Y, "Retrieved DecorationBoundingBox.y should be equal to set value");
            Assert.AreEqual(temp.Width, textField.DecorationBoundingBox.Width, "Retrieved DecorationBoundingBox.width should be equal to set value");
            Assert.AreEqual(temp.Height, textField.DecorationBoundingBox.Height, "Retrieved DecorationBoundingBox.height should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputColor. Check whether InputColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.InputColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            Vector4 color = new Vector4(0.1f, 0.2f, 0.3f, 0.4f);
            textField.InputColor = color;
            Assert.AreEqual(color.R, textField.InputColor.R, "Retrieved InputColor.R should be equal to set value");
            Assert.AreEqual(color.G, textField.InputColor.G, "Retrieved InputColor.G should be equal to set value");
            Assert.AreEqual(color.B, textField.InputColor.B, "Retrieved InputColor.B should be equal to set value");
            Assert.AreEqual(color.A, textField.InputColor.A, "Retrieved InputColor.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test EnableMarkup. Check whether EnableMarkup is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.EnableMarkup A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void EnableMarkup_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.EnableMarkup = true;
            Assert.AreEqual(true, textField.EnableMarkup, "Retrieved EnableMarkup should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputFontFamily. Check whether InputFontFamily is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.InputFontFamily A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputFontFamily_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.InputFontFamily = "test InputFontFamily";
            Assert.AreEqual("test InputFontFamily", textField.InputFontFamily, "Retrieved InputFontFamily should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputFontStyle. Check whether InputFontStyle is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.InputFontStyle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputFontStyle_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            PropertyMap map = new PropertyMap();
            map.Clear();
            PropertyValue value = new PropertyValue("bold");
            map.Add("weight", value);
            value = new PropertyValue("condensed");
            map.Add("width", value);
            value = new PropertyValue("italic");
            map.Add("slant", value);
            textField.InputFontStyle = map;
            Assert.AreEqual(map.Count(), textField.InputFontStyle.Count(), "Retrieved InputFontStyle should be equal to set value");
            string str1, str2;
            for (uint index = 0u; index < map.Count(); index++)
            {
                map.GetValue(index).Get(out str1);
                textField.InputFontStyle.GetValue(index).Get(out str2);
                Assert.AreEqual(str1, str2, index + " : should be equals to the set value");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test InputPointSize. Check whether InputPointSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.InputPointSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputPointSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.InputPointSize = 0.5f;
            Assert.AreEqual(0.5f, textField.InputPointSize, "Retrieved InputPointSize should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Underline. Check whether Underline is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.Underline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Underline_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            PropertyMap map = new PropertyMap();
            map.Clear();
            PropertyValue value = new PropertyValue(true);
            map.Insert("enable", value);
            value = new PropertyValue(new Vector4(1.0f, 0.0f, 0.0f, 1.0f));
            map.Insert("color", value);
            value = new PropertyValue(0.1f);
            map.Insert("height", value);
            textField.Underline = map;
            Assert.AreEqual(map.Count(), textField.Underline.Count(), "Retrieved Underline' count should be equal to set value");

            bool enable = false;
            Vector4 color = new Vector4();
            float height = 0.0f;
            textField.Underline.Find(0, "enable").Get(out enable);
            textField.Underline.Find(0, "color").Get(color);
            textField.Underline.Find(0, "height").Get(out height);

            Assert.AreEqual(true, enable, "enable : should be equals to the set value");
            Assert.AreEqual(1.0f, color.R, "color : should be equals to the set value");
            Assert.AreEqual(0.1f, height, "height : should be equals to the set value");
        }

#if false // currently ACR is not yet proceed. temporarily blocked.
        //[Test]
        //[Category("P1")]
        //[Description("Test HiddenInputSettings. Check whether HiddenInputSettings is readable and writable.")]
        //[Property("SPEC", "Tizen.NUI.BaseComponents.TextField.HiddenInputSettings A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Youxia Wu, youxia17.wu@samsung.com")]
        public void HiddenInputSettings_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textFiled = new TextField();
            PropertyMap hiddenMapSet = new PropertyMap();
            PropertyMap hiddenMapGet = new PropertyMap();
            hiddenMapSet.Add(HiddenInputProperty.Mode, new PropertyValue((int)HiddenInputModeType.HideAll));
            hiddenMapSet.Add(HiddenInputProperty.ShowDuration, new PropertyValue(2));
            hiddenMapSet.Add(HiddenInputProperty.SubstituteCount, new PropertyValue(4));
            hiddenMapSet.Add(HiddenInputProperty.SubstituteCharacter, new PropertyValue(0x23));
            textFiled.HiddenInputSettings = hiddenMapSet;

            hiddenMapGet = textFiled.HiddenInputSettings;
            Assert.AreEqual(hiddenMapSet.Count(), hiddenMapGet.Count(), "Retrieved HiddenInputSettings's count should be equal to set value");
            int value_set = 0, value_get = 0;
            hiddenMapSet.Find(HiddenInputProperty.Mode).Get(out value_set);
            hiddenMapGet.Find(HiddenInputProperty.Mode).Get(out value_get);
            Assert.AreEqual(value_set, value_get, "Retrieved Mode should be equal to set value");
            hiddenMapSet.Find(HiddenInputProperty.ShowDuration).Get(out value_set);
            hiddenMapGet.Find(HiddenInputProperty.ShowDuration).Get(out value_get);
            Assert.AreEqual(value_set, value_get, "Retrieved ShowDuration should be equal to set value");
            hiddenMapSet.Find(HiddenInputProperty.SubstituteCount).Get(out value_set);
            hiddenMapGet.Find(HiddenInputProperty.SubstituteCount).Get(out value_get);
            Assert.AreEqual(value_set, value_get, "Retrieved SubstituteCount should be equal to set value");
            Int32 set_value, get_value = 0;
            hiddenMapSet.Find(HiddenInputProperty.SubstituteCharacter).Get(out set_value);
            hiddenMapGet.Find(HiddenInputProperty.SubstituteCharacter).Get(out get_value);
            Assert.AreEqual(set_value, get_value, "Retrieved SubstituteCharacter should be equal to set value");
        }
#endif
        [Test]
        [Category("P1")]
        [Description("Test Shadow. Check whether Shadow is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.Shadow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Shadow_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            Window.Instance.Add(textField);

            PropertyMap map = new PropertyMap();
            map.Add("color", new PropertyValue("green"));
            map.Add("offset", new PropertyValue("2 2"));
            map.Add("blurRadius", new PropertyValue(0.0f));

            textField.Shadow = map;

            Tizen.Log.Debug("NUI", $"map.Count()={map.Count()}, textField.Shadow.Count()={textField.Shadow.Count()}");
            Assert.AreEqual(map.Count(), textField.Shadow.Count(), "Retrieved Shadow's count should be equal to set value");

            Vector4 color = new Vector4();
            textField.Shadow.GetValue(0).Get(color);
            Tizen.Log.Debug("NUI", $"color r={color.R}, g={color.G}, b={color.B}, a={color.A}");
            Assert.IsTrue(color.R == 0 && color.G == 1 && color.B == 0 && color.A == 1);

            Vector2 offset = new Vector2();
            textField.Shadow.GetValue(1).Get(offset);
            Tizen.Log.Fatal("NUI", $"offset x={offset.X}, y={offset.Y}");
            Assert.IsTrue(offset.X == 2 && offset.Y == 2);

            float blurRadius = -1.0f;
            textField.Shadow.GetValue(2).Get(out blurRadius);
            Tizen.Log.Fatal("NUI", $"blurRadius={blurRadius}");
            Assert.IsTrue(blurRadius == 0);
        }

        [Test]
        [Category("P1")]
        [Description("Test InputMethodSettings. Check whether InputMethodSettings is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.InputMethodSettings A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputMethodSettings_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            PropertyMap map = new PropertyMap();
            PropertyValue value = new PropertyValue(10);
            map.Add("PANEL_LAYOUT", value);
            textField.InputMethodSettings = map;
            int value_in = 0, value_out = 0;
            map.Find(0, "PANEL_LAYOUT").Get(out value_in);
            textField.InputMethodSettings.Find(0, "PANEL_LAYOUT").Get(out value_out);
            Assert.AreEqual(value_in, value_out, "Retrieved InputMethodSettings should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputUnderline. Check whether InputUnderline is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.InputUnderline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputUnderline_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.InputUnderline = "Underline input properties";
            Assert.AreEqual("Underline input properties", textField.InputUnderline, "InputShadow is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputShadow. Check whether InputShadow is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.InputShadow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputShadow_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.InputShadow = "Shadow input properties";
            Assert.AreEqual("Shadow input properties", textField.InputShadow, "InputShadow is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Emboss. Check whether Emboss is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.Emboss A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Emboss_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textFiled = new TextField();
            textFiled.Emboss = "Text Emboss";
            Assert.AreEqual("Text Emboss", textFiled.Emboss, "Retrieved Emboss should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputEmboss. Check whether InputEmboss is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.InputEmboss A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputEmboss_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textFiled = new TextField();
            textFiled.InputEmboss = "Text Input Emboss";
            Assert.AreEqual("Text Input Emboss", textFiled.InputEmboss, "Retrieved InputEmboss should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputOutline. Check whether InputOutline is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.InputOutline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputOutline_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textFiled = new TextField();
            textFiled.InputOutline = "Text Input Outline";
            Assert.AreEqual("Text Input Outline", textFiled.InputOutline, "Retrieved InputOutline should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Outline. Check whether Outline is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.Outline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Outline_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField text = new TextField();
            PropertyMap outlineMapSet = new PropertyMap();
            outlineMapSet.Add("color", new PropertyValue(Color.Red));
            outlineMapSet.Add("width", new PropertyValue(2.0f));
            text.Outline = outlineMapSet;

            PropertyMap propertyMap = text.Outline;
            Vector4 color = new Vector4();
            bool ret = (propertyMap.Find(0, "color")).Get(color);
            Assert.AreEqual(Color.Red.R, color.R, "Should be equals to the set value of width");
            Assert.AreEqual(Color.Red.G, color.G, "Should be equals to the set value of width");
            Assert.AreEqual(Color.Red.B, color.B, "Should be equals to the set value of width");
            Assert.AreEqual(Color.Red.A, color.A, "Should be equals to the set value of width");

            int width = 0;
            ret = (propertyMap.Find(1, "width")).Get(out width);
            Assert.AreEqual(2, width, "Should be equals to the set value of width");
        }

        [Test]
        [Category("P1")]
        [Description("Test PixelSize. Check whether PixelSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.PixelSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PixelSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.PixelSize = 20.0f;
            Assert.AreEqual(20.0f, textField.PixelSize, 0.0001f, "Retrieved PixelSize should be equals to the set value");

        }

        [Test]
        [Category("P1")]
        [Description("Test EnableShiftSelection. Check whether EnableShiftSelection is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.EnableShiftSelection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EnableShiftSelection_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextField textField = new TextField();
            textField.EnableShiftSelection = true;
            Assert.IsTrue(textField.EnableShiftSelection, "The value of textField.EnableShiftSelection should be true");
            textField.EnableShiftSelection = false;
            Assert.IsFalse(textField.EnableShiftSelection, "The value of textField.EnableShiftSelection should be false");
        }

        [Test]
        [Category("P1")]
        [Description("Test TextChanged.Check whether TextChanged defined in the spec is callable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.TextChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextChanged_CHECK_EVENT()
        {
            TextField textFiled = new TextField();
            textFiled.Text = "add";
            Window.Instance.GetDefaultLayer().Add(textFiled);
            bool flag = false;
            textFiled.TextChanged += (obj, e) =>
            {
                flag = true;
            };
            textFiled.Text = "add 1";
            Assert.IsTrue(flag, "TextChanged is not be called");
        }

        [Test]
        [Category("P1")]
        [Description("Test MaxLengthReached.Check whether MaxLengthReached defined in the spec is callable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.MaxLengthReached E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void MaxLengthReached_CHECK_EVENT()
        {
            TextField textFiled = new TextField();
            textFiled.MaxLength = 5;
            textFiled.Text = "12345";
            Window.Instance.GetDefaultLayer().Add(textFiled);
            bool flag = false;
            textFiled.TextChanged += (obj, e) =>
            {
                flag = true;
            };
            textFiled.Text = "123456789";
            Assert.IsTrue(flag, "MaxLengthReached is not be called");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the TextField.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                TextField textField = new TextField();
                textField.Dispose();
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
        [Description("Test MatchSystemLanguageDirectionProperty. Check whether MatchSystemLanguageDirectionProperty(BindableProperty) is working correctly or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.MatchSystemLanguageDirectionProperty A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void MatchSystemLanguageDirectionProperty_CHECK_VALUE()
        {
            var textField = new TextField();
            Assert.IsNotNull(textField, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(textField, "Should be an instance of TextField type.");

            textField.MatchSystemLanguageDirection = false;
            Assert.AreEqual(false, textField.MatchSystemLanguageDirection, "should be same");

            textField.MatchSystemLanguageDirection = true;
            Assert.AreEqual(true, textField.MatchSystemLanguageDirection, "should be same");
        }

        [Test]
        [Category("P1")]
        [Description("Test MatchSystemLanguageDirection. Check whether MatchSystemLanguageDirection is working correctly or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextField.MatchSystemLanguageDirection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void MatchSystemLanguageDirection_CHECK_VALUE()
        {
            var textField = new TextField();
            Assert.IsNotNull(textField, "Can't create success object TextField");
            Assert.IsInstanceOf<TextField>(textField, "Should be an instance of TextField type.");

            textField.MatchSystemLanguageDirection = false;
            bool ret = textField.MatchSystemLanguageDirection;
            Assert.AreEqual(false, ret, "should be same");

            textField.MatchSystemLanguageDirection = true;
            ret = textField.MatchSystemLanguageDirection;
            Assert.AreEqual(true, ret, "should be same");
        }
    }
}
