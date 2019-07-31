using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Tizen.NUI.Test;

namespace Tizen.NUI.Tests
{

    [TestFixture]
    [Description("Tizen.NUI.Animation Tests")]
    public class AnimationTests
    {
        private string TAG = "NUI";

        [SetUp]
        public void Init()
        {
            Tizen.Log.Info(TAG, "Init() is called!");
            App.MainTitleChangeText("AnimationTests");
            App.MainTitleChangeBackgroundColor(null);
        }

        [TearDown]
        public void Destroy()
        {
            Tizen.Log.Info(TAG, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("dali animation constructor test")]
        [Property("SPEC", "Tizen.NUI.Animation.Animation C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Animation_INIT()
        {
            /* TEST CODE */
            var animation = new Animation();
            Assert.IsInstanceOf<Animation>(animation, "Should return Animation instance.");
        }

        [Test]
        [Category("P1")]
        [Description("dali animation constructor test, with the duration.")]
        [Property("SPEC", "Tizen.NUI.Animation.Animation C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "int")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Animation_INIT_WITH_INT()
        {
            /* TEST CODE */
            var animation = new Animation(3);
            Assert.IsInstanceOf<Animation>(animation, "Should return Animation instance.");
            Assert.AreEqual(3, animation.Duration, "The Duration of the animation should be 3");
        }

        [Test]
        [Category("P1")]
        [Description("Test Properties. Check whether Properties is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Animation.Properties A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Properties_SET_GET_VALUE()
        {
            /* TEST CODE */
            var animation = new Animation(1000);
            string[] properties = new string[] { "Opacity", "PositionX"};
            animation.Properties = properties;
            Assert.AreEqual("Opacity", animation.Properties[0], "The Properties[0] value of the animation is not correct here.");
            Assert.AreEqual("PositionX", animation.Properties[1], "The Properties[1] value of the animation is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test DestValue. Check whether DestValue is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Animation.DestValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void DestValue_SET_GET_VALUE()
        {
            /* TEST CODE */
            var animation = new Animation(1000);
            string[] destValue = new string[] { "0.0f", "960,540" };
            animation.DestValue = destValue;
            Assert.AreEqual("0.0f", animation.DestValue[0], "The DestValue[0] value of the animation is not correct here.");
            Assert.AreEqual("960,540", animation.DestValue[1], "The DestValue[1] value of the animation is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test StartTime. Check whether StartTime is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Animation.StartTime A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void StartTime_SET_GET_VALUE()
        {
            /* TEST CODE */
            var animation = new Animation(3000);
            int[] startTime = new int[] { 0, 1000 };
            animation.StartTime = startTime;
            Assert.AreEqual(0, animation.StartTime[0], "The StartTime[0] value of the animation is not correct here.");
            Assert.AreEqual(1000, animation.StartTime[1], "The StartTime[1] value of the animation is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test EndTime. Check whether EndTime is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Animation.EndTime A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EndTime_SET_GET_VALUE()
        {
            /* TEST CODE */
            var animation = new Animation(3000);
            int[] endTime = new int[] { 1000, 3000 };
            animation.EndTime = endTime;
            Assert.AreEqual(1000, animation.EndTime[0], "The EndTime[0] value of the animation is not correct here.");
            Assert.AreEqual(3000, animation.EndTime[1], "The EndTime[1] value of the animation is not correct here.");
        }

        [Test]
        [Category("P1")]
        [Description("Test PlayAnimateTo. Check whether PlayAnimateTo works or not.")]
        [Property("SPEC", "Tizen.NUI.Animation.PlayAnimateTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task PlayAnimateTo_CHECK_STATE()
        {
            /* TEST CODE */
            var animation = new Animation(3000);

            string[] properties = new string[] { "Opacity", "PositionX" };
            animation.Properties = properties;

            string[] destValue = new string[] { "0.0", "960" };
            animation.DestValue = destValue;

            int[] startTime = new int[] { 0, 1000 };
            animation.StartTime = startTime;

            int[] endTime = new int[] { 1000, 3000 };
            animation.EndTime = endTime;

            View view = new View();
            view.Position2D = new Position2D(0, 0);
            view.Size2D = new Size2D(200, 200);
            view.BackgroundColor = Color.Red;
            Window.Instance.Add(view);

            try
            {
                animation.PlayAnimateTo(view);
                await Task.Delay(3020);
                Assert.AreEqual(view.PositionX, 960.0f, "PositionX is not correct!");
                Assert.AreEqual(view.Opacity, 0.0f, "Opacity is not correct!");
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
        [Description("Test AnimateTo. Animate the property to the target value.")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("COVPARAM", "View, string, object, AlphaFunction")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task AnimateTo_CHECK_STATE_WITH_ACTOR_STRING_OBJECT_ALPHAFUNCTION()
        {
            /* TEST CODE */
            View actor = new View();
            actor.Position = new Position(100.0f, 50.0f, 60.0f);
            Window.Instance.GetDefaultLayer().Add(actor);

            Animation animation = new Animation(1000);
            Position targetValue = new Position(0.0f, 0.0f, 0.0f);
            animation.AnimateTo(actor, "Position", targetValue, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.Play();

            await Task.Delay(1020);
            Assert.AreEqual(actor.Position.X, 0.0f, "Position.X is not correct!");
            Assert.AreEqual(actor.Position.Y, 0.0f, "Position.Y is not correct!");
            Assert.AreEqual(actor.Position.Z, 0.0f, "Position.Z is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test AnimateTo. Animate the property to the target value from startTime to endTime")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateTo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("COVPARAM", "View, string, object, int, int, AlphaFunction")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task AnimateTo_CHECK_STATE_WITH_ACTOR_STRING_OBJECT_INT_INT_ALPHAFUNCTION()
        {
            /* TEST CODE */
            View actor = new View();
            actor.Position = new Position(100.0f, 50.0f, 60.0f);
            Window.Instance.GetDefaultLayer().Add(actor);

            Animation animation = new Animation(1000);
            Position targetValue = new Position(0.0f, 0.0f, 0.0f);
            animation.AnimateTo(actor, "Position", targetValue, 500, 1000, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.Play();

            await Task.Delay(1020);
            Assert.AreEqual(actor.Position.X, 0.0f, "Position.X is not correct!");
            Assert.AreEqual(actor.Position.Y, 0.0f, "Position.Y is not correct!");
            Assert.AreEqual(actor.Position.Z, 0.0f, "Position.Z is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test AnimateBy. Animate the property by the ralative value.")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("COVPARAM", "View, string, object, AlphaFunction")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task AnimateBy_CHECK_STATE_WITH_ACTOR_STRING_OBJECT_ALPHAFUNCTION()
        {
            /* TEST CODE */
            View actor = new View();
            actor.PositionX = 0.0f;
            Window.Instance.GetDefaultLayer().Add(actor);

            Animation animation = new Animation(1000);
            float targetValue = 100.0f;
            animation.AnimateBy(actor, "PositionX", targetValue, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.Play();

            await Task.Delay(500);
            Assert.AreEqual(actor.PositionX, 100.0f, "PositionX is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test AnimateBy. Animate the property by the ralative value from startTime to endTime.")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateBy M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("COVPARAM", "View, string, object, int, int, AlphaFunction")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task AnimateBy_CHECK_STATE_WITH_ACTOR_STRING_OBJECT_INT_INT_ALPHAFUNCTION()
        {
            /* TEST CODE */
            View actor = new View();
            actor.PositionX = 0.0f;
            Window.Instance.GetDefaultLayer().Add(actor);

            Animation animation = new Animation(1000);
            float targetValue = 100.0f;
            animation.AnimateBy(actor, "PositionX", targetValue, 500, 1000, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.Play();

            await Task.Delay(600);
            Assert.AreEqual(actor.PositionX, 100.0f, "PositionX is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test AnimateBetween. Animate the property between keyframes.")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateBetween M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("COVPARAM", "View, string, KeyFrames, Interpolation, AlphaFunction")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task AnimateBetween_CHECK_STATE_WITH_ACTOR_STRING_OBJECT_ALPHAFUNCTION()
        {
            /* TEST CODE */
            View actor = new View();
            Window.Instance.GetDefaultLayer().Add(actor);
            actor.PositionX = 0.0f;
            Animation animation = new Animation(1000);
            KeyFrames keyFrames = new KeyFrames();
            keyFrames.Add(0.0f, 0.0f);
            keyFrames.Add(0.2f, 0.5f);
            keyFrames.Add(0.4f, 0.8f);
            keyFrames.Add(1.0f, 1.0f);
            animation.AnimateBetween(actor, "PositionX", keyFrames, Animation.Interpolation.Linear, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.Play();

            await Task.Delay(500);
            Assert.AreEqual(1.0f, actor.PositionX, "The PositionX of the actor is not correct here!");
        }


        [Test]
        [Category("P1")]
        [Description("Test AnimateBetween. Animate the property between keyframes from startTime to endTime.")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimateBetween M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("COVPARAM", "View, string, KeyFrames, int, int, Interpolation, AlphaFunction")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task AnimateBetween_CHECK_STATE_WITH_ACTOR_STRING_OBJECT_INT_INT_ALPHAFUNCTION()
        {
            /* TEST CODE */
            View actor = new View();
            Window.Instance.GetDefaultLayer().Add(actor);
            actor.PositionX = 0.0f;
            Animation animation = new Animation(1000);
            KeyFrames keyFrames = new KeyFrames();
            keyFrames.Add(0.0f, 0.0f);
            keyFrames.Add(0.2f, 0.5f);
            keyFrames.Add(0.4f, 0.8f);
            keyFrames.Add(1.0f, 1.0f);
            animation.AnimateBetween(actor, "PositionX", keyFrames, 0, 1000, Animation.Interpolation.Linear, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.Play();

            await Task.Delay(500);
            Assert.AreEqual(1.0f, actor.PositionX, "The PositionX of the actor is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test AnimatePath. Animate the property to the target value.")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimatePath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("COVPARAM", "View, Path, vector3, AlphaFunction")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task AnimatePath_CHECK_STATE_WITH_VIEW_PATH_VECTOR3_OBJECT_ALPHAFUNCTION()
        {
            /* TEST CODE */
            View view = new View();
            view.Size = new Size(200, 200, 0);
            view.Position = new Position(0, 0, 0);
            view.PivotPoint = PivotPoint.TopLeft;
            view.BackgroundColor = Color.Red;

            Window.Instance.GetDefaultLayer().Add(view);
            Path path = new Path();
            path.AddPoint(new Position(30, 80, 0));
            path.AddPoint(new Position(70, 120, 0));
            path.AddPoint(new Position(100, 100, 0));
            path.AddControlPoint(new Vector3(39, 90, 0));
            path.AddControlPoint(new Vector3(56, 119, 0));
            path.AddControlPoint(new Vector3(78, 120, 0));
            path.AddControlPoint(new Vector3(93, 104, 0));

            Animation animation = new Animation(1000);
            animation.AnimatePath(view, path, new Vector3(1, 0, 0), new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.Play();
            Vector3 position = new Vector3();
            Vector3 tangent = new Vector3();
            await Task.Delay(1020);
            path.Sample(1.0f, position, tangent);
            Assert.AreEqual(100, position.X, "Position.X is not correct!");
            Assert.AreEqual(100, position.Y, "Position.Y is not correct!");
            Assert.AreEqual(0, position.Z, "Position.Z is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test AnimatePath. Animate the property to the target value from startTime to endTime")]
        [Property("SPEC", "Tizen.NUI.Animation.AnimatePath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("COVPARAM", "View, Path, vector3, int, int, AlphaFunction")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task AnimatePath_CHECK_STATE_WITH_VIEW_PATH_VECTOR3_INT_INT_ALPHAFUNCTION()
        {
            /* TEST CODE */
            View view = new View();
            view.Size = new Size(200, 200, 0);
            view.Position = new Position(0, 0, 0);
            view.PivotPoint = PivotPoint.TopLeft;
            view.BackgroundColor = Color.Red;

            Window.Instance.GetDefaultLayer().Add(view);
            Path path = new Path();
            path.AddPoint(new Position(30, 80, 0));
            path.AddPoint(new Position(70, 120, 0));
            path.AddPoint(new Position(100, 100, 0));
            path.AddControlPoint(new Vector3(39, 90, 0));
            path.AddControlPoint(new Vector3(56, 119, 0));
            path.AddControlPoint(new Vector3(78, 120, 0));
            path.AddControlPoint(new Vector3(93, 104, 0));

            Animation animation = new Animation(1000);
            animation.AnimatePath(view, path, new Vector3(1, 0, 0), 0, 1000, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.Play();
            Vector3 position = new Vector3();
            Vector3 tangent = new Vector3();
            await Task.Delay(1020);
            path.Sample(1.0f, position, tangent);
            Assert.AreEqual(100, position.X, "Position.X is not correct!");
            Assert.AreEqual(100, position.Y, "Position.Y is not correct!");
            Assert.AreEqual(0, position.Z, "Position.Z is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test CurrentLoop. Check whether CurrentLoop returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Animation.CurrentLoop A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task CurrentLoop_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Window.Instance.GetDefaultLayer().Add(actor);

            Animation animation = new Animation(1000);
            animation.AnimateTo(actor, "Position", new Position(10.0f, 10.0f, 10.0f), new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.LoopCount = 3;
            Assert.AreEqual(0, animation.CurrentLoop);
            animation.Play();
        }

        [Test]
        [Category("P1")]
        [Description("Test CurrentProgress. Check whether CurrentProgress is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Animation.CurrentProgress A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task CurrentProgress_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Window.Instance.GetDefaultLayer().Add(actor);

            Animation animation = new Animation(1000);
            Position targetPosition = new Position(100.0f, 100.0f, 100.0f);
            animation.AnimateTo(actor, "Position", targetPosition, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            Assert.Less(Math.Abs(0.0f - animation.CurrentProgress), 0.00001, "The CurrentProgress of the animation is not correct here!");
            animation.Play();
        }

        [Test]
        [Category("P1")]
        [Description("Test PlayFrom. Check whether the animation will begin with specify progress.")]
        [Property("SPEC", "Tizen.NUI.Animation.ProgressNotification A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task ProgressNotification_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.Position = new Position(0.0f, 0.0f, 0.0f);
            Window.Instance.GetDefaultLayer().Add(actor);
            Animation animation = new Animation(1000);
            animation.ProgressNotification = 0.5f;
            Position targetPosition = new Position(100.0f, 100.0f, 100.0f);
            animation.AnimateTo(actor, "Position", targetPosition, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            await Task.Delay(200);
            Assert.Less(Math.Abs(0.5f - animation.ProgressNotification), 0.00001, "The ProgressNotification of the animation is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test SpeedFactor. Check whether SpeedFactor is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Animation.SpeedFactor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task SpeedFactor_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Window.Instance.GetDefaultLayer().Add(actor);

            Animation animation = new Animation(1000);
            Position targetPosition = new Position(100.0f, 100.0f, 100.0f);
            Position initialPosition = new Position(0.0f, 0.0f, 0.0f);
            KeyFrames keyframes = new KeyFrames();
            keyframes.Add(0.0f, initialPosition);
            keyframes.Add(1.0f, targetPosition);

            animation.AnimateBetween(actor, "Position", keyframes, Animation.Interpolation.Cubic, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));

            animation.SpeedFactor = 2.0f;
            Assert.AreEqual(2.0f, animation.SpeedFactor, "The SpeedFactor of the animation is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test PlayRange. Check whether PlayRange is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Animation.PlayRange A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task PlayRange_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Window.Instance.GetDefaultLayer().Add(actor);
            //Test the default value
            Animation animation = new Animation(1000);
            Position targetPosition = new Position(100.0f, 100.0f, 100.0f);
            animation.PlayRange = new Vector2(0.4f, 0.9f);
            animation.AnimateTo(actor, "Position", targetPosition, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.Play();
            await Task.Delay(200);
            Assert.AreEqual(0.4f, animation.PlayRange.X, "The PlayRange.X of the animation is not correct here!");
            Assert.AreEqual(0.9f, animation.PlayRange.Y, "The PlayRange.Y of the animation is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Stop. Stop the animation with specify EndAction and check the target value.")]
        [Property("SPEC", "Tizen.NUI.Animation.Stop M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("COVPARAM", "EndActions")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Stop_CHECK_STATE_WITH_ENDACTIONS()
        {
            /* TEST CODE */
            View actor = new View();
            actor.PositionX = 0.0f;
            Window.Instance.GetDefaultLayer().Add(actor);

            Animation animation = new Animation(1000);
            float targetPositionX = 1.0f;
            animation.AnimateTo(actor, "PositionX", targetPositionX, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            Assert.AreEqual(animation.EndAction, Animation.EndActions.Cancel, "The EnsActions type should be Animation.EndActions.Cancel");
            animation.Play();
            await Task.Delay(1020);

            animation.Stop(Animation.EndActions.Discard);
            await Task.Delay(100);
            Assert.AreEqual(1.0f, actor.PositionX, "The PositionX of the actor is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Clear. Clear the animation and check the target value.")]
        [Property("SPEC", "Tizen.NUI.Animation.Clear M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Clear_CHECK_STATE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.PositionX = 0.0f;
            Window.Instance.GetDefaultLayer().Add(actor);

            Animation animation = new Animation(1000);
            float targetPositionX = 1.0f;
            animation.AnimateTo(actor, "PositionX", targetPositionX, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.EndAction = Animation.EndActions.Cancel;
            animation.Play();

            await Task.Delay(1020);
            animation.Clear();
            await Task.Delay(100);
            Assert.AreEqual(1.0f, actor.PositionX, "The PositionX of the actor is not correct here!");

        }


        [Test]
        [Category("P1")]
        [Description("Test Looping. Check whether Looping is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Animation.Looping A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Looping_SET_GET_VALUE()
        {
            /* TEST CODE */
            Animation animation = new Animation(3000);
            animation.Looping = true;
            Assert.IsTrue(animation.Looping, "The Looping of the animation is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test EndAction. Check whether EndAction is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Animation.EndAction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void EndAction_SET_GET_VALUE()
        {
            /* TEST CODE */
            Animation animation = new Animation(3000);
            animation.EndAction = Animation.EndActions.Discard;
            Assert.AreEqual(animation.EndAction, Animation.EndActions.Discard, "Test for Animation.EndActions.Discard");
            animation.EndAction = Animation.EndActions.StopFinal;
            Assert.AreEqual(animation.EndAction, Animation.EndActions.StopFinal, "Test for Animation.EndActions.StopFinal");
        }

        [Test]
        [Category("P1")]
        [Description("Test Stop. Stop the animation and check the animation's state.")]
        [Property("SPEC", "Tizen.NUI.Animation.Stop M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Stop_CHECK_STATE()
        {
            /* TEST CODE */
            View actor = new View();
            Window.Instance.GetDefaultLayer().Add(actor);
            actor.PositionX = 0.0f;
            Animation animation = new Animation(1000);
            float targetValue = 0.5f;
            animation.AnimateTo(actor, "PositionX", targetValue, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.Play();
            await Task.Delay(200);
            animation.Stop();
            await Task.Delay(100);
            Assert.AreEqual(Animation.States.Stopped, animation.State, "The State of the animation is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test DisconnectAction. Check whether DisconnectAction is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Animation.DisconnectAction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task DisconnectAction_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Window.Instance.GetDefaultLayer().Add(actor);

            Animation animation = new Animation(1000);
            Position targetPosition = new Position(10.0f, 10.0f, 0.0f);
            animation.AnimateTo(actor, "Position", targetPosition, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            Assert.AreEqual(Animation.EndActions.StopFinal, animation.DisconnectAction, "Test for Animation.EndActions.StopFinal");
            animation.Play();

            await Task.Delay(500);
            Window.Instance.GetDefaultLayer().Remove(actor);
            await Task.Delay(20);
            Assert.AreEqual(targetPosition.X, actor.PositionX, "The PositionX of the actor is not correct here!");
            Assert.AreEqual(targetPosition.Y, actor.PositionY, "The PositionY of the actor is not correct here!");
            Assert.AreEqual(targetPosition.Z, actor.PositionZ, "The PositionZ of the actor is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test PlayFrom. Check whether the animation will begin with specify progress.")]
        [Property("SPEC", "Tizen.NUI.Animation.PlayFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task PlayFrom_CHECK_STATE()
        {
            /* TEST CODE */
            try
            {
                View actor = new View();
                actor.Position = new Position(0.0f, 0.0f, 0.0f);
                Window.Instance.GetDefaultLayer().Add(actor);
                Animation animation = new Animation(1000);
                Position targetPosition = new Position(100.0f, 100.0f, 100.0f);

                animation.AnimateTo(actor, "Position", targetPosition, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));

                animation.PlayFrom(0.4f);
                animation.Play();
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
        [Description("Test Dispose, try to dispose the Animation.")]
        [Property("SPEC", "Tizen.NUI.Animation.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Dispose_TEST()
        {
            /* TEST CODE */
            try
            {
                Animation animation = new Animation();
                animation.Dispose();
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
        [Description("Test Play. Play the animation and check the animation's state.")]
        [Property("SPEC", "Tizen.NUI.Animation.Play M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Play_CHECK_STATE()
        {
            /* TEST CODE */
            View actor = new View();
            Window.Instance.GetDefaultLayer().Add(actor);

            Animation animation = new Animation(1000);
            animation.AnimateTo(actor, "Position", new Position(10.0f, 10.0f, 10.0f), new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.Play();
            Assert.AreEqual(Animation.States.Playing, animation.State, "The State of the animation is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test PlayAfter. PlayAfter the animation and check the animation's state.")]
        [Property("SPEC", "Tizen.NUI.Animation.PlayAfter M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task PlayAfter_CHECK_STATE()
        {
            /* TEST CODE */
            View actor = new View();
            actor.Position = new Position(0, 0, 0);
            Window.Instance.GetDefaultLayer().Add(actor);

            Animation animation = new Animation(1000);
            animation.AnimateTo(actor, "Position", new Position(10.0f, 10.0f, 10.0f), new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.PlayAfter(200);
            await Task.Delay(150);
            Assert.AreEqual(0, animation.CurrentProgress, "The animation should be delayed!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Pause. Pause the animation and check the animation's state.")]
        [Property("SPEC", "Tizen.NUI.Animation.Pause M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MCST")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Pause_CHECK_STATE()
        {
            /* TEST CODE */
            View actor = new View();
            Window.Instance.GetDefaultLayer().Add(actor);

            Animation animation = new Animation(1000);
            animation.AnimateTo(actor, "Position", new Position(10.0f, 10.0f, 10.0f), new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.Play();
            animation.Pause();
            Assert.AreEqual(Animation.States.Paused, animation.State, "The State of the animation is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Duration. Check whether Duration is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Animation.Duration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void Duration_SET_GET_VALUE()
        {
            /* TEST CODE */
            Animation animation = new Animation(3);
            Assert.AreEqual(3, animation.Duration, "The Duration of the animation should be 3");
            animation.Duration = 50;
            Assert.AreEqual(50, animation.Duration, "The Duration of the animation should be 50");
        }

        [Test]
        [Category("P1")]
        [Description("Test DefaultAlphaFunction. Check whether DefaultAlphaFunction is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Animation.DefaultAlphaFunction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void DefaultAlphaFunction_SET_GET_VALUE()
        {
            /* TEST CODE */
            Animation animation = new Animation(3000);

            AlphaFunction function = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseIn);
            animation.DefaultAlphaFunction = function;
            Assert.AreEqual(AlphaFunction.BuiltinFunctions.EaseIn, animation.DefaultAlphaFunction.GetBuiltinFunction(), "The BuiltinFunctions type of the animation is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test State. Check whether State returns expected value or not.")]
        [Property("SPEC", "Tizen.NUI.Animation.State A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void State_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Window.Instance.GetDefaultLayer().Add(actor);
            Animation animation = new Animation(1000);
            animation.AnimateTo(actor, "Position", new Position(100.0f, 100.0f, 100.0f), new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.Play();
            Assert.AreEqual(Animation.States.Playing, animation.State, "The animation's State is not correct!");
        }

        [Test]
        [Category("P1")]
        [Description("Test LoopCount. Check whether LoopCount is readable and writable.")]
        [Property("SPEC", "Tizen.NUI.Animation.LoopCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public void LoopCount_SET_GET_VALUE()
        {
            /* TEST CODE */
            View actor = new View();
            Window.Instance.GetDefaultLayer().Add(actor);

            Animation animation = new Animation(1000);
            animation.LoopCount = 3;
            float targetValue = 0.5f;
            animation.AnimateTo(actor, "PositionX", targetValue, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            Assert.AreEqual(3, animation.LoopCount, "The LoopCount of the animation is not correct here!");
        }

        [Test]
        [Category("P1")]
        [Description("Test Finished. Check whether the Finished event triggered when the animation finished")]
        [Property("SPEC", "Tizen.NUI.Animation.Finished E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task Finished_CHECK_EVENT()
        {
            /* TEST CODE */
            bool flag = false;
            View actor = new View();
            Window.Instance.GetDefaultLayer().Add(actor);

            Animation animation = new Animation(1000);
            float targetValue = 1.0f;
            animation.AnimateTo(actor, "PositionX", targetValue, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.Finished += (obj, e) =>
            {
                flag = true;
            };
            animation.Play();
            await Task.Delay(2000);
            Assert.AreEqual(targetValue, actor.PositionX, "PositionX is not correct!");
            Assert.IsTrue(flag, "The finished Event is incorrect!");

        }

        [Test]
        [Category("P1")]
        [Description("Test ProgressReached. Check whether the ProgressReached event triggered when the animation reach the progress notification.")]
        [Property("SPEC", "Tizen.NUI.Animation.ProgressReached E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "Feng Jin, feng16.jin@samsung.com")]
        public async Task ProgressReached_CHECK_EVENT()
        {
            /* TEST CODE */
            bool flag = false;
            View actor = new View();
            Window.Instance.GetDefaultLayer().Add(actor);

            Animation animation = new Animation(1000);
            float targetValue = 0.5f;
            animation.ProgressNotification = 0.5f;
            animation.AnimateTo(actor, "PositionX", targetValue, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
            animation.ProgressReached += (obj, e) =>
            {
                flag = true;
            };
            animation.Play();
            await Task.Delay(2000);
            Assert.IsTrue(flag, "The ProgressReached Event is incorrect!");
        }

        [Test]
        [Category("P1")]
        [Description("Test DownCast. Get the Animation instance from a handle instance")]
        [Property("SPEC", "Tizen.NUI.Animation.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Xianbing Teng, xb.teng@samsung.com")]
        public void DownCast_CHECK_RETURN_TYPE()
        {
            /* TEST CODE */
            BaseHandle handle = new Animation();
            Animation animation = Animation.DownCast(handle);
            Assert.IsInstanceOf<Animation>(animation, "Should return a instance of Animation");
        }
    }
}
