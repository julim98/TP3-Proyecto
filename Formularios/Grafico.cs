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

        private int[] asignarIntervalos(int total, int cantIntervalos)
        {
            int[] posiciones = new int[listaLocal.Length];
            int intervaloMax = total / cantIntervalos;
            int intervaloMin = 0;
            for (int i = 0; i < cantIntervalos; i++)
            {
                for (int j = 0; j < listaLocal.Length; j++)
                {
                    if (listaLocal[j] < intervaloMax && listaLocal[j] >= intervaloMin)
                    {
                        posiciones[j] = i; 
                    }
                }
            }

            return posiciones;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (verificarSeleccion())
            {
                graficoValores.Series[0].Points.Clear();

                graficoValores.ChartAreas[0].AxisX.Interval = listaLocal.Length / cantidadIntervalos();
                int[] valores = asignarIntervalos(listaLocal.Length, cantidadIntervalos());
                // int[] intervaloValores = asignarIntervalos(listaLocal.Length, cantidadIntervalos());

                for (int i = 0; i < listaLocal.Length; i++)
                {
                    // graficoValores.Series[0].Points.AddXY(intervaloValores[i], listaLocal[i]);
                    graficoValores.Series[0].Points.AddXY(valores[i], 1);
                }

            }

        }

    }
}
