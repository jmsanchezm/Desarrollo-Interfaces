using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Biblioteca
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