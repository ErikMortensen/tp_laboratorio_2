using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serealiza cualquier tipo de dato que reciba como parametro
        /// </summary>
        /// <param name="archivo">donde guarda los datos</param>
        /// <param name="datos">dato</param>
        /// <returns>true si fue guardado correctamente</returns>
        public bool Guardar(string archivo, T dato)
        {
            try
            {
                using (XmlTextWriter escribir = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(escribir, dato);
                }

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Desserealiza un archivo 
        /// </summary>
        /// <param nme="archivo">archivo a deserealizar</param>
        /// <param name="datos"></param>
        /// <returns>true si deserealizo correctamenter</returns>
        public bool Leer(string archivo, out T dato)
        {
            try
            {
                using (XmlTextReader leer = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    dato = (T)ser.Deserialize(leer);

                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
