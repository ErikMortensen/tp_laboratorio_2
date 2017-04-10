using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Numero
    {
        private double valor;

#region CONSTRUCTORES
       
        public Numero()
        { 
            this.valor = 0;
        }

        public Numero(string numeroString)
        {
            setNumero(numeroString);
        }

        public Numero(double num)
        {
            valor = num;
        }

#endregion
   
#region METODOS

        /// <summary>
        /// Fc que retorna el numero ingresado
        /// </summary>
        /// <returns>el numero</returns>
        public double getNumero()
        {
            return this.valor;
        }

        /// <summary>
        /// Fc que recibe el string, llama a la fc validarNumero para convertirlo en double
        /// </summary>
        /// <param name="numero">string a ser validado</param>
        private void setNumero(string numero)
        {
            this.valor = validarNumero(numero);   
        }
        
        /// <summary>
        /// Fc que valida si la cadena ingresada contiene solo caracteres numericos,
        /// de ser posible la convierte en un double
        /// </summary>
        /// <param name="numeroString">cadena ingresada</param>
        /// <returns>el numero en caso de ser un string que contenga solo numeros,
        /// o 0 en caso contrario</returns>
        private double validarNumero(string numeroString)
        {
            double numero = 0;

            if (double.TryParse(numeroString, out numero))
                return numero;

            return numero;

        }



#endregion

#region SOBRECARGA

        public static double operator +(Numero numero1, Numero numero2)
        {
            double resultado;
            return resultado = numero1.valor + numero2.valor;

        }

        public static double operator -(Numero numero1, Numero numero2)
        {
            double resultado;
            return resultado = numero1.valor - numero2.valor;

        }

        public static double operator *(Numero numero1, Numero numero2)
        {
            double resultado;
            return resultado = numero1.valor * numero2.valor;

        }

        public static double operator /(Numero numero1, Numero numero2)
        {
            double resultado;
            return resultado = numero1.valor / numero2.valor;

        }

        public static bool operator ==(Numero numero1, double numero)
        {
            return (numero1.valor==numero);

        }

        public static bool operator !=(Numero numero1, double numero)
        {
           return !(numero1.valor == numero);

        }

#endregion
    }
    
}
