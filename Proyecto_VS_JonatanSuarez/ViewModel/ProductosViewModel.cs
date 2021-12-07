using Proyecto_VS_JonatanSuarez.Commands;
using Proyecto_VS_JonatanSuarez.Commands.ProductosCommands;
using Proyecto_VS_JonatanSuarez.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.ViewModel
{
    public class ProductosViewModel : ViewModelBase
    {
        private ObservableCollection<string> listaProveedores { get; set; }
        public ObservableCollection<string> ListaProveedores
        {
            get { return listaProveedores; }
            set { listaProveedores = value; OnPropertyChanged(nameof(ListaProveedores)); }
        }

        public ICommand CargarProveedoresProdCommand { get; set; }

        public ProductosViewModel()
        {
            ListaProveedores = new ObservableCollection<string>();
            CargarProveedoresProdCommand = new CargarProveedoresProdCommand(this);
        }
    }
}
