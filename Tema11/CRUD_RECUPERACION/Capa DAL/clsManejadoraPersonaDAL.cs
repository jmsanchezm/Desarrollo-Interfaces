using Capa_Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL
{
    public class clsManejadoraPersonaDAL
    {
        /// <summary>
        /// Metodo que inserta en la base de datos una persona 
        /// Precondiciones: Le tiene que llegar una persona
        /// </summary>
        /// <param name="pers"></param>
        /// <returns>Devuelve el codigo de estado</returns>
        public static async Task<HttpStatusCode> InsertarPersonaDAL(clsPersona pers) 
        {
       
            HttpClient client = new HttpClient();
            
            string datos;
            
            HttpContent content;
            
            string cadena = clsConexion.getConexion();

            Uri uri = new Uri($"{cadena}Personas");

            HttpResponseMessage response = new HttpResponseMessage();

            try 
            {
                datos = JsonConvert.SerializeObject( pers );

                content = new StringContent( datos , System.Text.Encoding.UTF8, "application/json");

                response = await client.PostAsync( uri, content );  

            } catch ( Exception ex ) 
            {
                throw ex;
            }

            return response.StatusCode;
        }

        /// <summary>
        /// Metodo que edita una persona de la base de datos
        /// Precondiciones: Le debe llegar una persona
        /// </summary>
        /// <param name="pers"></param>
        /// <returns>Devuelve el codigo de estado</returns>
        public static async Task<HttpStatusCode> EditarPersonaDAL(clsPersona pers) 
        {
            HttpClient client = new HttpClient();

            string datos;

            HttpContent content;

            string cadena = clsConexion.getConexion();

            Uri uri = new Uri($"{cadena}Personas/{pers.Id}");

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                datos = JsonConvert.SerializeObject(pers);

                content = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");

                response = await client.PutAsync(uri, content);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response.StatusCode;
        }

        /// <summary>
        /// Metodo que elimina una persona de la base de datos
        /// Precondiciones: Le tiene que llegar el id de una persona 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<HttpStatusCode> EliminarPersonaDAL(int id) 
        {
            HttpClient client = new HttpClient();

            string datos;

            HttpContent content;

            string cadena = clsConexion.getConexion();

            Uri uri = new Uri($"{cadena}Personas/{id}");

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {

                response = await client.DeleteAsync(uri);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response.StatusCode;
        }
    }
}
