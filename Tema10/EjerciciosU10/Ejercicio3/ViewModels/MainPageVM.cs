
using System.ComponentModel;
using System.Windows.Input;

namespace Ejercicio3.ViewModels 
{
    public class MainPageVM : NotifyVM
    {

        #region atributos

        private string resultado;
        private DelegateCommand numerosCommand;
        private DelegateCommand demasCommand;
        
        #endregion

        #region Constructores
        public MainPageVM()
        {
            this.resultado = "0";

        }
        #endregion

        #region Propiedades
        public string Resultado
        {
            get { return this.resultado; }
            private set
            {
                if (resultado != value)
                {
                    resultado = value;
                    NotifyPropertyChanged(nameof(resultado));
                }
            }
        }

        public DelegateCommand NumerosCommand
        {
            get { return numerosCommand; }
        }

        public DelegateCommand DemasCommand
        {
            get { return demasCommand; }
        }
        #endregion

        #region Comandos
        private void numerosCommandExecute()
        {

        }

        private void demasCommandExecute()
        {

        }
        #endregion

    }
}
