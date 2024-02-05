using Biblioteca;

namespace PlacasSolares;

public partial class CitaDetallada: ContentPage
{
	public CitaDetallada(object item)
	{
		InitializeComponent();

		BindingContext = item;
	}

	/*
	/// <summary>
	/// Funcion que abre el navegador con una URL
	/// Está función se ejecuta cuando el user le da click al boton como llegar
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private void comoLlegarClick(object sender, EventArgs e)
    {
		AbrirNavegador(direccion.Text);
    }

	/// <summary>
	/// Función quue proporciona al navegador la URL bien formada
	/// Se le añade la URL principal de google maps
	/// </summary>
	/// <param name="direccion"></param>
	private void AbrirNavegador(string direccion)
		
	{
        string[] localizacion = direccion.Split(' ');
		string url = "https://www.google.com/maps";
		for (int i = 0; i < localizacion.Length; i++) 
		{ 
			url = localizacion[i]+ "+";
		}


        try 
		{
			Launcher.OpenAsync(new Uri(url));
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error al abrir el navegador: {ex.Message}");
		}
	}*/
}