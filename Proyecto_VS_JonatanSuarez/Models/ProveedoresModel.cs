using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_VS_JonatanSuarez.Models
{
    public class ProveedoresModel : INotifyPropertyChanged, ICloneable
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

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; OnPropertyChanged(nameof(Nombre)); }
        }

        private string poblacion;
        public string Poblacion
        {
            get { return poblacion; }
            set { poblacion = value; OnPropertyChanged(nameof(Poblacion));}
        }

        private int telefono;
        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; OnPropertyChanged(nameof(Telefono));}
        }

        public ProveedoresModel()
        {

        }
    }
}
