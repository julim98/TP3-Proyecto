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
    public partial class Exponencial : Form
    {
        decimal[] lista;

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

        private double completarExponencial(int numero)
        {
            double n = (double)numero;
            double lambda;
            if (cmbParametro.Text == Parametro.Lambda.ToString())
            {
                lambda = n;
            }
            else if (cmbParametro.Text == Parametro.Media.ToString())
            {
                lambda = 1 / n;
            }
            else
            {
                lambda = Math.Pow(1 / Math.Sqrt(n),2);
            }
            return lambda;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (verificarEntradas())
            {
                Random rand = new Random();
                int cantidad = int.Parse(txtCantidad.Text);
                double lambda = completarExponencial(int.Parse(txtParametro.Text));
                lista = new decimal[cantidad];
                grilla.Rows.Clear();

                for (int i = 0; i < cantidad ; i++)
                {
                    string xTxt = (-(1 / lambda) * Math.Log(1 - rand.NextDouble())).ToString();
                    decimal x = decimal.Parse(xTxt);
                    x = decimal.Round(x, 4);
                    lista[i] = x;
                    grilla.Rows.Add(i + 1, x);
                }
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
            TestChiCuadrado test = new TestChiCuadrado(lista);
            test.Show();
        }
    }
}

