using XmlFormatter.View;

namespace XmlFormatter.Model
{
    class XmlFormatterModel
    {
        private readonly IMainWindow _mainWindow;

        public XmlFormatterModel(IMainWindow mainWindow)
        {
            _mainWindow = mainWindow;

            _mainWindow.Show();
        }
    }
}
