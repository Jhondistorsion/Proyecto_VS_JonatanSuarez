using Proyecto_VS_JonatanSuarez.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase selectedViewModel;

        public MainViewModel()
        {
            SelectedViewModel = new ViewModelBase();
            UpdateViewCommand = new UpdateViewCommand(this);
        }

        public ViewModelBase SelectedViewModel 
        { 
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged(nameof(selectedViewModel)); }       
        }

        public ICommand UpdateViewCommand { get; set; }



    }
}
