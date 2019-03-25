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
        private int stackPosition;
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
        public void NaviframeItemPush(View header,View content)
        {
            ManualStop();
            
            NaviItem item = new NaviItem();
            item.Header = header;
            item.contentView = content;
            pushStack.Add(item);

            if (pushStack.Count == 1)
            {
                rootItem= item;
            }
            if(currentItem != null) currentItem.Hide();
            currentItem = item;
            stackPosition = pushStack.Count;
            contentView.Add(content);
            headContent.Add(header);
        }
        public void NaviFrameItemPre()
        {
            ManualStop();

            if (pushStack.Count == 1) return;
            if (stackPosition <= 1) return;
            stackPosition--;
            prevItem = currentItem;
            currentItem = pushStack[stackPosition - 1];
            currentItem.Show();
            AnitMateContent(false);
        }
        public void NaviFrameItemNext()
        {
            ManualStop();

            if (stackPosition >= pushStack.Count) return;
            stackPosition++;

            prevItem = currentItem;
            currentItem = pushStack[stackPosition - 1];

            currentItem.Show();
            AnitMateContent(true);

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
            stackPosition = 0;
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
            if (prevItem != null)
            {
                prevItem.Hide();
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
                    startcur = currentItem.contentView.SizeWidth * (-1);
                    endcur = 0;
                }
                else
                {
                    startcur = currentItem.contentView.SizeWidth;
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
        }
    }
}
