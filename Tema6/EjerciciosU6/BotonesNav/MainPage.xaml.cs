namespace BotonesNav
{
    public partial class MainPage : ContentPage
    {
        public Boolean yaExisteBtn3 = false;


        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Descripción: método que comprueba si el botón 3 existe y en caso contrario, lo crea.
        /// Precondiciones: que el sender 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCounterClicked(object sender, EventArgs e)
        {
            if (!yaExisteBtn3)
            {
                Button boton = new Button
                {
                    Text = "Boton3",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    BackgroundColor = Colors.LightBlue,
                    HeightRequest = 70,
                    WidthRequest = 200,
                    FontFamily = "Verdana",
                    FontSize = 16,
                    FontAttributes = FontAttributes.Bold,
                    BorderColor = Colors.Yellow,
                    Margin = 30
                };
                //añadimos un botón y añadimos el evento.

                vslButtons.Add(boton);
                boton.Clicked += OnCounterClicked;

                //también se puede hacer btn3.Clicked += new System.EventHandler(evento_ClickedBtn3);
                yaExisteBtn3 = true;

            }
        }
    }
}