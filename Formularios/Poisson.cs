using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP3_proyecto.Formularios
{
    public partial class Poisson : Form
    {
        public Poisson()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            double lambda = -(double.Parse(txtLambda.Text));
            int p = 1;
            int x = -1;
            double a = Math.Pow(2.718, lambda);
        }

        private void validaciones()
        {
            bool bandera = true;
            if (txtLambda.Text == "")
            {
                MessageBox.Show("Falta ingresar valor de λ");
                bandera = false;
                return;
            }

            if (txtCantValores.Text == "")
            {
                MessageBox.Show("Falta ingresar valores");
                bandera = false;
                return;
            }

            if (int.Parse(txtCantValores.Text) <= 0)
            {
                MessageBox.Show("Debe ingresar un número entero positivo", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
                return;
            }


        }

        private void txtCantValores_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
