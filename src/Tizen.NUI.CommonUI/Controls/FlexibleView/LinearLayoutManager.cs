using System;
using System.ComponentModel;

namespace Tizen.NUI.CommonUI
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LinearLayoutManager : FlexibleView.LayoutManager
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int HORIZONTAL = OrientationHelper.HORIZONTAL;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int VERTICAL = OrientationHelper.VERTICAL;
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly int NO_POSITION = FlexibleView.NO_POSITION;

        public static readonly int INVALID_OFFSET = -2147483648;

        private static readonly float MAX_SCROLL_FACTOR = 1 / 3f;

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int mOrientation;

        internal OrientationHelper mOrientationHelper;

        private LayoutState mLayoutState;
        private AnchorInfo mAnchorInfo = new AnchorInfo();

        /**
     * Stashed to avoid allocation, currently only used in #fill()
     */
        private LayoutChunkResult mLayoutChunkResult = new LayoutChunkResult();

        private bool mShouldReverseLayout = false;


        /**
         * When LayoutManager needs to scroll to a position, it sets this variable and requests a
         * layout which will check this variable and re-layout accordingly.
         */
        private int mPendingScrollPosition = NO_POSITION;

        /**
         * Used to keep the offset value when {@link #scrollToPositionWithOffset(int, int)} is
         * called.
         */
        private int mPendingScrollPositionOffset = INVALID_OFFSET;

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LinearLayoutManager(int orientation)
        {
            mOrientation = orientation;
            mOrientationHelper = OrientationHelper.createOrientationHelper(this, mOrientation);

            mLayoutState = new LayoutState();
            mLayoutState.Offset = mOrientationHelper.GetStartAfterPadding();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool CanScrollHorizontally()
        {
            return mOrientation == HORIZONTAL;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool CanScrollVertically()
        {
            return mOrientation == VERTICAL;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnLayoutChildren(FlexibleView.Recycler recycler, FlexibleView.ViewState state)
        {
            mLayoutState.Recycle = false;
            if (!mAnchorInfo.Valid || mPendingScrollPosition != NO_POSITION)
            {
                mAnchorInfo.Reset();
                mAnchorInfo.LayoutFromEnd = mShouldReverseLayout;
                // calculate anchor position and coordinate
                UpdateAnchorInfoForLayout(recycler, state, mAnchorInfo);
                mAnchorInfo.Valid = true;
            }

            ScrapAttachedViews(recycler);

            if (mAnchorInfo.LayoutFromEnd == true)
            {
                UpdateLayoutStateToFillStart(mAnchorInfo.Position, mAnchorInfo.Coordinate);
                Fill(recycler, mLayoutState, state, false, true);

                UpdateLayoutStateToFillEnd(mAnchorInfo.Position, mAnchorInfo.Coordinate);
                mLayoutState.CurrentPosition += mLayoutState.ItemDirection;
                Fill(recycler, mLayoutState, state, false, true);
            }
            else
            {
                UpdateLayoutStateToFillEnd(mAnchorInfo.Position, mAnchorInfo.Coordinate);
                Fill(recycler, mLayoutState, state, false, true);

                UpdateLayoutStateToFillStart(mAnchorInfo.Position, mAnchorInfo.Coordinate);
                mLayoutState.CurrentPosition += mLayoutState.ItemDirection;
                Fill(recycler, mLayoutState, state, false, true);
            }

            OnLayoutCompleted(state);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ScrollHorizontallyBy(float dx, FlexibleView.Recycler recycler, FlexibleView.ViewState state, bool immediate)
        {
            if (mOrientation == VERTICAL)
            {
                return 0;
            }
            return ScrollBy(dx, recycler, state, immediate);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ScrollVerticallyBy(float dy, FlexibleView.Recycler recycler, FlexibleView.ViewState state, bool immediate)
        {
            if (mOrientation == HORIZONTAL)
            {
                return 0;
            }
            return ScrollBy(dy, recycler, state, immediate); ;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ComputeScrollOffset(FlexibleView.ViewState state)
        {
            FlexibleView.ViewHolder startChild = FindFirstVisibleItemView();
            FlexibleView.ViewHolder endChild = FindLastVisibleItemView();
            if (GetChildCount() == 0 || startChild == null || endChild == null)
            {
                return 0;
            }
            int minPosition = Math.Min(startChild.LayoutPosition, endChild.LayoutPosition);
            int maxPosition = Math.Max(startChild.LayoutPosition, endChild.LayoutPosition);
            int itemsBefore = mShouldReverseLayout
                    ? Math.Max(0, state.ItemCount - maxPosition - 1)
                    : Math.Max(0, minPosition);

            float laidOutArea = Math.Abs(mOrientationHelper.GetViewHolderEnd(endChild)
                   - mOrientationHelper.GetViewHolderStart(startChild));
            int itemRange = Math.Abs(startChild.LayoutPosition - endChild.LayoutPosition) + 1;
            float avgSizePerRow = laidOutArea / itemRange;

            return (float)Math.Round(itemsBefore * avgSizePerRow + (mOrientationHelper.GetStartAfterPadding()
                    - mOrientationHelper.GetViewHolderStart(startChild)));
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ComputeScrollExtent(FlexibleView.ViewState state)
        {
            FlexibleView.ViewHolder startChild = FindFirstVisibleItemView();
            FlexibleView.ViewHolder endChild = FindLastVisibleItemView();
            if (GetChildCount() == 0 || startChild == null || endChild == null)
            {
                return 0;
            }
            float extend = mOrientationHelper.GetViewHolderEnd(endChild)
                - mOrientationHelper.GetViewHolderStart(startChild);
            return Math.Min(mOrientationHelper.GetTotalSpace(), extend);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ComputeScrollRange(FlexibleView.ViewState state)
        {
            FlexibleView.ViewHolder startChild = FindFirstVisibleItemView();
            FlexibleView.ViewHolder endChild = FindLastVisibleItemView();
            if (GetChildCount() == 0 || startChild == null || endChild == null)
            {
                return 0;
            }
            float laidOutArea = mOrientationHelper.GetViewHolderEnd(endChild)
                    - mOrientationHelper.GetViewHolderStart(startChild);
            int laidOutRange = Math.Abs(startChild.LayoutPosition - endChild.LayoutPosition) + 1;
            // estimate a size for full list.
            return laidOutArea / laidOutRange * state.ItemCount;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FindFirstVisibleItemPosition()
        {
            FlexibleView.ViewHolder child = FindFirstVisibleItemView();
            return child == null ? NO_POSITION : child.LayoutPosition;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FindFirstCompleteVisibleItemPosition()
        {
            FlexibleView.ViewHolder child = FindFirstCompleteVisibleItemView();
            return child == null ? NO_POSITION : child.LayoutPosition;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FindLastVisibleItemPosition()
        {
            FlexibleView.ViewHolder child = FindLastVisibleItemView();
            return child == null ? NO_POSITION : child.LayoutPosition;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int FindLastCompleteVisibleItemPosition()
        {
            FlexibleView.ViewHolder child = FindLastCompleteVisibleItemView();
            return child == null ? NO_POSITION : child.LayoutPosition;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ScrollToPosition(int position)
        {
            mPendingScrollPosition = position;
            mPendingScrollPositionOffset = INVALID_OFFSET;

            RelayoutRequest();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ScrollToPositionWithOffset(int position, int offset)
        {
            mPendingScrollPosition = position;
            mPendingScrollPositionOffset = offset;

            RelayoutRequest();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnLayoutCompleted(FlexibleView.ViewState state)
        {
            if (mPendingScrollPosition != NO_POSITION)
            {
                ChangeFocus(mPendingScrollPosition);
            }
            mPendingScrollPosition = NO_POSITION;
            mPendingScrollPositionOffset = INVALID_OFFSET;

            mAnchorInfo.Reset();
        }


        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override int GetNextPosition(int position, string direction, FlexibleView.ViewState state)
        {
            if (mOrientation == HORIZONTAL)
            {
                switch (direction)
                {
                    case "Left":
                        if (position > 0)
                        {
                            return position - 1;
                        }
                        break;
                    case "Right":
                        if (position < state.ItemCount - 1)
                        {
                            return position + 1;
                        }
                        break;
                }
            }
            else
            {
                switch (direction)
                {
                    case "Up":
                        if (position > 0)
                        {
                            return position - 1;
                        }
                        break;
                    case "Down":
                        if (position < state.ItemCount - 1)
                        {
                            return position + 1;
                        }
                        break;
                }
            }

            return NO_POSITION;
        }

        internal virtual void LayoutChunk(FlexibleView.Recycler recycler, FlexibleView.ViewState state,
            LayoutState layoutState, LayoutChunkResult result)
        {
            FlexibleView.ViewHolder holder = layoutState.Next(recycler);
            if (holder == null)
            {
                // if we are laying out views in scrap, this may return null which means there is
                // no more items to layout.
                result.Finished = true;
                return;
            }

            if (mShouldReverseLayout == (layoutState.LayoutDirection == LayoutState.LAYOUT_START))
                AddView(holder);
            else
                AddView(holder, 0);

            result.Consumed = mOrientationHelper.GetViewHolderMeasurement(holder);

            float left, top, width, height;
            if (mOrientation == VERTICAL)
            {
                width = GetWidth() - GetPaddingLeft() - GetPaddingRight();
                height = result.Consumed;
                left = GetPaddingLeft();
                if (layoutState.LayoutDirection == LayoutState.LAYOUT_END)
                {
                    top = layoutState.Offset;
                }
                else
                {
                    top = layoutState.Offset - height;
                }
                LayoutChild(holder, left, top, width, height);
            }
            else
            {
                width = result.Consumed;
                height = GetHeight() - GetPaddingTop() - GetPaddingBottom();
                top = GetPaddingTop();
                if (layoutState.LayoutDirection == LayoutState.LAYOUT_END)
                {
                    left = layoutState.Offset;
                }
                else
                {
                    left = layoutState.Offset - width;
                }
                LayoutChild(holder, left, top, width, height);
            }

            result.Focusable = true;
        }

        internal override FlexibleView.ViewHolder OnFocusSearchFailed(FlexibleView.ViewHolder focused, string direction, FlexibleView.Recycler recycler, FlexibleView.ViewState state)
        {
            if (GetChildCount() == 0)
            {
                return null;
            }
            int layoutDir = ConvertFocusDirectionToLayoutDirection(direction);
            if (layoutDir == LayoutState.INVALID_LAYOUT)
            {
                return null;
            }
            int maxScroll = (int)(MAX_SCROLL_FACTOR * mOrientationHelper.GetTotalSpace());
            UpdateLayoutState(layoutDir, maxScroll, false, state);
            mLayoutState.ScrollingOffset = LayoutState.SCROLLING_OFFSET_NaN;
            mLayoutState.Recycle = false;
            Fill(recycler, mLayoutState, state, true, true);

            FlexibleView.ViewHolder nextFocus;
            if (layoutDir == LayoutState.LAYOUT_START)
            {
                nextFocus = GetChildAt(0);
            }
            else
            {
                nextFocus = GetChildAt(GetChildCount() - 1);
            }
            return nextFocus;
        }


        private void UpdateAnchorInfoForLayout(FlexibleView.Recycler recycler, FlexibleView.ViewState state, AnchorInfo anchorInfo)
        {
            if (UpdateAnchorFromPendingData(state, anchorInfo))
            {
                return;
            }

            if (UpdateAnchorFromChildren(recycler, state, anchorInfo))
            {
                return;
            }

            anchorInfo.Position = state.FocusPosition != NO_POSITION ? state.FocusPosition : 0;
            anchorInfo.Coordinate = anchorInfo.LayoutFromEnd ? mOrientationHelper.GetEndAfterPadding() : mOrientationHelper.GetStartAfterPadding();
        }

        /**
         * If there is a pending scroll position or saved states, updates the anchor info from that
         * data and returns true
         */
        private bool UpdateAnchorFromPendingData(FlexibleView.ViewState state, AnchorInfo anchorInfo)
        {
            if (state.IsPreLayout() || mPendingScrollPosition == NO_POSITION)
            {
                return false;
            }
            // validate scroll position
            if (mPendingScrollPosition < 0 || mPendingScrollPosition >= state.ItemCount)
            {
                mPendingScrollPosition = NO_POSITION;
                mPendingScrollPositionOffset = INVALID_OFFSET;
                return false;
            }

            anchorInfo.Position = mPendingScrollPosition;

            if (mPendingScrollPositionOffset == INVALID_OFFSET)
            {
                anchorInfo.Coordinate = anchorInfo.LayoutFromEnd ? mOrientationHelper.GetEndAfterPadding() : mOrientationHelper.GetStartAfterPadding();
            }
            else
            {
                if (mShouldReverseLayout)
                {
                    anchorInfo.Coordinate = mOrientationHelper.GetEndAfterPadding()
                            - mPendingScrollPositionOffset;
                }
                else
                {
                    anchorInfo.Coordinate = mOrientationHelper.GetStartAfterPadding()
                            + mPendingScrollPositionOffset;
                }
            }
            return true;
        }

        /**
         * Finds an anchor child from existing Views. Most of the time, this is the view closest to
         * start or end that has a valid position (e.g. not removed).
         * <p>
         * If a child has focus, it is given priority.
         */
        private bool UpdateAnchorFromChildren(FlexibleView.Recycler recycler,
                FlexibleView.ViewState state, AnchorInfo anchorInfo)
        {
            if (GetChildCount() == 0)
            {
                return false;
            }

            FlexibleView.ViewHolder anchorChild = FindFirstCompleteVisibleItemView();
            anchorInfo.Position = anchorChild.LayoutPosition;
            anchorInfo.Coordinate = mOrientationHelper.GetViewHolderStart(anchorChild);

            return true;
        }

        /**
         * Converts a focusDirection to orientation.
         *
         * @param focusDirection One of {@link View#FOCUS_UP}, {@link View#FOCUS_DOWN},
         *                       {@link View#FOCUS_LEFT}, {@link View#FOCUS_RIGHT},
         *                       {@link View#FOCUS_BACKWARD}, {@link View#FOCUS_FORWARD}
         *                       or 0 for not applicable
         * @return {@link LayoutState#LAYOUT_START} or {@link LayoutState#LAYOUT_END} if focus direction
         * is applicable to current state, {@link LayoutState#INVALID_LAYOUT} otherwise.
         */
        private int ConvertFocusDirectionToLayoutDirection(string focusDirection)
        {
            switch (focusDirection)
            {
                case "Up":
                    return mOrientation == VERTICAL ? LayoutState.LAYOUT_START
                            : LayoutState.INVALID_LAYOUT;
                case "Down":
                    return mOrientation == VERTICAL ? LayoutState.LAYOUT_END
                            : LayoutState.INVALID_LAYOUT;
                case "Left":
                    return mOrientation == HORIZONTAL ? LayoutState.LAYOUT_START
                            : LayoutState.INVALID_LAYOUT;
                case "Right":
                    return mOrientation == HORIZONTAL ? LayoutState.LAYOUT_END
                            : LayoutState.INVALID_LAYOUT;
                default:                    
                    return LayoutState.INVALID_LAYOUT;
            }

        }


        private float Fill(FlexibleView.Recycler recycler, LayoutState layoutState, FlexibleView.ViewState state, bool stopOnFocusable, bool immediate)
        {
            float start = layoutState.Available;
            if (layoutState.ScrollingOffset != LayoutState.SCROLLING_OFFSET_NaN)
            {
                // TODO ugly bug fix. should not happen
                if (layoutState.Available < 0)
                {
                    layoutState.ScrollingOffset += layoutState.Available;
                }
                if (immediate == true)
                {
                    RecycleByLayoutState(recycler, layoutState, true);
                }
            }
            float remainingSpace = layoutState.Available + layoutState.Extra;
            LayoutChunkResult layoutChunkResult = mLayoutChunkResult;
            while ((remainingSpace > 0) && layoutState.HasMore(state))
            {
                layoutChunkResult.ResetInternal();
                LayoutChunk(recycler, state, layoutState, layoutChunkResult);
                if (layoutChunkResult.Finished)
                {
                    break;
                }
                layoutState.Offset += layoutChunkResult.Consumed * layoutState.LayoutDirection;
                /**
                 * Consume the available space if:
                 * * layoutChunk did not request to be ignored
                 * * OR we are laying out scrap children
                 * * OR we are not doing pre-layout
                 */
                if (!layoutChunkResult.IgnoreConsumed || !state.IsPreLayout())
                {
                    layoutState.Available -= layoutChunkResult.Consumed;
                    // we keep a separate remaining space because mAvailable is important for recycling
                    remainingSpace -= layoutChunkResult.Consumed;
                }

                if (layoutState.ScrollingOffset != LayoutState.SCROLLING_OFFSET_NaN)
                {
                    layoutState.ScrollingOffset += layoutChunkResult.Consumed;
                    if (layoutState.Available < 0)
                    {
                        layoutState.ScrollingOffset += layoutState.Available;
                    }
                    if (immediate == true)
                    {
                        RecycleByLayoutState(recycler, layoutState, true);
                    }
                }
                if (stopOnFocusable && layoutChunkResult.Focusable)
                {
                    break;
                }
            }
            if (immediate == false)
            {
                RecycleByLayoutState(recycler, layoutState, false);
            }

            return start - layoutState.Available;
        }

        private void RecycleByLayoutState(FlexibleView.Recycler recycler, LayoutState layoutState, bool immediate)
        {
            if (!layoutState.Recycle)
            {
                return;
            }
            if (layoutState.LayoutDirection == LayoutState.LAYOUT_START)
            {
                RecycleViewsFromEnd(recycler, layoutState.ScrollingOffset, immediate);
            }
            else
            {
                RecycleViewsFromStart(recycler, layoutState.ScrollingOffset, immediate);
            }
        }

        private void RecycleViewsFromStart(FlexibleView.Recycler recycler, float dt, bool immediate)
        {
            if (dt < 0)
            {
                return;
            }
            // ignore padding, ViewGroup may not clip children.
            float limit = dt;
            int childCount = GetChildCount();
            if (mShouldReverseLayout)
            {
                for (int i = childCount - 1; i >= 0; i--)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if (mOrientationHelper.GetViewHolderEnd(child) > limit)
                    {
                        // stop here
                        RecycleChildren(recycler, childCount - 1, i, immediate);
                        return;
                    }
                }
            }
            else
            {
                for (int i = 0; i < childCount; i++)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if (mOrientationHelper.GetViewHolderEnd(child) > limit)
                    {
                        // stop here
                        RecycleChildren(recycler, 0, i, immediate);
                        return;
                    }
                }
            }
        }

        private void RecycleViewsFromEnd(FlexibleView.Recycler recycler, float dt, bool immediate)
        {
            int childCount = GetChildCount();
            if (dt < 0)
            {
                return;
            }
            float limit = mOrientationHelper.GetEnd() - dt;
            if (mShouldReverseLayout)
            {
                for (int i = 0; i < childCount; i++)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if (mOrientationHelper.GetViewHolderStart(child) < limit)
                    {
                        // stop here
                        RecycleChildren(recycler, 0, i, immediate);
                        return;
                    }
                }
            }
            else
            {
                for (int i = childCount - 1; i >= 0; i--)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if (mOrientationHelper.GetViewHolderStart(child) < limit)
                    {
                        // stop here
                        RecycleChildren(recycler, childCount - 1, i, immediate);
                        return;
                    }
                }
            }
        }

        private float ScrollBy(float dy, FlexibleView.Recycler recycler, FlexibleView.ViewState state, bool immediate)
        {
            if (GetChildCount() == 0 || dy == 0)
            {
                return 0;
            }
            mLayoutState.Recycle = true;
            int layoutDirection = dy < 0 ? LayoutState.LAYOUT_END : LayoutState.LAYOUT_START;
            float absDy = Math.Abs(dy);
            UpdateLayoutState(layoutDirection, absDy, true, state);
            float consumed = mLayoutState.ScrollingOffset 
                + Fill(recycler, mLayoutState, state, false, immediate);

            if (consumed < 0)
            {
                return 0;
            }

            float scrolled = absDy > consumed ? -layoutDirection * consumed : dy;

            mOrientationHelper.OffsetChildren(scrolled, immediate);


            return scrolled;
        }

        private void UpdateLayoutState(int layoutDirection, float requiredSpace, bool canUseExistingSpace, FlexibleView.ViewState state)
        {
            mLayoutState.Extra = 0;
            mLayoutState.LayoutDirection = layoutDirection;
            float scrollingOffset;
            if (layoutDirection == LayoutState.LAYOUT_END)
            {
                mLayoutState.Extra += mOrientationHelper.GetEndPadding();
                // get the first child in the direction we are going
                FlexibleView.ViewHolder child = GetChildClosestToEnd();
                // the direction in which we are traversing children
                mLayoutState.ItemDirection = mShouldReverseLayout ? LayoutState.ITEM_DIRECTION_HEAD
                        : LayoutState.ITEM_DIRECTION_TAIL;
                mLayoutState.CurrentPosition = child.LayoutPosition + mLayoutState.ItemDirection;
                mLayoutState.Offset = mOrientationHelper.GetViewHolderEnd(child);
                // calculate how much we can scroll without adding new children (independent of layout)
                scrollingOffset = mOrientationHelper.GetViewHolderEnd(child)
                        - mOrientationHelper.GetEndAfterPadding();

            }
            else
            {
                mLayoutState.Extra += mOrientationHelper.GetStartAfterPadding();
                FlexibleView.ViewHolder child = GetChildClosestToStart();
                mLayoutState.ItemDirection = mShouldReverseLayout ? LayoutState.ITEM_DIRECTION_TAIL
                        : LayoutState.ITEM_DIRECTION_HEAD;
                mLayoutState.CurrentPosition = child.LayoutPosition + mLayoutState.ItemDirection;
                mLayoutState.Offset = mOrientationHelper.GetViewHolderStart(child);
                scrollingOffset = -mOrientationHelper.GetViewHolderStart(child)
                        + mOrientationHelper.GetStartAfterPadding();
            }
            mLayoutState.Available = requiredSpace;
            if (canUseExistingSpace)
            {
                mLayoutState.Available -= scrollingOffset;
            }
            mLayoutState.ScrollingOffset = scrollingOffset;

        }
        /**
         * Convenience method to find the child closes to start. Caller should check it has enough
         * children.
         *
         * @return The child closes to start of the layout from user's perspective.
         */
        private FlexibleView.ViewHolder GetChildClosestToStart()
        {
            return GetChildAt(mShouldReverseLayout ? GetChildCount() - 1 : 0);
        }

        /**
         * Convenience method to find the child closes to end. Caller should check it has enough
         * children.
         *
         * @return The child closes to end of the layout from user's perspective.
         */
        private FlexibleView.ViewHolder GetChildClosestToEnd()
        {
            return GetChildAt(mShouldReverseLayout ? 0 : GetChildCount() - 1);
        }

        private void UpdateLayoutStateToFillEnd(int itemPosition, float offset)
        {
            mLayoutState.Available = mOrientationHelper.GetEndAfterPadding() - offset;
            mLayoutState.ItemDirection = mShouldReverseLayout ? LayoutState.ITEM_DIRECTION_HEAD :
                    LayoutState.ITEM_DIRECTION_TAIL;
            mLayoutState.CurrentPosition = itemPosition;
            mLayoutState.LayoutDirection = LayoutState.LAYOUT_END;
            mLayoutState.Offset = offset;
            mLayoutState.ScrollingOffset = LayoutState.SCROLLING_OFFSET_NaN;
            mLayoutState.Extra = mOrientationHelper.GetEndPadding();
        }

        private void UpdateLayoutStateToFillStart(int itemPosition, float offset)
        {
            mLayoutState.Available = offset - mOrientationHelper.GetStartAfterPadding();
            mLayoutState.CurrentPosition = itemPosition;
            mLayoutState.ItemDirection = mShouldReverseLayout ? LayoutState.ITEM_DIRECTION_TAIL :
                    LayoutState.ITEM_DIRECTION_HEAD;
            mLayoutState.LayoutDirection = LayoutState.LAYOUT_START;
            mLayoutState.Offset = offset;
            mLayoutState.ScrollingOffset = LayoutState.SCROLLING_OFFSET_NaN;
            mLayoutState.Extra = mOrientationHelper.GetStartAfterPadding();
        }

        private FlexibleView.ViewHolder FindFirstVisibleItemView()
        {
            int childCount = GetChildCount();
            if (mShouldReverseLayout == false)
            {
                for (int i = 0; i < childCount; i++)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if ((int)mOrientationHelper.GetViewHolderEnd(child) > 0)
                    {
                        return child;
                    }
                }
            }
            else
            {
                for (int i = childCount - 1; i >= 0; i--)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if ((int)mOrientationHelper.GetViewHolderEnd(child) > 0)
                    {
                        return child;
                    }
                }
            }
            return null;
        }

        private FlexibleView.ViewHolder FindFirstCompleteVisibleItemView()
        {
            int childCount = GetChildCount();
            if (mShouldReverseLayout == false)
            {
                for (int i = 0; i < childCount; i++)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if ((int)mOrientationHelper.GetViewHolderStart(child) > 0)
                    {
                        return child;
                    }
                }
            }
            else
            {
                for (int i = childCount - 1; i >= 0; i--)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if ((int)mOrientationHelper.GetViewHolderStart(child) > 0)
                    {
                        return child;
                    }
                }
            }
            return null;
        }

        private FlexibleView.ViewHolder FindLastVisibleItemView()
        {
            int childCount = GetChildCount();
            if (mShouldReverseLayout == false)
            {
                for (int i = childCount - 1; i >= 0; i--)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if ((int)mOrientationHelper.GetViewHolderStart(child) < (int)mOrientationHelper.GetEnd())
                    {
                        return child;
                    }
                }
            }
            else
            {
                for (int i = 0; i < childCount; i++)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if ((int)mOrientationHelper.GetViewHolderStart(child) < (int)mOrientationHelper.GetEnd())
                    {
                        return child;
                    }
                }
            }
            return null;
        }

        private FlexibleView.ViewHolder FindLastCompleteVisibleItemView()
        {
            int childCount = GetChildCount();
            if (mShouldReverseLayout == false)
            {
                for (int i = childCount - 1; i >= 0; i--)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if ((int)mOrientationHelper.GetViewHolderEnd(child) < (int)mOrientationHelper.GetEnd())
                    {
                        return child;
                    }
                }
            }
            else
            {
                for (int i = 0; i < childCount; i++)
                {
                    FlexibleView.ViewHolder child = GetChildAt(i);
                    if ((int)mOrientationHelper.GetViewHolderEnd(child) < (int)mOrientationHelper.GetEnd())
                    {
                        return child;
                    }
                }
            }
            return null;
        }


        /**
         * Helper class that keeps temporary state while {LayoutManager} is filling out the empty space.
         **/
        internal class LayoutState
        {
            public static readonly int LAYOUT_START = -1;

            public static readonly int LAYOUT_END = 1;

            public static readonly int INVALID_LAYOUT = -1000;

            public static readonly int ITEM_DIRECTION_HEAD = -1;

            public static readonly int ITEM_DIRECTION_TAIL = 1;

            public static readonly int SCROLLING_OFFSET_NaN = -10000;

            /**
             * We may not want to recycle children in some cases (e.g. layout)
             */
            public bool Recycle = true;

            /**
             * Pixel offset where layout should start
             */
            public float Offset;

            /**
             * Number of pixels that we should fill, in the layout direction.
             */
            public float Available;

            /**
             * Current position on the adapter to get the next item.
             */
            public int CurrentPosition;

            /**
             * Defines the direction in which the data adapter is traversed.
             * Should be {@link #ITEM_DIRECTION_HEAD} or {@link #ITEM_DIRECTION_TAIL}
             */
            public int ItemDirection;

            /**
             * Defines the direction in which the layout is filled.
             * Should be {@link #LAYOUT_START} or {@link #LAYOUT_END}
             */
            public int LayoutDirection;

            /**
             * Used when LayoutState is constructed in a scrolling state.
             * It should be set the amount of scrolling we can make without creating a new view.
             * Settings this is required for efficient view recycling.
             */
            public float ScrollingOffset;

            /**
             * Used if you want to pre-layout items that are not yet visible.
             * The difference with {@link #mAvailable} is that, when recycling, distance laid out for
             * {@link #mExtra} is not considered to avoid recycling visible children.
             */
            public float Extra = 0;


            /**
             * @return true if there are more items in the data adapter
             */
            public bool HasMore(FlexibleView.ViewState state)
            {
                return CurrentPosition >= 0 && CurrentPosition < state.ItemCount;
            }

            /**
         * Gets the view for the next element that we should layout.
         * Also updates current item index to the next item, based on {@link #mItemDirection}
         *
         * @return The next element that we should layout.
         */
            public FlexibleView.ViewHolder Next(FlexibleView.Recycler recycler)
            {
                FlexibleView.ViewHolder itemView = recycler.GetViewForPosition(CurrentPosition);
                CurrentPosition += ItemDirection;
                return itemView;
            }
        }

        internal class LayoutChunkResult
        {
            public float Consumed;
            public bool Finished;
            public bool IgnoreConsumed;
            public bool Focusable;

            public void ResetInternal()
            {
                Consumed = 0;
                Finished = false;
                IgnoreConsumed = false;
                Focusable = false;
            }
        }

        private class AnchorInfo
        {
            public int Position;
            public float Coordinate;
            public bool LayoutFromEnd;
            public bool Valid;

            public void Reset()
            {
                Position = NO_POSITION;
                Coordinate = INVALID_OFFSET;
                LayoutFromEnd = false;
                Valid = false;
            }

        }
    }
}
