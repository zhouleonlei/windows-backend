using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI;
using Tizen.NUI.Controls;

namespace Tizen.FH.NUI.Controls
{
    public class ProgressCircle : Tizen.NUI.Controls.Progress
    {
       // private VDProgressCircleAttributes progressBarAttrs = null;

        public List<string> ImageList = null;

        public override string ProgressImageURLPre
        {
            get
            {
                return progressBarAttrs.ProgressImageURLPrefix.All;
            }
            set
            {
                progressBarAttrs.ProgressImageURLPrefix.All = value;

                UpdateList();
                UpdateValue();
            }
        }

        public ProgressCircle(string style) : base(style)
        {
            ImageList = new List<string>();

            progressObj.WidthResizePolicy = ResizePolicyType.FillToParent;
            progressObj.HeightResizePolicy = ResizePolicyType.FillToParent;
            loadingObj.WidthResizePolicy = ResizePolicyType.FillToParent;
            loadingObj.HeightResizePolicy = ResizePolicyType.FillToParent;
            bufferObj.WidthResizePolicy = ResizePolicyType.FillToParent;
            bufferObj.HeightResizePolicy = ResizePolicyType.FillToParent;
        }
        protected override void OnUpdate(Attributes attrs)
        {
            progressBarAttrs = attrs as ProgressBarAttributes;
            if (progressBarAttrs == null)
            {
                return;
            }

            ApplyAttributes(this, progressBarAttrs);
            ApplyAttributes(trackObj, progressBarAttrs.TrackImageAttributes);
            ApplyAttributes(progressObj, progressBarAttrs.ProgressImageAttributes);
            UpdateList();
            UpdateValue();
        }


        public override void UpdateValue()
        {
            if (progressObj == null || ImageList == null ||
                (currentValue == null && currentValue == null) ||
                (maxValue == null && maxValue == null))
            {
                return;
            }

            int curVal = -1;
            if (currentValue != null)
            {
                curVal = (int)currentValue.Value;
            }
            else
            {
                if (CurrentValue != null)
                {
                    curVal = (int)currentValue.Value;
                }
            }

            if (curVal < 0)
            {
                return;
            }

            int maxVal = -1;
            if (maxValue != null)
            {
                maxVal = (int)maxValue.Value;
            }
            else
            {
                if (maxValue != null)
                {
                    maxVal = (int)maxValue.Value;
                }
            }

            if (maxVal <= 0)
            {
                return;
            }

            if (curVal > maxVal)
            {
                return;
            }
            int imageCount = ImageList.Count;

            if (imageCount <= 0)
            {
                return;
            }
            int rateIndex = 0;
            int imageIndex = 0;
            if (curVal == 0)
            {
                rateIndex = 0;
                imageIndex = 0;
            }
            else if (curVal == maxVal)
            {
                rateIndex = 100;
                imageIndex = imageCount - 1;
            }
            else
            {
                rateIndex = (int)(((float)curVal / (float)maxVal) * 100.0f + 0.5f);
                if (imageCount == 1)
                {
                    imageIndex = 0;
                }
                else
                {
                    float ratio = (float)maxVal / (float)(imageCount - 1);
                    imageIndex = (int)((float)curVal / ratio);
                }
            }
            progressObj.ResourceUrl = ImageList[imageIndex]; //SetImage(ImageList[imageIndex]);

            //if (textLabel != null)
            //{
            //    bool textEnabled = false;
            //    if (isTextEnabled != null)
            //    {
            //        textEnabled = isTextEnabled.Value;
            //    }
            //    else
            //    {
            //        if (progressCircleAttrs.StateTextEnable != null)
            //        {
            //            textEnabled = progressCircleAttrs.StateTextEnable.Value;
            //        }
            //    }

            //    if (textEnabled)
            //    {
            //        textLabel.Text = rateIndex.ToString();
            //        textLabel.Show();
            //    }
            //    else
            //    {
            //        textLabel.Hide();
            //    }
            //}
        }

        private void UpdateList()
        {
            uint max;
            if (ImageList != null)
            {
                ImageList.Clear();
            }
            if (this.MaxValue != null)
            {
                max = (uint)this.MaxValue.Value;
            }
            else
            {
                max = 100;
            }

            for (int i = 0; i <= max; i++)
            {
                string pre = progressBarAttrs.ProgressImageURLPrefix.All;
                if (i < 10)
                {
                    ImageList.Add(pre + "0" + i.ToString() + ".png");
                }
                else
                {
                    ImageList.Add(pre + i.ToString() + ".png");
                }

            }
        }
    }
}
