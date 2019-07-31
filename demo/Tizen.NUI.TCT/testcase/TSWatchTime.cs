using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.WatchTime Tests")]
    public class WatchTimeTests
    {
        private string TAG = "NUI";

        private bool IsWearable()
        {
            //string value;
            //var result = Tizen.System.Information.TryGetValue("tizen.org/feature/profile", out value);
            //if (result && value.Equals("wearable"))
            //{
            //    return true;
            //}

            //return false;
            return true;
        }

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("WatchTimeTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("WatchTime constructor test")]
        [Property("SPEC", "Tizen.NUI.WatchTime.WatchTime C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void WatchTime_INIT()
        {
            if (IsWearable())
            {
                /* TEST CODE */
                var time = new WatchTime();
                Assert.IsInstanceOf<WatchTime>(time, "Should return WatchTime instance.");
            }
            else
            {
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Day. Check whether Day is readable.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.Day A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Day_GET_VALUE()
        {
            /* TEST CODE */
            if (IsWearable())
            {
                var watchTime = new WatchTime();
                Assert.IsInstanceOf<WatchTime>(watchTime, "Should be an instance of WatchTime type.");
                int time = watchTime.Day;
                Assert.IsTrue(time > 0.0f, "The Day is not correct!");
            }
            else
            {
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test DaylightSavingTimeStatus. Check whether DaylightSavingTimeStatus is readable.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.DaylightSavingTimeStatus A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void DaylightSavingTimeStatus_GET_VALUE()
        {
            /* TEST CODE */
            if (IsWearable())
            {
                var watchTime = new WatchTime();
                Assert.IsInstanceOf<WatchTime>(watchTime, "Should be an instance of WatchTime type.");
                bool status = watchTime.DaylightSavingTimeStatus;
                Assert.AreEqual(false, status, "Should be the default value");
            }
            else
            {
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test DayOfWeek. Check whether DayOfWeek is readable.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.DayOfWeek A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void DayOfWeek_GET_VALUE()
        {
            /* TEST CODE */
            if (IsWearable())
            {
                var watchTime = new WatchTime();
                Assert.IsInstanceOf<WatchTime>(watchTime, "Should be an instance of WatchTime type.");
                int day = watchTime.DayOfWeek;
                Assert.IsTrue(day > 0.0f, "The DayOfWeek is not correct!");
            }
            else
            {
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Hour. Check whether Hour is readable.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.Hour A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Hour_GET_VALUE()
        {
            /* TEST CODE */
            if (IsWearable())
            {
                var watchTime = new WatchTime();
                Assert.IsInstanceOf<WatchTime>(watchTime, "Should be an instance of WatchTime type.");
                int hour = watchTime.Hour;
                Assert.IsTrue(hour > 0.0f, "The hour is not correct!");
            }
            else
            {
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Hour24. Check whether Hour24 is readable.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.Hour24 A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Hour24_GET_VALUE()
        {
            /* TEST CODE */
            if (IsWearable())
            {
                var watchTime = new WatchTime();
                Assert.IsInstanceOf<WatchTime>(watchTime, "Should be an instance of WatchTime type.");
                int hour24 = watchTime.Hour24;
                Assert.IsTrue(hour24 >= 0.0f, "The hour24 is not correct!");
            }
            else
            {
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Millisecond. Check whether Millisecond is readable.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.Millisecond A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Millisecond_GET_VALUE()
        {
            /* TEST CODE */
            if (IsWearable())
            {
                var watchTime = new WatchTime();
                Assert.IsInstanceOf<WatchTime>(watchTime, "Should be an instance of WatchTime type.");
                int millisecond = watchTime.Millisecond;
                Assert.IsTrue(millisecond >= 0.0f, "The millisecond is not correct!");
            }
            else
            {
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Minute. Check whether Minute is readable.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.Minute A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Minute_GET_VALUE()
        {
            /* TEST CODE */
            if (IsWearable())
            {
                var watchTime = new WatchTime();
                Assert.IsInstanceOf<WatchTime>(watchTime, "Should be an instance of WatchTime type.");
                int minute = watchTime.Minute;
                Assert.IsTrue(minute >= 0.0f, "The minute is not correct!");
            }
            else
            {
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Month. Check whether Month is readable.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.Month A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Month_GET_VALUE()
        {
            /* TEST CODE */
            if (IsWearable())
            {
                var watchTime = new WatchTime();
                Assert.IsInstanceOf<WatchTime>(watchTime, "Should be an instance of WatchTime type.");
                int month = watchTime.Month;
                Assert.IsTrue(month > 0.0f, "The month is not correct!");
            }
            else
            {
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Second. Check whether Second is readable.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.Second A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Second_GET_VALUE()
        {
            /* TEST CODE */
            if (IsWearable())
            {
                var watchTime = new WatchTime();
                Assert.IsInstanceOf<WatchTime>(watchTime, "Should be an instance of WatchTime type.");
                int second = watchTime.Second;
                Assert.IsTrue(second >= 0.0f, "The second is not correct!");
            }
            else
            {
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test TimeZone. Check whether TimeZone is readable.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.TimeZone A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void TimeZone_GET_VALUE()
        {
            /* TEST CODE */
            if (IsWearable())
            {
                var watchTime = new WatchTime();
                Assert.IsInstanceOf<WatchTime>(watchTime, "Should be an instance of WatchTime type.");
                string zone = watchTime.TimeZone;
                Assert.IsNotEmpty(zone, "TimeZone is empty");
            }
            else
            {
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Year. Check whether Year is readable.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.Year A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Xianbing teng, xb.teng@samsung.com")]
        public void Year_GET_VALUE()
        {
            /* TEST CODE */
            if (IsWearable())
            {
                var watchTime = new WatchTime();
                Assert.IsInstanceOf<WatchTime>(watchTime, "Should be an instance of WatchTime type.");
                int year = watchTime.Year;
                Assert.IsTrue(year > 0.0f, "The Year is not correct!");
            }
            else
            {
                Assert.Pass("Not Supported profile");
            }
        }
    }
}