using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Capa_BL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Capa_UI.Models.ViewModel
{
    public class ListadoPersonasVM
    {

        private Task<ObservableCollection<clsPersona>> listado;
        

        public ListadoPersonasVM()
        {
            try
            {
                listado = clsListadoPersonasBL.ListadoCompletoPersonas();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Task<ObservableCollection<clsPersona>> Listado
        {
            get { return listado; }
            set { listado = value; }

        }

  

        

    }


}

