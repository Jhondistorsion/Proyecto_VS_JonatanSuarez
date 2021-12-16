using Proyecto_VS_JonatanSuarez.Models;
using Proyecto_VS_JonatanSuarez.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.Commands.ProductosCommands
{
    public class IniciaNuevoProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }


        private ProductosViewModel productosViewModel { get; set; }

        public IniciaNuevoProductoCommand(ProductosViewModel productosViewModel)
        {
            this.productosViewModel = productosViewModel;
        }

        public void Execute(object parameter)
        {
            productosViewModel.CurrentProducto = new ProductoModel();
        }
    }
}
