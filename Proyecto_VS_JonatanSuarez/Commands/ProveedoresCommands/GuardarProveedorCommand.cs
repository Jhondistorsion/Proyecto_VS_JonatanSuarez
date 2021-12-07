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
    public class GuardarProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public ProveedoresViewModel proveedoresViewModel { get; set; }

        public GuardarProveedorCommand(ProveedoresViewModel proveedoresViewModel)
        {
            this.proveedoresViewModel = proveedoresViewModel;
        }

        public void Execute(object parameter)
        {
            ProveedoresView vistaProveedores = (ProveedoresView)parameter;

            if (proveedoresViewModel.CurrentProveedor.Nombre.Equals("") || proveedoresViewModel.CurrentProveedor.Nombre is null)
            {
                MessageBox.Show("Debes introducir un nombre");
            }else if (vistaProveedores.textPoblacion.Text.Equals(""))
            {
                MessageBox.Show("Debes introducir una población");
            }else if (vistaProveedores.textTelefono.Text.Equals(""))
            {
                MessageBox.Show("Debes introducir un teléfono");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("¿Deseas realizar los cambios?", "Modificar", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    bool okguardar = ProveedoresDBHandler.GuardarProveedor(proveedoresViewModel.CurrentProveedor);
                    if (okguardar)
                    {
                        MessageBox.Show("Proveedor modificado con éxito", "Modificar");
                        vistaProveedores.E00EstadoInicial();
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar", "Modificar");

                    }

                } else if(result == MessageBoxResult.No)
                {
                    MessageBox.Show("Operación cancelada", "Modificar");
                }
            }
        }
    }
}
