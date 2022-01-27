using Proyecto_VS_JonatanSuarez.Models;
using Proyecto_VS_JonatanSuarez.Services;
using Proyecto_VS_JonatanSuarez.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Proyecto_VS_JonatanSuarez.Commands.LoginCommand
{
    class CheckLoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        private LoginViewModel loginViewModel { get; set; }

        public CheckLoginCommand(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
        }

        public async void Execute(object parameter)
        {
            Console.WriteLine("Ejecutando loginCommand");

            Login vistaLogin = (Login)parameter;

            string usuario = loginViewModel.UserName;
            string clave = vistaLogin.boxPass.Password;

            if (usuario.Equals(""))
            {
                MessageBox.Show("El campo nombre no puede estar vacío");
            }
            else if (clave.Equals(""))
            {
                MessageBox.Show("El campo contraseña no puede estar vacío");

            }
            else
            {
                UsuarioModel loginUsuario = new UsuarioModel(usuario, clave);


                RequestModel requestModel = new RequestModel();
                requestModel.route = "/login";
                requestModel.method = "GET";
                requestModel.data = loginUsuario;
                ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

                if (responseModel.resultOk)
                {
                    MessageBox.Show("Comprobación correcta de usuario");
                }
                else
                {
                    MessageBox.Show("Resultado de comprobación NO OK");
                }
            }

        }
    }
}
