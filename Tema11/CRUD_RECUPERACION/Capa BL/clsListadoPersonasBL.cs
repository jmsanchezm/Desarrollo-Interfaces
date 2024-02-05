using Capa_DAL;
using Capa_Entities;
namespace Capa_BL
{
    public class clsListadoPersonasBL
    {
        /// <summary>
        /// Metodo que llama al metodo de la capa DAL (Listado de personas)
        /// aplicando la regla de negocio
        /// </summary>
        /// <returns>Devuelve el listado filtrado o no segun el dia</returns>
        public async static Task<List<clsPersona>> listadoCompletoPersonas()
        {
            List<clsPersona> listado = await clsListadoPersonasDAL.listadoCompletoPersonas();
            List<clsPersona> listadoFinal=new List<clsPersona>();

            DateTime fechaActual = DateTime.Now;

            //Si el dia de la semana es viernes o sabado
            if (fechaActual.DayOfWeek==DayOfWeek.Friday || fechaActual.DayOfWeek == DayOfWeek.Saturday)
            {
                //Recorremos el listado
                foreach (clsPersona pers in listado)
                {
                    //Si esa persona es mayor o igual a 18 años de edad
                    if (fechaActual.Year - pers.FNac.Year >= 18)
                    {
                        //La añadiremos al listado que devolveremos
                        listadoFinal.Add(pers);
                    }
                }
            }
            else
            {
                listadoFinal = listado;
            }

            return listadoFinal; 

        }

    }
}
