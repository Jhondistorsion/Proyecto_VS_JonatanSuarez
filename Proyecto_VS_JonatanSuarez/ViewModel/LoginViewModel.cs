using Proyecto_VS_JonatanSuarez.Commands.LoginCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.ViewModel
{
     class LoginViewModel : ViewModelBase
    {
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged(nameof(UserName)); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged( nameof(Password)); }
        }

        public ICommand CheckLoginCommand { get; set; }


        public LoginViewModel()
        {
            CheckLoginCommand = new CheckLoginCommand(this);
        }
    }
}
