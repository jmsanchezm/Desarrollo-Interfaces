using Capa_Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL.Manejadoras
{
    public class clsManejadoraPersonaDAL
    {
        /// <summary>
        /// Función que inserta una persona en la API
        /// Preconditions: Tiene que llegar una persona
        /// Postconditions: Se inserta la persona en la API
        /// </summary>
        /// <param name="pers"></param>
        /// <returns> Código de estado </returns>
        public async static Task<HttpStatusCode> Insert(clsPersona pers)
        {

            HttpClient client = new HttpClient();

            string datos;

            HttpContent contenido;

            string uri = clsConexion.getConexion();

            Uri miUri = new Uri($"{uri}Personas");

            HttpResponseMessage respuesta = new HttpResponseMessage();

            try
            {
                //Serializamos la persona
                datos = JsonConvert.SerializeObject(pers);

                //Creamos el contenido con la persona
                contenido = new StringContent(datos, Encoding.UTF8, "application/json");

                //Hacemos la peticion
                respuesta = await client.PostAsync(miUri, contenido);

            }
            catch (Exception e)
            {
                throw e;
            }

            return respuesta.StatusCode;
        }

        /// <summary>
        /// Función que elimina a una persona de la API 
        /// Preconditions: Tiene que llegar un id de una persona
        /// Postconditions: Se elimina la persona de la API
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Código de estado  </returns>
        public async static Task<HttpStatusCode> Delete(int id)
        {
            HttpClient client = new HttpClient();

            string uri = clsConexion.getConexion();

            Uri miUri = new Uri($"{uri}Personas/{id}");

            HttpResponseMessage respuesta = new HttpResponseMessage();

            try
            {
                //Hacemos la peticion
                respuesta = await client.DeleteAsync(miUri);

            }
            catch (Exception e)
            {
                throw e;
            }

            return respuesta.StatusCode;
        }

        /// <summary>
        /// Función que actualiza a una persona de la API
        /// Preconditions: Tiene que llegar una persona
        /// Postconditions: Se actualiza la persona de la API
        /// </summary>
        /// <param name="pers"></param>
        /// <returns> Código de estado </returns>
        public async static Task<HttpStatusCode> Update(clsPersona pers)
        {
            HttpClient client = new HttpClient();

            string datos;

            HttpContent contenido;

            string uri = clsConexion.getConexion();

            Uri miUri = new Uri($"{uri}Personas/{pers.Id}");

            HttpResponseMessage respuesta = new HttpResponseMessage();

            try
            {
                //Serializamos la persona
                datos = JsonConvert.SerializeObject(pers);

                //Creamos el contenido con la persona
                contenido = new StringContent(datos, Encoding.UTF8, "application/json");

                //Hacemos la peticion
                respuesta = await client.PutAsync(miUri, contenido);

            }
            catch (Exception e)
            {
                throw e;
            }

            return respuesta.StatusCode;
        }

    }
}
