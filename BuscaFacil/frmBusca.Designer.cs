namespace BuscaFacil
{
    partial class FrmBusca
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBusca));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lsbMostraDir = new System.Windows.Forms.ListBox();
            this.Menu1 = new System.Windows.Forms.MenuStrip();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorTxtMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorDocMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorXlsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizaPDFMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizaImagemMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Aviso = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblAlteracao = new System.Windows.Forms.Label();
            this.lblProf = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxbFiltroNome = new System.Windows.Forms.TextBox();
            this.TxbFiltroTexto = new System.Windows.Forms.TextBox();
            this.TxbPastaBase = new System.Windows.Forms.TextBox();
            this.NumProf = new System.Windows.Forms.NumericUpDown();
            this.BtnBuscaTexto = new System.Windows.Forms.Button();
            this.btnRetorno = new System.Windows.Forms.Button();
            this.DtmAcesso = new System.Windows.Forms.DateTimePicker();
            this.DtmCriacao = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnResetNome = new System.Windows.Forms.Button();
            this.btnResetConteudo = new System.Windows.Forms.Button();
            this.process1 = new System.Diagnostics.Process();
            this.Menu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumProf)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsbMostraDir
            // 
            this.lsbMostraDir.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic);
            this.lsbMostraDir.FormattingEnabled = true;
            this.lsbMostraDir.ItemHeight = 22;
            this.lsbMostraDir.Location = new System.Drawing.Point(18, 148);
            this.lsbMostraDir.Name = "lsbMostraDir";
            this.lsbMostraDir.Size = new System.Drawing.Size(880, 422);
            this.lsbMostraDir.TabIndex = 35;
            this.lsbMostraDir.SelectedIndexChanged += new System.EventHandler(this.lsbMostraDir_SelectedIndexChanged);
            // 
            // Menu1
            // 
            this.Menu1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.Menu1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.Menu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçõesToolStripMenuItem,
            this.sobreToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.Menu1.Location = new System.Drawing.Point(5, 5);
            this.Menu1.Name = "Menu1";
            this.Menu1.Size = new System.Drawing.Size(1359, 54);
            this.Menu1.TabIndex = 37;
            this.Menu1.Text = "menuStrip1";
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editorTxtMenuItem,
            this.editorDocMenuItem,
            this.editorXlsMenuItem,
            this.visualizaPDFMenuItem,
            this.visualizaImagemMenuItem});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(142, 50);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // editorTxtMenuItem
            // 
            this.editorTxtMenuItem.Name = "editorTxtMenuItem";
            this.editorTxtMenuItem.Size = new System.Drawing.Size(280, 34);
            this.editorTxtMenuItem.Text = "Editor Texto";
            this.editorTxtMenuItem.Click += new System.EventHandler(this.editorTxtMenuItem_Click);
            // 
            // editorDocMenuItem
            // 
            this.editorDocMenuItem.Name = "editorDocMenuItem";
            this.editorDocMenuItem.Size = new System.Drawing.Size(280, 34);
            this.editorDocMenuItem.Text = "Editor DOC";
            this.editorDocMenuItem.Click += new System.EventHandler(this.editorDocMenuItem_Click);
            // 
            // editorXlsMenuItem
            // 
            this.editorXlsMenuItem.Name = "editorXlsMenuItem";
            this.editorXlsMenuItem.Size = new System.Drawing.Size(280, 34);
            this.editorXlsMenuItem.Text = "Editor XLS";
            this.editorXlsMenuItem.Click += new System.EventHandler(this.editorXlsMenuItem_Click);
            // 
            // visualizaPDFMenuItem
            // 
            this.visualizaPDFMenuItem.Name = "visualizaPDFMenuItem";
            this.visualizaPDFMenuItem.Size = new System.Drawing.Size(280, 34);
            this.visualizaPDFMenuItem.Text = "Visualizador PDF";
            this.visualizaPDFMenuItem.Click += new System.EventHandler(this.visualizaPDFMenuItem_Click);
            // 
            // visualizaImagemMenuItem
            // 
            this.visualizaImagemMenuItem.Name = "visualizaImagemMenuItem";
            this.visualizaImagemMenuItem.Size = new System.Drawing.Size(280, 34);
            this.visualizaImagemMenuItem.Text = "Visualizador Imagem";
            this.visualizaImagemMenuItem.Click += new System.EventHandler(this.visualizaImagemMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajudaToolStripMenuItem,
            this.informaçõesToolStripMenuItem});
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(75, 50);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(213, 34);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            this.ajudaToolStripMenuItem.Click += new System.EventHandler(this.ajudaToolStripMenuItem_Click);
            // 
            // informaçõesToolStripMenuItem
            // 
            this.informaçõesToolStripMenuItem.Name = "informaçõesToolStripMenuItem";
            this.informaçõesToolStripMenuItem.Size = new System.Drawing.Size(213, 34);
            this.informaçõesToolStripMenuItem.Text = "Informações";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(57, 50);
            this.sairToolStripMenuItem.Text = "Sair";
            // 
            // Aviso
            // 
            this.Aviso.AutoSize = true;
            this.Aviso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Aviso.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.Aviso.ForeColor = System.Drawing.Color.Red;
            this.Aviso.Location = new System.Drawing.Point(18, 582);
            this.Aviso.Name = "Aviso";
            this.Aviso.Size = new System.Drawing.Size(78, 24);
            this.Aviso.TabIndex = 38;
            this.Aviso.Text = "Avisos";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lblAlteracao
            // 
            this.lblAlteracao.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblAlteracao.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Italic);
            this.lblAlteracao.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblAlteracao.Location = new System.Drawing.Point(229, 40);
            this.lblAlteracao.Name = "lblAlteracao";
            this.lblAlteracao.Size = new System.Drawing.Size(137, 26);
            this.lblAlteracao.TabIndex = 43;
            this.lblAlteracao.Text = "Alteração";
            this.lblAlteracao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProf
            // 
            this.lblProf.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Italic);
            this.lblProf.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblProf.Location = new System.Drawing.Point(256, 72);
            this.lblProf.Name = "lblProf";
            this.lblProf.Size = new System.Drawing.Size(112, 50);
            this.lblProf.TabIndex = 46;
            this.lblProf.Text = "Niveis";
            this.lblProf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.NavajoWhite;
            this.label3.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Italic);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(244, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 44;
            this.label3.Text = "Criação";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxbFiltroNome
            // 
            this.TxbFiltroNome.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TxbFiltroNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxbFiltroNome.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.TxbFiltroNome.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TxbFiltroNome.Location = new System.Drawing.Point(4, 15);
            this.TxbFiltroNome.Margin = new System.Windows.Forms.Padding(2);
            this.TxbFiltroNome.Name = "TxbFiltroNome";
            this.TxbFiltroNome.Size = new System.Drawing.Size(203, 28);
            this.TxbFiltroNome.TabIndex = 9;
            this.TxbFiltroNome.Text = "Filtro Nome Arquivo";
            this.TxbFiltroNome.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TxbFiltroNome_MouseClick);
            this.TxbFiltroNome.TextChanged += new System.EventHandler(this.TxbFiltroNome_TextChanged);
            // 
            // TxbFiltroTexto
            // 
            this.TxbFiltroTexto.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TxbFiltroTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxbFiltroTexto.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.TxbFiltroTexto.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TxbFiltroTexto.Location = new System.Drawing.Point(4, 59);
            this.TxbFiltroTexto.Margin = new System.Windows.Forms.Padding(2);
            this.TxbFiltroTexto.Name = "TxbFiltroTexto";
            this.TxbFiltroTexto.Size = new System.Drawing.Size(203, 28);
            this.TxbFiltroTexto.TabIndex = 27;
            this.TxbFiltroTexto.Text = "Texto a ser Buscado";
            this.TxbFiltroTexto.Click += new System.EventHandler(this.TxbFiltroTexto_Click);
            // 
            // TxbPastaBase
            // 
            this.TxbPastaBase.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TxbPastaBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxbPastaBase.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.TxbPastaBase.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.TxbPastaBase.Location = new System.Drawing.Point(18, 49);
            this.TxbPastaBase.Margin = new System.Windows.Forms.Padding(2);
            this.TxbPastaBase.MaxLength = 100;
            this.TxbPastaBase.Name = "TxbPastaBase";
            this.TxbPastaBase.Size = new System.Drawing.Size(311, 28);
            this.TxbPastaBase.TabIndex = 1;
            this.TxbPastaBase.Text = "C:\\";
            this.TxbPastaBase.Leave += new System.EventHandler(this.TxbPastaBase_Leave);
            this.TxbPastaBase.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TxbPastaBase_MouseDown);
            // 
            // NumProf
            // 
            this.NumProf.Font = new System.Drawing.Font("Verdana", 8F);
            this.NumProf.Location = new System.Drawing.Point(227, 89);
            this.NumProf.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumProf.Name = "NumProf";
            this.NumProf.Size = new System.Drawing.Size(57, 27);
            this.NumProf.TabIndex = 29;
            this.NumProf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumProf.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // BtnBuscaTexto
            // 
            this.BtnBuscaTexto.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnBuscaTexto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnBuscaTexto.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.BtnBuscaTexto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnBuscaTexto.FlatAppearance.BorderSize = 3;
            this.BtnBuscaTexto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.BtnBuscaTexto.Font = new System.Drawing.Font("Verdana", 6F);
            this.BtnBuscaTexto.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnBuscaTexto.Location = new System.Drawing.Point(347, 42);
            this.BtnBuscaTexto.Margin = new System.Windows.Forms.Padding(0);
            this.BtnBuscaTexto.Name = "BtnBuscaTexto";
            this.BtnBuscaTexto.Size = new System.Drawing.Size(68, 68);
            this.BtnBuscaTexto.TabIndex = 1;
            this.BtnBuscaTexto.Text = "BUSCA TEXTO";
            this.BtnBuscaTexto.UseMnemonic = false;
            this.BtnBuscaTexto.UseVisualStyleBackColor = false;
            this.BtnBuscaTexto.Click += new System.EventHandler(this.BtnBuscaTexto_Click);
            // 
            // btnRetorno
            // 
            this.btnRetorno.Font = new System.Drawing.Font("Verdana", 8F);
            this.btnRetorno.Location = new System.Drawing.Point(18, 86);
            this.btnRetorno.Name = "btnRetorno";
            this.btnRetorno.Size = new System.Drawing.Size(39, 28);
            this.btnRetorno.TabIndex = 34;
            this.btnRetorno.Text = "<-";
            this.btnRetorno.UseVisualStyleBackColor = true;
            this.btnRetorno.Visible = false;
            this.btnRetorno.Click += new System.EventHandler(this.btnRetorno_Click);
            // 
            // DtmAcesso
            // 
            this.DtmAcesso.Font = new System.Drawing.Font("Verdana", 8F);
            this.DtmAcesso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtmAcesso.Location = new System.Drawing.Point(247, 60);
            this.DtmAcesso.Name = "DtmAcesso";
            this.DtmAcesso.Size = new System.Drawing.Size(119, 27);
            this.DtmAcesso.TabIndex = 21;
            this.DtmAcesso.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // DtmCriacao
            // 
            this.DtmCriacao.CalendarFont = new System.Drawing.Font("Verdana", 8F);
            this.DtmCriacao.Font = new System.Drawing.Font("Verdana", 8F);
            this.DtmCriacao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtmCriacao.Location = new System.Drawing.Point(247, 15);
            this.DtmCriacao.Name = "DtmCriacao";
            this.DtmCriacao.Size = new System.Drawing.Size(119, 27);
            this.DtmCriacao.TabIndex = 14;
            this.DtmCriacao.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel1.Controls.Add(this.btnResetNome);
            this.panel1.Controls.Add(this.btnResetConteudo);
            this.panel1.Controls.Add(this.DtmCriacao);
            this.panel1.Controls.Add(this.DtmAcesso);
            this.panel1.Controls.Add(this.TxbFiltroTexto);
            this.panel1.Controls.Add(this.TxbFiltroNome);
            this.panel1.Controls.Add(this.lblAlteracao);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(509, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 95);
            this.panel1.TabIndex = 47;
            // 
            // btnResetNome
            // 
            this.btnResetNome.Location = new System.Drawing.Point(212, 15);
            this.btnResetNome.Name = "btnResetNome";
            this.btnResetNome.Size = new System.Drawing.Size(25, 26);
            this.btnResetNome.TabIndex = 51;
            this.btnResetNome.Text = "X";
            this.btnResetNome.UseVisualStyleBackColor = true;
            this.btnResetNome.Click += new System.EventHandler(this.btnResetNome_Click);
            // 
            // btnResetConteudo
            // 
            this.btnResetConteudo.Location = new System.Drawing.Point(212, 59);
            this.btnResetConteudo.Name = "btnResetConteudo";
            this.btnResetConteudo.Size = new System.Drawing.Size(25, 26);
            this.btnResetConteudo.TabIndex = 50;
            this.btnResetConteudo.Text = "X";
            this.btnResetConteudo.UseVisualStyleBackColor = true;
            this.btnResetConteudo.Click += new System.EventHandler(this.btnResetConteudo_Click);
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // FrmBusca
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(916, 615);
            this.Controls.Add(this.BtnBuscaTexto);
            this.Controls.Add(this.NumProf);
            this.Controls.Add(this.Aviso);
            this.Controls.Add(this.lsbMostraDir);
            this.Controls.Add(this.Menu1);
            this.Controls.Add(this.btnRetorno);
            this.Controls.Add(this.TxbPastaBase);
            this.Controls.Add(this.lblProf);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menu1;
            this.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.MaximumSize = new System.Drawing.Size(2000, 1200);
            this.Name = "FrmBusca";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSCA FÁCIL";
            this.Load += new System.EventHandler(this.FrmBusca_Load);
            this.Shown += new System.EventHandler(this.FrmBusca_Shown);
            this.Menu1.ResumeLayout(false);
            this.Menu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumProf)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.ListBox lsbMostraDir;
        private System.Windows.Forms.MenuStrip Menu1;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informaçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorTxtMenuItem;
        private System.Windows.Forms.Label Aviso;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblAlteracao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProf;
        private System.Windows.Forms.TextBox TxbFiltroNome;
        private System.Windows.Forms.TextBox TxbFiltroTexto;
        private System.Windows.Forms.TextBox TxbPastaBase;
        private System.Windows.Forms.NumericUpDown NumProf;
        private System.Windows.Forms.Button BtnBuscaTexto;
        private System.Windows.Forms.Button btnRetorno;
        private System.Windows.Forms.DateTimePicker DtmAcesso;
        private System.Windows.Forms.DateTimePicker DtmCriacao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnResetNome;
        private System.Windows.Forms.Button btnResetConteudo;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.ToolStripMenuItem editorDocMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorXlsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizaPDFMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizaImagemMenuItem;
    }
}

