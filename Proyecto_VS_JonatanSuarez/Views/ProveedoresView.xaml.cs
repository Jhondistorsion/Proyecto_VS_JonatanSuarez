using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyecto_VS_JonatanSuarez.Views
{
    /// <summary>
    /// Lógica de interacción para ProveedoresView.xaml
    /// </summary>
    public partial class ProveedoresView : UserControl, INotifyPropertyChanged
    {
        public ProveedoresView()
        {
            InitializeComponent();
            E00EstadoInicial();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void E00EstadoInicial()
        {
            btnNuevo.Visibility = Visibility.Visible;
            btnModificar.Visibility = Visibility.Visible;
            btnBorrar.Visibility = Visibility.Visible;
            
            btnCrear.Visibility = Visibility.Collapsed;
            btnGuardar.Visibility = Visibility.Collapsed;
            btnCancelar.Visibility = Visibility.Collapsed;

            textCif.IsEnabled = false;
            textNombre.IsEnabled = false;
            textPoblacion.IsEnabled = false;
            textTelefono.IsEnabled = false;

            textCif.Text = "";
            textNombre.Text = "";
            textPoblacion.Text = "";
            textTelefono.Text = "0";

            proveedoresListView.IsEnabled = true;
        }

        public void E01NuevoProveedor()
        {
            btnCrear.Visibility = Visibility.Visible;
            btnCancelar.Visibility= Visibility.Visible;

            btnNuevo.Visibility = Visibility.Collapsed;
            btnModificar.Visibility = Visibility.Collapsed;
            btnBorrar.Visibility = Visibility.Collapsed;
            btnGuardar.Visibility = Visibility.Collapsed;

            textCif.IsEnabled = true;
            textNombre.IsEnabled = true;
            textPoblacion.IsEnabled = true;
            textTelefono.IsEnabled = true;

            textCif.Text = "";
            textNombre.Text = "";
            textPoblacion.Text = "";
            textTelefono.Text = "0";

            proveedoresListView.IsEnabled = false;

        }

        public void E02ModificarProveedor()
        {
            btnGuardar.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Visible;

            btnCrear.Visibility = Visibility.Collapsed;
            btnNuevo.Visibility= Visibility.Collapsed;
            btnBorrar.Visibility= Visibility.Collapsed;
            btnModificar.Visibility= Visibility.Collapsed;

            textCif.IsEnabled = false;
            textNombre.IsEnabled = true;
            textPoblacion.IsEnabled = true;
            textTelefono.IsEnabled = true;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Operación cancelada", "Atención");
            E00EstadoInicial();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if(textCif.Text.Equals("") || textCif.Text is null)
            {
                MessageBox.Show("Debes seleccionar un proveedor", "Atención");
            }
            else
            {
                E02ModificarProveedor();
            }
            
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            E01NuevoProveedor();
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (textCif.Text.Equals("") || textCif.Text is null)
            {
                MessageBox.Show("Debes seleccionar un proveedor", "Atención");
            }

        }
    }
}
