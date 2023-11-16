using BibliotecaDeClases;

namespace Ejercicio1_T7.Views;

public partial class Pagina4 : ContentPage
{
	public Pagina4()
	{
		InitializeComponent();
	}
	public Pagina4(clsPersona persona)
	{
		InitializeComponent();

		String nombreCompleto = persona.Nombre + " " + persona.Apellidos;

		nombreApePersona.Text = nombreCompleto;
	}

}