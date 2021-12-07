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
    public class NuevoProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        private ProveedoresViewModel proveedoresViewModel { get; set; }

        public NuevoProveedorCommand(ProveedoresViewModel proveedoresViewModel)
        {
            this.proveedoresViewModel = proveedoresViewModel;
        }

        public void Execute(object parameter)
        {
            ProveedoresView vistaProveedores = (ProveedoresView)parameter;
            if (proveedoresViewModel.CurrentProveedor._id.Equals(""))
            {
                MessageBox.Show("Debes introducir un CIF");
            }
            else if (proveedoresViewModel.CurrentProveedor.Nombre.Equals(""))
            {
                MessageBox.Show("Debes introducir un nombre");
            }
            else if (proveedoresViewModel.CurrentProveedor.Poblacion.Equals(""))
            {
                MessageBox.Show("Debes introducir una población");
            }
            else if (proveedoresViewModel.CurrentProveedor.Telefono.Equals(""))
            {
                MessageBox.Show("Debes introducir un teléfono");
            }
            else
            {


                MessageBoxResult result = MessageBox.Show("¿Deseas crear el proveedor?", "Nuevo proveedor", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    bool okinsertar = ProveedoresDBHandler.NuevoProveedor(proveedoresViewModel.CurrentProveedor);
                    if (okinsertar)
                    {                    
                        MessageBox.Show("Se ha creado el proveedor", "Atención");
                        vistaProveedores.E00EstadoInicial();
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el proveedor", "Atención");
                    }
                }
                else if (result == MessageBoxResult.No)
                {
                    MessageBox.Show("Operación cancelada");
                }

            }
        }
    }
}
