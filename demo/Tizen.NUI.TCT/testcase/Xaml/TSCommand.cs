using NUnit.Framework;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.Binding.Command Tests")]
    public class CommandTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Setup()
        {
            Tizen.Log.Info(TAG, "BindablePropertyTests-------------- - Setup()");
        }

        [TearDown]
        public void TearDown()
        {
            Tizen.Log.Info(TAG, "BindablePropertyTests-------------- - TearDown()");
        }


        [Test]
        [Category("P1")]
        [Description("Test Construct. Check Command construct.")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action<Object>")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Command_INIT_WITH_ACTIONOBJES()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check Command construct.")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Command_INIT_WITH_ACTION()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check Command construct.")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action<Object>, Func<Object, Boolean>")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Command_INIT_WITH_ACTIONOBJES_FUNCOBJESBOOLES()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Construct. Check Command construct.")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Command C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "Action, Func<Boolean>")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Command_INIT_WITH_ACTION_FUNCBOOLES()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test CanExecute. Check CanExecute() of Command.")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.CanExecute M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void CanExecute_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test Execute. Check Execute() of Command.")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.Execute M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void Execute_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test ChangeCanExecute. Check ChangeCanExecute() of Command.")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.ChangeCanExecute M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void ChangeCanExecute_CHECK_RETURN_VALUE()
        {
            /* TEST CODE */
        }

        [Test]
        [Category("P1")]
        [Description("Test CanExecuteChanged. Test whether the CanExecuteChanged event will be triggered.")]
        [Property("SPEC", "Tizen.NUI.Binding.Command.CanExecuteChanged E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Xiaohui Fang, xiaohui.fang@samsung.com")]
        public void CanExecuteChanged_CHECK_EVENT()
        {
            /* TEST CODE */
        }


    }
}
