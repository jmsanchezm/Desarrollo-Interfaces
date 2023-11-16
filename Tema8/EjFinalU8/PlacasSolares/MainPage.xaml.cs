using Microsoft.Maui.ApplicationModel.Communication;

namespace PlacasSolares
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public async void onClickedButton(object sender, EventArgs e) 
        {
            if (!String.IsNullOrEmpty(Username.Text) && !String.IsNullOrEmpty(Password.Text))
            {
                await Navigation.PushAsync(new ListaTareas());
            }
            else
            {
                TextoCredenciales.IsVisible = true;
            }
            
        }

    }
}