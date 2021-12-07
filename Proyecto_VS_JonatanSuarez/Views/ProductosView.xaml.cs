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
    /// Lógica de interacción para ProductosView.xaml
    /// </summary>
    public partial class ProductosView : UserControl, INotifyPropertyChanged
    {
        public ProductosView()
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

            textBarras.IsEnabled = false;
            textReferencia.IsEnabled = false;
            cmbProveedor.IsEnabled = false;
            textDescripcion.IsEnabled = false;
            cmbFabricante.IsEnabled = false;
            textPrecio.IsEnabled = false;
            cmbFormato.IsEnabled = false;
            dateFecha.IsEnabled = false;
            cmbConector.IsEnabled = false;
            textStock.IsEnabled = false;

            textBarras.Text = "";
            textReferencia.Text = "";
            cmbProveedor.Text = "";
            textDescripcion.Text = "";
            cmbFabricante.Text = "";
            textPrecio.Text = "";
            cmbFormato.Text = "";
            dateFecha.Text = "";
            cmbConector.Text = "";
            textStock.Text = "";


        }

    }
}
