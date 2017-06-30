using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivo;

        public Texto(string archivo)
        {
            this._archivo = archivo;
        }

        /// <summary>
        /// Guarda en un archivo de texto los datos pasados por parametro
        /// </summary>
        /// <param name="datos">Datos</param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            using (StreamWriter file = new StreamWriter(this._archivo, true))
            {
                file.WriteLine(datos);
            }
            return true;
        }

        /// <summary>
        /// Lee un archivo de texto y agrega cada linea a una lista
        /// </summary>
        /// <param name="datos">Lista en la que se guardan los datos</param>
        /// <returns></returns>
        public bool leer(out List<string> linea)
        {
            linea = new List<string>();

            using (StreamReader file = new StreamReader(this._archivo))
            {
                while (!file.EndOfStream)
                {
                    linea.Add(file.ReadLine());
                }
            }

            return true;
        }
    }
}
