using Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacasSolares
{
    public static class ListadoCompletoCasa
    {
        /// <summary>
        /// Método que devuelve un listado con citas a las que tiene que visitar el ingeniero 
        /// Se crea un array de objeto de tipo casas y se le añaden los valores
        /// </summary>
        /// <returns></returns>
        public static List<Casa> CasaList()
        {
            List<Casa> listaCasas = new List<Casa>
            {
                new Casa("Gonzalez Martín","San José de la Rinconada", 956142351,"casa_gonzalez_martin.png",false,false,""),
                new Casa("Sanchez Moreno","Las 3000 viviendas",951637510, "casa_sanchez_moreno.png",false,false, ""),
                new Casa("Jimenez Pelo","Cerro del Avestruz",605167930, "casa_jimenez_pelo.png",false,false, ""),
                new Casa("Miguel Gonzalez","Mairena del Aljarafe",722141056, "casa_miguel_gonzalez.png",false, false,""),
                new Casa("Caballero Gil","Tiro de Linea",903465123, "casa_caballero_gil.png",false, false, ""),
                new Casa("Jimenez Arenas","Tiro de Linea",987654321, "casa_jimenez_arenas.png",false, false, ""),
                new Casa("De isla Carrillo de Albornoz","Tomares",689456321, "casa_de_isla.png",false, false, ""),
                new Casa("Rodriguez Ruiz", "Utrera",602336752,"casa_rodriguez_ruiz.png",false, false, "")
            };

            return listaCasas;
        }
    }
}
