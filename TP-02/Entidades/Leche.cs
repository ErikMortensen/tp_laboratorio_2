using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2017
{
    public class Leche : Producto
    {
        #region Atributos
        private ETipo _tipo;
        #endregion

        #region Enumerados
        public enum ETipo { Entera, Descremada }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que recibe 3 parámetros del producto Leche
        /// y asigna por defecto TIPO = ENTERA
        /// </summary>
        /// <param name="marca">marca del producto</param>
        /// <param name="codigoBarra">Codigo de barras del producto</param>
        /// <param name="color">color del producto</param>
        public Leche(EMarca marca, string codigoBarra, ConsoleColor color)
            : base(codigoBarra, marca, color)
        {
            _tipo = ETipo.Entera;
        }

        /// <summary>
        /// Constructor que recibe los 4 parámetros del producto Leche
        /// </summary>
        /// <param name="marca">marca del producto</param>
        /// <param name="codigoBarra">Codigo de barras del producto</param>
        /// <param name="color">color del producto</param>
        /// <param name="tipo">Enum del tipo de producto</param>
        public Leche(EMarca marca, string codigoBarra, ConsoleColor color, ETipo tipo)
            : base(codigoBarra, marca, color)
        {
            this._tipo = tipo;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get { return 20; }
            
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos del producto
        /// </summary>
        /// <returns>Un string con los datos del producto</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar().ToString());
            sb.AppendLine("CALORIAS : " + this.CantidadCalorias); 
            sb.AppendLine("TIPO : " + this._tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
