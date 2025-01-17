﻿using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.FamilyBoard
{
    public class PictureChooser : IViewLifecycle
    {
        private View mRootView;

        // close
        private View mCloseView;
        private ImageView mCloseImageView;
        private TapGestureDetector mCloseAreaTapGestureDetector;

        private View mPictureRootView;

        // title
        private View mTitleView;
        private TextLabel mTitleLabel;

        // next button
        private Button mNextButton;

        // picture grid
        private FlexibleView mPictureGrid;
        private PictureGridBridge mPictureGridBridge;
        private List<FlexibleView.ViewHolder> mPictureItemList = new List<FlexibleView.ViewHolder>();

        private Toast mMessageIndicator;

        private readonly int SCREEN_WIDTH = 1080;
        private readonly int SCREEN_HEIGHT = 1920;

        //
        private static string FB_PICTURE_DIR = CommonResource.GetResourcePath() + "picker/";
        private static string FB_PICTURE_CLOSE_IMAGE = FB_PICTURE_DIR + "familyboard_ic_delete.png";
        private static string FB_PICTURE_NEXT_BUTTON_IMAGE = FB_PICTURE_DIR + "familyboard_photo_drawer_btn.png";

        private static string FB_PHOTO_ALBUM_DIR = CommonResource.GetResourcePath() + "photo_album/";
        private static string FB_PHOTO_ALBUM_004_IMAGE = FB_PHOTO_ALBUM_DIR + "Photo_004.jpg";
        private static string FB_PHOTO_ALBUM_007_IMAGE = FB_PHOTO_ALBUM_DIR + "Photo_007.jpg";
        private static string FB_PHOTO_ALBUM_010_IMAGE = FB_PHOTO_ALBUM_DIR + "Photo_010.jpg";
        private static string FB_PHOTO_ALBUM_012_IMAGE = FB_PHOTO_ALBUM_DIR + "Photo_012.jpg";
        private static string FB_PHOTO_ALBUM_005_IMAGE = FB_PHOTO_ALBUM_DIR + "Photo_005.jpg";
        private static string FB_PHOTO_ALBUM_006_IMAGE = FB_PHOTO_ALBUM_DIR + "Photo_006.jpg";
        private static string FB_PHOTO_ALBUM_008_IMAGE = FB_PHOTO_ALBUM_DIR + "Photo_008.jpg";
        private static string FB_PHOTO_ALBUM_009_IMAGE = FB_PHOTO_ALBUM_DIR + "Photo_009.jpg";

        public void Activate()
        {
            mRootView = new View();
            mRootView.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.7f);
            mRootView.Size2D = new Size2D(SCREEN_WIDTH, SCREEN_HEIGHT);
            Window.Instance.GetDefaultLayer().Add(mRootView);

            CreateCloseButton();

            CreatePictureGrid();

            // message
            mMessageIndicator = new Toast();
            mMessageIndicator.Duration = 1000;
            mMessageIndicator.TextArray = new string[] { "You can only select up to 5 pictures." };
            mMessageIndicator.Position2D = new Position2D(200, 600);
            mMessageIndicator.Size2D = new Size2D(680, 300);
            mRootView.Add(mMessageIndicator);
            mMessageIndicator.Hide();
        }

        public void Reactivate()
        {
            mCloseAreaTapGestureDetector.Attach(mCloseView);
        }

        public void Deactivate()
        {
            if (mNextButton != null)
            {
                mPictureRootView.Remove(mNextButton);
                mNextButton.Dispose();
                mNextButton = null;
            }

            if (mPictureGrid != null)
            {
                mPictureRootView.Remove(mPictureGrid);
                mPictureGrid.Dispose();
                mPictureGrid = null;
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

            if (mTitleLabel != null)
            {
                mTitleView.Remove(mTitleLabel);
                mTitleLabel.Dispose();
                mTitleLabel = null;
            }

            if (mTitleView != null)
            {
                mPictureRootView.Remove(mTitleView);
                mTitleView.Dispose();
                mTitleView = null;
            }

            if (mPictureRootView != null)
            {
                mRootView.Remove(mPictureRootView);
                mPictureRootView.Dispose();
                mPictureRootView = null;
            }

            if (mMessageIndicator != null)
            {
                mRootView.Remove(mMessageIndicator);
                mMessageIndicator.Dispose();
                mMessageIndicator = null;
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

        public void ShowMessage()
        {
            if (mMessageIndicator != null)
            {
                mMessageIndicator.Show();
            }
        }

        public void ShowNextButton(bool selected)
        {
            if (selected)
            {
                mNextButton.Show();
            }
            else
            {
                mNextButton.Hide();
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

        private void CreatePictureGrid()
        {
            // picture
            mPictureRootView = new View();
            mPictureRootView.Position2D = new Position2D(0, 405);
            mPictureRootView.Size2D = new Size2D(SCREEN_WIDTH, 177 + (340 + 10) * 3 + 340);
            mPictureRootView.BackgroundColor = new Color(0.2f, 0.2f, 0.2f, 1.0f);
            mRootView.Add(mPictureRootView);

            // title
            mTitleView = new View();
            mTitleView.Position2D = new Position2D();
            mTitleView.Size2D = new Size2D(SCREEN_WIDTH, 177);
            mPictureRootView.Add(mTitleView);

            mTitleLabel = new TextLabel();
            mTitleLabel.Text = "Picture";
            mTitleLabel.FontFamily = "SamsungOneUI 600";
            mTitleLabel.PointSize = 40;
            mTitleLabel.TextColor = new Color(1.0f, 1.0f, 1.0f, 0.8f);
            mTitleLabel.PositionUsesPivotPoint = true;
            mTitleLabel.PivotPoint = PivotPoint.Center;
            mTitleLabel.ParentOrigin = ParentOrigin.Center;
            mTitleLabel.HorizontalAlignment = HorizontalAlignment.Center;
            mTitleLabel.VerticalAlignment = VerticalAlignment.Center;
            mTitleView.Add(mTitleLabel);

            // next button
            mNextButton = new Button();
            mNextButton.BackgroundImage = FB_PICTURE_NEXT_BUTTON_IMAGE;
            mNextButton.Text = "Next";
            mNextButton.TextColor = Color.White;
            mNextButton.PointSize = 30;
            mNextButton.FontFamily = "SamsungOneUI 500";
            mNextButton.Position2D = new Position2D(SCREEN_WIDTH - 151 - 40 - 46, (177 - 70) /2);
            mNextButton.Size2D = new Size2D(151 + 40, 60 + 10);
            mPictureRootView.Add(mNextButton);

            mNextButton.ClickEvent += OnNextButtonClickEvent;
            mNextButton.Hide();

            // grid
            mPictureGrid = new FlexibleView();
            mPictureGrid.Name = "Picture Grid";
            mPictureGrid.Position2D = new Position2D(0, 177);
            mPictureGrid.Size2D = new Size2D(SCREEN_WIDTH, SCREEN_HEIGHT - 405 - 177);
            mPictureGrid.Padding = new Extents(41, 41, 0, 0);
            mPictureGrid.ItemClickEvent += OnGridItemClickEvent;
            mPictureRootView.Add(mPictureGrid);

            List<PictureGridItemData> dataList = new List<PictureGridItemData>();
            dataList.Add(new PictureGridItemData(FB_PHOTO_ALBUM_004_IMAGE));
            dataList.Add(new PictureGridItemData(FB_PHOTO_ALBUM_007_IMAGE));
            dataList.Add(new PictureGridItemData(FB_PHOTO_ALBUM_010_IMAGE));
            dataList.Add(new PictureGridItemData(FB_PHOTO_ALBUM_012_IMAGE));
            dataList.Add(new PictureGridItemData(FB_PHOTO_ALBUM_005_IMAGE));
            dataList.Add(new PictureGridItemData(FB_PHOTO_ALBUM_006_IMAGE));
            dataList.Add(new PictureGridItemData(FB_PHOTO_ALBUM_008_IMAGE));
            dataList.Add(new PictureGridItemData(FB_PHOTO_ALBUM_009_IMAGE));

            mPictureGridBridge = new PictureGridBridge(this, dataList);
            mPictureGrid.SetAdapter(mPictureGridBridge);

            GridLayoutManager layoutManager = new GridLayoutManager(3, LinearLayoutManager.VERTICAL);
            mPictureGrid.SetLayoutManager(layoutManager);
        }

        private void OnNextButtonClickEvent(object sender, Button.ClickEventArgs e)
        {
            mCloseAreaTapGestureDetector.Detach(mCloseView);
            PictureWizard.Instance.Next();
        }

        private void OnGridItemClickEvent(object sender, FlexibleView.ItemClickEventArgs e)
        {
            if (e.ClickedView != null)
            {
                PictureGridItemView iv = e.ClickedView.ItemView as PictureGridItemView;
                if (iv != null)
                {
                    iv.SelectImage();

                    if (iv.IsSelected())
                    {
                        mPictureItemList.Add(e.ClickedView);
                    }
                    else
                    {
                        mPictureItemList.Remove(e.ClickedView);
                        iv.SetIndicator("");
                    }

                    for (int i = 0; i < mPictureItemList.Count; i++)
                    {
                        PictureGridItemView pgv = mPictureItemList[i].ItemView as PictureGridItemView;
                        int index = ImageManager.Instance.GetImageIndex(pgv.ImageId());
                        if (index != 0)
                        {
                            pgv.SetIndicator("" + index);
                        }
                        else
                        {
                            pgv.SetIndicator("");
                        }
                    }
                }
            }
        }

        private void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            ImageManager.Instance.RemoveAllImages();
            FamilyBoardApplication.Instance.RemoveView();
        }
    }

    internal class PictureGridItemData
    {
        public PictureGridItemData(string url)
        {
            Picture = url;
        }

        public string Picture
        {
            set;
            get;
        }
    }

    internal class PictureGridItemView : View
    {
        private View mRootView;
        private ImageView mPictureView;
        private View mCheckTextView;
        private TextLabel mTextLabel;

        // state
        private bool mIsSelected = false;

        //
        private PictureChooser mPictureChooser;

        private static string FB_PICTURE_DIR = CommonResource.GetResourcePath() + "picker/";
        private static string FB_PICTURE_OVAL_NORMAL_IMAGE = FB_PICTURE_DIR + "familyboard_photo_ic_nor.png";
        private static string FB_PICTURE_OVAL_SELECTED_IMAGE = FB_PICTURE_DIR + "familyboard_photo_ic_sel.png";

        public PictureGridItemView(PictureChooser chooser, string photo)
        {
            mPictureChooser = chooser;

            //
            mRootView = new View();
            mRootView.Size2D = new Size2D(326, 340);

            mPictureView = new ImageView();
            mPictureView.ResourceUrl = photo;
            mPictureView.PositionUsesPivotPoint = true;
            mPictureView.ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft;
            mPictureView.PivotPoint = Tizen.NUI.PivotPoint.TopLeft;
            mPictureView.Position2D = new Position2D(0, 0);
            mPictureView.Size2D = new Size2D(326, 340);

            if (mPictureView.NaturalSize2D.Width < mPictureView.NaturalSize2D.Height)
            {
                mPictureView.FittingMode = FittingModeType.FitWidth;
            }
            else
            {
                mPictureView.FittingMode = FittingModeType.FitHeight;
            }

            mRootView.Add(mPictureView);

            // check and digit
            mCheckTextView = new View();
            mCheckTextView.Position2D = new Position2D(326 - 10 - 50, 10);
            mCheckTextView.Size2D = new Size2D(50, 50);
            mRootView.Add(mCheckTextView);

            mTextLabel = new TextLabel();
            mTextLabel.BackgroundImage = FB_PICTURE_OVAL_NORMAL_IMAGE;
            mTextLabel.FontFamily = "SamsungOneUI 600";
            mTextLabel.PointSize = 16;
            mTextLabel.TextColor = new Color(1.0f, 1.0f, 1.0f, 0.8f);
            mTextLabel.HorizontalAlignment = HorizontalAlignment.Center;
            mTextLabel.VerticalAlignment = VerticalAlignment.Center;
            mTextLabel.PositionUsesPivotPoint = true;
            mTextLabel.PivotPoint = Tizen.NUI.PivotPoint.Center;
            mTextLabel.ParentOrigin = Tizen.NUI.ParentOrigin.Center;
            mTextLabel.Size2D = new Size2D(50, 50);
            mCheckTextView.Add(mTextLabel);

            Add(mRootView);
        }

        public bool IsSelected()
        {
            return mIsSelected;
        }

        public string ImageId()
        {
            return mPictureView.ResourceUrl;
        }

        public void SetIndicator(string index)
        {
            mTextLabel.Text = index;
        }

        public void SelectImage()
        {
            mIsSelected = !mIsSelected;
            if (mIsSelected)
            {
                mPictureChooser.ShowNextButton(true);
                if (ImageManager.Instance.ImageCount() >= 5)
                {
                    mPictureChooser.ShowMessage();
                    mIsSelected = !mIsSelected; // restore.
                }
                else
                {
                    mTextLabel.BackgroundImage = FB_PICTURE_OVAL_SELECTED_IMAGE;
                    ImageManager.Instance.AddImage(mPictureView.ResourceUrl, "");
                }
            }
            else
            {
                mTextLabel.BackgroundImage = FB_PICTURE_OVAL_NORMAL_IMAGE;
                ImageManager.Instance.RemoveImage(mPictureView.ResourceUrl);
                if (ImageManager.Instance.ImageCount() == 0)
                {
                    mPictureChooser.ShowNextButton(false);
                }
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
                if (mTextLabel != null)
                {
                    mCheckTextView.Remove(mTextLabel);
                    mTextLabel.Dispose();
                    mTextLabel = null;
                }
                if (mCheckTextView != null)
                {
                    mRootView.Remove(mCheckTextView);
                    mCheckTextView.Dispose();
                    mCheckTextView = null;
                }
                if (mPictureView != null)
                {
                    mRootView.Remove(mPictureView);
                    mPictureView.Dispose();
                    mPictureView = null;
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

    internal class PictureGridBridge : FlexibleView.Adapter
    {
        private List<PictureGridItemData> mDatas;
        private PictureChooser mPictureChooser;

        public PictureGridBridge(PictureChooser chooser, List<PictureGridItemData> datas)
        {
            mPictureChooser = chooser;
            mDatas = datas;
        }

        public override int GetItemViewType(int position)
        {
            return position;  // position is used as item view type.
        }

        public override FlexibleView.ViewHolder OnCreateViewHolder(int viewType)
        {
            View item_view = null;
            PictureGridItemData listItemData = mDatas[viewType];

            item_view = new PictureGridItemView(mPictureChooser, listItemData.Picture);
            FlexibleView.ViewHolder viewHolder = new FlexibleView.ViewHolder(item_view);

            return viewHolder;
        }

        public override void OnBindViewHolder(FlexibleView.ViewHolder holder, int position)
        {
            PictureGridItemData listItemData = mDatas[position];
            if (position % (3 - 1) == 0)
            {
                PictureGridItemView listItemView = holder.ItemView as PictureGridItemView;
                listItemView.Name = "Item" + position;
                listItemView.Size2D = new Size2D(326, 340);
                listItemView.Margin = new Extents(0, 10, 0, 10);
            }
            else
            {
                PictureGridItemView listItemView = holder.ItemView as PictureGridItemView;
                listItemView.Name = "Item" + position;
                listItemView.Size2D = new Size2D(326, 340);
                listItemView.Margin = new Extents(0, 0, 0, 10);
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
