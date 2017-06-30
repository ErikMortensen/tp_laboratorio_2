using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario:Persona
    {
        #region Atributos
        protected int _legajo;
        #endregion

        #region Constructores

        public Universitario()
        {}

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        #endregion

        #region Metodos

        
        protected abstract string ParticiparEnClase();

        /// <summary>
        ///  Retorna un string con todos los datos de un universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.Append("LEGAJO NUMERO: " + this._legajo);

            return sb.ToString();
        }
        #endregion

        #region Sobrecarga
        
        /// <summary>
        /// dos universitarios seran iguales si:
        /// los 2 son universitarios y
        /// poseen el mismo DNI o legajo
        /// </summary>
        /// <param name="pg1">universitario 1</param>
        /// <param name="pg2">universitario 2</param>
        /// <returns>true si son iguales y false en caso contrario</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        { 
            if (pg1.Equals(pg2) && (pg1.DNI == pg2.DNI || pg1._legajo == pg2._legajo))
                return true;
           
            return false;
        }

        /// <summary>
        /// dos universitarios son distintos si no son iguales
        /// </summary>
        /// <param name="pg1">universitario 1</param>
        /// <param name="pg2">universitario 2</param>
        /// <returns>true si son distintos o false si son iguales</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}
