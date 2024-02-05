using Capa_UI.Models;
using Capa_Entities;
using Capa_BL;
using System.Collections.ObjectModel;
using System.Net;
using Capa_UI.Views;

namespace Capa_UI.ViewModels
{
    public class clsInsertarPersona : clsVMBase
    {
        clsPersona pers;
        DelegateCommand guardarCommand;
        DelegateCommand cancelarCommand;
        ObservableCollection<clsDepartamento> listadoDeptos;
        clsDepartamento depto;

        public clsInsertarPersona()
        {
            cargarListado();
            this.pers = new clsPersona();
            this.depto = new clsDepartamento();
            guardarCommand = new DelegateCommand(GuardarCommand_Execute);
            cancelarCommand = new DelegateCommand(CancelarCommand_Execute);
        }


        public clsPersona Pers
        {
            get { return pers; }
            set
            {
                pers = value;
                pers.IdDepartamento = depto.IdDepartamento;
                NotifyPropertyChanged("Pers");
                guardarCommand.RaiseCanExecuteChanged();
                cancelarCommand.RaiseCanExecuteChanged();   
            }
        }

        public clsDepartamento Depto
        {
            get { return depto; }
            set
            {
                depto = value;
                NotifyPropertyChanged("Depto");
            }
        }

        public ObservableCollection<clsDepartamento> ListadoDeptos
        {
            get { return listadoDeptos; }
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
        /// Si se acepta, navegara a la vista de listado de personas
        /// </summary>
        private async void CancelarCommand_Execute()
        {
            bool cancelar;

            cancelar = await Shell.Current.DisplayAlert("Mensaje", "¿Desea cancelar la operación?", "Si", "No");

            if (cancelar)
            {
                await Shell.Current.Navigation.PushAsync(new ListadoPersonas());
            }
        }

        /// <summary>
        /// Funcion que se encarga de insertar una persona en la base de datos
        /// Si se ha insertado correctamente, se mostrara un mensaje y se navegara a la vista de listado de personas
        /// En caso contrario, se mostrara un mensaje de error y se navegara a la vista de listado de personas
        /// </summary>
        private async void GuardarCommand_Execute()
        {
            HttpStatusCode code;

            code = await clsManejadoraPersonaBL.InsertarPersonaBL(pers);

            if (code == HttpStatusCode.Created)
            {
                await Shell.Current.DisplayAlert("Mensaje", "Persona insertada correctamente", "Aceptar");

                await Shell.Current.Navigation.PushAsync(new ListadoPersonas());

            }
            else
            {
                await Shell.Current.DisplayAlert("Mensaje", "Error al insertar la persona", "Aceptar");

                await Shell.Current.Navigation.PushAsync(new ListadoPersonas());

            }
        }

        /// <summary>
        /// Funcion que se encarga de cargar el listado de departamentos
        /// </summary>
        private async void cargarListado()
        {
            List<clsDepartamento> lista = await clsListadoDeptoBL.listadoCompletoDeptos();
            listadoDeptos = new ObservableCollection<clsDepartamento>(lista);

            NotifyPropertyChanged("ListadoDeptos");
        }


    }
}
