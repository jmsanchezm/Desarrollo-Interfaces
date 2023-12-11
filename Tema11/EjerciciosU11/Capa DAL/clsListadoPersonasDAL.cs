using Capa_Entidades;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using static System.Net.WebRequestMethods;

namespace Capa_DAL
{
    // All the code in this file is included in all platforms.
    public class clsListadoPersonasDAL
    {
        public static async Task<ObservableCollection<clsPersona>> listadoCompletoPersonas() 
        {
            string urlBase = "https://crudnervion.azurewebsites.net/api/";
            string url = $"{urlBase}personas";

            ObservableCollection<clsPersona> listado = new ObservableCollection<clsPersona>();

            HttpClient miCliente;

            HttpResponseMessage miRespuesta;

            string datosJSON;

            miCliente = new HttpClient();

            try
            {
                miRespuesta = await miCliente.GetAsync(url);

                if (miRespuesta.IsSuccessStatusCode)
                {
                    datosJSON = await miCliente.GetStringAsync(url);

                    miCliente.Dispose();


                    listado = JsonConvert.DeserializeObject<ObservableCollection<clsPersona>>(datosJSON);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return listado;
        }
    }
}