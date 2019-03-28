using System;
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NaviFrame() : base()
        {
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NaviFrame(string style) : base(style)
        {
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NaviFrame(NaviFrameAttributes attributes) : base()
        {
            this.attributes = naviframeAttributes = attributes.Clone() as NaviFrameAttributes;
            Initialize();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void NaviFrameItemPush(View header,View content)
        {
            ManualStop();
            popFlag = false;
            NaviItem item = new NaviItem();
            item.header = header;
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new NaviFrameAttributes();
        }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                        if(headContent != null) headContent.Remove(pushStack[i].header);
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                flickAnimation.AnimateTo(currentItem.header, "PositionX", endcur);
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
                flickAnimation.AnimateTo(prevItem.header, "PositionX", endpre);
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

            internal View header;
            internal View contentView;
            internal void SetX(float x)
            {
                header.PositionX = x;
                contentView.PositionX = x;
            }
            internal void Show()
            {
                header.Show();
                contentView.Show();
            }
            internal void Hide()
            {
                header.Hide();
                contentView.Hide();
            }
            internal void Dispose()
            {
                header.Dispose();
                contentView.Dispose();
            }
        }
    }
}
