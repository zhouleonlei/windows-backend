using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    public class StepIndicator : Control
    {
        protected override Attributes GetAttributes()
        {
            return null;
        }

        public StepIndicator() : base()
        {
            if (stepAttr == null)
            {
                this.attributes = stepAttr = new StepIndicatorAttributes
                {


                };
            }
            Initalize();
        }

        public StepIndicator(string stepsStyle) : base(stepsStyle)
        {
            //stepAttr = StyleSet.GetAttribute(stepsStyle) as Attributes;
            //if (stepAttr != null)
            // {
            Initalize();
            //}
        }

        public StepIndicator(StepIndicatorAttributes attr) : base()
        {
            stepAttr = attr;
            if (stepAttr != null)
            {
                Initalize();
            }
        }

        public string CheckImageURL
        {
            get
            {
                return stepAttr.CheckImageURL.All;
            }
            set
            {
                stepAttr.CheckImageURL.All = value;
                InitChecks();
            }
        }

        public Size2D NormalStepTextAtrSize
        {
            get
            {
                return stepAttr.NormalStepTextAtr.Size2D;
            }
            set
            {
                stepAttr.NormalStepTextAtr.Size2D = value;
            }
        }

        /// <summary>
        /// set total steps when init
        /// get total steps
        /// </summary>
        /// <param name="value"> number of steps </param>
        public int Steps
        {
            get
            {
                return steps;
            }
            set
            {
                steps = value;
                skipable = new bool[steps];
                for (int i = 0; i < steps; i++)
                {
                    skipable[i] = false;
                }
                InitStepLabels();
                InitChecks();
                if (stepLabels.Count > 0)
                {
                    stepLabels[0].Scale = new Vector3(1.2f, 1.2f, 0.0f);
                }
            }

        }

        public Size StepSize
        {
            get
            {

                return stepAttr.StepSize;
            }
            set
            {
                //SetValue(TrackImageAttributesProperty, value);
                stepAttr.StepSize = value;
                LayoutStepLabels();
            }
        }

        public Size LeftArrowSize
        {
            get
            {
                return leftArrow.Size;
            }
            set
            {
                leftArrow.Size = value;
            }
        }

        public Size RightArrowSize
        {
            get
            {
                return leftArrow.Size;
            }
            set
            {
                leftArrow.Size = value;
            }
        }

        public string LeftArrowURL
        {
            get
            {
                return leftArrow.ResourceUrl;
            }
            set
            {
                leftArrow.ResourceUrl = value;
            }
        }

        public string RightArrowURL
        {
            get
            {
                return rightArrow.ResourceUrl;
            }
            set
            {
                rightArrow.ResourceUrl = value;
            }
        }

        //public TextLabel tt
        //{
        //    set
        //    {
        //        return focusStep;
        //    }
        //}

        /// <summary>
        /// set current step to jump forward or backward
        /// get current step
        /// </summary>
        public int CurrentStep
        {
            get
            {
                return currentStep + 1;
            }
        }

        /// <summary>
        /// set init status of all steps
        /// get now status of all steps
        /// </summary>
        /// <param name="index">step index</param>
        /// <param name="enable">skipable or not</param>
        /// <exception cref="ArgumentOutOfRangeException">Throw when index is less than 1, or greater than steps.</exception>
        /// <example>
        /// <code>
        /// Stepindicator stepCtrol;
        /// try
        /// {
        ///     stepCtrol.Steps= 10;
        ///     stepCtrol.SetSkipable(11, true);
        /// }
        /// catch(ArgumentOutOfRangeException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to set skipable : " + e.Message);
        /// }
        /// </code>
        /// </example>
        public void SetSkipable(int index, bool enable)
        {
            if (index <= 0 || index > steps)
            {
                throw new ArgumentOutOfRangeException("index is out of steps");
            }
            skipable[index - 1] = enable;
            //if(index - 1 == currentStep)
            //{
            //    rightIndicateText.Text = skipText;
            //}
        }

        /// <summary>
        /// move to previous step
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when back to less than step 0.</exception>
        /// <example>
        /// <code>
        /// Stepindicator stepCtrol;
        /// try
        /// {
        ///     stepCtrol.Back();
        /// }
        /// catch(ArgumentOutOfRangeException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to move back : " + e.Message);
        /// }
        /// </code>
        /// </example>
        public void Back()
        {
            if (currentStep == 0)
            {
                return;
            }

            //StopPlayer(checkAniPlayer);
            //StopPlayer(focusAniPlayer);

            if (currentStep < steps)
            {
                checkIcons[currentStep].Hide();
                stepLabels[currentStep].Show();
                stepLabels[currentStep].Scale = new Vector3(1.0f, 1.0f, 0.0f);
                stepLabels[currentStep].Opacity = 1.0f;
            }
            currentStep--;
            if (currentStep >= 0)
            {
                checkIcons[currentStep].Hide();
                stepLabels[currentStep].Show();
                stepLabels[currentStep].Scale = new Vector3(1.2f, 1.2f, 0.0f);
                stepLabels[currentStep].Opacity = 1.0f;
            }
            UpdateIndicate(rtlEnable);
        }

        /// <summary>
        /// move to next step
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when move next to larger than steps-1.</exception>
        /// <example>
        /// <code>
        /// Stepindicator stepCtrol;
        /// try
        /// {
        ///     stepCtrol.Next();
        /// }
        /// catch(ArgumentOutOfRangeException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to move next : " + e.Message);
        /// }
        /// </code>
        /// </example>
        public void Next()
        {
            if (currentStep >= steps)
            {
                return;
            }
            //PlayCheckMotion(stepLabels[currentStep]);
            CheckStep(currentStep);
            currentStep++;

            if (currentStep < steps)
            {
                //PlayFocusMotion(stepLabels[currentStep]);
            }
            UpdateIndicate(rtlEnable);
        }

        /// <summary>
        /// skip next step
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Throw when skip to larger than steps-1.</exception>
        /// <example>
        /// <code>
        /// Stepindicator stepCtrol;
        /// try
        /// {
        ///     stepCtrol.Skip();
        /// }
        /// catch(ArgumentOutOfRangeException e)
        /// {
        ///     Tizen.Log.Error(LogTag, "Failed to skip : " + e.Message);
        /// }
        /// </code>
        /// </example>
        public void Skip()
        {
            if (currentStep >= steps)
            {
                return;
            }
            stepLabels[currentStep].Scale = new Vector3(1.0f, 1.0f, 0.0f);
            stepLabels[currentStep].Opacity = 0.4f;
            currentStep++;

            if (currentStep < steps)
            {
                //PlayFocusMotion(stepLabels[currentStep]);
            }
            UpdateIndicate(rtlEnable);
        }

        /// <summary>
        /// set/get text for next indicate
        /// </summary>
        public string NextText
        {
            set
            {
                nextText = value;
                //if (!skipable[currentStep])
                //{
                //    rightIndicateText.Text = value;
                //}
            }

            get
            {
                return nextText;
            }
        }

        /// <summary>
        /// set/get text for previous indicate
        /// </summary>
        public string PreviousText
        {
            set
            {
                previousText = value;
                //leftIndicateText.Text = value;               
            }

            get
            {
                return previousText;
            }
        }

        /// <summary>
        /// set text for skip indicate
        /// </summary>  
        public string SkipText
        {
            set
            {
                skipText = value;
                //if (skipable[currentStep])
                //{
                //    rightIndicateText.Text = value;
                //}  
            }
            get
            {
                return skipText;
            }

        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                //UIDirectionChangedEvent -= OnUIDirectionChagned;
                tapGestrueDector.Detected -= OnTapGestrueDetected;
                tapGestrueDector.Dispose();
                tapGestrueDector = null;

                foreach (TextLabel item in stepLabels)
                {
                    if (item != null)
                    {
                        Remove(item);
                        item.Dispose();
                    }
                }
                stepLabels.Clear();

                foreach (ImageView item in checkIcons)
                {
                    if (item != null)
                    {
                        Remove(item);
                        item.Dispose();
                    }
                }
                checkIcons.Clear();

                if (leftArrow != null)
                {
                    Remove(leftArrow);
                    leftArrow.Dispose();
                    leftArrow = null;
                }
                if (rightArrow != null)
                {
                    Remove(rightArrow);
                    rightArrow.Dispose();
                    rightArrow = null;
                }
                if (leftIndicateText != null)
                {
                    Remove(leftIndicateText);
                    leftIndicateText.Dispose();
                    leftIndicateText = null;
                }
                if (rightIndicateText != null)
                {
                    Remove(rightIndicateText);
                    rightIndicateText.Dispose();
                    rightIndicateText = null;
                }
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            //Unreference this from if a static instance refer to this. 

            //You must call base.Dispose(type) just before exit.
            base.Dispose(type);
        }

        protected override void OnUpdate(Attributes attrs)
        {
            if (attrs != null)
                stepAttr = attrs as StepIndicatorAttributes;

            if (stepAttr == null)
            {
                return;
            }

            if (stepLabels.Count == 0 && steps > 0)
            {
                InitStepLabels();
                InitChecks();
                stepLabels[0].Scale = new Vector3(1.2f, 1.2f, 0.0f);
            }

            if (stepAttr.LeftArrowIconAttr != null)
            {
                ApplyAttributes(leftArrow, stepAttr.LeftArrowIconAttr);
            }

            if (stepAttr.RightArrowIconAttr != null)
            {
                ApplyAttributes(rightArrow, stepAttr.RightArrowIconAttr);
            }

            if (stepAttr.LeftTextAttr != null)
            {
                ApplyAttributes(leftIndicateText, stepAttr.LeftTextAttr);
            }
            if (stepAttr.RightTextAttr != null)
            {
                ApplyAttributes(rightIndicateText, stepAttr.RightTextAttr);
            }
            if (stepAttr.StepSize != null || stepAttr.NormalStepTextAtr != null)
            {
                LayoutStepLabels();
            }
            if (stepAttr.StepSize != null)
            {
                LayoutChecks(stepAttr);
            }

            UpdateIndicate(rtlEnable);
        }

        private void Initalize()
        {
            //UIDirectionChangedEvent += OnUIDirectionChagned;
            //rtlEnable = SystemProperty.Instance.UIDirection == UIDirection.RTL ? true : false;
            LayoutArrows();
            LayoutIndicateTexts();

            tapGestrueDector = new TapGestureDetector();
            tapGestrueDector.Attach(leftArrow);
            tapGestrueDector.Attach(rightArrow);
            tapGestrueDector.Detected += OnTapGestrueDetected;


        }

        private void OnTapGestrueDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            ImageView obj = e.View as ImageView;
            if (1 == e.TapGesture.NumberOfTaps)
            {
                if (obj == leftArrow)
                {
                    Back();
                }
                else if (obj == rightArrow)
                {
                    Console.WriteLine("!!!!!");
                    Console.WriteLine("!!!!!  Tap right");
                    Next();
                }
                else
                {
                    // Do nothing
                }
            }
        }

        //private void StopPlayer(AnimationPlayer player)
        //{
        //    if (player != null && player.State == AnimationPlayer.States.Playing)
        //    {
        //        player.Stop(AnimationPlayer.EndActions.StopFinal);
        //    }
        //}

        //private void PlayCheckMotion(TextLabel aniObj)
        //{
        //    StopPlayer(checkAniPlayer);

        //    if (checkAniPlayer == null)
        //    {
        //        checkAniPlayer = new AnimationPlayer(aniObj, TVMotionType.Hide);
        //        checkAniPlayer.Duration = Constants.DURATION_FOCUS_OUT;
        //    }

        //    checkAniPlayer.Clear();

        //    AnimationParameter addParam = checkAniPlayer.DefaultParam.Clone();
        //    addParam.Animatees.Clear();
        //    addParam.Animatees.Add(aniObj);
        //    addParam.StartTime = 0;
        //    addParam.EndTime = Constants.DURATION_HIDE;
        //    checkAniPlayer.AnimateTo(addParam);

        //    addParam.Property = "Scale";
        //    addParam.DestinationValue = new Vector3(Constants.SCALE_SHRINK, Constants.SCALE_SHRINK, Constants.SCALE_ORIGINAL);
        //    addParam.CurveType = AnimationCurve.Out;

        //    checkAniPlayer.AnimateTo(addParam);

        //    addParam.Dispose();
        //    addParam = null;

        //    checkAniPlayer.Play();
        //}

        //private void PlayFocusMotion(TextLabel aniObj)
        //{
        //    StopPlayer(focusAniPlayer);

        //    if (focusAniPlayer == null)
        //    {
        //        focusAniPlayer = new AnimationPlayer(aniObj, TVMotionType.FocusIn);
        //    }

        //    focusAniPlayer.Clear();

        //    AnimationParameter addParam = focusAniPlayer.DefaultParam.Clone();
        //    addParam.Animatees.Clear();
        //    addParam.Animatees.Add(aniObj);
        //    focusAniPlayer.AnimateTo(addParam);

        //    addParam.Dispose();
        //    addParam = null;

        //    focusAniPlayer.Play();
        //}

        private void CheckStep(int overStep)
        {
            ImageView checkImage = checkIcons[overStep];
            checkImage.Show();
            //if (frameAni == null)
            //{
            //    frameAni = new FrameAnimation
            //    {
            //        ImageArray = stepAttr.CheckImageArray
            //    };
            //}
            //frameAni.Stop(Animation.EndActions.StopFinal);
            //frameAni.Attach(checkImage);
            //frameAni.Play();
        }

        private void InitStepLabels()
        {
            for (int i = 0; i < steps; i++)
            {
                TextLabel stepText = new TextLabel
                {
                    Text = (i + 1).ToString(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center
                };

                stepLabels.Insert(i, stepText);
                Add(stepLabels[i]);
            }
        }

        private void LayoutStepLabels()
        {
            if (steps == 0 || stepLabels.Count == 0)// || attr == null)
            {
                return;
            }
            float halfPos = stepAttr.StepSize.Width * steps / 2.0f;
            for (int i = 0; i < stepLabels.Count; i++)
            {
                float posX = stepAttr.StepSize.Width * (i + 0.5f) - halfPos;
                if (rtlEnable)
                {
                    posX = -posX;
                }
                TextLabel stepText = stepLabels[i];
                if (stepAttr.NormalStepTextAtr.FontFamily != null)
                    stepText.FontFamily = stepAttr.NormalStepTextAtr.FontFamily;
                if (stepAttr.NormalStepTextAtr.PointSize != null)
                    stepText.PointSize = (float)stepAttr.NormalStepTextAtr.PointSize.All;
                if (stepAttr.NormalStepTextAtr.TextColor != null)
                    stepText.TextColor = stepAttr.NormalStepTextAtr.TextColor.All;
                stepText.Size = stepAttr.StepSize;
                stepText.Position = new Position(posX, 0, 0);
            }
        }

        private void InitChecks()
        {
            checkIcons.Clear();
            global::System.Console.WriteLine("!!! init checks");
            for (int i = 0; i < steps; i++)
            {
                ImageView checkIcon = new ImageView
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center
                };
                checkIcon.ResourceUrl = stepAttr.CheckImageURL.All;
                checkIcons.Insert(i, checkIcon);
                Add(checkIcons[i]);
                checkIcon.Hide();
            }
        }

        private void LayoutChecks(StepIndicatorAttributes attr)
        {
            global::System.Console.WriteLine("!!! layout checks");
            if (steps == 0 || checkIcons.Count == 0 || attr == null)
            {
                return;
            }
            for (int i = 0; i < checkIcons.Count; i++)
            {
                ImageView checkIcon = checkIcons[i];
                checkIcon.Size = attr.StepSize;
                checkIcon.Position = new Position(stepLabels[i].PositionX, 0, 0);
            }
        }

        private void LayoutArrows()
        {
            leftArrow.PositionUsesPivotPoint = true;
            leftArrow.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
            leftArrow.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;

            leftArrow.Size = new Size(42, 42, 0.0f);//

            Add(leftArrow);
            leftArrow.Hide();

            rightArrow.PositionUsesPivotPoint = true;
            rightArrow.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
            rightArrow.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
            rightArrow.Position = new Vector3(0.0f, 0.0f, 0.0f);
            rightArrow.Size = new Size(42, 42, 0.0f);//
            Add(rightArrow);
        }

        private void LayoutIndicateTexts()
        {
            leftIndicateText.Text = "";
            leftIndicateText.PositionUsesPivotPoint = true;
            leftIndicateText.PivotPoint = new Vector3(0.0f, 0.5f, 0.5f);
            leftIndicateText.ParentOrigin = new Vector3(0.0f, 0.5f, 0.5f);
            leftIndicateText.HorizontalAlignment = HorizontalAlignment.Begin;
            leftIndicateText.VerticalAlignment = VerticalAlignment.Center;
            Add(leftIndicateText);
            leftIndicateText.Hide();

            rightIndicateText.Text = "";
            rightIndicateText.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
            rightIndicateText.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
            rightIndicateText.PositionUsesPivotPoint = true;
            rightIndicateText.HorizontalAlignment = HorizontalAlignment.End;
            rightIndicateText.VerticalAlignment = VerticalAlignment.Center;
            Add(rightIndicateText);
        }

        private void UpdateIndicate(bool bReversed)
        {
            if (currentStep > steps || currentStep < 0)
            {
                return;
            }
            TextLabel rText = bReversed ? leftIndicateText : rightIndicateText;
            TextLabel lText = bReversed ? rightIndicateText : leftIndicateText;

            ImageView lArrow = bReversed ? rightArrow : leftArrow;
            ImageView rArrow = bReversed ? leftArrow : rightArrow;
            if (rText == null || lText == null || lArrow == null || rArrow == null)
            {
                return;
            }
            if (currentStep < steps && skipable[currentStep])
            {
                rText.Text = skipText;
            }
            else
            {
                rText.Text = nextText;
            }
            lText.Text = previousText;

            if (currentStep == 0)
            {
                lText.Hide();
                lArrow.Hide();
                rText.Show();
                rArrow.Show();
            }
            else if (currentStep >= steps - 1)
            {
                rText.Hide();
                rArrow.Hide();
                lText.Show();
                lArrow.Show();
            }
            else
            {
                rText.Show();
                rArrow.Show();
                lText.Show();
                lArrow.Show();
            }
        }

        //private void OnUIDirectionChagned(object sender, DirectionChangedEventArgs e)
        //{
        //    Log.Fatal("test", "ParentDirection: " + e.ParentUIDirection);
        //    if (e.ParentUIDirection == UIDirection.LTR)
        //    {
        //        rtlEnable = false;

        //    }
        //    else if (e.ParentUIDirection == UIDirection.RTL)
        //    {
        //        // RTL layouting
        //        rtlEnable = true;
        //    }
        //    UpdateIndicate(rtlEnable);
        //    LayoutChecks(stepAttr);
        //    LayoutStepLabels(stepAttr);
        //}

        private int steps = 0;
        private int currentStep = 0;
        private List<TextLabel> stepLabels = new List<TextLabel>();
        private List<ImageView> checkIcons = new List<ImageView>();
        private ImageView leftArrow = new ImageView();
        private ImageView rightArrow = new ImageView();


        private TextLabel leftIndicateText = new TextLabel();
        private TextLabel rightIndicateText = new TextLabel();

        private string previousText;
        private string nextText;
        private string skipText;
        private bool[] skipable;

        //private AnimationPlayer checkAniPlayer;
        //private AnimationPlayer focusAniPlayer;

        //private FrameAnimation frameAni;

        private StepIndicatorAttributes stepAttr = null;
        const int MaxLength = 10;
        private bool rtlEnable = false;

        private TapGestureDetector tapGestrueDector;
    }
}
