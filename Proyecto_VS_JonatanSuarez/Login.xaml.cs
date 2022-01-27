using MaterialDesignThemes.Wpf;
using Proyecto_VS_JonatanSuarez.Models;
using Proyecto_VS_JonatanSuarez.Services;
using Proyecto_VS_JonatanSuarez.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_VS_JonatanSuarez
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

            var paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(Theme.Dark);
         
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            if (boxUser.Text.Equals(""))
            {
                MessageBox.Show("El campo nombre no puede estar vacío");
            }
            else if (boxPass.Password.Equals(""))
            {
                MessageBox.Show("El campo contraseña no puede estar vacío");

            }
            else
            {
                UsuarioModel loginUsuario = new UsuarioModel(boxUser.Text, boxPass.Password);


                RequestModel requestModel = new RequestModel();
                requestModel.route = "/login";
                requestModel.method = "GET";
                requestModel.data = loginUsuario;
                ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

                if (responseModel.resultOk)
                {
                    entrar();
                }
                else
                {
                    MessageBox.Show("El usuario o la clave son incorrectos");
                }
            }
            
        }
            
        private void entrar()
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }
    }



}



