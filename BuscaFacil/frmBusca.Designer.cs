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
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_arquivos = new System.Windows.Forms.Label();
            this.lbl_arquivos_filtrados = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.TxtEscolheDir = new System.Windows.Forms.TextBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.txb_textoBusca = new System.Windows.Forms.TextBox();
            this.btnBuscaTexto = new System.Windows.Forms.Button();
            this.numProf = new System.Windows.Forms.NumericUpDown();
            this.lblProf = new System.Windows.Forms.Label();
            this.lsbMostraDir = new System.Windows.Forms.ListBox();
            this.lsbMostraArquivos = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkAcesso = new System.Windows.Forms.CheckBox();
            this.chkCriacao = new System.Windows.Forms.CheckBox();
            this.dtm_acesso = new System.Windows.Forms.DateTimePicker();
            this.dtm_criacao = new System.Windows.Forms.DateTimePicker();
            this.btnDesfazer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numProf)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "DIRETÓRIOS";
            this.label2.UseWaitCursor = true;
            // 
            // lbl_arquivos
            // 
            this.lbl_arquivos.AutoSize = true;
            this.lbl_arquivos.Location = new System.Drawing.Point(577, 64);
            this.lbl_arquivos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_arquivos.Name = "lbl_arquivos";
            this.lbl_arquivos.Size = new System.Drawing.Size(70, 13);
            this.lbl_arquivos.TabIndex = 8;
            this.lbl_arquivos.Text = "ARQUIVOS";
            this.lbl_arquivos.UseWaitCursor = true;
            // 
            // lbl_arquivos_filtrados
            // 
            this.lbl_arquivos_filtrados.AutoSize = true;
            this.lbl_arquivos_filtrados.Location = new System.Drawing.Point(572, 64);
            this.lbl_arquivos_filtrados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_arquivos_filtrados.Name = "lbl_arquivos_filtrados";
            this.lbl_arquivos_filtrados.Size = new System.Drawing.Size(139, 13);
            this.lbl_arquivos_filtrados.TabIndex = 10;
            this.lbl_arquivos_filtrados.Text = "ARQUIVOS FILTRADOS";
            this.lbl_arquivos_filtrados.UseWaitCursor = true;
            // 
            // TxtEscolheDir
            // 
            this.TxtEscolheDir.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TxtEscolheDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEscolheDir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEscolheDir.Location = new System.Drawing.Point(15, 27);
            this.TxtEscolheDir.Margin = new System.Windows.Forms.Padding(2);
            this.TxtEscolheDir.MaxLength = 100;
            this.TxtEscolheDir.Name = "TxtEscolheDir";
            this.TxtEscolheDir.Size = new System.Drawing.Size(310, 21);
            this.TxtEscolheDir.TabIndex = 1;
            this.TxtEscolheDir.Text = "Pasta Base de Busca";
            this.TxtEscolheDir.UseWaitCursor = true;
            this.TxtEscolheDir.Leave += new System.EventHandler(this.TxtEscolheDir_Leave);
            this.TxtEscolheDir.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TxtEscolheDir_MouseDown);
            // 
            // txtFiltro
            // 
            this.txtFiltro.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(359, 29);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(127, 21);
            this.txtFiltro.TabIndex = 9;
            this.txtFiltro.Text = "Filto Nome Arquivo";
            this.txtFiltro.UseWaitCursor = true;
            // 
            // txb_textoBusca
            // 
            this.txb_textoBusca.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txb_textoBusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_textoBusca.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_textoBusca.Location = new System.Drawing.Point(737, 29);
            this.txb_textoBusca.Margin = new System.Windows.Forms.Padding(2);
            this.txb_textoBusca.Name = "txb_textoBusca";
            this.txb_textoBusca.Size = new System.Drawing.Size(144, 21);
            this.txb_textoBusca.TabIndex = 27;
            this.txb_textoBusca.Text = "Texto a ser Buscado";
            this.txb_textoBusca.UseWaitCursor = true;
            // 
            // btnBuscaTexto
            // 
            this.btnBuscaTexto.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnBuscaTexto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBuscaTexto.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnBuscaTexto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnBuscaTexto.FlatAppearance.BorderSize = 3;
            this.btnBuscaTexto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnBuscaTexto.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaTexto.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBuscaTexto.Location = new System.Drawing.Point(899, 32);
            this.btnBuscaTexto.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscaTexto.Name = "btnBuscaTexto";
            this.btnBuscaTexto.Size = new System.Drawing.Size(45, 45);
            this.btnBuscaTexto.TabIndex = 28;
            this.btnBuscaTexto.Text = "BUSCA TEXTO";
            this.btnBuscaTexto.UseMnemonic = false;
            this.btnBuscaTexto.UseVisualStyleBackColor = false;
            this.btnBuscaTexto.UseWaitCursor = true;
            this.btnBuscaTexto.Click += new System.EventHandler(this.BtnBuscaTexto_Click);
            // 
            // numProf
            // 
            this.numProf.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numProf.Location = new System.Drawing.Point(801, 55);
            this.numProf.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numProf.Name = "numProf";
            this.numProf.Size = new System.Drawing.Size(80, 22);
            this.numProf.TabIndex = 29;
            this.numProf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numProf.UseWaitCursor = true;
            this.numProf.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblProf
            // 
            this.lblProf.AutoSize = true;
            this.lblProf.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProf.Location = new System.Drawing.Point(714, 64);
            this.lblProf.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProf.Name = "lblProf";
            this.lblProf.Size = new System.Drawing.Size(82, 13);
            this.lblProf.TabIndex = 30;
            this.lblProf.Text = "Profundidade";
            this.lblProf.UseWaitCursor = true;
            // 
            // lsbMostraDir
            // 
            this.lsbMostraDir.FormattingEnabled = true;
            this.lsbMostraDir.Location = new System.Drawing.Point(12, 84);
            this.lsbMostraDir.Name = "lsbMostraDir";
            this.lsbMostraDir.Size = new System.Drawing.Size(551, 342);
            this.lsbMostraDir.TabIndex = 35;
            this.lsbMostraDir.UseWaitCursor = true;
            this.lsbMostraDir.SelectedIndexChanged += new System.EventHandler(this.lsbMostraDir_SelectedIndexChanged);
            // 
            // lsbMostraArquivos
            // 
            this.lsbMostraArquivos.FormattingEnabled = true;
            this.lsbMostraArquivos.Location = new System.Drawing.Point(575, 84);
            this.lsbMostraArquivos.Name = "lsbMostraArquivos";
            this.lsbMostraArquivos.Size = new System.Drawing.Size(546, 342);
            this.lsbMostraArquivos.TabIndex = 36;
            this.lsbMostraArquivos.UseWaitCursor = true;
            this.lsbMostraArquivos.SelectedIndexChanged += new System.EventHandler(this.lsbMostraArquivos_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçõesToolStripMenuItem,
            this.sobreToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1156, 24);
            this.menuStrip1.TabIndex = 37;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.UseWaitCursor = true;
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editorToolStripMenuItem});
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.configuraçõesToolStripMenuItem.Text = "Configurações";
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.editorToolStripMenuItem.Text = "Editor";
            this.editorToolStripMenuItem.Click += new System.EventHandler(this.editorToolStripMenuItem_Click);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajudaToolStripMenuItem,
            this.informaçõesToolStripMenuItem});
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            this.ajudaToolStripMenuItem.Click += new System.EventHandler(this.ajudaToolStripMenuItem_Click);
            // 
            // informaçõesToolStripMenuItem
            // 
            this.informaçõesToolStripMenuItem.Name = "informaçõesToolStripMenuItem";
            this.informaçõesToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.informaçõesToolStripMenuItem.Text = "Informações";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            // 
            // chkAcesso
            // 
            this.chkAcesso.AutoSize = true;
            this.chkAcesso.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAcesso.Location = new System.Drawing.Point(717, 32);
            this.chkAcesso.Name = "chkAcesso";
            this.chkAcesso.Size = new System.Drawing.Size(15, 14);
            this.chkAcesso.TabIndex = 22;
            this.chkAcesso.UseVisualStyleBackColor = true;
            this.chkAcesso.UseWaitCursor = true;
            // 
            // chkCriacao
            // 
            this.chkCriacao.AutoSize = true;
            this.chkCriacao.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCriacao.Location = new System.Drawing.Point(602, 32);
            this.chkCriacao.Name = "chkCriacao";
            this.chkCriacao.Size = new System.Drawing.Size(15, 14);
            this.chkCriacao.TabIndex = 18;
            this.chkCriacao.UseVisualStyleBackColor = true;
            this.chkCriacao.UseWaitCursor = true;
            // 
            // dtm_acesso
            // 
            this.dtm_acesso.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtm_acesso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtm_acesso.Location = new System.Drawing.Point(623, 29);
            this.dtm_acesso.Name = "dtm_acesso";
            this.dtm_acesso.Size = new System.Drawing.Size(88, 20);
            this.dtm_acesso.TabIndex = 21;
            this.dtm_acesso.UseWaitCursor = true;
            this.dtm_acesso.Value = new System.DateTime(2024, 9, 12, 8, 40, 8, 0);
            // 
            // dtm_criacao
            // 
            this.dtm_criacao.CalendarFont = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtm_criacao.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtm_criacao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtm_criacao.Location = new System.Drawing.Point(507, 30);
            this.dtm_criacao.Name = "dtm_criacao";
            this.dtm_criacao.Size = new System.Drawing.Size(89, 20);
            this.dtm_criacao.TabIndex = 14;
            this.dtm_criacao.UseWaitCursor = true;
            this.dtm_criacao.Value = new System.DateTime(2024, 9, 12, 8, 40, 8, 0);
            // 
            // btnDesfazer
            // 
            this.btnDesfazer.Font = new System.Drawing.Font("Verdana", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesfazer.Location = new System.Drawing.Point(330, 27);
            this.btnDesfazer.Name = "btnDesfazer";
            this.btnDesfazer.Size = new System.Drawing.Size(22, 23);
            this.btnDesfazer.TabIndex = 34;
            this.btnDesfazer.Text = "X";
            this.btnDesfazer.UseVisualStyleBackColor = true;
            this.btnDesfazer.UseWaitCursor = true;
            this.btnDesfazer.Click += new System.EventHandler(this.btnRetorno_Click);
            // 
            // FrmBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(1156, 437);
            this.Controls.Add(this.btnDesfazer);
            this.Controls.Add(this.lblProf);
            this.Controls.Add(this.btnBuscaTexto);
            this.Controls.Add(this.numProf);
            this.Controls.Add(this.lsbMostraArquivos);
            this.Controls.Add(this.dtm_criacao);
            this.Controls.Add(this.dtm_acesso);
            this.Controls.Add(this.txb_textoBusca);
            this.Controls.Add(this.lsbMostraDir);
            this.Controls.Add(this.chkAcesso);
            this.Controls.Add(this.chkCriacao);
            this.Controls.Add(this.lbl_arquivos_filtrados);
            this.Controls.Add(this.lbl_arquivos);
            this.Controls.Add(this.TxtEscolheDir);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.MaximumSize = new System.Drawing.Size(2000, 1200);
            this.Name = "FrmBusca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSCA FÁCIL";
            this.UseWaitCursor = true;
            this.Shown += new System.EventHandler(this.FrmPrincipal_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numProf)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_arquivos;
        private System.Windows.Forms.Label lbl_arquivos_filtrados;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox TxtEscolheDir;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.TextBox txb_textoBusca;
        private System.Windows.Forms.Button btnBuscaTexto;
        private System.Windows.Forms.NumericUpDown numProf;
        private System.Windows.Forms.Label lblProf;
        private System.Windows.Forms.ListBox lsbMostraDir;
        private System.Windows.Forms.ListBox lsbMostraArquivos;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informaçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkAcesso;
        private System.Windows.Forms.CheckBox chkCriacao;
        private System.Windows.Forms.DateTimePicker dtm_acesso;
        private System.Windows.Forms.DateTimePicker dtm_criacao;
        private System.Windows.Forms.Button btnDesfazer;
    }
}

