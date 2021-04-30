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

namespace TP3_proyecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

 Poisson
        private void bPoisson_Click(object sender, EventArgs e)
        {
            Poisson poisson = new Poisson();
            poisson.Show();

        private void bExponencial_Click(object sender, EventArgs e)
        {
            Exponencial exponencial = new Exponencial();
            exponencial.Show();
        }

        private void bUniforme_Click(object sender, EventArgs e)
        {
            Uniforme uniforme = new Uniforme();
            uniforme.Show();
 main
        }
    }
}
