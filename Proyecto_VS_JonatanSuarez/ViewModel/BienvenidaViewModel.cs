using Proyecto_VS_JonatanSuarez.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.ViewModel
{
    public class BienvenidaViewModel : ViewModelBase
    {
        public ICommand CargaBaseDatosCommand { get; set; }

        public ProductosViewModel productosViewModel;

        public BienvenidaViewModel()
        {
            productosViewModel = new ProductosViewModel();
            CargaBaseDatosCommand = new CargaBaseDatosCommand(productosViewModel);
        }
    }
}
