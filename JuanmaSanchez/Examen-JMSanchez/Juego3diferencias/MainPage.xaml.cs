using Microsoft.Maui.Controls.Shapes;

namespace Juego3diferencias
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        #region Inicialización del XAML
        public MainPage()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que al detectar el tap en la espalda del perro cambia la opacidad de ambas elipses de ambas imagenes a 100.
        /// Comprueba si estan todas las diferencias marcadas, muestra un mensaje de victoria y las vuelve invisible otra vez
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TapEllipse(object sender, EventArgs e)
        {
            Ellipse ellipseGlobal = (Ellipse)sender;

            ellipseGlobal.Opacity = 1;

            if (bdrCasita.Opacity == 1 && bdrEspalda.Opacity == 1 && bdrHueso.Opacity == 1)
            {
                FinalPartida("Victoria", "Has ganado\n¿Quieres seguir jugando?");

            }
        }

        /// <summary>
        /// Metodo que al detectar el tap en el hueso del cacharro de la comida cambia la opacidad de ambas elipses de ambas imagenes a 100.
        /// Comprueba si estan todas las diferencias marcadas, muestra un mensaje de victoria y las vuelve invisible otra vez
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TapHueso(object sender, EventArgs e)
        {
            bdrHueso.Opacity = 1;
            bdrHueso2.Opacity = 1;

            if (bdrCasita.Opacity == 1 && bdrEspalda.Opacity == 1 && bdrHueso.Opacity == 1)
            {
                FinalPartida("Victoria", "Has ganado\n¿Quieres seguir jugando?");

            }
        }

        /// <summary>
        /// Metodo que al detectar el tap en la casita del perro cambia la opacidad de ambas elipses de ambas imagenes a 100.
        /// Comprueba si estan todas las diferencias marcadas, muestra un mensaje de victoria y las vuelve invisible otra vez
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TapCasita(object sender, EventArgs e)
        {
            bdrCasita.Opacity = 1;
            bdrCasita2.Opacity = 1;

            if (bdrCasita.Opacity == 1 && bdrEspalda.Opacity == 1 && bdrHueso.Opacity == 1)
            {
                FinalPartida("Victoria", "Has ganado\n¿Quieres seguir jugando?");

            }
        }

        /// <summary>
        /// Metodo para detectar los clicks en la imagen y que salte un popup co el error. Si se equivoca 3 veces salta un error definitivo y se cierra o reinicia el juego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TapImagen(object sender, EventArgs e)
        {
            await DisplayAlert("Fallo", "ERROR: Click falso\nIntentos restantes: " + (3 - (count + 1)), "OK");

            count++;

            if (count == 3)
            {
                FinalPartida("Derrota", "Has gastado tus clicks\n¿Quieres seguir jugando?");

            }
        }

        /// <summary>
        /// Metodo que controla el final de la partida
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="mensaje"></param>
        private async void FinalPartida(String titulo, String mensaje)
        {
            bool respuesta = await DisplayAlert(titulo, mensaje, "Si", "No");

            if (respuesta)
            {
                count = 0;

                bdrEspalda.Opacity = 0;
                bdrEspalda2.Opacity = 0;
                bdrHueso.Opacity = 0;
                bdrHueso2.Opacity = 0;
                bdrCasita.Opacity = 0;
                bdrCasita2.Opacity = 0;
            }
            else
            {
                Application.Current.Quit();
            }
        }


        #endregion
    }
}