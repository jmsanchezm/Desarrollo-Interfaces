using Capa_BL;
using Capa_Entities;
using Capa_UI.Models;
using Capa_UI.Views;
using System.Collections.ObjectModel;
using System.Net;

namespace Capa_UI.ViewModels
{
    public class clsListadoDepartamentosConDeptoSelect : clsVMBase
    {

        #region Atributos
        private clsDepartamento deptoSeleccionado;
        private ObservableCollection<clsDepartamento> listado;
        private DelegateCommand insertarCommand;
        private DelegateCommand editarCommand;
        private DelegateCommand eliminarCommand;
        private DelegateCommand filtrarCommand;
        private bool isRunning;
        private string texto;
        #endregion

        #region Constructores
        public clsListadoDepartamentosConDeptoSelect()
        {
            isRunning = true;
            cargarListado();
            deptoSeleccionado = null;
            insertarCommand = new DelegateCommand(InsertarCommand_Execute);
            editarCommand = new DelegateCommand(EditarCommand_Execute, EditarCommand_CanExecute);
            eliminarCommand = new DelegateCommand(EliminarCommand_Execute, EliminarCommand_CanExecute);
            filtrarCommand = new DelegateCommand(FiltrarCommand_Execute);
        }
        #endregion

        #region Propiedades

        public clsDepartamento DeptoSeleccionado
        {
            get { return deptoSeleccionado; }
            set
            {
                deptoSeleccionado = value;
                NotifyPropertyChanged("DeptoSeleccionado");
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

        public ObservableCollection<clsDepartamento> Listado
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
            await Shell.Current.Navigation.PushAsync(new InsertarDepartamento());
        }

        /// <summary>
        /// Command que navegara a la vista de la edicion de la persona
        /// </summary>
        private async void EditarCommand_Execute()
        {
            await Shell.Current.Navigation.PushAsync(new EditarDepartamento());
        }

        /// <summary>
        /// Command que comprueba si hay una persona seleccionada
        /// </summary>
        /// <returns>Devuelve true o false en funcion de si esta seleccionada una persona</returns>
        private bool EditarCommand_CanExecute()
        {
            bool editar = false;

            if (deptoSeleccionado != null)
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
            aceptar = await Shell.Current.DisplayAlert("Eliminar", "¿Esta seguro que desea eliminar este departamento?", "Si", "No");

            //Si es true
            if (aceptar)
            {
                //Llamaremos a la funcion de la capa BL(eliminacion de la persona)
                code = await clsManejadoraDepartamentoBL.EliminarDeptoBL(deptoSeleccionado.IdDepartamento);

                //Si el codigo que nos devuelve la funcion es distinto a 200
                if (code != HttpStatusCode.OK)
                {
                    await Shell.Current.DisplayAlert("Error", "No se ha podido eliminar el departamento", "Ok");

                    //En caso contrario, mostyrara un display alert de que se elimino correctamente
                }
                else
                {
                    await Shell.Current.DisplayAlert("Se ha eliminado correctamente", "El departamento se ha eliminado correctamente", "Ok");
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

            if (deptoSeleccionado != null)
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
            ObservableCollection<clsDepartamento> listadoFiltrado = new ObservableCollection<clsDepartamento>(listado.Where(depto => depto.Nombre.Contains(Texto)));

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
            List<clsDepartamento> listadoDeptos = await clsListadoDeptoBL.listadoCompletoDeptos();

            listado = new ObservableCollection<clsDepartamento>();

            foreach (clsDepartamento deptos in listadoDeptos)
            {
                clsDepartamento depto = new clsDepartamento(deptos);

                listado.Add(depto);
            }

            isRunning = false;
            NotifyPropertyChanged("IsRunning");
            NotifyPropertyChanged("Listado");
        }
        #endregion

    }
}
