using Proyecto_VS_JonatanSuarez.Commands.ProductosCommands;
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

namespace Proyecto_VS_JonatanSuarez.Commands
{
    public class CargaBaseDatosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public ProductosViewModel productosViewModel;
        public BienvenidaViewModel bienvenidaViewModel;

        public CargaBaseDatosCommand(ProductosViewModel productosViewModel)
        {
            this.productosViewModel = productosViewModel;          
        }

        public void Execute(object parameter)
        {          

            if (ProveedoresDBHandler.activaCargaProveedores && ProductosDBHandler.activaCargarListaProductos)
            {
                ProveedoresDBHandler.CargarListaProveedores();
                ProveedoresDBHandler.CargarListaProveedoresProductos();
                ObservableCollection<string> ListaProveedores = new ObservableCollection<string>();
                ProductosDBHandler.CargarListaProductos();

                ProveedoresDBHandler.activaCargaProveedores = false;
                ProductosDBHandler.activaCargarListaProductos = false;

                Console.WriteLine("BASE DE DATOS CARGADA");
            }
            productosViewModel.CargarProveedoresProdCommand.Execute("");
            productosViewModel.CargarProductosCommand.Execute("");
        }
    }
}
