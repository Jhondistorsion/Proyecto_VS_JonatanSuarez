using Proyecto_VS_JonatanSuarez.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_VS_JonatanSuarez.Services
{
    public class ProductosDBHandler
    {
        private static ObservableCollection<ProductoModel> listaProductos = new ObservableCollection<ProductoModel>();

        public static void CargarListaProductos(ObservableCollection<ProveedoresModel> ListaProveedores, ObservableCollection<string> ListaFabricantes, ObservableCollection<string> ListaFormatos, ObservableCollection<string> ListaConectores)
        {

            listaProductos = new ObservableCollection<ProductoModel>();

            ProveedoresDBHandler.CargarListaProveedores();
            ListaProveedores = ProveedoresDBHandler.ObtenerListaProveedores();

            Random r = new Random();

            for (int i = 0; i < 20; i++)
            {

                ProductoModel p = new ProductoModel();
                p._id = r.Next(100, 999).ToString();

                p.Proveedor._id = ListaProveedores.ElementAt(i)._id;
                p.Proveedor.Nombre = ListaProveedores.ElementAt(i).Nombre;
                p.Proveedor.Poblacion = ListaProveedores.ElementAt(i).Poblacion;
                p.Proveedor.Telefono = ListaProveedores.ElementAt(i).Telefono;

                p.Fabricante = ListaFabricantes.ElementAt(r.Next(5));
                p.Formato = ListaFormatos.ElementAt(r.Next(3));
                p.Conector = ListaConectores.ElementAt(r.Next(3));

                p.Referencia = "Artículo de tipo bombilla";
                p.Descripcion = "Iluminación led de 3000 lumens";
                p.Precio = r.Next(20, 150);
                p.FechaEntrada = DateTime.Today;
                p.Stock = r.Next(1, 500);

                listaProductos.Add(p);
            }
        }


        public static ObservableCollection<ProductoModel> ObtenerListaProductos()
        {
            return listaProductos;
        }

        private static ObservableCollection<ProductoModel> listaProductosBusqueda = new ObservableCollection<ProductoModel>();

        public static void CargarListaProveedoresBusqueda(string busqueda)
        {
            listaProductosBusqueda = new ObservableCollection<ProductoModel>();

            foreach(ProductoModel p in listaProductos)
            {
                if (p._id.Contains(busqueda) || 
                    p.Referencia.Contains(busqueda) ||
                    p.Proveedor.Nombre.Contains(busqueda) ||
                    p.Proveedor._id.Contains(busqueda) ||
                    p.Proveedor.Poblacion.Contains(busqueda) ||
                    p.Proveedor.Telefono.ToString().Contains(busqueda) ||
                    p.Descripcion.Contains(busqueda) ||
                    p.Fabricante.Contains(busqueda) ||
                    p.Precio.ToString().Contains(busqueda) ||
                    p.Formato.Contains(busqueda) ||
                    p.FechaEntrada.ToString().Contains(busqueda) ||
                    p.Conector.Contains(busqueda) ||
                    p.Stock.ToString().Contains(busqueda))
                {
                    listaProductosBusqueda.Add(p);
                }
            }
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
                    p.Proveedor = Producto.Proveedor;
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
            try
            {
                listaProductos.Add(producto);
                okinsertar = true;
            }
            catch (Exception ex) { }

            return okinsertar;
        }
    }
}
