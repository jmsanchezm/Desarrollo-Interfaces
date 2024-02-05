using Biblioteca;
using System.Collections.ObjectModel;

namespace PlacasSolares;

public partial class ListaTareas : ContentPage
{
	public ListaTareas()
	{
		InitializeComponent();

		//Creo una lista en la que guardar� el resultado de la funci�n de la clase ListadoCompletoCasa
		ObservableCollection<Casa> listaCasas = new ObservableCollection<Casa>(ListadoCompletoCasa.CasaList());
		ListaCitasView.ItemsSource = listaCasas;

		BindingContext=this;

	}

	/// <summary>
	/// Funcion que llevar� al usuario a la vista detallada de la casa seleccionada
	/// Utilizar� un navigation para poder acceder a la vista correspondiente 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private async void ListaCitasView_ItemTapped(object sender, ItemTappedEventArgs e)
    {

		await Navigation.PushModalAsync(new CitaDetallada(e.Item)) ; 
    }
}