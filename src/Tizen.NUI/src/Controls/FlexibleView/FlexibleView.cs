using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Controls
{
    public class FlexibleView : Control
    {
        public static readonly int NO_POSITION = -1;
        public static readonly int INVALID_TYPE = -1;

        private Adapter mAdapter;
        private LayoutManager mLayout;
        private Recycler mRecycler;
        private RecycledViewPool mRecyclerPool;
        private ChildHelper mChildHelper;

        private ViewState mState;

        private PanGestureDetector mPanGestureDetector;

        private int mFocusedItemIndex = NO_POSITION;

        private AdapterHelper mAdapteHelper;




        public FlexibleView()
        {
            mRecyclerPool = new RecycledViewPool();

            mRecycler = new Recycler(this);
            mRecycler.SetRecycledViewPool(mRecyclerPool);

            mChildHelper = new ChildHelper(this);

            mState = new ViewState(this);

            mPanGestureDetector = new PanGestureDetector();
            mPanGestureDetector.Attach(this);
            mPanGestureDetector.Detected += OnPanGestureDetected;

            mAdapteHelper = new AdapterHelper(this);

            ClippingMode = ClippingModeType.ClipToBoundingBox;
        }

        public void SetAdapter(Adapter adapter)
        {
            if (adapter == null)
            {
                return;
            }
            mAdapter = adapter;

            mAdapter.ItemEvent += OnItemEvent;
        }

        public Adapter GetAdapter()
        {
            return mAdapter;
        }

        public void SetLayoutManager(LayoutManager layoutManager)
        {
            mLayout = layoutManager;

            mLayout.SetRecyclerView(this);

            if (mLayout.CanScrollHorizontally())
            {
                mPanGestureDetector.AddDirection(PanGestureDetector.DirectionHorizontal);
            }
            else if (mLayout.CanScrollVertically())
            {
                mPanGestureDetector.AddDirection(PanGestureDetector.DirectionVertical);
            }
        }

        public int FocusedItemIndex
        {
            get
            {
                return mFocusedItemIndex;
            }
            set
            {
                if (value == mFocusedItemIndex)
                {
                    return;
                }

                if (mAdapter == null)
                {
                    return;
                }

                if (mLayout == null)
                {
                    return;
                }

                mLayout.ScrollToPosition(value);
            }
        }
        public void ScrollToPositionWithOffset(int position, int offset)
        {
            mLayout.ScrollToPositionWithOffset(position, offset);
        }

        public void MoveFocus(string direction)
        {
            mLayout.MoveFocus(direction, mRecycler, mState);

            //RemoveAndRecycleScrapInt();
        }

        public ViewHolder FindViewHolderForLayoutPosition(int position)
        {
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                if (mChildHelper.GetChildAt(i) is ViewHolder holder)
                {
                    if (holder.LayoutPosition == position)
                    {
                        return holder;
                    }
                }
            }

            return null;
        }

        public ViewHolder FindViewHolderForAdapterPosition(int position)
        {
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                if (mChildHelper.GetChildAt(i) is ViewHolder holder)
                {
                    if (holder.AdapterPosition == position)
                    {
                        return holder;
                    }
                }
            }

            return null;
        }

        protected override Attributes GetAttributes()
        {
            return null;
        }

        protected override void OnRelayout(object sender, EventArgs e)
        {
            if (mAdapter == null)
            {
                return;
            }

            if (mLayout == null)
            {
                return;
            }

            DispatchLayoutStep1();

            mLayout.OnLayoutChildren(mRecycler, mState);

            RemoveAndRecycleScrapInt();
        }

        private void DispatchLayoutStep1()
        {
            ProcessAdapterUpdates();
            SaveOldPositions();
            ClearOldPositions();
        }

        private void ProcessAdapterUpdates()
        {
            mAdapteHelper.PreProcess();
        }

        private void OffsetPositionRecordsForInsert(int positionStart, int itemCount)
        {
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                ViewHolder holder = mChildHelper.GetChildAt(i);
                if (holder != null && holder.AdapterPosition >= positionStart)
                {
                    holder.OffsetPosition(itemCount, false);
                }
            }

            if (positionStart <= mFocusedItemIndex)
            {
                mFocusedItemIndex += itemCount;
            }
        }

        void OffsetPositionRecordsForRemove(int positionStart, int itemCount, bool applyToPreLayout)
        {
            int positionEnd = positionStart + itemCount;
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                ViewHolder holder = mChildHelper.GetChildAt(i);
                if (holder != null)
                {
                    if (holder.AdapterPosition >= positionEnd)
                    {
                        holder.OffsetPosition(-itemCount, applyToPreLayout);
                    }
                    else if (holder.AdapterPosition >= positionStart)
                    {
                        holder.FlagRemovedAndOffsetPosition(positionStart - 1, -itemCount, applyToPreLayout);
                    }
                }
            }

            if (positionEnd <= mFocusedItemIndex)
            {
                mFocusedItemIndex -= itemCount;
            }
            else if (positionStart <= mFocusedItemIndex)
            {
                mFocusedItemIndex = positionStart;
                if (mFocusedItemIndex >= mAdapter.GetItemCount())
                {
                    mFocusedItemIndex = mAdapter.GetItemCount() - 1;
                }
            }
        }

        private void SaveOldPositions()
        {
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                ViewHolder holder = mChildHelper.GetChildAt(i);
                holder.SaveOldPosition();
            }
        }

        private void ClearOldPositions()
        {
            int childCount = mChildHelper.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                ViewHolder holder = mChildHelper.GetChildAt(i);
                holder.ClearOldPosition();
            }
        }

        private void RemoveAndRecycleScrapInt()
        {
            int scrapCount = mRecycler.GetScrapCount();
            for (int i = 0; i < scrapCount; i++)
            {
                ViewHolder scrap = mRecycler.GetScrapViewAt(i);
                mChildHelper.RemoveView(scrap);
                mRecycler.RecycleView(scrap);
            }
            mRecycler.ClearScrap();
        }

        private void DispatchFocusChanged(int nextFocusPosition)
        {
            ViewHolder previousFocusView = FindViewHolderForAdapterPosition(mFocusedItemIndex);
            ViewHolder currentFocusView = FindViewHolderForAdapterPosition(nextFocusPosition);
            mAdapter.OnFocusChange(previousFocusView, currentFocusView);

            mFocusedItemIndex = nextFocusPosition;
        }

        private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
        {
            if (e.PanGesture.State == Gesture.StateType.Started)
            {

            }
            else if (e.PanGesture.State == Gesture.StateType.Continuing)
            {
                if (mLayout.CanScrollVertically())
                {
                    mLayout.ScrollVerticallyBy((int)e.PanGesture.Displacement.Y, mRecycler, mState);
                }
                else if (mLayout.CanScrollHorizontally())
                {
                    mLayout.ScrollHorizontallyBy((int)e.PanGesture.Displacement.X, mRecycler, mState);
                }
            }
            else if (e.PanGesture.State == Gesture.StateType.Finished)
            {

            }
        }


        private void OnItemEvent(object sender, Adapter.ItemEventArgs e)
        {
            switch (e.EventType)
            {
                case Adapter.ItemEventType.Insert:
                    mAdapteHelper.OnItemRangeInserted(e.param[0], e.param[1]);
                    break;
                case Adapter.ItemEventType.Remove:
                    mAdapteHelper.OnItemRangeRemoved(e.param[0], e.param[1]);
                    break;
                case Adapter.ItemEventType.Move:
                    break;
                case Adapter.ItemEventType.Change:
                    break;
                default:
                    return;
            }
            RelayoutRequest();
        }
        public abstract class Adapter
        {
            public abstract ViewHolder OnCreateViewHolder(int viewType);

            public abstract void OnBindViewHolder(ViewHolder holder, int position);

            public abstract int GetItemCount();

            public virtual int GetItemViewType(int position)
            {
                return 0;
            }

            /**
             * Called by RecyclerView when it starts observing this Adapter.
             * <p>
             * Keep in mind that same adapter may be observed by multiple RecyclerViews.
             *
             * @param recyclerView The RecyclerView instance which started observing this adapter.
             */
            public virtual void OnAttachedToRecyclerView(FlexibleView recyclerView)
            {
            }

            /**
             * Called by RecyclerView when it stops observing this Adapter.
             *
             * @param recyclerView The RecyclerView instance which stopped observing this adapter.
             */
            public virtual void OnDetachedFromRecyclerView(FlexibleView recyclerView)
            {
            }

            public virtual void OnFocusChange(ViewHolder previousFocus, ViewHolder currentFocus)
            {
            }

            /**
             * Called when a view created by this adapter has been recycled.
             * If an item view has large or expensive data bound to it such as large bitmaps, this may be a good place to release those resources
             */
            public virtual void OnViewRecycled(ViewHolder holder)
            {
            }

            public virtual void OnViewAttachedToWindow(ViewHolder holder)
            {
            }

            public virtual void OnViewDetachedFromWindow(ViewHolder holder)
            {
            }

            public void NotifyDataSetChanged()
            {
            }

            public void NotifyItemChanged(int index)
            {
                ItemEventArgs args = new ItemEventArgs
                {
                    EventType = ItemEventType.Change,
                };
                args.param[0] = index;
                args.param[1] = 1;
                OnItemEvent(this, args);
            }

            public void NotifyItemRangeChanged(int indexStart, int itemCount)
            {
            }

            public void NotifyItemInserted(int index)
            {
                ItemEventArgs args = new ItemEventArgs
                {
                    EventType = ItemEventType.Insert,
                };
                args.param[0] = index;
                args.param[1] = 1;
                OnItemEvent(this, args);
            }

            public void NotifyItemRangeInserted(int indexStart, int itemCount)
            {
            }

            public void NotifyItemRemoved(int index)
            {
                ItemEventArgs args = new ItemEventArgs
                {
                    EventType = ItemEventType.Remove,
                };
                args.param[0] = index;
                args.param[1] = 1;
                OnItemEvent(this, args);
            }

            public void NotifyItemRangeRemoved(int indexStart, int itemCount)
            {
            }

            public void NotifyItemMoved(int fromIndex, int toIndex)
            {
               
            }

            public enum ItemEventType
            {
                Insert = 0,
                Remove,
                Move,
                Change
            }

            public class ItemEventArgs : EventArgs
            {
                /// <summary>
                /// Data changed event type.
                /// </summary>
                public ItemEventType EventType
                {
                    get { return mType; }
                    set { mType = value; }
                }

                /// <summary>
                /// Changed data.
                /// </summary>
                public object data;

                /// <summary>
                /// Data change event parameters.
                /// </summary>
                public int[] param = new int[4];

                private ItemEventType mType;
            }

            public delegate void EventHandler<ItemEventArgs>(object sender, ItemEventArgs e);
            private EventHandler<ItemEventArgs> itemEventHandlers;
            /// <summary>
            /// Data changed event.
            /// </summary>
            public event EventHandler<ItemEventArgs> ItemEvent
            {
                add
                {
                    itemEventHandlers += value;
                }

                remove
                {
                    itemEventHandlers -= value;
                }
            }

            private void OnItemEvent(object sender, ItemEventArgs e)
            {
                itemEventHandlers?.Invoke(sender, e);
            }
        }

        public abstract class LayoutManager
        {
            private FlexibleView mFlexibleView;
            private ChildHelper mChildHelper;

            private Animation mAnimation;

            public abstract void OnLayoutChildren(Recycler recycler, ViewState state);

            public virtual void OnLayoutCompleted(ViewState state) { }

            public abstract void MoveFocus(string direction, Recycler recycler, ViewState state);

            public virtual bool CanScrollHorizontally()
            {
                return false;
            }

            public virtual bool CanScrollVertically()
            {
                return false;
            }

            public virtual float ScrollHorizontallyBy(float dy, Recycler recycler, ViewState state)
            {
                return 0;
            }

            public virtual float ScrollVerticallyBy(float dy, Recycler recycler, ViewState state)
            {
                return 0;
            }

            public virtual void ScrollToPosition(int position)
            {

            }

            public virtual void ScrollToPositionWithOffset(int position, int offset)
            {

            }

            /**
              * Calls {@code RecyclerView#RelayoutRequest} on the underlying RecyclerView
              */
            public void RelayoutRequest()
            {
                if (mFlexibleView != null)
                {
                    mFlexibleView.RelayoutRequest();
                }
            }

            public void LayoutChild(ViewHolder child, float left, float top, float width, float height)
            {
                //Console.WriteLine($"LayoutChild... position:{child.AdapterPosition} {left},{top} {width}*{height}");
                child.SizeWidth = width;
                child.SizeHeight = height;
                child.PositionX = left;
                child.PositionY = top;
            }

            public void ChangeFocus(int focusPosition)
            {
                if (mFlexibleView != null)
                {
                    mFlexibleView.DispatchFocusChanged(focusPosition);
                }
            }

            //public int GetItemCount()
            //{
            //    Adapter b = mFlexibleView != null ? mFlexibleView.mAdapter : null;

            //    return b != null ? b.GetItemCount() : 0;
            //}

            public int GetChildCount()
            {
                return mChildHelper != null ? mChildHelper.GetChildCount() : 0;
            }

            public ViewHolder GetChildAt(int index)
            {
                return mChildHelper != null ? mChildHelper.GetChildAt(index) : null;
            }

            public ViewHolder FindItemViewByPosition(int position)
            {
                return mFlexibleView.FindViewHolderForLayoutPosition(position);
            }

            public void OffsetChildrenHorizontal(float dx)
            {
                if (mChildHelper == null)
                {
                    return;
                }

                int childCount = mChildHelper.GetChildCount();
                for (int i = childCount - 1; i >= 0; i--)
                {
                    ViewHolder v = mChildHelper.GetChildAt(i);
                    v.PositionX += dx;
                    Console.WriteLine($"{i} AdapterPosition:{v.AdapterPosition} X:{v.PositionX}");
                }
            }

            public void OffsetChildrenVertical(float dy)
            {
                if (mChildHelper == null)
                {
                    return;
                }

                //if (mAnimation == null)
                //{
                //    mAnimation = new Animation(100);
                //}
                //else if (mAnimation.State == Animation.States.Playing)
                //{
                //    mAnimation.Stop(Animation.EndActions.Cancel);
                //}
                //mAnimation.Clear();

                int childCount = mChildHelper.GetChildCount();
                //Console.WriteLine($"OffsetChildrenVertical... dy:{dy} childCount:{childCount}");
                for (int i = childCount - 1; i >= 0; i--)
                {
                    ViewHolder v = mChildHelper.GetChildAt(i);
                    //Console.WriteLine($"v {v.AdapterPosition} {v.PositionY}");
                    //mAnimation.AnimateTo(v, "PositionY", v.PositionY + dy);
                    v.PositionY += dy;
                    //Console.WriteLine($"{i} AdapterPosition:{v.AdapterPosition} Y:{v.PositionY}");
                }
                //mAnimation.Play();
            }

            /**
            * Return the width of the parent RecyclerView
            *
            * @return Width in pixels
            */
            public float GetWidth()
            {
                return mFlexibleView != null ? mFlexibleView.SizeWidth : 0;
            }

            /**
             * Return the height of the parent RecyclerView
             *
             * @return Height in pixels
             */
            public float GetHeight()
            {
                return mFlexibleView != null ? mFlexibleView.SizeHeight : 0;
            }

            /**
             * Return the left padding of the parent RecyclerView
             *
             * @return Padding in pixels
             */
            public int GetPaddingLeft()
            {
                return mFlexibleView != null ? mFlexibleView.Padding.Start : 0;
            }

            /**
             * Return the top padding of the parent RecyclerView
             *
             * @return Padding in pixels
             */
            public int GetPaddingTop()
            {
                return mFlexibleView != null ? mFlexibleView.Padding.Top : 0;
            }

            /**
             * Return the right padding of the parent RecyclerView
             *
             * @return Padding in pixels
             */
            public int GetPaddingRight()
            {
                return mFlexibleView != null ? mFlexibleView.Padding.End : 0;
            }

            /**
             * Return the bottom padding of the parent RecyclerView
             *
             * @return Padding in pixels
             */
            public int GetPaddingBottom()
            {
                return mFlexibleView != null ? mFlexibleView.Padding.Bottom : 0;
            }

            public void AddView(ViewHolder holder, int index = -1)
            {
                mChildHelper.AddView(holder, index);
            }

            public void ScrapAttachedViews(Recycler recycler)
            {
                if (mChildHelper == null)
                {
                    return;
                }

                recycler.ClearScrap();

                //int childCount = mChildHelper.GetChildCount();
                //for (int i = childCount - 1; i >= 0; i--)
                //{
                //    ItemView v = mChildHelper.GetChildAt(i);
                //    ScrapOrRecycleView(recycler, i, v);
                //}

                mChildHelper.ScrapViews(recycler);
            }

            public void RemoveAndRecycleViewAt(int index, Recycler recycler)
            {
                ViewHolder v = mChildHelper.GetChildAt(index);
                mChildHelper.RemoveViewAt(index);
                recycler.RecycleView(v);
            }

            public void RecycleChildren(FlexibleView.Recycler recycler, int startIndex, int endIndex)
            {
                if (startIndex == endIndex)
                {
                    return;
                }
                //Console.WriteLine($"RecycleChildren startIndex: {startIndex} endIndex:{endIndex}");
                if (endIndex > startIndex)
                {
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        recycler.RecycleView(v);
                    }
                    mChildHelper.RemoveViewsRange(startIndex, endIndex - startIndex);
                }
                else
                {
                    for (int i = startIndex; i > endIndex; i--)
                    {
                        ViewHolder v = mChildHelper.GetChildAt(i);
                        recycler.RecycleView(v);
                    }
                    mChildHelper.RemoveViewsRange(endIndex + 1, startIndex - endIndex);
                }
            }

            private void ScrapOrRecycleView(Recycler recycler, int index, ViewHolder itemView)
            {
                recycler.ScrapView(itemView);
            }

            internal void SetRecyclerView(FlexibleView recyclerView)
            {
                mFlexibleView = recyclerView;
                mChildHelper = recyclerView.mChildHelper;
            }


        }

        public class ViewHolder
        {
            /**
             * This ViewHolder has been bound to a position; mPosition, mItemId and mItemViewType
             * are all valid.
             */
            static readonly int FLAG_BOUND = 1 << 0;

            /**
             * The data this ViewHolder's view reflects is stale and needs to be rebound
             * by the adapter. mPosition and mItemId are consistent.
             */
            static readonly int FLAG_UPDATE = 1 << 1;

            /**
             * This ViewHolder's data is invalid. The identity implied by mPosition and mItemId
             * are not to be trusted and may no longer match the item view type.
             * This ViewHolder must be fully rebound to different data.
             */
            static readonly int FLAG_INVALID = 1 << 2;

            /**
             * This ViewHolder points at data that represents an item previously removed from the
             * data set. Its view may still be used for things like outgoing animations.
             */
            static readonly int FLAG_REMOVED = 1 << 3;

            /**
             * This ViewHolder should not be recycled. This flag is set via setIsRecyclable()
             * and is intended to keep views around during animations.
             */
            static readonly int FLAG_NOT_RECYCLABLE = 1 << 4;

            /**
             * This ViewHolder is returned from scrap which means we are expecting an addView call
             * for this itemView. When returned from scrap, ViewHolder stays in the scrap list until
             * the end of the layout pass and then recycled by RecyclerView if it is not added back to
             * the RecyclerView.
             */
            static readonly int FLAG_RETURNED_FROM_SCRAP = 1 << 5;

            /**
             * This ViewHolder is fully managed by the LayoutManager. We do not scrap, recycle or remove
             * it unless LayoutManager is replaced.
             * It is still fully visible to the LayoutManager.
             */
            static readonly int FLAG_IGNORE = 1 << 7;

            private int mFlags;

            private View mItemView;

            private int mPosition = NO_POSITION;
            private int mOldPosition = NO_POSITION;
            private int mItemViewType = INVALID_TYPE;
            private int mPreLayoutPosition = NO_POSITION;

            private Vector4 mPadding = Vector4.Zero;
            private float mSizeWidth = 0;
            private float mSizeHeight = 0;
            private float mPositionX = 0;
            private float mPositionY = 0;

            private FlexibleView.Recycler mScrapContainer;

            public ViewHolder(View itemView)
            {
                if (itemView == null)
                {
                    throw new ArgumentNullException("itemView may not be null");
                }
                this.mItemView = itemView;
            }

            public View ItemView
            {
                get
                {
                    return mItemView;
                }
            }

            public Vector4 Padding
            {
                get
                {
                    return mPadding;
                }
                set
                {
                    mPadding = value;
                }
            }

            public float SizeWidth
            {
                get
                {
                    return mSizeWidth;
                }
                set
                {
                    mSizeWidth = value;

                    mItemView.SizeWidth = value - mPadding[0] - mPadding[2];
                }
            }

            public float SizeHeight
            {
                get
                {
                    return mSizeHeight;
                }
                set
                {
                    mSizeHeight = value;

                    mItemView.SizeHeight = value - mPadding[1] - mPadding[3];
                }
            }

            public float PositionX
            {
                get
                {
                    return mPositionX;
                }
                set
                {
                    mPositionX = value;

                    mItemView.PositionX = value + mPadding[0];
                }
            }

            public float PositionY
            {
                get
                {
                    return mPositionY;
                }
                set
                {
                    mPositionY = value;

                    mItemView.PositionY = value + mPadding[1];
                }
            }

            /// <summary>
            /// Get layout position of item view.
            /// </summary>
            public int LayoutPosition
            {
                get
                {
                    return mPreLayoutPosition == NO_POSITION ? mPosition : mPreLayoutPosition;
                }
                //internal set
                //{
                //    mPreLayoutPosition = value;
                //}
            }

            public int AdapterPosition
            {
                get
                {
                    return mPosition;
                }
                internal set
                {
                    mPosition = value;
                }
            }

            public int OldPosition
            {
                get
                {
                    return mOldPosition;
                }
                //internal set
                //{
                //    mOldPosition = value;
                //}
            }

            public int ItemViewType
            {
                get
                {
                    return mItemViewType;
                }
                set
                {
                    mItemViewType = value;
                }
            }

            public bool IsBound
            {
                get;
                set;
            }

            public bool IsScrap()
            {
                return mScrapContainer != null;
            }

            public Recycler ScrapContainer
            {
                get
                {
                    return mScrapContainer;
                }
                set
                {
                    mScrapContainer = value;
                }
            }

            public void Unscrap()
            {
                mScrapContainer.UnscrapView(this);
            }

            void SetFlags(int flags, int mask)
            {
                mFlags = (mFlags & ~mask) | (flags & mask);
            }

            void AddFlags(int flags)
            {
                mFlags |= flags;
            }


            internal void FlagRemovedAndOffsetPosition(int mNewPosition, int offset, bool applyToPreLayout)
            {
                AddFlags(ViewHolder.FLAG_REMOVED);
                OffsetPosition(offset, applyToPreLayout);
                mPosition = mNewPosition;
            }

            internal void OffsetPosition(int offset, bool applyToPreLayout)
            {
                if (mOldPosition == NO_POSITION)
                {
                    mOldPosition = mPosition;
                }
                if (mPreLayoutPosition == NO_POSITION)
                {
                    mPreLayoutPosition = mPosition;
                }
                if (applyToPreLayout)
                {
                    mPreLayoutPosition += offset;
                }
                mPosition += offset;
            }

            internal void ClearOldPosition()
            {
                mOldPosition = NO_POSITION;
                mPreLayoutPosition = NO_POSITION;
            }
            internal void SaveOldPosition()
            {
                if (mOldPosition == NO_POSITION)
                {
                    mOldPosition = mPosition;
                }
            }

        }

        private class ChildHelper
        {
            private FlexibleView mFlexibleView;
            //private List<ItemView> mScrapedViews = new List<ItemView>();
            private List<ViewHolder> mViewList = new List<ViewHolder>();

            //private Dictionary<ItemView, InfoRecord> mLayoutInfoMap = new Dictionary<ItemView, InfoRecord>();

            private List<ViewHolder> mRemovePendingViews;

            public ChildHelper(FlexibleView owner)
            {
                mFlexibleView = owner;
            }

            public void ScrapViews(Recycler recycler)
            {
                recycler.ClearScrap();
                foreach (ViewHolder itemView in mViewList)
                {
                    recycler.ScrapView(itemView);
                }

                mViewList.Clear();
            }

            public void AddView(ViewHolder holder, int index)
            {
                //Console.WriteLine($"ChildHelper.AddView {holder.AdapterPosition} to {index}");
                if (holder.IsScrap())
                {
                    holder.Unscrap();
                }
                if (index == -1)
                {
                    index = mViewList.Count;
                }
                mViewList.Insert(index, holder);

                mFlexibleView.Add(holder.ItemView);
            }

            public bool RemoveView(ViewHolder holder)
            {
                //Console.WriteLine($"ChildHelper.RemoveView {holder.AdapterPosition}");
                mFlexibleView.Remove(holder.ItemView);
                return mViewList.Remove(holder);
            }

            public bool RemoveViewAt(int index)
            {
                ViewHolder itemView = mViewList[index];
                return RemoveView(itemView);
            }

            public bool RemoveViewsRange(int index, int count)
            {
                for (int i = index; i < index + count; i++)
                {
                    ViewHolder holder = mViewList[i];
                    //Console.WriteLine($"ChildHelper.RemoveView {holder.AdapterPosition}");
                    mFlexibleView.Remove(holder.ItemView);
                }
                mViewList.RemoveRange(index, count);
                return false;
            }

            public int GetChildCount()
            {
                return mViewList.Count;
            }

            public ViewHolder GetChildAt(int index)
            {
                if (index < 0 || index >= mViewList.Count)
                {
                    return null;
                }
                return mViewList[index];
            }
        }

        private class AdapterHelper
        {
            private FlexibleView mFlexibleView;

            private List<UpdateOp> mPendingUpdates = new List<UpdateOp>();

            private int mExistingUpdateTypes = 0;

            public AdapterHelper(FlexibleView flexibleView)
            {
                mFlexibleView = flexibleView;
            }

            /**
             * @return True if updates should be processed.
             */
            public bool OnItemRangeInserted(int positionStart, int itemCount)
            {
                if (itemCount < 1)
                {
                    return false;
                }
                mPendingUpdates.Add(new UpdateOp(UpdateOp.ADD, positionStart, itemCount));
                mExistingUpdateTypes |= UpdateOp.ADD;
                return mPendingUpdates.Count == 1;
            }

            /**
             * @return True if updates should be processed.
             */
            public bool OnItemRangeRemoved(int positionStart, int itemCount)
            {
                if (itemCount < 1)
                {
                    return false;
                }
                mPendingUpdates.Add(new UpdateOp(UpdateOp.REMOVE, positionStart, itemCount));
                mExistingUpdateTypes |= UpdateOp.REMOVE;
                return mPendingUpdates.Count == 1;
            }

            public void PreProcess()
            {
                int count = mPendingUpdates.Count;
                for (int i = 0; i < count; i++)
                {
                    UpdateOp op = mPendingUpdates[i];
                    switch (op.cmd)
                    {
                        case UpdateOp.ADD:
                            mFlexibleView.OffsetPositionRecordsForInsert(op.positionStart, op.itemCount);
                            break;
                        case UpdateOp.REMOVE:
                            mFlexibleView.OffsetPositionRecordsForRemove(op.positionStart, op.itemCount, false);
                            break;
                        case UpdateOp.UPDATE:
                            break;
                        case UpdateOp.MOVE:
                            break;
                    }
                }
                mPendingUpdates.Clear();
            }

        }

        /**
 * Queued operation to happen when child views are updated.
 */
        private class UpdateOp
        {

            public const int ADD = 1;

            public const int REMOVE = 1 << 1;

            public const int UPDATE = 1 << 2;

            public const int MOVE = 1 << 3;

            public const int POOL_SIZE = 30;

            public int cmd;

            public int positionStart;

            // holds the target position if this is a MOVE
            public int itemCount;

            public UpdateOp(int cmd, int positionStart, int itemCount)
            {
                this.cmd = cmd;
                this.positionStart = positionStart;
                this.itemCount = itemCount;
            }

            public bool Equals(UpdateOp op)
            {
                if (cmd != op.cmd)
                {
                    return false;
                }
                if (cmd == MOVE && Math.Abs(itemCount - positionStart) == 1)
                {
                    // reverse of this is also true
                    if (itemCount == op.positionStart && positionStart == op.itemCount)
                    {
                        return true;
                    }
                }
                if (itemCount != op.itemCount)
                {
                    return false;
                }
                if (positionStart != op.positionStart)
                {
                    return false;
                }

                return true;
            }

            public int HashCode()
            {
                int result = cmd;
                result = 31 * result + positionStart;
                result = 31 * result + itemCount;
                return result;
            }

        }

        //private class ViewInfoStore
        //{
        //}
        private class InfoRecord
        {
            public static readonly int FLAG_DISAPPEARED = 1;
            public static readonly int FLAG_APPEAR = 1 << 1;


            public ItemViewInfo preInfo;
            public ItemViewInfo postInfo;
        }

        private class ItemViewInfo
        {
            public float Left
            {
                get;
                set;
            }
            public float Top
            {
                get;
                set;
            }
            public float Right
            {
                get;
                set;
            }
            public float Bottom
            {
                get;
                set;
            }
        }


        public class ViewState
        {
            static readonly int STEP_START = 1;
            static readonly int STEP_LAYOUT = 1 << 1;
            static readonly int STEP_ANIMATIONS = 1 << 2;

            private FlexibleView mFlexibleView;

            public int mLayoutStep = STEP_START;
            /**
            * Number of items adapter had in the previous layout.
            */
            //public int mPreviousLayoutItemCount = 0;
            /**
             * Number of items adapter has.
             */
            //public int mItemCount = 0;
            /**
             * This data is saved before a layout calculation happens. After the layout is finished,
             * if the previously focused view has been replaced with another view for the same item, we
             * move the focus to the new item automatically.
             */

            private bool mInPreLayout = false;

            public ViewState(FlexibleView flexibleView)
            {
                mFlexibleView = flexibleView;
            }

            public int FocusPosition
            {
                get
                {
                    return mFlexibleView.mFocusedItemIndex;
                }
            }

            public int ItemCount
            {
                get
                {
                    Adapter b = mFlexibleView != null ? mFlexibleView.mAdapter : null;

                    return b != null ? b.GetItemCount() : 0;
                }
            }

            public bool IsPreLayout()
            {
                return mInPreLayout;
            }


        }



        public class Recycler
        {
            private FlexibleView mRecyclerView;
            private RecycledViewPool mRecyclerPool;

            private List<ViewHolder> mAttachedScrap = new List<ViewHolder>();
            private List<ViewHolder> mChangedScrap = null;
            //private List<ItemView> mCachedViews = new List<ItemView>();

            private List<ViewHolder> mUnmodifiableAttachedScrap;

            private int mCacheSizeMax = 2;

            public Recycler(FlexibleView recyclerView)
            {
                mRecyclerView = recyclerView;
            }

            public void SetViewCacheSize(int viewCount)
            {
                mCacheSizeMax = viewCount;
            }

            internal void SetRecycledViewPool(RecycledViewPool pool)
            {
                mRecyclerPool = pool;
            }         

            public ViewHolder GetViewForPosition(int position)
            {
                Adapter b = mRecyclerView != null ? mRecyclerView.mAdapter : null;
                if (b == null)
                {
                    return null;
                }
                if (position < 0 || position >= b.GetItemCount())
                {
                    return null;
                }

                int type = b.GetItemViewType(position);
                ViewHolder itemView = null;
                for (int i = 0; i < mAttachedScrap.Count; i++)
                {
                    if (mAttachedScrap[i].LayoutPosition == position && mAttachedScrap[i].ItemViewType == type)
                    {
                        itemView = mAttachedScrap[i];
                        break;
                    }
                }
                if (itemView == null)
                {
                    itemView = mRecyclerPool.GetRecycledView(type);
                    if (itemView == null)
                    {
                        itemView = b.OnCreateViewHolder(type);
                    }

                    if (!itemView.IsBound)
                    {
                        b.OnBindViewHolder(itemView, position);
                        itemView.IsBound = true;
                    }

                    itemView.AdapterPosition = position;
                    itemView.ItemViewType = type;
                }

                return itemView;
            }

            public void ScrapView(ViewHolder itemView)
            {
                //Console.WriteLine($"Recycler.ScrapView itemView:{itemView.AdapterPosition}");
                mAttachedScrap.Add(itemView);
                itemView.ScrapContainer = this;
            }

            public void UnscrapView(ViewHolder itemView)
            {
                //Console.WriteLine($"Recycler.UnscrapView itemView:{itemView.AdapterPosition}");
                mAttachedScrap.Remove(itemView);
                itemView.ScrapContainer = null;
            }

            public void RecycleView(ViewHolder itemView)
            {
                //Console.WriteLine($"Recycler.RecycleView itemView:{itemView.AdapterPosition}");
                itemView.ScrapContainer = null;
                mRecyclerPool.PutRecycledView(itemView);
            }

            public int GetScrapCount()
            {
                return mAttachedScrap.Count;
            }

            public ViewHolder GetScrapViewAt(int index)
            {
                return mAttachedScrap[index];
            }

            public void ClearScrap()
            {
                mAttachedScrap.Clear();
                if (mChangedScrap != null)
                {
                    mChangedScrap.Clear();
                }
            }
        }

        internal class RecycledViewPool
        {
            private int mMaxTypeCount = 10;
            private List<ViewHolder>[] mScrap;

            public RecycledViewPool()
            {
                mScrap = new List<ViewHolder>[mMaxTypeCount];
            }

            //public void SetViewTypeCount(int typeCount)
            //{
            //}

            public ViewHolder GetRecycledView(int viewType)
            {
                if (viewType >= mMaxTypeCount || mScrap[viewType] == null)
                {
                    return null;
                }

                int index = mScrap[viewType].Count - 1;
                if (index < 0)
                {
                    return null;
                }
                ViewHolder recycledView = mScrap[viewType][index];
                mScrap[viewType].RemoveAt(index);

                return recycledView;
            }

            public void PutRecycledView(ViewHolder view)
            {
                int viewType = view.ItemViewType;
                if (mScrap[viewType] == null)
                {
                    mScrap[viewType] = new List<ViewHolder>();
                }
                view.IsBound = false;
                mScrap[viewType].Add(view);
            }

            public void Clear()
            {

            }
        }

    }
}
