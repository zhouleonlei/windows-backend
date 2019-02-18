//using System;
//using Tizen.NUI;
//using Tizen.NUI.BaseComponents;

//namespace Tizen.NUI.Controls
//{
//    /// <summary>
//    /// The Loading class of tv nui component. It's used to indicate informs users of the ongoing operation.
//    /// </summary>
//    /// <code>
//    /// Loading loading = new Loading("C_Loading_WhiteSmall");
//    /// </code>
//    /// <code>
//    /// Loading.Attributes attr = new Loading.Attributes();
//    /// attr.FPS = 60;
//    /// attr.ImageArray = new string[]
//    /// {
//    ///     @"/usr/share/resources/image/loading/loading_whites/loading_whites_00.png",
//    ///     ...
//    ///     @"/usr/share/resources/image/loading/loading_whites/loading_whites_35.png"
//    /// };
//    /// Loading loading = new Loading(attr); 
//    /// </code>
//    public class Loading : Control
//    {
//        protected override Attributes GetAttributes()
//        {
//            return null;
//        }

//        public new class aAttributes : Control.Attributes
//        {
//            /// <summary>
//            /// The default constructor of the Loading Attributes class.
//            /// </summary>
//            public Attributes()
//            {
//            }

//            /// <summary>
//            /// Copy Constructor of the Loading Attributes class.
//            /// </summary>
//            /// <param name="attrs">Attributes to be copied</param>
//            public Attributes(Attributes attrs) : base(attrs)
//            {
//                if (attrs == null)
//                {
//                    return;
//                }
//                if (attrs.ImageArray != null)
//                {
//                    int length = attrs.ImageArray.Length;
//                    if (length > 0)
//                    {
//                        ImageArray = new string[length];
//                        for (int i = 0; i < length; i++)
//                        {
//                            ImageArray[i] = attrs.ImageArray[i];
//                        }
//                    }
//                }
//                if (attrs.FPS != null)
//                {
//                    FPS = attrs.FPS;
//                }
//            }

//            /// <summary>
//            /// The method to clone the Loading Attributes.
//            /// </summary>
//            /// <returns>The Loading Attributes.</returns>
//            public override Control.Attributes Clone()
//            {
//                return new Attributes(this);
//            }

//            /// <summary>
//            /// The image array.
//            /// </summary>
//            public string[] ImageArray = null;

//            /// <summary>
//            /// The animation FPS.
//            /// </summary>
//            public int? FPS = null;
//        }

//        /// <summary>
//        /// The static method to create Loading instance.
//        /// </summary>
//        /// <returns>The Loading instance.</returns>
//        static Loading CreateInstance()
//        {
//            return new Loading();
//        }

//        /// <summary>
//        /// For register type to View Registry
//        /// </summary>
//        static Loading()
//        {
//        }

//        /// <summary>
//        /// The constructor of Loading
//        /// </summary>
//        public Loading() : base()
//        {
//            if (loadingAttrs == null)
//            {
//                loadingAttrs = new Attributes();
//            }
//            Initialize();
//        }
//        /// <summary>
//        /// Constructor of the Loading class with special style.
//        /// </summary>
//        /// <param name="style">The string to initialize the Loading.</param>
//        public Loading(string style) : base(style)
//        {
//            if (loadingAttrs == null)
//            {
//                loadingAttrs = new Attributes();
//            }
//            Initialize();
//        }

//        /// <summary>
//        /// The constructor of the Loading class with specific Attributes.
//        /// </summary>
//        /// <param name="attrs">The Attributes object to initialize the Loading.</param>
//        public Loading(Attributes attrs = null) : base(attrs, "Loading")
//        {
//            if (loadingAttrs == null)
//            {
//                loadingAttrs = new Attributes();
//            }
//            Initialize();
//        }

//        /// <summary>
//        /// Function to Play the loading animation.
//        /// </summary>
//        public void Play()
//        {
//            aniState = AnimationState.Play;
//            UpdateAnimationState();
//        }

//        /// <summary>
//        /// Function to Stop the loading animation.
//        /// </summary>
//        public void Stop()
//        {
//            aniState = AnimationState.Stop;
//            UpdateAnimationState();
//        }

//        /// <summary>
//        /// Function to Pause the loading animation.
//        /// </summary>
//        public void Pause()
//        {
//            aniState = AnimationState.Pause;
//            UpdateAnimationState();
//        }

//        /// <summary>
//        /// Dispose Loading.
//        /// </summary>
//        /// <param name="type">The DisposeTypes value.</param>
//        protected override void Dispose(DisposeTypes type)
//        {
//            if (disposed)
//            {
//                return;
//            }

//            if (type == DisposeTypes.Explicit)
//            {
//                //Called by User
//                //Release your own managed resources here.
//                //You should release all of your own disposable objects here.
//                frameAni.Stop();
//                frameAni.Detach();
//                frameAni = null;

//                // According to FrameAnimation spec, image source should be Disposed later than FrameAnimation.
//                Remove(imageView);
//                imageView.Dispose();
//                imageView = null;
//            }

//            //Release your own unmanaged resources here.
//            //You should not access any managed member here except static instance.
//            //because the execution order of Finalizes is non-deterministic.
//            //Unreference this from if a static instance refer to this. 

//            //You must call base.Dispose(type) just before exit.
//            base.Dispose(type);
//        }

//        /// <summary>
//        /// The method to update Attributes.
//        /// </summary>
//        /// <param name="attrs">The specified attributes object.</param>
//        protected override void OnUpdate(Control.Attributes attrs)
//        {
//            if (attrs is Attributes pAttrs)
//            {
//                UpdateAttributes(pAttrs);
//                ApplyAttributes();
//            }
//        }

//        private void UpdateAttributes(Attributes attrs)
//        {
//            if (attrs.FPS != null)
//            {
//                loadingAttrs.FPS = attrs.FPS;
//            }
//            if (attrs.ImageArray != null)
//            {
//                int count = attrs.ImageArray.Length;
//                if (count > 0)
//                {
//                    loadingAttrs.ImageArray = new string[count];
//                    for (int i = 0; i < count; i++)
//                    {
//                        loadingAttrs.ImageArray[i] = attrs.ImageArray[i];
//                    }
//                }
//            }
//        }

//        private void ApplyAttributes()
//        {
//            if (loadingAttrs.FPS != null)
//            {
//                frameAni.FPS = loadingAttrs.FPS.Value;
//            }
//            if (loadingAttrs.ImageArray != null)
//            {
//                frameAni.Detach();
//                frameAni.ImageArray = loadingAttrs.ImageArray;
//                frameAni.Attach(imageView);
//            }
//            UpdateAnimationState();
//        }

//        private void UpdateAnimationState()
//        {
//            if (frameAni == null)
//            {
//                return;
//            }

//            if (aniState == AnimationState.Play)
//            {
//                frameAni.Play();
//            }
//            else if (aniState == AnimationState.Pause)
//            {
//                frameAni.Pause();
//            }
//            else if (aniState == AnimationState.Stop)
//            {
//                frameAni.Stop();
//            }
//        }

//        private void Initialize()
//        {
//            imageView = new ImageView
//            {
//                WidthResizePolicy = ResizePolicyType.FillToParent,
//                HeightResizePolicy = ResizePolicyType.FillToParent,
//                PositionUsesPivotPoint = true,
//                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
//                PivotPoint = Tizen.NUI.PivotPoint.Center
//            };
//            Add(imageView);

//            frameAni = new FrameAnimation
//            {
//                Looping = true
//            };
//        }

//        internal enum AnimationState
//        {
//            None,
//            Play,
//            Pause,
//            Stop
//        }

//        private Attributes loadingAttrs = null;     // Loading Attributes
//        private FrameAnimation frameAni = null;     // FrameAnimation
//        private ImageView imageView = null;         // ImageView object
//        private AnimationState aniState = AnimationState.None;  // Animation state
//    }
//}
