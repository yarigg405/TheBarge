using Assets.Code.UI;
using Assets.Code.UI.Services;
using System;


namespace Assets.Code.StaticData.Windows
{
    [Serializable]
    public sealed class WindowConfig
    {
        public WindowId WindowId;
        public WindowBase Prefab;
    }
}