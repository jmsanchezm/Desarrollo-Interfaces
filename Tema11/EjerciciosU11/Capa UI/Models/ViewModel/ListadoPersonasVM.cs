﻿using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Capa_BL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Capa_UI.Models.ViewModel
{
    public class ListadoPersonasVM : INotifyPropertyChanged
    {
        #region atributos

        private List<clsPersona> listadoPersonas;

        private ObservableCollection<clsPersona> listado;

        private bool isRunning;

        #endregion

        #region constructores
        public ListadoPersonasVM()
        {

           cargarPersonas();
           isRunning=true;

    }

        #endregion


        #region propiedades
        public ObservableCollection<clsPersona> Listado
        {
            get { return listado; }

        }

        public bool IsRunning
        {
            get { return isRunning; }
        }

        #endregion



        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Funcion que llama a la capa BL para obtener el listado de personas
        /// </summary>
        /// <returns></returns>
        private async Task cargarPersonas()
        {
            listadoPersonas = await clsListadoPersonasBL.ListadoCompletoPersonas();
            listado = new ObservableCollection<clsPersona>(listadoPersonas);

            isRunning = false;

            OnPropertyChanged("Listado");
            OnPropertyChanged("IsRunning");

        }

        private void OnPropertyChanged(String property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }


}

