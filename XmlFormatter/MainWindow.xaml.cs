using System;
using System.Collections.Generic;
using System.Windows;
using XmlFormatter.Common;
using Microsoft.Win32;
using XmlFormatter.View;

namespace XmlFormatter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        public event Action<DataFromMainWindow> SubmitButtonPressed = delegate {};

        private readonly List<string> _filesList = new List<string>();
        private readonly IIHtmlViewerWindowFactory _htmlViewerWindowFactory;

        List<MyTableRow> _tableRowsList = new List<MyTableRow>
        {
            new MyTableRow { FirstColumn = "a", SecondColumn = "b", ThirdColumn = "c" },
            new MyTableRow { FirstColumn = "d", SecondColumn = "e", ThirdColumn = "f" },
        };

        public MainWindow()
        {
            InitializeComponent();

            dataGrid1.ItemsSource = _tableRowsList;
            _htmlViewerWindowFactory = new HtmlViewerWindowFactory();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            var textFieldsList = new List<string>
            {
                field1TextBox.Text,
                field2TextBox.Text,
                field3TextBox.Text,
                field4TextBox.Text,
                field5TextBox.Text,
                field6TextBox.Text,
                field7TextBox.Text,
                field8TextBox.Text,
                field9TextBox.Text,
                field10TextBox.Text
            };

            var sendingData = new DataFromMainWindow
            {
                FilesNames = _filesList,
                Table = _tableRowsList,
                TextFields = textFieldsList
            };

            SubmitButtonPressed(sendingData);
        }

        public void ShowResult(string html)
        {
            var htmlViewer = _htmlViewerWindowFactory.Create();
            htmlViewer.ShowDialog();
            htmlViewer.LoadHtml(html);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "XmlFormatter", MessageBoxButton.OK);
        }

        private void attachFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word Documents|*.docx|Word Documents|*.doc";
            if (openFileDialog.ShowDialog() == true)
                _filesList.AddRange(openFileDialog.FileNames);

            filesListBox.Items.Clear();
            foreach (var fileName in _filesList)
            {
                filesListBox.Items.Add(fileName);
            }
        }

    }
}
