using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public partial class frmCalculadora : Form
    {
        Numero numero1;
        Numero numero2;
        string operador;

        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            numero1 = new Numero (this.txtNumero1.Text);

        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            numero2 = new Numero(this.txtNumero2.Text);
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            operador = this.cmbOperacion.Text;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "0";
            this.cmbOperacion.Text = "";

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            //Solo ingresa si se han cargado datos
            if (numero1 != null && numero2 != null && operador!="")
            {
                double resultado = Calculadora.operar(numero1, numero2, operador);
                
                this.lblResultado.Text = resultado.ToString();
                
            }
        }
    }
}
