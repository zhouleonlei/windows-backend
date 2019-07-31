using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.BaseComponents.TextLabel Tests")]
    public class TextLabelTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("TextLabelTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a TextLabel object. Check whether object is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.TextLabel C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextLabel_INIT()
        {
            /* TEST CODE */
            var textLabel = new TextLabel();
            Assert.IsNotNull(textLabel, "Can't create success object textLabel");
            Assert.IsInstanceOf<TextLabel>(textLabel, "Should be an instance of textLabel type.");
        }

        [Test]
        [Category("P1")]
        [Description("Create a TextLabel object with string. Check whether object whose text is initialized is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.TextLabel C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "string")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextLabel_INIT_WITH_STRING()
        {
            /* TEST CODE */
            var textLabel = new TextLabel("test  textlabel");
            Assert.IsNotNull(textLabel, "Can't create success object textLabel");
            Assert.IsInstanceOf<TextLabel>(textLabel, "Should be an instance of textLabel type.");
            Assert.AreEqual("test  textlabel", textLabel.Text, "Retrieved Text should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Text. Check whether Text is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.Text A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Text_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.Text = "test Text";
            Assert.AreEqual("test Text", textLabel.Text, "Retrieved Text should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test FontFamily. Check whether FontFamily is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.FontFamily A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void FontFamily_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.FontFamily = "test FontFamily";
            Assert.AreEqual("test FontFamily", textLabel.FontFamily, "Retrieved FontFamily should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test FontStyle. Check whether FontStyle is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.FontStyle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void FontStyle_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            PropertyMap map = new PropertyMap();
            map.Clear();
            PropertyValue value = new PropertyValue("bold");
            map.Insert("weight", value);
            value = new PropertyValue("condensed");
            map.Insert("width", value);
            value = new PropertyValue("italic");
            map.Insert("slant", value);
            textLabel.FontStyle = map;

            //This is for MDC-Solis TCT: MCD-Solis has different fonts installed so it needs seperated test case. (There is no condition or definition for specific target) 
            if (map.Count() != textLabel.FontStyle.Count())
            {
                map.Clear();
                value = new PropertyValue("bold");
                map.Insert("weight", value);
                value = new PropertyValue("normal");
                map.Insert("width", value);
                value = new PropertyValue("italic");
                map.Insert("slant", value);
                textLabel.FontStyle = map;
            }

            Assert.AreEqual(map.Count(), textLabel.FontStyle.Count(), "Retrieved FontStyle's count should be equal to set value");
            string str1, str2;
            for (uint index = 0u; index < map.Count(); index++)
            {
                map.GetValue(index).Get(out str1);
                textLabel.FontStyle.GetValue(index).Get(out str2);
                Assert.AreEqual(str1, str2, index + ": should be equals to the set value");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test PointSize. Check whether PointSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.PointSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PointSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            float size = 0.5f;
            textLabel.PointSize = size;
            Assert.AreEqual(size, textLabel.PointSize, "Retrieved PointSize should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test MultiLine. Check whether MultiLine is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.MultiLine A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void MultiLine_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.MultiLine = true;
            Assert.AreEqual(true, textLabel.MultiLine, "Retrieved MultiLine should be equal to set value");
            textLabel.MultiLine = false;
            Assert.AreEqual(false, textLabel.MultiLine, "Retrieved MultiLine should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test HorizontalAlignment. Check whether HorizontalAlignment is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.HorizontalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void HorizontalAlignment_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.HorizontalAlignment = HorizontalAlignment.End;
            Assert.AreEqual(HorizontalAlignment.End, textLabel.HorizontalAlignment, "Retrieved HorizontalAlignment should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test VerticalAlignment. Check whether VerticalAlignment is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.VerticalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void VerticalAlignment_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.VerticalAlignment = VerticalAlignment.Center;
            Assert.AreEqual(VerticalAlignment.Center, textLabel.VerticalAlignment, "Retrieved VerticalAlignment should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test VerticalLineAlignment. Check whether VerticalLineAlignment is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.VerticalLineAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void VerticalLineAlignment_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.VerticalLineAlignment = VerticalLineAlignment.Center;
            Assert.AreEqual(VerticalLineAlignment.Center, textLabel.VerticalLineAlignment, "Retrieved VerticalLineAlignment should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test TextColor. Check whether TextColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.TextColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void TextColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            Color color = Color.Red;
            textLabel.TextColor = color;
            Assert.AreEqual(color.R, textLabel.TextColor.R, "Retrieved TextColor should be equal to set value");
            Assert.AreEqual(color.G, textLabel.TextColor.G, "Retrieved TextColor should be equal to set value");
            Assert.AreEqual(color.B, textLabel.TextColor.B, "Retrieved TextColor should be equal to set value");
            Assert.AreEqual(color.A, textLabel.TextColor.A, "Retrieved TextColor should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ShadowOffset. Check whether ShadowOffset is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.ShadowOffset A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ShadowOffset_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            Vector2 offset = new Vector2(1.0f, 1.0f);
            textLabel.ShadowOffset = offset;
            Assert.AreEqual(offset.X, textLabel.ShadowOffset.X, "Retrieved ShadowOffset.X should be equal to set value");
            Assert.AreEqual(offset.Y, textLabel.ShadowOffset.Y, "Retrieved ShadowOffset.Y should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test ShadowColor. Check whether ShadowColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.ShadowColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void ShadowColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            Vector4 color = new Vector4(0.1f, 0.2f, 0.3f, 0.4f);
            textLabel.ShadowColor = color;
            Assert.AreEqual(color.R, textLabel.ShadowColor.R, "Retrieved ShadowColor.R should be equal to set value");
            Assert.AreEqual(color.G, textLabel.ShadowColor.G, "Retrieved ShadowColor.G should be equal to set value");
            Assert.AreEqual(color.B, textLabel.ShadowColor.B, "Retrieved ShadowColor.B should be equal to set value");
            Assert.AreEqual(color.A, textLabel.ShadowColor.A, "Retrieved ShadowColor.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test UnderlineColor. Check whether UnderlineColor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.UnderlineColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void UnderlineColor_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            Vector4 color = new Vector4(0.1f, 0.2f, 0.3f, 0.4f);
            textLabel.UnderlineColor = color;
            Assert.AreEqual(color.R, textLabel.UnderlineColor.R, "Retrieved UnderlineColor.R should be equal to set value");
            Assert.AreEqual(color.G, textLabel.UnderlineColor.G, "Retrieved UnderlineColor.G should be equal to set value");
            Assert.AreEqual(color.B, textLabel.UnderlineColor.B, "Retrieved UnderlineColor.B should be equal to set value");
            Assert.AreEqual(color.A, textLabel.UnderlineColor.A, "Retrieved UnderlineColor.A should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test UnderlineHeight. Check whether UnderlineHeight is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.UnderlineHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void UnderlineHeight_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.UnderlineHeight = 1.0f;
            Assert.AreEqual(1.0f, textLabel.UnderlineHeight, "Retrieved UnderlineHeight should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test EnableMarkup. Check whether EnableMarkup is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.EnableMarkup A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void EnableMarkup_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.EnableMarkup = true;
            Assert.AreEqual(true, textLabel.EnableMarkup, "Retrieved EnableMarkup should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test EnableAutoScroll. Check whether EnableAutoScroll is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.EnableAutoScroll A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void EnableAutoScroll_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.EnableAutoScroll = true;
            Assert.AreEqual(true, textLabel.EnableAutoScroll, "Retrieved EnableAutoScroll should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test AutoScrollSpeed. Check whether AutoScrollSpeed is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.AutoScrollSpeed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void AutoScrollSpeed_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.AutoScrollSpeed = 20;
            Assert.AreEqual(20, textLabel.AutoScrollSpeed, "Retrieved AutoScrollSpeed should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test AutoScrollLoopCount. Check whether AutoScrollLoopCount is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.AutoScrollLoopCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void AutoScrollLoopCount_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.AutoScrollLoopCount = 20;
            Assert.AreEqual(20, textLabel.AutoScrollLoopCount, "Retrieved AutoScrollLoopCount should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test AutoScrollGap. Check whether AutoScrollGap is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.AutoScrollGap A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void AutoScrollGap_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.AutoScrollGap = 1.0f;
            Assert.AreEqual(1.0f, textLabel.AutoScrollGap, "Retrieved AutoScrollGap should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test LineSpacing. Check whether LineSpacing is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.LineSpacing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void LineSpacing_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.LineSpacing = 1.0f;
            Assert.AreEqual(1.0f, textLabel.LineSpacing, "Retrieved LineSpacing should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Underline. Check whether Underline is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.Underline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Underline_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            PropertyMap map = new PropertyMap();
            map.Clear();
            PropertyValue value = new PropertyValue(true);
            map.Insert("enable", value);
            value = new PropertyValue(new Vector4(1.0f, 0.0f, 0.0f, 1.0f));
            map.Insert("color", value);
            value = new PropertyValue(0.1f);
            map.Insert("height", value);
            textLabel.Underline = map;
            Assert.AreEqual(map.Count(), textLabel.Underline.Count(), "Retrieved Underline should be equal to set value");

            bool enable = false;
            Vector4 color = new Vector4();
            float height = 0.0f;
            textLabel.Underline.Find(0, "enable").Get(out enable);
            textLabel.Underline.Find(0, "color").Get(color);
            textLabel.Underline.Find(0, "height").Get(out height);

            Assert.AreEqual(true, enable, "enable : should be equals to the set value");
            Assert.AreEqual(1.0f, color.R, "color : should be equals to the set value");
            Assert.AreEqual(0.1f, height, "height : should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Shadow. Check whether Shadow is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.Shadow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Shadow_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            PropertyMap map = new PropertyMap();
            map.Add("color", new PropertyValue("green"));
            map.Add("offset", new PropertyValue("2 2"));
            map.Add("blurRadius", new PropertyValue(0.0f));

            textLabel.Shadow = map;

            Tizen.Log.Debug("NUI", $"map.Count()={map.Count()}, textLabel.Shadow.Count()={textLabel.Shadow.Count()}");
            Assert.AreEqual(map.Count(), textLabel.Shadow.Count(), "Retrieved Shadow's count should be equal to set value");

            Vector4 color = new Vector4();
            textLabel.Shadow.GetValue(0).Get(color);
            Tizen.Log.Debug("NUI", $"color r={color.R}, g={color.G}, b={color.B}, a={color.A}");
            Assert.IsTrue(color.R == 0 && color.G == 1 && color.B == 0 && color.A == 1);

            Vector2 offset = new Vector2();
            textLabel.Shadow.GetValue(1).Get(offset);
            Tizen.Log.Fatal("NUI", $"offset x={offset.X}, y={offset.Y}");
            Assert.IsTrue(offset.X == 2 && offset.Y == 2);

            float blurRadius = -1.0f;
            textLabel.Shadow.GetValue(2).Get(out blurRadius);
            Tizen.Log.Fatal("NUI", $"blurRadius={blurRadius}");
            Assert.IsTrue(blurRadius == 0);
        }

        [Test]
        [Category("P1")]
        [Description("Test Ellipsis. Check whether LineCount is readable")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.LineCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LineCount_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.Size = new Size(300.0f, 300.0f, 0.0f);
            textLabel.MultiLine = true;
            textLabel.Text = "line1 \n line2";
            Window.Instance.GetDefaultLayer().Add(textLabel);
            Assert.GreaterOrEqual(textLabel.LineCount, 2, "Should be >= 2 lines");
        }

        [Test]
        [Category("P1")]
        [Description("Test Emboss. Check whether Emboss is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.Emboss A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Emboss_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.Emboss = "Text Emboss";
            Assert.AreEqual("Text Emboss", textLabel.Emboss, "Retrieved Emboss should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Outline. Check whether Outline is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.Outline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void Outline_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel text = new TextLabel();
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
        [Description("Test UnderlineEnabled. Check whether UnderlineEnabled is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.UnderlineEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void UnderlineEnabled_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.UnderlineEnabled = true;
            Assert.IsTrue(textLabel.UnderlineEnabled, "Retrieved UnderlineEnabled should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test AutoScrollLoopDelay. Check whether AutoScrollLoopDelay is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.AutoScrollLoopDelay A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AutoScrollLoopDelay_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.AutoScrollLoopDelay = 20.0f;
            Assert.AreEqual(20.0f, textLabel.AutoScrollLoopDelay, "Retrieved AutoScrollLoopDelay should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test AutoScrollStopMode. Check whether AutoScrollStopMode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.AutoScrollStopMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AutoScrollStopMode_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.AutoScrollStopMode = AutoScrollStopMode.FinishLoop;
            Assert.AreEqual(AutoScrollStopMode.FinishLoop, textLabel.AutoScrollStopMode, "Retrieved AutoScrollStopMode should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test AutoScrollStopMode. Check whether AutoScrollStopMode is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.AutoScrollStopMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void AutoScrollStopMode_SET_GET_VALUE_WITH_IMMEDIATE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.AutoScrollStopMode = AutoScrollStopMode.Immediate;
            Assert.AreEqual(AutoScrollStopMode.Immediate, textLabel.AutoScrollStopMode, "Retrieved AutoScrollStopMode should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test Ellipsis. Check whether Ellipsis is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.Ellipsis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Ellipsis_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.Ellipsis = true;
            Assert.IsTrue(textLabel.Ellipsis, "Retrieved Ellipsis should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PixelSize. Check whether PixelSize is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.PixelSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void PixelSize_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.PixelSize = 20.0f;
            Assert.AreEqual(20.0f, textLabel.PixelSize, 0.0001f, "Retrieved PixelSize should be equals to the set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test LineWrapMode.Check whether TextChanged is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.LineWrapMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LineWrapMode_SET_GET_VALUE()
        {
            TextLabel textLabel = new TextLabel();
            textLabel.LineWrapMode = LineWrapMode.Word;
            Assert.AreEqual(LineWrapMode.Word, textLabel.LineWrapMode, "LineWrapMode is not equal to the set value!");
        }

        [Test]
        [Category("P1")]
        [Description("Test TextDirection.Check whether TextDirection returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.TextDirection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void TextDirection_READ_ONLY()
        {
            TextLabel textLabel = new TextLabel();
            textLabel.Text = "English";
            Assert.AreEqual(TextDirection.LeftToRight, textLabel.TextDirection, "TextDirection is incorrect here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test TranslatableText.Check whether TranslatableText is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.TranslatableText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void TranslatableText_SET_GET_VALUE()
        {
            TextLabel textLabel = new TextLabel();
            if (NUIApplication.MultilingualResourceManager != null)
            {
                textLabel.TranslatableText = "TextField";
                string translatablePlaceholderText = textLabel.TranslatableText;
                Assert.AreEqual("TextField", textLabel.TranslatableText, "TranslatableText is not equal to the set value!");
            }
        }
#if false // currently ACR is not yet proceed. temporarily blocked.
        //[Test]
        //[Category("P1")]
        //[Description("Test TextColorAnimatable. Check whether TextColorAnimatable is readable and writable.")]
        //[Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.TextColorAnimatable A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void TextColorAnimatable_SET_GET_VALUE()
        {
            /* TEST CODE */
            TextLabel textLabel = new TextLabel();
            textLabel.TextColorAnimatable = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            Assert.AreEqual(1.0f, textLabel.TextColorAnimatable.R, "Retrieved TextColorAnimatable.R should be equals to the set value");
            Assert.AreEqual(1.0f, textLabel.TextColorAnimatable.G, "Retrieved TextColorAnimatable.G should be equals to the set value");
            Assert.AreEqual(1.0f, textLabel.TextColorAnimatable.B, "Retrieved TextColorAnimatable.B should be equals to the set value");
            Assert.AreEqual(1.0f, textLabel.TextColorAnimatable.A, "Retrieved TextColorAnimatable.A should be equals to the set value");
        }
#endif

        [Test]
        [Category("P1")]
        [Description("Test OnBindingContextChanged. Check whether it return the right value")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.OnBindingContextChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Junqing Ma, junqing.ma@samsung.com")]
        public void OnBindingContextChanged_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
            try
            {
                MyTexLabel textLabel = new MyTexLabel();
                textLabel._OnBindingContextChanged();
            }
            catch(Exception e)
            {
                Tizen.Log.Error("Test CustomView.cs", "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test MatchSystemLanguageDirectionProperty. Check whether MatchSystemLanguageDirectionProperty(BindableProperty) is working correctly or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.MatchSystemLanguageDirectionProperty A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void MatchSystemLanguageDirectionProperty_CHECK_VALUE()
        {
            var textLabel = new TextLabel();
            Assert.IsNotNull(textLabel, "Can't create success object textLabel");
            Assert.IsInstanceOf<TextLabel>(textLabel, "Should be an instance of textLabel type.");

            textLabel.MatchSystemLanguageDirection = false;
            Assert.AreEqual(false, textLabel.MatchSystemLanguageDirection, "should be same");

            textLabel.MatchSystemLanguageDirection = true;
            Assert.AreEqual(true, textLabel.MatchSystemLanguageDirection, "should be same");
        }

        [Test]
        [Category("P1")]
        [Description("Test MatchSystemLanguageDirection. Check whether MatchSystemLanguageDirection is working correctly or not.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.TextLabel.MatchSystemLanguageDirection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void MatchSystemLanguageDirection_CHECK_VALUE()
        {
            var textLabel = new TextLabel();
            Assert.IsNotNull(textLabel, "Can't create success object textLabel");
            Assert.IsInstanceOf<TextLabel>(textLabel, "Should be an instance of textLabel type.");

            textLabel.MatchSystemLanguageDirection = false;
            bool ret = textLabel.MatchSystemLanguageDirection;
            Assert.AreEqual(false, ret, "should be same");

            textLabel.MatchSystemLanguageDirection = true;
            ret = textLabel.MatchSystemLanguageDirection;
            Assert.AreEqual(true, ret, "should be same");
        }

    }

    public class MyTexLabel : TextLabel
    {
        public MyTexLabel() : base()
        {
        }

        public void _OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }
    }
}
