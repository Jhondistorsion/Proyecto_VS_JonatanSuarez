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
            if (parameter == null)
            {
                ObservableCollection<ProveedoresModel> ListaProveedores = new ObservableCollection<ProveedoresModel>();
                ProductosDBHandler.CargarListaProductos(ListaProveedores, productosViewModel.ListaFabricantes, productosViewModel.ListaFormatos, productosViewModel.ListaConectores);
                productosViewModel.ListaProductos = ProductosDBHandler.ObtenerListaProductos();
            }
            else if(parameter is string)
            {
                string orden = parameter.ToString();
                if (orden.Equals("buscar"))
                {
                    ProductosDBHandler.CargarListaProveedoresBusqueda(productosViewModel.Busqueda);
                    productosViewModel.ListaProductos = ProductosDBHandler.ObtenerListaProductosBusqueda();

                }else if (orden.Equals("cancelar"))
                {
                    productosViewModel.ListaProductos = ProductosDBHandler.ObtenerListaProductos();
                }
                
            }
            
            

           
 
            //Console.WriteLine("Busqueda contiene: " + productosViewModel.Busqueda);
                
            
            
        }
    }
}
