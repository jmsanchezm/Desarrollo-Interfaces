namespace Capa_DAL
{
    public class clsConexion
    {
        /// <summary>
        /// Metodo que devuelve la cadena de conexion
        /// Precondiciones: no hay
        /// Postcondiciones: devuelve un string con la cadena de conexion
        /// </summary>
        /// <returns>Cadena conexion</returns>
        public static string getConexion()
        {
            return "https://crudjuanmasanchez.azurewebsites.net/api/";
        }
    }
}