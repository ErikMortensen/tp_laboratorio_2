using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public delegate void cambioEnElProgreso(int progreso);
    public delegate void progresoCompletado(string resultado);    

    public class Descargador
    {
        public event cambioEnElProgreso cambioProgreso;
        public event progresoCompletado htmlCompletado;

        private string html;
        private Uri direccion;

        public Descargador(Uri direccion)
        {
            this.direccion = direccion;
            this.html = "";
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion, html);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.cambioProgreso(e.ProgressPercentage);
        }

        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.html = e.Result;
            }
            catch (Exception)
            {
                Console.WriteLine("Ocurrio un error al leer la URL");
            }            

            this.htmlCompletado(this.html);
        }
    }
}
