using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using Capa_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Entities;
using System.Collections.ObjectModel;
using Capa_BL;
using System.ComponentModel;
using Capa_UI.Views;

namespace Capa_UI.ViewModels
{
    public class clsListadoPersonasPersonaSeleccionadaVM:clsVMBase
    {
        #region atributos
        private DelegateCommand buscarPersona;
        private List<clsPersona> listadoPersonas;
        private ObservableCollection<clsPersona> lista;
        private DelegateCommand vistaDetallada;
        private clsPersona personaSeleccionada; 
        private string textoABuscar;
        private DelegateCommand insertar;
        private bool isRunning;

        #endregion

        #region constructores
        public clsListadoPersonasPersonaSeleccionadaVM()
        {

            cargarPersonas();
            buscarPersona = new DelegateCommand(buscar);
            vistaDetallada = new DelegateCommand(detallada);
            isRunning = true;
            insertar = new DelegateCommand(insertarPersona);

        }

        #endregion


        #region propiedades
        public ObservableCollection<clsPersona> Lista
        {
            get { return lista; }
            set { lista = value; }

        }

        public clsPersona PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set
            {
                personaSeleccionada = value;
                NotifyPropertyChanged("PersonaSeleccionada");
            }
        }

        public bool IsRunning
        {
            get { return isRunning; }
        }

        public string TextoABuscar
        {
            get { return textoABuscar; }
            set 
            { 
                textoABuscar = value; 
                NotifyPropertyChanged("TextoABuscar");

            }
        }

        public DelegateCommand BuscarPersona
        {
            get { return buscarPersona; }
        }

        public DelegateCommand VistaDetallada
        {
            get { return vistaDetallada; }
        }

        public DelegateCommand Insertar
        {
            get { return insertar; }
        }

        #endregion

        #region funciones
        private async Task cargarPersonas()
        {
            listadoPersonas = await clsListadoPersonasBL.listadoPersonas();
            
            lista = new ObservableCollection<clsPersona>(listadoPersonas);

            isRunning = false;

            NotifyPropertyChanged("Lista");
            NotifyPropertyChanged("IsRunning");

        }

        private void buscar()
        {
            Lista = new ObservableCollection<clsPersona>(listadoPersonas.Where(x => x.Nombre.Contains(textoABuscar)));

            NotifyPropertyChanged("Lista");
        }

        private async void detallada(clsPersona persSelect)
        {
            await Shell.Current.Navigation.PushAsync(new DetallePersona(persSelect));
        }

        private async void insertarPersona()
        {
            await Shell.Current.Navigation.PushAsync(new InsertaPersona());
        }

        #endregion
    }
}
