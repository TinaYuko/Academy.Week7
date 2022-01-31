using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.WPF.AppBase.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        private string myProperty = "Testo di prova";
        public string MyProperty
        {
            get { return myProperty; }
            set 
            { myProperty = value;
              NotifyPropertyChanged();
            }
        }

        private int myProperty2;
        public int MyProperty2
        {
            get { return myProperty2; }
            set
            {
                myProperty2 = value;
            }
        }

        public bool isChecked = true;
        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; NotifyPropertyChanged(); } 
        }
    }
}
