using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivos;

        public frmWebBrowser()
        {
            InitializeComponent();
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }
        delegate void FinDescargaCallback(string html);
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }

        #region "Hecho por mi"

        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorial a = new frmHistorial();
            a.Show();
        }

        private void btnIr_Click(object sender, EventArgs e)
        {  
            #region Guardado de link en historial 
            StringBuilder strBldr = new StringBuilder("");
          
            if (this.txtUrl.Text.Length > 0)
            {
                if (!(this.txtUrl.Text.StartsWith("http://")))
                {
                    strBldr.Append("http://");
                    strBldr.Append(this.txtUrl.Text);
                    this.txtUrl.Text = strBldr.ToString();
                }

                this.archivos.guardar(this.txtUrl.Text);
            }
            #endregion

            #region Carga de datos de la URL en la textbox
            Descargador desc = new Descargador(new Uri(this.txtUrl.Text));

            desc.cambioProgreso += new Hilo.cambioEnElProgreso(this.ProgresoDescarga);
            desc.htmlCompletado += new Hilo.progresoCompletado(this.FinDescarga);

            new Thread(desc.IniciarDescarga).Start();
            #endregion
        }

        #endregion 
    }
}
