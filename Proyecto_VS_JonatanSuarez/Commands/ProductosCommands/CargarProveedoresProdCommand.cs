using Proyecto_VS_JonatanSuarez.Services;
using Proyecto_VS_JonatanSuarez.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.Commands.ProductosCommands
{
    public class CargarProveedoresProdCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public ProductosViewModel productosViewModel;

        public CargarProveedoresProdCommand(ProductosViewModel productosViewModel)
        {
            this.productosViewModel = productosViewModel;
        }

        public void Execute(object parameter)
        {
            if (ProveedoresDBHandler.activaCargaProveedores)
            {
                ProveedoresDBHandler.CargarListaProveedores();
                ProveedoresDBHandler.CargarListaProveedoresProductos();
                ProveedoresDBHandler.activaCargaProveedores = false;
            }           
            //productosViewModel.ListaProveedores = ProveedoresDBHandler.ObtenerListaProveedoresProductos();
            productosViewModel.ListaProveedoresFull = ProveedoresDBHandler.ObtenerListaProveedores();
            productosViewModel.Listaproveedorestotal = ProveedoresDBHandler.ObtenerListaProveedores();

            Console.WriteLine("Proveedores productos cargados");
        }
    }
}
