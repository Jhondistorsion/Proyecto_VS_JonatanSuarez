using Proyecto_VS_JonatanSuarez.ViewModel;
using Proyecto_VS_JonatanSuarez.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.Commands.ProductosCommands
{
    public class OcultaProveedorCommand : ICommand
    {
      
    
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }


        private ProductosViewModel productosViewModel { get; set; }

        public OcultaProveedorCommand(ProductosViewModel productosViewModel)
        {
            this.productosViewModel = productosViewModel;
        }

        public void Execute(object parameter)
        {
            if (parameter is ProductosView)
            {

                ProductosView vistaProductos = (ProductosView)parameter;
                vistaProductos.OcultaProveedor();
                
            }
            
        }
    }
}
