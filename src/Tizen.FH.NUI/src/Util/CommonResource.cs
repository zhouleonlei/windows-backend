using System.ComponentModel;

namespace Tizen.FH.NUI
{
    internal class CommonResource
    {
        private CommonResource() { }
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CommonResource Instance { get; } = new CommonResource();
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetFHResourcePath()
        {
            return @"../../../demo/csharp-demo/res/images/FH3/";
        }
    }
}
