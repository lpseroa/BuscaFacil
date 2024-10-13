namespace BuscaFacil
{
    partial class frmAjuda
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
            this.txbAjuda = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txbAjuda
            // 
            this.txbAjuda.Location = new System.Drawing.Point(21, 14);
            this.txbAjuda.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.txbAjuda.Multiline = true;
            this.txbAjuda.Name = "txbAjuda";
            this.txbAjuda.Size = new System.Drawing.Size(699, 353);
            this.txbAjuda.TabIndex = 0;
            // 
            // frmAjuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 378);
            this.Controls.Add(this.txbAjuda);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "frmAjuda";
            this.Text = "Ajuda";
            this.Load += new System.EventHandler(this.frmAjuda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbAjuda;
    }
}