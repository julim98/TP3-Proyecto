namespace TP3_proyecto
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.bPoisson = new System.Windows.Forms.Button();
            this.bExponencial = new System.Windows.Forms.Button();
            this.bUniforme = new System.Windows.Forms.Button();
            this.bNormal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bPoisson
            // 
            this.bPoisson.Location = new System.Drawing.Point(410, 238);
            this.bPoisson.Name = "bPoisson";
            this.bPoisson.Size = new System.Drawing.Size(127, 38);
            this.bPoisson.TabIndex = 0;
            this.bPoisson.Text = "Poisson";
            this.bPoisson.UseVisualStyleBackColor = true;
            this.bPoisson.Click += new System.EventHandler(this.bPoisson_Click);
            // 
            // bExponencial
            // 
            this.bExponencial.Location = new System.Drawing.Point(238, 238);
            this.bExponencial.Name = "bExponencial";
            this.bExponencial.Size = new System.Drawing.Size(127, 38);
            this.bExponencial.TabIndex = 1;
            this.bExponencial.Text = "Exponencial";
            this.bExponencial.UseVisualStyleBackColor = true;
            this.bExponencial.Click += new System.EventHandler(this.bExponencial_Click);
            // 
            // bUniforme
            // 
            this.bUniforme.Location = new System.Drawing.Point(67, 238);
            this.bUniforme.Name = "bUniforme";
            this.bUniforme.Size = new System.Drawing.Size(127, 38);
            this.bUniforme.TabIndex = 2;
            this.bUniforme.Text = "Uniforme";
            this.bUniforme.UseVisualStyleBackColor = true;
            this.bUniforme.Click += new System.EventHandler(this.bUniforme_Click);
            // 
            // bNormal
            // 
            this.bNormal.Location = new System.Drawing.Point(577, 238);
            this.bNormal.Name = "bNormal";
            this.bNormal.Size = new System.Drawing.Size(127, 38);
            this.bNormal.TabIndex = 3;
            this.bNormal.Text = "Normal";
            this.bNormal.UseVisualStyleBackColor = true;
            this.bNormal.Click += new System.EventHandler(this.bNormal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(617, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "Elija una distribucion para generar los numeros aleatorios";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 322);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bNormal);
            this.Controls.Add(this.bUniforme);
            this.Controls.Add(this.bExponencial);
            this.Controls.Add(this.bPoisson);
            this.Name = "Form1";
            this.Text = "TP3 - Simulacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bPoisson;
        private System.Windows.Forms.Button bExponencial;
        private System.Windows.Forms.Button bUniforme;
        private System.Windows.Forms.Button bNormal;
        private System.Windows.Forms.Label label1;
    }
}

