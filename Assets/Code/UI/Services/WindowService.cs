using System;
using System.Collections.Generic;
using System.Text;


namespace Assets.Code.UI.Services
{
    public sealed class WindowService
    {
        private readonly UiFactory _uiFactory;

        public WindowService(UiFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Open(WindowId windowId)
        {
            switch (windowId)
            {
                case WindowId.None:
                    break;


                case WindowId.Shop:
                    _uiFactory.CreateShop();
                    break;
            }
        }

    }
}
