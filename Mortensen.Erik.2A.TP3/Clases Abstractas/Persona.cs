using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;


namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region Atributos
        protected string _apellido;
        protected int _dni;
        protected ENacionalidad _nacionalidad;
        protected string _nombre;
        #endregion

        #region Propiedades

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = ValidarNombreApellido(value); }
        }

        public int DNI
        {
            get { return this._dni; }
            set { this._dni = ValidarDni(this._nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = ValidarNombreApellido(value); }
        }

        
        public string StringToDNI
        {
            set { this._dni= ValidarDni(this.Nacionalidad,value);}
        }
        #endregion

        #region Constructores

        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this._dni = dni;
        }

        
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre,apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Retorna un string con todos los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad.ToString());

            return sb.ToString();
        }

        #endregion

        #region Validaciones
        /// <summary>
        /// Valida que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y 89999999. 
        /// </summary>
        /// <param name="nacionalidad">nacionalidad</param>
        /// <param name="dato">numero de dni</param>
        /// <returns>si es correcto retornara el numero de DNI, caso contrario, se lanzara la excepcion DniInvalidoException.</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                    else
                        return dato;

                case ENacionalidad.Extranjero:
                    if (dato < 90000000)
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
                    else
                        return dato;

                default:
                    return dato;
            }
        }
        /// <summary>
        /// Prueba pasar un dni de tipo string a entero, de ser posible lo valida 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>de ser todo correcto retorna el dni de tipo int, caso contrario lanza excepcion</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int numeroDni;

            dato = dato.Replace(".", "");

            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException(dato.ToString());

            try
            {
                numeroDni = Int32.Parse(dato);
            }
            catch (Exception e)
            {
                throw new DniInvalidoException(dato.ToString(), e);
            }

            return Persona.ValidarDni(nacionalidad,numeroDni);
        }

        /// <summary>
        /// Valida el string que recibe por parametro para que solo contenga caracteres validos
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        protected string ValidarNombreApellido(string dato)
        {
            Regex regex = new Regex(@"[a-zA-Z]*");

            Match match = regex.Match(dato);

            if (match.Success)
                return match.Value;
            else
                return "";
        }

        #endregion
    }
}
