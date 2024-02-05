using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Capa_Entities;
using Capa_BL;
using Capa_UI.Models;
using Capa_UI.Views;

namespace Capa_UI.ViewModels
{
    public  class clsInsertarDepartamento
    {

        private clsDepartamento depto;
        private DelegateCommand guardarCommand;
        private DelegateCommand cancelarCommand;

        public clsInsertarDepartamento()
        {
            depto = new clsDepartamento();
            guardarCommand = new DelegateCommand(GuardarCommand_Execute);
            cancelarCommand = new DelegateCommand(CancelarCommand_Execute);
        }


        public clsDepartamento Depto
        {
            get { return depto; }
            set
            {
                depto = value;
                cancelarCommand.RaiseCanExecuteChanged();
                guardarCommand.RaiseCanExecuteChanged();
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
        /// Metodo que se encarga de insertar un departamento en la base de datos
        /// Si se ha insertado correctamente, se mostrara un mensaje y se navegara a la vista de listado de departamentos
        /// En caso contrario, se mostrara un mensaje de error y se navegara a la vista de listado de departamentos
        /// </summary>
        private async void GuardarCommand_Execute()
        {
            HttpStatusCode code;

            code = await clsManejadoraDepartamentoBL.InsertarDeptoBL(depto);

            if (code == HttpStatusCode.Created)
            {
                await Shell.Current.DisplayAlert("Mensaje", "Departamento insertado correctamente", "Aceptar");

                await Shell.Current.Navigation.PushAsync(new ListadoDepartamentos());
            }
            else
            {
                await Shell.Current.DisplayAlert("Mensaje", "Error al insertar el departamento", "Aceptar");

                await Shell.Current.Navigation.PushAsync(new ListadoDepartamentos());
            }
        }

        /// <summary>
        /// Metodo por el que se podra cancelar la operacion
        /// Si se acepta, navegara a la vista de listado de departamentos
        /// </summary>
        private async void CancelarCommand_Execute()
        {
            bool cancelar;

            cancelar = await Shell.Current.DisplayAlert("Mensaje", "Desea cancelar la operacion?", "Aceptar", "Cancelar");

            if (cancelar)
            {
                await Shell.Current.Navigation.PushAsync(new ListadoDepartamentos());
            }

        }

    }
}
