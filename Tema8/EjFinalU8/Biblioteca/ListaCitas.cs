using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class ListaCitas
    {
        public List<Casa> CasaList ()
        {
            List<Casa> listaCasas = new List<Casa>
            {
                listaCasas.Add(new Casa("Gonzalez Martín","San José de la Rinconada", "https://casasinhaus.com/wp-content/uploads/2021/10/casa-modular-moderna-piscina.jpg",false),
                listaCasas.Add(new Casa("Sanchez Moreno","Las 3000 viviendas", "https://imgix.cosentino.com/es/wp-content/uploads/2023/07/Lumire-70-Facade-MtWaverley-vic-1.jpg?auto=format%2Ccompress&ixlib=php-3.3.0",false),
                listaCasas.Add(new Casa("Jimenez Pelo","Cerro del Avestruz", "https://www.proyectosdecasas.es/files/images/casas-modernas-proyectos-zx108.jpg",false),
                listaCasas.Add(new Casa("Miguel Gonzalez","Mairena del Aljarafe", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSGQ1OUu-4KBBXwHvKC5SxxjL18c6eayl0El36CR0g2&s",false),
                listaCasas.Add(new Casa("Caballero Gil","Tiro de Linea", "https://www.arqhys.com/wp-content/uploads/2011/07/Planos-y-fachadas-gratis-con-medidas-20.jpg",false),
                listaCasas.Add(new Casa("Jimenez Arenas","Tiro de Linea", "https://casasinhaus.com/wp-content/uploads/2021/10/casa-modular-moderna-piscina.jpg",false),
                listaCasas.Add(new Casa("De isla","Tomares", "https://casasinhaus.com/wp-content/uploads/2021/10/casa-modular-moderna-piscina.jpg",false))};

            return listaCasas;
        }
    }
}
