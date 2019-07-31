using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.Timer Tests")]
    public class TimerTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("TimerTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali timer constructor test")]
        [Property("SPEC", "Tizen.NUI.Timer.Timer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Timer_INIT()
        {
            /* TEST CODE */
            var timer = new Timer(100);
            Assert.IsInstanceOf<Timer>(timer, "Should return Timer instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali Interval, Check whether Interval is readable and writable")]
        [Property("SPEC", "Tizen.NUI.Timer.Interval A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Interval_SET_GET_VALUE()
        {
            /* TEST CODE */
            Timer timer = new Timer(100);
            timer.Interval = 2000;
            Assert.AreEqual(2000, timer.Interval, "Interval should be equal to the set value!");
        }

        [Test]
        [Category("P1")]
        [Description("dali timer Start test, start the timer")]
        [Property("SPEC", "Tizen.NUI.Timer.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Start_CHECK_VALUE()
        {
            /* TEST CODE */
            Timer timer = new Timer(100);
            try
            {
                timer.Start();
                Assert.IsTrue(timer.IsRunning(), "The timer should be running now!");
            }
            catch
            {
                Assert.IsFalse(true, "start failed.");
            }
        }

        [Test]
        [Category("P1")]
        [Description("dali timer Stop test, stop the timer")]
        [Property("SPEC", "Tizen.NUI.Timer.Stop M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Stop_CHECK_VALUE()
        {
            /* TEST CODE */
            try
            {
                Timer timer = new Timer(100);
                timer.Start();
                timer.Stop();
                Assert.IsFalse(timer.IsRunning(), "The timer should be stopped now!");
            }
            catch
            {
                Assert.IsFalse(true, "start failed.");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Running, Check whether IsRunning returns expected value or not")]
        [Property("SPEC", "Tizen.NUI.Timer.IsRunning A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void IsRunning_GET_VALUE()
        {
            /* TEST CODE */
            Timer timer = new Timer(100);
            timer.Start();
            timer.Stop();
            Assert.IsFalse(timer.IsRunning(), "The timer should be stopped now!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Tick. Test whether the Tick event will be triggered when the time passed.")]
        [Property("SPEC", "Tizen.NUI.Timer.Tick E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Tick_CHECK_EVENT()
        {
            Timer timer = new Timer(200);
            bool flag = false;
            timer.Tick += (source, e) =>
            {
                flag = true;
                return false;
            };
            timer.Start();
            Tizen.Log.Fatal("NUI", $"Tick_CHECK_EVENT() : timer.Start() [TimeStamp:{DateTime.Now.ToString("hh:mm:ss.fff")}]");
            await Task.Delay(300);
            timer.Stop();
            Tizen.Log.Fatal("NUI", $"Tick_CHECK_EVENT() : timer.Stop(), flag={flag} [TimeStamp:{DateTime.Now.ToString("hh:mm:ss.fff")}]");
            Assert.IsTrue(flag, "The Tick Event has been triggerred!");
        }

        [Test]
        [Category("P1")]
        [Description("Test DownCast. Get the Timer instance from a handle instance")]
        [Property("SPEC", "Tizen.NUI.Timer.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void DownCast_GET_VALUE()
        {
            /* TEST CODE */
            BaseHandle handle = new Timer(200);
            //Downcast() method will be deprecated. as/is are now supported in NUI.
            Timer timer = handle as Timer;
            Assert.IsInstanceOf<Timer>(timer, "Should return a instance of Timer");
        }

#if false // currently ACR is not yet proceed. temporarily blocked.
        //[Test]
        //[Category("P1")]
        //[Description("Test Dispose, try to dispose the timer.")]
        //[Property("SPEC", "Tizen.NUI.Timer.Dispose M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR MCST")]
        //[Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Timer timer = new Timer(30);
                timer.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }
#endif
    }
}
