using Capa_Entidades;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using static System.Net.WebRequestMethods;

namespace Capa_DAL
{
    // All the code in this file is included in all platforms.
    public class clsListadoPersonasDAL
    {
        /// <summary>
        /// Función que devuelve el listado completo de personas de la API
        /// Precondiciones: No hay
        /// Postcondiciones: El listado siempre devolverá un listado de personas o vacío
        /// </summary>
        /// <returns> Listado de personas </returns>
        public static async Task<List<clsPersona>> listadoCompletoPersonas() 
        {

            string url = $"{clsConexion.cadenaConexion()}personas";

            List<clsPersona> listado = new List<clsPersona>();

            HttpClient miCliente;

            HttpResponseMessage miRespuesta;

            string datosJSON;

            miCliente = new HttpClient();
           
            miRespuesta = await miCliente.GetAsync(url);

            if (miRespuesta.IsSuccessStatusCode)
            {
                datosJSON = await miCliente.GetStringAsync(url);

                miCliente.Dispose();

                listado = JsonConvert.DeserializeObject<List<clsPersona>>(datosJSON);
            }
       
            return listado;
        }
    }
}