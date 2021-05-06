using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP3_proyecto.Formularios;

namespace TP3_proyecto.Formularios
{
    public partial class Poisson : Form
    {
        decimal[] lista;
        decimal[] minMax = new decimal[2];

        public Poisson()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            validaciones();

            Random rnd = new Random();
            double lambda = -(double.Parse(txtLambda.Text));
            int cantidad = int.Parse(txtCantValores.Text);
            lista = new decimal[cantidad];

            dgv.Rows.Clear();
            for (int i = 0; i < cantidad; i++)
            {
                double p = 1;
                double x = -1;
                double a = Math.Pow(2.718, lambda);
                double u;

                do
                {
                    u = rnd.NextDouble();
                    p = p * u;
                    x = x + 1;
                } while (p >= a);
                lista[i] = (decimal)x;
                if (i == 0)
                {
                    minMax[0] = (decimal)x;
                    minMax[1] = (decimal)x;
                }
                else
                {
                    if ((decimal)x < minMax[0]) minMax[0] = (decimal)x;
                    if ((decimal)x > minMax[1]) minMax[1] = (decimal)x;
                }
                dgv.Rows.Add(i + 1, x);
            }
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

            if (!decimal.TryParse(txtLambda.Text, out decimal resultado2) || resultado2 <= 0)
            {
                MessageBox.Show("Ingrese correctamente el valor de λ");
                bandera = false;
                return;
            }


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGrafico_Click(object sender, EventArgs e)
        {
            Grafico grafico = new Grafico(lista);
            grafico.Show();
        }

        private void btnChi_Click(object sender, EventArgs e)
        {
            TestChiCuadrado test = new TestChiCuadrado(lista, 2, minMax, decimal.Parse(txtLambda.Text));
            test.Show();
        }
    }
}
