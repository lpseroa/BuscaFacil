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
    public partial class frmAjuda : Form
    {
        public frmAjuda()
        {
            InitializeComponent();
        }

        private void frmAjuda_Load(object sender, EventArgs e)
        {
            txbAjuda.Text = "Bem vindo ao Busca Fácil! \r\n\n" +
                "Este programa foi desenvolvido para facilitar a busca de arquivos em seu computador. \r\n\r\n" +
                " A base de toda a busca é a caixa de texto  'Pasta Base de Ajuda' \r\n"     +
                "   Para escolher uma pasta base para a busca você pode clicar como botão direito do mouse \r\n" +
                "   ou digitar na caixa de texto o endereço completo da pasta bse desejada \r\n" +
                "Em seguida, digite o nome do arquivo que deseja encontrar e clique no botão 'Buscar'. \r\n" +
                "Os arquivos encontrados serão exibidos na lista abaixo. \r\n" +
                "Para abrir um arquivo, clique sobre ele e em seguida clique no botão 'Abrir'. \r\n" +
                "Para abrir a pasta onde o arquivo está localizado, clique sobre ele e em seguida clique no botão 'Abrir Pasta'. \r\n" +
                "Para fechar o programa, clique no botão 'Sair'.";
        }
    }
}
