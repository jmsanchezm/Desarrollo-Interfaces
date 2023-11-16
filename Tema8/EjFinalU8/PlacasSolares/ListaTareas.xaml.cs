namespace PlacasSolares;

public partial class ListaTareas : ContentPage
{
	public ListaTareas()
	{
		InitializeComponent();

		ListView listView = new ListView();
		listView.SetBinding(ItemsView.ItemsSourceProperty, "Casas");
	}
}