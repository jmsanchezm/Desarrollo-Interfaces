using Capa_DAL;
using Capa_Entidades;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Capa_BL
{
    public class clsListadoPersonasBL
    {
        public static async Task<ObservableCollection<clsPersona>> ListadoCompletoPersonas()
        {
            return await clsListadoPersonasDAL.listadoCompletoPersonas();
           
        }
    }
}