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
    public partial class Grafico : Form
    {
        decimal[] listaLocal;

        public Grafico(decimal[] lista)
        {
            InitializeComponent();
            listaLocal = lista;
            rellenarLista();
            graficoValores.Series[0].Label = "Valores";
        }

        private void rellenarLista()
        {
            int longitud = listaLocal.Length;
            for (int i = 0; i < longitud; i++)
            {
                grilla.Rows.Add(i + 1, listaLocal[i]);
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

        private bool verificarSeleccion()
        {
            if (rb5.Checked || rb10.Checked || rb15.Checked || rb20.Checked)
            {
                return true;
            }
            else return false;
        }

        private int[] asignarIntervalos(decimal[] minMax, int cantIntervalos)
        {
            int[] posiciones = new int[cantIntervalos];
            decimal intervalo = (minMax[1] - minMax[0]) / (cantIntervalos - 1);
            decimal intervaloMax = minMax[0] + intervalo;
            decimal intervaloMin = minMax[0];
            for (int i = 0; i < cantIntervalos; i++)
            {
                for (int j = 0; j < listaLocal.Length; j++)
                {
                    if (listaLocal[j] < intervaloMax && listaLocal[j] >= intervaloMin)
                    {
                        posiciones[i] += 1; 
                    }
                }
                intervaloMin = intervaloMax;
                intervaloMax = intervaloMax + intervalo; 
            }

            return posiciones;
        }

        private decimal[] buscarMinMax()
        {
            decimal min = listaLocal[0];
            decimal max = listaLocal[0];
            decimal[] resultados = new decimal[2];

            for (int i = 0; i < listaLocal.Length; i++)
            {
                if (listaLocal[i] > max)
                {
                    max = listaLocal[i];
                }
                if (listaLocal[i] < min)
                {
                    min = listaLocal[i];
                }
            }

            resultados[0] = min;
            resultados[1] = max;
            return resultados;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (verificarSeleccion())
            {
                graficoValores.Series.Clear();
                graficoValores.Series.Add("Valores");
                decimal[] minMax = buscarMinMax();
                int cantIntervalos = cantidadIntervalos();
                decimal intervalo = (minMax[1] - minMax[0]) / (cantIntervalos - 1);
                int[] valores = asignarIntervalos(minMax, cantIntervalos);

                for (int i = 0; i < cantIntervalos; i++)
                {
                    decimal min = decimal.Round(minMax[0] + (i * intervalo), 4);
                    decimal max = decimal.Round(minMax[0] + ((i + 1) * intervalo), 4);
                    string nombreIntervalo = (i + 1).ToString() + ": " + (min).ToString() + "-" + (max).ToString();
                    graficoValores.Series.Add(nombreIntervalo);
                    graficoValores.Series[0].Points.AddXY((double) (i+1), (double)valores[i]);
                }

            }

        }

    }
}
