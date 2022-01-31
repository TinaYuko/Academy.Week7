using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Week7.WPF.BindingDemo.Entities;

namespace Week7.WPF.BindingDemo.ViewModel
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        private IRepoPerson repoPerson;

        //Lista di persone da collegare in binding con la view
        //è il view model ad essere collegato col model, fa da collegamento tra la view e la model

        public IList<Person> People => repoPerson.GetAll();
        //public IList<Person> People {get {return repoPerson.GetAll()} }

        //Proprietà che conterrà la persona selezionata
        private Person selectedPerson = null;

        public Person SelectedPerson 
        { 
            get { return selectedPerson; } 
            set
            {
                if (selectedPerson==value)
                {
                    return;
                }
                selectedPerson = value;
                //Scatenare l'evento di Binding
                NotifyPropertyChanged();
                //Richiamo l'operazione da eseguire quando la proprietà viene modificata
                SalutaCommand.RaiseCanExecuteChanged();
            }
        }

        private string txtSaluto = null;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string TextSaluto
        {
            get { return txtSaluto; }
            set 
            { 
                txtSaluto = value;
                NotifyPropertyChanged();
            }
        }

        public RelayCommand SalutaCommand { get; private set; }

        public MainWindowViewModel(IRepoPerson repo)
        {
            repoPerson = repo;
            SalutaCommand = new RelayCommand(salutaExecute, salutaCanExecute);
        }

        private bool salutaCanExecute (object? param)
        {
            return SelectedPerson != null;
        }
        private void salutaExecute(object? param)
        {
            if (SelectedPerson != null)
            {
                TextSaluto = $"Hi, {SelectedPerson}";
            }
        }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
