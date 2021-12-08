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

        private ProveedoresViewModel proveedoresViewModel { get; set; }

        public CargarProveedoresCommand(ProveedoresViewModel proveedoresViewModel)
        {
            this.proveedoresViewModel = proveedoresViewModel;
        }

        public void Execute(object parameter)
        {
            if (ProveedoresDBHandler.activaCargaProveedores)
            {
                ProveedoresDBHandler.CargarListaProveedores();
                ProveedoresDBHandler.activaCargaProveedores = false;
            }
            proveedoresViewModel.ListaProveedores = ProveedoresDBHandler.ObtenerListaProveedores();


        }
    }
}
