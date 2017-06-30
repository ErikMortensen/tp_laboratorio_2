using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region "Atributos"

        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #endregion

        #region "Constructores"

        /// <summary>
        /// Inicializa una instancia jornada, inicializando el atributo _alumnos con la lista de alumnos que participan
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Inicializa una instancia Jornada, asignandole una clase y un instructor
        /// </summary>
        /// <param name="clase">nombre de la clase de la jornada</param>
        /// <param name="instructor">nombre del profesor que da dicha jornada</param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion

        #region "Sobrecarga"

        /// <summary>
        /// Una jornada sera igual a un alumno si este participa de la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">un alumno</param>
        /// <returns>retorna true si el alumno participa en la clase de dicha jornada, false en caso contrario</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return (j._alumnos.Contains(a));
        }

        /// <summary>
        /// Una jornada sera distinta a un alumno si este no participa de la clase
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">un alumno</param>
        /// <returns>true si el alumno no participa en la clase de la jornada, false en caso contrario</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la lista de alumnos de la clase de la jornada, si es que este ya no esta en ella
        /// </summary>
        /// <param name="j">jornada</param>
        /// <param name="a">alumno</param>
        /// <returns>la jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j._alumnos.Add(a);
                return j;
            }
            else
                throw new AlumnoRepetidoException();
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de lectura y escritura que retorna y asigna la instancia de la lista _alumnos
        /// </summary>
        List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura que retorna y asigna el atributo _clase
        /// </summary>
        Universidad.EClases Clases
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura que retorna y asigna el atributo _instructor
        /// </summary>
        Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }

        #endregion

        #region "Metodos"
        
        /// <summary>
        /// Guarda en un archivo de texto los datos de la jornada
        /// </summary>
        /// <param name="jornada">jornada que se desea guardar</param>
        /// <returns>true si pudo guardar el archivo</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return (texto.Guardar("Jornada.txt", jornada.ToString()));
        }

        /// <summary>
        /// Lee el archivo de texto de la jornada
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>true si se pudieron leer los datos</returns>
        public static bool Leer(out string dato)
        {
            Texto texto = new Texto();
            return (texto.Leer("Jornada.txt", out dato));
        }
        
        /// <summary>
        /// Retorna un string con los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLASE DE " + this._clase);
            sb.AppendLine(" POR " + this._instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno a in this._alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            sb.Append('<').Append('-', 48).Append('>');

            return sb.ToString();
        }

        #endregion
    }
}
