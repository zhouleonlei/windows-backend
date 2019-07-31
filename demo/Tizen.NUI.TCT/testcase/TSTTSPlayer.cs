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
    [Description("Tizen.NUI.TTSPlayer Tests")]
    public class TTSPlayerTests
    {
        private string TAG = "NUI";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("TTSPlayerTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get.Check whether Get() function could get an TTSPlayer instance successfully.")]
        [Property("SPEC", "Tizen.NUI.TTSPlayer.Get M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void Get_RETURN_VALUE()
        {
            TTSPlayer player = TTSPlayer.Get();
            Assert.NotNull(player, "Should not be null to the ttsplayer.Get");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get.Check whether Instance property return a TTSPlayer instance successfully.")]
        [Property("SPEC", "Tizen.NUI.TTSPlayer.Instance A")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Instance_READ_ONLY()
        {
            TTSPlayer instance = TTSPlayer.Instance;
            Assert.NotNull(instance, "Should not be null to the ttsplayer.Instance");
        }

        [Test]
        [Category("P1")]
        [Description("Test Get.Check whether Get(TTSMode) function could get an TTSPlayer instance successfully.")]
        [Property("SPEC", "Tizen.NUI.TTSPlayer.Get M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "TTSMode")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void Get_RETURN_VALUE_WITH_TTSMODE()
        {
            TTSPlayer player = TTSPlayer.Get(TTSPlayer.TTSMode.ScreenReader);
            Assert.NotNull(player, "Should not be null to the ttsplayer.Get");
        }

        [Test]
        [Category("P1")]
        [Description("Test Play.Check whether Play function works or not.")]
        [Property("SPEC", "Tizen.NUI.TTSPlayer.Play M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void Play_NO_RETURN_VALUE()
        {
            TTSPlayer player = TTSPlayer.Get(TTSPlayer.TTSMode.ScreenReader);

            try
            {
                player.Play("test");
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Stop.Check whether Stop function works or not.")]
        [Property("SPEC", "Tizen.NUI.TTSPlayer.Stop M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void Stop_NO_RETURN_VALUE()
        {
            TTSPlayer player = TTSPlayer.Get(TTSPlayer.TTSMode.ScreenReader);

            try
            {
                player.Stop();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Pause.Check whether Pause function works or not.")]
        [Property("SPEC", "Tizen.NUI.TTSPlayer.Pause M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void Pause_NO_RETURN_VALUE()
        {
            TTSPlayer player = TTSPlayer.Get(TTSPlayer.TTSMode.ScreenReader);

            try
            {
                player.Pause();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test Resume.Check whether Resume function works or not.")]
        [Property("SPEC", "Tizen.NUI.TTSPlayer.Resume M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void Resume_NO_RETURN_VALUE()
        {
            TTSPlayer player = TTSPlayer.Get(TTSPlayer.TTSMode.ScreenReader);

            try
            {
                player.Resume();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test GetState.Check whether GetState function works or not.")]
        [Property("SPEC", "Tizen.NUI.TTSPlayer.GetState M")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public void GetState_RETURN_VALUE()
        {
            TTSPlayer player = TTSPlayer.Get(TTSPlayer.TTSMode.ScreenReader);
            TTSPlayer.TTSState stat = player.GetState();
            Assert.AreEqual(TTSPlayer.TTSState.Unavailable, stat, "Should be equals to TTSPlayer.TTSState.Playing set");
        }

        [Test]
        [Category("P1")]
        [Description("Test StateChanged.Check whether StateChanged function works or not.")]
        [Property("SPEC", "Tizen.NUI.TTSPlayer.StateChanged E")]
        [Property("SPEC_URL", " - ")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Fang Xiaohui, xiaohui.fang@samsung.com")]
        public async Task StateChanged_CHECK_EVENT()
        {
            TTSPlayer.TTSState stat = TTSPlayer.TTSState.Unavailable;
            TTSPlayer player = TTSPlayer.Get(TTSPlayer.TTSMode.Default);

            for (int i = 0; i < (int)TTSPlayer.TTSMode.ModeNum; i++)
            {
                player = TTSPlayer.Get((TTSPlayer.TTSMode)i);
                stat = player.GetState();
                if (stat == TTSPlayer.TTSState.Unavailable)
                {
                    Tizen.Log.Fatal(TAG, "TTS Player is NOT available in this target! Need to Check! TTSMode=" + (TTSPlayer.TTSMode)i);
                }
                else
                {
                    Tizen.Log.Fatal(TAG, "TTS Player is available in this target! TTSMode=" + (TTSPlayer.TTSMode)i);
                    break;
                }
            }

            bool flag = false;
            if (stat == TTSPlayer.TTSState.Unavailable)
            {
                Tizen.Log.Fatal(TAG, "TTS Player is NOT available in this target! Need to Check!");
                flag = true;
            }

            player.StateChanged += (obj, e) =>
            {
                flag = true;
            };

            player.Play("test");
            player.Pause();
            await Task.Delay(20);

            Assert.IsTrue(flag, "StateChanged is not be called");
        }
    }
}