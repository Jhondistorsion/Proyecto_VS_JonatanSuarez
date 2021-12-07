using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_VS_JonatanSuarez.Models
{
    public class ProductoModel : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        private string id;
        public string _id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(nameof(_id)); }
        }

        private ProveedoresModel proveedor;
        public ProveedoresModel Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; OnPropertyChanged(nameof(Proveedor)); }
        }

        private string fabricante;
        public string Fabricante
        {
            get { return fabricante; }
            set { fabricante = value; OnPropertyChanged(nameof (Fabricante)); }
        }

        private string formato;
        public string Formato
        {
            get { return formato; }
            set { formato = value; OnPropertyChanged( nameof(Formato)); }
        }

        private string conector;
        public string Conector
        {
            get { return conector; }
            set { conector = value; OnPropertyChanged(nameof(Conector)); }
        }

        private string referencia;
        public string Referencia
        {
            get { return referencia; }
            set { referencia = value; OnPropertyChanged(nameof(Referencia)); }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; OnPropertyChanged(nameof(Descripcion));}
        }

        private string precio;
        public string Precio
        {
            get { return precio; }
            set { precio = value; OnPropertyChanged(nameof(Precio)); }
        }

        private DateTime fechaEntrada;
        public DateTime FechaEntrada
        {
            get { return fechaEntrada; }
            set { fechaEntrada = value; OnPropertyChanged(nameof(FechaEntrada)); }
        }

        private int stock;
        public int Stock
        {
            get { return stock; }
            set { stock = value; OnPropertyChanged(nameof(Stock)); }
        }

        public ProductoModel()
        {
            fechaEntrada = DateTime.Today;
            proveedor = new ProveedoresModel();
        }
    }
}
