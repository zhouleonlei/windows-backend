using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Controls;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{

    public class ListItemData
    {
        private string str;

        public ListItemData(int i)
        {
            str = "Text" + i.ToString();
        }

        public string TextString
        {
            get
            {
                return str;
            }
        }
    }

    public class ListItemView : View
    {
        private TextLabel mText;

        public ListItemView()
        {
            mText = new TextLabel();
            mText.WidthResizePolicy = ResizePolicyType.FillToParent;
            mText.HeightResizePolicy = ResizePolicyType.FillToParent;
            mText.PointSize = 22;
            mText.HorizontalAlignment = HorizontalAlignment.Center;
            mText.VerticalAlignment = VerticalAlignment.Center;
            Add(mText);
        }

        public string MainText
        {
            get
            {
                return mText.Text;
            }
            set
            {
                mText.Text = value;
            }
        }
    }

    public class ListBridge : FlexibleView.Adapter
    {
        private List<ListItemData> mDatas;

        public ListBridge(List<ListItemData> datas)
        {
            mDatas = datas;
        }

        public void InsertData(int position)
        {
            mDatas.Insert(position, new ListItemData(1000 + position));
            NotifyItemInserted(position);
        }

        public void RemoveData(int position)
        {
            mDatas.RemoveAt(position);
            NotifyItemRemoved(position);
        }

        public override FlexibleView.ViewHolder OnCreateViewHolder(int viewType)
        {
            FlexibleView.ViewHolder viewHolder = new FlexibleView.ViewHolder(new ListItemView());

            return viewHolder;
        }

        public override void OnBindViewHolder(FlexibleView.ViewHolder holder, int position)
        {
            //Console.WriteLine($"OnBindItemView... position: {position}");
            holder.Padding = new Vector4(1, 1, 1, 1);
            holder.SizeWidth = 150;
            holder.SizeHeight = 60;

            ListItemData listItemData = mDatas[position];

            ListItemView listItemView = holder.ItemView as ListItemView;
            listItemView.Name = "Item" + position;
            //Random rd = new Random();
            //listItemView.SizeHeight = 60;
            if (listItemView != null)
            {
                listItemView.MainText = String.Format("{0:D2}", position) + " : " + listItemData.TextString;
            }
            //listItemView.Margin = new Extents(1, 1, 1, 1);
            if (position % 2 == 0)
                listItemView.BackgroundColor = Color.Cyan;
            else
                listItemView.BackgroundColor = Color.Yellow;
        }

        public override int GetItemCount()
        {
            return mDatas.Count;
        }

        public override void OnFocusChange(FlexibleView.ViewHolder previousFocus, FlexibleView.ViewHolder currentFocus)
        {
            if (previousFocus != null)
            {
                //Console.WriteLine($"previousFocus {previousFocus.AdapterPosition}");
                if (previousFocus.AdapterPosition % 2 == 0)
                    previousFocus.ItemView.BackgroundColor = Color.Cyan;
                else
                    previousFocus.ItemView.BackgroundColor = Color.Yellow;
                //previousFocus.SizeWidth = 150;
                //previousFocus.SizeHeight = 60;
                //NotifyItemChanged(previousFocus.AdapterPosition);
            }
            if (currentFocus != null)
            {
                //Console.WriteLine($"currentFocus {currentFocus.AdapterPosition}");
                currentFocus.ItemView.BackgroundColor = Color.Magenta;
                //currentFocus.SizeWidth = 200;
                //currentFocus.SizeHeight = 100;
                //NotifyItemChanged(currentFocus.AdapterPosition);
            }
        }

    }

    public class FlexibleViewSample : IExample
    {
        private FlexibleView flexibleView1;
        private FlexibleView flexibleView2;
        private ListBridge adapter;

        public void Activate()
        {
            Window window = Window.Instance;

            flexibleView1 = new FlexibleView();
            flexibleView1.Name = "RecyclerView";
            flexibleView1.Position2D = new Position2D(500, 200);
            flexibleView1.Size2D = new Size2D(400, 450);
            flexibleView1.Padding = new Extents(10, 10, 10, 10);
            flexibleView1.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.4f);

            List<ListItemData> dataList = new List<ListItemData>();
            for (int i = 0; i < 131; ++i)
            {
                dataList.Add(new ListItemData(i));
            }
            adapter = new ListBridge(dataList);
            flexibleView1.SetAdapter(adapter);

            LinearLayoutManager layoutManager1 = new LinearLayoutManager(LinearLayoutManager.VERTICAL);
            //GridLayoutManager layoutManager1 = new GridLayoutManager(3, LinearLayoutManager.VERTICAL);
            flexibleView1.SetLayoutManager(layoutManager1);

            flexibleView1.FocusedItemIndex = 0;

            window.Add(flexibleView1);

            flexibleView1.Focusable = true;

            flexibleView1.KeyEvent += RecyclerView_KeyEvent;
            flexibleView1.FocusGained += FlexibleView_FocusGained;
            flexibleView1.FocusLost += FlexibleView_FocusLost;


            flexibleView2 = new FlexibleView();
            flexibleView2.Name = "RecyclerView";
            flexibleView2.Position2D = new Position2D(500, 800);
            flexibleView2.Size2D = new Size2D(700, 200);
            flexibleView2.Padding = new Extents(10, 10, 10, 10);
            flexibleView2.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.4f);

            flexibleView2.SetAdapter(adapter);

            GridLayoutManager layoutManager2 = new GridLayoutManager(3, LinearLayoutManager.HORIZONTAL);
            flexibleView2.SetLayoutManager(layoutManager2);

            flexibleView2.FocusedItemIndex = 0;

            window.Add(flexibleView2);

            flexibleView2.Focusable = true;

            flexibleView2.KeyEvent += RecyclerView_KeyEvent;
            flexibleView2.FocusGained += FlexibleView_FocusGained;
            flexibleView2.FocusLost += FlexibleView_FocusLost;

            FocusManager.Instance.SetCurrentFocusView(flexibleView1);
        }

        private void FlexibleView_FocusLost(object sender, EventArgs e)
        {
            View flexibleView = sender as View;
            flexibleView.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.4f);
        }

        private void FlexibleView_FocusGained(object sender, EventArgs e)
        {
            View flexibleView = sender as View;
            flexibleView.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.8f);
        }

        private bool RecyclerView_KeyEvent(object source, View.KeyEventArgs e)
        {
            FlexibleView flexibleView = source as FlexibleView;
            return ProcessKey(flexibleView, e.Key);
        }

        private bool ProcessKey(FlexibleView flexibleView, Key key)
        {
            if (key.State == Key.StateType.Down)
            {
                if (key.KeyPressedName == "Up")
                {
                    flexibleView.MoveFocus("Up");
                }
                else if (key.KeyPressedName == "Down")
                {
                    flexibleView.MoveFocus("Down");
                }
                if (key.KeyPressedName == "Left")
                {
                    flexibleView.MoveFocus("Left");
                }
                else if (key.KeyPressedName == "Right")
                {
                    flexibleView.MoveFocus("Right");
                }
                else if (key.KeyPressedName == "0")
                {
                    if (flexibleView == flexibleView1)
                    {
                        FocusManager.Instance.SetCurrentFocusView(flexibleView2);
                    }
                    else if (flexibleView == flexibleView2)
                    {
                        FocusManager.Instance.SetCurrentFocusView(flexibleView1);
                    }
                }
                else if (key.KeyPressedName == "1")
                {
                    adapter.InsertData(1);
                }
                else if (key.KeyPressedName == "2")
                {
                    adapter.RemoveData(1);
                }
                else if (key.KeyPressedName == "8")
                {
                    flexibleView.FocusedItemIndex = 0;
                }
                else if (key.KeyPressedName == "9")
                {
                    flexibleView.FocusedItemIndex = 15;
                }
                else if (key.KeyPressedName == "7")
                {
                    uint childCount = flexibleView2.GetChildCount();
                    for (uint i = 0; i < childCount; i++)
                    {
                        View child = flexibleView2.GetChildAt(i);
                        Console.WriteLine($"{i} {child.ID} {child.Name} {child.PositionX},{child.PositionY}");
                    }
                }
            }

            return false;
        }

        public void Deactivate()
        {
            Window window = Window.Instance;
            window.Remove(flexibleView1);
            flexibleView1.Dispose();
            window.Remove(flexibleView2);
            flexibleView2.Dispose();
        }
    }
}
