namespace Calendarios
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            // Establecemos la fecha mínima a el día de hoy
            entrada.MinimumDate = DateTime.Now;
            salida.MinimumDate = entrada.MinimumDate.AddDays(1);
        }

        private void entrada_DateSelected(object sender, DateChangedEventArgs e)
        {
            salida.MinimumDate = entrada.Date.AddDays(1);
        }


    }
}