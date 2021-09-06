using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Awesomium.Core;
using Spire.Pdf;
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

            using (var sr = new StreamWriter("test.html"))
            {
                sr.Write(html);
            }
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            const string pdfFileName = "doc_1.pdf";
            webControl1.PrintToFile(Directory.GetCurrentDirectory(), PrintConfig.Default);

            var pdfdocument = new PdfDocument();
            pdfdocument.LoadFromFile(pdfFileName);

            var pDialog = new PrintDialog
            {
                AllowPrintToFile = true,
                AllowSomePages = true,
                PrinterSettings =
                {
                    MinimumPage = 1,
                    MaximumPage = pdfdocument.Pages.Count,
                    FromPage = 1,
                    ToPage = pdfdocument.Pages.Count
                }
            };

            if (pDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            
            pdfdocument.PrintSettings.SelectPageRange(pDialog.PrinterSettings.FromPage, pDialog.PrinterSettings.ToPage);
            pdfdocument.PrintSettings.PrinterName = pDialog.PrinterSettings.PrinterName;
            pdfdocument.Print();
        }
    }
}
