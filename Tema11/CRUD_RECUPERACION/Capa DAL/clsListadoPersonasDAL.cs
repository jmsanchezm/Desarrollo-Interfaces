using Capa_Entities;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Capa_DAL
{
    // All the code in this file is included in all platforms.
    public class clsListadoPersonasDAL
    {

        public async static Task<List<clsPersona>> listadoCompletoPersonas()
        {
            string miCadenaBase = clsConexion.getConexion();

            Uri uri = new Uri($"{miCadenaBase}Personas");

            List<clsPersona> listadoPersonas = new List<clsPersona>();

            HttpClient client = new HttpClient();

            HttpResponseMessage response;

            string jsonRespuesta;

            try
            {
                
                response = await client.GetAsync( uri );

                if (response.IsSuccessStatusCode) 
                { 
                    jsonRespuesta = await client.GetStringAsync(uri);

                    client.Dispose();

                    listadoPersonas = JsonConvert.DeserializeObject<List<clsPersona>>(jsonRespuesta);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listadoPersonas;
        }

    }
}
