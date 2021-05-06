﻿using System;
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
    public partial class Uniforme : Form
    {
        decimal[] lista;
        decimal[] minMax = new decimal[2];

        public Uniforme()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (verificarEntradas())
            {
                Random rand = new Random();
                int cantidad = int.Parse(txtCantidad.Text);
                lista = new decimal[cantidad];

                grilla.Rows.Clear();
                for (int i = 0; i < cantidad; i++)
                {
                    int limiteA = int.Parse(txtLimiteA.Text);
                    int limiteB = int.Parse(txtLimiteB.Text);
                    decimal x = (decimal) (limiteA + rand.NextDouble() * (limiteB - limiteA));
                    x = decimal.Round(x, 4);
                    lista[i] = x;
                    grilla.Rows.Add(i + 1, x);
                }
            }
        }

        private bool verificarEntradas()
        {
            if (!decimal.TryParse(txtLimiteA.Text, out decimal resultado1))
            {
                MessageBox.Show("Ingrese correctamente el Limite A");
                return false;
            }

            if (!decimal.TryParse(txtLimiteB.Text, out decimal resultado2))
            {
                MessageBox.Show("Ingrese correctamente el Limite B");
                return false;
            }

            if (!int.TryParse(txtCantidad.Text, out int resultado3) || resultado3 <= 0)
            {
                MessageBox.Show("Ingrese correctamente la cantidad de variables aleatorias");
                return false;
            }

            int A = int.Parse(txtLimiteA.Text);
            int B = int.Parse(txtLimiteB.Text);

            if (A >= B)
            {
                MessageBox.Show("El valor de A tiene que ser menor y distinto al valor de B");
                return false;
            }

            if (A == 0 && B == 1)
            {
                MessageBox.Show("Los valores A y B no pueden ser 0 y 1 respectivamente");
                return false;
            }

            minMax[0] = A;
            minMax[1] = B;
            return true;
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
            TestChiCuadrado test = new TestChiCuadrado(lista, 1, minMax, 0);
            test.Show();
        }
    }
}
