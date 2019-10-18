using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.FamilyBoard
{
    public class FrameStyleChooser : IViewLifecycle
    {
        private View mRootView;

        // close
        private View mCloseView;
        private ImageView mCloseImageView;
        private TapGestureDetector mCloseAreaTapGestureDetector;

        // back, title, done
        private View mTitleRootView;
        private View mTitleView;
        private TextLabel mTitleLabel;
        private Button mBackButton;
        private Button mDoneButton;

        // preview
        private View mPreviewRootView;
        private ImageView[] mPreviewImageViews;
        private ImageView[] mPreviewFrameStyleImageViews;
        private int mCurrentPreviewIndex;
        private PanGestureDetector mPreviewPanGestureDetector;
        private int mLastPreviewPositionX;

        // frame style grid
        private View mFrameStyleRootView;
        private FlexibleView mFrameStyleGrid;
        private FrameStyleGridBridge mFrameStyleBridge;
        private FlexibleView.ViewHolder mLastCheckedFrameStyle;

        //
        private Rectangle[] mFrameBorders = { new Rectangle(0, 0, 0, 0),
                                        new Rectangle(0, 0, 0, 0),
                                        new Rectangle(0, 0, 0, 0),
                                        new Rectangle(7, 7, 7, 7),
                                        new Rectangle(14, 14, 14, 14),
                                        new Rectangle(10, 10, 10, 81),
                                        new Rectangle(21, 21, 21, 21),
                                        new Rectangle(21, 21, 21, 21)};

        private readonly int SCREEN_WIDTH = 1080;
        private readonly int SCREEN_HEIGHT = 1920;

        //
        private static string FB_PICTURE_DIR = CommonResource.GetResourcePath() + "picker/";
        private static string FB_PICTURE_CLOSE_IMAGE = FB_PICTURE_DIR + "familyboard_ic_delete.png";
        private static string FB_PICTURE_BACK_BUTTON_IMAGE = FB_PICTURE_DIR + "familyboard_gallery_ic_back.png";
        private static string FB_PICTURE_DONE_BUTTON_IMAGE = FB_PICTURE_DIR + "familyboard_photo_drawer_btn.png";
        private static string FB_PICTURE_FRAME_PICTURE_IMAGE = FB_PICTURE_DIR + "familyboard_photo_frame_picture.png";
        private static string FB_PICTURE_FRAME_FRAME1_IMAGE = FB_PICTURE_DIR + "familyboard_photo_frame_01.png";
        private static string FB_PICTURE_FRAME_FRAME2_IMAGE = FB_PICTURE_DIR + "familyboard_photo_frame_02.png";
        private static string FB_PICTURE_FRAME_FRAME3_IMAGE = FB_PICTURE_DIR + "familyboard_photo_frame_03.png";
        private static string FB_PICTURE_FRAME_FRAME4_IMAGE = FB_PICTURE_DIR + "familyboard_photo_frame_04.png";
        private static string FB_PICTURE_FRAME_FRAME5_IMAGE = FB_PICTURE_DIR + "familyboard_photo_frame_05.png";
        private static string FB_PICTURE_FRAME_FRAME6_IMAGE = FB_PICTURE_DIR + "familyboard_photo_frame_06.png";
        private static string FB_PICTURE_FRAME_FRAME7_IMAGE = FB_PICTURE_DIR + "familyboard_photo_frame_07.png";
        private static string FB_PICTURE_FRAME_FRAME8_IMAGE = FB_PICTURE_DIR + "familyboard_photo_frame_08.png";

        public void Activate()
        {
            mRootView = new View();
            mRootView.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.7f);
            mRootView.Size2D = new Size2D(SCREEN_WIDTH, SCREEN_HEIGHT);
            mRootView.ClippingMode = ClippingModeType.ClipToBoundingBox;
            Window.Instance.GetDefaultLayer().Add(mRootView);

            CreateCloseButton();

            // picture
            CreateBackTitleNext();

            CreatePreview();

            CreateFrameStyleGrid();
        }

        public void Reactivate()
        {
            DestroyPreview();
            CreatePreview();
            mCloseAreaTapGestureDetector.Attach(mCloseView);
        }

        public void Deactivate()
        {
            if (mFrameStyleGrid != null)
            {
                mFrameStyleRootView.Remove(mFrameStyleGrid);
                mFrameStyleGrid.Dispose();
                mFrameStyleGrid = null;
            }

            if (mFrameStyleRootView != null)
            {
                mRootView.Remove(mFrameStyleRootView);
                mFrameStyleRootView.Dispose();
                mFrameStyleRootView = null;
            }

            if (mTitleLabel != null)
            {
                mTitleView.Remove(mTitleLabel);
                mTitleLabel.Dispose();
                mTitleLabel = null;
            }

            if (mTitleView != null)
            {
                mTitleRootView.Remove(mTitleView);
                mTitleView.Dispose();
                mTitleView = null;
            }

            if (mDoneButton != null)
            {
                mTitleRootView.Remove(mDoneButton);
                mDoneButton.Dispose();
                mDoneButton = null;
            }

            if (mBackButton != null)
            {
                mTitleRootView.Remove(mBackButton);
                mBackButton.Dispose();
                mBackButton = null;
            }

            if (mTitleRootView != null)
            {
                mRootView.Remove(mTitleRootView);
                mTitleRootView.Dispose();
                mTitleRootView = null;
            }

            if (mCloseAreaTapGestureDetector != null)
            {
                mCloseAreaTapGestureDetector.Detected -= OnTapGestureDetected;
                mCloseAreaTapGestureDetector.Detach(mCloseView);
                mCloseAreaTapGestureDetector.Dispose();
                mCloseAreaTapGestureDetector = null;
            }

            if (mCloseImageView != null)
            {
                mCloseView.Remove(mCloseImageView);
                mCloseImageView.Dispose();
                mCloseImageView = null;
            }

            if (mCloseView != null)
            {
                mRootView.Remove(mCloseView);
                mCloseView.Dispose();
                mCloseView = null;
            }

            if (mRootView != null)
            {
                Window.Instance.GetDefaultLayer().Remove(mRootView);
                mRootView.Dispose();
                mRootView = null;
            }
        }

        public View GetRootView()
        {
            return mRootView;
        }

        public void ChooseFrameStyle(int position, string style)
        {
            int imageCount = ImageManager.Instance.ImageCount();
            for (int i = 0; i < imageCount; i++)
            {
                //NPatchVisual patchVisual = new NPatchVisual();
                //patchVisual.URL = style;
                //patchVisual.Border = mFrameBorders[position];
                //mPreviewFrameStyleImageViews[i].Background = patchVisual.OutputVisualMap;
                //mPreviewFrameStyleImageViews[i].Show();
                ImageManager.Instance.SetFrameStyle(i, style);
            }
        }

        private void CreateCloseButton()
        {
            // close
            mCloseView = new View();
            mCloseView.Position2D = new Position2D(0, 0);
            mCloseView.Size2D = new Size2D(SCREEN_WIDTH, 405);
            mRootView.Add(mCloseView);

            mCloseImageView = new ImageView();
            mCloseImageView.ResourceUrl = FB_PICTURE_CLOSE_IMAGE;
            mCloseImageView.Position2D = new Position2D(SCREEN_WIDTH - 40 - 41, 405 - 22 - 40);
            mCloseImageView.Size2D = new Size2D(40, 40);
            mCloseView.Add(mCloseImageView);

            mCloseAreaTapGestureDetector = new TapGestureDetector();
            mCloseAreaTapGestureDetector.Attach(mCloseView);
            mCloseAreaTapGestureDetector.Detected += OnTapGestureDetected;
        }

        private void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            ImageManager.Instance.RemoveAllImages();
            FamilyBoardApplication.Instance.RemoveView();
        }

        private void CreateBackTitleNext()
        {
            mTitleRootView = new View();
            mTitleRootView.Position2D = new Position2D(0, 405);
            mTitleRootView.Size2D = new Size2D(SCREEN_WIDTH, 164);
            mTitleRootView.BackgroundColor = new Color(0.2f, 0.2f, 0.2f, 1.0f);
            mRootView.Add(mTitleRootView);

            // back button
            mBackButton = new Button();
            mBackButton.BackgroundImage = FB_PICTURE_BACK_BUTTON_IMAGE;
            mBackButton.Position2D = new Position2D(24, 77);
            mBackButton.Size2D = new Size2D(46, 46);
            mTitleRootView.Add(mBackButton);

            mBackButton.ClickEvent += OnBackButtonClickEvent;

            // title
            mTitleView = new View();
            mTitleView.Position2D = new Position2D();
            mTitleView.Size2D = new Size2D(SCREEN_WIDTH, 177);
            mTitleRootView.Add(mTitleView);

            mTitleLabel = new TextLabel();
            mTitleLabel.Text = "Choose Frame Style";
            mTitleLabel.FontFamily = "SamsungOneUI 600";
            mTitleLabel.PointSize = 30;
            mTitleLabel.TextColor = new Color(1.0f, 1.0f, 1.0f, 0.8f);
            mTitleLabel.PositionUsesPivotPoint = true;
            mTitleLabel.PivotPoint = PivotPoint.Center;
            mTitleLabel.ParentOrigin = ParentOrigin.Center;
            mTitleLabel.HorizontalAlignment = HorizontalAlignment.Center;
            mTitleLabel.VerticalAlignment = VerticalAlignment.Center;
            mTitleView.Add(mTitleLabel);

            // done button
            mDoneButton = new Button();
            mDoneButton.BackgroundImage = FB_PICTURE_DONE_BUTTON_IMAGE;
            mDoneButton.Text = "Done";
            mDoneButton.TextColor = Color.White;
            mDoneButton.PointSize = 30;
            mDoneButton.FontFamily = "SamsungOneUI 500";
            mDoneButton.Position2D = new Position2D(SCREEN_WIDTH - 151 - 40 - 46, (177 - 70) / 2);
            mDoneButton.Size2D = new Size2D(151 + 40, 60 + 10);
            mTitleRootView.Add(mDoneButton);

            mDoneButton.ClickEvent += OnDoneButtonClickEvent;
        }

        private void CreatePreview()
        {
            int imageCount = ImageManager.Instance.ImageCount();

            mPreviewRootView = new View();
            mPreviewRootView.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.85f);
            mPreviewRootView.Position2D = new Position2D(0, 405 + 164 - 300);
            mPreviewRootView.Size2D = new Size2D((SCREEN_WIDTH - 540) + (540 + 60) * imageCount - 60, 610);
            mRootView.Add(mPreviewRootView);

            mPreviewPanGestureDetector = new PanGestureDetector();
            mPreviewPanGestureDetector.Attach(mPreviewRootView);
            mPreviewPanGestureDetector.Detected += OnPreviewTapGestureDetected;

            mCurrentPreviewIndex = 0;

            mPreviewFrameStyleImageViews = new ImageView[imageCount];
            for (int i = 0; i < imageCount; i++)
            {
                mPreviewFrameStyleImageViews[i] = new ImageView();
                float opacity = 0.5f;
                if (i == mCurrentPreviewIndex)
                {
                    opacity = 1.0f;
                }
                mPreviewFrameStyleImageViews[i].Opacity = opacity;

                //
                mPreviewFrameStyleImageViews[i].Position2D = new Position2D((SCREEN_WIDTH - 540) / 2 + i * (540 + 60), (610 - 540) / 2);
                mPreviewFrameStyleImageViews[i].Size2D = new Size2D(540, 540);
                //mPreviewRootView.Add(mPreviewFrameStyleImageViews[i]);
                mPreviewFrameStyleImageViews[i].Hide();
            }

            mPreviewImageViews = new ImageView[imageCount];

            for (int i = 0; i < imageCount; i++)
            {
                mPreviewImageViews[i] = new ImageView();
                float opacity = 0.5f;
                if (i == mCurrentPreviewIndex)
                {
                    opacity = 1.0f;
                }
                mPreviewImageViews[i].Opacity = opacity;

                //
                ImageVisual imageVisual = new ImageVisual()
                {
                    URL = ImageManager.Instance.GetImageFile(i),
                    VisualFittingMode = VisualFittingModeType.FitKeepAspectRatio,
                };
                mPreviewImageViews[i].Image = imageVisual.OutputVisualMap;
                mPreviewImageViews[i].Position2D = new Position2D((SCREEN_WIDTH - 540) / 2 + i * (540 + 60), (610 - 540) / 2);
                mPreviewImageViews[i].Size2D = new Size2D(540, 540);
                mPreviewRootView.Add(mPreviewImageViews[i]);
            }
        }

        private void OnPreviewTapGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            switch (e.PanGesture.State)
            {
                case Gesture.StateType.Started:
                    {
                        mLastPreviewPositionX = (int)mPreviewRootView.PositionX;
                        break;
                    }

                case Gesture.StateType.Continuing:
                    {
                        mPreviewRootView.PositionX += (int)e.PanGesture.Displacement.X;
                        break;
                    }
                case Gesture.StateType.Finished:
                    {
                        int imageCount = ImageManager.Instance.ImageCount();
                        mPreviewRootView.PositionX += (int)e.PanGesture.Displacement.X;
                        float deltaX = mPreviewRootView.PositionX - mLastPreviewPositionX;
                        if (Math.Abs(deltaX) < 200 / 2)
                        {
                            mPreviewRootView.PositionX = mLastPreviewPositionX;
                        }
                        else
                        {
                            if (deltaX < 0)
                            {
                                mCurrentPreviewIndex++;
                                if (mCurrentPreviewIndex >= imageCount)
                                {
                                    mPreviewRootView.PositionX = mLastPreviewPositionX;
                                    mCurrentPreviewIndex = imageCount - 1;
                                }
                                else
                                {
                                    mPreviewRootView.PositionX = mLastPreviewPositionX - (540 + 60);
                                }
                            }
                            else
                            {
                                mCurrentPreviewIndex--;
                                if (mCurrentPreviewIndex < 0)
                                {
                                    mPreviewRootView.PositionX = mLastPreviewPositionX;
                                    mCurrentPreviewIndex = 0;
                                }
                                else
                                {
                                    mPreviewRootView.PositionX = mLastPreviewPositionX + (540 + 60);
                                }
                            }
                        }

                        // update opacity.
                        for (int i = 0; i < imageCount; i++)
                        {
                            if (i == mCurrentPreviewIndex)
                            {
                                mPreviewImageViews[i].Opacity = 1.0f;
                            }
                            else
                            {
                                mPreviewImageViews[i].Opacity = 0.5f;
                            }
                        }
                        break;
                    }
            }
        }

        private void DestroyPreview()
        {
            mCurrentPreviewIndex = 0;

            for(int i = 0; i < mPreviewImageViews.Length; i++)
            {
                mPreviewRootView.Remove(mPreviewImageViews[i]);
                mPreviewImageViews[i].Dispose();
                mPreviewImageViews[i] = null;
            }
            mPreviewImageViews = null;

            if (mPreviewRootView != null)
            {
                mRootView.Remove(mPreviewRootView);
                mPreviewRootView.Dispose();
                mPreviewRootView = null;
            }
        }

        private void CreateFrameStyleGrid()
        {
            mFrameStyleRootView = new View();
            mFrameStyleRootView.Position2D = new Position2D(0, 405 + 610 + 164 - 400);
            mFrameStyleRootView.Size2D = new Size2D(SCREEN_WIDTH, SCREEN_HEIGHT - 405 - 610 - 164);
            mFrameStyleRootView.BackgroundColor = new Color(0.2f, 0.2f, 0.2f, 1.0f);
            mRootView.Add(mFrameStyleRootView);

            // grid
            mFrameStyleGrid = new FlexibleView();
            mFrameStyleGrid.Name = "Frame Style Grid";
            mFrameStyleGrid.Position2D = new Position2D(0, 164);
            mFrameStyleGrid.Size2D = new Size2D(SCREEN_WIDTH, SCREEN_HEIGHT - 405 - 164);
            mFrameStyleGrid.Padding = new Extents(54, 54, 0, 0);
            mFrameStyleGrid.ItemClickEvent += OnGridItemClickEvent;
            mFrameStyleRootView.Add(mFrameStyleGrid);

            List<FrameStyleGridItemData> dataList = new List<FrameStyleGridItemData>();
            dataList.Add(new FrameStyleGridItemData(FB_PICTURE_FRAME_PICTURE_IMAGE, FB_PICTURE_FRAME_FRAME1_IMAGE, "Frameless"));
            dataList.Add(new FrameStyleGridItemData(FB_PICTURE_FRAME_PICTURE_IMAGE, FB_PICTURE_FRAME_FRAME2_IMAGE, "No shadow"));
            dataList.Add(new FrameStyleGridItemData(FB_PICTURE_FRAME_PICTURE_IMAGE, FB_PICTURE_FRAME_FRAME3_IMAGE, "Shelf shadow"));
            dataList.Add(new FrameStyleGridItemData(FB_PICTURE_FRAME_PICTURE_IMAGE, FB_PICTURE_FRAME_FRAME4_IMAGE, "Thin frame"));
            dataList.Add(new FrameStyleGridItemData(FB_PICTURE_FRAME_PICTURE_IMAGE, FB_PICTURE_FRAME_FRAME5_IMAGE, "Bold frame"));
            dataList.Add(new FrameStyleGridItemData(FB_PICTURE_FRAME_PICTURE_IMAGE, FB_PICTURE_FRAME_FRAME6_IMAGE, "Polaroid frame"));
            dataList.Add(new FrameStyleGridItemData(FB_PICTURE_FRAME_PICTURE_IMAGE, FB_PICTURE_FRAME_FRAME7_IMAGE, "Drawing frame"));
            dataList.Add(new FrameStyleGridItemData(FB_PICTURE_FRAME_PICTURE_IMAGE, FB_PICTURE_FRAME_FRAME8_IMAGE, "Brush frame"));

            mFrameStyleBridge = new FrameStyleGridBridge(dataList);
            mFrameStyleGrid.SetAdapter(mFrameStyleBridge);

            GridLayoutManager layoutManager = new GridLayoutManager(4, LinearLayoutManager.VERTICAL);
            mFrameStyleGrid.SetLayoutManager(layoutManager);
        }

        private void OnBackButtonClickEvent(object sender, Button.ClickEventArgs e)
        {
            mCloseAreaTapGestureDetector.Detach(mCloseView);
            PictureWizard.Instance.Back();
        }

        private void OnDoneButtonClickEvent(object sender, Button.ClickEventArgs e)
        {
            FamilyBoardApplication.Instance.RemoveView();
        }

        private void OnGridItemClickEvent(object sender, FlexibleView.ItemClickEventArgs e)
        {
            if (e.ClickedView != null)
            {
                FrameStyleGridItemView iv = e.ClickedView.ItemView as FrameStyleGridItemView;
                if (iv != null)
                {
                    if (iv.IsChecked())
                    {
                        return;
                    }

                    iv.CheckFrameStyle(true);
                    if (mLastCheckedFrameStyle != null && mLastCheckedFrameStyle != e.ClickedView)
                    {
                        FrameStyleGridItemView lastItem = mLastCheckedFrameStyle.ItemView as FrameStyleGridItemView;
                        lastItem.CheckFrameStyle(false);
                    }
                    mLastCheckedFrameStyle = e.ClickedView;

                    ChooseFrameStyle(e.ClickedView.AdapterPosition, iv.GetFrameStyle());
                }
            }
        }
    }

    internal class FrameStyleGridItemData
    {
        public FrameStyleGridItemData(string picture, string frame, string style)
        {
            Picture = picture;
            Frame = frame;
            Style = style;
        }

        public string Picture
        {
            set;
            get;
        }

        public string Frame
        {
            set;
            get;
        }

        public string Style
        {
            set;
            get;
        }
    }

    internal class FrameStyleGridItemView : View
    {
        private View mRootView;
        private View mTextView;
        private TextLabel mTextLabel;
        private ImageView mPictureView;
        private ImageView mFrameView;
        private ImageView mCheckView;

        // state
        private bool mIsChecked = false;

        private readonly int FRAME_WIDTH = 228;
        private readonly int FRAME_HEIGHT = 241;

        private static string FB_PICTURE_DIR = CommonResource.GetResourcePath() + "picker/";
        private static string FB_PICTURE_CHECK_IMAGE = FB_PICTURE_DIR + "familyboard_photo_frame_check.png";

        public FrameStyleGridItemView(string picture, string frame, string text, int offset)
        {
            mRootView = new View();
            mRootView.Size2D = new Size2D(228, FRAME_HEIGHT + 34 + offset);

            // title
            mTextView = new View();
            mTextView.Position2D = new Position2D(29, 0);
            mTextView.Size2D = new Size2D(FRAME_WIDTH - 29, 34);
            mRootView.Add(mTextView);

            mTextLabel = new TextLabel();
            mTextLabel.Text = text;
            mTextLabel.FontFamily = "SamsungOneUI 500";
            mTextLabel.PointSize = 24;
            mTextLabel.TextColor = new Color(1.0f, 1.0f, 1.0f, 0.8f);
            mTextLabel.HorizontalAlignment = HorizontalAlignment.Begin;
            mTextLabel.VerticalAlignment = VerticalAlignment.Bottom;
            mTextLabel.PositionUsesPivotPoint = true;
            mTextLabel.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
            mTextLabel.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
            mTextView.Add(mTextLabel);

            mFrameView = new ImageView();
            mFrameView.ResourceUrl = frame;
            mFrameView.Position2D = new Position2D(0, 34 + offset);
            mFrameView.Size2D = new Size2D(FRAME_WIDTH, FRAME_HEIGHT);
            mRootView.Add(mFrameView);

            mPictureView = new ImageView();
            mPictureView.ResourceUrl = picture;
            mPictureView.Position2D = new Position2D(0, 34 + offset);
            mPictureView.Size2D = new Size2D(FRAME_WIDTH, FRAME_HEIGHT);
            mRootView.Add(mPictureView);

            // check
            mCheckView = new ImageView();
            mCheckView.ResourceUrl = FB_PICTURE_CHECK_IMAGE;
            mCheckView.Position2D = new Position2D(0, 34 + offset);
            mCheckView.Size2D = new Size2D(FRAME_WIDTH, FRAME_HEIGHT);
            mRootView.Add(mCheckView);
            mCheckView.Hide();

            Add(mRootView);
        }

        public bool IsChecked()
        {
            return mIsChecked;
        }

        public string GetFrameStyle()
        {
            return mFrameView.ResourceUrl;
        }

        public void CheckFrameStyle(bool isChecked)
        {
            if (isChecked)
            {
                if (!mIsChecked)
                {
                    mCheckView.Show();
                    mIsChecked = true;
                }
            }
            else
            {
                mCheckView.Hide();
                mIsChecked = false;
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
                if (mCheckView != null)
                {
                    mRootView.Remove(mCheckView);
                    mCheckView.Dispose();
                    mCheckView = null;
                }
                if (mPictureView != null)
                {
                    mRootView.Remove(mPictureView);
                    mPictureView.Dispose();
                    mPictureView = null;
                }
                if (mTextLabel != null)
                {
                    mTextView.Remove(mTextLabel);
                    mTextLabel.Dispose();
                    mTextLabel = null;
                }
                if (mTextView != null)
                {
                    mRootView.Remove(mTextView);
                    mTextView.Dispose();
                    mTextView = null;
                }
                if (mRootView != null)
                {
                    Remove(mRootView);
                    mRootView = null;
                }
            }

            base.Dispose(type);
        }
    }

    internal class FrameStyleGridBridge : FlexibleView.Adapter
    {
        private List<FrameStyleGridItemData> mDatas;

        public FrameStyleGridBridge(List<FrameStyleGridItemData> datas)
        {
            mDatas = datas;
        }

        public override int GetItemViewType(int position)
        {
            return position;  // position is used as item view type.
        }

        public override FlexibleView.ViewHolder OnCreateViewHolder(int viewType)
        {
            View item_view = null;
            FrameStyleGridItemData listItemData = mDatas[viewType];
            int offset = -2;
            if (viewType > 3)
            {
                offset = 11;
            }
            item_view = new FrameStyleGridItemView(listItemData.Picture, listItemData.Frame, listItemData.Style, offset);
            FlexibleView.ViewHolder viewHolder = new FlexibleView.ViewHolder(item_view);
            return viewHolder;
        }

        public override void OnBindViewHolder(FlexibleView.ViewHolder holder, int position)
        {
            FrameStyleGridItemData listItemData = mDatas[position];
            if (position < 4)
            {
                FrameStyleGridItemView listItemView = holder.ItemView as FrameStyleGridItemView;
                listItemView.Name = "Item" + position;
                listItemView.Size2D = new Size2D(228, 273);
                if (position < 3)
                {
                    listItemView.Margin = new Extents(0, 20, 0, 0);
                }
                else
                {
                    listItemView.Margin = new Extents(0, 0, 0, 0);
                }      
            }
            else
            {
                FrameStyleGridItemView listItemView = holder.ItemView as FrameStyleGridItemView;
                listItemView.Name = "Item" + position;
                listItemView.Size2D = new Size2D(228, 286);
                if (position < 7)
                {
                    listItemView.Margin = new Extents(0, 20, 0, 0);
                }
                else
                {
                    listItemView.Margin = new Extents(0, 0, 0, 0);
                }
            }
        }

        public override void OnDestroyViewHolder(FlexibleView.ViewHolder holder)
        {
            if (holder.ItemView != null)
            {
                holder.ItemView.Dispose();
            }
        }

        public override int GetItemCount()
        {
            return mDatas.Count;
        }
    }
}
