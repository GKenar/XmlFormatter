using System;
using XmlFormatter.Common;
using XmlFormatter.View;

namespace XmlFormatter.Model
{
    class XmlFormatterModel
    {
        private readonly IMainWindow _mainWindow;

        public XmlFormatterModel(IMainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            _mainWindow.SubmitButtonPressed += MainWindowOnSubmitButtonPressed;

            _mainWindow.Show();
        }

        private void MainWindowOnSubmitButtonPressed(DataFromMainWindow dataFromMainWindow)
        {
            throw new NotImplementedException();
        }
    }
}
