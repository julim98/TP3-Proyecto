using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_SIM
{
    public partial class TestChiCuadrado : Form
    {
        bool band_Ok = false;
        public TestChiCuadrado()
        {
            InitializeComponent();
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
            else { 
                num = 20;
            }
            
            return num;
        }
        public double[] generarIntervalos(double [] numeros)
        {
            int num = cantidadIntervalos();
            
            double[] intervalos = new double[num];
            float tam =  1 / (float) num;

            for (int i = 0; i < intervalos.Length; i++)
            {
              
                if (i == 0)
                {
                    intervalos[i] = Math.Round(tam,4);                   
                }
                else
                {                   
                    intervalos[i] = Math.Round(intervalos[i-1] + tam,4);         
                }
                Console.WriteLine(intervalos[i]);
                
            }

            return intervalos;
        }

        private void CargarFrecuencias(double[] numeros , double[] intervalos)
        {
            int[] frecuencias = new int[intervalos.Length];
            double suma = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                suma += numeros[i];

                for (int j = 0; j < intervalos.Length; j++)
                {
                    if(j == 0)
                    {
                        if (numeros[i] < intervalos[j])
                        {
                            frecuencias[j]++;


                        }
                    }
                    else
                    {
                        if ( intervalos[j-1] < numeros[i] && numeros[i] < intervalos[j])
                        {
                            frecuencias[j]++;


                        }
                    }
                }
            }
            for (int i = 0; i < intervalos.Length; i++)
            {
                if (i == 0)
                {
                    
                    dgvFrecuencias.Rows.Add(0, intervalos[i],frecuencias[i], suma/intervalos.Length);
                }
                else
                {

                    dgvFrecuencias.Rows.Add(intervalos[i - 1], intervalos[i],frecuencias[i], suma/intervalos.Length);
                }

            }
            

            
        }
        
        private double metodoMedia(double[] elem)
        {
            double media;
            double suma = 0;
            
            for (int i = 0; i < elem.Length ; i++)
            {
                suma += elem[i];
            }
            media = Math.Round(suma / elem.Length,4); 

            Console.WriteLine("La Media es:"+ media);
            return media;
            
        }
        private double metodoVarianza(double[] elem)
        {
            double varianza;
            double suma = 0;
            double media = metodoMedia(elem);

            for (int i = 0; i < elem.Length; i++)
            {
                suma += Math.Pow(elem[i] - media ,2) ;
            }

            varianza = Math.Round(suma / elem.Length,4);
            Console.WriteLine("La Varianza es:" + varianza);
            return varianza;
        }

        //private void cargarTabla()
        //{
        //    Random random = new Random();

        //    double rn1;
        //    double rn2;

        //    for (int i = 0; i < 15; i++)
        //    {
        //        rn1 = random.NextDouble();
        //        rn2 = random.NextDouble();

        //        dgvRandom.Rows.Add(rn1,rn2);
        //    }
        //}

        private void btnGenerar_Click(object sender, EventArgs e)
        {

            validarIngreso();
            dgvFrecuencias.Rows.Clear();
            dgvSerie.Rows.Clear();
            if (band_Ok)
            {
                //aca van los datos aleatorios
                //double media = metodoMedia(elem);
                //double varianza = metodoVarianza(elem);
                //double[] intervalos = generarIntervalos(elem);
                //CargarFrecuencias(elem, intervalos);

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
