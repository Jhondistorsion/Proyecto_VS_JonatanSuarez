using Proyecto_VS_JonatanSuarez.Models;
using Proyecto_VS_JonatanSuarez.ViewModel;
using Proyecto_VS_JonatanSuarez.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.Commands.ProductosCommands
{
    public class CargarProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        private ProductosViewModel productosViewModel;


        public CargarProductoCommand(ProductosViewModel productosViewModel)
        {
            this.productosViewModel = productosViewModel;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                ProductoModel productos = (ProductoModel)parameter;


                productosViewModel.CurrentProducto = (ProductoModel)productos.Clone();
                productosViewModel.SelectedProducto = (ProductoModel)productos.Clone();

                Console.WriteLine("Item seleccionado: " + parameter.ToString());
            }
             
            
        }
    }
}
