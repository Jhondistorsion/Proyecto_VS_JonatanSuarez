using Newtonsoft.Json;
using Proyecto_VS_JonatanSuarez.Models;
using Proyecto_VS_JonatanSuarez.Services;
using Proyecto_VS_JonatanSuarez.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.Commands
{
    public class CargarProveedoresCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        private ProveedoresViewModel proveedoresViewModel { get; set; }

        public CargarProveedoresCommand(ProveedoresViewModel proveedoresViewModel)
        {
            this.proveedoresViewModel = proveedoresViewModel;
        }

        public async void Execute(object parameter)
        {
            ResponseModel responseModel = await ProveedoresDBHandler.AccionProveedor("GET", proveedoresViewModel);

            if (responseModel.resultOk)
            {
                proveedoresViewModel.ListaProveedores = JsonConvert.DeserializeObject<ObservableCollection<ProveedoresModel>>((string)responseModel.data);
            }
            else
            {
                MessageBox.Show((string)responseModel.data);
            }

        }
    }
}
