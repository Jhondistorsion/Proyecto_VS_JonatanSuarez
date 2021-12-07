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
            ProveedoresDBHandler.CargarListaProveedores();
            ProveedoresDBHandler.CargarListaProveedoresProductos();
            productosViewModel.ListaProveedores = ProveedoresDBHandler.ObtenerListaProveedoresProductos();
        }
    }
}
