using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    [XmlInclude(typeof(Persona))]
    [XmlInclude(typeof(Universidad))]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Profesor))]
    [XmlInclude(typeof(Jornada))]
    [Serializable]
    
    public class Universidad
    {
        #region Enum
        /// <summary>
        /// Enumerado con las distintas clases que se dictan
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Atributos

        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornada;

        #endregion

        #region "Propiedades"

        /// <summary>
        /// Propiedad que asigna y retorna la lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        /// <summary>
        /// Propiedad que asigna y retorna la lista de la jornada
        /// </summary>
        public List<Jornada> Jornada
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        /// <summary>
        /// Le asigna una posicion a la jornada
        /// </summary>
        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }

        /// <summary>
        /// Propiedad que asigna y retorna la lista de profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        #endregion

        #region "Constructores"

        /// <summary>
        /// Inicializa una instancia de Universidad, inicializando las listas de alumno, profesor y jornada
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }

        #endregion

        #region "Sobrecargas"

        /// <summary>
        /// Una universidad sera igual a un alumno, si dicho alumno esta inscripto en ella
        /// </summary>
        /// <param name="g">una universidad</param>
        /// <param name="a">un alumno</param>
        /// <returns>retorna true si el alumno esta inscripto en la universidad, false en caso contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alu in g.alumnos)
            {
                if (alu.DNI == a.DNI)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Una universidad sera distinta a un alumno, si dicho alumno no esta inscripto en ella
        /// </summary>
        /// <param name="g">una universidad</param>
        /// <param name="a">un alumno</param>
        /// <returns>true si el alumno no esta inscripto en la universidad, false en caso contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Retorna el primer profesor de la universidad que puede dar determinada clase
        /// </summary>
        /// <param name="g">una universidad</param>
        /// <param name="clase">una clase</param>
        /// <returns>el nombre del profesor</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor i in g.profesores)
            {
                if (i == clase)
                    return i;
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Retorna el primer profesor de la universidad que no puede dar determinada clase
        /// </summary>
        /// <param name="g">una universidad</param>
        /// <param name="clase">una clase</param>
        /// <returns>el nombre del profesor</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor i in g.profesores)
            {
                if (i != clase)
                    return i;
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Una universidad sera igual a un profesor si el mismo esta dando clases en ella
        /// </summary>
        /// <param name="g">una universidad</param>
        /// <param name="i">un profesor</param>
        /// <returns>true si el profesor esta dando clases en la universidad, false en caso contrario</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor prof in g.profesores)
            {
                if (prof.Equals(i))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Una universidad sera distinta de un profesor si el mismo no esta dando clases en ella
        /// </summary>
        /// <param name="g">una universidad</param>
        /// <param name="i">un profesor</param>
        /// <returns>true si el profesor no esta dando clases en la universidad, false en caso contrario</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Agrega una clase a la universidad, generando una nueva jornada
        /// indicando un profesor que pueda darla y la lista de alumnos que la toman
        /// </summary>
        /// <param name="g">una universidad</param>
        /// <param name="clase">una clase</param>
        /// <returns>la universidad</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g == clase);

            foreach (Alumno alu in g.alumnos)
            {
                if (alu == clase)
                    jornada += alu;
            }
            g.jornada.Add(jornada);

            return g;
        }

        /// <summary>
        /// Agrega un alumno a la universidad, validando previamente que no este ya cargado
        /// </summary>
        /// <param name="g">una universidad</param>
        /// <param name="a">un alumno</param>
        /// <returns>la universidad</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g == a)
                throw new AlumnoRepetidoException();

            g.alumnos.Add(a);

            return g;
        }

        /// <summary>
        /// Agrega un profesor a la universidad, validando previamente que no este cargado
        /// </summary>
        /// <param name="g">una universidad</param>
        /// <param name="i">un profesor</param>
        /// <returns>la universidad</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g == i)
                throw new Exception("Ya existe el instructor.");
            else
                g.profesores.Add(i);

            return g;

        }

        #endregion

        #region "Metodos"

        /// <summary>
        /// Muestra los datos de la jornada de la universidad
        /// </summary>
        /// <param name="gim">una universidad</param>
        /// <returns>un string con todos los datos</returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");

            foreach (Jornada j in gim.jornada)
            {
                sb.AppendLine(j.ToString());
                // sb.Append('<').Append('-',48).Append('>');
                sb.AppendLine("");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Hace publicos los datos de la instancia
        /// </summary>
        /// <returns>un string con todos los datos</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        
        /// <summary>
        /// Guarda los datos de la universidad en un archivo Xml, con el nombre Universidad.xml
        /// </summary>
        /// <param name="gim">una universidad</param>
        /// <returns></returns>
        public static bool Guardar(Universidad gim)
        {
            try
            {
                Archivos.Xml<Universidad> xml = new Archivos.Xml<Universidad>();
                return xml.Guardar("Universidad.xml", gim);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee un archivo Xml
        /// </summary>
        /// <param name="gim">una universidad</param>
        /// <returns>retorna la universidad si fue exitosa la lectura</returns>
        public static Universidad Leer(Universidad gim)
        {
            try
            {
                Archivos.Xml<Universidad> xml = new Archivos.Xml<Universidad>();
                xml.Leer("Universidad.xml", out gim);
                return gim;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
       
        #endregion
    }
}
