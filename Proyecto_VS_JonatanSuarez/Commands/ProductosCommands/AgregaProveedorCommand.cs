﻿using Proyecto_VS_JonatanSuarez.Models;
using Proyecto_VS_JonatanSuarez.ViewModel;
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
    public class AgregaProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        private ProductosViewModel productosViewModel { get; set; }

        public AgregaProveedorCommand(ProductosViewModel productosViewModel)
        {
            this.productosViewModel = productosViewModel;
        }


        public void Execute(object parameter)
        {
            if (parameter is ProveedoresModel)
            {
                ProveedoresModel proveedor = (ProveedoresModel)parameter;

                bool encontrado = false;

                try
                {
                    foreach (string p in productosViewModel.CurrentProducto.Proveedores)
                    {

                        if (p.Equals(proveedor._id))
                        {
                            MessageBox.Show("El proveedor ya existe en la lista de proveedores", "Atención");
                            encontrado = true;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {

                }

                if (!encontrado)
                {
                    MessageBoxResult result = MessageBox.Show("¿Deseas agregar el proveedor?", "Nuevo proveedor", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        productosViewModel.CurrentProducto.Proveedores.Add(proveedor._id);
                        MessageBox.Show("Proveedor agregado correctamente", "Agregar proveedor");

                    }
                    if (result == MessageBoxResult.No)
                    {
                        MessageBox.Show("Operación cancelada", "Agregar proveedor");
                    }

                }

            }
        }
    }
}

