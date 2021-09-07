using System;
using XmlFormatter.Common;

namespace XmlFormatter.View
{
    interface IMainWindow
    {
        event Action<DataFromMainWindow> SubmitButtonPressed;
        void Show();
        void ShowResult(string html);
        void ShowMessage(string message);
    }
}
