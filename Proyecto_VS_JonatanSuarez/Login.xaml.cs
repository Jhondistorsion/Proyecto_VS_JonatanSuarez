using MaterialDesignThemes.Wpf;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string user = "admin";
            string pass = "salinas";

            if (boxUser.Text.Equals(""))
            {
                MessageBox.Show("El campo nombre no puede estar vacío");
            }
            else if (boxPass.Text.Equals(""))
            {
                MessageBox.Show("El campo contraseña no puede estar vacío");

            }
            else if (boxUser.Text.Equals(user) && !boxPass.Text.Equals(pass))
            {
                MessageBox.Show("Usuario incorrecto");
            }
            else if (!boxUser.Text.Equals(user) && boxPass.Text.Equals(pass))
            {
                MessageBox.Show("Usuario incorrecto");

            }
            else if (!boxUser.Text.Equals(user) && !boxPass.Text.Equals(pass))
            {
                MessageBox.Show("Usuario incorrecto");
            }
            else if (boxUser.Text.Equals(user) && boxPass.Text.Equals(pass))
            {
                MainWindow mainwindow = new MainWindow();
                mainwindow.Show();
                this.Close();
            }
        }
    }



}



