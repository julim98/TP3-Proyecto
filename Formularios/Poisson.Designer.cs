
namespace TP3_proyecto.Formularios
{
    partial class Poisson
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ID_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VALOR_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCantValores = new System.Windows.Forms.TextBox();
            this.txtLambda = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ingrese valor lambda(λ):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cantidad de valores a generar:";
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_,
            this.VALOR_});
            this.dgv.Location = new System.Drawing.Point(15, 72);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(340, 221);
            this.dgv.TabIndex = 3;
            // 
            // ID_
            // 
            this.ID_.HeaderText = "ID";
            this.ID_.Name = "ID_";
            this.ID_.Width = 150;
            // 
            // VALOR_
            // 
            this.VALOR_.HeaderText = "VALOR";
            this.VALOR_.Name = "VALOR_";
            this.VALOR_.Width = 150;
            // 
            // txtCantValores
            // 
            this.txtCantValores.Location = new System.Drawing.Point(211, 44);
            this.txtCantValores.Name = "txtCantValores";
            this.txtCantValores.Size = new System.Drawing.Size(56, 20);
            this.txtCantValores.TabIndex = 5;
            this.txtCantValores.TextChanged += new System.EventHandler(this.txtCantValores_TextChanged);
            // 
            // txtLambda
            // 
            this.txtLambda.Location = new System.Drawing.Point(167, 5);
            this.txtLambda.Name = "txtLambda";
            this.txtLambda.Size = new System.Drawing.Size(100, 20);
            this.txtLambda.TabIndex = 6;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(280, 44);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 7;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            // 
            // Poisson
            // 
            this.ClientSize = new System.Drawing.Size(363, 302);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtLambda);
            this.Controls.Add(this.txtCantValores);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Poisson";
            this.Text = "Distribución Poisson";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        
        
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        
        private System.Windows.Forms.DataGridView dgv;
        
        private System.Windows.Forms.TextBox txtCantValores;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_;
        private System.Windows.Forms.DataGridViewTextBoxColumn VALOR_;
        private System.Windows.Forms.TextBox txtLambda;
        private System.Windows.Forms.Button btnGenerar;
    }
}