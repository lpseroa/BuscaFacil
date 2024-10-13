namespace BuscaFacil
{
    partial class FrmPrincipal
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuConfigurarNotepad = new System.Windows.Forms.ToolStripMenuItem();
            this.executarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menNotepad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menBuscarArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Verdana", 9F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConfigurarNotepad,
            this.executarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.OwnerItem = this.menNotepad;
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // mnuConfigurarNotepad
            // 
            this.mnuConfigurarNotepad.Name = "mnuConfigurarNotepad";
            this.mnuConfigurarNotepad.Size = new System.Drawing.Size(180, 22);
            this.mnuConfigurarNotepad.Text = "Configurar";
            this.mnuConfigurarNotepad.Click += new System.EventHandler(this.mnuConfigurarNotepad_Click);
            // 
            // executarToolStripMenuItem
            // 
            this.executarToolStripMenuItem.Name = "executarToolStripMenuItem";
            this.executarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.executarToolStripMenuItem.Text = "Executar";
            this.executarToolStripMenuItem.Click += new System.EventHandler(this.executarToolStripMenuItem_Click);
            // 
            // menNotepad
            // 
            this.menNotepad.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menNotepad.DropDown = this.contextMenuStrip1;
            this.menNotepad.Name = "menNotepad";
            this.menNotepad.Size = new System.Drawing.Size(81, 22);
            this.menNotepad.Text = "Notepad++";

            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menBuscarArquivo,
            this.menNotepad});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(280, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menBuscarArquivo
            // 
            this.menBuscarArquivo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.menBuscarArquivo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menBuscarArquivo.Name = "menBuscarArquivo";
            this.menBuscarArquivo.Size = new System.Drawing.Size(99, 22);
            this.menBuscarArquivo.Text = "Buscar Arquivo";
            this.menBuscarArquivo.Click += new System.EventHandler(this.menBuscarArquivo_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 90);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmPrincipal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menBuscarArquivo;
        private System.Windows.Forms.ToolStripMenuItem menNotepad;
        private System.Windows.Forms.ToolStripMenuItem mnuConfigurarNotepad;
        private System.Windows.Forms.ToolStripMenuItem executarToolStripMenuItem;
    }
}