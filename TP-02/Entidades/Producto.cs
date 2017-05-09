using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        #region Atributos
        protected EMarca _marca;
        protected string _codigoDeBarras;
        protected ConsoleColor _colorPrimarioEmpaque;
        protected short _cantidadCalorias;
        #endregion

        #region Enumerados
        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        #endregion

        #region Contructores

        public Producto(string codigoDeBarras, EMarca marca, ConsoleColor color)
        {
            this._codigoDeBarras = codigoDeBarras;
            this._marca = marca;
            this._colorPrimarioEmpaque = color;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del Producto
        /// </summary>
        protected abstract short CantidadCalorias { get;}

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>Un string con los datos del producto</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region Sobrecarga

        /// <summary>
        /// Sobrecarga del operador string para que devuelva los datos del producto
        /// </summary>
        /// <param name="p">Un producto</param>
        /// <returns>Un string con los datos del producto</returns>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CODIGO DE BARRAS: " + p._codigoDeBarras);
            sb.AppendLine("MARCA          : " + p._marca.ToString());
            sb.AppendLine("COLOR EMPAQUE  : " + p._colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1">Producto uno</param>
        /// <param name="v2">Producto dos</param>
        /// <returns>retorna 1 si los productos tienen el mismo codigo o 0 en caso contrario</returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1">Producto uno</param>
        /// <param name="v2">Producto dos</param>
        /// <returns>Retorna 1 si los productos tienen distinto codigo o 0 en caso contrario</returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }
        #endregion
    }
}
