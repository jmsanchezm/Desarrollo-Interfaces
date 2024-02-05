using Capa_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_UI.Models
{
    public class clsPersonaConDepto: clsVMBase
    {
        private string nombreDepto;
        private clsPersona persona;
        private List<clsDepartamento> departamentos;

        public clsPersonaConDepto()
        {
            departamentos = new List<clsDepartamento>();
            persona = new clsPersona();
        }

        public clsPersonaConDepto(clsPersona pers) 
        { 
            persona.Id = pers.Id;
            persona.Nombre= pers.Nombre;   
            persona.Apellido= pers.Apellido;
            persona.FNac = pers.FNac;  
            persona.Direccion = pers.Direccion;   
            persona.Tlf = pers.Tlf;    
            persona.Foto = pers.Foto;
            persona.IdDepartamento = pers.IdDepartamento;
            nombreDepto = departamentos.Find(d => d.IdDepartamento == pers.IdDepartamento).Nombre;

        }

        public string NombreDepto
        {
            get { return nombreDepto; }
            set 
            { 
                nombreDepto = value; 
                NotifyPropertyChanged("NombreDepto");   
            }
        }

        public clsPersona Persona
        {
            get { return persona; }
            set
            {
                persona = value;
                NotifyPropertyChanged("Persona");
            }
        }
    }
}
