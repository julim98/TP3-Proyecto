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

        private void bPoisson_Click(object sender, EventArgs e)
        {
            Poisson poisson = new Poisson();
            poisson.Show();
        }
    }
}
