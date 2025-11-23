using Assets.Code.StaticData.Windows;
using Assets.Code.UI.Services;
using System.Collections.Generic;
using System.Linq;


namespace Assets.Code.StaticData
{
    public class StaticDataService
    {
        private readonly WindowsStaticData _staticData;
        private readonly Dictionary<WindowId, WindowConfig> _windowConfig = new();

        public StaticDataService(WindowsStaticData staticData)
        {
            _staticData = staticData; 
            _windowConfig = _staticData
               .Configs
               .ToDictionary(x => x.WindowId, x => x);
        }

        public WindowConfig ForWindow(WindowId windowId)
        {
            return _windowConfig.TryGetValue(windowId, out var windowConfig)
                  ? windowConfig
                  : null;
        }
    }
}
