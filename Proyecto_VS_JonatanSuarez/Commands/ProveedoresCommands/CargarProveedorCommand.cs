using Proyecto_VS_JonatanSuarez.Models;
using Proyecto_VS_JonatanSuarez.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.Commands
{
    public class CargarProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
                return true;
        }

        private ProveedoresViewModel proveedoresViewModel { get; set; }

        public CargarProveedorCommand(ProveedoresViewModel proveedoresViewModel)
        {
            this.proveedoresViewModel = proveedoresViewModel;
        }

        public void Execute(object parameter)
        {
            if(parameter != null)
            {
                ProveedoresModel proveedor = (ProveedoresModel)parameter;

                proveedoresViewModel.CurrentProveedor = (ProveedoresModel)proveedor.Clone();
                proveedoresViewModel.SelectedProveedor = (ProveedoresModel)proveedor.Clone();
            }
        }
    }
}
