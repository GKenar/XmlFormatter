namespace XmlFormatter.View
{
    interface IHtmlViewerWindow
    {
        void Show();
        bool? ShowDialog();
        void LoadHtml(string html);
    }
}
