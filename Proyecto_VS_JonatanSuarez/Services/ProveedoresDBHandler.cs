using Newtonsoft.Json;
using Proyecto_VS_JonatanSuarez.Models;
using Proyecto_VS_JonatanSuarez.ViewModel;
using Proyecto_VS_JonatanSuarez.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_VS_JonatanSuarez.Services
{
    public class ProveedoresDBHandler
    {
        private static ObservableCollection<ProveedoresModel> listaProveedores = new ObservableCollection<ProveedoresModel>();

        public static bool activaCargaProveedores = true;

        public async static void CargarListaProveedores()
        {

            ResponseModel responseModel = await ProveedoresDBHandler.AccionProveedor("GET", null);

            if (responseModel.resultOk)
            {
                listaProveedores = JsonConvert.DeserializeObject<ObservableCollection<ProveedoresModel>>((string)responseModel.data);
            }
            else
            {
                MessageBox.Show((string)responseModel.data);
            }

            Console.WriteLine("Lista proveedores generada");
           
        }


        public static ObservableCollection<ProveedoresModel> ObtenerListaProveedores()
        {
            return listaProveedores;
        }

        private static ObservableCollection<string> listaProveedoresProductos = new ObservableCollection<string>();
        public static void CargarListaProveedoresProductos()
        {
            foreach (ProveedoresModel p in listaProveedores)
            {
                listaProveedoresProductos.Add(p._id);
            }
        }

        public static ObservableCollection<string> ObtenerListaProveedoresProductos()
        {
            return listaProveedoresProductos;
        }
       
        public static async Task<ResponseModel> AccionProveedor(string metodo, ProveedoresViewModel Proveedor)
        {

            RequestModel requestModel = new RequestModel();
            requestModel.route = "/proveedores";
            requestModel.method = metodo;

            if (metodo.Equals("DELETE"))
            {
                requestModel.data = Proveedor.CurrentProveedor._id;
            }
            else if(metodo.Equals("GET") || metodo is null)
            {
                requestModel.data = "all";
            }
            else
            {
                requestModel.data = Proveedor.CurrentProveedor;
            }
          
            ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

            return await Task.FromResult(responseModel);
        }


    }
}
