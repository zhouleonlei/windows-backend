using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    public class Spin : Control
    {
        private Style type = Style.IntStyle;        
        private ImageView backgroundImage = null;
        private View clipView = null;
        private View aniView = null;
        private View nameView = null;
        private TextLabel nameText = null;
        private TextLabel[] itemLabel = null;
        private TextField textField = null;
        private View dividerRec = null;
        private View dividerRec2 = null;
        private ImageView maskTopImage = null;
        private ImageView maskBottomImage = null;        
        private Animation spinAnimation = null;        
        private Timer finishedTimer = null;
        private PanGestureDetector panGestureDetector = null;
        private TapGestureDetector tapGestureDetector = null;
        
        private int upItemIndex = 0;
        private int midItemIndex = 1;
        private int downItemIndex = 2;
        private int nMin = 0;
        private int nMax = 0;
        private int curValue = 0;
        private int itemHeight = 0;
        private float floatItemHeight = 0f;
        private float floatItemHalfHeight = 0f;
        private int upDownItemTextSize = 0;
        private int midItemTextSize = 0;        
        private int tapAnimationDuration = 200;

        //Gesture variable
        private Direction moveDirection = Direction.None;      
        private int midItemPositionY = 0;
        private float aniViewPositionY = 0f; 
        private float calculateAdjustLen = 0f;
        private float maxMoveDownHeight = 0f;
        private float maxMoveUpHeight = 0f;
        private float curMoveHeight = 0f;
        private float lastMoveHeight = 0f; 
        private FinishAniType finishAniType = FinishAniType.Tap;
        private FinishAniAction finishAniAction = FinishAniAction.None;
        private PanAnimationState panAnimationState = PanAnimationState.None;
        private uint finishTimerLoopCount = 0;        
        private int finishTimerFirstInterval = 0;
        private int finishTimerIncreaseInterval = 0;
        private bool isTouchRelease = true; 
        
        private SpinAttributes spinAttributes;

        public Spin() : base()
        {
            Initialize();
        }
        
        public Spin(string style) : base(style)
        {
            if (style.Contains("str") || style.Contains("Str"))
            {
                type = Style.StrStyle;
            }
            
            Initialize();
        }
        
        private enum Style
        {
            IntStyle = 1,
            StrStyle = 2
        }
        
        private enum FinishAniType
        {
            Tap = 1,
            Pan = 2            
        }

        private enum Direction
        {
            None = 0,
            Up = 1,
            Down = 2            
        }

        private enum PanAnimationState
        {
            None = 0,
            PanAni = 1,
            FinishAni = 2
        }

        private enum FinishAniAction
        {
            None = 0,
            MoveToCenter = 1,
            MoveToNext = 2,
            MoveToNext5 = 3,
            MoveToNext20 = 4
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
               
               if (itemLabel != null)
               {
                   itemLabel[upItemIndex].Text = GetStrValue(curValue - 1);
                   itemLabel[midItemIndex].Text = GetStrValue(curValue);
                   itemLabel[downItemIndex].Text = GetStrValue(curValue + 1);
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
               
               if (itemLabel != null)
               {
                   itemLabel[upItemIndex].Text = GetStrValue(curValue - 1);
                   itemLabel[midItemIndex].Text = GetStrValue(curValue);
                   itemLabel[downItemIndex].Text = GetStrValue(curValue + 1);
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
                    tapGestureDetector.Detach(clipView);
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
                        if (itemLabel != null)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                if (itemLabel[i] != null)
                                {
                                    aniView.Remove(itemLabel[i]);
                                    itemLabel[i].Dispose();
                                    itemLabel[i] = null;
                                }
                            }
                        }
                        clipView.Remove(aniView);
                        aniView.Dispose();
                        aniView = null;
                    }
                    
                    if (textField != null)
                    {
                        textField.FocusGained -= OnTextFieldFocusGained;
                        textField.FocusLost -= OnTextFieldFocusLost;
                        textField.TextChanged -= OnTextFieldTextChanged;
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

            itemHeight = spinAttributes.ItemHeight;
            upDownItemTextSize = spinAttributes.TextSize;
            midItemTextSize = spinAttributes.CenterTextSize;           
            floatItemHeight = itemHeight;
            floatItemHalfHeight = itemHeight/2;
            midItemPositionY = itemHeight;
            
            if (itemLabel != null)
            {
                for (int i = 0; i < 4; i++)
                {
                    ApplyAttributes(itemLabel[i], spinAttributes.TextAttrs);
                }

                itemLabel[upItemIndex].Position2D = new Position2D(0, 0);
                itemLabel[upItemIndex].Opacity = 0.4f;
                itemLabel[upItemIndex].PointSize = upDownItemTextSize;
                itemLabel[midItemIndex].Position2D = new Position2D(0, itemHeight); 
                itemLabel[midItemIndex].Opacity = 1.0f;
                itemLabel[midItemIndex].PointSize = midItemTextSize;
                itemLabel[downItemIndex].Position2D = new Position2D(0, itemHeight*2); 
                itemLabel[downItemIndex].Opacity = 0.4f;
                itemLabel[downItemIndex].PointSize = upDownItemTextSize;
                itemLabel[downItemIndex+1].Position2D = new Position2D(0, itemHeight*3); 
                itemLabel[upItemIndex].Text = GetStrValue(curValue - 1);
                itemLabel[midItemIndex].Text = GetStrValue(curValue);
                itemLabel[downItemIndex].Text = GetStrValue(curValue + 1);
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
                    textField.CursorWidth = 0;
                    textField.BackgroundColor = new Color(0,0,0,0.5f);
                    textField.FocusGained += OnTextFieldFocusGained;
                    textField.FocusLost += OnTextFieldFocusLost;
                    textField.TextChanged += OnTextFieldTextChanged;
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
                tapGestureDetector.Attach(clipView);
                
                if (spinAttributes.TextAttrs != null)
                {
                    itemLabel = new TextLabel[4];
                    
                    for (int i = 0; i < 4; i++)
                    {
                        itemLabel[i] = new TextLabel();
                        aniView.Add(itemLabel[i]);    
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
            
            Console.WriteLine("---OnTouchEvent---" + panAnimationState + "state: " + state);

            if (panAnimationState == PanAnimationState.FinishAni)
            {
                if (state == PointStateType.Down)
                {
                    finishedTimer.Stop();
                    ResetPositon();  
                    isTouchRelease = false;
                }
            }
            else
            {
                if (state == PointStateType.Down)
                {
                    isTouchRelease = true;
                }
            }
            
            return false;
        }

        private bool OnFinishedTickEvent(object source, Timer.TickEventArgs e)
        {
            Console.WriteLine("----OnFinishedTickEvent----");

            if (finishTimerLoopCount == 0)
            {
                ResetPositon();
                return false;
            }
            else
            {
                finishTimerLoopCount--;
                
                switch (finishAniType)
                {
                    case FinishAniType.Tap:
                        {
                            if (moveDirection == Direction.Down)
                            {
                                AnimationWithTime(floatItemHalfHeight, tapAnimationDuration / 2);
                            }
                            else
                            {
                                AnimationWithTime(-floatItemHalfHeight, tapAnimationDuration / 2);
                            }
                            
                            AdjustLabelPosition();
                        }
                        break;
                    case FinishAniType.Pan:
                        {
                            if (finishTimerLoopCount == 0)
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
            Console.WriteLine("----OnTapGestureDetected---, e.TapGesture.y = " + e.TapGesture.LocalPoint.Y);
            
            if (panAnimationState != PanAnimationState.None)
            {
                return;
            }
            
            if (!isTouchRelease)
            {
                return;
            }
            
            if (!finishedTimer.IsRunning())
            {
                float Y = e.TapGesture.LocalPoint.Y;
                
                if (Y < (dividerRec.Position2D.Y - clipView.Position2D.Y))
                {
                    if (curValue == nMin)
                    {
                        return;
                    }
                    else
                    {
                        moveDirection = Direction.Down;
                        calculateAdjustLen = floatItemHalfHeight;
                        AnimationWithTime(floatItemHalfHeight, tapAnimationDuration / 2);

                        if (finishedTimer != null)
                        {
                            finishAniType = FinishAniType.Tap;
                            finishTimerLoopCount = 1;
                            finishedTimer.Interval = (uint)spinAnimation.Duration;
                            finishedTimer.Start();
                        }
                    }
                }
                else if (Y >= (dividerRec.Position2D.Y - clipView.Position2D.Y) && Y <= (dividerRec2.Position2D.Y - clipView.Position2D.Y))
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
                    if (curValue == nMax)
                    {
                        return;
                    }
                    else
                    {
                        moveDirection = Direction.Up;
                        calculateAdjustLen = -floatItemHalfHeight;
                        AnimationWithTime(-floatItemHalfHeight, tapAnimationDuration / 2);

                        if (finishedTimer != null)
                        {
                            finishAniType = FinishAniType.Tap;
                            finishTimerLoopCount = 1;
                            finishedTimer.Interval = (uint)spinAnimation.Duration;
                            finishedTimer.Start();
                        }
                    }
                }
            }            
        }    
        
        private void PanGestureInit()
        {    
            panAnimationState = PanAnimationState.None;
            moveDirection = Direction.None;
            calculateAdjustLen = 0;
            midItemPositionY = itemHeight; 
            aniViewPositionY = 0;
            curMoveHeight = 0;
            finishAniAction = FinishAniAction.None;
            finishTimerLoopCount = 0;
            
            //calculate the max movement
            maxMoveDownHeight = (curValue - nMin) * itemHeight;
            maxMoveUpHeight = (curValue - nMax) * itemHeight;            
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
                    moveDirection = Direction.Down;
                    calculateAdjustLen = itemHeight / 2;
                }
                else
                {
                    moveDirection = Direction.Up;
                    calculateAdjustLen = -itemHeight / 2;
                }
                
                finishAniType = FinishAniType.Pan;
            }

            if (e.PanGesture.State == Gesture.StateType.Continuing || e.PanGesture.State == Gesture.StateType.Started)
            {
                Console.WriteLine("----- e.PanGesture.State = " + e.PanGesture.State + "time = " + e.PanGesture.Time + "Y=" + e.PanGesture.Displacement.Y);
                
                float calculateMove = 0f;
                
                spinAnimation.Stop();
                curMoveHeight += e.PanGesture.Displacement.Y;
                panAnimationState = PanAnimationState.PanAni;

                if (e.PanGesture.Displacement.Y > 0)
                {
                    if (moveDirection == Direction.Up)
                    {
                        calculateAdjustLen += itemHeight;
                    }
                    
                    lastMoveHeight = e.PanGesture.Displacement.Y;
                    
                    if (curMoveHeight > maxMoveDownHeight)
                    {
                        calculateMove = maxMoveDownHeight - (curMoveHeight - e.PanGesture.Displacement.Y);
                        curMoveHeight = maxMoveDownHeight;
                    }
                    else
                    {
                        calculateMove = e.PanGesture.Displacement.Y;
                    }

                    if(calculateMove != 0)
                    {
                        moveDirection = Direction.Down;
                    }
                    else
                    {
                        moveDirection = Direction.Down;
                        return;
                    }

                    while (calculateMove > floatItemHeight)// need improve
                    {
                        spinAnimation.Stop();
                        spinAnimation.Clear();                        
                        aniViewPositionY += floatItemHeight;
                        spinAnimation.AnimateTo(aniView, "Position", new Position(0, aniViewPositionY, 0));
                        AdjustLabelPosition();                        
                        calculateMove -= floatItemHeight;
                    }
                    
                    AnimationWithTime(calculateMove, 50);                    
                    calculateAdjustLen += calculateMove;                    
                }
                else if (e.PanGesture.Displacement.Y < 0)
                {
                    Console.WriteLine("----curValue : " + curValue +" " + maxMoveUpHeight +" " + curMoveHeight);
                    
                    if (moveDirection == Direction.Down)
                    {
                        calculateAdjustLen -= itemHeight;
                    }
                    
                    lastMoveHeight = -e.PanGesture.Displacement.Y;
                    
                    if (curMoveHeight < maxMoveUpHeight)
                    {
                        calculateMove = maxMoveUpHeight - (curMoveHeight - e.PanGesture.Displacement.Y);
                        curMoveHeight = maxMoveUpHeight;
                    }
                    else
                    {
                        calculateMove = e.PanGesture.Displacement.Y;
                    }
                                        
                    if(calculateMove != 0)
                    {
                        moveDirection = Direction.Up;
                    }
                    else
                    {
                        moveDirection = Direction.Up;
                        return;
                    }

                    while (calculateMove < -floatItemHeight) // need improve
                    {
                        spinAnimation.Stop();
                        spinAnimation.Clear();                        
                        aniViewPositionY -= floatItemHeight;
                        spinAnimation.AnimateTo(aniView, "Position", new Position(0, aniViewPositionY, 0));                        
                        AdjustLabelPosition();                   
                        calculateMove += floatItemHeight;
                    }
                    
                    AnimationWithTime(calculateMove, 50);
                    calculateAdjustLen += calculateMove;    
                }
                                
                if ((moveDirection == Direction.Down) && ((calculateAdjustLen >= floatItemHeight)))
                {
                    calculateAdjustLen -= itemHeight;
                    AdjustLabelPosition();
                }
                else if ((moveDirection == Direction.Up) && ((calculateAdjustLen <= -floatItemHeight)))
                {
                    calculateAdjustLen += itemHeight;
                    AdjustLabelPosition();
                }
            }

            if (e.PanGesture.State == Gesture.StateType.Finished)
            {
                Console.WriteLine("------e.PanGesture.State = " + e.PanGesture.State + "time = " + e.PanGesture.Time);
                
                panAnimationState = PanAnimationState.FinishAni;
                
                if (lastMoveHeight < 2)
                {
                    finishAniAction = FinishAniAction.MoveToCenter;
                }
                else if (lastMoveHeight >= 2 && lastMoveHeight <= 3)
                {
                    finishAniAction = FinishAniAction.MoveToNext; 
                }
                else if (lastMoveHeight > 3 && lastMoveHeight <= 10)
                {
                    finishAniAction = FinishAniAction.MoveToNext5; 
                }
                else
                {
                    finishAniAction = FinishAniAction.MoveToNext20; 
                }

                Console.WriteLine("---finishAniAction: " + finishAniAction);
                
                if (finishAniAction == FinishAniAction.MoveToCenter)
                {
                    if (finishedTimer != null)
                    {
                        if (moveDirection == Direction.Down)
                        {
                            AnimationWithTime(floatItemHalfHeight - calculateAdjustLen, 100 * GetAbs(floatItemHalfHeight - calculateAdjustLen) / itemHeight); 
                            
                        }
                        else if (moveDirection == Direction.Up)
                        {
                            AnimationWithTime(-floatItemHalfHeight - calculateAdjustLen, 100 * GetAbs(-floatItemHalfHeight - calculateAdjustLen) / itemHeight);
                        }
                                                
                        finishedTimer.Interval = (uint)spinAnimation.Duration;
                        finishTimerLoopCount = 0;
                        finishedTimer.Start();
                    }
                }
                else if (finishAniAction == FinishAniAction.MoveToNext)
                {
                    finishTimerFirstInterval = 500;
                    finishTimerIncreaseInterval = 100;
                    StartFinishedAnimation(1);                        
                }
                else if (finishAniAction == FinishAniAction.MoveToNext5)
                {
                    finishTimerFirstInterval = 100;
                    finishTimerIncreaseInterval = 60;
                    StartFinishedAnimation(5);
                }
                else if (finishAniAction == FinishAniAction.MoveToNext20)
                {
                    finishTimerFirstInterval = 15;
                    finishTimerIncreaseInterval = 6;
                    StartFinishedAnimation(20);
                }                    
            }
        }

        private void FinishAnimation(bool isHalfItemHeight)
        {
            float moveHeight = 0;
            
            if (isHalfItemHeight)
            {
                moveHeight = floatItemHalfHeight;
            }
            else
            {
                moveHeight = floatItemHeight;
            }
            
            finishTimerFirstInterval += finishTimerIncreaseInterval;
            spinAnimation.Duration = finishTimerFirstInterval;
            finishedTimer.Interval = (uint)spinAnimation.Duration;

            if (moveDirection == Direction.Down)
            {
                if ((maxMoveDownHeight- curMoveHeight) < floatItemHeight)
                {
                    finishTimerLoopCount = 0;
                    moveHeight = floatItemHalfHeight;
                }
                
                curMoveHeight += moveHeight;

                if (curMoveHeight > maxMoveDownHeight)
                {
                    curMoveHeight = maxMoveDownHeight;
                    return;
                }
                else
                {
                    spinAnimation.Stop();
                    spinAnimation.Clear();
                    aniViewPositionY += moveHeight;
                    spinAnimation.AnimateTo(aniView, "Position", new Position(0, aniViewPositionY, 0));
                    spinAnimation.Play();
                    AdjustLabelPosition();
                }
            }
            else if (moveDirection == Direction.Up)
            {
                if ((maxMoveUpHeight- curMoveHeight) > -floatItemHeight)
                {
                    finishTimerLoopCount = 0;
                    moveHeight = floatItemHalfHeight;
                }
                
                curMoveHeight -= moveHeight;

                if (curMoveHeight < maxMoveUpHeight)
                {
                    curMoveHeight = maxMoveUpHeight;
                    return;
                }
                else
                {
                    spinAnimation.Stop();
                    spinAnimation.Clear();
                    aniViewPositionY -= moveHeight;
                    spinAnimation.AnimateTo(aniView, "Position", new Position(0, aniViewPositionY, 0));
                    spinAnimation.Play();                
                    AdjustLabelPosition();
                }
            }
        }
        
        private void AdjustLabelPosition()
        {
            if (moveDirection == Direction.Down)
            {
                midItemPositionY -= itemHeight;
                
                upItemIndex = (upItemIndex == 0)? 3: upItemIndex-1;
                midItemIndex = (midItemIndex == 0)? 3: midItemIndex-1;
                downItemIndex = (downItemIndex == 0)? 3: downItemIndex-1;
                itemLabel[upItemIndex].Position2D = new Position2D(0, midItemPositionY - itemHeight);
                itemLabel[upItemIndex].Text = GetStrValue(curValue - 2);
                itemLabel[upItemIndex].Opacity = 0.4f;
                itemLabel[upItemIndex].PointSize = upDownItemTextSize;
                itemLabel[midItemIndex].Opacity = 1.0f;
                itemLabel[midItemIndex].PointSize = midItemTextSize;
                itemLabel[downItemIndex].Opacity = 0.4f;
                itemLabel[downItemIndex].PointSize = upDownItemTextSize;

                curValue -= 1;
            }
            else if (moveDirection == Direction.Up)
            {
                midItemPositionY += itemHeight;
                
                upItemIndex = (upItemIndex == 3)? 0: upItemIndex+1;
                midItemIndex = (midItemIndex == 3)? 0: midItemIndex+1;
                downItemIndex = (downItemIndex == 3)? 0: downItemIndex+1;
                itemLabel[downItemIndex].Position2D = new Position2D(0, midItemPositionY + itemHeight);
                itemLabel[downItemIndex].Text = GetStrValue(curValue + 2);
                itemLabel[upItemIndex].Opacity = 0.4f;
                itemLabel[upItemIndex].PointSize = upDownItemTextSize;
                itemLabel[midItemIndex].Opacity = 1.0f;
                itemLabel[midItemIndex].PointSize = midItemTextSize;
                itemLabel[downItemIndex].Opacity = 0.4f;
                itemLabel[downItemIndex].PointSize = upDownItemTextSize;
                
                curValue += 1;
            }
        }

        private void ResetPositon()
        {
            spinAnimation.Stop();
            spinAnimation.Clear();
            panAnimationState = 0;
            calculateAdjustLen= 0;
            upItemIndex = 0;
            midItemIndex = 1;
            downItemIndex = 2;
            aniView.Position2D = new Position2D(0, 0);
            itemLabel[0].Position2D = new Position2D(0, 0);
            itemLabel[0].Text = GetStrValue(curValue-1);
            itemLabel[1].Position2D = new Position2D(0, itemHeight);
            itemLabel[1].Text = GetStrValue(curValue);
            itemLabel[2].Position2D = new Position2D(0, itemHeight*2);
            itemLabel[2].Text = GetStrValue(curValue+1);
            itemLabel[upItemIndex].Opacity = 0.4f;
            itemLabel[upItemIndex].PointSize = upDownItemTextSize;
            itemLabel[midItemIndex].Opacity = 1.0f;
            itemLabel[midItemIndex].PointSize = midItemTextSize;
            itemLabel[downItemIndex].Opacity = 0.4f;
            itemLabel[downItemIndex].PointSize = upDownItemTextSize;
            midItemPositionY = itemHeight;
            aniViewPositionY = 0;
        }
        
        private void AnimationWithTime(float move, int time)
        {
            spinAnimation.Stop();
            spinAnimation.Clear();
            aniViewPositionY += move;
            spinAnimation.Duration = time;
            spinAnimation.AnimateTo(aniView, "Position", new Position(0, aniViewPositionY, 0));
            spinAnimation.Play();
        }
        
        private void SwitchToTextField()
        {
            aniView.Hide();
            dividerRec.Hide();
            dividerRec2.Hide();
            panGestureDetector.Detach(clipView);
            tapGestureDetector.Detach(clipView);
            textField.Show();
        }

        private void SwitchToAniView()
        {
            textField.Hide();
            ResetPositon();
            panGestureDetector.Attach(clipView);
            tapGestureDetector.Attach(clipView);
            aniView.Show();
            dividerRec.Show();
            dividerRec2.Show();
        }

        private void StartFinishedAnimation(uint cnt)
        {
            if (calculateAdjustLen != floatItemHeight / 2 && calculateAdjustLen != -floatItemHeight / 2)
            {
                if (moveDirection == Direction.Down)
                {
                    curMoveHeight += (floatItemHeight - calculateAdjustLen);
                    
                    if (curMoveHeight > maxMoveDownHeight)
                    {
                        AnimationWithTime(floatItemHalfHeight - calculateAdjustLen, 100 * GetAbs(floatItemHalfHeight - calculateAdjustLen) / itemHeight);
                        finishTimerLoopCount = 0;
                    }
                    else
                    {
                        AnimationWithTime(floatItemHeight - calculateAdjustLen, 100 * GetAbs(floatItemHeight - calculateAdjustLen) / itemHeight);
                        finishTimerLoopCount = cnt;
                    }
                }
                else if (moveDirection == Direction.Up)
                {
                    curMoveHeight += (-floatItemHeight - calculateAdjustLen);
                    
                    if (curMoveHeight < maxMoveUpHeight)
                    {
                        AnimationWithTime(-floatItemHalfHeight - calculateAdjustLen, 100 * GetAbs(-floatItemHalfHeight - calculateAdjustLen) / itemHeight);
                        finishTimerLoopCount = 0;
                    }
                    else
                    {
                        AnimationWithTime(-floatItemHeight - calculateAdjustLen, 100 * GetAbs(-floatItemHeight - calculateAdjustLen) / itemHeight);
                        finishTimerLoopCount = cnt;
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
                finishTimerLoopCount = cnt - 1;
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
