using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.TTSPlayer.StateChangedEventArgs Tests")]
    public class StateChangedEventArgsTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("StateChangedEventArgsTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Create a StateChangedEventArgs object. Check whether StateChangedEventArgs is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.TTSPlayer.StateChangedEventArgs.StateChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void StateChangedEventArgs_INIT()
        {
            /* TEST CODE */
            var stateChangedEventArgs = new TTSPlayer.StateChangedEventArgs();
            Assert.IsNotNull(stateChangedEventArgs, "Can't create success object StateChangedEventArgs");
            Assert.IsInstanceOf<TTSPlayer.StateChangedEventArgs>(stateChangedEventArgs, "Should be an instance of StateChangedEventArgs type.");
        }

        [Test]
        [Category("P1")]
        [Description("Test NextState. Check whether NextState is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.TTSPlayer.StateChangedEventArgs.NextState A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA","PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void NextState_SET_GET_VALUE()
        {
            /* TEST CODE */
            TTSPlayer.StateChangedEventArgs stateChangedEventArgs = new TTSPlayer.StateChangedEventArgs();
            stateChangedEventArgs.NextState = TTSPlayer.TTSState.Playing;
            Assert.AreEqual(TTSPlayer.TTSState.Playing, stateChangedEventArgs.NextState, "Retrieved NextState should be equal to set value");
        }

        [Test]
        [Category("P1")]
        [Description("Test PrevState. Check whether PrevState is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.TTSPlayer.StateChangedEventArgs.PrevState A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Wu Youxia, youxia.wu@partner.samsung.com")]
        public void PrevState_SET_GET_VALUE()
        {
            /* TEST CODE */
            TTSPlayer.StateChangedEventArgs stateChangedEventArgs = new TTSPlayer.StateChangedEventArgs();
            stateChangedEventArgs.PrevState = TTSPlayer.TTSState.Playing;
            Assert.AreEqual(TTSPlayer.TTSState.Playing, stateChangedEventArgs.PrevState, "Retrieved PrevState should be equal to set value");
        }
    }
}
