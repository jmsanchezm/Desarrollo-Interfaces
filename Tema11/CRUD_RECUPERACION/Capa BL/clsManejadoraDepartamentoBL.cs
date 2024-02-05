using System.Net;
using Capa_DAL;
using Capa_Entities;

namespace Capa_BL
{
    public class clsManejadoraDepartamentoBL
    {
        /// <summary>
        /// Metodo que llamara al metodo de la capa DAL (insercion de un departamento)
        /// </summary>
        /// <param name="depto"></param>
        /// <returns>Devuelve el codigo de estado</returns>
        public async static Task<HttpStatusCode> InsertarDeptoBL(clsDepartamento depto)
        {
            return await clsManejadoraDeptoDAL.InsertarDeptoDAL(depto);
        }

        /// <summary>
        /// Metodo que llamara al metodo de la capa DAl (eliminacion de un departamento)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve el codigo de estado</returns>
        public async static Task<HttpStatusCode> EliminarDeptoBL(int id)
        {
            return await clsManejadoraDeptoDAL.EliminarDeptoDAL(id);
        }


        /// <summary>
        /// Metodo que llamara al metodo de la capa DAL (edicion de un departamento)
        /// </summary>
        /// <param name="depto"></param>
        /// <returns>Devuelve el codigo de estado</returns>
        public async static Task<HttpStatusCode> EditarDeptoBL(clsDepartamento depto)
        {
            return await clsManejadoraDeptoDAL.EditarDeptoDAL(depto);
        }
    }
}
