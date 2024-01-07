
using Capa_Entities;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Capa_DAL
{
    public class clsListadoDepartamentosDAL
    {
        /// <summary>
        /// Metodo que devuelve un listado completo de departamentos de una API
        /// Precondiciones: No hay
        /// Postcondiciones: Se devuelve un listado de departamentos
        /// </summary>
        /// <returns>Listado de departamentos</returns>
        public async static Task<List<clsDepartamento>> listadoCompletoDepartamento() 
        { 
            //Establecemos la coneccion con la API
            string uri = clsConexion.getConexion();

            //Creamos la Uri
            Uri miUri = new Uri($"{uri}Departamentos");

            List<clsDepartamento> listado = new List<clsDepartamento>();
            
            //Creamos el cliente
            HttpClient client = new HttpClient();

            //Creamos el mensaje de respuesta
            HttpResponseMessage codigo;

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
                    listado = JsonConvert.DeserializeObject<List<clsDepartamento>>(respuesta);
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
