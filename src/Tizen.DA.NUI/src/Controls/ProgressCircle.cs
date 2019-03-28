using System;
using System.Collections.Generic;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI;
using Tizen.NUI.CommonUI;

namespace Tizen.FH.NUI.Controls
{
    public class ProgressCircle : Tizen.NUI.CommonUI.Progress
    {
        public List<string> ImageList = null;
        private TextLabel textLabel;
        private bool isTextEnabled;

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

        public bool IsTextEnabled
        {
            get
            {
                return isTextEnabled;
            }
            set
            {
                isTextEnabled = value;
                if (value == false)
                {
                    if (textLabel != null)
                    {
                        textLabel.Hide();
                    }
                }
            }

        }

        public ProgressCircle(string style) : base(style)
        {
            ImageList = new List<string>();

            //progressObj.WidthResizePolicy = ResizePolicyType.FillToParent;
            //progressObj.HeightResizePolicy = ResizePolicyType.FillToParent;
            //loadingObj.WidthResizePolicy = ResizePolicyType.FillToParent;
            //loadingObj.HeightResizePolicy = ResizePolicyType.FillToParent;
            //bufferObj.WidthResizePolicy = ResizePolicyType.FillToParent;
            //bufferObj.HeightResizePolicy = ResizePolicyType.FillToParent;
            textLabel = new TextLabel
            {
                WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                PositionUsesPivotPoint = true,
                ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                PivotPoint = Tizen.NUI.PivotPoint.Center
            };
            Add(textLabel);
        }
        protected override void OnUpdate(Attributes attrs)
        {
            base.OnUpdate(attrs);
            UpdateList();
            UpdateValue();
        }

        protected override void UpdateStates()
        {
            if (state == ProgressStatusType.Buffering)
            {
                bufferObj.Show();
                loadingObj.Hide();
                progressObj.Hide();
                textLabel.Text = "Buffering";
            }
            else if (state == ProgressStatusType.Determinate)
            {
                bufferObj.Hide();
                loadingObj.Hide();
                progressObj.Show();
                UpdateValue();
            }
            else
            {
                bufferObj.Hide();
                loadingObj.Show();
                progressObj.Hide();
                textLabel.Text = "Loading";
            }
        }

        protected override void UpdateValue()
        {
            if (/*progressObj == null ||*/ ImageList == null ||
                (CurrentValue==null) ||
                (MaxValue == null))
            {
                return;
            }

            int curVal = -1;
            if (CurrentValue != null)
            {
                curVal = (int)CurrentValue.Value;
            }
            else
            {
                if (CurrentValue != null)
                {
                    curVal = (int)CurrentValue.Value;
                }
            }

            if (curVal < 0)
            {
                return;
            }

            int maxVal = -1;
            if (MaxValue != null)
            {
                maxVal = (int)MaxValue.Value;
            }
            else
            {
                if (MaxValue != null)
                {
                    maxVal = (int)MaxValue.Value;
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

            if (textLabel != null)
            {
                if (isTextEnabled)
                {
                    Console.WriteLine("text label change text");
                    textLabel.Text = rateIndex.ToString();
                    textLabel.Show();

                }
                else
                {
                    textLabel.Hide();
                }
            }

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
