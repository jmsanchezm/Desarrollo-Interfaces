using Capa_Entities;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.Text.Json.Serialization;

namespace Capa_DAL
{
    public class clsListadoPersonasDAL
    {
        /// <summary>
        /// Metodo que devuelve un listado completo de personas de una API
        /// Precondiciones: No hay
        /// Postcondiciones: Se devuelve un listado de personas
        /// </summary>
        /// <returns></returns>
        public async static Task<List<clsPersona>> listadoCompletoPersonas() 
        { 
            //Establecemos la coneccion con la API
            string uri = clsConexion.getConexion();

            //Creamos la Uri
            Uri miUri = new Uri($"{uri}Personas");

            List<clsPersona> listado = new List<clsPersona>();

            //Creamos el mensaje de respuesta
            HttpResponseMessage codigo;

            //Creamos el cliente
            HttpClient client = new HttpClient();

            //Creamos la respuesta
            string respuesta;

            try 
            { 
                //Hacemos la peticion
                codigo = await client.GetAsync(miUri);

                //Comprobamos que la peticion se haya realizado correctamente
                if (codigo.IsSuccessStatusCode) 
                { 
                    //Obtenemos la respuesta
                    respuesta = await client.GetStringAsync(miUri);

                    //Cerramos la conexion
                    client.Dispose();

                    //Deserializamos la respuesta
                    listado = JsonConvert.DeserializeObject<List<clsPersona>>(respuesta);
                }
                
            }catch(Exception e)
            {
                throw e; 
            } 
            
            //Devolvemos el listado
            return listado;

        }
    }
}
