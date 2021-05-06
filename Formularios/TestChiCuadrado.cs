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
    public partial class TestChiCuadrado : Form
    {
        bool band_Ok = false;
        decimal[] listaLocal;
        int distribucionLocal;
        // 0 = normal , 1 = uniforme, 2 = poisson , 3 = exponencial -
        decimal[] minMaxLocal = new decimal[2];
        decimal parametro;

        public TestChiCuadrado(decimal[] lista, int distribucion, decimal[] minMax, decimal parametroI)
        {
            InitializeComponent();
            distribucionLocal = distribucion;
            minMaxLocal = minMax;
            listaLocal = new decimal[lista.Length];
            parametro = parametroI;
            for (int i = 0; i < lista.Length; i++)
            {
                listaLocal[i] = lista[i];
            }
        }

        private void validarIngreso()
        {
            if (!rb5.Checked && !rb10.Checked && !rb15.Checked && !rb20.Checked)
            {
                MessageBox.Show("Debe Seleccionar un Intervalo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (band_Ok == false)
            {
                band_Ok = true;
            }

        }

        private int cantidadIntervalos()
        {
            int num;

            if (rb5.Checked)
            {
                num = 5;
            }
            else if (rb10.Checked)
            {
                num = 10;
            }
            else if (rb15.Checked)
            {
                num = 15;
            }
            else
            {
                num = 20;
            }

            return num;
        }

        public decimal[] generarIntervalos(out decimal[] marcasDeClase, out decimal[] desde, out decimal[] hasta, out decimal tamañoIntervalo)
        {
            int num = cantidadIntervalos();
            marcasDeClase = new decimal[num];
            desde = new decimal[num];
            hasta = new decimal[num];
            decimal[] intervalos = new decimal[num];
            if (distribucionLocal == 2)
            {
                tamañoIntervalo = Math.Round(minMaxLocal[1] - minMaxLocal[0]) / ((decimal)num);
            }
            else
            {
                tamañoIntervalo = (minMaxLocal[1] - minMaxLocal[0]) / ((decimal)num);

            }
            decimal intervaloMax = minMaxLocal[0] + tamañoIntervalo;
            decimal intervaloMin = minMaxLocal[0];

            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < listaLocal.Length; j++)
                {
                    if ((i == 0 && listaLocal[j] < intervaloMax )||( i == 0 && listaLocal[j] == minMaxLocal[1]))
                    {
                        intervalos[i] += 1;
                    }
                    else if (listaLocal[j] < intervaloMax && listaLocal[j] >= intervaloMin)
                    {
                        intervalos[i] += 1;
                    }
                }
                marcasDeClase[i] = (intervaloMax + intervaloMin) / 2;
                desde[i] = intervaloMin;
                hasta[i] = intervaloMax;

                intervaloMin = intervaloMax;
                intervaloMax = intervaloMax + tamañoIntervalo;
            }
            
            return intervalos;
        }


        private decimal[] calcularFe(int numeroIntervalos, decimal[] x, decimal anchoIntervalo)
        {
            decimal[] fe = new decimal[numeroIntervalos];
            int n = listaLocal.Length;
            if (distribucionLocal == 0)
            {
                decimal suma = 0;
                for (int j = 0; j < n; j++)
                {
                    suma += listaLocal[j];
                }
                decimal media = suma/n;

                for (int i = 0; i < numeroIntervalos; i++)
                {
                    double e = ((-0.5) * Math.Pow((double)((x[i] - media) / parametro),2));
                    fe[i] = (decimal)Math.Exp(e) / (parametro * (decimal)Math.Sqrt(2 * Math.PI)) * anchoIntervalo * n;
                }
            }
            else if (distribucionLocal == 1)
            {
                decimal valor = (1 / (minMaxLocal[1] - minMaxLocal[0])) * anchoIntervalo * n;
                decimal feT = Math.Round(valor, 4);
                for (int i = 0; i < numeroIntervalos; i++)
                {
                    fe[i] = feT;
                }
            }
            else if (distribucionLocal == 2)
            {
                for (int i = 0; i < numeroIntervalos; i++)
                {
                    double xr = Math.Round((double)x[i]);
                    double factorial = 1;
                    for (int j = 1; j < xr+1; j++)
                    {
                        factorial = factorial * j;
                    }
                    fe[i] = (decimal)Math.Round((Math.Exp((double)(-parametro)) * Math.Pow((double)parametro, xr) / factorial) * n);
                }
            }
            else
            {
                for (int i = 0; i < numeroIntervalos; i++)
                {
                    decimal valor = parametro * (decimal)Math.Exp(-(double)(parametro * x[i])) * anchoIntervalo * n;
                    fe[i] = Math.Round(valor, 4);
                }
            }
            return fe;
        }

        private void ajustarIntervalos(decimal[] fe, decimal[] fo, decimal[] desde, decimal[] hasta, out decimal[] feResultado, out decimal[] foResultado, out decimal[] desdeResultado, out decimal[] hastaResultado)
        {
            List<decimal> feIntermedio = new List<decimal>();
            List<decimal> foIntermedio = new List<decimal>();
            List<decimal> desdeIntermedio = new List<decimal>();
            List<decimal> hastaIntermedio = new List<decimal>();

            feIntermedio.AddRange(fe);
            foIntermedio.AddRange(fo);
            desdeIntermedio.AddRange(desde);
            hastaIntermedio.AddRange(hasta);

            int contador = 0;
            while (contador <= feIntermedio.Count / 2)
            {
                while (feIntermedio[contador] < 5 && feIntermedio.Count > 1)
                {
                    feIntermedio[contador] += feIntermedio[contador + 1];
                    foIntermedio[contador] += foIntermedio[contador + 1];
                    hastaIntermedio[contador] = hastaIntermedio[contador + 1];

                    feIntermedio.RemoveAt(contador + 1);
                    foIntermedio.RemoveAt(contador + 1);
                    hastaIntermedio.RemoveAt(contador + 1);
                    desdeIntermedio.RemoveAt(contador + 1);
                }

                while (feIntermedio[feIntermedio.Count - (contador + 1)] < 5 && feIntermedio.Count > 1)
                {
                    feIntermedio[feIntermedio.Count - (contador + 1)] += feIntermedio[feIntermedio.Count - (contador + 2)];
                    foIntermedio[foIntermedio.Count - (contador + 1)] += foIntermedio[foIntermedio.Count - (contador + 2)];
                    desdeIntermedio[feIntermedio.Count - (contador + 1)] = desdeIntermedio[feIntermedio.Count - (contador + 2)];

                    feIntermedio.RemoveAt(feIntermedio.Count - (contador + 2));
                    foIntermedio.RemoveAt(foIntermedio.Count - (contador + 2));
                    desdeIntermedio.RemoveAt(desdeIntermedio.Count - (contador + 2));
                    hastaIntermedio.RemoveAt(hastaIntermedio.Count - (contador + 2));
                }

                contador += 1;
            }

            feResultado = feIntermedio.ToArray();
            foResultado = foIntermedio.ToArray();
            desdeResultado = desdeIntermedio.ToArray();
            hastaResultado = hastaIntermedio.ToArray();
        }


        private void CargarFrecuencias(decimal[] fo, decimal[] fe, decimal[] desde, decimal[] hasta)
        {

            decimal sumC = 0;
            for (int i = 0; i < fo.Length; i++)
            {
                decimal c = (decimal)Math.Pow((double)(fo[i] - fe[i]) , 2) / fe[i];
                sumC += c;
                dgvFrecuencias.Rows.Add(desde[i], hasta[i], fo[i], fe[i], c, sumC);
            }
        }        

        private void btnGenerar_Click(object sender, EventArgs e)
        {

            validarIngreso();
            dgvFrecuencias.Rows.Clear();
            dgvSerie.Rows.Clear();
            if (band_Ok)
            {
                decimal[] intervalos;
                decimal[] marcasDeClase;

                intervalos = generarIntervalos(out decimal[] mc , out decimal[] desde, out decimal[] hasta, out decimal anchoIntervalo);
                marcasDeClase = mc;
                decimal[] fe = calcularFe(intervalos.Length, marcasDeClase, anchoIntervalo);
                ajustarIntervalos(fe,intervalos, desde, hasta, out decimal[] feRe, out decimal[] foRe, out decimal[] desdeRe, out decimal[] hastaRe);

                CargarFrecuencias(foRe, feRe, desdeRe, hastaRe);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
