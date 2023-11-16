using BibliotecaDeClases;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Ejercicio1_T7.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void buttonClicked(object sender, EventArgs e)
	{

		await Navigation.PushAsync(new PaginaTabbed());
	}

	private async void page4Navigate(object sender, EventArgs e)
	{

        clsPersona persona = new clsPersona();
        persona.Nombre = txtNombre.Text;
        persona.Apellidos = txtApellidos.Text;

        await Navigation.PushAsync(new Pagina4(persona));

	}

	private async void page5Navigate(object sender, EventArgs e)
	{

		await Navigation.PushAsync(new Pagina5());
	}
}