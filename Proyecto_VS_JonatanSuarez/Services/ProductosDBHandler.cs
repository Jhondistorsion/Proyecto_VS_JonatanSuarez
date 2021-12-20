using Proyecto_VS_JonatanSuarez.Models;
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

        public static void CargarListaProductos(ObservableCollection<string> ListaProveedores, ObservableCollection<string> ListaFabricantes, ObservableCollection<string> ListaFormatos, ObservableCollection<string> ListaConectores)
        {

            ListaProveedores = ProveedoresDBHandler.ObtenerListaProveedoresProductos();

            Random r = new Random();

            for (int i = 0; i < 20; i++)
            {

                ProductoModel p = new ProductoModel();
                p._id = r.Next(100, 999).ToString();

                p.Proveedores.Add(ListaProveedores.ElementAt(r.Next(19)));
                p.Proveedores.Add(ListaProveedores.ElementAt(r.Next(19)));

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
                    p.Proveedores.Contains(busqueda) ||                   
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
    }
}
