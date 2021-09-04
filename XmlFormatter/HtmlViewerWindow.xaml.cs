using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Awesomium.Core;
using XmlFormatter.View;

namespace XmlFormatter
{
    /// <summary>
    /// Логика взаимодействия для HtmlViewerWindow.xaml
    /// </summary>
    public partial class HtmlViewerWindow : Window, IHtmlViewerWindow
    {
        public HtmlViewerWindow()
        {
            InitializeComponent();
        }

        public void LoadHtml(string html)
        {
            webControl1.ViewType = WebViewType.Window;
            webControl1.LoadHTML(html);
        }
    }
}
