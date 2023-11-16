using Biblioteca;
using CoreSpotlight;

namespace EjercicioU5
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnClicked(object sender, EventArgs e)
        {
            clsPersona persona = new clsPersona();

            persona.Nombre = Nombre.Text;

            if (!string.IsNullOrEmpty(persona.Nombre))
            {
                persona.Apellido = await DisplayPromptAsync("", "Introduzca su apellido0");

                await DisplayAlert("Hola", persona.Nombre + " " + persona.Apellido, "OK");



            }
        }
    }
}