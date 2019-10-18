using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.FH.FamilyBoard
{
    class ImageManager
    {
        private static ImageManager instance = null;
        private List<ImageDataItem> mImageList = new List<ImageDataItem>();

        public static ImageManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ImageManager();
                }
                return instance;
            }
        }

        public void AddImage(string file, string style)
        {
            ImageDataItem item = new ImageDataItem();
            item.Index = mImageList.Count + 1;
            item.FileName = file;
            item.FrameStyle = style;
            mImageList.Add(item);
        }

        public void RemoveImage(string file)
        {
            List<ImageDataItem> aliveList = new List<ImageDataItem>();

            for (int i = 0; i < mImageList.Count; i++)
            {
                if (mImageList[i].FileName.Equals(file))
                {
                    continue;
                }
                aliveList.Add(mImageList[i]);
            }

            mImageList.Clear();

            for (int i = 0; i < aliveList.Count; i++)
            {
                ImageDataItem item = aliveList[i];
                item.Index = i + 1;
                mImageList.Add(item);
            }
        }

        public void RemoveAllImages()
        {
            mImageList.Clear();
        }

        public int GetImageIndex(string file)
        {
            for (int i = 0; i < mImageList.Count; i++)
            {
                if (mImageList[i].FileName.Equals(file))
                {
                    return mImageList[i].Index;
                }
            }

            return 0;
        }

        public void SetFrameStyle(int index, string style)
        {
            mImageList[index].FrameStyle = style;
        }

        public int ImageCount()
        {
            return mImageList.Count;
        }

        public string GetImageFile(int index)
        {
            return mImageList[index].FileName;
        }

        private class ImageDataItem
        {
            public int Index
            {
                get;
                set;
            }

            public string FileName
            {
                get;
                set;
            }

            public string FrameStyle
            {
                get;
                set;
            }
        }

        private ImageManager()
        {
        }
    }
}
