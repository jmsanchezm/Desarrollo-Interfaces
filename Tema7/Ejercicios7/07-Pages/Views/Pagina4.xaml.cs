using Biblioteca;

namespace _07_Pages.Views;

public partial class Pagina4 : ContentPage
{
	private clsPersona persona;

	public Pagina4(clsPersona persona)
	{
		InitializeComponent();

		this.persona = persona;
		label.Text = this.persona.Nombre + " " + this.persona.Apellido;

	}

}