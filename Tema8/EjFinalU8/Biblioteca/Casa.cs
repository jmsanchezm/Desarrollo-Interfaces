namespace Biblioteca
{
    // All the code in this file is included in all platforms.
    public class Casa
    {
        #region atributos
        private string nombreCasa= "";
        private string direccion="";
        private long telefono=0;
        private string urlImage="";
        private Boolean visitado=false;

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

        public Casa(string nombreCasa, string direccion, long telefono, string urlImage, bool visitado)
        {
            this.nombreCasa = nombreCasa;
            this.direccion = direccion;
            this.telefono = telefono;
            this.urlImage = urlImage;
            this.visitado = visitado;
        }

        #endregion
        #region propiedades
        public String NombreCasa 
        { 
            get { return nombreCasa; }
            set { nombreCasa = value;}
        }

        public String Direccion 
        { 
            get {  return direccion; } 
            set {  direccion = value;} 
        }

        public String UrlImage
        { 
            get { return urlImage; } 
            set {  urlImage = value;} 
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

        #endregion
    }
}