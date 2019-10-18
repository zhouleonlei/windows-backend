
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.FH.FamilyBoard
{
    
    public class FamilyBoardMain : IViewLifecycle
    {
        private View mRootView;
        private TapGestureDetector mTapGestureDetector;

        // date time
        private View mTimeView;
        private TextLabel mTimeLabel;
        private View mAmPmView;
        private TextLabel mAmPmLabel;
        private View mDateView;
        private TextLabel mDateLabel;

        // menu
        private View mMenuRootView;
        private FlexibleView mMenuList;
        private NPatchVisual mNPatchVisual;
        private MenuListBridge mMenuListBridge;

        // image
        private ImageView[] mSelectedImages;
        private int mCurrentImagesCount = 0;

        private readonly int MAX_IMAGE_COUNT = 50;

        private readonly int SCREEN_WIDTH = 1080;
        private readonly int SCREEN_HEIGHT = 1920;

        // images
        private static string FB_BACKGROUND_IMAGE = CommonResource.GetResourcePath() + "familyboard_metal_bg_6.png";

        private static string FB_MENU_IMAGE = CommonResource.GetResourcePath() + "add_menu/";
        private static string FB_MENU_BACKGROUND_IMAGE = FB_MENU_IMAGE + "fb_menu_bg.png";
        private static string FB_MENU_PICTURE_IMAGE = FB_MENU_IMAGE + "fb_menu_ic_picture.png";
        private static string FB_MENU_MEMO_IMAGE = FB_MENU_IMAGE + "fb_menu_ic_memo.png";
        private static string FB_MENU_STICKERS_IMAGE = FB_MENU_IMAGE + "fb_menu_ic_stickers.png";
        private static string FB_MENU_DRAWING_IMAGE = FB_MENU_IMAGE + "fb_menu_ic_drawing.png";
        private static string FB_MENU_TEXT_IMAGE = FB_MENU_IMAGE + "fb_menu_ic_text.png";
        private static string FB_MENU_MUSIC_IMAGE = FB_MENU_IMAGE + "fb_menu_ic_music.png";
        private static string FB_MENU_NEW_IMAGE = FB_MENU_IMAGE + "fb_menu_ic_new.png";
        private static string FB_MENU_OPEN_IMAGE = FB_MENU_IMAGE + "fb_menu_ic_open.png";
        private static string FB_MENU_MORE_IMAGE = FB_MENU_IMAGE + "fb_menu_ic_more.png";

        public void Activate()
        {
            mRootView = new View();
            mRootView.Size2D = new Size2D(SCREEN_WIDTH, SCREEN_HEIGHT);
            mRootView.BackgroundImage = FB_BACKGROUND_IMAGE;
            Window.Instance.GetDefaultLayer().Add(mRootView);

            mTapGestureDetector = new TapGestureDetector();
            mTapGestureDetector.Attach(mRootView);
            mTapGestureDetector.Detected += OnTapGestureDetected;

            CreateDateTime();

            // for test
            mSelectedImages = new ImageView[MAX_IMAGE_COUNT];
            mCurrentImagesCount = 0;
        }

        public void Reactivate()
        {
            mTapGestureDetector.Attach(mRootView);

            //
            ShowSelectedImage();

            // clear db
            ImageManager.Instance.RemoveAllImages();
        }

        public void Deactivate()
        {
            if (mRootView != null)
            {
                Window.Instance.GetDefaultLayer().Remove(mRootView);
                mRootView.Dispose();
                mRootView = null;
            }
        }

        private void ShowSelectedImage()
        {
            int imageCount = ImageManager.Instance.ImageCount();
            if (mCurrentImagesCount + imageCount >= 50)
                return;

            for (int i = 0; i < imageCount; i++)
            {
                ImageVisual imageVisual = new ImageVisual()
                {
                    URL = ImageManager.Instance.GetImageFile(i),
                    VisualFittingMode = VisualFittingModeType.FitKeepAspectRatio,
                };
                mSelectedImages[mCurrentImagesCount + i] = new ImageView();
                mSelectedImages[mCurrentImagesCount + i].Image = imageVisual.OutputVisualMap;
                mSelectedImages[mCurrentImagesCount + i].Position2D = new Position2D(200 + i * 14, 300 + i * 14);
                mSelectedImages[mCurrentImagesCount + i].Size2D = new Size2D(400, 400);
                mRootView.Add(mSelectedImages[mCurrentImagesCount + i]);
            }

            mCurrentImagesCount += imageCount;
        }

        private void CreateDateTime()
        {
            // time
            mTimeView = new View();
            mTimeView.Position2D = new Position2D(48, 33);
            mTimeView.SizeHeight = 28 + 58 + 22;
            mTimeView.SizeWidth = 226 + 300;
            mRootView.Add(mTimeView);

            mTimeLabel = new TextLabel();
            mTimeLabel.Text = "09:30";
            mTimeLabel.FontFamily = "SamsungOneUI 500";
            mTimeLabel.PointSize = 71;
            mTimeLabel.TextColor = new Color(1.0f, 1.0f, 1.0f, 0.7f);
            mTimeLabel.Position2D = new Position2D(0, 0);
            mTimeLabel.SizeHeight = 58 + 100;
            mTimeLabel.SizeWidth = mTimeLabel.GetWidthForHeight(mTimeLabel.SizeHeight);
            mTimeLabel.PositionUsesPivotPoint = true;
            mTimeLabel.PivotPoint = PivotPoint.CenterLeft;
            mTimeLabel.ParentOrigin = ParentOrigin.CenterLeft;
            mTimeView.Add(mTimeLabel);

            // am, pm
            mAmPmView = new View();
            mAmPmView.Position2D = new Position2D(48 + (int)mTimeLabel.SizeWidth + 11, 95 - 30);
            mAmPmView.SizeHeight = 9 + 18 + 7 + 40;
            mAmPmView.SizeWidth = 226;
            mRootView.Add(mAmPmView);

            mAmPmLabel = new TextLabel();
            mAmPmLabel.Text = "AM";
            mAmPmLabel.FontFamily = "SamsungOneUI 500";
            mAmPmLabel.PointSize = 22;
            mAmPmLabel.TextColor = new Color(1.0f, 1.0f, 1.0f, 0.7f);
            //mAmPmLabel.Position2D = new Position2D(0, 0);
            //mAmPmLabel.SizeHeight = 18;
            //mAmPmLabel.SizeWidth = mAmPmLabel.GetWidthForHeight(mAmPmLabel.SizeHeight);
            mAmPmLabel.PositionUsesPivotPoint = true;
            mAmPmLabel.PivotPoint = PivotPoint.CenterRight;
            mAmPmLabel.ParentOrigin = ParentOrigin.CenterRight;
            mAmPmView.Add(mAmPmLabel);

            // date
            mDateView = new View();
            mDateView.Position2D = new Position2D(48, 134 + 22);
            mDateView.SizeHeight = 9 + 18 + 7;
            mDateView.SizeWidth = 490;
            mRootView.Add(mDateView);

            mDateLabel = new TextLabel();
            mDateLabel.Text = "Wednesday, June 21";
            mDateLabel.FontFamily = "SamsungOneUI 500";
            mDateLabel.PointSize = 22;
            mDateLabel.TextColor = new Color(1.0f, 1.0f, 1.0f, 0.7f);
            //mDateLabel.Position2D = new Position2D(0, 9);
            //mDateLabel.SizeHeight = 18;
            //mDateLabel.SizeWidth = mDateLabel.GetWidthForHeight(mDateLabel.SizeHeight);
            mDateLabel.PositionUsesPivotPoint = true;
            mDateLabel.PivotPoint = PivotPoint.CenterRight;
            mDateLabel.ParentOrigin = ParentOrigin.CenterRight;

            mDateView.Add(mDateLabel);
        }

        private void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            if (mMenuRootView == null)
            {
                Vector2 pos = e.TapGesture.ScreenPoint;
                CreateMenu((int)pos.X, (int)pos.Y);
                mMenuRootView.Hide();
            }

            if (mMenuRootView.Visibility)
            {
                mMenuRootView.Hide();
            }
            else
            {
                Vector2 pos = e.TapGesture.ScreenPoint;
                mMenuRootView.Position2D = new Position2D((int)pos.X, (int)pos.Y);
                mMenuRootView.Show();
            }
        }

        private void CreateMenu(int x, int y)
        {
            mMenuRootView = new View();
            mNPatchVisual = new NPatchVisual();
            mNPatchVisual.URL = FB_MENU_BACKGROUND_IMAGE;
            mNPatchVisual.Border = new Rectangle(80, 80, 120, 50);
            mMenuRootView.Background = mNPatchVisual.OutputVisualMap;
            mMenuRootView.Position2D = new Position2D(x, y);
            mMenuRootView.Size2D = new Size2D(270 + 40, 369 + 50);
            mRootView.Add(mMenuRootView);

            mMenuList = new FlexibleView();
            mMenuList.Name = "Menu List";
            mMenuList.Position2D = new Position2D(30, 5);
            mMenuList.Size2D = new Size2D(210, 6 * 50 + 8 + 56);
            mMenuList.Padding = new Extents(0, 0, 0, 0);
            mMenuList.ItemClickEvent += OnListItemClickEvent;
            mMenuRootView.Add(mMenuList);

            List<MenuListItemData> dataList = new List<MenuListItemData>();
            dataList.Add(new MenuListItemData(FB_MENU_PICTURE_IMAGE, "picture"));
            dataList.Add(new MenuListItemData(FB_MENU_MEMO_IMAGE, "memo"));
            dataList.Add(new MenuListItemData(FB_MENU_STICKERS_IMAGE, "stickers"));
            dataList.Add(new MenuListItemData(FB_MENU_DRAWING_IMAGE, "drawing"));
            dataList.Add(new MenuListItemData(FB_MENU_TEXT_IMAGE, "text"));
            dataList.Add(new MenuListItemData(FB_MENU_MUSIC_IMAGE, "music"));
            dataList.Add(new MenuListItemData("", ""));

            mMenuListBridge = new MenuListBridge(dataList);
            mMenuList.SetAdapter(mMenuListBridge);

            LinearLayoutManager layoutManager = new LinearLayoutManager(LinearLayoutManager.VERTICAL);
            mMenuList.SetLayoutManager(layoutManager);
        }

        private void OnListItemClickEvent(object sender, FlexibleView.ItemClickEventArgs e)
        {
            if (e.ClickedView != null)
            {
                int index = e.ClickedView.AdapterPosition;
                switch (index)
                {
                    case 0: 
                        {
                            mMenuRootView.Hide();
                            mTapGestureDetector.Detach(mRootView);
                            FamilyBoardApplication.Instance.CreateView("Picture Wizard");
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }

    internal class MenuListItemData
    {
        public MenuListItemData(string icon, string text)
        {
            Icon = icon;
            Text = text;
        }

        public string Icon
        {
            set;
            get;
        }

        public string Text
        {
            set;
            get;
        }
    }

    internal class MenuListItemView : View
    {
        private View mRootView;
        private ImageView mIconView;
        private View mTextView;
        private TextLabel mTextLabel;

        public MenuListItemView(string icon, string text)
        {
            mRootView = new View();
            mRootView.Size2D = new Size2D(210, 50);

            mIconView = new ImageView();
            mIconView.Position2D = new Position2D(21, 0);
            mIconView.Size2D = new Size2D(30, 30);
            mIconView.ResourceUrl = icon;
            mIconView.PositionUsesPivotPoint = true;
            mIconView.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
            mIconView.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
            mRootView.Add(mIconView);

            mTextView = new View();
            mTextView.Position2D = new Position2D(21 + 30 + 15, 0);
            mTextView.Size2D = new Size2D(210 - 30 - 15, 50);
            mTextView.PositionUsesPivotPoint = true;
            mTextView.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
            mTextView.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
            mRootView.Add(mTextView);

            mTextLabel = new TextLabel();
            mTextLabel.Text = text;
            mTextLabel.FontFamily = "SamsungOneUI 600";
            mTextLabel.PointSize = 16;
            mTextLabel.TextColor = new Color(0.0f, 0.0f, 0.0f, 0.8f);
            mTextLabel.PositionUsesPivotPoint = true;
            mTextLabel.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
            mTextLabel.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
            mTextView.Add(mTextLabel);

            Add(mRootView);
        }
    }

    internal class MenuButtonsItemView : View
    {
        private View mRootView;
        private TableView mIconsView;
        private ImageView mAddImageView;
        private ImageView mOpenImageView;
        private ImageView mMoreImageView;

        private static string FB_MENU_IMAGE = CommonResource.GetResourcePath() + "add_menu/";
        private static string FB_MENU_NEW_IMAGE = FB_MENU_IMAGE + "fb_menu_ic_new.png";
        private static string FB_MENU_OPEN_IMAGE = FB_MENU_IMAGE + "fb_menu_ic_open.png";
        private static string FB_MENU_MORE_IMAGE = FB_MENU_IMAGE + "fb_menu_ic_more.png";

        public MenuButtonsItemView()
        {
            mRootView = new View();
            mRootView.Size2D = new Size2D(210, 8 + 56);

            mIconsView = new TableView(1, 3);
            mIconsView.Position2D = new Position2D(31, 8);
            mIconsView.Size2D = new Size2D(210, 56);
            mIconsView.PositionUsesPivotPoint = true;
            mIconsView.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
            mIconsView.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
            mRootView.Add(mIconsView);

            mAddImageView = new ImageView();
            mAddImageView.ResourceUrl = FB_MENU_NEW_IMAGE;
            mIconsView.SetCellAlignment(new TableView.CellPosition(0, 0), HorizontalAlignmentType.Center, VerticalAlignmentType.Center);
            mIconsView.AddChild(mAddImageView, new TableView.CellPosition(0, 0));

            mOpenImageView = new ImageView();
            mOpenImageView.ResourceUrl = FB_MENU_OPEN_IMAGE;
            mIconsView.SetCellAlignment(new TableView.CellPosition(0, 1), HorizontalAlignmentType.Center, VerticalAlignmentType.Center);
            mIconsView.AddChild(mOpenImageView, new TableView.CellPosition(0, 1));

            mMoreImageView = new ImageView();
            mMoreImageView.ResourceUrl = FB_MENU_MORE_IMAGE;
            mIconsView.SetCellAlignment(new TableView.CellPosition(0, 2), HorizontalAlignmentType.Center, VerticalAlignmentType.Center);
            mIconsView.AddChild(mMoreImageView, new TableView.CellPosition(0, 2));

            Add(mRootView);
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (mAddImageView != null)
                {
                    mIconsView.Remove(mAddImageView);
                    mAddImageView.Dispose();
                    mAddImageView = null;
                }
                if (mOpenImageView != null)
                {
                    mIconsView.Remove(mOpenImageView);
                    mOpenImageView.Dispose();
                    mOpenImageView = null;
                }
                if (mMoreImageView != null)
                {
                    mIconsView.Remove(mMoreImageView);
                    mMoreImageView.Dispose();
                    mMoreImageView = null;
                }
                if (mIconsView != null)
                {
                    mRootView.Remove(mIconsView);
                    mIconsView.Dispose();
                    mIconsView = null;
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

    internal class MenuListBridge : FlexibleView.Adapter
    {
        private List<MenuListItemData> mDatas;

        public MenuListBridge(List<MenuListItemData> datas)
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
            MenuListItemData listItemData = mDatas[viewType];

            switch (viewType)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    {
                        item_view = new MenuListItemView(listItemData.Icon, listItemData.Text);
                        break;
                    }
                case 6:
                    {
                        item_view = new MenuButtonsItemView();
                        break;
                    }
                default:
                    break;
            }

            FlexibleView.ViewHolder viewHolder = new FlexibleView.ViewHolder(item_view);

            return viewHolder;
        }

        public override void OnBindViewHolder(FlexibleView.ViewHolder holder, int position)
        {
            MenuListItemData listItemData = mDatas[position];
            switch (position)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    {
                        MenuListItemView listItemView = holder.ItemView as MenuListItemView;
                        listItemView.Name = "Item" + position;
                        listItemView.Size2D = new Size2D(210, 50);
                        listItemView.Margin = new Extents(0, 0, 0, 0);
                        break;
                    }
                case 6:
                    {
                        MenuButtonsItemView listItemView = holder.ItemView as MenuButtonsItemView;
                        listItemView.Name = "Item" + position;
                        listItemView.Size2D = new Size2D(210, 8 + 56);
                        listItemView.Margin = new Extents(0, 0, 0, 0);
                        break;
                    }
                default:
                    break;
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

