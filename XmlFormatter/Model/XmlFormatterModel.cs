using System.Linq;
using XmlFormatter.Common;
using XmlFormatter.View;

namespace XmlFormatter.Model
{
    class XmlFormatterModel
    {
        private readonly IMainWindow _mainWindow;
        private readonly IXmlDocumentBuilder _documentBuilder;
        private readonly IFilesLoader _filesLoader;

        public XmlFormatterModel(IMainWindow mainWindow, IXmlDocumentBuilder documentBuilder, IFilesLoader filesLoader)
        {
            _mainWindow = mainWindow;
            _documentBuilder = documentBuilder;
            _filesLoader = filesLoader;

            _mainWindow.SubmitButtonPressed += MainWindowOnSubmitButtonPressed;

            _mainWindow.Show();
        }

        private void MainWindowOnSubmitButtonPressed(DataFromMainWindow data)
        {
            var filesContent = _filesLoader.Load(data.FilesNames).Select(ContentEncoder.ToBase64).ToList();
            var result = _documentBuilder.Build(data.TextFields, data.Table, filesContent, data.FilesNames);

            _mainWindow.ShowResult(result);
        }
    }
}
