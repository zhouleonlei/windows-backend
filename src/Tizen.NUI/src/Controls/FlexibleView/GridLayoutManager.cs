using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI.Controls
{
    public class GridLayoutManager : LinearLayoutManager
    {
        public static readonly int DEFAULT_SPAN_COUNT = -1;

        private int mSpanCount = DEFAULT_SPAN_COUNT;
        /**
         * @param spanCount The number of columns or rows in the grid
         * @param orientation Layout orientation. Should be {@link #HORIZONTAL} or {@link
         *                      #VERTICAL}.
         */
        public GridLayoutManager(int spanCount, int orientation) : base(orientation)
        {
            mSpanCount = spanCount;
        }

        protected override void LayoutChunk(FlexibleView.Recycler recycler, FlexibleView.ViewState state,
            LayoutState layoutState, LayoutChunkResult result)
        {
            int count = mSpanCount;
            for (int i = 0; i < count; i++)
            {
                FlexibleView.ViewHolder holder = layoutState.Next(recycler);
                if (holder == null)
                {
                    result.mFinished = true;
                    return;
                }

                if (layoutState.mLayoutDirection == LayoutState.LAYOUT_END)
                    AddView(holder);
                else
                    AddView(holder, 0);

                result.mConsumed = mOrientationHelper.GetViewHolderMeasurement(holder);

                float left, top, width, height;
                if (mOrientation == VERTICAL)
                {
                    width = (GetWidth() - GetPaddingLeft() - GetPaddingRight()) / count;
                    height = result.mConsumed;
                    if (layoutState.mLayoutDirection == LayoutState.LAYOUT_END)
                    {
                        left = GetPaddingLeft() + width * i;
                        top = layoutState.mOffset;
                    }
                    else
                    {
                        left = GetPaddingLeft() + width * (count - 1 - i);
                        top = layoutState.mOffset - height;
                    }
                    LayoutChild(holder, left, top, width, height);
                }
                else
                {
                    width = result.mConsumed;
                    height = (GetHeight() - GetPaddingTop() - GetPaddingBottom()) / count;
                    if (layoutState.mLayoutDirection == LayoutState.LAYOUT_END)
                    {
                        top = GetPaddingTop() + height * i;
                        left = layoutState.mOffset;
                    }
                    else
                    {
                        top = GetPaddingTop() + height * (count - 1 - i);
                        left = layoutState.mOffset - width;
                    }
                    LayoutChild(holder, left, top, width, height);
                }
            }
        }


        protected override int GetNextPosition(int position, string direction, FlexibleView.ViewState state)
        {
            if (mOrientation == HORIZONTAL)
            {
                switch (direction)
                {
                    case "Left":
                        if (position >= mSpanCount)
                        {
                            return position - mSpanCount;
                        }
                        break;
                    case "Right":
                        if (position < state.ItemCount - mSpanCount)
                        {
                            return position + mSpanCount;
                        }
                        break;
                    case "Up":
                        if (position % mSpanCount > 0)
                        {
                            return position - 1;
                        }
                        break;
                    case "Down":
                        if (position < state.ItemCount - 1 && (position % mSpanCount < mSpanCount - 1))
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
                    case "Left":
                        if (position % mSpanCount > 0)
                        {
                            return position - 1;
                        }
                        break;
                    case "Right":
                        if (position < state.ItemCount - 1 && (position % mSpanCount < mSpanCount - 1))
                        {
                            return position + 1;
                        }
                        break;
                    case "Up":
                        if (position >= mSpanCount)
                        {
                            return position - mSpanCount;
                        }
                        break;
                    case "Down":
                        if (position < state.ItemCount - mSpanCount)
                        {
                            return position + mSpanCount;
                        }
                        break;
                }
            }

            return NO_POSITION;
        }

        private void AssignSpans(FlexibleView.Recycler recycler, FlexibleView.ViewState state, int count,
            int consumedSpanCount, bool layingOutInPrimaryDirection)
        {
            // spans are always assigned from 0 to N no matter if it is RTL or not.
            // RTL is used only when positioning the view.
            int span, start, end, diff;
            // make sure we traverse from min position to max position
            if (layingOutInPrimaryDirection)
            {
                start = 0;
                end = count;
                diff = 1;
            }
            else
            {
                start = count - 1;
                end = -1;
                diff = -1;
            }
            span = 0;
            for (int i = start; i != end; i += diff)
            {
            }
        }

    }
}
