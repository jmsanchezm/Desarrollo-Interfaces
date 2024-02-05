using System.Net;
using Capa_Entities;
using Capa_DAL;

namespace Capa_BL
{
    public class clsManejadoraPersonaBL
    {
        /// <summary>
        /// Metodo que llama al metodo de la capa DAL (insercion de una persona)
        /// </summary>
        /// <param name="pers"></param>
        /// <returns>Devuelve el codigo de estado</returns>
        public async static Task<HttpStatusCode> InsertarPersonaBL(clsPersona pers)
        {
            return await clsManejadoraPersonaDAL.InsertarPersonaDAL(pers);
        }

        /// <summary>
        /// Metodo que llama al metodo de la capa DAL (eliminacion de una persona)
        /// aplicando la regla de negocio (si es un dia distinto a domingo)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve el codigo de estado</returns>
        public async static Task<HttpStatusCode> EliminaPersonaBL(int id)
        {
            DateTime fechaActual = DateTime.Now;
            HttpStatusCode codigo;

            //Si el dia es distinto a domingo
            if (fechaActual.DayOfWeek != DayOfWeek.Sunday)
            {
                //Ejecutara el metodo de la capa DAL
                codigo = await clsManejadoraPersonaDAL.EliminarPersonaDAL(id);
            }
            //En caso contrario
            else
            {
                //El servidor recibira la solicitud, la entendera, pero la rechazara
                //HttpStatusCode.Forbidden = 403
                codigo = HttpStatusCode.Forbidden;
            }

            return codigo;
        }

        /// <summary>
        /// Metodo que llama al metodo de la capa DAL (edicion de persona)
        /// </summary>
        /// <param name="pers"></param>
        /// <returns>Devuelve el codigo de estado</returns>
        public async static Task<HttpStatusCode> EditarPersonaBL(clsPersona pers)
        {
            return await clsManejadoraPersonaDAL.EditarPersonaDAL(pers);
        }


    }
}
