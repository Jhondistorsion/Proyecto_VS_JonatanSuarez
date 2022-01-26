﻿using Newtonsoft.Json;
using Proyecto_VS_JonatanSuarez.Models;
using Proyecto_VS_JonatanSuarez.Services;
using Proyecto_VS_JonatanSuarez.ViewModel;
using Proyecto_VS_JonatanSuarez.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public async void Execute(object parameter)
        {          

            if (parameter == null)
            {
                //productosViewModel.ListaProductos = ProductosDBHandler.ObtenerListaProductos();
                ResponseModel responseModel = await ProductosDBHandler.AccionProducto("GET", productosViewModel);

                if (responseModel.resultOk)
                {
                    productosViewModel.ListaProductos = JsonConvert.DeserializeObject<ObservableCollection<ProductoModel>>((string)responseModel.data);
                }
                else
                {
                    MessageBox.Show((string)responseModel.data);
                }
            }
            else if(parameter is string)
            {
                string orden = parameter.ToString();
                if (orden.Equals("buscar"))
                {
                    //ProductosDBHandler.CargarListaProveedoresBusqueda(productosViewModel.Busqueda);
                    //productosViewModel.ListaProductos = ProductosDBHandler.ObtenerListaProductosBusqueda();

                    RequestModel requestModel = new RequestModel()
                    {
                        route = "/productos",
                        method = "GET",
                        data = productosViewModel.Busqueda
                    };

                    ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

                    if (responseModel.resultOk)
                    {
                        try
                        {
                            productosViewModel.CurrentProducto = JsonConvert.DeserializeObject<ProductoModel>((string)responseModel.data);
                        }catch (Exception ex)
                        {
                            MessageBox.Show("Producto no encontrado");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show((string)responseModel.data);
                    }

                }
                else if (orden.Equals("cancelar"))
                {
                    productosViewModel.ListaProductos = ProductosDBHandler.ObtenerListaProductos();
                }
                
            }

            
        }
    }
}
