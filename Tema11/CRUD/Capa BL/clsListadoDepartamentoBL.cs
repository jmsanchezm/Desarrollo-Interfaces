using Capa_DAL;
using Capa_Entities;

namespace Capa_BL
{

    public class clsListadoDepartamentoBL
    {
        /// <summary>
        /// Metodo que devuelve un listado completo de departamentos de una API
        /// Con reglas de negocio
        /// </summary>
        /// <returns>listado de departamentos</returns>
        public static Task<List<clsDepartamento>> listadoDepartamento() 
        { 
            return clsListadoDepartamentosDAL.listadoCompletoDepartamento();   
        }
    }
}