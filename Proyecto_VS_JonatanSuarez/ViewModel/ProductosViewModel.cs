using Proyecto_VS_JonatanSuarez.Commands;
using Proyecto_VS_JonatanSuarez.Commands.ProductosCommands;
using Proyecto_VS_JonatanSuarez.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.ViewModel
{
    public class ProductosViewModel : ViewModelBase
    {
        private ObservableCollection<string> listaProveedores { get; set; }
        public ObservableCollection<string> ListaProveedores
        {
            get { return listaProveedores; }
            set { listaProveedores = value; OnPropertyChanged(nameof(ListaProveedores)); }
        }

        private ObservableCollection<ProductoModel> listaProductos;
        public ObservableCollection<ProductoModel> ListaProductos
        {
            get { return listaProductos; }
            set { listaProductos = value; OnPropertyChanged(nameof(ListaProductos));}
        }

        public ObservableCollection<string> ListaFabricantes { get; set; }
        public ObservableCollection<string> ListaFormatos { get; set; }
        public ObservableCollection<string> ListaConectores { get; set; }

        private ProductoModel currentProducto;
        public ProductoModel CurrentProducto
        {
            get { return currentProducto; }
            set { currentProducto = value; OnPropertyChanged(nameof(CurrentProducto)); }
        }

        private ProductoModel selectedProducto;
        public ProductoModel SelectedProducto
        {
            get { return selectedProducto; }
            set { selectedProducto = value; OnPropertyChanged(nameof(SelectedProducto)); }
        }

        public ICommand CargarProveedoresProdCommand { get; set; }
        public ICommand CargarProductosCommand { get; set; }
        public ICommand CargarProductoCommand { get; set; }
        public ICommand GuardarProductoCommand { get; set; }

        public ProductosViewModel()
        {
            ListaProductos = new ObservableCollection<ProductoModel>();
            ListaProveedores = new ObservableCollection<string>();
            ListaFabricantes = new ObservableCollection<string>() { "Lexman", "Bosh", "Philips", "Osram","Ilumax","Panasonic"};
            ListaFormatos = new ObservableCollection<string>() { "Rosca", "Panel", "Tira", "Tubo" };
            ListaConectores = new ObservableCollection<string>() { "E14", "E22", "GU10", "G9" };
            CargarProveedoresProdCommand = new CargarProveedoresProdCommand(this);
            CargarProductosCommand = new CargarProductosCommand(this);
            CargarProductoCommand = new CargarProductoCommand(this);
            GuardarProductoCommand = new GuardarProductoCommand(this);
            CurrentProducto = new ProductoModel();
        }
    }
}
