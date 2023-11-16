using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Models
{
    public class clsPersona : INotifyPropertyChanged
    {
        private string nombre;

        public event PropertyChangedEventHandler PropertyChanged;

        public clsPersona()
        {
            nombre = "Juanma";
        }

        public clsPersona(string nombre)
        {
            this.nombre = nombre;
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnProperyChanged();
            }
        }

        protected void OnProperyChanged([CallerMemberName] string nombre = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));

        }


    }
}
