using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Capa_Entities;

namespace Capa_DAL.Manejadoras
{
    public class clsManejadoraDepartamentoDAL
    {
        
        /// <summary>
        /// Función que inserta un departamento en la API
        /// Preconditions: Tiene que llegar un departamento
        /// Postconditions: Se inserta el departamento en la API
        /// </summary>
        /// <param name="depto"></param>
        /// <returns>Código de estado</returns>
        public async static Task<HttpStatusCode> Insert(clsDepartamento depto)
        {

            HttpClient client = new HttpClient();

            string datos;

            HttpContent contenido;

            string uri = clsConexion.getConexion();

            Uri miUri = new Uri($"{uri}Departamentos");

            HttpResponseMessage respuesta = new HttpResponseMessage();

            try
            {
                //Serializamos el departamento
                datos = JsonConvert.SerializeObject(depto);

                //Creamos el contenido con el departamento
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
        /// Función que elimina un departamento de la API
        /// Preconditions: Tiene que llegar un id de un departamento
        /// Preconditions: Se elimina el departamento de la API
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Código de estado </returns>
        public async static Task<HttpStatusCode> Delete(int id)
        {

            HttpClient client = new HttpClient();

            string uri = clsConexion.getConexion();

            Uri miUri = new Uri($"{uri}Departamentos/{id}");

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
        /// Función que actualiza un departamento de la API
        /// Preconditions: Tiene que llegar un departamento
        /// Postconditions: Se actualiza el departamento de la API
        /// </summary>
        /// <param name="depto"></param>
        /// <returns> Código de estado </returns>
        public async static Task<HttpStatusCode> Update(clsDepartamento depto)
        {

            HttpClient client = new HttpClient();

            string datos;

            HttpContent contenido;

            string uri = clsConexion.getConexion();

            Uri miUri = new Uri($"{uri}Departamentos/{depto.IdDepartamento}");

            HttpResponseMessage respuesta = new HttpResponseMessage();

            try
            {
                //Serializamos el departamento
                datos = JsonConvert.SerializeObject(depto);

                //Creamos el contenido con el departamento
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
