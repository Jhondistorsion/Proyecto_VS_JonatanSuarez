using Proyecto_VS_JonatanSuarez.Services;
using Proyecto_VS_JonatanSuarez.ViewModel;
using Proyecto_VS_JonatanSuarez.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.Commands.ProveedoresCommands
{
    public class BorrarProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public ProveedoresViewModel proveedoresViewModel { get; set; }

        public BorrarProveedorCommand(ProveedoresViewModel proveedoresViewModel)
        {
            this.proveedoresViewModel = proveedoresViewModel;
        }

        public void Execute(object parameter)
        {

            if(proveedoresViewModel.CurrentProveedor._id is null)
            {
                MessageBox.Show("Debes seleccionar un proveedor", "Atención");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("¿Deseas eliminar el proveedor?", "Borrar", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    bool borrado = ProveedoresDBHandler.BorrarProveedor(proveedoresViewModel.CurrentProveedor);
                    if (borrado)
                    {
                        MessageBox.Show("Proveedor eliminado correctamente", "Borrar");
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar proveedor", "Borrar");
                    }
                }
                else if (result == MessageBoxResult.No)
                {
                    MessageBox.Show("Operación cancelada", "Borrar");
                }
            }

            
        }
    }
}
