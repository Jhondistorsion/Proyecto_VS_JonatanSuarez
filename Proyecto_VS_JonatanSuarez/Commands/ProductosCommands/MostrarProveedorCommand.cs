using Proyecto_VS_JonatanSuarez.Models;
using Proyecto_VS_JonatanSuarez.Services;
using Proyecto_VS_JonatanSuarez.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.Commands.ProductosCommands
{
    public class MostrarProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        private ProductosViewModel productosViewModel { get; set; }

        public MostrarProveedorCommand(ProductosViewModel productosViewModel)
        {
            this.productosViewModel = productosViewModel;
        }

        public void Execute(object parameter)
        {

            if (parameter != null)
            {
                string cmbProveedor = (string)parameter;

                productosViewModel.P_cif = "";
                productosViewModel.P_nombre = "";
                productosViewModel.P_poblacion = "";
                productosViewModel.P_telefono = "";

                foreach (ProveedoresModel p in productosViewModel.ListaProveedoresFull)
                {
                    if (cmbProveedor.Equals(p._id))
                    {
                        productosViewModel.P_cif = p._id;
                        productosViewModel.P_nombre = p.Nombre;
                        productosViewModel.P_poblacion = p.Poblacion;
                        productosViewModel.P_telefono = p.Telefono.ToString();
                        break;
                    }                   
                }
                if(productosViewModel.P_cif.Equals(""))
                {
                    productosViewModel.P_cif = "No encontrado";
                    productosViewModel.P_nombre = "No disponible";
                    productosViewModel.P_poblacion = "No disponible";
                    productosViewModel.P_telefono = "No disponible";
                }

            }
                    
            


        }
    }
}
