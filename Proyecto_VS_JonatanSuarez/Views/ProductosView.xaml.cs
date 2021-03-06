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
            btnBuscar.IsEnabled = true;

            btnCancelar.Content = "CANCELAR";

            btnNuevoProveedor.IsEnabled = false;

            textBarras.IsEnabled = false;
            textReferencia.IsEnabled = false;
            cmbProveedor.IsEnabled = true;
            textDescripcion.IsEnabled = false;
            cmbFabricante.IsEnabled = false;
            textPrecio.IsEnabled = false;
            cmbFormato.IsEnabled = false;
            dateFecha.IsEnabled = false;
            cmbConector.IsEnabled = false;
            textStock.IsEnabled = false;


            productosListView.IsEnabled = true;
            stackProveedor.Visibility = Visibility.Collapsed;
            stackProveedor.IsEnabled = false;


        }

        public void E01NuevoProveedor()
        {

            btnCrear.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Visible;

            btnNuevo.Visibility = Visibility.Collapsed;
            btnModificar.Visibility = Visibility.Collapsed;
            btnBorrar.Visibility = Visibility.Collapsed;
            btnGuardar.Visibility = Visibility.Collapsed;
            btnBuscar.IsEnabled = false;

            btnNuevoProveedor.IsEnabled = true;

            textBarras.IsEnabled = true;
            textReferencia.IsEnabled = true;
            cmbProveedor.IsEnabled = true;
            textDescripcion.IsEnabled = true;
            cmbFabricante.IsEnabled = true;
            textPrecio.IsEnabled = true;
            cmbFormato.IsEnabled = true;
            dateFecha.IsEnabled = true;
            cmbConector.IsEnabled = true;
            textStock.IsEnabled = true;

            textBarras.Text = "";
            textReferencia.Text = "";
            cmbProveedor.SelectedIndex = 0;
            textDescripcion.Text = "";
            cmbFabricante.SelectedIndex = 0;
            textPrecio.Text = "0";
            cmbFormato.SelectedIndex = 0;
            dateFecha.Text = DateTime.Today.ToString();
            cmbConector.SelectedIndex = 0;
            textStock.Text = "0";


            productosListView.IsEnabled = false;

        }

        public void E02ModificarProveedor()
        {
            btnGuardar.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Visible;

            btnCrear.Visibility = Visibility.Collapsed;
            btnNuevo.Visibility = Visibility.Collapsed;
            btnBorrar.Visibility = Visibility.Collapsed;
            btnModificar.Visibility = Visibility.Collapsed;
            btnBuscar.IsEnabled = false;

            btnNuevoProveedor.IsEnabled = true;

            textBarras.IsEnabled = false;
            textReferencia.IsEnabled = true;
            cmbProveedor.IsEnabled = true;
            textDescripcion.IsEnabled = true;
            cmbFabricante.IsEnabled = true;
            textPrecio.IsEnabled = true;
            cmbFormato.IsEnabled = true;
            dateFecha.IsEnabled = true;
            cmbConector.IsEnabled = true;
            textStock.IsEnabled = true;

            productosListView.IsEnabled = false;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            if (btnCancelar.Content.Equals("VOLVER"))
            {
                E00EstadoInicial();
            }
            else
            {
                MessageBox.Show("Operación cancelada", "Atención");
                E00EstadoInicial();
            }

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (textBarras.Text.Equals("") || textBarras.Text is null)
            {
                MessageBox.Show("Debes seleccionar un producto", "Atención");
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
            if (textBarras.Text.Equals("") || textBarras.Text is null)
            {
                MessageBox.Show("Debes seleccionar un producto", "Atención");
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (textBusqueda.Text.Equals(""))
            {

                MessageBox.Show("Escribe un criterio de búsqueda", "Atención");
            }
            else

            {
                btnBuscar.Visibility = Visibility.Collapsed;
                btnBuscarCancelar.Visibility = Visibility.Visible;
            }
        }

        private void btnBuscarCancelar_Click(object sender, RoutedEventArgs e)
        {

            btnBuscar.Visibility = Visibility.Visible;
            btnBuscarCancelar.Visibility = Visibility.Collapsed;
            textBusqueda.Text = "";

        }

        private void btnAceptarProveedor_Click(object sender, RoutedEventArgs e)
        {
            dialogProveedores.IsOpen = false;
            cmbProveedor.SelectedIndex = cmbProveedor.Items.Count;
        }

        private void btnProveedor_Click(object sender, RoutedEventArgs e)
        {
            if (cmbProveedor.Text.Equals(""))
            {
                MessageBox.Show("Selecciona un proveedor del producto", "Atención");
            }
            else
            {
                if (!stackProveedor.IsEnabled)
                {
                    stackProveedor.Visibility = Visibility.Visible;
                    btnProveedor.Content = "OCULTAR INFO DEL PROVEEDOR";
                    stackProveedor.IsEnabled = true;
                }
                else
                {
                    stackProveedor.Visibility = Visibility.Collapsed;
                    btnProveedor.Content = "MOSTRAR INFO DEL PROVEEDOR";
                    stackProveedor.IsEnabled = false;
                }
            }


        }

        public void OcultaProveedor()
        {
            stackProveedor.Visibility = Visibility.Collapsed;
            btnProveedor.Content = "MOSTRAR INFO DEL PROVEEDOR";
            stackProveedor.IsEnabled = false;

        }
    }
}
