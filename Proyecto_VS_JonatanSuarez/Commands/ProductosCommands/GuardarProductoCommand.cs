﻿using Proyecto_VS_JonatanSuarez.Services;
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
    public class GuardarProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        private ProductosViewModel productosViewModel { get; set; }

        public GuardarProductoCommand(ProductosViewModel productosViewModel)
        {
            this.productosViewModel = productosViewModel;
        }

        public void Execute(object parameter)
        {
            ProductosView vistaProductos = (ProductosView)parameter;
            Regex regex = new Regex("[^0-9]");


            if (productosViewModel.CurrentProducto.Referencia.Equals(""))
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

                MessageBoxResult result = MessageBox.Show("¿Deseas realizar los cambios?", "Modificar", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    bool okguardar = ProductosDBHandler.GuardarProducto(productosViewModel.CurrentProducto);
                    if (okguardar)
                    {
                        MessageBox.Show("Producto modificado con éxito", "Modificar");
                        vistaProductos.E00EstadoInicial();
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar", "Modificar");

                    }

                }
                else if (result == MessageBoxResult.No)
                {
                    MessageBox.Show("Operación cancelada", "Modificar");
                }
            }
        }
    }
}
