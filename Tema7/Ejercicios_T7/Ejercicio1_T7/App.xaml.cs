using Ejercicio1_T7.Views;

namespace Ejercicio1_T7
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}