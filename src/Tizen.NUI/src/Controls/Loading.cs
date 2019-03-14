using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    /// <summary>
    /// The Loading class of tv nui component. It's used to indicate informs users of the ongoing operation.
    /// </summary>
    /// <code>
    /// Loading loading = new Loading("C_Loading_WhiteSmall");
    /// </code>
    /// <code>
    /// Loading.Attributes attr = new Loading.Attributes();
    /// attr.FPS = 60;
    /// attr.ImageArray = new string[]
    /// {
    ///     @"/usr/share/resources/image/loading/loading_whites/loading_whites_00.png",
    ///     ...
    ///     @"/usr/share/resources/image/loading/loading_whites/loading_whites_35.png"
    /// };
    /// Loading loading = new Loading(attr); 
    /// </code>
    public class Loading : Control
    {
        protected override Attributes GetAttributes()
        {
            return null;
        }

        public List<string> ImageArray = null;

        public Loading() : base()
        {
            if (loadingAttrs == null)
            {
                this.attributes = loadingAttrs = new LoadingAttributes
                {
                    LoadingImageURLPrefix = new StringSelector(),

                };
            }
            Initialize();
        }

        public Loading(string style) : base(style)
        {
            Initialize();
        }

        public Loading(LoadingAttributes attributes) : base()
        {
            this.attributes = loadingAttrs = attributes.Clone() as LoadingAttributes;
            Initialize();
        }

        //public void Play()
        //{
        //    aniState = AnimationState.Play;
        //    UpdateAnimationState();
        //}

        //public void Stop()
        //{
        //    aniState = AnimationState.Stop;
        //    UpdateAnimationState();

        //    imageVisual.
        //}

        //public void Pause()
        //{
        //    aniState = AnimationState.Pause;
        //    UpdateAnimationState();
        //}

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
                //frameAni.Stop();
                //frameAni.Detach();
                //frameAni = null;

                // According to FrameAnimation spec, image source should be Disposed later than FrameAnimation.
                RemoveVisual("imageVisual");

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
            //Console.WriteLine(" ----  OnUpdate");
            //if (attrs != null)
            //    loadingAttrs = attrs as LoadingAttributes;
            //ApplyAttributes(this, loadingAttrs);
            //UpdateList();
        }

        public string LoadingImageURLPrefix
        {
            get
            {
                return loadingAttrs.LoadingImageURLPrefix.All;
            }
            set
            {
                loadingAttrs.LoadingImageURLPrefix.All = value;

                UpdateList();

            }
        }

        public int FPS
        {
            get
            {
                if (loadingAttrs.FPS == null)
                {
                    loadingAttrs.FPS = new IntSelector();
                    loadingAttrs.FPS.All = (int)(1000.0f / imageVisual.FrameDelay);
                }
                return loadingAttrs.FPS.All.Value;
            }
            set
            {
                if (loadingAttrs.FPS == null)
                {
                    loadingAttrs.FPS = new IntSelector();
                    loadingAttrs.FPS.All = (int) (1000.0f / imageVisual.FrameDelay);
                }
                loadingAttrs.FPS.All = value;
                Console.WriteLine("---------"+ imageVisual.FrameDelay.ToString());
                imageVisual.FrameDelay = 1000.0f / (float)value;

            }
        }

        private void UpdateList()
        {

            if (ImageArray != null)
            {
                ImageArray.Clear();
                Console.WriteLine("!!!!!!!!CLEAR");
                if (loadingAttrs != null)
                {
                    Console.WriteLine("!!!!!!!!!169");
                    if (loadingAttrs.LoadingImageURLPrefix != null)
                    {
                        for (int i = 0; i <= 35; i++)
                        {
                            string pre = loadingAttrs.LoadingImageURLPrefix.All;
                            if (i < 10)
                            {

                                ImageArray.Add(pre + "0" + i.ToString() + ".png");
                            }
                            else
                            {
                                ImageArray.Add(pre + i.ToString() + ".png");
                            }

                        }
                    }
                }
                imageVisual.URLS = ImageArray;
            }

        }

        private void Initialize()
        {
            ImageArray = new List<string>();
            imageVisual = new AnimatedImageVisual()
            {
                URLS = ImageArray,
                FrameDelay = 16.6f,
                LoopCount = -1,
                Size = new Size2D(100, 100),
                Position = new Vector2(0, 0),
                Origin = Visual.AlignType.TopEnd,
                AnchorPoint = Visual.AlignType.TopEnd
            };

            loadingAttrs = attributes as LoadingAttributes;

            UpdateList();

            this.AddVisual("imageVisual", imageVisual);
        }

        internal enum AnimationState
        {
            None,
            Play,
            Pause,
            Stop
        }

        private LoadingAttributes loadingAttrs = null;     // Loading Attributes
        //private FrameAnimation frameAni = null;     // FrameAnimation
        private ImageView imageView = null;         // ImageView object
        private AnimatedImageVisual imageVisual = null;

        //private AnimationState aniState = AnimationState.None;  // Animation state
    }
}
