namespace Biblioteca
{
    
    public class Casa
    {
        #region atributos
        private string nombreCasa= "";
        private string direccion="";
        private long telefono=0;
        private string urlImage="";
        private Boolean visitado=false;
        private Boolean apto= false;
        private string notas = "";

        #endregion

        #region constructores
        
        public Casa() 
        {
            this.direccion = "";
            this.nombreCasa = "";
            this.visitado = false;
            this.urlImage = "";
        }

        public Casa(string nombreCasa, string direccion, string urlImage, bool visitado)
        {
            this.nombreCasa = nombreCasa;
            this.direccion = direccion;
            this.urlImage = urlImage;
            this.visitado = visitado;
        }

        public Casa(string nombreCasa, string direccion, long telefono, string urlImage, bool visitado, bool apto, string notas)
        {
            this.nombreCasa = nombreCasa;
            this.direccion = direccion;
            this.telefono = telefono;
            this.urlImage = urlImage;
            this.visitado = visitado;
            this.apto = apto;
            this.notas = notas;

        }

        #endregion
        #region propiedades
        public String NombreCasa 
        { 
            get { return nombreCasa; }
            
        }

        public String Direccion 
        { 
            get {  return direccion; } 
            
        }

        public String UrlImage
        { 
            get { return urlImage; }  
        }
        public bool Visitado 
        {
            get { return visitado; } 
            set {  visitado = value; }
        }
        public long Telefono 
        {
            get { return telefono; }
            set { telefono = value; }
        }
        public Boolean Apto 
        {
            get { return apto; }
        }

        public string Notas
        {
            get { return notas; }
            set { notas = value; }
        }

        #endregion
    }
}