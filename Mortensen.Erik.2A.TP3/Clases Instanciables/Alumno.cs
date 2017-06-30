using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno:Universitario
    {
        #region Enum
        public enum EEstadoCuenta
        {
            Becado,
            Deudor,
            AlDia
        }
        #endregion

        #region Atributos
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoDeCuenta;

        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa una instancia de la clase Alumno
        /// </summary>
        public Alumno()
        { }

        /// <summary>
        /// Inicializa una instancia de la clase Alumno, le pasa los atributos a la clase persona para inicializar,
        /// y asigna la clase que toma el alumno
        /// </summary>
        /// <param name="id">legajo del alumno</param>
        /// <param name="nombre">nombre del alumno</param>
        /// <param name="apellido">apellido del alumno</param>
        /// <param name="dni">dni del alumno</param>
        /// <param name="nacionalidad">nacionalidad del alumno</param>
        /// <param name="claseQueToma">clase quetoma del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Inicializa una instancia de la clase Alumno, le pasa los atributos como parametros al constructor anterior,
        /// y asigna el estado de cuenta del alumno
        /// </summary>
        /// <param name="id">legajo del alumno</param>
        /// <param name="nombre">nombre del alumno</param>
        /// <param name="apellido">apellido del alumno</param>
        /// <param name="dni">dni del alumno</param>
        /// <param name="nacionalidad">nacionalidad del alumno</param>
        /// <param name="claseQueToma">clase quetoma del alumno</param>
        /// <param name="estadoCuenta">estado de cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoDeCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorna un string con los datos del alumno
        /// </summary>
        /// <returns>un string con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            if(this._estadoDeCuenta==EEstadoCuenta.AlDia)
                sb.AppendLine("ESTADO DE CUENTA: Cuota al día" );
            else
                sb.AppendLine("ESTADO DE CUENTA: " + this._estadoDeCuenta);
            sb.AppendLine("TOMA CLASES DE " + this._claseQueToma);
            
            return sb.ToString();
        }

        /// <summary>
        /// retorna un string con las clases que toma el alumno
        /// </summary>
        /// <returns>un string con los datos</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this._claseQueToma.ToString();
        }

        /// <summary>
        /// Hace publicos los datos del alumno
        /// </summary>
        /// <returns>sun string con los datos</returns>
        public string ToString()
        {
            return this.MostrarDatos();
        }
        
        #endregion

        #region Sobrecarga
        /// <summary>
        /// Un alumno sera igual a una clase, si toma dicha clase y su estado de cuenta no es deudor
        /// </summary>
        /// <param name="a">un alumno</param>
        /// <param name="clase">una clase que pertenezca al enumerado Universidad.EClases</param>
        /// <returns>retorna true si el alumno toma esa clase y su estado de cuenta no es deudor, false en caso contrario</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a._claseQueToma == clase && a._estadoDeCuenta != EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Un alumno sera distinto a una clase, si no toma dicha clase
        /// </summary>
        /// <param name="a">un alumno</param>
        /// <param name="clase">una clase que pertenezca al enumerado Universidad.EClases</param>
        /// <returns>retorna true si el alumno no toma dicha clase, false en caso contrario</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a._claseQueToma != clase);
        }

        #endregion
    }

    
}
