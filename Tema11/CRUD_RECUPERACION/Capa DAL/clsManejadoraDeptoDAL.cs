using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Capa_Entities;
using Newtonsoft.Json;

namespace Capa_DAL
{
    public class clsManejadoraDeptoDAL
    {
        /// <summary>
        /// Metodo que inserta un departamento en la base de datos
        /// Precondiciones: Le debe llegar un departamento
        /// </summary>
        /// <param name="depto"></param>
        /// <returns>Devuelve el codigo de estado</returns>
        public async static Task<HttpStatusCode> InsertarDeptoDAL(clsDepartamento depto)
        {
            HttpClient client = new HttpClient();

            string datos;

            HttpContent content;

            string cadena = clsConexion.getConexion();

            Uri uri = new Uri($"{cadena}Departamentos");

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                datos = JsonConvert.SerializeObject(depto);

                content = new StringContent(datos, System.Text.Encoding.UTF8, "application/json");

                response = await client.PostAsync(uri, content);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response.StatusCode;
        }
        /// <summary>
        /// Metodo que edita un departamento de la base de datos
        /// Precondiciones: Le debe llegar un departamento 
        /// </summary>
        /// <param name="depto"></param>
        /// <returns>Devuelve el codigo de estado</returns>
        public async static Task<HttpStatusCode> EditarDeptoDAL(clsDepartamento depto)
        {
            HttpClient client = new HttpClient();

            string datos;

            HttpContent content;

            string cadena = clsConexion.getConexion();

            Uri uri = new Uri($"{cadena}Departamentos/{depto.IdDepartamento}");

            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                datos = JsonConvert.SerializeObject(depto);

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
        /// Metodo que elimina un departamento de la base de datos
        /// Precondiciones: Le debe llegar un id de un departamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve el codigo de estado</returns>
        public async static Task<HttpStatusCode> EliminarDeptoDAL(int id)
        {
            HttpClient client = new HttpClient();

            string datos;

            HttpContent content;

            string cadena = clsConexion.getConexion();

            Uri uri = new Uri($"{cadena}Departamentos/{id}");

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
