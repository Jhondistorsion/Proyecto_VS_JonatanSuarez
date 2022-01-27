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

namespace Proyecto_VS_JonatanSuarez.Commands.ProductosCommands
{
    public class BorrarProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        private ProductosViewModel productosViewModel { get; set; }

        public BorrarProductoCommand(ProductosViewModel productosViewModel)
        {
            this.productosViewModel = productosViewModel;
        }

        public async void Execute(object parameter)
        {
            ProductosView vistaProductos = (ProductosView)parameter;           

            if (productosViewModel.CurrentProducto._id is null || productosViewModel.CurrentProducto._id.Equals(""))
            {
                vistaProductos.E00EstadoInicial();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("¿Deseas eliminar el producto?", "Borrar", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    ResponseModel responseModel = await ProductosDBHandler.AccionProducto("DELETE", productosViewModel);
                    if (responseModel.resultOk)
                    {
                        MessageBox.Show("Producto eliminado correctamente", "Borrar");
                        productosViewModel.CargarProductosCommand.Execute("");
                        vistaProductos.E00EstadoInicial();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar producto", "Borrar");
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
