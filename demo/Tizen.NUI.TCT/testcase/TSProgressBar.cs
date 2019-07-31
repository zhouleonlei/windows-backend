using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using System.Threading;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.UIComponents.ProgressBar Tests")]
    public class ProgressBarTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("ProgressBarTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check whether Table View construct.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ProgressBar.ProgressBar C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void ProgressBar_INIT()
        {
            var progress = new ProgressBar();
            Assert.IsInstanceOf<ProgressBar>(progress, "Progress Contruct Fail");
        }

        [Test]
        [Category("P1")]
        [Description("Test ProgressValue. Check ProgressValue Read and Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ProgressBar.ProgressValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void ProgressValue_SET_GET_VALUE()
        {
            ProgressBar progress = new ProgressBar();
            progress.ParentOrigin = ParentOrigin.TopLeft;
            progress.PivotPoint = PivotPoint.TopLeft;
            progress.Size = new Size(Window.Instance.Size.Width, 20.0f, 0.0f);
            progress.Position = new Position(0.0f, 0.0f, 0.0f);
            progress.BackgroundColor = new Color(255,0,0,255);

            Window.Instance.GetDefaultLayer().Add(progress);
            progress.ProgressValue =  0.03f;
            Assert.AreEqual(0.03f, progress.ProgressValue, "ProgressValue test Fail ");

            Window.Instance.GetDefaultLayer().Remove(progress);
        }

        [Test]
        [Category("P1")]
        [Description("Test SecondaryProgressValue. Check SecondaryProgressValue Read and Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ProgressBar.SecondaryProgressValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public async Task SecondaryProgressValue_SET_GET_VALUE()
        {
            ProgressBar progress = new ProgressBar();
            progress.ParentOrigin = ParentOrigin.TopLeft;
            progress.PivotPoint = PivotPoint.TopLeft;
            progress.Size = new Size(Window.Instance.Size.Width, 20.0f, 0.0f);
            progress.Position = new Position(0.0f, 20.0f, 0.0f);
            progress.BackgroundColor = new Color(0, 255, 0, 255);

            Window.Instance.GetDefaultLayer().Add(progress);
            progress.SecondaryProgressValue = 0.04f;
            await Task.Delay(2000);

            float secondvalue = progress.SecondaryProgressValue;
            Assert.AreEqual(0.04f, secondvalue, "Secondary ProgressValue test Fail");
            Window.Instance.GetDefaultLayer().Remove(progress);
        }

        [Test]
        [Category("P1")]
        [Description("Test Indeterminate. Check Indeterminate Read and Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ProgressBar.Indeterminate A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public async Task Indeterminate_SET_GET_VALUE()
        {
            ProgressBar progress = new ProgressBar();
            progress.ParentOrigin = ParentOrigin.TopLeft;
            progress.PivotPoint = PivotPoint.TopLeft;
            progress.Size = new Size(Window.Instance.Size.Width, 20.0f, 0.0f);
            progress.Position = new Position(0.0f, 0.0f, 0.0f);
            progress.BackgroundColor = new Color(255, 0, 0, 255);

            Window.Instance.GetDefaultLayer().Add(progress);
            progress.Indeterminate = true;

            await Task.Delay(20);
            Assert.IsTrue(progress.Indeterminate, "Test Indeterminate Fail.");
            Window.Instance.GetDefaultLayer().Remove(progress);
        }

        [Test]
        [Category("P1")]
        [Description("Test TrackVisual. Check TrackVisual Read and Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ProgressBar.TrackVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void TrackVisual_SET_GET_VALUE()
        {
            ProgressBar progress = new ProgressBar();

            progress.ParentOrigin = ParentOrigin.TopLeft;
            progress.PivotPoint = PivotPoint.TopLeft;
            progress.Size = new Size(Window.Instance.Size.Width, 20.0f, 0.0f);
            progress.Position = new Position(0.0f, 0.0f, 0.0f);
            progress.BackgroundColor = new Color(255, 0, 0, 255);

            Window.Instance.GetDefaultLayer().Add(progress);
            PropertyMap map = new PropertyMap();
            map.Add("visualType", new PropertyValue("IMAGE"));
            map.Add(ImageVisualProperty.URL, new PropertyValue(image_path));
            progress.TrackVisual = map;
            string url = "";
            PropertyValue value = progress.TrackVisual.Find(ImageVisualProperty.URL);
            Assert.IsNotNull(value, "Property Value is NUll.");
            value.Get(out url);
            Assert.AreEqual(image_path, url, "URL IS NOT RIGHT.");
            Window.Instance.GetDefaultLayer().Remove(progress);
        }

        [Test]
        [Category("P1")]
        [Description("Test SecondaryProgressVisual. Check SecondaryProgressVisual Read and Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ProgressBar.SecondaryProgressVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public void SecondaryProgressVisual_SET_GET_VALUE()
        {
            ProgressBar progress = new ProgressBar();
            PropertyMap map = new PropertyMap();
            map.Add("visualType", new PropertyValue("IMAGE"));
            map.Add(ImageVisualProperty.URL, new PropertyValue(image_path));
            progress.SecondaryProgressVisual = map;
            string url = "";
            PropertyValue value = progress.SecondaryProgressVisual.Find(ImageVisualProperty.URL);
            Assert.IsNotNull(value, "Property Value is NUll.");
            value.Get(out url);
            Assert.AreEqual(image_path, url, "URL IS NOT RIGHT.");
        }

        [Test]
        [Category("P1")]
        [Description("Test ProgressVisual. Check ProgressVisual Read and Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ProgressBar.ProgressVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]
        public async Task ProgressVisual_SET_GET_VALUE()
        {
            ProgressBar progress = new ProgressBar();

            progress.ParentOrigin = ParentOrigin.TopLeft;
            progress.PivotPoint = PivotPoint.TopLeft;
            progress.Size = new Size(Window.Instance.Size.Width, 20.0f, 0.0f);
            progress.Position = new Position(0.0f, 0.0f, 0.0f);
            progress.BackgroundColor = new Color(255, 0, 0, 255);
            Window.Instance.GetDefaultLayer().Add(progress);
            PropertyMap map = new PropertyMap();
            map.Add("visualType", new PropertyValue("IMAGE"));
            map.Add(ImageVisualProperty.URL, new PropertyValue(image_path));

            await Task.Delay(2000);
            progress.ProgressVisual = map;
            string url = "";
            PropertyMap rMap = progress.ProgressVisual;
            Assert.IsNotNull(rMap, "RETURN IS NULL");
            PropertyValue pvalue = rMap.Find(ImageVisualProperty.URL);
            Assert.IsNotNull(pvalue, "RETURN IS NULL 2");
            pvalue.Get(out url);
            Assert.AreEqual(image_path, url, "URL IS NOT RIGHT.");
            Window.Instance.GetDefaultLayer().Remove(progress);
        }

        [Test]
        [Category("P1")]
        [Description("Test IndeterminateVisual. Check IndeterminateVisual Read and Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ProgressBar.IndeterminateVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void IndeterminateVisual_SET_GET_VALUE()
        {
            ProgressBar progress = new ProgressBar();
            PropertyMap map = new PropertyMap();
            map.Add("visualType", new PropertyValue("IMAGE"));
            map.Add(ImageVisualProperty.URL, new PropertyValue(image_path));

            progress.IndeterminateVisual = map;
            string url = "";
            PropertyValue pValue = progress.IndeterminateVisual.Find(ImageVisualProperty.URL);
            Assert.IsNotNull(pValue, "RETURN IS NULL 2");
            pValue.Get(out url);
            Assert.AreEqual(image_path, url, "URL IS NOT RIGHT.");
        }

        [Test]
        [Category("P1")]
        [Description("Test LabelVisual. Check LabelVisual Read and Write.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ProgressBar.LabelVisual A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Xuemei Chen, xnicole.chen@samsung.com")]

        public void LabelVisual_SET_GET_VALUE()
        {
            ProgressBar progress = new ProgressBar();
            progress.Size2D = new Size2D(0, 100);
            progress.ProgressValue = 0.5f;
            progress.SecondaryProgressValue = 0.61f;
            PropertyMap map = new PropertyMap();
            map.Add(Visual.Property.Type, new PropertyValue((int)Tizen.NUI.Visual.Type.Text));
            map.Add(TextVisualProperty.PointSize, new PropertyValue(10.0f));
            map.Add(TextVisualProperty.Text, new PropertyValue(Math.Round(progress.ProgressValue, 2) + " / " + Math.Round(progress.SecondaryProgressValue, 2)));
            progress.LabelVisual = map;

            PropertyValue value = progress.LabelVisual.Find(TextVisualProperty.Text);
            Assert.IsNotNull(progress.LabelVisual.Find(TextVisualProperty.Text), "Should not be null");
            String text = "";
            (progress.LabelVisual.Find(TextVisualProperty.Text)).Get(out text);
            Assert.AreEqual("0.5 / 0.61", text, "SelectedStateImage does not work well here!");
        }

        [Test]
        [Category("P1")]
        [Description("dali progress bar indeterminatw visual animation test")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ProgressBar.IndeterminateVisualAnimation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void IndeterminateVisualAnimation_SET_GET_VALUE()
        {
            ProgressBar progress = new ProgressBar();
            PropertyArray  transitionMap = new PropertyArray();
            PropertyMap animatorMap = new PropertyMap();
            PropertyMap timeMap = new PropertyMap();
            timeMap.Add("delay", new PropertyValue(0.5f));
            timeMap.Add("duration", new PropertyValue(1.0f));
            animatorMap.Add("alphaFunction", new PropertyValue("EASE_IN_OUT_BACK"));
            animatorMap.Add("timePeriod", new PropertyValue( timeMap));

            transitionMap.PushBack( new PropertyValue("indeterminateVisual"));
            transitionMap.PushBack(new PropertyValue("offset"));
            transitionMap.PushBack( new PropertyValue(new Vector2(0.0f, 0.0f)));
            transitionMap.PushBack( new PropertyValue(new Vector2(10.0f, 0.0f)));
            transitionMap.PushBack(new PropertyValue(animatorMap));

            progress.IndeterminateVisualAnimation = transitionMap;
        }

        [Test]
        [Category("P1")]
        [Description("dali progressbar ValueChanged test, Try to change the value of the progressBar and check whether the ValueChanged event has been trrigged")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ProgressBar.ValueChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void ValueChanged_CHECK_EVENT()
        {
            ProgressBar progress = new ProgressBar();
            progress.ProgressValue = 0.2f;
            bool flag = false;
            progress.ValueChanged += (obj, ee) =>
            {
                flag = true;
            };
            progress.ProgressValue = 0.4f;
            Assert.IsTrue(flag, "The ValueChanged event not been triggerred!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Dispose, try to dispose the ProgressBar.")]
        [Property("SPEC", "Tizen.NUI.UIComponents.ProgressBar.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                ProgressBar progressBar = new ProgressBar();
                progressBar.Dispose();
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
