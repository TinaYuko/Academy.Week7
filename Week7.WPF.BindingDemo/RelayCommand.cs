using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Week7.WPF.BindingDemo
{
    public class RelayCommand : ICommand
    {

        public event EventHandler? CanExecuteChanged;
        //Puntatore ad un metodo che esegue il metodo richiesto
        private Action<object?> executeMethod;
        //Puntatore ad un metodo che restituisce true/false a seconda 
        //di determinati criteri
        //è l'equivalente a Func<object, bool>  
        private Predicate<object?> canExecuteMethod;

        public RelayCommand(Action<object?> Execute, Predicate<object?> canExecute)
        {
            executeMethod = Execute;
            canExecuteMethod = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            if (canExecuteMethod==null)
            {
                return true;
                //se non è stato istanziato il metodo canExecuteMethdo, 
                //questo comando sarà sempre abilitato
            }
            return canExecuteMethod.Invoke(parameter);

            //operatore ternario, altrimenti
            //return (canExecuteMethod==null) ? true : canExecuteMethod.Invoke(parameter);
        }

        internal void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Execute(object? parameter)
        {
           
            executeMethod?.Invoke(parameter);
            //è equivalente a 

            //if (executeMethod != null)
            //{
            //    executeMethod.Invoke(parameter);
            //}
        }

    }
}
