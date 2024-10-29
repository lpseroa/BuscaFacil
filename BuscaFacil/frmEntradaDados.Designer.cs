namespace BuscaFacil
{
    partial class InputBox
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
            this.txtDados = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnFecha = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDados
            // 
            this.txtDados.Location = new System.Drawing.Point(12, 38);
            this.txtDados.Name = "txtDados";
            this.txtDados.Size = new System.Drawing.Size(501, 26);
            this.txtDados.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnOK.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOK.Location = new System.Drawing.Point(12, 79);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 44);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnFecha
            // 
            this.btnFecha.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnFecha.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFecha.Location = new System.Drawing.Point(429, 70);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(84, 44);
            this.btnFecha.TabIndex = 3;
            this.btnFecha.Text = "FECHA";
            this.btnFecha.UseVisualStyleBackColor = false;
            this.btnFecha.Click += new System.EventHandler(this.btnFecha_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(248, 29);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "O que deve ser Solicitado ";
            this.lblTitulo.UseCompatibleTextRendering = true;
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // InputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 126);
            this.Controls.Add(this.txtDados);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnFecha);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.Name = "InputBox";
            this.Text = "Digite os Dados Solicitados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDados;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnFecha;
        private System.Windows.Forms.Label lblTitulo;
    }
}