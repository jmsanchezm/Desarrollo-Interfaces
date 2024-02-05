using Capa_DAL;
using Capa_Entities;

namespace Capa_BL
{
    public class clsListadoDeptoBL
    {
        /// <summary>
        /// Metodo que llama al metodo de la capa DAL (listado de departamentos)
        /// </summary>
        /// <returns></returns>
        public async static Task<List<clsDepartamento>> listadoCompletoDeptos()
        {
            return await clsListadoDepartamentosDAL.listadoCompletoDeptos();
        }

    }
}
