using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using Capa_Entities;

namespace Capa_UI.ViewModels
{
    public class clsListadoDeptDeptSeleccionadoVM
    {

        private DelegateCommand buscarDepartamento;
        private List<clsDepartamento> listadoDepartamentos;
        private ObservableCollection<clsDepartamento> lista;
        private DelegateCommand vistaDetallada;
        private DelegateCommand insertar;
        private clsDepartamento departamentoSeleccionado;
        private string textoABuscar;
        private bool isRunning;

        public clsListadoDeptDeptSeleccionadoVM()
        {
            cargarDepartamentos();
            buscarDepartamento = new DelegateCommand(buscar);
            vistaDetallada = new DelegateCommand(detallada);
            isRunning = true;
            insertar = new DelegateCommand(insertarDepartamento);
        }

        private void insertarDepartamento()
        {
            throw new NotImplementedException();
        }

        private void detallada()
        {
            throw new NotImplementedException();
        }

        private void buscar()
        {
            throw new NotImplementedException();
        }

        private void cargarDepartamentos()
        {
            throw new NotImplementedException();
        }

        //Constructor por defecto con el metodo cargarDepartamentos, instanciacion de los comandos
        //(con metodos buscar, detallada e insertarPersona) y el isRunning

        //Propiedades de la lista de departamentos, departamento seleccionado, string de busqueda ,
        //el isRunning y los comandos (en los set del departamento y texto a buscar: NotifyPropertyChanged)


        //Función que carga los departamentos en la lista de departamentos

        //Metodo que busca el departamento por el nombre

        //Método que nos llevará a la página de detalles del departamento

        //Método que nos llevará a la página de inserción de departamento
    }
}
