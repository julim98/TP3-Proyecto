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
    public partial class Exponencial : Form
    {
        public Exponencial()
        {
            InitializeComponent();
        }

        enum Parametro
        {
            Lambda,
            Media,
            Varianza
        }

        private void Exponencial_Load(object sender, EventArgs e)
        {
            cmbParametro.Items.Add(Parametro.Lambda.ToString());
            cmbParametro.Items.Add(Parametro.Media.ToString());
            cmbParametro.Items.Add(Parametro.Varianza.ToString());
        }

        private bool verificarEntradas()
        {
            if (!int.TryParse(txtParametro.Text, out int resultado1) || resultado1 <= 0)
            {
                MessageBox.Show("Ingrese correctamente el parametro");
                return false;
            }

            if (!int.TryParse(txtCantidad.Text, out int resultado2) || resultado2 <= 0)
            {
                MessageBox.Show("Ingrese correctamente la cantidad de variables aleatorias");
                return false;
            }
            return true;
        }

        private decimal completar(int numero)
        {
            double lambda;
            if (cmbParametro.Text == Parametro.Lambda.ToString())
            {
                lambda = numero;
            }
            else if (cmbParametro.Text == Parametro.Media.ToString())
            {
                lambda = 1 / numero;
            }
            else
            {
                lambda = 1 / Math.Sqrt(numero);
            }
            return decimal.Parse(lambda.ToString());
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (verificarEntradas())
            {
                var rand = new Random();
                int cantidad = int.Parse(txtCantidad.Text);
                decimal lambda = completar(int.Parse(txtParametro.Text));
                grilla.Rows.Clear();
                grilla.Rows.Add(cantidad);

                for (int i = 0; i < cantidad ; i++)
                {
                    decimal x = decimal.Round(- (1 / lambda) * (1 - rand.Next(0, 1)), 4);
                    grilla.Rows[i].Cells[0].Value = i++;
                    grilla.Rows[i].Cells[0].Value = x;
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

