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

        private string busqueda;
        public string Busqueda
        {
            get { return busqueda; }
            set { busqueda = value; OnPropertyChanged(nameof(Busqueda)); }
        }

        private string p_cif;
        public string P_cif
        {
            get { return p_cif; }
            set { p_cif = value; OnPropertyChanged(nameof(P_cif)); }
        }

        private string p_nombre;
        public string P_nombre
        {
            get { return p_nombre; }
            set { p_nombre = value; OnPropertyChanged(nameof(P_nombre));}
        }

        private string p_poblacion;
        public string P_poblacion
        {
            get { return p_poblacion;}
            set { p_poblacion = value; OnPropertyChanged(nameof (P_poblacion));}
        }

        private string p_telefono;
        public string P_telefono
        {
            get { return p_telefono; }
            set { p_telefono = value; OnPropertyChanged(nameof(P_telefono));}
        }


        public ICommand CargarProveedoresProdCommand { get; set; }
        public ICommand CargarProductosCommand { get; set; }
        public ICommand CargarProductoCommand { get; set; }
        public ICommand GuardarProductoCommand { get; set; }
        public ICommand BorrarProductoCommand { get; set; }
        public ICommand NuevoProductoCommand { get; set; }
        public ICommand CargaBaseDatos { get; set; }
        public ICommand AgregaProveedorCommand { get; set; }
        public ICommand MostrarProveedorCommand { get; set; }

        public ICommand IniciaNuevoProductoCommand { get; set; }

        private ObservableCollection<ProveedoresModel> listaProveedoresFull;
        public ObservableCollection<ProveedoresModel> ListaProveedoresFull
        {
            get { return listaProveedoresFull; }
            set { listaProveedoresFull = value; OnPropertyChanged(nameof (ListaProveedoresFull));}
        }


        public ProductosViewModel()
        {
            ListaProductos = new ObservableCollection<ProductoModel>();
            ListaProveedores = new ObservableCollection<string>();
            ListaProveedoresFull = new ObservableCollection<ProveedoresModel>();
            ListaFabricantes = new ObservableCollection<string>() { "Lexman", "Bosh", "Philips", "Osram","Ilumax","Panasonic"};
            ListaFormatos = new ObservableCollection<string>() { "Rosca", "Panel", "Tira", "Tubo" };
            ListaConectores = new ObservableCollection<string>() { "E14", "E22", "GU10", "G9" };

            CargarProveedoresProdCommand = new CargarProveedoresProdCommand(this);
            CargarProductosCommand = new CargarProductosCommand(this);
            CargarProductoCommand = new CargarProductoCommand(this);
            GuardarProductoCommand = new GuardarProductoCommand(this);
            BorrarProductoCommand = new BorrarProductoCommand(this);
            NuevoProductoCommand = new NuevoProductoCommand(this);
            CargaBaseDatos = new CargaBaseDatosCommand(this);
            AgregaProveedorCommand = new AgregaProveedorCommand(this);
            MostrarProveedorCommand = new MostrarProveedorCommand(this);
            IniciaNuevoProductoCommand = new IniciaNuevoProductoCommand(this);

            CurrentProducto = new ProductoModel();
            Busqueda = "";
            P_cif = "";
            P_nombre = "";
            P_poblacion = "";
            P_telefono = "";
        }
    }
}
