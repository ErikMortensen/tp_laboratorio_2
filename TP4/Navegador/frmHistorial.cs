using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
            List<string> listaNombres = new List<string>();
            archivos.leer(out listaNombres);
            lstHistorial.DataSource = listaNombres;
        }
    }
}
