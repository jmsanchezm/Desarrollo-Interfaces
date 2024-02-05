using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using Capa_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Android.Views;

namespace Capa_UI.ViewModels
{
    public class clsDetallesPersonaVM
    {
        #region atributos
        private clsPersona persona;
        private DelegateCommand editar;
        private DelegateCommand eliminar;
        #endregion

        #region constructores

       

        public clsDetallesPersonaVM(clsPersona pers)
        {
            persona = pers;
            editar = new DelegateCommand(editarPersona);
            eliminar = new DelegateCommand(eliminarPersona);
        }

        #endregion

        #region propiedades
        public clsPersona Persona
        {
            get { return persona; }
            set { persona = value; }
        }
        #endregion

        #region commands

        public DelegateCommand Editar
        {
            get { return editar; }
        }

        public DelegateCommand Eliminar
        {
            get { return eliminar; }
        }

        #endregion

        #region metodos

        private async void eliminarPersona()
        {
            //Método que le mostrará un mensaje al usuario para confirmar la eliminación de la persona
            //Si el usuario confirma la eliminación, se eliminará la persona de la base de datos y se volverá a la página de listado de personas
            //Para la eliminación de la persona, llamaremos al método Delete de la capa BL
        }

        private void editarPersona()
        {
            //Método que nos llevará a la página de edición de la persona
            //Para ello, crearemos una nueva vista de edición de persona y le pasaremos la persona a editar
        }

        #endregion
    }
}
