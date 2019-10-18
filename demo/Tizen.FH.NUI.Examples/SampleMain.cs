using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tizen.FH.NUI;
using Tizen.FH.NUI.Controls;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using StyleManager = Tizen.NUI.Components.StyleManager;

namespace Tizen.FH.NUI.Samples
{
    public class CommonResource
    {
        public static string GetFHResourcePath()
        {
            return @"../../../demo/csharp-demo/res/images/FH3/";
        }
        public static string GetDaliResourcePath()
        {
            Tizen.Log.Fatal("NUI", $"GetFHResourcePath()! res={Tizen.Applications.Application.Current.DirectoryInfo.Resource}");
            //turn Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/Dali/";
            return @"../../../demo/csharp-demo/res/images/Dali/";
        }
    }
    public class NaviListItemData
    {
        private string str;

        public NaviListItemData(string s)
        {
            str = s;
        }

        public string TextString
        {
            get
            {
                return str;
            }
        }
    }

    public class NaviListItemView : View
    {
        private TextLabel mText;

        public NaviListItemView()
        {
            mText = new TextLabel();
            mText.WidthResizePolicy = ResizePolicyType.FillToParent;
            mText.HeightResizePolicy = ResizePolicyType.FillToParent;
            mText.PointSize = 40;
            mText.HorizontalAlignment = HorizontalAlignment.Begin;
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

    public class NaviListBridge : Tizen.NUI.Components.FlexibleView.Adapter
    {
        private List<NaviListItemData> mDatas;

        public NaviListBridge(List<NaviListItemData> datas)
        {
            mDatas = datas;
        }

        public void InsertData(int position)
        {
            mDatas.Insert(position, new NaviListItemData((1000 + position).ToString()));
            NotifyItemInserted(position);
        }

        public void RemoveData(int position)
        {
            mDatas.RemoveAt(position);
            NotifyItemRemoved(position);
        }

        public override Tizen.NUI.Components.FlexibleView.ViewHolder OnCreateViewHolder(int viewType)
        {
            Tizen.NUI.Components.FlexibleView.ViewHolder viewHolder = new Tizen.NUI.Components.FlexibleView.ViewHolder(new NaviListItemView());

            return viewHolder;
        }

        public override void OnBindViewHolder(Tizen.NUI.Components.FlexibleView.ViewHolder holder, int position)
        {
            NaviListItemData listItemData = mDatas[position];
            NaviListItemView listItemView = holder.ItemView as NaviListItemView;

            listItemView.Name = "Item" + position;
            listItemView.SizeWidth = 1000;
            listItemView.SizeHeight = 163;

            if (listItemView != null)
            {
                listItemView.MainText = listItemData.TextString;
            }
            listItemView.Margin = new Extents(0, 0, 1, 0);
            listItemView.BackgroundColor = new Color(1f, 1f, 1f, 1f);
        }

        public override void OnDestroyViewHolder(Tizen.NUI.Components.FlexibleView.ViewHolder holder)
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

        public override void OnFocusChange(Tizen.NUI.Components.FlexibleView flexibleView, int previousFocus, int currentFocus)
        {
            Tizen.NUI.Components.FlexibleView.ViewHolder previousFocusView = flexibleView.FindViewHolderForAdapterPosition(previousFocus);
            if (previousFocusView != null)
            {
            
            }
            Tizen.NUI.Components.FlexibleView.ViewHolder currentFocusView = flexibleView.FindViewHolderForAdapterPosition(currentFocus);
            if (currentFocusView != null)
            {
                
            }
        }

        public override void OnViewAttachedToWindow(Tizen.NUI.Components.FlexibleView.ViewHolder holder)
        {

        }

        public override void OnViewDetachedFromWindow(Tizen.NUI.Components.FlexibleView.ViewHolder holder)
        {

        }

    }
    //public class SampleMain : FHNUIApplication, IExample
    //{
    //    public static NaviFrame SampleNaviFrame
    //    {
    //        get
    //        {
    //            Console.WriteLine("test naviFrame!!");
    //            if (naviFrame == null)
    //            {
    //                Console.WriteLine("test naviFrame null!!");
    //            }
    //            return naviFrame;
    //        }
    //    }
    //    public void Activate()
    //    {
    //        Window.Instance.BackgroundColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    //        Window.Instance.GetDefaultLayer().Add(naviFrame);
    //        Window.Instance.GetDefaultLayer().Add(backNavigation);
    //    }

    //    public void Deactivate()
    //    {
    //        if (backNavigation != null)
    //        {
    //            Window.Instance.GetDefaultLayer().Remove(backNavigation);
    //            backNavigation.Dispose();
    //            backNavigation = null;
    //        }

    //        if (naviFrame != null)
    //        {
    //            Window.Instance.GetDefaultLayer().Remove(naviFrame);
    //            naviFrame.Dispose();
    //            naviFrame = null;
    //        }
    //    }

    //    protected override void OnCreate()
    //    {
    //        base.OnCreate();

    //        var examples = from type in Assembly.GetEntryAssembly().GetTypes()
    //                       where typeof(IExample).GetTypeInfo().IsAssignableFrom(type) && type.Namespace == this.GetType().Namespace
    //                       && type != this.GetType() && type.GetTypeInfo().IsClass
    //                       orderby type.Name ascending
    //                       select type.Name;
    //        RunSample("Tizen.FH.NUI.Samples", "ContactCardsSample");

    //        //naviFrame = new NaviFrame("DefaultNaviFrame");
    //        //Header head = new Header("DefaultHeader");
    //        //head.BackgroundColor = new Color(1f, 1f, 1f, 0.7f);
    //        //head.HeaderText = "FHub Samples";

    //        //contentList = new FlexibleView();
    //        //contentList.Name = "Sample List";
    //        //contentList.Position2D = new Position2D(0, 1);
    //        ////contentList.Size2D = new Size2D(1080, 1790);
    //        //contentList.Size2D = new Size2D(1080, 896);
    //        //contentList.Padding = new Extents(0, 8, 0, 0);
    //        //contentList.BackgroundColor = new Color(0, 0, 0, 0.2f);
    //        //contentList.ItemClickEvent += OnListItemClickEvent;

    //        //List<NaviListItemData> dataList = new List<NaviListItemData>();
    //        //for (int i = 0; i < examples.Count(); ++i)
    //        //{
    //        //    dataList.Add(new NaviListItemData(examples.ElementAt(i)));
    //        //}
    //        //adapter = new NaviListBridge(dataList);
    //        //contentList.SetAdapter(adapter);

    //        //LinearLayoutManager layoutManager = new LinearLayoutManager(LinearLayoutManager.VERTICAL);
    //        //contentList.SetLayoutManager(layoutManager);

    //        //scrollBar = new ScrollBar("DAScrollbar");
    //        //scrollBar.Direction = ScrollBar.DirectionType.Vertical;
    //        //scrollBar.Position2D = new Position2D(1074, 2);
    //        ////scrollBar.Size2D = new Size2D(4, 1786);
    //        //scrollBar.Size2D = new Size2D(4, 894);
    //        //scrollBar.ThumbSize = new Size2D(4, 30);
    //        //contentList.AttachScrollBar(scrollBar);

    //        //naviFrame.NaviFrameItemPush(head, contentList);

    //        //backNavigation = new Navigation("Back");
    //        //backNavigation.Position2D = new Position2D(0, 950);
    //        //backNavigation.ItemTouchEvent += OnBackNaviTouchEvent;

    //        //Navigation.NavigationItemData backItem = new Navigation.NavigationItemData("WhiteBackItem");
    //        //backNavigation.AddItem(backItem);

    //        //Window.Instance.KeyEvent += Instance_Key;

    //        //Activate();
    //        //sampleStack.Push(this);
    //    }

    //    private void OnListItemClickEvent(object sender, FlexibleView.ItemClickEventArgs e)
    //    {
    //        if (e.ClickedView != null)
    //        {
    //            int index = e.ClickedView.AdapterPosition;
    //            string sampleName = (e.ClickedView.ItemView as NaviListItemView)?.MainText;
    //            RunSample("Tizen.FH.NUI.Samples", sampleName);
    //        }
    //    }

    //    private void OnBackNaviTouchEvent(object source, View.TouchEventArgs e)
    //    {
    //        Log.Debug("NUI", $"OnNaviTouchEvent! touch position=({e.Touch.GetScreenPosition(0).X}, {e.Touch.GetScreenPosition(0).Y}), {e.Touch.GetState(0)}");
    //        if (e.Touch.GetState(0) == PointStateType.Up)
    //        {
    //            ExitSample();
    //        }
    //        return;
    //    }

    //    public void ExitSample()
    //    {
    //        if (naviFrame.Count == 1)
    //        {
    //            if (sampleStack.Count() == 2)
    //            {
    //                IExample lastSample = sampleStack.Pop();
    //                lastSample.Deactivate();
    //                FullGC();
    //            }
    //            Deactivate();
    //            Exit();
    //            Environment.Exit(0);
    //            return;
    //        }
    //        else
    //        {
    //            naviFrame.NaviFrameItemPop();
    //        }
    //    }

    //    private void Instance_Key(object sender, Window.KeyEventArgs e)
    //    {
    //        if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "BackSpace" || e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
    //        {
    //            ExitSample();
    //        }
    //    }
    //    public void RunSample(string @namespace, string sampleName)
    //    {
    //        object item = Activator.CreateInstance(global::System.Type.GetType(@namespace + "." + sampleName));
    //        if (item is IExample)
    //        {
    //            if (sampleStack.Count() > 1)
    //            {
    //                IExample lastSample = sampleStack.Pop();
    //                lastSample.Deactivate();
    //                FullGC();
    //            }
    //            example = item as IExample;
    //            sampleStack.Push(example);
    //            example.Activate();
    //        }
    //    }

    //    private void FullGC()
    //    {
    //        global::System.GC.Collect();
    //        global::System.GC.WaitForPendingFinalizers();
    //        global::System.GC.Collect();
    //    }

    //    private bool SampleMain_KeyEvent(object source, View.KeyEventArgs e)
    //    {
    //        TextLabel textLabel = source as TextLabel;

    //        if (e.Key.State == Key.StateType.Down)
    //        {
    //            if (e.Key.KeyPressedName == "Return")
    //            {
    //                string sampleName = textLabel.Text;

    //                RunSample("Tizen.FH.NUI.Samples", sampleName);

    //                return true;
    //            }
    //            switch (e.Key.KeyPressedName)
    //            {
    //                case "1":
    //                    StyleManager.Instance.Theme = "Utility";
    //                    break;
    //                case "2":
    //                    StyleManager.Instance.Theme = "Food";
    //                    break;
    //                case "3":
    //                    StyleManager.Instance.Theme = "Family";
    //                    break;
    //                case "4":
    //                    StyleManager.Instance.Theme = "Kitchen";
    //                    break;
    //            }
    //        }

    //        return false;
    //    }

    //    private static NaviFrame naviFrame;
    //    private Header header;
    //    private FlexibleView contentList;
    //    private NaviListBridge adapter;
    //    private ScrollBar scrollBar;
    //    private Navigation backNavigation;
    //    IExample example;

    //    int currentIndex = 0;
    //    Stack<IExample> sampleStack = new Stack<IExample>();
    //}
}

