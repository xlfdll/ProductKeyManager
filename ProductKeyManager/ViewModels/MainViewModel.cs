using System;
using System.Collections.ObjectModel;

using Xlfdll.Diagnostics;
using Xlfdll.Windows.Presentation;
using Xlfdll.Windows.Presentation.Dialogs;

namespace ProductKeyManager
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            this.Products = new ObservableCollection<Product>();
            this.ProductKeys = new ObservableCollection<ProductKey>();
        }

        public ObservableCollection<Product> Products { get; }
        public ObservableCollection<ProductKey> ProductKeys { get; }

        public RelayCommand<Object> AboutCommand
            => new RelayCommand<Object>
            (
                delegate
                {
                    AboutWindow aboutWindow = new AboutWindow
                        (App.Current.MainWindow,
                        AssemblyMetadata.EntryAssemblyMetadata,
                        new ApplicationPackUri("/Images/ProductKeyManager.png"));

                    aboutWindow.ShowDialog();
                }
            );
    }
}