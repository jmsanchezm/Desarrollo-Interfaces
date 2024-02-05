using Capa_BL;
using Capa_Entities;
using Capa_UI.Models;
using Capa_UI.Views;
using System.Collections.ObjectModel;
using System.Net;

namespace Capa_UI.ViewModels
{
    public class clsEditarPersona : clsVMBase
    {
        private clsPersonaConDepto persona;
        private DelegateCommand guardarCommand;
        private DelegateCommand cancelarCommand;    
        private ObservableCollection<clsDepartamento> listadoDeptos;

        public clsEditarPersona()
        {

            cargarListado();
            guardarCommand = new DelegateCommand(GuardarCommand_Execute);
            cancelarCommand = new DelegateCommand(CancelarCommand_Execute);
        }

        public clsEditarPersona(clsPersonaConDepto persona)
        {
            this.persona = persona;
        }

        public clsPersonaConDepto Persona
        {
            get { return persona; }
            set
            {
                persona = value;
                guardarCommand.RaiseCanExecuteChanged();
                cancelarCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand GuardarCommand
        {
            get { return guardarCommand; }
        }

        public DelegateCommand CancelarCommand
        {
            get { return cancelarCommand; }
        }

        /// <summary>
        /// Funcion por la que se podra cancelar la operacion
        /// En caso de aceptar, navegara a la vista de listado de personas
        /// </summary>
        private async void CancelarCommand_Execute()
        {
            bool cancelar;

            cancelar = await Shell.Current.DisplayAlert("Mensaje", "¿Desea cancelar la edición?", "Sí", "No");

            if (cancelar)
            {
                await Shell.Current.Navigation.PushAsync(new ListadoPersonas());
            }

        }

        /// <summary>
        /// Funcion que ejecutara la funcion de edicion de la persona de la capa Bl
        /// Si la operacion es correcta, navegara a la vista de listado de personas, mostrando un mensaje de exito
        /// En caso contrario, mostrara un mensaje de error y navegara al listado de personas
        /// </summary>
        private async void GuardarCommand_Execute()
        {
            HttpStatusCode code;

            code = await clsManejadoraPersonaBL.EditarPersonaBL(persona.Persona);

            if (code == HttpStatusCode.OK)
            {
                await Shell.Current.DisplayAlert("Mensaje", "Persona editada correctamente", "Aceptar");

                await Shell.Current.Navigation.PushAsync(new ListadoPersonas());
            }
            else
            {
                await Shell.Current.DisplayAlert("Mensaje", "Error al editar la persona", "Aceptar");

                await Shell.Current.Navigation.PushAsync(new ListadoPersonas());
            }
        }

        /// <summary>
        /// Funcion que cargara el listado de departamentos
        /// </summary>
        private async void cargarListado()
        {
            List<clsDepartamento> lista = await clsListadoDeptoBL.listadoCompletoDeptos();
            listadoDeptos = new ObservableCollection<clsDepartamento>(lista);

            NotifyPropertyChanged("ListadoDeptos");
        }

    }
}
