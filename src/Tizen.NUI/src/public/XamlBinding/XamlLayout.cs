using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.UIComponents;

namespace Tizen.NUI.Xaml
{
    [ContentProperty("Content")]
    public class XamlLayout : BaseHandle
    {
        public XamlLayout()
        {
            IsCreateByXaml = true;
            Root = new View();
            Root.WidthResizePolicy = ResizePolicyType.FillToParent;
            Root.HeightResizePolicy = ResizePolicyType.FillToParent;
        }

        public View Root
        {
            get;
            internal set;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public View Content
        {
            get
            {
                return null;
            }
            set
            {
                Root.Add(value);
            }
        }

        public View RelateView
        {
            get
            {
                return relateView;
            }
            set
            {
                relateView = value;
                relateView.Add(Root);
            }
        }

        /// <summary>
        /// The Resources property.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceDictionary XamlResources
        {
            get
            {
                return Application.Current.XamlResources;
            }

            set
            {
                Application.Current.XamlResources = value;
            }
        }

        private View relateView;
    }
}
