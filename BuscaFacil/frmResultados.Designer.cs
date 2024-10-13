namespace BuscaFacil
{
    partial class frmResultados
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
            this.RtbResultado = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RtbResultado
            // 
            this.RtbResultado.Location = new System.Drawing.Point(24, 12);
            this.RtbResultado.Name = "RtbResultado";
            this.RtbResultado.Size = new System.Drawing.Size(797, 371);
            this.RtbResultado.TabIndex = 0;
            this.RtbResultado.Text = "";
            this.RtbResultado.TextChanged += new System.EventHandler(this.RtbResultado_TextChanged);
            // 
            // frmResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 395);
            this.Controls.Add(this.RtbResultado);
            this.Name = "frmResultados";
            this.Text = "Resultado Esperado";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox RtbResultado;
    }
}