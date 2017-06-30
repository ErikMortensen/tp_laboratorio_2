using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda el string recibido en un archivo.
        /// </summary>
        /// <param name="archivo">nombre donde se garda el archivo</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns> Truesifue guardado correctamente</returns>
        public bool Guardar(string archivo, string dato)
        {
            try
            {
                using (StreamWriter escribir = new StreamWriter(archivo, true))
                {
                    escribir.WriteLine(dato);
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee un archivo que recibe por parametro
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si fue leido correctamente</returns>
        public bool Leer(string archivo, out string dato)
        {
            try
            {
                using (StreamReader leer = new StreamReader(archivo))
                {
                    dato = leer.ReadToEnd();
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
