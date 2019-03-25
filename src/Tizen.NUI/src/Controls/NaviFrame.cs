using System;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;


namespace Tizen.NUI.Controls
{
    public class NaviFrame : Control
    {
        private List<NaviItem> pushStack = new List<NaviItem>();
        private NaviFrameAttributes naviframeAttributes;
        private View headContent;
        private View contentView;
        private NaviItem rootItem;
        private NaviItem currentItem;
        private NaviItem prevItem;
        private Animation flickAnimation;
        private bool popFlag;
        private float startcur, endcur, startpre, endpre;
        
        public NaviFrame() : base()
        {
            Initialize();
        }
        public NaviFrame(string style) : base(style)
        {
            Initialize();
        }

        public NaviFrame(NaviFrameAttributes attributes) : base()
        {
            this.attributes = naviframeAttributes = attributes.Clone() as NaviFrameAttributes;
            Initialize();
        }
        public void NaviFrameItemPush(View header,View content)
        {
            ManualStop();
            popFlag = false;
            NaviItem item = new NaviItem();
            item.Header = header;
            item.contentView = content;
            pushStack.Add(item);
            contentView.Add(content);
            headContent.Add(header);
            prevItem = currentItem;
            currentItem = pushStack[pushStack.Count - 1];

            if (pushStack.Count == 1)
            {
                rootItem= item;
                return;
            }
            currentItem.Show();
            AnitMateContent(false);
        }
        public void NaviFrameItemPop()
        {
            ManualStop();
            if (pushStack.Count <= 1) return;
            popFlag = true ;
            prevItem = currentItem;
            currentItem = pushStack[pushStack.Count - 2];
            currentItem.Show();
            AnitMateContent(true);
            NaviItem result = pushStack[pushStack.Count - 1];
            pushStack.RemoveAt(pushStack.Count - 1);
            result.Dispose();
        }

        protected override Attributes GetAttributes()
        {
            return new NaviFrameAttributes();
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }
            if (type == DisposeTypes.Explicit)
            {
                for (int i = 0; i < pushStack.Count; i++)
                {
                    if (pushStack[i] != null)
                    {
                        if (contentView != null) contentView.Remove(pushStack[i].contentView);
                        if(headContent != null) headContent.Remove(pushStack[i].Header);
                        pushStack[i].Dispose();
                        pushStack[i] = null;
                    }
                }
                pushStack.Clear();
               
                if (headContent != null)
                {
                    Remove(headContent);
                    headContent.Dispose();
                    headContent = null;
                }
                if (contentView != null)
                {
                    Remove(contentView);
                    contentView.Dispose();
                    contentView = null;
                }
                if (flickAnimation != null)
                {
                    flickAnimation.Dispose();
                    flickAnimation = null;
                }
            }
            base.Dispose(type);
        }

        protected override void OnUpdate(Attributes attributtes)
        {
            
            naviframeAttributes = attributes as NaviFrameAttributes;
            if (naviframeAttributes == null)
            {
                return;
            }
            if(naviframeAttributes.NaviHeaderAttributes != null)
            {
                ApplyAttributes(headContent, naviframeAttributes.NaviHeaderAttributes);
            }

            if (naviframeAttributes.ContentAttributes != null)
            {
                ApplyAttributes(contentView, naviframeAttributes.ContentAttributes);
            }
        }
       
        private void Initialize()
        {
            ClippingMode = ClippingModeType.ClipToBoundingBox;
            popFlag = false;
            naviframeAttributes = attributes as NaviFrameAttributes;
            if (naviframeAttributes == null)
            {
                throw new Exception("Header attribute parse error.");
            }
            flickAnimation = new Animation(300);
            flickAnimation.Finished += FlickFinish;

            headContent = new View();
            Add(headContent);
            contentView = new View();
            Add(contentView);
            ApplyAttributes(this, naviframeAttributes);
        }

        private void FlickFinish(object sender, EventArgs e)
        {
            if(popFlag)
            {
                if (prevItem != null)
                {
                    prevItem.Dispose();
                    prevItem = null;
                }
            }
            else
            {
                if (prevItem != null)
                {
                    prevItem.Hide();
                }
            }
           
        }
        private void ManualStop()
        {
            if (flickAnimation != null)
            {
                if (flickAnimation.State == Animation.States.Playing)
                {
                    flickAnimation.Stop();
                }

                flickAnimation.Clear();
            }
            if (prevItem != null) prevItem.Hide();//in case animation is not finished
            if (currentItem != null) currentItem.SetX(endcur);
        }
        private void AnitMateContent(bool nextflag)
        {

            if (currentItem != null)
            {
                if (nextflag)
                {
                    startcur = prevItem.contentView.SizeWidth * (-1);
                    endcur = 0;
                }
                else
                {
                    startcur = prevItem.contentView.SizeWidth;
                    endcur = 0;
                }
                currentItem.SetX(startcur);
                flickAnimation.AnimateTo(currentItem.contentView, "PositionX", endcur);
                flickAnimation.AnimateTo(currentItem.Header, "PositionX", endcur);
            }
           
            if (prevItem != null)
            {
                if (nextflag)
                {
                    startpre = 0;
                    endpre = prevItem.contentView.SizeWidth;
                }
                else
                {
                    startpre = 0;
                    endpre = prevItem.contentView.SizeWidth * (-1);
                }
                prevItem.Show();
                prevItem.SetX(startpre); 
                flickAnimation.AnimateTo(prevItem.contentView, "PositionX", endpre);
                flickAnimation.AnimateTo(prevItem.Header, "PositionX", endpre);
            }

            flickAnimation.Play();
        }

        private void CreateNaviframeAttributes()
        {
            if (naviframeAttributes.NaviHeaderAttributes == null)
            {
                naviframeAttributes.NaviHeaderAttributes = new ViewAttributes();
            }
           
            if (naviframeAttributes.ContentAttributes == null)
            {
                naviframeAttributes.ContentAttributes = new ViewAttributes();
            }
        }

 
        internal class NaviItem
        {

            internal View Header;
            internal View contentView;
            internal void SetX(float x)
            {
                Header.SetX(x);
                contentView.SetX(x);
            }
            internal void Show()
            {
                Header.Show();
                contentView.Show();
            }
            internal void Hide()
            {
                Header.Hide();
                contentView.Hide();
            }
            internal void Dispose()
            {
                Header.Dispose();
                contentView.Dispose();
            }
        }
    }
}
