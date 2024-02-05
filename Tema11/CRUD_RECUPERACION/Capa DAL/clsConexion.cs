using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_DAL
{
    public class clsConexion 
    { 
        /// <summary>
        /// Metodo que devuelve un string con la URI de la api
        /// </summary>
        /// <returns></returns>
        public static string getConexion() 
        {
            return "https://crudjuanmasanchez.azurewebsites.net/api/";
        }

    }
}
