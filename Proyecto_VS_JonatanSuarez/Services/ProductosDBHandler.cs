using Newtonsoft.Json;
using Proyecto_VS_JonatanSuarez.Models;
using Proyecto_VS_JonatanSuarez.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_VS_JonatanSuarez.Services
{
    public class ProductosDBHandler
    {
        private static ObservableCollection<ProductoModel> listaProductos = new ObservableCollection<ProductoModel>();

        public static bool activaCargarListaProductos = true;

        public static async void CargarListaProductos()
        {

            ResponseModel responseModel = await AccionProducto("GET", null);

            if (responseModel.resultOk)
            {
                listaProductos = JsonConvert.DeserializeObject<ObservableCollection<ProductoModel>>((string)responseModel.data);
            }
            else
            {
                MessageBox.Show((string)responseModel.data);
            }

            Console.WriteLine("Lista proveedores generada");
        }


        public static ObservableCollection<ProductoModel> ObtenerListaProductos()
        {
            return listaProductos;
        }

        private static ObservableCollection<ProductoModel> listaProductosBusqueda = new ObservableCollection<ProductoModel>();

        public static void CargarListaProveedoresBusqueda(ProductoModel producto)
        {
            listaProductosBusqueda = new ObservableCollection<ProductoModel>();
            listaProductosBusqueda.Add(producto);

        }

        public static ObservableCollection<ProductoModel> ObtenerListaProductosBusqueda()
        {
            return listaProductosBusqueda;
        }


        public static bool GuardarProducto(ProductoModel Producto)
        {

            bool okguardar = false;

            foreach (ProductoModel p in listaProductos)
            {
                if (p._id == Producto._id)
                {
                    p.Referencia = Producto.Referencia;
                    p.Descripcion = Producto.Descripcion;
                    p.Fabricante = Producto.Fabricante;
                    p.Precio= Producto.Precio;
                    p.Formato = Producto.Formato;
                    p.FechaEntrada= Producto.FechaEntrada;
                    p.Conector = Producto.Conector;
                    p.Stock= Producto.Stock;

                    okguardar = true;
                    break;
                }
            }
            return okguardar;
        }

        public static bool BorrarProducto(ProductoModel Producto)
        {
            bool okborrar = false;

            foreach (ProductoModel p in listaProductos)
            {
                if (p._id == Producto._id)
                {
                    listaProductos.Remove(p);
                    okborrar = true;
                    break;
                }
            }
            return okborrar;
        }

        public static bool NuevoProducto(ProductoModel producto)
        {
                   
            bool okinsertar = false;
            bool duplicado = false;

            foreach(ProductoModel p in listaProductos)
            {
                if (producto._id.Equals(p._id))
                {
                    duplicado = true;
                    MessageBox.Show("El CIF del producto ya existe", "Error");
                }
            }

            if (!duplicado)
            {
                try
                {
                    listaProductos.Add(producto);
                    okinsertar = true;
                }
                catch (Exception ex) { }

                return okinsertar;
            }

            return okinsertar;
            
        }

        public static async Task<ResponseModel> AccionProducto(string metodo, ProductosViewModel Producto)
        {

            RequestModel requestModel = new RequestModel();
            requestModel.route = "/productos";
            requestModel.method = metodo;

            if (metodo.Equals("DELETE"))
            {
                requestModel.data = Producto.CurrentProducto._id;
            }
            else if (metodo.Equals("GET") || metodo is null)
            {
                requestModel.data = "all";
            }
            else
            {
                requestModel.data = Producto.CurrentProducto;
            }

            ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

            return await Task.FromResult(responseModel);
        }

        public static async Task<ResponseModel> BuscarProducto(ProductosViewModel Producto)
        {

            RequestModel requestModel = new RequestModel();
            requestModel.route = "/productos";
            requestModel.method = "GET";
            requestModel.data = Producto.Busqueda;
          
            ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

            if (responseModel.resultOk)
            {
                try
                {
                    Producto.CurrentProducto = JsonConvert.DeserializeObject<ProductoModel>((string)responseModel.data);
                    CargarListaProveedoresBusqueda(Producto.CurrentProducto);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Producto no encontrado");
                    listaProductosBusqueda = new ObservableCollection<ProductoModel>();
                }

            }
            else
            {
                MessageBox.Show((string)responseModel.data);
            }

            return await Task.FromResult(responseModel);
        }
    }
}
