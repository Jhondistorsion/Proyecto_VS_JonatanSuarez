using Proyecto_VS_JonatanSuarez.Models;
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

        private ProveedoresViewModel proveedoresViewModel { get; set; }

        public BorrarProveedorCommand(ProveedoresViewModel proveedoresViewModel)
        {
            this.proveedoresViewModel = proveedoresViewModel;
        }

        public async void Execute(object parameter)
        {
            ProveedoresView vistaProveedores = (ProveedoresView)parameter;

            if (proveedoresViewModel.CurrentProveedor._id is null || proveedoresViewModel.CurrentProveedor._id.Equals(""))
            {
                vistaProveedores.E00EstadoInicial();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("¿Deseas eliminar el proveedor?", "Borrar", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {

                    ResponseModel responseModel = await ProveedoresDBHandler.AccionProveedor("DELETE", proveedoresViewModel);
                    if (responseModel.resultOk)
                    {
                        MessageBox.Show("Proveedor eliminado correctamente", "Borrar");
                        proveedoresViewModel.CargarProveedoresCommand.Execute("");
                        vistaProveedores.E00EstadoInicial();
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
