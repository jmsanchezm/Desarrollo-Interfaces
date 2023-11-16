namespace Ejercicio1_T7.Views;

public partial class Pagina3 : ContentPage
{
	public Pagina3()
	{
		InitializeComponent();
	}

	private async void botonPulsado(object sender, EventArgs e)
	{
		await Navigation.PopToRootAsync();
	}
}