using Proyecto_VS_JonatanSuarez.ViewModel;
using System;
using System.Collections.Generic;
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
            if (parameter is string)
            {
                string proveedor = parameter.ToString();

                try
                {
                    foreach (string p in productosViewModel.CurrentProducto.Proveedores)
                    {

                        if (proveedor.Equals(p))
                        {
                            MessageBox.Show("El proveedor ya existe en la lista de proveedores", "Atención");
                            break;
                        }
                        else
                        {
                            productosViewModel.CurrentProducto.Proveedores.Add(proveedor);
                            Console.WriteLine("item agregado " + proveedor.ToString());
                            Console.WriteLine("iteración " + p.ToString());
                            break;

                        }


                    }
                }
                catch (Exception ex)
                {

                }

                foreach (string p in productosViewModel.CurrentProducto.Proveedores)
                {
                    Console.WriteLine("items de la lista " + p);
                }

            }

        }
    }
}

