using Proyecto_VS_JonatanSuarez.Services;
using Proyecto_VS_JonatanSuarez.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.Commands
{
    public class CargarProveedoresCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public ProveedoresViewModel proveedoresViewModel;

        public CargarProveedoresCommand(ProveedoresViewModel proveedoresViewModel)
        {
            this.proveedoresViewModel = proveedoresViewModel;
        }

        public void Execute(object parameter)
        {
            ProveedoresDBHandler.CargarListaProveedores();
            proveedoresViewModel.ListaProveedores = ProveedoresDBHandler.ObtenerListaProveedores();
        }
    }
}
