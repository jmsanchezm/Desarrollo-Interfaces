using Capa_Entities;
using Capa_UI.Models;
using Capa_UI.Views;
using System;
using System.Collections.Generic;
using Capa_BL;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Capa_UI.ViewModels
{
    public class clsEditarDepartamento: clsVMBase
    {
        private clsDepartamento depto;
        private DelegateCommand guardarCommand;
        private DelegateCommand cancelarCommand;

        public clsEditarDepartamento()
        {
            depto = new clsDepartamento();
            guardarCommand = new DelegateCommand(GuardarCommand_Execute);
            cancelarCommand = new DelegateCommand(CancelarCommand_Execute);
        }   

        public clsEditarDepartamento(clsDepartamento depto)
        {
            this.depto = depto;
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
        /// Funcion que se encarga de ejercutar el metodo de editar departamento de la capa BL
        /// Si se ha editado correctamente, se mostrara un mensaje y se navegara a la vista de listado de departamentos
        /// En caso contrario, se mostrara un mensaje de error y se navegara a la vista de listado de departamentos
        /// </summary>
        private async void GuardarCommand_Execute()
        {
            HttpStatusCode code;

            code = await clsManejadoraDepartamentoBL.EditarDeptoBL(depto);

            if (code == HttpStatusCode.OK)
            {
                await Shell.Current.DisplayAlert("Mensaje", "Departamento editado correctamente", "Aceptar");

                await Shell.Current.Navigation.PushAsync(new ListadoDepartamentos());
            }else
            {
                await Shell.Current.DisplayAlert("Mensaje", "Error al editar el departamento", "Aceptar");

                await Shell.Current.Navigation.PushAsync(new ListadoDepartamentos());
            }
        }

        /// <summary>
        /// Funcion por la que se podra cancelar la operacion
        /// En caso de aceptar, navegara a la vista de listado de departamentos
        /// </summary>
        private async void CancelarCommand_Execute()
        {
            bool cancelar;

            cancelar = await Shell.Current.DisplayAlert("Mensaje", "¿Desea cancelar la operación?", "Si", "No");

            if (cancelar)
            {
                await Shell.Current.Navigation.PushAsync(new ListadoDepartamentos());
            }
        }



    }
}
