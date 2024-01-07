using Capa_DAL.Manejadoras;
using Capa_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Capa_BL.ManejadorasBL
{
    public class clsManejadoraPersonaBL
    {
        /// <summary>
        /// Función que inserta una persona en la API
        /// Preconditions: Tiene que llegar una persona
        /// Postconditions: Se inserta la persona en la API
        /// </summary>
        /// <param name="pers"></param>
        /// <returns>Código de estado</returns>
        public async static Task<HttpStatusCode> Insert(clsPersona pers) 
        { 
        
            return await clsManejadoraPersonaDAL.Insert(pers);

        }

        /// <summary>
        /// Función que elimina a una persona de la API
        /// Con la condición de que no sea domingo
        /// Si es domingo, no se elimina
        /// Preconditions: Tiene que llegar un id de una persona
        /// Postconditions: Se elimina la persona de la API si no es domingo
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Código de estado</returns>
        public async static Task<HttpStatusCode> Delete(int id)
        {
        
            HttpStatusCode codigo;

            DateTime fechaActual = DateTime.Now;

            if (fechaActual.DayOfWeek != DayOfWeek.Sunday)
            {
                codigo = await clsManejadoraPersonaDAL.Delete(id);
            }
            else 
            {
                //HttpStatusCode.Forbidden = 403
                //El servidor entendió la solicitud, pero rechaza cumplirla.
                codigo = HttpStatusCode.Forbidden;
            }

            return codigo;

        }

        /// <summary>
        /// Función que actualiza a una persona de la API 
        /// Preconditions: Tiene que llegar una persona
        /// Postconditions: Se actualiza la persona en la API
        /// </summary>
        /// <param name="pers"></param>
        /// <returns>Código de estado</returns>
        public async static Task<HttpStatusCode> Update(clsPersona pers)
        {
        
            return await clsManejadoraPersonaDAL.Update(pers);

        }


    }
}
