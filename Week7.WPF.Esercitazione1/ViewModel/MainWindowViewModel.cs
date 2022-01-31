using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.WPF.Esercitazione1.Command;
using Week7.WPF.Esercitazione1.Entities;

namespace Week7.WPF.Esercitazione1.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private IProductRepo repoP;
        public List<Product> Products => repoP.GetAll();
        public RelayCommand UpdateChartCommand { get; private set; }
        public RelayCommand ViewProductCommand { get; private set; }

        public MainWindowViewModel(IProductRepo repo)
        {
            repoP = repo;
            UpdateChartCommand = new RelayCommand(updateChartExecute, operationCanExecute);
            ViewProductCommand = new RelayCommand(viewProductExecute, operationCanExecute);
        }
        private decimal totalChart = 0;

        private bool operationCanExecute(object? param)
        {
            return SelectedProduct != null;
        }

        private void updateChartExecute(object? param)
        {
            if (SelectedProduct != null)
            {
                this.totalChart += SelectedProduct.Price;
                //Mostrare a video
                TextChart = $"Hai speso {totalChart} euro";
            }
        }
        private bool viewChart = false;
        public bool ViewChart
        {
            get { return viewChart; }
            set { viewChart = value; NotifyPropertyChanged(); }
        }
        private void viewProductExecute(object? param)
        {
            if (SelectedProduct != null)
            {
                //Mostrare a video
                TextDetails = $"{SelectedProduct}";
            }
        }

        private string txtDetails;
        public string TextDetails
        {
            get { return txtDetails; }
            set
            {
                txtDetails = value;
                NotifyPropertyChanged();
            }
        }

        private string txtChart;
        public string TextChart
        {
            get { return txtChart; }
            set
            {
                txtChart = value;
                NotifyPropertyChanged();
            }
        }

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                if (selectedProduct == value)
                {
                    return;
                }
                selectedProduct = value;
                NotifyPropertyChanged();
                UpdateChartCommand.RaiseCanExecuteChanged();
                ViewProductCommand.RaiseCanExecuteChanged();
            }
        }
    }
}

