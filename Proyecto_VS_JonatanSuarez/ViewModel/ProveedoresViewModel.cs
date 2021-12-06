using Proyecto_VS_JonatanSuarez.Commands;
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
    public class ProveedoresViewModel : ViewModelBase
    {
        private ObservableCollection<ProveedoresModel> listaProveedores { get; set; }
        public ObservableCollection<ProveedoresModel> ListaProveedores
        {
            get { return listaProveedores;}
            set { listaProveedores = value;  OnPropertyChanged(nameof(ListaProveedores)); }
        }

        public ICommand CargarProveedoresCommand { get; set; }

        public ProveedoresViewModel()
        {
            ListaProveedores = new ObservableCollection<ProveedoresModel>();
            CargarProveedoresCommand = new CargarProveedoresCommand(this);

        }
    }
}
