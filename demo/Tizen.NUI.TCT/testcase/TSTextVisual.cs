using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.TextVisual Tests")]
    public class TextVisualTests
    {
        private string TAG = "NUI";

        private static bool _flagComposingPropertyMap;
        internal class MyTextVisual : TextVisual
        {
            protected override void ComposingPropertyMap()
            {
                _flagComposingPropertyMap = true;
                base.ComposingPropertyMap();
            }
        }

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("TextVisualTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a TextVisual object.Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.TextVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextVisual_INIT()
        {
            /* TEST CODE */
            var textVisualMap = new TextVisual();
            Assert.IsNotNull(textVisualMap, "Can't create success object TextVisual");
            Assert.IsInstanceOf<TextVisual>(textVisualMap, "Should be an instance of TextVisual type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test Text. Check whether Text is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.Text A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Text_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextVisual textVisualMap = new TextVisual();
            textVisualMap.Text = "Text";
            Assert.AreEqual("Text", textVisualMap.Text, "Retrieved Text should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test FontFamily. Check whether FontFamily is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.FontFamily A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void FontFamily_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextVisual textVisualMap = new TextVisual();
            textVisualMap.FontFamily = "FontFamily";
            Assert.AreEqual("FontFamily", textVisualMap.FontFamily, "Retrieved FontFamily should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test FontStyle. Check whether FontStyle is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.FontStyle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void FontStyle_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextVisual textVisualMap = new TextVisual();
            PropertyMap fontStyleMapSet = new PropertyMap();
            fontStyleMapSet.Add("weight", new PropertyValue("bold"));
            fontStyleMapSet.Add("width", new PropertyValue("condensed"));
            fontStyleMapSet.Add("slant", new PropertyValue("italic"));
            textVisualMap.FontStyle = fontStyleMapSet;

            PropertyMap fontStyleMapGet = new PropertyMap();
            fontStyleMapGet = textVisualMap.FontStyle;
            Assert.IsNotNull(fontStyleMapGet, "Should not be null");
            string str = "";
            fontStyleMapGet.Find(0, "weight").Get(out str);
            Assert.AreEqual("bold", str, "fontStyleMapGet.Find(\"weight\") should equals to the set value");
            fontStyleMapGet.Find(1, "width").Get(out str);
            Assert.AreEqual("condensed", str, "fontStyleMapGet.Find(\"width\") should equals to the set value");
            fontStyleMapGet.Find(2, "slant").Get(out str);
            Assert.AreEqual("italic", str, "fontStyleMapGet.Find(\"slant\") should equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PointSize. Check whether PointSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.PointSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PointSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextVisual textVisualMap = new TextVisual();
            textVisualMap.PointSize = 1.0f;
            Assert.AreEqual(1.0f, textVisualMap.PointSize, "Retrieved PointSize should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test MultiLine. Check whether MultiLine is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.MultiLine A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void MultiLine_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextVisual textVisualMap = new TextVisual();
            textVisualMap.MultiLine = true;
            Assert.AreEqual(true, textVisualMap.MultiLine, "Retrieved MultiLine should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test HorizontalAlignment. Check whether HorizontalAlignment is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.HorizontalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void HorizontalAlignment_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextVisual textVisualMap = new TextVisual();
            textVisualMap.HorizontalAlignment = HorizontalAlignment.Center;
            Assert.AreEqual(HorizontalAlignment.Center, textVisualMap.HorizontalAlignment, "Retrieved HorizontalAlignment should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test VerticalAlignment. Check whether VerticalAlignment is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.VerticalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void VerticalAlignment_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextVisual textVisualMap = new TextVisual();
            textVisualMap.VerticalAlignment = VerticalAlignment.Center;
            Assert.AreEqual(VerticalAlignment.Center, textVisualMap.VerticalAlignment, "Retrieved VerticalAlignment should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test TextColor. Check whether TextColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.TextColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextVisual textVisualMap = new TextVisual();
            Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            textVisualMap.TextColor = color;
            Assert.AreEqual(1.0f, textVisualMap.TextColor.R, "Retrieved TextColor.R should be equal to set value");
            Assert.AreEqual(1.0f, textVisualMap.TextColor.G, "Retrieved TextColor.G should be equal to set value");
            Assert.AreEqual(1.0f, textVisualMap.TextColor.B, "Retrieved TextColor.B should be equal to set value");
            Assert.AreEqual(1.0f, textVisualMap.TextColor.A, "Retrieved TextColor.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test EnableMarkup. Check whether EnableMarkup is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.EnableMarkup A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void EnableMarkup_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextVisual textVisualMap = new TextVisual();
            textVisualMap.EnableMarkup = true;
            Assert.AreEqual(true, textVisualMap.EnableMarkup, "Retrieved EnableMarkup should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Shadow. Check whether Shadow is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.Shadow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void Shadow_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextVisual textVisualMap = new TextVisual();
            PropertyMap shadowMapSet = new PropertyMap();
            shadowMapSet.Add("color", new PropertyValue(new Color(1.0f, 0.1f, 0.3f, 0.5f)));
            shadowMapSet.Add("offset", new PropertyValue(new Vector2(2.0f, 1.0f)));
            shadowMapSet.Add("blurRadius", new PropertyValue(3.0f));
            textVisualMap.Shadow = shadowMapSet;

            PropertyMap shadowMapGet = new PropertyMap();
            shadowMapGet = textVisualMap.Shadow;
            Assert.IsNotNull(shadowMapGet, "Should not be null");
            Color color = new Color();
            shadowMapGet["color"].Get(color);
            Assert.AreEqual(1.0f, color.R, "Retrieved color.R should be equal to set value");
            Assert.AreEqual(0.1f, color.G, "Retrieved color.G should be equal to set value");
            Assert.AreEqual(0.3f, color.B, "Retrieved color.B should be equal to set value");
            Assert.AreEqual(0.5f, color.A, "Retrieved color.A should be equal to set value");

            Vector2 vector2 = new Vector2();
            shadowMapGet["offset"].Get(vector2);
            Assert.AreEqual(2.0f, vector2.X, "Retrieved vector2.X should be equal to set value");
            Assert.AreEqual(1.0f, vector2.Y, "Retrieved vector2.Y should be equal to set value");

            float blurRadius;
            shadowMapGet["blurRadius"].Get(out blurRadius);
            Assert.AreEqual(3.0f, blurRadius, "Retrieved blurRadius should equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Underline. Check whether Underline is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.Underline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void Underline_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextVisual textVisualMap = new TextVisual();
            PropertyMap underlineMapSet = new PropertyMap();
            underlineMapSet.Add("enable", new PropertyValue("true"));
            underlineMapSet.Add("color", new PropertyValue("green"));
            underlineMapSet.Add("height", new PropertyValue("1"));
            textVisualMap.Underline = underlineMapSet;

            PropertyMap underlineMapGet = new PropertyMap();
            underlineMapGet = textVisualMap.Underline;
            Assert.IsNotNull(underlineMapGet, "Should not be null");
            string str = "";
            underlineMapGet["enable"].Get(out str);
            Assert.AreEqual("true", str, "Retrieved enable should equals to the set value");
            underlineMapGet["color"].Get(out str);
            Assert.AreEqual("green", str, "Retrieved color should equals to the set value");
            underlineMapGet["height"].Get(out str);
            Assert.AreEqual("1", str, "Retrieved height should equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Outline. Check whether Outline is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.Outline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.comm")]
        public void Outline_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextVisual textVisualMap = new TextVisual();
            PropertyMap outlineMapSet = new PropertyMap();
            outlineMapSet.Add("color", new PropertyValue(new Color(1.0f, 0.1f, 0.3f, 0.5f)));
            outlineMapSet.Add("width", new PropertyValue("1"));
            textVisualMap.Outline = outlineMapSet;

            PropertyMap outlineMapGet = new PropertyMap();
            outlineMapGet = textVisualMap.Outline;
            Assert.IsNotNull(outlineMapGet, "Should not be null");

            Color color = new Color();
            outlineMapGet["color"].Get(color);
            Assert.AreEqual(1.0f, color.R, "Retrieved color.R should be equal to set value");
            Assert.AreEqual(0.1f, color.G, "Retrieved color.G should be equal to set value");
            Assert.AreEqual(0.3f, color.B, "Retrieved color.B should be equal to set value");
            Assert.AreEqual(0.5f, color.A, "Retrieved color.A should be equal to set value");

            string str = "";
            outlineMapGet["width"].Get(out str);
            Assert.AreEqual("1", str, "Retrieved width should equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Background. Check whether Background is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.Background A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.comm")]
        public void Background_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextVisual textVisualMap = new TextVisual();
            PropertyMap backgroundMapSet = new PropertyMap();
            backgroundMapSet.Add("enable", new PropertyValue(true));
            backgroundMapSet.Add("color", new PropertyValue(new Color(1.0f, 0.1f, 0.3f, 0.5f)));
            textVisualMap.Background = backgroundMapSet;

            PropertyMap backgroundMapGet = new PropertyMap();
            backgroundMapGet = textVisualMap.Background;
            Assert.IsNotNull(backgroundMapGet, "Should not be null");
            bool enable = false;
            backgroundMapGet["enable"].Get(out enable);
            Assert.AreEqual(true, enable, "Retrieved enable should equals to the set value");

            Color color = new Color();
            backgroundMapGet["color"].Get(color);
            Assert.AreEqual(1.0f, color.R, "Retrieved color.R should be equal to set value");
            Assert.AreEqual(0.1f, color.G, "Retrieved color.G should be equal to set value");
            Assert.AreEqual(0.3f, color.B, "Retrieved color.B should be equal to set value");
            Assert.AreEqual(0.5f, color.A, "Retrieved color.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Check override method ComposingPropertyMap is invoked when new TextVisual instance.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Wenfeng Ge, wenfeng.ge@samsung.com")]
        public void ComposingPropertyMap_OVERRIDE_METHOD()
        {
            /*PRE CONDITION
             * _flagComposingPropertyMap flag is initialize false value
             * Create a instance MySVGVisual
             */
            _flagComposingPropertyMap = false;
            Assert.False(_flagComposingPropertyMap, "_flagComposingPropertyMap should false initial");
            /**TEST CODE**/
            var myTextVisual = new MyTextVisual()
            {
                TextColor = new Color(1.0f, 0.3f, 0.5f, 1.0f),
            };
            Assert.IsInstanceOf<TextVisual>(myTextVisual, "Should be an instance of TextVisual type.");
            PropertyMap propertyMap = myTextVisual.OutputVisualMap;
            Assert.True(_flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");
        }
    }
}
