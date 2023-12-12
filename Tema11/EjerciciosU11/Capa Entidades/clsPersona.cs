namespace Capa_Entidades
{
    public class clsPersona
    {
        #region atributos

        private int id;
        private string nombre;
        private string apellidos;
        private string fechaNacimiento;
        private string direccion;
        private string foto;
        private int idDepartamento;

        #endregion

        #region constructores

        public clsPersona()
        {
            id = 0;
            nombre = "";
            apellidos = "";
            fechaNacimiento = "";
            direccion = "";
            foto = "";
            idDepartamento = 0;

        }

        public clsPersona(int id, string nombre, string apellidos, string fechaNacimiento, string direccion, string foto, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
            this.direccion = direccion;
            this.foto = foto;
            this.idDepartamento = idDepartamento;
        }

        #endregion

        #region propiedades

        public int ID {
            get { return id; }
        }

        public string Nombre 
        {
            get { return nombre; }
            set { nombre = value; } 
        }
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        public string FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }
        public int IDDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }

        #endregion
    }
}