using Capa_Entities;
using Capa_UI.ViewModels;

namespace Capa_UI.Views;

public partial class DetallePersona : ContentPage
{
	public DetallePersona()
	{
		InitializeComponent();
	}

	public DetallePersona(clsPersona persona)
	{
        InitializeComponent();
        BindingContext = new clsDetallesPersonaVM(persona);
    }
}