using BuscaFacil.BuscaFacil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Policy;

namespace BuscaFacil
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void menBuscarArquivo_Click(object sender, EventArgs e)
        {
            FrmBusca fb = new FrmBusca(); // Substitua Form2 pelo nome do seu novo formulário
            fb.Show(); // Para mostrar o formulário
        }


        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            Configuracao.LeConfiguracao();
        }

        private void mnuConfigurarNotepad_Click(object sender, EventArgs e)
        {
            // Busca a Configuracao do notepad
            string urlNotepad = Configuracao.GetValor("urlNotepad");

            // cria um objeto inputBox 
            InputBox inputBox = new InputBox("Digite o endereço completo do notepad++", urlNotepad);
            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                // Substitui o valor da configuração 
                Configuracao.SubstituiConfiguracao("urlNotepad", inputBox.InputText);
            }
        }

        private void executarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string urlNotepad = Configuracao.GetValor("urlNotepad");
            //string arquivo = "";

            if (!File.Exists(urlNotepad))
            {
                MessageBox.Show("Notepad++ não encontrado.");
                return;
            }

            //string notepadPath = @"C:\Program Files\Notepad++\notepad++.exe";
            try
            {
                Process.Start(urlNotepad);
            }
            catch (Exception ex)
            {
                // Trate qualquer exceção que possa ocorrer (por exemplo, aplicativo não encontrado)
                Console.WriteLine($"Erro ao abrir o aplicativo: {ex.Message}");
            }
        }


    }
}

