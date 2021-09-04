namespace XmlFormatter.View
{
    class HtmlViewerWindowFactory : IIHtmlViewerWindowFactory
    {
        public IHtmlViewerWindow Create()
        {
            return new HtmlViewerWindow();
        }
    }
}
