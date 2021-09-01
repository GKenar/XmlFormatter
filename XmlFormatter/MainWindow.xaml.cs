using System;
using System.Collections.Generic;
using System.Windows;
using XmlFormatter.Common;

namespace XmlFormatter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

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
    }
}
