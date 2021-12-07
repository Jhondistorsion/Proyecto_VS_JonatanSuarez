using Proyecto_VS_JonatanSuarez.Commands;
using Proyecto_VS_JonatanSuarez.Commands.ProveedoresCommands;
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

        private ProveedoresModel currentProveedor;
        public ProveedoresModel CurrentProveedor
        {
            get { return currentProveedor; }
            set { currentProveedor = value; OnPropertyChanged(nameof(CurrentProveedor)); }
        }

        private ProveedoresModel selectedProveedor;
        public ProveedoresModel SelectedProveedor
        {
            get { return selectedProveedor;}
            set { selectedProveedor = value; OnPropertyChanged(nameof (SelectedProveedor)); }
        }
        

        public ICommand CargarProveedoresCommand { get; set; }

        public ICommand CargarProveedorCommand { get; set; }

        public ICommand GuardarProveedorCommand { get; set; }

        public ICommand BorrarProveedorCommand { get; set; }

        public ProveedoresViewModel()
        {
            ListaProveedores = new ObservableCollection<ProveedoresModel>();
            CargarProveedoresCommand = new CargarProveedoresCommand(this);
            CargarProveedorCommand = new CargarProveedorCommand(this);
            GuardarProveedorCommand = new GuardarProveedorCommand(this);
            BorrarProveedorCommand = new BorrarProveedorCommand(this);
            CurrentProveedor = new ProveedoresModel();

        }
    }
}
