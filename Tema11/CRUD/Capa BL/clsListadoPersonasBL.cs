using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_DAL;
using Capa_Entities;

namespace Capa_BL
{
    public class clsListadoPersonasBL
    {
        /// <summary>
        /// Función que devuelve un listado de personas con la regla de negocio aplicada
        /// Precondiciones: No hay
        /// Postcondiciones: Se devuelve un listado de personas filtrado o no, dependiendo del día de la semana
        /// </summary>
        /// <returns>Listado de personas</returns>
        public async static Task<List<clsPersona>> listadoPersonas()
        {
            List<clsPersona> listado = await clsListadoPersonasDAL.listadoCompletoPersonas();

            List<clsPersona> listadoFinal = new List<clsPersona>();

            DateTime fechaActual = DateTime.Now;

            //Si es viernes o sabado, filtramos por mayores de edad
            if (fechaActual.DayOfWeek == DayOfWeek.Friday || fechaActual.DayOfWeek == DayOfWeek.Saturday)
            {
                listadoFinal = mayorEdad(listado);
            }
            else 
            {
                //Si no, devolvemos el listado completo
                listadoFinal = listado;
            }

            return listadoFinal;

        }

        /// <summary>
        /// Función que filtra un listado de personas por mayores de edad
        /// Precondiciones: Tiene que llegar un listado de personas
        /// Postcondiciones: Se devuelve un listado de personas filtrado por mayores de edad
        /// </summary>
        /// <param name="listado"></param>
        /// <returns> Listado de personas mayores de edad</returns>
        public static List<clsPersona> mayorEdad(List<clsPersona> listado) 
        {
            
            List<clsPersona> listadoFiltrado = new List<clsPersona>();

            DateTime fechaActual = DateTime.Now;

            //Recorremos el listado
            foreach (clsPersona pers in listado)
            {
                //Calculamos la edad
                int edad = pers.FNac.Year - fechaActual.Year;
                
                //Comprobamos si es mayor de edad
                if (edad >= 18)
                {
                    //Añadimos a la lista filtrada
                    listadoFiltrado.Add(pers);
                }
            }

            return listadoFiltrado;

        }

    }
}
