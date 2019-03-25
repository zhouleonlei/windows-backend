using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.CommonUI
{
    public class FHSpin : Control
    {
        private enum Style
        {
            IntStyle = 1,
            StrStyle = 2
        }
        private enum TimeAniType
        {
            TapFinishedAni = 1,
            PanFinishedAni = 2            
        }
        
        private Style type = Style.IntStyle;
        private TimeAniType timeAniType = TimeAniType.TapFinishedAni;
        
        private ImageView backgroundImage;
        private View clipView;
        private View aniView;
        private View nameView;
        private TextLabel nameText;
        private TextLabel[] label;
        private TextField textField;
        private View dividerRec;
        private View dividerRec2;
        private ImageView maskTopImage;
        private ImageView maskBottomImage;        
        private Animation spinAnimation;        
        private Timer finishedTimer;
        private PanGestureDetector panGestureDetector = null;
        private TapGestureDetector tapGestureDetector = null;
        
        private int pre = 0;
        private int cur = 1;
        private int next = 2;

        private int curValue;
        private int nMin = 0;
        private int nMax = 0;
        
        private int moveState = 0;
        private int curHeight;
        private float aniViewHeight; 
        private    float movelen;

        float maxMoveDown = 0;
        float maxMoveUp = 0;
        float curMove = 0;
        float calculateMove = 0;

        private int finishedState;
        private uint RepeatCnt;
        private int gestureState;

        private float last;
        private float tapFinishedMove;

        private int timeSetting;
        private int timeStep;

        private int ITEMHEIGHT;
        private int ITEMHEIGHT_HALF;
        private float FLOARTITEMHEIGHT;
        private float FLOARTITEMHEIGHT_HALF;
        private int TEXTSIZE;
        private int TEXTSIZE_CENTER;
        
        const int TAP_ANIMATION_TIME = 200;
        
        private SpinAttributes spinAttributes;

        public FHSpin() : base()
        {
            Initialize();
        }
        public FHSpin(string style) : base(style)
        {
            if (style.Contains("str") || style.Contains("Str"))
            {
                type = Style.StrStyle;
            }
            Initialize();
        }

        public string NameText
        {
            get
            {
                return nameText?.Text;
            }
            set
            {
                if (nameText != null)
                {
                    nameText.Text = value;
                }
            }
        }

        public int Min
        {
            get
            {
                return nMin;
            }
            set
            {
               nMin = value;
               if (label != null)
               {
                   label[pre].Text = GetStrValue(curValue - 1);
                   label[cur].Text = GetStrValue(curValue);
                   label[next].Text = GetStrValue(curValue + 1);
               }
            }
        }

        public int Max
        {
            get
            {
                return nMax;
            }
            set
            {
               nMax = value;
               if (label != null)
               {
                   label[pre].Text = GetStrValue(curValue - 1);
                   label[cur].Text = GetStrValue(curValue);
                   label[next].Text = GetStrValue(curValue + 1);
               }
            }
        }

        public int CurValue
        {
            get
            {
                return curValue;
            }
            set
            {
               curValue = value;
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
                if (backgroundImage != null)
                {
                    Remove(backgroundImage);
                    backgroundImage.Dispose();
                    backgroundImage = null;
                }

                if (maskTopImage != null)
                {
                    Remove(maskTopImage);
                    maskTopImage.Dispose();
                    maskTopImage = null;
                }

                if (maskBottomImage != null)
                {
                    Remove(maskBottomImage);
                    maskBottomImage.Dispose();
                    maskBottomImage = null;
                }
                
                if (dividerRec != null)
                {
                    Remove(dividerRec);
                    dividerRec.Dispose();
                    dividerRec = null;
                }

                if (dividerRec2 != null)
                {
                    Remove(dividerRec2);
                    dividerRec2.Dispose();
                    dividerRec2 = null;
                }
                
                if (panGestureDetector != null)
                {
                    panGestureDetector.Detach(clipView);
                    panGestureDetector.Detected -= OnPanGestureDetected;
                    panGestureDetector.Dispose();
                    panGestureDetector = null;
                }

                if (tapGestureDetector != null)
                {
                    if (label != null)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            tapGestureDetector.Detach(label[i]);
                        }
                    }
                    tapGestureDetector.Detected -= OnTapGestureDetected;
                    tapGestureDetector.Dispose();
                    tapGestureDetector = null;
                }

                if (finishedTimer != null)
                {
                    finishedTimer.Tick -= OnFinishedTickEvent;
                    finishedTimer.Dispose();
                    finishedTimer = null;
                }
                
                if (spinAnimation != null)
                {
                    spinAnimation.Dispose();
                    spinAnimation = null;
                }

                if (clipView != null)
                {
                    if (aniView != null)
                    {
                        if (label != null)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                if (label[i] != null)
                                {
                                    aniView.Remove(label[i]);
                                    label[i].Dispose();
                                    label[i] = null;
                                }
                            }
                        }
                        clipView.Remove(aniView);
                        aniView.Dispose();
                        aniView = null;
                    }
                    
                    if (textField != null)
                    {
                        textField.TouchEvent -= OnTextFieldTouchEvent;
                        textField.FocusGained -= OnTextFieldFocusGained;
                        textField.FocusLost -= OnTextFieldFocusLost;
                        textField.TextChanged -= OnTextFieldTextChanged;
                        textField.MaxLengthReached -= OnTextFieldMaxLengthReached;
                        clipView.Remove(textField);
                        textField.Dispose();
                        textField = null;
                    }
                    
                    Remove(clipView);
                    clipView.Dispose();
                    clipView = null;
                }
                
                if (nameView != null)
                {    
                    if (nameText != null)
                    {
                        nameView.Remove(nameText);
                        nameText.Dispose();
                        nameText = null;
                    }
                    Remove(nameView);
                    nameView.Dispose();
                    nameView = null;
                }                
            }
            base.Dispose(type);
        }
           
        protected override void OnFocusGained(object sender, EventArgs e)
        {
            base.OnFocusGained(sender, e);
        }
        protected override void OnFocusLost(object sender, EventArgs e)
        {
            base.OnFocusLost(sender, e);
        }
        protected override Attributes GetAttributes()
        {
            return null;
        }
        protected override void OnUpdate(Attributes attributtes)
        {
            spinAttributes = attributes as SpinAttributes;
            if (spinAttributes == null)
            {
                return;
            }

            ApplyAttributes(this, spinAttributes);
            ApplyAttributes(backgroundImage, spinAttributes.BackgroundImageAttributes);
            ApplyAttributes(nameText, spinAttributes.NameTextAttrs);
            ApplyAttributes(nameView, spinAttributes.NameViewAttributes);
            ApplyAttributes(clipView, spinAttributes.ClipViewAttributes);
            ApplyAttributes(aniView, spinAttributes.AniViewAttributes);
            ApplyAttributes(dividerRec, spinAttributes.DividerRecAttrs);
            ApplyAttributes(dividerRec2, spinAttributes.DividerRec2Attrs);
            ApplyAttributes(textField, spinAttributes.TextFieldAttrs);    
            ApplyAttributes(maskBottomImage,spinAttributes.MaskBottomImageAttributes);
            ApplyAttributes(maskTopImage, spinAttributes.MaskTopImageAttributes);

            ITEMHEIGHT = spinAttributes.ItemHeight;
            TEXTSIZE = spinAttributes.TextSize;
            TEXTSIZE_CENTER = spinAttributes.CenterTextSize;
            
            ITEMHEIGHT_HALF = ITEMHEIGHT/2;
            FLOARTITEMHEIGHT = ITEMHEIGHT;
            FLOARTITEMHEIGHT_HALF = ITEMHEIGHT/2;
            curHeight = ITEMHEIGHT;
            
            if (label != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    ApplyAttributes(label[i], spinAttributes.TextAttrs);
                }

                label[pre].Position2D = new Position2D(0, 0);
                label[pre].Opacity = 0.4f;
                label[pre].PointSize = TEXTSIZE;
                label[cur].Position2D = new Position2D(0, ITEMHEIGHT); 
                label[cur].Opacity = 1.0f;
                label[cur].PointSize = TEXTSIZE_CENTER;
                label[next].Position2D = new Position2D(0, ITEMHEIGHT*2); 
                label[next].Opacity = 0.4f;
                label[next].PointSize = TEXTSIZE;
                label[next+1].Position2D = new Position2D(0, ITEMHEIGHT*3); 

                label[pre].Text = GetStrValue(curValue - 1);
                label[cur].Text = GetStrValue(curValue);
                label[next].Text = GetStrValue(curValue + 1);
            }                    
        }

        private void Initialize()
        {
            spinAttributes = attributes as SpinAttributes;
            if (spinAttributes == null)
            {
                throw new Exception("Spin attribute parse error.");
            }

            StateFocusableOnTouchMode = true;
            LeaveRequired = true;
            
            if (spinAttributes.BackgroundImageAttributes != null)
            {
                backgroundImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
                Add(backgroundImage);
            }
                        
            if (spinAttributes.ClipViewAttributes != null)
            {    
                clipView = new View();
                clipView.ClippingMode = ClippingModeType.ClipChildren;
                clipView.TouchEvent += OnTouchEvent;
                Add(clipView);

                if (spinAttributes.TextFieldAttrs != null)
                {
                    textField = new TextField()
                    {
                        WidthResizePolicy = ResizePolicyType.Fixed,
                        HeightResizePolicy = ResizePolicyType.Fixed
                    };
                    textField.Focusable = true;
                    textField.MaxLength = 2;
                    textField.TouchEvent += OnTextFieldTouchEvent;
                    textField.FocusGained += OnTextFieldFocusGained;
                    textField.FocusLost += OnTextFieldFocusLost;
                    textField.TextChanged += OnTextFieldTextChanged;
                    textField.MaxLengthReached += OnTextFieldMaxLengthReached;
                    clipView.Add(textField);
                    textField.Hide();    
                }
                
                if (spinAttributes.AniViewAttributes != null)
                {    
                    aniView = new View();
                    clipView.Add(aniView);
                    spinAnimation = new Animation(100);             
                    spinAnimation.EndAction = Animation.EndActions.StopFinal;        
                }
                
                panGestureDetector = new PanGestureDetector();
                panGestureDetector.Attach(clipView);
                panGestureDetector.Detected += OnPanGestureDetected;

                tapGestureDetector = new TapGestureDetector();
                tapGestureDetector.Detected += OnTapGestureDetected;
                if (spinAttributes.TextAttrs != null)
                {
                    label = new TextLabel[4];
                    for (int i = 0; i < 4; i++)
                    {
                        label[i] = new TextLabel();
                        tapGestureDetector.Attach(label[i]);
                        aniView.Add(label[i]);    
                    }
                }
                
            }    
            
            if (spinAttributes.DividerRecAttrs != null)
            {
                dividerRec = new View();
                Add(dividerRec);
            }

            if (spinAttributes.DividerRec2Attrs != null)
            {
                dividerRec2 = new View();
                Add(dividerRec2);
            }

            if (spinAttributes.MaskTopImageAttributes != null)
            {
                maskTopImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };                        
                Add(maskTopImage);
            }

            if (spinAttributes.MaskBottomImageAttributes != null)
            {
                maskBottomImage = new ImageView()
                {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                };
                Add(maskBottomImage);
            }    

            if (spinAttributes.NameViewAttributes != null)
            {
                nameView = new View();
                Add(nameView);
                if (spinAttributes.NameTextAttrs != null)
                {
                    nameText = new TextLabel();
                    nameView.Add(nameText);
                }
            }
            
            finishedTimer = new Timer(100);
            finishedTimer.Tick += OnFinishedTickEvent;
        }

        private void OnTextFieldMaxLengthReached(object source, EventArgs e)
        {
            return;
        }

        private bool OnTextFieldTouchEvent(object source, View.TouchEventArgs e)
        {
            return false;
        }
        private void OnTextFieldFocusGained(object source, EventArgs e)
        {
            Console.WriteLine("<<<----OnTextFieldFocusGained---, textField focus gained");

            textField.PlaceholderTextFocused = GetStrValue(curValue);
            textField.PlaceholderTextColor = Color.Black;
            textField.Text = "";
        }
        private void OnTextFieldFocusLost(object source, EventArgs e)
        {
            Console.WriteLine(">>>-----OnTextFieldFocusLost--, textField focus lost" +textField.Text.Length);

            if (textField.Text.Length != 0)
            {
                int value = curValue;
                if (int.TryParse(textField.Text, out value))
                {
                    if (value > nMax)
                    {
                        textField.Text = GetStrValue(nMax);
                        curValue = nMax;
                    }
                    else
                    {
                        curValue = value;
                    }
                }
                SwitchToAniView();
            }
            else
            {
                SwitchToAniView();
            }
        }

        private void OnTextFieldTextChanged(object sender, TextField.TextChangedEventArgs e)
        {
            int textLength = 0;
            if (textField != null && textField.Text != null)
            {
                textLength = textField.Text.Length;
            }
            Console.WriteLine("+++++++++OnTextFieldTextChanged+++++++, text changed, textLength = " + textLength);
            if (textLength != 0)
            {
                if (textLength == 2)
                {
                    int value = curValue;
                    if (int.TryParse(textField.Text, out value))
                    {
                        if (value > nMax)
                        {
                            textField.Text = GetStrValue(nMax);
                            curValue = nMax;
                        }
                        else
                        {
                            curValue = value;
                        }
                    }
                    textField.Text = "";
                    SwitchToAniView();
                }
            }
        }

        private bool OnTouchEvent(object source, View.TouchEventArgs e)
        {
            View view = source as View;    
            PointStateType state = e.Touch.GetState(0);
            Console.WriteLine("---OnTouchEvent---" + gestureState + "state: " + state);

            if (gestureState == 3)
            {
                if (state == PointStateType.Down)
                {
                    finishedTimer.Stop();
                    spinAnimation.Stop();
                }
                else
                {
                    ResetPositon();  /// add animation and timer!
                }
            }            
            return false;
        }

        private bool OnFinishedTickEvent(object source, Timer.TickEventArgs e)
        {
            Console.WriteLine("----OnFinishedTickEvent----");

            if (RepeatCnt == 0)
            {
                ResetPositon();
                return false;
            }
            else
            {
                RepeatCnt--;
                switch (timeAniType)
                {
                    case TimeAniType.TapFinishedAni:
                        {
                            AnimationWithTime(tapFinishedMove, TAP_ANIMATION_TIME/2);
                            AdjustLabelPosition();
                        }
                        break;
                    case TimeAniType.PanFinishedAni:
                        {
                            if (RepeatCnt == 0)
                            {
                                FinishAnimation(true);
                            }
                            else
                            {
                                FinishAnimation(false);
                            }
                        }
                        break;
                    default:
                        break;
                }
                return true;
            }    
        }
        private void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            Console.WriteLine("----OnTapGestureDetected---, e.TapGesture.State = " + e.TapGesture.State);
            
            if (gestureState != 0)
            {
                return;
            }
                        
            TextLabel t = e.View as TextLabel;
            if (!finishedTimer.IsRunning())
            {
                if (t == label[cur])
                {
                    if (type != Style.IntStyle)
                    {
                        return;
                    }
                    SwitchToTextField();                    
                    FocusManager.Instance.SetCurrentFocusView(textField);
                }
                else
                {
                    if(t.Text == " ")
                    {
                        return;
                    }
                    else
                    {
                        if (curMove != 0)
                        {
                            Console.WriteLine("---Error:TAP---");    
                        }
                        
                        int dir;
                        if(t == label[0])
                        {
                            moveState = 1;
                            movelen = FLOARTITEMHEIGHT_HALF;
                            calculateMove = FLOARTITEMHEIGHT - movelen;
                            tapFinishedMove = ITEMHEIGHT - calculateMove;
                            AnimationWithTime(calculateMove, TAP_ANIMATION_TIME/2);

                            if (finishedTimer != null)
                            {
                                timeAniType = TimeAniType.TapFinishedAni;
                                RepeatCnt = 1;
                                finishedTimer.Interval = (uint)spinAnimation.Duration;
                                finishedTimer.Start();
                            }
                        }
                        else
                        {
                            moveState = 2;
                            movelen = -FLOARTITEMHEIGHT_HALF;
                            calculateMove = -FLOARTITEMHEIGHT - movelen;
                            tapFinishedMove = -ITEMHEIGHT - calculateMove;

                            AnimationWithTime(calculateMove, TAP_ANIMATION_TIME/2);

                            if (finishedTimer != null)
                            {
                                timeAniType = TimeAniType.TapFinishedAni;
                                RepeatCnt = 1;
                                finishedTimer.Interval = (uint)spinAnimation.Duration;
                                finishedTimer.Start();
                            }
                        }                            
                    }
                }

            }
            
        }    
        private void PanGestureInit()
        {    
            gestureState = 1;
            moveState = 0;
            movelen = 0;

            curHeight = ITEMHEIGHT; 
            aniViewHeight = 0;
            curMove = 0;
            finishedState = 2;
            RepeatCnt = 0;
            
            //calculate the max movement
            maxMoveDown = (curValue - nMin)*ITEMHEIGHT;
            maxMoveUp = (curValue-nMax)*ITEMHEIGHT;            
        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            Console.WriteLine("------e.PanGesture.State = " + e.PanGesture.State);
            
            if (e.PanGesture.State == Gesture.StateType.Started)
            {
                Console.WriteLine("------e.PanGesture.State = " + e.PanGesture.State + "time = " + e.PanGesture.Time);
                if (finishedTimer.IsRunning())
                {
                    finishedTimer.Stop();
                    ResetPositon();
                }
                if (aniView.Position2D.Y != 0)
                {
                    ResetPositon();
                }
                PanGestureInit();
                
                if (e.PanGesture.Displacement.Y > 0)
                {
                    moveState = 1;
                    movelen = ITEMHEIGHT_HALF;
                }
                else
                {
                    moveState = 2;
                    movelen = -ITEMHEIGHT_HALF;
                }
                timeAniType = TimeAniType.PanFinishedAni;
            }

            if (e.PanGesture.State == Gesture.StateType.Continuing || e.PanGesture.State == Gesture.StateType.Started)
            {
                Console.WriteLine("----- e.PanGesture.State = " + e.PanGesture.State + "time = " + e.PanGesture.Time + "Y=" + e.PanGesture.Displacement.Y);
                spinAnimation.Stop();
                curMove += e.PanGesture.Displacement.Y;

                gestureState = 2;

                if (e.PanGesture.Displacement.Y > 0)
                {
                    if (moveState == 2)
                    {
                        movelen += ITEMHEIGHT;
                    }
                    last = e.PanGesture.Displacement.Y;
                    
                    if (curMove > maxMoveDown)
                    {
                        calculateMove = maxMoveDown - (curMove - e.PanGesture.Displacement.Y);
                        curMove = maxMoveDown;
                    }
                    else
                    {
                        calculateMove = e.PanGesture.Displacement.Y;
                    }

                    if(calculateMove != 0)
                    {
                        moveState = 1;
                    }
                    else
                    {
                        moveState = 1;
                        return;
                    }
                    //  when need to change the font and color!!!!!!

                    while (calculateMove > FLOARTITEMHEIGHT)// need improve
                    {
                        spinAnimation.Stop();
                        spinAnimation.Clear();
                        
                        aniViewHeight += FLOARTITEMHEIGHT;
                        spinAnimation.AnimateTo(aniView, "Position", new Position(0, aniViewHeight, 0));

                        AdjustLabelPosition();
                        
                        calculateMove -= FLOARTITEMHEIGHT;
                    }
                    
                    AnimationWithTime(calculateMove, 50);                    
                    movelen += calculateMove;                    
                }
                else if (e.PanGesture.Displacement.Y < 0)
                {
                    Console.WriteLine("----curValue : " + curValue +" " + maxMoveUp +" " + curMove);
                    if (moveState == 1)
                    {
                        movelen -= ITEMHEIGHT;
                    }
                    last = -e.PanGesture.Displacement.Y;
                    
                    if (curMove < maxMoveUp)
                    {
                        calculateMove = maxMoveUp - (curMove - e.PanGesture.Displacement.Y);
                        curMove = maxMoveUp;
                    }
                    else
                    {
                        calculateMove = e.PanGesture.Displacement.Y;
                    }
                                        
                    if(calculateMove != 0)
                    {
                        moveState = 2;
                    }
                    else
                    {
                        moveState = 2;
                        return;
                    }

                    while (calculateMove < -FLOARTITEMHEIGHT) // need improve
                    {
                        spinAnimation.Stop();
                        spinAnimation.Clear();
                        
                        aniViewHeight -= FLOARTITEMHEIGHT;
                        spinAnimation.AnimateTo(aniView, "Position", new Position(0, aniViewHeight, 0));
                        
                        AdjustLabelPosition();
                        
                        calculateMove += FLOARTITEMHEIGHT;
                    }
                    
                    AnimationWithTime(calculateMove, 50);
                    movelen += calculateMove;    
                }
                                
                if ((moveState == 1) && ((movelen >= FLOARTITEMHEIGHT)))
                {
                    movelen -= ITEMHEIGHT;
                    AdjustLabelPosition();
                }
                else if ((moveState == 2) && ((movelen <= -FLOARTITEMHEIGHT)))
                {
                    movelen += ITEMHEIGHT;
                    AdjustLabelPosition();
                }
            }

            if (e.PanGesture.State == Gesture.StateType.Finished)
            {
                Console.WriteLine("------e.PanGesture.State = " + e.PanGesture.State + "time = " + e.PanGesture.Time);
                gestureState = 3;
                
                if (last < 2)
                {
                    finishedState = 0;
                }
                else if (last >= 2 && last <= 3)
                {
                    finishedState = 1; 
                }
                else if (last > 3 && last <= 10)
                {
                    finishedState = 2; 
                }
                else
                {
                    finishedState = 3; 
                }

                Console.WriteLine("---finishedState: " + finishedState);
                
                if (finishedState == 0)
                {
                    // move to center
                    if (finishedTimer != null)
                    {
                        if (moveState == 1)
                        {
                            AnimationWithTime(FLOARTITEMHEIGHT_HALF - movelen, 100*GetAbs(FLOARTITEMHEIGHT_HALF - movelen)/ITEMHEIGHT); 
                            
                        }
                        else if (moveState == 2)
                        {
                            AnimationWithTime(-FLOARTITEMHEIGHT_HALF - movelen, 100*GetAbs(-FLOARTITEMHEIGHT_HALF - movelen)/ITEMHEIGHT);
                        }
                                                
                        finishedTimer.Interval = (uint)spinAnimation.Duration;
                        RepeatCnt = 0;
                        finishedTimer.Start();
                    }
                }
                else if (finishedState == 1)
                {
                    timeSetting = 500;
                    timeStep = 100;
                    StartFinishedAnimation(1);                        
                }
                else if (finishedState == 2)
                {
                    timeSetting = 100;
                    timeStep = 60;
                    StartFinishedAnimation(5);
                }
                else if (finishedState == 3)
                {
                    timeSetting = 15;
                    timeStep = 6;
                    StartFinishedAnimation(20);
                }                    
            }
        }

        private void FinishAnimation(bool isHalfItemHeight)
        {
            float moveHeight = 0;
            if (isHalfItemHeight)
            {
                moveHeight = FLOARTITEMHEIGHT_HALF;
            }
            else
            {
                moveHeight = FLOARTITEMHEIGHT;
            }
            
            timeSetting += timeStep;
            spinAnimation.Duration = timeSetting;
            finishedTimer.Interval = (uint)spinAnimation.Duration;

            if (moveState == 1)
            {
                if ((maxMoveDown- curMove) < FLOARTITEMHEIGHT)
                {
                    RepeatCnt = 0;
                    moveHeight = FLOARTITEMHEIGHT_HALF;
                }
                
                curMove += moveHeight;

                if (curMove > maxMoveDown)
                {
                    curMove = maxMoveDown;
                    return;
                }
                else
                {
                    spinAnimation.Stop();
                    spinAnimation.Clear();
                    aniViewHeight += moveHeight;
                    Console.WriteLine("aniViewHeight: " + aniViewHeight + " "+aniView.Position2D.Y);
                    spinAnimation.AnimateTo(aniView, "Position", new Position(0, aniViewHeight, 0));
                    spinAnimation.Play();

                    AdjustLabelPosition();
                }
            }
            else if (moveState == 2)
            {
                if ((maxMoveUp- curMove) > -FLOARTITEMHEIGHT)
                {
                    RepeatCnt = 0;
                    moveHeight = FLOARTITEMHEIGHT_HALF;
                }
                
                curMove -= moveHeight;

                if (curMove < maxMoveUp)
                {
                    curMove = maxMoveUp;
                    return;
                }
                else
                {
                    spinAnimation.Stop();
                    spinAnimation.Clear();
                    aniViewHeight -= moveHeight;
                    spinAnimation.AnimateTo(aniView, "Position", new Position(0, aniViewHeight, 0));
                    spinAnimation.Play();
                
                    AdjustLabelPosition();
                }
            }
        }
        
        private void AdjustLabelPosition()
        {
            if (moveState == 1)
            {
                curHeight -= ITEMHEIGHT;
                
                pre = (pre == 0)? 3: pre-1;
                cur = (cur == 0)? 3: cur-1;
                next = (next == 0)? 3: next-1;
                label[pre].Position2D = new Position2D(0, curHeight - ITEMHEIGHT);
                label[pre].Text = GetStrValue(curValue - 2);
                label[pre].Opacity = 0.4f;
                label[pre].PointSize = TEXTSIZE;
                label[cur].Opacity = 1.0f;
                label[cur].PointSize = TEXTSIZE_CENTER;
                label[next].Opacity = 0.4f;
                label[next].PointSize = TEXTSIZE;

                curValue -= 1;
            }
            else if (moveState == 2)
            {
                curHeight += ITEMHEIGHT;
                
                pre = (pre == 3)? 0: pre+1;
                cur = (cur == 3)? 0: cur+1;
                next = (next == 3)? 0: next+1;
                label[next].Position2D = new Position2D(0, curHeight + ITEMHEIGHT);
                label[next].Text = GetStrValue(curValue + 2);
                label[pre].Opacity = 0.4f;
                label[pre].PointSize = TEXTSIZE;
                label[cur].Opacity = 1.0f;
                label[cur].PointSize = TEXTSIZE_CENTER;
                label[next].Opacity = 0.4f;
                label[next].PointSize = TEXTSIZE;
                
                curValue += 1;
            }
        }

        private void ResetPositon()
        {
            spinAnimation.Stop();
            spinAnimation.Clear();
            gestureState = 0;
            movelen= 0;
            pre = 0;
            cur = 1;
            next = 2;
            aniView.Position2D = new Position2D(0, 0);
            label[0].Position2D = new Position2D(0, 0);
            label[0].Text = GetStrValue(curValue-1);
            label[1].Position2D = new Position2D(0, ITEMHEIGHT);
            label[1].Text = GetStrValue(curValue);
            label[2].Position2D = new Position2D(0, ITEMHEIGHT*2);
            label[2].Text = GetStrValue(curValue+1);
            label[pre].Opacity = 0.4f;
            label[pre].PointSize = TEXTSIZE;
            label[cur].Opacity = 1.0f;
            label[cur].PointSize = TEXTSIZE_CENTER;
            label[next].Opacity = 0.4f;
            label[next].PointSize = TEXTSIZE;
            curHeight = ITEMHEIGHT;
            aniViewHeight = 0;
        }
        
        private void AnimationWithTime(float move, int time)
        {
            spinAnimation.Stop();
            spinAnimation.Clear();

            aniViewHeight += move;
            spinAnimation.Duration = time;
            spinAnimation.AnimateTo(aniView, "Position", new Position(0, aniViewHeight, 0));
            spinAnimation.Play();
        }
        private void SwitchToTextField()
        {
            aniView.Hide();
            dividerRec.Hide();
            dividerRec2.Hide();
            panGestureDetector.Detach(clipView);
            textField.Show();
        }

        private void SwitchToAniView()
        {
            textField.Hide();
            ResetPositon();
            panGestureDetector.Attach(clipView);
            aniView.Show();
            dividerRec.Show();
            dividerRec2.Show();
        }

        private void StartFinishedAnimation(uint cnt)
        {
            if (movelen != FLOARTITEMHEIGHT/2 && movelen != -FLOARTITEMHEIGHT/2)
            {
                if (moveState == 1)
                {
                    curMove += (FLOARTITEMHEIGHT - movelen);
                    if (curMove > maxMoveDown)
                    {
                        AnimationWithTime(FLOARTITEMHEIGHT_HALF - movelen, 100*GetAbs(FLOARTITEMHEIGHT_HALF - movelen)/ ITEMHEIGHT);
                        RepeatCnt = 0;
                    }
                    else
                    {
                        AnimationWithTime(FLOARTITEMHEIGHT - movelen, 100*GetAbs(FLOARTITEMHEIGHT - movelen)/ ITEMHEIGHT);
                        RepeatCnt = cnt;
                    }
                }
                else if (moveState == 2)
                {
                    curMove += (-FLOARTITEMHEIGHT - movelen);
                    if (curMove < maxMoveUp)
                    {
                        AnimationWithTime(-FLOARTITEMHEIGHT_HALF - movelen, 100*GetAbs(-FLOARTITEMHEIGHT_HALF - movelen)/ ITEMHEIGHT);
                        RepeatCnt = 0;
                    }
                    else
                    {
                        AnimationWithTime(-FLOARTITEMHEIGHT - movelen, 100*GetAbs(-FLOARTITEMHEIGHT - movelen)/ ITEMHEIGHT);
                        RepeatCnt = cnt;
                    }
                }
                if (finishedTimer != null)
                {
                    finishedTimer.Interval = (uint)spinAnimation.Duration;
                    finishedTimer.Start();
                }
            }
            else
            {
                RepeatCnt = cnt - 1;
                FinishAnimation(false);
                finishedTimer.Start();
            }
        }

        private int GetAbs(float data)
        {
            return data > 0 ? (int)data : (int)-data;
        }

        private string GetStrValue(int data)
        {
            if (data < nMin || data > nMax)
            {
                return " ";
            }

            if (type == Style.StrStyle)
            {
                switch (data)
                {
                    case 0:
                        return "AM";
                    case 1:
                        return "PM";
                    default:
                        return " ";
                }
            }
            else
            {
                return data.ToString("D2");
            }
        }
    }
}
