﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.UIComponents;
using Tizen.NUI;

namespace Tizen.FH.NUI.Samples
{
    public class Example
    {
        // Constructors

        /**
         * @param[in] name unique name of example
         * @param[in] title The caption for the example to appear on a tile button.
         */
        public Example(string name, string title)
        {
            this.name = name;
            this.title = title;
        }

        public Example()
        {
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
        }

        static public int CompareByTitle(Example lhs, Example rhs)
        {
            return String.Compare(lhs.title, lhs.title);
        }
    };

    public class DaliTableView
    {
        static public string DEMO_IMAGE_DIR = CommonResource.GetDaliResourcePath() + "DaliDemo/";
        static public string LOGO_PATH = DEMO_IMAGE_DIR + "Logo-for-demo.png";

        const float KEYBOARD_FOCUS_ANIMATION_DURATION = 1.0f;           ///< The total duration of the keyboard focus animation
        const float KEYBOARD_FOCUS_START_SCALE = 1.05f;                 ///< The starting scale of the focus highlight
        const float KEYBOARD_FOCUS_END_SCALE = 1.18f;                   ///< The end scale of the focus highlight
        const float KEYBOARD_FOCUS_END_ALPHA = 0.7f;                    ///< The end alpha of the focus highlight
        const float KEYBOARD_FOCUS_INITIAL_FADE_PERCENTAGE = 0.16f;     ///< The duration of the initial fade (from translucent to the end-alpha) as a percentage of the overal animation duration.
        Vector3 startScale = new Vector3(KEYBOARD_FOCUS_START_SCALE, KEYBOARD_FOCUS_START_SCALE, KEYBOARD_FOCUS_START_SCALE); ///< @see KEYBOARD_FOCUS_START_SCALE
        Vector3 endScale = new Vector3(KEYBOARD_FOCUS_END_SCALE, KEYBOARD_FOCUS_END_SCALE, KEYBOARD_FOCUS_END_SCALE);         ///< @see KEYBOARD_FOCUS_END_SCALE
        const float initialFadeDuration = KEYBOARD_FOCUS_ANIMATION_DURATION * KEYBOARD_FOCUS_INITIAL_FADE_PERCENTAGE;   ///< @see KEYBOARD_FOCUS_INITIAL_FADE_PERCENTAGE

        const float TILE_LABEL_PADDING = 8.0f;                          ///< Border between edge of tile and the example text
        const float BUTTON_PRESS_ANIMATION_TIME = 0.35f;                ///< Time to perform button scale effect.
        const float ROTATE_ANIMATION_TIME = 0.5f;                       ///< Time to perform rotate effect.
        const int MAX_PAGES = 256;                                      ///< Maximum pages (arbitrary safety limit)
        const int EXAMPLES_PER_ROW = 3;
        const int ROWS_PER_PAGE = 3;
        const int EXAMPLES_PER_PAGE = EXAMPLES_PER_ROW * ROWS_PER_PAGE;
        const float LOGO_MARGIN_RATIO = 0.1f / 0.3f;
        const float BOTTOM_PADDING_RATIO = 0.4f / 0.9f;
        Vector3 SCROLLVIEW_RELATIVE_SIZE = new Vector3(0.9f, 1.0f, 0.8f);      ///< ScrollView's relative size to its parent
        Vector3 TABLE_RELATIVE_SIZE = new Vector3(0.95f, 0.9f, 0.8f);          ///< TableView's relative size to the entire stage. The Y value means sum of the logo and table relative heights.
        const float STENCIL_RELATIVE_SIZE = 1.0f;

        const float EFFECT_SNAP_DURATION = 0.66f;                       ///< Scroll Snap Duration for Effects
        const float EFFECT_FLICK_DURATION = 0.5f;                       ///< Scroll Flick Duration for Effects
        Vector3 ANGLE_CUBE_PAGE_ROTATE = new Vector3((float)Math.PI * 0.5f, (float)Math.PI * 0.5f, 0.0f);

        Vector4[] BUBBLE_COLOR =
        {
          new Vector4( 0.3255f, 0.3412f, 0.6353f, 0.32f ),
          new Vector4( 0.3647f, 0.7569f, 0.8157f, 0.32f ),
          new Vector4( 0.3804f, 0.7412f, 0.6510f, 0.32f ),
          new Vector4( 1.0f, 1.0f, 1.0f, 0.13f )
        };

        const int NUMBER_OF_BUBBLE_COLOR = 4;

        string[] SHAPE_IMAGE_TABLE =
        {
          DEMO_IMAGE_DIR + "shape-circle.png",
          DEMO_IMAGE_DIR + "shape-bubble.png"
        };

        const int NUMBER_OF_SHAPE_IMAGES = 2;

        const int NUM_BACKGROUND_IMAGES = 18;
        const float BACKGROUND_SWIPE_SCALE = 0.025f;
        const float BACKGROUND_SPREAD_SCALE = 1.5f;
        const float SCALE_MOD = 1000.0f * (float)Math.PI * 2.0f;
        const float SCALE_SPEED = 10.0f;
        const float SCALE_SPEED_SIN = 0.1f;

        const uint BACKGROUND_ANIMATION_DURATION = 15000; // 15 secs

        Vector4 BACKGROUND_COLOR = new Vector4(0.3569f, 0.5451f, 0.7294f, 1.0f);

        const float BUBBLE_MIN_Z = -1.0f;
        const float BUBBLE_MAX_Z = 0.0f;

        const uint CORE_MAJOR_VERSION = 1;
        const uint CORE_MINOR_VERSION = 4;
        const uint CORE_MICRO_VERSION = 27;

        const uint ADAPTOR_MAJOR_VERSION = 1;
        const uint ADAPTOR_MINOR_VERSION = 4;
        const uint ADAPTOR_MICRO_VERSION = 27;

        const uint TOOLKIT_MAJOR_VERSION = 1;
        const uint TOOLKIT_MINOR_VERSION = 4;
        const uint TOOLKIT_MICRO_VERSION = 27;

        public void AddExample(Example example)
        {
            mExampleList.Add(example);
        }

        public void SortAlphabetically(bool sortAlphabetically)
        {
            mSortAlphabetically = sortAlphabetically;
        }

        private const uint FOCUS_ANIMATION_ACTOR_NUMBER = 2;

        public delegate void ExampleClicked(string name);

        private ExampleClicked onClicked;

        public DaliTableView(ExampleClicked onClicked)
        {
            this.onClicked = onClicked;
        }

        public int GetCurrentPageIndex()
        {
            if (null != mScrollView)
            {
                return (int)mScrollView.GetCurrentPage();
            }
            else
            {
                return -1;
            }
        }

        public void ScrollTo(uint pageIndex)
        {
            mScrollView.ScrollTo(pageIndex, 0.0f);
        }

        public void Initialize()
        {
            Window.Instance.KeyEvent += OnKeyEvent;

            Size2D stageSize = Window.Instance.WindowSize;

            // Background
            mRootActor = CreateBackground("LauncherBackground");

            // Add logo
            ImageView logo = new ImageView(LOGO_PATH);
            logo.Name = "LOGO_IMAGE";
            //logo.SetAnchorPoint(AnchorPoint::TOP_CENTER);
            logo.PositionUsesPivotPoint = true;
            logo.PivotPoint = PivotPoint.TopCenter;
            logo.ParentOrigin = new Position(0.5f, 0.1f, 0.5f);
            logo.WidthResizePolicy = ResizePolicyType.UseNaturalSize;
            logo.HeightResizePolicy = ResizePolicyType.UseNaturalSize;

            //// The logo should appear on top of everything.
            //logo.DrawMode = DrawModeType.Overlay2D;
            mRootActor.Add(logo);

            // Show version in a popup when log is tapped
            mLogoTapDetector = new TapGestureDetector();
            mLogoTapDetector.Attach(logo);
            mLogoTapDetector.Detected += OnLogoTapped;

            // Scrollview occupying the majority of the screen
            mScrollView = new ScrollView();
            mScrollView.PositionUsesPivotPoint = true;
            mScrollView.PivotPoint = PivotPoint.BottomCenter;
            mScrollView.ParentOrigin = new Vector3(0.5f, 1.0f - 0.05f, 0.5f);
            mScrollView.WidthResizePolicy = ResizePolicyType.FillToParent;
            mScrollView.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            mScrollView.SetSizeModeFactor(new Vector3(0.0f, 0.6f, 0.0f));

            ushort buttonsPageMargin = (ushort)((1.0f - TABLE_RELATIVE_SIZE.X) * 0.5f * stageSize.Width);
            mScrollView.SetPadding(new PaddingType(buttonsPageMargin, buttonsPageMargin, 0, 0));

            //mScrollView.SetAxisAutoLock(true);
            mScrollView.ScrollCompleted += OnScrollComplete;
            mScrollView.ScrollStarted += OnScrollStart;

            mPageWidth = stageSize.Width * TABLE_RELATIVE_SIZE.X * 0.5f;

            // Populate background and bubbles - needs to be scrollViewLayer so scroll ends show
            View bubbleContainer = new View();
            bubbleContainer.WidthResizePolicy = bubbleContainer.HeightResizePolicy = ResizePolicyType.FillToParent;
            bubbleContainer.PositionUsesPivotPoint = true;
            bubbleContainer.PivotPoint = PivotPoint.Center;
            bubbleContainer.ParentOrigin = ParentOrigin.Center;
            SetupBackground(bubbleContainer);

            mRootActor.Add(bubbleContainer);
            mRootActor.Add(mScrollView);

            // Add scroll view effect and setup constraints on pages
            ApplyScrollViewEffect();

            // Add pages and tiles
            Populate();

            // Remove constraints for inner cube effect
            ApplyCubeEffectToPages();

            // Set initial orientation
            uint degrees = 0;
            Rotate(degrees);

            // Background animation
            mAnimationTimer = new Timer(BACKGROUND_ANIMATION_DURATION);
            mAnimationTimer.Tick += PauseBackgroundAnimation;
            mAnimationTimer.Start();
            mBackgroundAnimsPlaying = true;
        }

        private bool PauseBackgroundAnimation(object source, Timer.TickEventArgs e)
        {
            PauseAnimation();
            return false;
        }

        private void PauseAnimation()
        {
            if (mBackgroundAnimsPlaying)
            {
                foreach (Animation anim in mBackgroundAnimations)
                {
                    anim.Stop();
                }

                mBackgroundAnimsPlaying = false;
            }
        }

        private void PlayAnimation()
        {
            if (!mBackgroundAnimsPlaying)
            {
                foreach (Animation anim in mBackgroundAnimations)
                {
                    anim.Play();
                }

                mBackgroundAnimsPlaying = true;
            }

            mAnimationTimer.Interval = BACKGROUND_ANIMATION_DURATION;
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {

            }
        }

        private void OnScrollStart(object source, Scrollable.StartedEventArgs e)
        {
            mScrolling = true;
            //PlayAnimation();
        }

        private void OnScrollComplete(object source, Scrollable.CompletedEventArgs e)
        {
            // move focus to 1st item of new page
            mScrolling = false;
            //FocusManager.Instance.SetCurrentFocusView(mPages[mScrollView.GetCurrentPage()].GetChildAt(0));
        }

        private void OnLogoTapped(object source, TapGestureDetector.DetectedEventArgs e)
        {
            // Only show if currently fully hidden. If transitioning-out, the transition will not be interrupted.
            if (!mVersionPopup || (mVersionPopup.DisplayState == Tizen.NUI.UIComponents.Popup.DisplayStateType.Hidden))
            {
                if (!mVersionPopup)
                {
                    string stream = "";
                    stream += "DALi Core: " + CORE_MAJOR_VERSION + "." + CORE_MINOR_VERSION + "." + CORE_MICRO_VERSION + "\n";
                    stream += "DALi Adaptor: " + ADAPTOR_MAJOR_VERSION + "." + ADAPTOR_MINOR_VERSION + "." + ADAPTOR_MICRO_VERSION + "\n";
                    stream += "DALi Toolkit: " + TOOLKIT_MAJOR_VERSION + "." + TOOLKIT_MINOR_VERSION + "." + TOOLKIT_MICRO_VERSION + "\n";

                    mVersionPopup = new Tizen.NUI.UIComponents.Popup();
                    mVersionPopup.PositionUsesPivotPoint = true;
                    mVersionPopup.PivotPoint = PivotPoint.Center;
                    mVersionPopup.ParentOrigin = ParentOrigin.Center;

                    TextLabel titleActor = new TextLabel("Version information");
                    titleActor.Name = "titleActor";
                    titleActor.HorizontalAlignment = HorizontalAlignment.Center;

                    TextLabel contentActor = new TextLabel(stream);
                    contentActor.Name = "contentActor";
                    contentActor.MultiLine = true;
                    contentActor.HorizontalAlignment = HorizontalAlignment.Center;
                    contentActor.SetPadding(new PaddingType(0, 0, 20, 0));

                    mVersionPopup.SetTitle(titleActor);
                    mVersionPopup.SetContent(contentActor);

                    mVersionPopup.WidthResizePolicy = ResizePolicyType.SizeRelativeToParent;
                    mVersionPopup.SetSizeModeFactor(new Vector3(0.75f, 1.0f, 1.0f));
                    mVersionPopup.HeightResizePolicy = ResizePolicyType.FitToChildren;

                    mVersionPopup.TouchedOutside += HideVersionPopup;
                    Window.Instance.Add(mVersionPopup);
                }

                mVersionPopup.SetDisplayState(Tizen.NUI.UIComponents.Popup.DisplayStateType.Shown);
            }
        }

        private void HideVersionPopup(object sender, Tizen.NUI.UIComponents.Popup.TouchedOutsideEventArgs e)
        {
            // Only hide if currently fully shown. If transitioning-in, the transition will not be interrupted.
            if (null != mVersionPopup && (mVersionPopup.DisplayState == Tizen.NUI.UIComponents.Popup.DisplayStateType.Shown))
            {
                mVersionPopup.SetDisplayState(Tizen.NUI.UIComponents.Popup.DisplayStateType.Hidden);
            }
        }

        /**
         * Creates the background image
         */
        private View CreateBackground(string stylename)
        {
            View background = new View();
            Window.Instance.Add(background);
            background.SetStyleName(stylename);
            background.Name = "BACKGROUND";
            background.PositionUsesPivotPoint = true;
            background.PivotPoint = PivotPoint.Center;
            background.ParentOrigin = ParentOrigin.Center;
            background.WidthResizePolicy = ResizePolicyType.FillToParent;
            background.HeightResizePolicy = ResizePolicyType.FillToParent;
            return background;
        }

        private View CreateTile(string name, string title, Vector3 sizeMultiplier, Vector2 position)
        {
            ImageView focusableTile = new ImageView();

            focusableTile.SetStyleName("DemoTile");
            focusableTile.ResourceUrl = CommonResource.GetDaliResourcePath() + "DaliDemo/demo-tile-texture.9.png";
            focusableTile.PositionUsesPivotPoint = true;
            focusableTile.ParentOrigin = ParentOrigin.Center;
            focusableTile.WidthResizePolicy = focusableTile.HeightResizePolicy = ResizePolicyType.SizeRelativeToParent;
            focusableTile.SetSizeModeFactor(sizeMultiplier);
            focusableTile.Name = name;

            // Set the tile to be keyboard focusable
            focusableTile.Focusable = true;

            // Register a property with the ImageView. This allows us to inject the scroll-view position into the shader.
            PropertyValue value = new PropertyValue(new Vector3(0.0f, 0.0f, 0.0f));
            int propertyIndex = focusableTile.RegisterProperty("uCustomPosition", value);

            // We create a constraint to perform a precalculation on the scroll-view X offset
            // and pass it to the shader uniform, along with the tile's position.
            //Constraint shaderPosition = Constraint::New<Vector3>(focusableTile, propertyIndex, TileShaderPositionConstraint(mPageWidth, position.x));
            //shaderPosition.AddSource(Source(mScrollView, ScrollView::Property::SCROLL_POSITION) );
            //shaderPosition.SetRemoveAction(Constraint::Discard );
            //shaderPosition.Apply();
            //focusableTile.Add( tileContent );

            // Create an ImageView for the 9-patch border around the tile.
            ImageView borderImage = new ImageView();
            borderImage.SetStyleName("DemoTileBorder");
            borderImage.ResourceUrl = CommonResource.GetDaliResourcePath() + "DaliDemo/item-background.9.png";
            borderImage.PositionUsesPivotPoint = true;
            borderImage.PivotPoint = PivotPoint.Center;
            borderImage.ParentOrigin = ParentOrigin.Center;
            borderImage.WidthResizePolicy = borderImage.HeightResizePolicy = ResizePolicyType.FillToParent;
            borderImage.Opacity = 0.8f;
            focusableTile.Add(borderImage);

            TextLabel label = new TextLabel();
            label.PositionUsesPivotPoint = true;
            label.PivotPoint = PivotPoint.Center;
            label.ParentOrigin = ParentOrigin.Center;
            label.SetStyleName("LauncherLabel");
            label.MultiLine = true;
            label.Text = title;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.HeightResizePolicy = ResizePolicyType.FillToParent;

            // Pad around the label as its size is the same as the 9-patch border. It will overlap it without padding.
            label.SetPadding(new PaddingType((int)TILE_LABEL_PADDING, (int)TILE_LABEL_PADDING, (int)TILE_LABEL_PADDING, (int)TILE_LABEL_PADDING));
            focusableTile.Add(label);

            // Connect to the touch events
            focusableTile.TouchEvent += OnTilePressed;
            //focusableTile.HoverEvent += OnTileHovered;

            return focusableTile;
        }

        private bool DoTilePress(View actor, PointStateType pointState)
        {
            bool consumed = false;

            if (PointStateType.Down == pointState)
            {
                mPressedActor = actor;
                consumed = true;
            }

            // A button press is only valid if the Down & Up events
            // both occurred within the button.
            if ((PointStateType.Up == pointState) &&
                (mPressedActor == actor))
            {
                // ignore Example button presses when scrolling or button animating.
                if ((!mScrolling) && (!mPressedAnimation))
                {
                    string name = actor.Name;
                    foreach (Example example in mExampleList)
                    {
                        if (example.Name == name)
                        {
                            consumed = true;
                            break;
                        }
                    }
                }

                if (consumed)
                {
                    mPressedAnimation = new Animation((int)(BUTTON_PRESS_ANIMATION_TIME * 1000.0));
                    mPressedAnimation.EndAction = Animation.EndActions.Discard;

                    // scale the content actor within the Tile, as to not affect the placement within the Table.
                    View content = actor.GetChildAt(0);
                    mPressedAnimation.AnimateTo(content, "Scale", new Vector3(0.7f, 0.7f, 1.0f), 0, (int)((BUTTON_PRESS_ANIMATION_TIME * 0.5f) * 1000.0), new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut));
                    mPressedAnimation.AnimateTo(content, "Scale", Vector3.One, (int)((BUTTON_PRESS_ANIMATION_TIME * 0.5f) * 1000.0), (int)((BUTTON_PRESS_ANIMATION_TIME * 0.5f) * 1000.0), new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut));
                    mPressedAnimation.AnimateTo(content, "Orientation", new Rotation(new Radian(new Degree(180)), new Vector3(0, 1, 0)));
                    mPressedAnimation.Play();
                    mPressedAnimation.Finished += OnPressedAnimationFinished;
                }
            }
            return consumed;
        }

        private void OnPressedAnimationFinished(object sender, EventArgs e)
        {
            string name = mPressedActor?.Name;

            mPressedAnimation = null;
            mPressedActor = null;

            onClicked(name);
        }

        private bool OnTilePressed(object source, View.TouchEventArgs e)
        {
            return DoTilePress(source as View, e.Touch.GetState(0));
        }

        private List<View> tiles = new List<View>();

        private void Populate()
        {
            Vector2 stageSize = Window.Instance.WindowSize;

            mTotalPages = (uint)((mExampleList.Count() + EXAMPLES_PER_PAGE - 1) / EXAMPLES_PER_PAGE);

            // Populate ScrollView.
            if (mExampleList.Count() > 0)
            {
                if (mSortAlphabetically)
                {
                    mExampleList.Sort(Example.CompareByTitle);
                }

                int pageCount = mExampleList.Count / (ROWS_PER_PAGE * EXAMPLES_PER_ROW) + ((0 == mExampleList.Count % (ROWS_PER_PAGE * EXAMPLES_PER_ROW)) ? 0 : 1);
                mPages = new View[pageCount];

                int pageIndex = 0;

                uint exampleCount = 0;

                for (int t = 0; t < mTotalPages; t++)
                {
                    // Create Table
                    TableView page = new TableView(ROWS_PER_PAGE, EXAMPLES_PER_ROW);
                    page.PositionUsesPivotPoint = true;
                    page.PivotPoint = PivotPoint.Center;
                    page.ParentOrigin = ParentOrigin.Center;
                    page.WidthResizePolicy = page.HeightResizePolicy = ResizePolicyType.FillToParent;
                    mScrollView.Add(page);

                    // Calculate the number of images going across (columns) within a page, according to the screen resolution and dpi.
                    const float margin = 2.0f;
                    const float tileParentMultiplier = 1.0f / EXAMPLES_PER_ROW;

                    for (uint row = 0; row < ROWS_PER_PAGE; row++)
                    {
                        for (uint column = 0; column < EXAMPLES_PER_ROW; column++)
                        {
                            Example example = mExampleList.ElementAt((int)exampleCount++);

                            // Calculate the tiles relative position on the page (between 0 & 1 in each dimension).
                            Vector2 position = new Vector2((float)(column) / (EXAMPLES_PER_ROW - 1.0f), (float)(row) / (EXAMPLES_PER_ROW - 1.0f));
                            View tile = CreateTile(example.Name, example.Title, new Vector3(tileParentMultiplier, tileParentMultiplier, 1.0f), position);

                            tile.SetPadding(new PaddingType((int)margin, (int)margin, (int)margin, (int)margin));
                            page.AddChild(tile, new TableView.CellPosition(row, column));
                            //page.Add(tile);

                            tiles.Add(tile);

                            if (exampleCount == mExampleList.Count)
                            {
                                break;
                            }
                        }

                        if (exampleCount == mExampleList.Count)
                        {
                            break;
                        }
                    }

                    mPages[pageIndex++] = page;

                    if (exampleCount == mExampleList.Count)
                    {
                        break;
                    }
                }
            }

            // Update Ruler info.
            mScrollRulerX = new RulerPtr(new FixedRuler(mPageWidth));
            mScrollRulerY = new RulerPtr(new DefaultRuler());
            mScrollRulerX.SetDomain(new RulerDomain(0.0f, (mTotalPages + 1) * stageSize.Width * TABLE_RELATIVE_SIZE.X * 0.5f, true));
            mScrollRulerY.Disable();
            mScrollView.SetRulerX(mScrollRulerX);
            mScrollView.SetRulerY(mScrollRulerY);
        }

        private void SetupBackground(View bubbleContainer)
        {
            // Add bubbles to the bubbleContainer.
            // Note: The bubbleContainer is parented externally to this function.
            AddBackgroundActors(bubbleContainer, NUM_BACKGROUND_IMAGES);
        }

        private void AddBackgroundActors(View layer, int count)
        {
            int shapeType = 0;
            Random sizeRandom = new Random(DateTime.Now.Millisecond);
            Random shapeRandom = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < count; ++i)
            {
                int randSize = sizeRandom.Next(10, 400);
                shapeType = shapeRandom.Next(0, NUMBER_OF_SHAPE_IMAGES);
                //shapeType = (shapeType + 1) % 2;

                Console.WriteLine("randSize is {0}, shapeType is {1}", randSize, shapeType);

                ImageView dfActor = new ImageView();
                dfActor.Size2D = new Vector2(randSize, randSize);
                dfActor.PositionUsesPivotPoint = true;
                dfActor.ParentOrigin = ParentOrigin.Center;

                // Set the Image URL and the custom shader at the same time
                PropertyMap effect = CreateDistanceFieldEffect();
                PropertyMap imageMap = new PropertyMap();
                imageMap.Insert(ImageVisualProperty.URL, new PropertyValue(SHAPE_IMAGE_TABLE[shapeType]));
                imageMap.Insert(Visual.Property.Shader, new PropertyValue(effect));
                imageMap.Insert(Visual.Property.MixColor, new PropertyValue(BUBBLE_COLOR[i % NUMBER_OF_BUBBLE_COLOR]));
                dfActor.ImageMap = imageMap;

                layer.Add(dfActor);
            }

            // Positioning will occur when the layer is relaid out
            layer.Relayout += InitialiseBackgroundActors;
        }

        private void InitialiseBackgroundActors(object sender, EventArgs e)
        {
            // Delete current animations
            mBackgroundAnimations.Clear();
            View actor = sender as View;

            // Create new animations
            Size2D size = actor.Size2D;

            Random childPosRandom = new Random(DateTime.Now.Millisecond);
            Random animationDurationRandom = new Random(DateTime.Now.Millisecond);

            for (uint i = 0, childCount = actor.GetChildCount(); i < childCount; ++i)
            {
                View child = actor.GetChildAt(i);

                // Calculate a random position
                Vector3 childPos = new Vector3(childPosRandom.Next((int)(-size.Width * 0.5f * BACKGROUND_SPREAD_SCALE), (int)(size.Width * 0.85f * BACKGROUND_SPREAD_SCALE)),
                                               childPosRandom.Next((int)(-size.Height), (int)(size.Height)),
                                               childPosRandom.Next((int)BUBBLE_MIN_Z, (int)BUBBLE_MAX_Z));

                child.Position = childPos;

                // Define bubble horizontal parallax and vertical wrapping
                //Constraint animConstraint = Constraint::New<Vector3>(child, Actor::Property::POSITION, AnimateBubbleConstraint(childPos, Random::Range(-0.85f, 0.25f)));
                //animConstraint.AddSource(Source(mScrollView, ScrollView::Property::SCROLL_POSITION));
                //animConstraint.AddSource(Dali::ParentSource(Dali::Actor::Property::SIZE));
                //animConstraint.AddSource(Dali::LocalSource(Dali::Actor::Property::SIZE));
                //animConstraint.SetRemoveAction(Constraint::Discard);
                //animConstraint.Apply();

                // Kickoff animation
                Animation animation = new Animation(animationDurationRandom.Next(30, 160) * 1000);
                animation.AnimateBy(child, "Position", new Vector3(0.0f, -2000.0f, 0.0f), new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
                animation.Looping = true;
                animation.Play();
                mBackgroundAnimations.Add(animation);
            }
        }

        private PropertyMap CreateDistanceFieldEffect()
        {
            string fragmentShaderPrefix = "#extension GL_OES_standard_derivatives : enable\n";

            string fragmentShader = "varying mediump vec2 vTexCoord;\n" +
      "\n" +
      "uniform mediump float uGlowBoundary;\n" +
      "uniform mediump vec2  uOutlineParams;\n" +
      "uniform lowp vec4  uOutlineColor;\n" +
   "uniform lowp vec4  uShadowColor;\n" +
"uniform mediump vec2  uShadowOffset;\n" +
"uniform lowp vec4  uGlowColor;\n" +
"uniform lowp    float uDoOutline;\n" +
"uniform lowp    float uDoShadow;\n" +
"uniform lowp    float uDoGlow;\n" +
      "\n" +
      "uniform sampler2D sTexture;\n" +
      "uniform lowp vec4 uColor;\n" +
      "\n" +
      "void main()\n" +
      "{\n" +
                "// sample distance field\n" +
                "mediump float smoothing = 0.5;\n" +

                "mediump float distance = texture2D(sTexture, vTexCoord).a;\n" +
                "mediump float smoothWidth = fwidth(distance);\n" +
                "mediump float alphaFactor = smoothstep(smoothing - smoothWidth, smoothing + smoothWidth, distance);\n" +
                "lowp    vec4 color;\n" +
        "if (uDoShadow == 0.0)\n" +
        "{\n" +
                    "mediump float alpha = uColor.a * alphaFactor;\n" +
                    "lowp    vec4 rgb = uColor;\n" +
          "\n" +
          "if (uDoOutline > 0.0)\n" +
          "{\n" +
                        "mediump float outlineWidth = uOutlineParams[1] + smoothWidth;\n" +
                        "mediump float outlineBlend = smoothstep(uOutlineParams[0] - outlineWidth, uOutlineParams[0] + outlineWidth, distance);\n" +
                        "alpha = smoothstep(smoothing - smoothWidth, smoothing + smoothWidth, distance);\n" +
                        "rgb = mix(uOutlineColor, uColor, outlineBlend);\n" +
          "}\n" +
          "\n" +
          "if (uDoGlow > 0.0)\n" +
          "{\n" +
                        "rgb = mix(uGlowColor, rgb, alphaFactor);\n" +
                        "alpha = smoothstep(uGlowBoundary, smoothing, distance);\n" +
          "}\n" +
          "\n" +
          "// set fragment color\n" +
          "color = vec4(rgb.rgb, alpha);\n" +
        "}\n" +
        "\n" +
        "else // (uDoShadow > 0.0)\n" +
        "{\n" +
                    "mediump float shadowDistance = texture2D(sTexture, vTexCoord - uShadowOffset).a;\n" +
                    "mediump float inText = alphaFactor;\n" +
                    "mediump float inShadow = smoothstep(smoothing - smoothWidth, smoothing + smoothWidth, shadowDistance);\n" +
          "\n" +
          "// inside object, outside shadow\n" +
          "if (inText == 1.0)\n" +
          "{\n" +
                        "color = uColor;\n" +
          "}\n" +
          "// inside object, outside shadow\n" +
          "else if ((inText != 0.0) && (inShadow == 0.0))\n" +
          "{\n" +
                        "color = uColor;\n" +
            "color.a *= inText;\n" +
          "}\n" +
          "// outside object, completely inside shadow\n" +
          "else if ((inText == 0.0) && (inShadow == 1.0))\n" +
          "{\n" +
                        "color = uShadowColor;\n" +
          "}\n" +
          "// inside object, completely inside shadow\n" +
          "else if ((inText != 0.0) && (inShadow == 1.0))\n" +
          "{\n" +
                        "color = mix(uShadowColor, uColor, inText);\n" +
            "color.a = uShadowColor.a;\n" +
          "}\n" +
          "// inside object, inside shadow's border\n" +
          "else if ((inText != 0.0) && (inShadow != 0.0))\n" +
          "{\n" +
                        "color = mix(uShadowColor, uColor, inText);\n" +
            "color.a *= max(inText, inShadow);\n" +
          "}\n" +
          "// inside shadow's border\n" +
          "else if (inShadow != 0.0)\n" +
          "{\n" +
                        "color = uShadowColor;\n" +
            "color.a *= inShadow;\n" +
          "}\n" +
          "// outside shadow and object\n" +
          "else \n" +
          "{\n" +
            "color.a = 0.0;\n" +
          "}\n" +
          "\n" +
        "}\n" +
        "\n" +
        "gl_FragColor = color;\n" +
        "\n" +
      "}";

            PropertyMap map = new PropertyMap();

            PropertyMap customShader = new PropertyMap();

            string fragmentShaderString;
            fragmentShaderString = fragmentShaderPrefix + fragmentShader;

            customShader.Insert(Visual.ShaderProperty.FragmentShader, new PropertyValue(fragmentShaderString));
            customShader.Insert(Visual.ShaderProperty.ShaderHints, new PropertyValue((int)Shader.Hint.Value.OUTPUT_IS_TRANSPARENT));

            map.Insert(Visual.Property.Shader, new PropertyValue(customShader));
            return map;
        }

        private void ApplyScrollViewEffect()
        {
            // Remove old effect if exists.

            if (mScrollViewEffect)
            {
                mScrollView.RemoveEffect(mScrollViewEffect);
            }

            // Just one effect for now
            SetupInnerPageCubeEffect();

            mScrollView.ApplyEffect(mScrollViewEffect);
        }

        private void SetupInnerPageCubeEffect()
        {
            Vector2 stageSize = Window.Instance.WindowSize;

            Path path = new Path();
            PropertyArray points = new PropertyArray();
            points.PushBack(new PropertyValue(new Vector3(stageSize.X * 0.5f, 0.0f, stageSize.X * 0.5f)));
            points.PushBack(new PropertyValue(new Vector3(0.0f, 0.0f, 0.0f)));
            points.PushBack(new PropertyValue(new Vector3(-stageSize.X * 0.5f, 0.0f, stageSize.X * 0.5f)));
            path.Points = points;

            PropertyArray controlPoints = new PropertyArray();
            controlPoints.PushBack(new PropertyValue(new Vector3(stageSize.X * 0.5f, 0.0f, stageSize.X * 0.3f)));
            controlPoints.PushBack(new PropertyValue(new Vector3(stageSize.X * 0.3f, 0.0f, 0.0f)));
            controlPoints.PushBack(new PropertyValue(new Vector3(-stageSize.X * 0.3f, 0.0f, 0.0f)));
            controlPoints.PushBack(new PropertyValue(new Vector3(-stageSize.X * 0.5f, 0.0f, stageSize.X * 0.3f)));
            path.ControlPoints = controlPoints;

            mScrollViewEffect = new ScrollViewPagePathEffect(path,
                                                             new Vector3(-1.0f, 0.0f, 0.0f),
                                                             ScrollView.Property.SCROLL_FINAL_X,
                                                             new Vector3(stageSize.X * TABLE_RELATIVE_SIZE.X, stageSize.Y * TABLE_RELATIVE_SIZE.Y, 0.0f), mTotalPages);
        }

        void ApplyCubeEffectToPages()
        {
            uint pageCount = 0;

            for (int i = 0; i < mPages.Count(); i++)
            {
                View page = mPages[i];
                mScrollViewEffect.ApplyToPage(page, pageCount++);
            }
        }

        void Rotate(uint degrees)
        {
            // Resize the root actor
            Vector2 stageSize = Window.Instance.WindowSize;
            Vector3 targetSize = new Vector3(stageSize.X, stageSize.Y, 1.0f);

            if (degrees == 90 || degrees == 270)
            {
                targetSize = new Vector3(stageSize.Y, stageSize.X, 1.0f);
            }

            if (mRotateAnimation)
            {
                mRotateAnimation.Stop();
                mRotateAnimation.Clear();
            }

            mRotateAnimation = new Animation((int)(ROTATE_ANIMATION_TIME * 1000.0));
            mRotateAnimation.AnimateTo(mRootActor, "Orientation", new Rotation(new Radian(new Degree(360 - degrees)), new Vector3(0, 0, 1)), new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut));
            mRotateAnimation.AnimateTo(mRootActor, "Size", targetSize, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut));
            mRotateAnimation.Play();
        }

        internal View mRootActor;                ///< All content (excluding background is anchored to this Actor)
        private Animation mRotateAnimation;          ///< Animation to rotate and resize mRootActor.
        private Animation mPressedAnimation;         ///< Button press scaling animation.
        private ScrollView mScrollView;               ///< ScrollView container (for all Examples)
        private ScrollViewPagePathEffect mScrollViewEffect;         ///< Effect to be applied to the scroll view
        private RulerPtr mScrollRulerX;             ///< ScrollView X (horizontal) ruler
        private RulerPtr mScrollRulerY;             ///< ScrollView Y (vertical) ruler
        private View mPressedActor;             ///< The currently pressed actor.
        private Timer mAnimationTimer;           ///< Timer used to turn off animation after a specific time period
        private TapGestureDetector mLogoTapDetector;          ///< To detect taps on the logo
        private Tizen.NUI.UIComponents.Popup mVersionPopup;             ///< Displays DALi library version information

        /**
   * This struct encapsulates all data relevant to each of the elements used within the custom keyboard focus effect.
   */
        private struct FocusEffect
        {
            public ImageView actor;                   ///< The parent keyboard focus highlight actor
            public Animation animation;               ///< The animation for the parent keyboard focus highlight actor
        };
        FocusEffect[] mFocusEffect = new FocusEffect[FOCUS_ANIMATION_ACTOR_NUMBER];    ///< The elements used to create the custom focus effect

        private View[] mPages;                    ///< List of pages.
        private List<Animation> mBackgroundAnimations = new List<Animation>();     ///< List of background bubble animations
        private List<Example> mExampleList = new List<Example>();              ///< List of examples.

        private float mPageWidth;                ///< The width of a page within the scroll-view, used to calculate the domain
        private uint mTotalPages;               ///< Total pages within scrollview.

        private bool mScrolling;              ///< Flag indicating whether view is currently being scrolled
        private bool mSortAlphabetically;     ///< Sort examples alphabetically.
        private bool mBackgroundAnimsPlaying; ///< Are background animations playing
    }
}
