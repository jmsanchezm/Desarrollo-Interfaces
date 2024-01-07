using Capa_DAL.Manejadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Capa_Entities;

namespace Capa_BL.ManejadorasBL
{
    public class clsManejadoraDepartamentoBL
    {
        /// <summary>
        /// Función que inserta un departamento en la API
        /// Preconditions: Tiene que llegar un departamento
        /// Postconditions: Se inserta el departamento en la API
        /// </summary>
        /// <param name="depto"></param>
        /// <returns> Código de estado </returns>
        public async static Task<HttpStatusCode> Insert(clsDepartamento depto)
        {
            return await clsManejadoraDepartamentoDAL.Insert(depto);
        }

        /// <summary>
        /// Función que elimina a un departamento de la API
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Código de estado</returns>
        public async static Task<HttpStatusCode> Delete(int id)
        {
            return await clsManejadoraDepartamentoDAL.Delete(id);
        }

        /// <summary>
        /// Función que actualiza a un departamento de la API
        /// Preconditions: Tiene que llegar un departamento
        /// Postconditions: Se actualiza el departamento en la API
        /// </summary>
        /// <param name="depto"></param>
        /// <returns>Código de estado</returns>
        public async static Task<HttpStatusCode> Update(clsDepartamento depto)
        {
            return await clsManejadoraDepartamentoDAL.Update(depto);
        }

    }
}
