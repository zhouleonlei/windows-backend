using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.CommonUI
{
    public class Toast : Control
    {
        private ToastAttributes toastAttributes;
        private ImageView toastBackground;
        private TextLabel toastText;
        private Timer timer;
        private Animation showAnimation;
        private Animation hideAnimation;
        private int leftSpace;
        private int downSpace;
        private bool autoDestroy = false;

        public Toast() : base()
        {
            SetAttribute();

            Initialize();
        }

        public Toast(ToastAttributes attributes)
        {
            this.attributes = toastAttributes = attributes.Clone() as ToastAttributes;
            Initialize();
        }

        public Toast(string style) : base(style)
        {
            if (attributes != null)
                toastAttributes = attributes as ToastAttributes;
            if (toastAttributes == null)
            {
                throw new Exception("Toast attribute parse error.");
            }
            Initialize();
        }

        public string Text
        {
            get
            {
                return toastText?.Text;
            }
            set
            {
                toastText.Text = value;
            }

        }

        public string BackgroundImageURL
        {
            get
            {
                if (toastAttributes.BackgroundImageAttributes.ResourceURL == null)
                    toastAttributes.BackgroundImageAttributes.ResourceURL = new StringSelector();
                return toastAttributes.BackgroundImageAttributes.ResourceURL.All;
            }
            set
            {
                if (toastAttributes.BackgroundImageAttributes.ResourceURL == null)
                {
                    toastAttributes.BackgroundImageAttributes.ResourceURL = new StringSelector();
                }

                toastAttributes.BackgroundImageAttributes.ResourceURL.All = value;
                Console.WriteLine("set url in SR");//gwfdebug
                RelayoutRequest();
            }
        }

        public int LeftSpace
        {
            get
            {
                return leftSpace;
            }
            set
            {
                leftSpace = value;
                RelayoutRequest();
            }
        }

        public int UpSpace
        {
            get
            {
                if (toastAttributes.UpSpace == null)
                {
                    toastAttributes.UpSpace = new int();
                }
                return toastAttributes.UpSpace.Value;
            }
            set
            {
                if (toastAttributes.UpSpace == null)
                {
                    toastAttributes.UpSpace = new int();
                }
                toastAttributes.UpSpace = value;
                downSpace = value;
                Console.WriteLine("Call set upspace done");
            }
        }

        public int DownSpace
        {
            get
            {
                return downSpace;
            }
            set
            {
                downSpace = value;
            }
        }

        public Rectangle BackgroundBorder
        {
            get
            {
                return toastAttributes?.BackgroundImageAttributes?.Border.All;
            }
            set
            {
                if (toastAttributes.BackgroundImageAttributes.Border == null)
                {
                    toastAttributes.BackgroundImageAttributes.Border = new RectangleSelector();
                }
                toastAttributes.BackgroundImageAttributes.Border.All = value;
            }

        }

        public Size2D TextSize2D
        {
            get
            {
                return toastAttributes?.TextAttributes?.Size2D;
            }
            set
            {
                toastText.Size2D = toastAttributes.TextAttributes.Size2D = value;
            }

        }

        public Position2D TextPosition2D
        {
            set
            {
                toastText.Position2D = toastAttributes.TextAttributes.Position2D = value;
            }
        }

        public void Show(uint millisecond, bool autoDestroy = false)
        {
            ShowWithAnimation(opacityDuration: 700, opacityStart: 0.5f, scaleDuration: 700, scaleStart: 0.97f);
            CreateTimer(millisecond);
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (toastBackground != null)
                {
                    this.Remove(toastBackground);
                    toastBackground.Dispose();
                    toastBackground = null;
                }

                if (toastText != null)
                {
                    this.Remove(toastText);
                    toastText.Dispose();
                    toastText = null;
                }
            }

            base.Dispose(type);
        }

        protected override void OnUpdate(Attributes attributes)
        {
            if (toastAttributes == null)
            {
                Console.WriteLine("OnUp att null (SR)");//gwfdebug
                return;
            }

            LayoutChild();

            /////////////////////////////////////////////////////
            ApplyAttributes(this, toastAttributes);

            ///////////////////// Background ///////////////////////////////
            ApplyAttributes(toastBackground, toastAttributes.BackgroundImageAttributes);
            Console.WriteLine("Apply background " + toastAttributes.BackgroundImageAttributes.ResourceURL.All);
            ////////////////////// Text //////////////////////////////
            ApplyAttributes(toastText, toastAttributes.TextAttributes);
        }

        protected override void OnRelayout(object sender, EventArgs e)
        {
            OnUpdate(attributes);
        }

        protected override Attributes GetAttributes()
        {
            return new ToastAttributes
            {
                TextAttributes = new TextAttributes
                {

                },

                BackgroundImageAttributes = new ImageAttributes
                {

                }

            };
        }

        protected virtual void LayoutChild()
        {
            if (toastAttributes.TextAttributes.Size2D == null)
            {
                toastAttributes.TextAttributes.Size2D = new Size2D();
            }
            if (toastAttributes.TextAttributes.Position2D == null)
            {
                toastAttributes.TextAttributes.Position2D = new Position2D();
            }
            toastAttributes.TextAttributes.Size2D.Width = this.Size2D.Width - 2 * LeftSpace;
            //Console.WriteLine("this.height"+this.Size2D.Height+" Upspace"+UpSpace.ToString()+"downSpace= "+downSpace.ToString());gwfdebug
            toastAttributes.TextAttributes.Size2D.Height = this.Size2D.Height - UpSpace - downSpace;
            toastAttributes.TextAttributes.Position2D.X = LeftSpace;
            toastAttributes.TextAttributes.Position2D.Y = UpSpace;
        }

        protected void SetAttribute()
        {
            toastAttributes = this.attributes as ToastAttributes;
        }

        private void Initialize()
        {
            Console.WriteLine("Initialize (SR)  Toast ");
            toastBackground = new ImageView()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            this.Add(toastBackground);

            toastText = new TextLabel()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            this.Add(toastText);
        }

        private void ShowWithAnimation(float opacityStart = 0.5f,
                                        float opacityEnd = 1.0f,
                                        int opacityStartTime = 0,
                                        int opacityDuration = 700,
                                        string opacityMotionCurve = "Basic",
                                        float scaleStart = 0.98f,
                                        float scaleEnd = 1.0f,
                                        int scaleStartTime = 0,
                                        int scaleDuration = 700,
                                        string scaleMotionCurve = "Elastic"
                                                                    )
        {
            if (hideAnimation != null && hideAnimation.State == Animation.States.Playing)
            {
                hideAnimation.Finished -= HideAnimationFinished;
                hideAnimation.Stop();
            }
            else if (Visibility == true)
            {
                //return;
            }

            if (showAnimation == null)
            {
                showAnimation = new Animation();
            }
            else if (showAnimation.State == Animation.States.Playing)
            {
                return;
            }

            //set start value
            Opacity = opacityStart;
            float scaleStartVal = scaleStart;
            float scaleEndVal = scaleEnd;
            showAnimation.Clear();
            Scale = new Vector3(scaleStartVal, scaleStartVal, 1);
            Show();

            showAnimation.Clear();

            int opacityEndTime = opacityStartTime + opacityDuration;
            int scaleEndTime = scaleStartTime + scaleDuration;
            showAnimation.Duration = opacityEndTime > scaleEndTime ? opacityEndTime : scaleEndTime;
            showAnimation.AnimateTo(this, "Opacity", opacityEnd, opacityStartTime, opacityEndTime);
            showAnimation.AnimateTo(this, "Scale", new Vector3(scaleEndVal, scaleEndVal, 1), scaleStartTime, scaleEndTime);

            showAnimation.Play();

        }

        private void HideWithAnimation(float opacityStart = 1.0f,
                                        float opacityEnd = 0.0f,
                                        int opacityStartTime = 0,
                                        int opacityDuration = 200,
                                        string opacityMotionCurve = "Basic",
                                        float scaleStart = 1.0f,
                                        float scaleEnd = 0.99f,
                                        int scaleStartTime = 0,
                                        int scaleDuration = 200,
                                        string scaleMotionCurve = "Elastic",
                                        bool autoDestroy = false
                                        )
        {
            if (showAnimation != null && showAnimation.State == Animation.States.Playing)
            {
                showAnimation.Stop();
            }
            if (Visibility == false)
            {
                return;
            }

            if (hideAnimation == null)
            {
                hideAnimation = new Animation();
            }
            else if (hideAnimation.State == Animation.States.Playing)
            {
                return;
            }

            hideAnimation.Finished += HideAnimationFinished;

            Opacity = opacityStart;
            float scaleStartVal = scaleStart;

            Scale = new Vector3(scaleStartVal, scaleStartVal, 1);

            hideAnimation.Clear();

            int opacityEndTime = opacityStartTime + opacityDuration;
            int scaleEndTime = scaleStartTime + scaleDuration;
            hideAnimation.Duration = opacityEndTime > scaleEndTime ? opacityEndTime : scaleEndTime;
            hideAnimation.AnimateTo(this, "Opacity", opacityEnd, opacityStartTime, opacityEndTime);
            float scaleEndVal = scaleEnd;
            hideAnimation.AnimateTo(this, "Scale", new Vector3(scaleEndVal, scaleEndVal, 1), scaleStartTime, scaleEndTime);

            hideAnimation.Play();
        }

        private void HideAnimationFinished(object sender, EventArgs e)
        {
            hideAnimation.Finished -= HideAnimationFinished;
            if (autoDestroy == true)
            {
                if (this.GetParent() != null)
                {
                    this.GetParent().Remove(this);
                }
                this.Dispose();
            }
            else
            {
                Hide();
                Opacity = 1.0f;
                Scale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }

        private void CreateTimer(uint millisecond)
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }

            timer = new Timer(millisecond);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private bool TimerTick(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Tick -= TimerTick;
            timer.Dispose();

            timer = null;
            HideWithAnimation(opacityDuration: 200, opacityEnd: 0.5f, scaleDuration: 200, scaleEnd: 0.95f);

            return false;
        }
    }
}
