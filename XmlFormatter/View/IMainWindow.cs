using System;
using XmlFormatter.Common;

namespace XmlFormatter.View
{
    interface IMainWindow
    {
        event Action<DataFromMainWindow> SubmitButtonPressed;
        void Show();
    }
}
