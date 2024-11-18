using System.Windows;
using System.Windows.Controls;

using Xlfdll.Windows.Presentation;

namespace ProductKeyManager
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainViewModel();
        }

        private void ImportKeysButton_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button)?.ShowDropMenu();
        }
    }
}