using System;
using System.Collections.Generic;
using System.Windows;
using XmlFormatter.Common;
using Microsoft.Win32;

namespace XmlFormatter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> _filesList = new List<string>();

        List<MyTableRow> list = new List<MyTableRow>
        {
            new MyTableRow { FirstColumn = "a", SecondColumn = "b", ThirdColumn = "c" },
            new MyTableRow { FirstColumn = "d", SecondColumn = "e", ThirdColumn = "f" },
        };

        public MainWindow()
        {
            InitializeComponent();

            dataGrid1.ItemsSource = list;
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine();
        }

        private void attachFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
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
