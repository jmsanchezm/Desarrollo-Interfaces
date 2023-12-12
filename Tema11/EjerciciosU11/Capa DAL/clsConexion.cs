using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL
{
    public class clsConexion
    {
        /// <summary>
        /// Función que devuelve la cadena de la URI de la API
        /// </summary>
        /// <returns> URI de la API </returns>
        public static string cadenaConexion() 
        {
            return "https://crudnervion.azurewebsites.net/api/";
        }

    }
}
