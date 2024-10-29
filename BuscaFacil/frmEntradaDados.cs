using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscaFacil
{
    public partial class InputBox : Form
    {

        public string InputText { get; private set; }

        public InputBox(string pergunta, string valorDefault)
        {
            InitializeComponent();
            txtDados.Text=valorDefault;
            lblTitulo.Text = pergunta; // Defina o texto da pergunta
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            InputText = txtDados.Text; // Armazena a entrada
            this.DialogResult = DialogResult.OK; // Define o resultado do diálogo
            this.Close(); // Fecha o formulário
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            this.Close(); // Fecha o formulário
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
