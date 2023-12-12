using Capa_DAL;
using Capa_Entidades;


namespace Capa_BL
{
    public class clsListadoPersonasBL
    {
        /// <summary>
        /// Funcion que llama a la capa DAL para obtener el listado de personas
        /// y aplicarles reglas de negocio correspondientes
        /// </summary>
        /// <returns> Listado de personas con regla aplicada </returns>
        public static async Task<List<clsPersona>> ListadoCompletoPersonas()
        {
            return await clsListadoPersonasDAL.listadoCompletoPersonas();
           
        }
    }
}