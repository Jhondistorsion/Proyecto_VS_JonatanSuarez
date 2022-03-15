using Proyecto_VS_JonatanSuarez.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.Commands
{
    public class UpdateViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public ReportViewModel reportViewModel { get; set; }

        public void Execute(object parameter)
        {
            if(parameter is string)
            {
                string vista = parameter.ToString();
                if (vista.Equals("inicio"))
                {
                    ViewModel.SelectedViewModel = new BienvenidaViewModel();
                }else if (vista.Equals("productos"))
                {
                    ViewModel.SelectedViewModel = new ProductosViewModel();
                }else if (vista.Equals("proveedores"))
                {
                    ViewModel.SelectedViewModel = new ProveedoresViewModel();
                }
                else if (vista.Equals("facturas"))
                {
                    ViewModel.SelectedViewModel = new FacturasViewModel();
                }
                else if (vista.Equals("consultas"))
                {
                    ViewModel.SelectedViewModel = new ConsultasViewModel(this);
                }
                else if (vista.Equals("informe"))
                {
                    ViewModel.SelectedViewModel = reportViewModel;
                }
            }
        }

        public MainViewModel ViewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.ViewModel = viewModel;
            this.ViewModel.SelectedViewModel = new BienvenidaViewModel();
            reportViewModel = new ReportViewModel();
        }
    }
}
