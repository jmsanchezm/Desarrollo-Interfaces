using _07_Pages.Views;
using Biblioteca;
namespace _07_Pages

    
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PaginaTabbed());
        }

        private async void onClickedPag4(object sender, EventArgs e) 
        { 
            clsPersona persona = new clsPersona(Nombre.Text,Apellidos.Text);

            await Navigation.PushModalAsync(new Pagina4(persona));

        }

        private async void onClickedPag5(object sender, EventArgs e) 
        {
            clsPersona persona = new clsPersona(Nombre.Text, Apellidos.Text);

            await Navigation.PushModalAsync(new Pagina5()
            {
                BindingContext = persona
            }) ;

        }


    }
}