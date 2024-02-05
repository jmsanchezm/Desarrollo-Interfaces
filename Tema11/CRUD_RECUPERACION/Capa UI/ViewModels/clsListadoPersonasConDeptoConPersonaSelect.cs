using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entities;
using Capa_UI.Models;
using Capa_BL;
using System.Net;
using Capa_UI.Views;

namespace Capa_UI.ViewModels
{
    public class clsListadoPersonasConDeptoConPersonaSelect : clsVMBase
    {
        #region Atributos
        private clsPersonaConDepto personaConDeptoSeleccionada;
        private ObservableCollection<clsPersonaConDepto> listado;
        private DelegateCommand insertarCommand;
        private DelegateCommand editarCommand;
        private DelegateCommand eliminarCommand;
        private DelegateCommand filtrarCommand;
        private bool isRunning;
        private string texto;
        #endregion

        #region Constructores
        public clsListadoPersonasConDeptoConPersonaSelect()
        {
            isRunning = true;
            cargarListado();
            personaConDeptoSeleccionada = null;
            insertarCommand = new DelegateCommand(InsertarCommand_Execute);
            editarCommand = new DelegateCommand(EditarCommand_Execute, EditarCommand_CanExecute);
            eliminarCommand = new DelegateCommand(EliminarCommand_Execute, EliminarCommand_CanExecute);
            filtrarCommand = new DelegateCommand(FiltrarCommand_Execute);

        }
        #endregion

        #region Propiedades
        public clsPersonaConDepto PersonaConDeptoSeleccionada
        {
            get { return personaConDeptoSeleccionada; }
            set
            {
                personaConDeptoSeleccionada = value;
                NotifyPropertyChanged("PersonaConDeptoSeleccionada");
                EditarCommand.RaiseCanExecuteChanged();
                EliminarCommand.RaiseCanExecuteChanged();
            }
        }

        public string Texto
        {
            get { return texto; }
            set
            {
                texto = value;
                NotifyPropertyChanged("Texto");
                FiltrarCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsRunning
        {
            get { return isRunning; }
        }

        public ObservableCollection<clsPersonaConDepto> Listado
        {
            get { return listado; }
        }

        public DelegateCommand EditarCommand
        {
            get { return editarCommand; }
        }

        public DelegateCommand EliminarCommand
        {
            get { return eliminarCommand; }
        }

        public DelegateCommand InsertarCommand
        {
            get { return insertarCommand; }
        }

        public DelegateCommand FiltrarCommand
        {
            get { return filtrarCommand; }
        }


        #endregion

        #region Commands

        /// <summary>
        /// Command que navegara a la vista de la insercion de la persona
        /// </summary>
        private async void InsertarCommand_Execute()
        {
            await Shell.Current.Navigation.PushAsync(new InsertarPersona());
        }

        /// <summary>
        /// Command que navegara a la vista de la edicion de la persona
        /// </summary>
        private async void EditarCommand_Execute()
        {
            await Shell.Current.Navigation.PushAsync(new EditarPersona());
        }

        /// <summary>
        /// Command que comprueba si hay una persona seleccionada
        /// </summary>
        /// <returns>Devuelve true o false en funcion de si esta seleccionada una persona</returns>
        private bool EditarCommand_CanExecute()
        {
            bool editar = false;

            if (personaConDeptoSeleccionada != null)
            {
                editar = true;
            }

            return editar;

        }

        /// <summary>
        /// Command que mostrara un display alert preguntando si quiere eliminar a la persona seleccionada
        /// Si su respuesta es si, llamara a la funcion de la capa BL (eliminacion de una persona con el id)
        /// </summary>
        private async void EliminarCommand_Execute()
        {
            HttpStatusCode code;

            bool aceptar = false;

            //Preguntamos si realmente quiere eliminar a la persona
            aceptar = await Shell.Current.DisplayAlert("Eliminar", "¿Esta seguro que desea eliminar esta persona?", "Si", "No");

            //Si es true
            if (aceptar)
            {
                //Llamaremos a la funcion de la capa BL(eliminacion de la persona)
                code = await clsManejadoraPersonaBL.EliminaPersonaBL(PersonaConDeptoSeleccionada.Persona.Id);

                //Si el codigo que nos devuelve la funcion es distinto a 200
                if (code != HttpStatusCode.OK)
                {
                    await Shell.Current.DisplayAlert("Error", "No se ha podido eliminar la persona", "Ok");

                    //En caso contrario, mostyrara un display alert de que se elimino correctamente
                }
                else
                {
                    await Shell.Current.DisplayAlert("Se ha eliminado correctamente", "La persona se ha eliminado correctamente", "Ok");
                }
            }

        }

        /// <summary>
        /// Command que comprueba que hay una persona seleccionada para poder eliminar a una persona
        /// </summary>
        /// <returns>Devuelve true o false en funcion de si esta seleccionada una persona o no</returns>
        private bool EliminarCommand_CanExecute()
        {
            bool eliminar = false;

            if (PersonaConDeptoSeleccionada != null)
            {
                eliminar = true;
            }
            return eliminar;
        }

        /// <summary>
        /// Command que guarda en un observableCollection el listado con la consulta linQ
        /// La consulta es: Que filtre el listado con las personas que contengan el texto para filtrar
        /// </summary>
        public async void FiltrarCommand_Execute()
        {
            ObservableCollection<clsPersonaConDepto> listadoFiltrado = new ObservableCollection<clsPersonaConDepto>(listado.Where(pers => personaConDeptoSeleccionada.Persona.Nombre.Contains(Texto)));

            listado = listadoFiltrado;

            NotifyPropertyChanged("Listado");
        }

        #endregion

        #region Funciones y Metodos

        /// <summary>
        /// Funcion que nos cargara el listado principal llamando a la capa BL
        /// Tambien, hace la conversion de una lista tipo List<> a un ObservableCollection<>
        /// Una vez cargado el listado, notificamos los cambios
        /// </summary>
        private async void cargarListado()
        {
            List<clsPersona> listadoPersonas = await clsListadoPersonasBL.listadoCompletoPersonas();

            listado = new ObservableCollection<clsPersonaConDepto>();

            foreach (clsPersona pers in listadoPersonas)
            {
                clsPersonaConDepto persConDepto = new clsPersonaConDepto(pers);

                listado.Add(persConDepto);
            }
            isRunning = false;
            NotifyPropertyChanged("IsRunning");
            NotifyPropertyChanged("Listado");
        }
        #endregion
    }
}
