using Capa_Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL
{
    public class clsListadoDepartamentosDAL
    {
        /// <summary>
        /// Metodo que devuelve un listado de departamentos que ofrece nuestra API
        /// </summary>
        /// <returns></returns>
        public static async Task<List<clsDepartamento>> listadoCompletoDeptos() 
        {

            string miCadenaBase = clsConexion.getConexion();

            Uri uri = new Uri($"{miCadenaBase}Departamentos");

            List<clsDepartamento> listadoDeptos = new List<clsDepartamento>();

            HttpClient client = new HttpClient();

            HttpResponseMessage response;

            string jsonRespuesta;

            try
            {

                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    jsonRespuesta = await client.GetStringAsync(uri);

                    client.Dispose();

                    listadoDeptos = JsonConvert.DeserializeObject<List<clsDepartamento>>(jsonRespuesta);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listadoDeptos;
        

    }

    }
}
