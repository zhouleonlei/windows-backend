using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.CommonUI
{
    public class Loading : Control
    {
        public List<string> ImageArray = null;
        private LoadingAttributes loadingAttrs = null;  // Loading Attributes

        private ImageView imageView = null;             // ImageView object
        private AnimatedImageVisual imageVisual = null;

        public Loading() : base()
        {
            loadingAttrs = this.attributes as LoadingAttributes;
            Initialize();
        }

        public Loading(string style) : base(style)
        {
            if (attributes != null)
                loadingAttrs = attributes as LoadingAttributes;
            Initialize();
        }

        public Loading(LoadingAttributes attributes) : base()
        {
            this.attributes = loadingAttrs = attributes.Clone() as LoadingAttributes;
            Initialize();
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

        protected override Attributes GetAttributes()
        {
            return new LoadingAttributes
            {
                LoadingImageURLPrefix = new StringSelector(),
            };
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
            if (loadingAttrs == null)
            {
                return;
            }
            ApplyAttributes(this, loadingAttrs);
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

            UpdateList();

            this.AddVisual("imageVisual", imageVisual);
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
    }
}
