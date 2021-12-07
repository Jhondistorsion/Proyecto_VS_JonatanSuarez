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
    public class NuevoProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        private ProductosViewModel productosViewModel { get; set; }

        public NuevoProductoCommand(ProductosViewModel productosViewModel)
        {
            this.productosViewModel = productosViewModel;
        }

        public void Execute(object parameter)
        {
            ProductosView vistaProductos = (ProductosView)parameter;

            if (productosViewModel.CurrentProducto._id.Equals(""))
            {
                MessageBox.Show("Debes introducir un código de barras");
            }
            else if (productosViewModel.CurrentProducto.Referencia.Equals(""))
            {
                MessageBox.Show("Debes introducir una referencia");
            }
            else if (productosViewModel.CurrentProducto.Descripcion.Equals(""))
            {
                MessageBox.Show("Debes introducir una descripción");
            }
            else if (productosViewModel.CurrentProducto.Precio.Equals(""))
            {
                MessageBox.Show("Debes introducir un precio");
            }
            else if (productosViewModel.CurrentProducto.Stock.Equals(""))
            {
                MessageBox.Show("Debes introducir el stock");
            }
            else
            {


                MessageBoxResult result = MessageBox.Show("¿Deseas crear el producto?", "Nuevo producto", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    bool okinsertar = ProductosDBHandler.NuevoProducto(productosViewModel.CurrentProducto);
                    if (okinsertar)
                    {
                        MessageBox.Show("Se ha creado el producto", "Atención");
                        vistaProductos.E00EstadoInicial();
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el producto", "Atención");
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
