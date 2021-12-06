using Proyecto_VS_JonatanSuarez.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.Commands
{
    public class UpdateViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is string)
            {
                string vista = parameter.ToString();
                if (vista.Equals("inicio"))
                {
                    ViewModel.SelectedViewModel = new BienvenidaViewModel();
                }else if (vista.Equals("productos"))
                {
                    ViewModel.SelectedViewModel = new ProductosViewModel();
                }else if (vista.Equals("proveedores"))
                {
                    ViewModel.SelectedViewModel = new ProveedoresViewModel();
                }
            }
        }

        public MainViewModel ViewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.ViewModel = viewModel;
            this.ViewModel.SelectedViewModel = new BienvenidaViewModel();
        }
    }
}
