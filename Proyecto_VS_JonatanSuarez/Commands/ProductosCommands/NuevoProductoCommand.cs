using Proyecto_VS_JonatanSuarez.Models;
using Proyecto_VS_JonatanSuarez.Services;
using Proyecto_VS_JonatanSuarez.ViewModel;
using Proyecto_VS_JonatanSuarez.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public async void Execute(object parameter)
        {
            ProductosView vistaProductos = (ProductosView)parameter;
            Regex regex = new Regex("[^0-9]");


            if (productosViewModel.CurrentProducto._id == null)
            {
                MessageBox.Show("Debes introducir un código de barras");
            }
            else if (productosViewModel.CurrentProducto.Referencia == null)
            {
                MessageBox.Show("Debes introducir una referencia");
            }
            else if (productosViewModel.CurrentProducto.Descripcion == null)
            {
                MessageBox.Show("Debes introducir una descripción");
            }
            else if (productosViewModel.CurrentProducto.Precio == null)
            {
                MessageBox.Show("Debes introducir un precio");
            }
            else if (productosViewModel.CurrentProducto.Stock == null)
            {
                MessageBox.Show("Debes introducir el stock");
            }
            else if (productosViewModel.CurrentProducto.Fabricante == null)
            {
                MessageBox.Show("Debes seleccionar un fabricante");
            }
            else if (productosViewModel.CurrentProducto.Formato == null)
            {
                MessageBox.Show("Debes seleccionar un formato");
            }
            else if (productosViewModel.CurrentProducto.Conector == null)
            {
                MessageBox.Show("Debes seleccionar un conector");
            }
            else if (productosViewModel.CurrentProducto.Proveedores.Count == 0)
            {
                MessageBox.Show("Debes agregar al menos un proveedor");
            }
            else if (regex.IsMatch(vistaProductos.textBarras.Text) || vistaProductos.textBarras.Text.Length > 10)
            {
                MessageBox.Show("Solo se permiten números de hasta 10 cifras en el campo Código de barras");

            }
            else if (regex.IsMatch(vistaProductos.textPrecio.Text) || vistaProductos.textPrecio.Text.Length > 10)
            {
                MessageBox.Show("Solo se permiten números de hasta 10 cifras en el campo Precio");

            }
            else if (regex.IsMatch(vistaProductos.textStock.Text) || vistaProductos.textStock.Text.Length > 10)
            {
                MessageBox.Show("Solo se permiten números de hasta 10 cifras en el campo Stock");

            }
            else
            {


                MessageBoxResult result = MessageBox.Show("¿Deseas crear el producto?", "Nuevo producto", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {

                    ResponseModel responseModel = await ProductosDBHandler.AccionProducto("POST", productosViewModel);                    
                    if (responseModel.resultOk)
                    {
                        MessageBox.Show("Se ha creado el producto");
                        productosViewModel.CargarProductosCommand.Execute("");
                        vistaProductos.E00EstadoInicial();
                    }
                    else
                    {
                        MessageBox.Show("Error al crear el producto", "Atención");
                        vistaProductos.E00EstadoInicial();
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
