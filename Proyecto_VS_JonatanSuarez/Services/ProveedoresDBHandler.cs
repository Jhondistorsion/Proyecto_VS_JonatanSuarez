using Proyecto_VS_JonatanSuarez.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_VS_JonatanSuarez.Services
{
    public class ProveedoresDBHandler
    {
        private static ObservableCollection<ProveedoresModel> listaProveedores = new ObservableCollection<ProveedoresModel>();

        public static void CargarListaProveedores()
        {
            for(int i = 0; i < 20; i++)
            {
                ProveedoresModel p = new ProveedoresModel();
                p._id = i.ToString();
                p.Nombre = "Almacén " + i.ToString();
                p.Poblacion = "Población " + i.ToString();
                p.Telefono = 90052512 + i;
                listaProveedores.Add(p);
            }
        }

        public static ObservableCollection<ProveedoresModel> ObtenerListaProveedores()
        {
            return listaProveedores;
        }
    }
}
