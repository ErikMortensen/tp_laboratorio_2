using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor:Universitario
    {
        #region "Atributos"

        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        #endregion

        #region "Constructores"

        /// <summary>
        /// Inicializa una instancia de la clase profesor
        /// </summary>
        public Profesor()
        { }

        /// <summary>
        /// Inicializa una instancia del atributo estatico _random
        /// </summary>
        static Profesor()
        {
            _random = new Random();
        }

        /// <summary>
        /// Inicializa una instancia de la clase profesor con su atributo _clasesDelDia, generando 2 clases random
        /// y asignandole todos sus atributos recibidos por parametros
        /// </summary>
        /// <param name="id">id del profesor</param>
        /// <param name="nombre">nombre del profesor</param>
        /// <param name="apellido">apellido del profesor</param>
        /// <param name="dni">dni del profesor</param>
        /// <param name="nacionalidad">nacionalidad del profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// mestra las clases que puede dar un profesor
        /// </summary>
        /// <returns>Retorna un string con las clases que puede dar un profesor </returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");

            foreach (Universidad.EClases clase in this._clasesDelDia)
                sb.AppendLine(clase.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Genera dos clases aleatorias y las asigna a la lista
        /// </summary>
        private void _randomClases()
        {
            this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0, 4));
            this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0, 4));
        }

        /// <summary>
        /// Muestra los datos del profesor
        /// </summary>
        /// <returns>un string con los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Hace publicos los datos del profesor
        /// </summary>
        /// <returns>un string con los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region "Sobrecarga"

        /// <summary>
        /// Nos dice si un profesor da una clase determinada
        /// </summary>
        /// <param name="p">un profesor</param>
        /// <param name="clase">una clase</param>
        /// <returns>true si el profedor da dicha clase, false en caso contrario</returns>
        public static bool operator ==(Profesor p, Universidad.EClases clase)
        {
            foreach (Universidad.EClases c in p._clasesDelDia)
            {
                if (c == clase)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Nos dice si un profesor no da una clase determinada
        /// </summary>
        /// <param name="p">un profesor</param>
        /// <param name="clase">una clase</param>
        /// <returns>true si el profesor no da dicha clase, false en caso contrario</returns>
        public static bool operator !=(Profesor p, Universidad.EClases clase)
        {
            return !(p == clase);
        }

        #endregion
    }
}
