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

namespace file_renamer
{
    /// <summary>
    /// Interaction logic for NodeDialog.xaml
    /// </summary>
    public partial class NodeDialog : Window
    {
        public Type SelectedItem { get; set; }
        public NodeDialog(MainWinVM vm)
        {
            InitializeComponent();
            DataContext = vm;
            //nodeList.ItemsSource = nodes;
        }

        private void accept(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            //Console.Write(SelectedItem.ToString());
        }

        private void accept(object sender, MouseButtonEventArgs e)
        {
            this.DialogResult = true;
            //Console.Write(SelectedItem.ToString());
        }
    }
}
