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

            ProveedoresDBHandler.CargarListaProveedores();
            ListaProveedores = ProveedoresDBHandler.ObtenerListaProveedores();

           
            for (int i = 0; i < 20; i++)
            {
               
                Random r = new Random();
                int numFabricantes = r.Next(5);

                //Console.WriteLine("Numero fabricante: " + numFabricantes);

                Random r2 = new Random();
                int numFormatosConectores = r2.Next(3);

                Random r3 = new Random();
                int numProveedores = r3.Next(19);

                ProductoModel p = new ProductoModel();
                p._id = ((100 + i) * (numProveedores)).ToString();

                p.Proveedor._id = ListaProveedores.ElementAt(i)._id;
                p.Proveedor.Nombre = ListaProveedores.ElementAt(i).Nombre;
                p.Proveedor.Poblacion = ListaProveedores.ElementAt(i).Poblacion;
                p.Proveedor.Telefono = ListaProveedores.ElementAt(i).Telefono;

                p.Fabricante = ListaFabricantes.ElementAt(numFabricantes);
                p.Formato = ListaFormatos.ElementAt(numFormatosConectores);
                p.Conector = ListaConectores.ElementAt(numFormatosConectores);

                p.Referencia = "Artículo de tipo bombilla";
                p.Descripcion = "Iluminación led de 3000 lumens";
                p.Precio = (numFormatosConectores * (i + 2));
                p.FechaEntrada = DateTime.Today;
                p.Stock = (2 + numFormatosConectores) * (2 + numFabricantes);

                listaProductos.Add(p);
            }
        }


        public static ObservableCollection<ProductoModel> ObtenerListaProductos()
        {
            return listaProductos;
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
