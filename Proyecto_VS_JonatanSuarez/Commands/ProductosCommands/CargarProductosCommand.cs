using Proyecto_VS_JonatanSuarez.Models;
using Proyecto_VS_JonatanSuarez.Services;
using Proyecto_VS_JonatanSuarez.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.Commands.ProductosCommands
{
    public class CargarProductosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        private ProductosViewModel productosViewModel { get; set; }

        public CargarProductosCommand(ProductosViewModel productosViewModel)
        {
            this.productosViewModel = productosViewModel;
        }

        public void Execute(object parameter)
        { 
            ObservableCollection<ProveedoresModel>ListaProveedores = new ObservableCollection<ProveedoresModel>();
            ProductosDBHandler.CargarListaProductos(ListaProveedores, productosViewModel.ListaFabricantes, productosViewModel.ListaFormatos,productosViewModel.ListaConectores);
            productosViewModel.ListaProductos = ProductosDBHandler.ObtenerListaProductos();
        }
    }
}
