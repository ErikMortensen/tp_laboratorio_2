using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Calculadora
    {


    //Metodo

        /// <summary>
        /// La funcion realiza la operacion entre 2 numeros
        /// </summary>
        /// <param name="numero1">numero ingresado en el textbox txtNumero1</param>
        /// <param name="numero2">numero ingresado en el textbox txtNumero2</param>
        /// <param name="operador">string que contiene el operador seleccionado del cmbOperacion</param>
        /// <returns>Retorna el resultado de la operacion, sino puede operar retornara 0</returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;

            switch (validarOperador(operador))
            {
                case "+":
                    return numero1 + numero2;
                    
                case "-":
                    return numero1 - numero2;
                    
                  case "*":
                    return numero1 * numero2;
                    
                case "/":
                    if (numero2 == 0) // En caso de que el divisor sea 0 retorna 0.
                        return 0;

                    return numero1 / numero2;
                                       
            }

            return resultado;
        }

        /// <summary>
        /// Valida que el operador sea un caracter válido
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Si es valido retorna el operador, caso contrario retorna "+"</returns>
        public static string validarOperador(string operador)
        {

            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
                return operador;

            return "+";
        }
    }
}
