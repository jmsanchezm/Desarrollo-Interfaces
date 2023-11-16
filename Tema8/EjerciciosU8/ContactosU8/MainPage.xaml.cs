using Biblioteca;
using System.Collections.ObjectModel;

namespace ContactosU8
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            ObservableCollection<Persona> listaContactView = new ObservableCollection<Persona>(ListadoPersonaCompleto.ListadoPersona());

            BindingContext = this;

        }

        

    }
}