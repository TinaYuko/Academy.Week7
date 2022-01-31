using Esercitazione_2.Core.Entities;
using Esercitazione_2.Core.Repo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_2.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IProductRepository _repoProducts;
        public IList<Product> Products => _repoProducts.GetAll();


        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if (_selectedProduct == value)
                {
                    return;
                }
                _selectedProduct = value;
                RaisePropertyChanged();
                UpdateChartCommand.RaiseCanExecuteChanged();
                ViewProductCommand.RaiseCanExecuteChanged();
            }
        }

        private bool viewChart = false;
        public bool ViewChart
        {
            get { return viewChart; }
            set { viewChart = value; RaisePropertyChanged(); }
        }

        private string txtDetails;
        public string TextDetails
        {
            get { return txtDetails; }
            set
            {
                txtDetails = value;
                RaisePropertyChanged();
            }
        }

        private string txtChart;
        public string TextChart
        {
            get { return txtChart; }
            set
            {
                txtChart = value;
                RaisePropertyChanged();
            }
        }

        private double totalChart = 0.0;

        public RelayCommand UpdateChartCommand { get; private set; }
        public RelayCommand ViewProductCommand { get; private set; }

        public MainWindowViewModel(IProductRepository repo)
        {
            _repoProducts = repo;
           // UpdateChartCommand = new RelayCommand(updateChartExecute, operationCanExecute);
            //ViewProductCommand = new RelayCommand(() => viewProductExecute, () => operationCanExecute);
        }

        public bool operationCanExecute()
        {
            return SelectedProduct != null;
        }

        public void updateChartExecute()
        {
            if (SelectedProduct != null)
            {
                this.totalChart += SelectedProduct.Price;
                //Mostrare a video
                TextChart = $"Hai speso {totalChart} euro";
            }

        }
        public void viewProductExecute(object? param)
            {
            if (SelectedProduct != null)
            {
                //Mostrare a video
                TextDetails = $"{SelectedProduct}";
            }
        }
        
    }
}
