using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_VS_JonatanSuarez.Models
{
    public class UsuarioModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string user;
        public string User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(nameof(User)); }
        }
        private string pass;
        public string Pass
        {
            get { return pass; }
            set { pass = value; OnPropertyChanged(nameof (Pass)); }
        }

        public UsuarioModel(string user, string pass)
        {
            this.user = user;
            this.pass = pass;
        }
    }
}
