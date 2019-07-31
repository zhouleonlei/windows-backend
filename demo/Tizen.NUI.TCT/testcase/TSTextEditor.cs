using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.TextEditor Tests")]
    public class TextEditorTests
    {
        private string TAG = "NUI";
        private bool _flagScrollStateChanged = false;
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("TextEditorTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        private void OnScrollStateChanged(object sender, EventArgs e)
        {
            _flagScrollStateChanged = true;
        }

        [Test]
        [Category("P1")]
        [Description("Create a TextEditor object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.TextEditor C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextEditor_INIT()
        {
            /* TEST CODE */
            var textEditor = new TextEditor();
            Assert.IsNotNull(textEditor, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(textEditor, "Should be an instance of TextEditor type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Text. Check whether Text is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.Text A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Text_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.Text = "test Text";
            Assert.AreEqual("test Text", textEditor.Text, "Retrieved Text should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test TextColor. Check whether TextColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.TextColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            Vector4 color = new Vector4(0.1f, 0.2f, 0.3f, 0.4f);
            textEditor.TextColor = color;
            Assert.AreEqual(color.R, textEditor.TextColor.R, "Retrieved TextColor should be equal to set value");
            Assert.AreEqual(color.G, textEditor.TextColor.G, "Retrieved TextColor should be equal to set value");
            Assert.AreEqual(color.B, textEditor.TextColor.B, "Retrieved TextColor should be equal to set value");
            Assert.AreEqual(color.A, textEditor.TextColor.A, "Retrieved TextColor should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test FontFamily. Check whether FontFamily is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.FontFamily A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void FontFamily_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.FontFamily = "test FontFamily";
            Assert.AreEqual("test FontFamily", textEditor.FontFamily, "Retrieved FontFamily should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test FontStyle. Check whether FontStyle is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.FontStyle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void FontStyle_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            PropertyMap map = new PropertyMap();
            map.Clear();
            PropertyValue value = new PropertyValue("bold");
            map.Insert("weight", value);
            value = new PropertyValue("condensed");
            map.Insert("width", value);
            value = new PropertyValue("italic");
            map.Insert("slant", value);
            textEditor.FontStyle = map;

            //This is for MDC-Solis TCT: MCD-Solis has different fonts installed so it needs seperated test case. (There is no condition or definition for specific target) 
            if(map.Count() != textEditor.FontStyle.Count())
            {
                map.Clear();
                value = new PropertyValue("bold");
                map.Insert("weight", value);
                value = new PropertyValue("normal");
                map.Insert("width", value);
                value = new PropertyValue("italic");
                map.Insert("slant", value);
                textEditor.FontStyle = map;
            }

            Assert.AreEqual(map.Count(), textEditor.FontStyle.Count(), "Retrieved FontStyle should be equal to set value");
            string str1, str2;
            for (uint index = 0u; index < map.Count(); index++)
            {
                map.GetValue(index).Get(out str1);
                textEditor.FontStyle.GetValue(index).Get(out str2);
                Assert.AreEqual(str1, str2, index + " : should be equals to the set value");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test PointSize. Check whether PointSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.PointSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PointSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            float size = 0.5f;
            textEditor.PointSize = size;
            Assert.AreEqual(size, textEditor.PointSize, "Retrieved PointSize should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test HorizontalAlignment. Check whether HorizontalAlignment is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.HorizontalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void HorizontalAlignment_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.HorizontalAlignment = HorizontalAlignment.End;
            Assert.AreEqual(HorizontalAlignment.End, textEditor.HorizontalAlignment, "Retrieved HorizontalAlignment should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollThreshold. Check whether ScrollThreshold is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.ScrollThreshold A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ScrollThreshold_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            float scrollThreshold = 0.5f;
            textEditor.ScrollThreshold = scrollThreshold;
            Assert.AreEqual(scrollThreshold, textEditor.ScrollThreshold, "Retrieved ScrollThreshold should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollSpeed. Check whether ScrollSpeed is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.ScrollSpeed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ScrollSpeed_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            float scrollSpeed = 0.5f;
            textEditor.ScrollSpeed = scrollSpeed;
            Assert.AreEqual(scrollSpeed, textEditor.ScrollSpeed, "Retrieved ScrollSpeed should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PrimaryCursorColor. Check whether PrimaryCursorColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.PrimaryCursorColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PrimaryCursorColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            Vector4 color = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
            textEditor.PrimaryCursorColor = color;
            Assert.AreEqual(color.R, textEditor.PrimaryCursorColor.R, "Retrieved PrimaryCursorColor should be equal to set value");
            Assert.AreEqual(color.G, textEditor.PrimaryCursorColor.G, "Retrieved PrimaryCursorColor should be equal to set value");
            Assert.AreEqual(color.B, textEditor.PrimaryCursorColor.B, "Retrieved PrimaryCursorColor should be equal to set value");
            Assert.AreEqual(color.A, textEditor.PrimaryCursorColor.A, "Retrieved PrimaryCursorColor should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SecondaryCursorColor. Check whether SecondaryCursorColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.SecondaryCursorColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SecondaryCursorColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            Vector4 color = new Vector4(0.1f, 0.2f, 0.3f, 0.4f);
            textEditor.SecondaryCursorColor = color;
            Assert.AreEqual(color.R, textEditor.SecondaryCursorColor.R, "Retrieved SecondaryCursorColor.R should be equal to set value");
            Assert.AreEqual(color.G, textEditor.SecondaryCursorColor.G, "Retrieved SecondaryCursorColor.G should be equal to set value");
            Assert.AreEqual(color.B, textEditor.SecondaryCursorColor.B, "Retrieved SecondaryCursorColor.B should be equal to set value");
            Assert.AreEqual(color.A, textEditor.SecondaryCursorColor.A, "Retrieved SecondaryCursorColor.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test EnableCursorBlink. Check whether EnableCursorBlink is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.EnableCursorBlink A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void EnableCursorBlink_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.EnableCursorBlink = true;
            Assert.AreEqual(true, textEditor.EnableCursorBlink, "Retrieved EnableCursorBlink should be equal to set value");
            textEditor.EnableCursorBlink = false;
            Assert.AreEqual(false, textEditor.EnableCursorBlink, "Retrieved EnableCursorBlink should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test CursorBlinkDuration. Check whether CursorBlinkDuration is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.CursorBlinkDuration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void CursorBlinkDuration_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.CursorBlinkDuration = 0.5f;
            Assert.AreEqual(0.5f, textEditor.CursorBlinkDuration, "Retrieved CursorBlinkDuration should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test CursorBlinkInterval. Check whether CursorBlinkInterval is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.CursorBlinkInterval A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void CursorBlinkInterval_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.CursorBlinkInterval = 0.5f;
            Assert.AreEqual(0.5f, textEditor.CursorBlinkInterval, "Retrieved CursorBlinkInterval should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test CursorWidth. Check whether CursorWidth is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.CursorWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void CursorWidth_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.CursorWidth = 1;
            Assert.AreEqual(1, textEditor.CursorWidth, "Retrieved CursorWidth should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetInputMethodContext. Check whether GetInputMethodContext works or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.GetInputMethodContext M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void GetInputMethodContext_RETURN_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            var inputMethodContext = textEditor.GetInputMethodContext();
            Assert.IsInstanceOf<InputMethodContext>(inputMethodContext, "Should be the instance of InputMethodContext Type");
        }

        [Test]
        [Category("P1")]
        [Description("Test GrabHandleImage. Check whether GrabHandleImage is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.GrabHandleImage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GrabHandleImage_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.GrabHandleImage = image_path;
            Assert.AreEqual(image_path, textEditor.GrabHandleImage, "Retrieved GrabHandleImage should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test GrabHandlePressedImage. Check whether GrabHandlePressedImage is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.GrabHandlePressedImage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void GrabHandlePressedImage_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.GrabHandlePressedImage = image_path;
            Assert.AreEqual(image_path, textEditor.GrabHandlePressedImage, "Retrieved GrabHandlePressedImage should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectionHandleImageLeft. Check whether SelectionHandleImageLeft is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.SelectionHandleImageLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectionHandleImageLeft_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            PropertyMap map = new PropertyMap();
            PropertyValue value = new PropertyValue("SelectionHandleImageLeft");
            map.Add("filename", value);
            textEditor.SelectionHandleImageLeft = map;
            string str1, str2;
            map.Find(0, "filename").Get(out str1);
            textEditor.SelectionHandleImageLeft.Find(0, "filename").Get(out str2);
            Assert.AreEqual(str1, str2, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectionHandleImageRight. Check whether SelectionHandleImageRight is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.SelectionHandleImageRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectionHandleImageRight_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            PropertyMap map = new PropertyMap();
            PropertyValue value = new PropertyValue("SelectionHandleImageRight");
            map.Add("filename", value);
            textEditor.SelectionHandleImageRight = map;
            string str1, str2;
            map.Find(0, "filename").Get(out str1);
            textEditor.SelectionHandleImageRight.Find(0, "filename").Get(out str2);
            Assert.AreEqual(str1, str2, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectionHandlePressedImageLeft. Check whether SelectionHandlePressedImageLeft is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.SelectionHandlePressedImageLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectionHandlePressedImageLeft_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            PropertyMap map = new PropertyMap();
            PropertyValue value = new PropertyValue("SelectionHandlePressedImageLeft");
            map.Add("filename", value);
            textEditor.SelectionHandlePressedImageLeft = map;
            string str1, str2;
            map.Find(0, "filename").Get(out str1);
            textEditor.SelectionHandlePressedImageLeft.Find(0, "filename").Get(out str2);
            Assert.AreEqual(str1, str2, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectionHandlePressedImageRight. Check whether SelectionHandlePressedImageRight is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.SelectionHandlePressedImageRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectionHandlePressedImageRight_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            PropertyMap map = new PropertyMap();
            PropertyValue value = new PropertyValue("SelectionHandlePressedImageRight");
            map.Add("filename", value);
            textEditor.SelectionHandlePressedImageRight = map;
            string str1, str2;
            map.Find(0, "filename").Get(out str1);
            textEditor.SelectionHandlePressedImageRight.Find(0, "filename").Get(out str2);
            Assert.AreEqual(str1, str2, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectionHandleMarkerImageLeft. Check whether SelectionHandleMarkerImageLeft is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.SelectionHandleMarkerImageLeft A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectionHandleMarkerImageLeft_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            PropertyMap map = new PropertyMap();
            PropertyValue value = new PropertyValue("SelectionHandleMarkerImageLeft");
            map.Add("filename", value);
            textEditor.SelectionHandleMarkerImageLeft = map;
            string str1, str2;
            map.Find(0, "filename").Get(out str1);
            textEditor.SelectionHandleMarkerImageLeft.Find(0, "filename").Get(out str2);
            Assert.AreEqual(str1, str2, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectionHandleMarkerImageRight. Check whether SelectionHandleMarkerImageRight is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.SelectionHandleMarkerImageRight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectionHandleMarkerImageRight_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            PropertyMap map = new PropertyMap();
            PropertyValue value = new PropertyValue("SelectionHandleMarkerImageRight");
            map.Add("filename", value);
            textEditor.SelectionHandleMarkerImageRight = map;
            string str1, str2;
            map.Find(0, "filename").Get(out str1);
            textEditor.SelectionHandleMarkerImageRight.Find(0, "filename").Get(out str2);
            Assert.AreEqual(str1, str2, "Should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SelectionHighlightColor. Check whether SelectionHighlightColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.SelectionHighlightColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void SelectionHighlightColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            Vector4 color = new Vector4(0.1f, 0.2f, 0.3f, 0.4f);
            textEditor.SelectionHighlightColor = color;
            Assert.AreEqual(color.R, textEditor.SelectionHighlightColor.R, "Retrieved GrabHandlePressedImage should be equal to set value");
            Assert.AreEqual(color.G, textEditor.SelectionHighlightColor.G, "Retrieved GrabHandlePressedImage should be equal to set value");
            Assert.AreEqual(color.B, textEditor.SelectionHighlightColor.B, "Retrieved GrabHandlePressedImage should be equal to set value");
            Assert.AreEqual(color.A, textEditor.SelectionHighlightColor.A, "Retrieved GrabHandlePressedImage should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test DecorationBoundingBox. Check whether DecorationBoundingBox is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.DecorationBoundingBox A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void DecorationBoundingBox_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            Rectangle temp = new Rectangle(0, 0, 1, 1);
            textEditor.DecorationBoundingBox = temp;
            Assert.AreEqual(temp.X, textEditor.DecorationBoundingBox.X, "Retrieved DecorationBoundingBox.x should be equal to set value");
            Assert.AreEqual(temp.Y, textEditor.DecorationBoundingBox.Y, "Retrieved DecorationBoundingBox.y should be equal to set value");
            Assert.AreEqual(temp.Width, textEditor.DecorationBoundingBox.Width, "Retrieved DecorationBoundingBox.width should be equal to set value");
            Assert.AreEqual(temp.Height, textEditor.DecorationBoundingBox.Height, "Retrieved DecorationBoundingBox.height should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test EnableMarkup. Check whether EnableMarkup is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.EnableMarkup A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void EnableMarkup_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.EnableMarkup = true;
            Assert.AreEqual(true, textEditor.EnableMarkup, "Retrieved EnableMarkup should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputColor. Check whether InputColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.InputColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            Vector4 color = new Vector4(0.1f, 0.2f, 0.3f, 0.4f);
            textEditor.InputColor = color;
            Assert.AreEqual(color.R, textEditor.InputColor.R, "Retrieved InputColor should be equal to set value");
            Assert.AreEqual(color.G, textEditor.InputColor.G, "Retrieved InputColor should be equal to set value");
            Assert.AreEqual(color.B, textEditor.InputColor.B, "Retrieved InputColor should be equal to set value");
            Assert.AreEqual(color.A, textEditor.InputColor.A, "Retrieved InputColor should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputFontFamily. Check whether InputFontFamily is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.InputFontFamily A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputFontFamily_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.InputFontFamily = "test InputFontFamily";
            Assert.AreEqual("test InputFontFamily", textEditor.InputFontFamily, "Retrieved InputFontFamily should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputFontStyle. Check whether InputFontStyle's count is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.InputFontStyle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputFontStyle_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            PropertyMap map = new PropertyMap();
            map.Clear();
            PropertyValue value = new PropertyValue("bold");
            map.Insert("weight", value);
            value = new PropertyValue("condensed");
            map.Insert("width", value);
            value = new PropertyValue("italic");
            map.Insert("slant", value);
            textEditor.InputFontStyle = map;
            Assert.AreEqual(map.Count(), textEditor.InputFontStyle.Count(), "Retrieved InputFontStyle's count should be equal to set value");
            string str1, str2;
            for (uint index = 0u; index < map.Count(); index++)
            {
                map.GetValue(index).Get(out str1);
                textEditor.InputFontStyle.GetValue(index).Get(out str2);
                Assert.AreEqual(str1, str2, index + " : should be equals to the set value");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test InputPointSize. Check whether InputPointSize's count is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.InputPointSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputPointSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.InputPointSize = 0.5f;
            Assert.AreEqual(0.5f, textEditor.InputPointSize, "Retrieved InputPointSize's count should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test LineSpacing. Check whether LineSpacing is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.LineSpacing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void LineSpacing_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.LineSpacing = 0.5f;
            Assert.AreEqual(0.5f, textEditor.LineSpacing, "Retrieved LineSpacing's count should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputLineSpacing. Check whether InputLineSpacing is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.InputLineSpacing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputLineSpacing_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.InputLineSpacing = 0.5f;
            Assert.AreEqual(0.5f, textEditor.InputLineSpacing, "Retrieved InputLineSpacing's count should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Underline. Check whether Underline is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.Underline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Underline_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            PropertyMap map = new PropertyMap();
            map.Clear();
            PropertyValue value = new PropertyValue(true);
            map.Insert("enable", value);
            value = new PropertyValue(new Vector4(1.0f, 0.0f, 0.0f, 1.0f));
            map.Insert("color", value);
            value = new PropertyValue(0.1f);
            map.Insert("height", value);
            textEditor.Underline = map;
            Assert.AreEqual(map.Count(), textEditor.Underline.Count(), "Retrieved Underline's count should be equal to set value");

            bool enable = false;
            Vector4 color = new Vector4();
            float height = 0.0f;
            textEditor.Underline.Find(0, "enable").Get(out enable);
            textEditor.Underline.Find(0, "color").Get(color);
            textEditor.Underline.Find(0, "height").Get(out height);

            Assert.AreEqual(true, enable, "enable : should be equals to the set value");
            Assert.AreEqual(1.0f, color.R, "color : should be equals to the set value");
            Assert.AreEqual(0.1f, height, "height : should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Shadow. Check whether Shadow is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.Shadow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Shadow_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            PropertyMap map = new PropertyMap();
            map.Add("color", new PropertyValue("green"));
            map.Add("offset", new PropertyValue("2 2"));
            map.Add("blurRadius", new PropertyValue(0.0f));

            textEditor.Shadow = map;

            Tizen.Log.Debug("NUI", $"map.Count()={map.Count()}, textEditor.Shadow.Count()={textEditor.Shadow.Count()}");
            Assert.AreEqual(map.Count(), textEditor.Shadow.Count(), "Retrieved Shadow's count should be equal to set value");

            Vector4 color = new Vector4();
            textEditor.Shadow.GetValue(0).Get(color);
            Tizen.Log.Debug("NUI", $"color r={color.R}, g={color.G}, b={color.B}, a={color.A}");
            Assert.IsTrue(color.R == 0 && color.G == 1 && color.B == 0 && color.A == 1);

            Vector2 offset = new Vector2();
            textEditor.Shadow.GetValue(1).Get(offset);
            Tizen.Log.Fatal("NUI", $"offset x={offset.X}, y={offset.Y}");
            Assert.IsTrue(offset.X == 2 && offset.Y == 2);

            float blurRadius = -1.0f;
            textEditor.Shadow.GetValue(2).Get(out blurRadius);
            Tizen.Log.Fatal("NUI", $"blurRadius={blurRadius}");
            Assert.IsTrue(blurRadius == 0);
        }

        [Test]
        [Category("P1")]
        [Description("Test InputUnderline. Check whether InputUnderline is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.InputUnderline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputUnderline_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.InputUnderline = "Underline input properties";
            Assert.AreEqual("Underline input properties", textEditor.InputUnderline, "InputUnderline is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputShadow. Check whether InputShadow is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.InputShadow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputShadow_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.InputShadow = "Shadow input properties";
            Assert.AreEqual("Shadow input properties", textEditor.InputShadow, "InputShadow is not correct here!");

        }

        [Test]
        [Category("P1")]
        [Description("Test Emboss. Check whether Emboss is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.Emboss A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Emboss_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.Emboss = "Text Emboss";
            Assert.AreEqual("Text Emboss", textEditor.Emboss, "Retrieved Emboss should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputEmboss. Check whether InputEmboss is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.InputEmboss A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputEmboss_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.InputEmboss = "Text Input Emboss";
            Assert.AreEqual("Text Input Emboss", textEditor.InputEmboss, "Retrieved InputEmboss should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test InputOutline. Check whether InputOutline is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.InputOutline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void InputOutline_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.InputOutline = "Text Input Outline";
            Assert.AreEqual("Text Input Outline", textEditor.InputOutline, "Retrieved InputOutline should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Outline. Check whether Outline is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.Outline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Outline_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            PropertyMap outlineMapSet = new PropertyMap();
            outlineMapSet.Add("color", new PropertyValue(Color.Red));
            outlineMapSet.Add("width", new PropertyValue(2.0f));
            textEditor.Outline = outlineMapSet;

            PropertyMap propertyMap = textEditor.Outline;
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
        [Description("Test EnableScrollBar. Check whether EnableScrollBar is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.EnableScrollBar A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EnableScrollBar_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.EnableScrollBar = false;
            Assert.IsFalse(textEditor.EnableScrollBar, "Retrieved EnableScrollBar should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PixelSize. Check whether PixelSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.PixelSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PixelSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.PixelSize = 20.0f;
            Assert.AreEqual(20.0f, textEditor.PixelSize, 0.0001f, "Retrieved PixelSize should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollBarFadeDuration. Check whether ScrollBarFadeDuration is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.ScrollBarFadeDuration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ScrollBarFadeDuration_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.ScrollBarFadeDuration = 20.0f;
            Assert.AreEqual(20.0f, textEditor.ScrollBarFadeDuration, "Retrieved PixelSize should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScrollBarShowDuration. Check whether ScrollBarShowDuration is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.ScrollBarShowDuration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ScrollBarShowDuration_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.ScrollBarShowDuration = 20.0f;
            Assert.AreEqual(20.0f, textEditor.ScrollBarShowDuration, "Retrieved PixelSize should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SmoothScroll. Check whether SmoothScroll is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.SmoothScroll A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SmoothScroll_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.SmoothScroll = false;
            Assert.IsFalse(textEditor.SmoothScroll, "Retrieved SmoothScroll should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test SmoothScrollDuration. Check whether SmoothScrollDuration is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.SmoothScrollDuration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void SmoothScrollDuration_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.SmoothScrollDuration = 5.0f;
            Assert.AreEqual(5.0f, textEditor.SmoothScrollDuration, "Retrieved SmoothScrollDuration should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test LineSpacing. Check whether LineSpacing is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.LineCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void LineCount_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            Assert.AreEqual(0, textEditor.LineCount, "Retrieved LineCount count should be equal to zero now");
        }

        [Test]
        [Category("P1")]
        [Description("Test EnableSelection. Check whether EnableSelection is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.EnableSelection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EnableSelection_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.EnableSelection = false;
            Assert.IsFalse(textEditor.EnableSelection, "Retrieved EnableSelection count should be equal to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PlaceholderText. Check whether PlaceholderText is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.PlaceholderText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PlaceholderText_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.PlaceholderText = "test PlaceholderText";
            Assert.AreEqual("test PlaceholderText", textEditor.PlaceholderText, "Retrieved PlaceholderText should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PlaceholderTextColor. Check whether PlaceholderTextColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.PlaceholderTextColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PlaceholderTextColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            Vector4 color = new Vector4(0.1f, 0.2f, 0.3f, 0.4f);
            textEditor.PlaceholderTextColor = color;
            Assert.AreEqual(color.R, textEditor.PlaceholderTextColor.R, "Retrieved PlaceholderTextColor.R should be equal to set value");
            Assert.AreEqual(color.G, textEditor.PlaceholderTextColor.G, "Retrieved PlaceholderTextColor.G should be equal to set value");
            Assert.AreEqual(color.B, textEditor.PlaceholderTextColor.B, "Retrieved PlaceholderTextColor.B should be equal to set value");
            Assert.AreEqual(color.A, textEditor.PlaceholderTextColor.A, "Retrieved PlaceholderTextColor.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Placeholder. Check whether Placeholder is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.Placeholder A")]
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

            TextEditor textEditor = new TextEditor();
            textEditor.Placeholder = map;
            PropertyMap propertyMap = textEditor.Placeholder;

            string text = "";
            bool ret = (propertyMap.Find(0, "text")).Get(out text);
            Tizen.Log.Debug(TAG, "gotten text=" + text + " return of get=" + ret);

            Assert.AreEqual("Setting Placeholder Text", text, "Should be equals to the set value of text");
        }

        [Test]
        [Category("P1")]
        [Description("Test EnableShiftSelection. Check whether EnableShiftSelection is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.EnableShiftSelection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EnableShiftSelection_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextEditor textEditor = new TextEditor();
            textEditor.EnableShiftSelection = true;
            Assert.IsTrue(textEditor.EnableShiftSelection, "The value of textEditor.EnableShiftSelection should be true");
            textEditor.EnableShiftSelection = false;
            Assert.IsFalse(textEditor.EnableShiftSelection, "The value of textEditor.EnableShiftSelection should be false");
        }

        [Test]
        [Category("P1")]
        [Description("Test TextChanged.Check whether TextChanged defined in the spec is callable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.TextChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextChanged_CHECK_EVENT()
        {
            TextEditor textEditor = new TextEditor();
            textEditor.Text = "add";
            Window.Instance.GetDefaultLayer().Add(textEditor);
            bool flag = false;
            textEditor.TextChanged += (obj, e) =>
            {
                flag = true;
            };
            textEditor.Text = "add 1";
            Assert.IsTrue(flag, "TextChanged is not be called");
        }

        [Test]
        [Category("P1")]
        [Description("Test LineWrapMode.Check whether TextChanged is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.LineWrapMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LineWrapMode_CHECK_VALUE()
        {
            TextEditor textEditor = new TextEditor();
            textEditor.LineWrapMode = LineWrapMode.Word;
            Assert.AreEqual(LineWrapMode.Word, textEditor.LineWrapMode, "LineWrapMode is not equal to the set value!");
        }

        [Test]
        [Category("P1")]
        [Description("Test TranslatablePlaceholderText.Check whether TranslatablePlaceholderText is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.TranslatablePlaceholderText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void TranslatablePlaceholderText_CHECK_VALUE()
        {
            TextEditor textEditor = new TextEditor();
            if (NUIApplication.MultilingualResourceManager != null)
            {
                textEditor.TranslatablePlaceholderText = "TextEditor";
                string translatablePlaceholderText = textEditor.TranslatablePlaceholderText;
                Assert.AreEqual("TextEditor", textEditor.TranslatablePlaceholderText, "TranslatablePlaceholderText is not equal to the set value!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test TranslatableText.Check whether TranslatableText is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.TranslatableText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void TranslatableText_CHECK_VALUE()
        {
            TextEditor textEditor = new TextEditor();
            if (NUIApplication.MultilingualResourceManager != null)
            {
                textEditor.TranslatableText = "TextEditor";
                string translatablePlaceholderText = textEditor.TranslatableText;
                Assert.AreEqual("TextEditor", textEditor.TranslatableText, "TranslatableText is not equal to the set value!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the TextEditor.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                TextEditor textEditor = new TextEditor();
                textEditor.Dispose();
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
        [Description("Test ScrollStateChanged.Check whether ScrollStateChanged defined in the spec is callable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.ScrollStateChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public async Task ScrollStateChanged_CHECK_EVENT()
        {
            var textEditor = new TextEditor()
            {
                Size2D = new Size2D(100, 60),
                Text = "Hello Hello World World",
                Focusable = true,
            };
            Window.Instance.Add(textEditor);
            try
            {
                textEditor.ScrollStateChanged += OnScrollStateChanged;
                FocusManager.Instance.SetCurrentFocusView(textEditor);
                await Task.Delay(500);
                Assert.IsTrue(_flagScrollStateChanged, "ScrollStateChanged is not be called");
            }
            catch (Exception e)
            {
                Tizen.Log.Error(TAG, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            finally
            {
                textEditor.ScrollStateChanged -= OnScrollStateChanged;
                Window.Instance.Remove(textEditor);
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test MatchSystemLanguageDirectionProperty. Check whether MatchSystemLanguageDirectionProperty(BindableProperty) is working correctly or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.MatchSystemLanguageDirectionProperty A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void MatchSystemLanguageDirectionProperty_CHECK_VALUE()
        {
            var textEditor = new TextEditor();
            Assert.IsNotNull(textEditor, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(textEditor, "Should be an instance of TextEditor type.");

            textEditor.MatchSystemLanguageDirection = false;
            Assert.AreEqual(false, textEditor.MatchSystemLanguageDirection, "should be same");

            textEditor.MatchSystemLanguageDirection = true;
            Assert.AreEqual(true, textEditor.MatchSystemLanguageDirection, "should be same");
        }

        [Test]
        [Category("P1")]
        [Description("Test MatchSystemLanguageDirection. Check whether MatchSystemLanguageDirection is working correctly or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextEditor.MatchSystemLanguageDirection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void MatchSystemLanguageDirection_CHECK_VALUE()
        {
            var textEditor = new TextEditor();
            Assert.IsNotNull(textEditor, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(textEditor, "Should be an instance of TextEditor type.");

            textEditor.MatchSystemLanguageDirection = false;
            bool ret = textEditor.MatchSystemLanguageDirection;
            Assert.AreEqual(false, ret, "should be same");

            textEditor.MatchSystemLanguageDirection = true;
            ret = textEditor.MatchSystemLanguageDirection;
            Assert.AreEqual(true, ret, "should be same");
        }

    }
}
