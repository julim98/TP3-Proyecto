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
    public partial class Normal : Form
    {
        decimal[] lista;

        public Normal()
        {
            InitializeComponent();
        }

        private bool verificarEntradas()
        {
            if (!double.TryParse(txtMedia.Text, out double resultado1))
            {
                MessageBox.Show("Ingrese correctamente el parametro Cantidad");
                return false;
            }

            if (!double.TryParse(txtVarianza.Text, out double resultado2) || resultado2 <= 0)
            {
                MessageBox.Show("Ingrese correctamente el parametro Varianza");
                return false;
            }

            if (!int.TryParse(txtCantidad.Text, out int resultado3) || resultado3 <= 0)
            {
                MessageBox.Show("Ingrese correctamente la cantidad de variables aleatorias");
                return false;
            }
            return true;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (verificarEntradas())
            {
                Random random = new Random();
                int cantidad = int.Parse(txtCantidad.Text);
                double media = double.Parse(txtMedia.Text);
                double varianza = (double)decimal.Parse(Math.Sqrt(double.Parse(txtVarianza.Text)).ToString());
                lista = new decimal[cantidad];

                grilla.Rows.Clear();

                double random1 = random.NextDouble();
                double random2 = random.NextDouble();

                for (int i = 0; i < cantidad; i++)
                {
                    if (i % 2 == 0)
                    {
                        string n1s = (Math.Sqrt(-2 * Math.Log(random1)) * Math.Cos(2 * Math.PI * random2) * varianza + media).ToString();
                        decimal n1 = decimal.Round(decimal.Parse(n1s), 4);
                        lista[i] = n1;

                        grilla.Rows.Add(i + 1, n1);
                    }
                    else
                    {
                        string n2s = (Math.Sqrt(-2 * Math.Log(random1)) * Math.Sin(2 * Math.PI * random2) * varianza + media).ToString();
                        decimal n2 = decimal.Round(decimal.Parse(n2s), 4);
                        lista[i] = n2;

                        grilla.Rows.Add(i + 1, n2);

                        random1 = random.NextDouble();
                        random2 = random.NextDouble();
                    }
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
