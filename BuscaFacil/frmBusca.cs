using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.AccessControl;
using BuscaFacil.BuscaFacil;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Net.NetworkInformation;
using System.Diagnostics.Eventing.Reader;

//=============================================================================
//
// Criterios de Trabalho
//
// 1. File                      - Permite criar, copiar, mover, e excluir arquivos,
//                                  além de ler e gravar dados em arquivos.
// 2. Directory                 - Permite manipular diretórios, como criar, mover,  e excluir
//                                  diretórios, além de listar arquivos e subdiretórios.
// 3. Path                      - Fornece métodos para manipular strings de caminho de arquivo,
//                                  como obter o nome do arquivo, a extensão e combinar caminhos.
// 4. FileInfo e DirectoryInfo  - Classes que fornecem métodos e propriedades para trabalhar
//                                  com arquivos e diretórios de forma mais orientada a objetos.
//
//
// Essas classes podem e vao ser usadas dentro dos metodos mas a comunicacao se
//   dara atraves de Listas de Strings e serao convertidos para arrays se for necesario
//=============================================================================


//=============================================================================
//  Açoes dos Objetos do Forms BuscaFacil
//=============================================================================

namespace BuscaFacil
{
    public partial class FrmBusca : Form
    {
        // Define os objetos imagens
        //Image imgDesfazer;
        Image imgLupa;

        // Criando uma pilha de arrays de strings para armazenar os
        //  caminhos das pastas que foram buscadas
        Stack<string> pilhaPastas = new Stack<string>();

        public const string PASTA_BUSCA_DEFAULT = "Pasta Base de Busca";    // Valor inicial do texto da pasta de busca

        // Metodo que permite a outras classes acessar ao label de aviso
        public void SetAviso(string texto)
        {
            Aviso.Text = texto;
        }

        public FrmBusca()
        {
            InitializeComponent();
            InitializeVerticalLabel();
        }

        private void InitializeVerticalLabel()
        {
            VerticalLabel verticalLabel = new VerticalLabel
            {
                TextContent = "FILTROS",
                ForeColor = System.Drawing.Color.Black,
                //Font = new System.Drawing.Font("Verdana", 8),
                Size = new System.Drawing.Size(30, 100), // Ajuste o tamanho conforme necessário
                Location = new System.Drawing.Point(500, 20) // Ajuste a posição conforme necessário
            };

            this.Controls.Add(verticalLabel);
            this.Font = new System.Drawing.Font("Verdana", 7, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        // cria um objeto do tipo BuscaUtil e passa a referencia do objeto frmBusca para ele
        private void FrmBusca_Load(object sender, EventArgs e)
        {
            //BuscaUtil bu = new BuscaUtil(this);
        }


        // Inicializacao do formulario Principal
        public void FrmBusca_Initialize()
        {
            try
            {
                // Carrega imagens para os botões
                this.imgLupa = Image.FromFile("./loupe.png");
            }
            catch (Exception e)
            {
                MessageBox.Show("Problema na carga da imagem " + e.Message);
                Environment.Exit(1);
            }

            // Redimensionar as imagens e atribui-las aos botões

            Image resizedImage = BuscaUtil.ResizeImage(imgLupa, (int)(BtnBuscaTexto.Width * 0.35), (int)(BtnBuscaTexto.Height * 0.35));
            BtnBuscaTexto.Image = resizedImage;
            BtnBuscaTexto.Text = "";
            BtnBuscaTexto.Size = new Size(35, 35);
            Aviso.Text = "";


            
        }

        // Quando o mouse se afasta da pasta base de busca chama a rotina principal de busca
        private void TxbPastaBase_Leave(object sender, EventArgs e)
        {
            if ((TxbPastaBase.Text != "") || (TxbPastaBase.Text != PASTA_BUSCA_DEFAULT))
            {
                lsbMostraDir.Items.Clear();
                BuscaTudo();
            }
        }

        // inicializacao do Formulario Principal
        private void FrmBusca_Shown(object sender, EventArgs e)
        {
            FrmBusca_Initialize();
            BtnBuscaTexto.Focus();
            BtnBuscaTexto.Select();
        }


        // procura na profundidade escolhida a palavra definida no textBox dentro dos araquivos
        // Se a profundidade é Zero significa que nao ha limite na busca
        private void BtnBuscaTexto_Click(object sender, EventArgs e)
        {
            lsbMostraDir.Items.Clear();
            BuscaTudo();
        }


        private void TxbPastaBase_MouseDown(object sender, MouseEventArgs e)
        {
            // Verifica se o botão direito do mouse foi clicado
            if (e.Button == MouseButtons.Right)
            {
                using (var dialog = new FolderBrowserDialog())
                {
                    DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string pastaBuscaSelecionada = dialog.SelectedPath;

                        // quando insere um valor no txtEscolheDir verifica se esta vazio , se nao estiver
                        // coloca o valor na pilha e habilita o botao de retorno
                        if (TxbPastaBase.Text != "")
                        {
                            pilhaPastas.Push(TxbPastaBase.Text);
                            //btnDesfazer.Visible = true;
                        }

                        TxbPastaBase.Text = pastaBuscaSelecionada;
                        TxbPastaBase.ForeColor = System.Drawing.SystemColors.WindowText;
                    }
                }

            }
                BuscaTudo();

        }

        private void TxbFiltroNome_TextChanged(object sender, EventArgs e)
        {
            TxbFiltroNome.ForeColor = System.Drawing.SystemColors.WindowText;
        }

        private void TxbFiltroNome_MouseClick(object sender, MouseEventArgs e)
        {
            TxbFiltroNome.Text = "";
        }

        // botao que retorna os diretorios buscados anteriormente atraves da pilha
        private void btnRetorno_Click(object sender, EventArgs e)
        {
            if (pilhaPastas.Count > 1)
            {
                // Pop: Removendo a string do topo da pilha
                string stringRemovida = pilhaPastas.Pop();

                TxbPastaBase.Text = stringRemovida;   // Coloca o item selecionado no campo de de busca e inicia a busca
                                                      // Limpa caixa de textos de saidas dos arquivos e pastas
                lsbMostraDir.Items.Clear();

                BuscaTudo();
            }

            if (pilhaPastas.Count == 1)
            {
                btnRetorno.Visible = false;
            }
        }




        // Quando se clica em um diretorio cosidera-se esse o diretorio base e refaz a busca
        //  quando é num arquivo, se for um arquivo texto abre o arquivo num editor configurado
        private void lsbMostraDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbMostraDir.SelectedItem != null)
            {
                string itemSelecionado = lsbMostraDir.SelectedItem.ToString();

                char tipo = itemSelecionado[0];
                string itemFiltrado = itemSelecionado.Substring(3);

                try
                {
                    if (tipo == 'A')    // se é um arquivo 
                    {
                        
                        string extensao = Path.GetExtension(itemFiltrado);

                        if ((extensao == ".txt") || (extensao == ".c") || (extensao == ".cpp")
                            || (extensao == ".cs") || (extensao == ".log"))
                        {
                            string editor = Configuracao.GetValor("editorTxt");

                            try
                            {
                                Process.Start(editor, itemFiltrado);
                            }
                            catch (Exception)
                            {
                                Aviso.Text = $"Erro ao abrir o editor de texto configurado";
                                Process.Start(itemFiltrado);
                            }
                        }
                        else if ((extensao == ".doc") || (extensao == ".docx") || (extensao == ".odt"))
                        {
                            string editor = Configuracao.GetValor("editorDoc");

                            try
                            {
                                Process.Start(editor, itemFiltrado);
                            }
                            catch (Exception)
                            {
                                Aviso.Text = $"Erro ao abrir o editor Doc configurado";
                                Process.Start(itemFiltrado);
                            }
                        }
                        else if ((extensao == ".xls") || (extensao == ".ods") )
                        {
                            string editor = Configuracao.GetValor("editorXls");

                            try
                            {
                                Process.Start(editor, itemFiltrado);
                            }
                            catch (Exception)
                            {
                                Aviso.Text = $"Erro ao abrir o editor XLS configurado";
                                Process.Start(itemFiltrado);
                            }
                        }
                        else if ((extensao == ".png") || (extensao == ".jpg") || (extensao == ".jpeg"))
                        {
                            string visualiz = Configuracao.GetValor("visualImagem");

                            try
                            {
                                Process.Start(visualiz, itemFiltrado);
                            }
                            catch (Exception)
                            {
                                Aviso.Text = $"Erro ao abrir o editor XLS configurado";
                                Process.Start(itemFiltrado);
                            }
                        }
                        else if ((extensao == ".pdf"))
                        {
                            string visualiz = Configuracao.GetValor("visualPDF");

                            try
                            {
                                Process.Start(visualiz, itemFiltrado);
                            }
                            catch (Exception)
                            {
                                Aviso.Text = $"Erro ao abrir o editor pdf configurado";
                                Process.Start(itemFiltrado);
                            }
                        }
                        else if ((extensao == ".bin") || (extensao == ".exe") )
                        {
                                Aviso.Text = $"Arquivo nao pode ser visualizado";
                        }

                        else
                        {
                            Process.Start(itemFiltrado);

                        }



                    }
                    else if (tipo == 'D')   // se é um diretorio
                    {
                        // quando insere um valor no txtEscolheDir verifica se esta vazio , se nao estiver
                        // coloca o valor na pilha e habilita o botao de retorno
                        if ((TxbPastaBase.Text != "") && (TxbPastaBase.Text != PASTA_BUSCA_DEFAULT))
                        {
                            pilhaPastas.Push(TxbPastaBase.Text);  // armzena na pilha
                            btnRetorno.Visible = true;
                        }

                        TxbPastaBase.Text = itemFiltrado;   // Coloca o item selecionado no campo de de busca e inicia a busca
                                                            // Extrai do string da pasta base o caminho da pasta a partir do terceiro caracter
                                                            // Limpa caixa de textos de saidas dos arquivos e pastas
                        lsbMostraDir.Items.Clear();
                        BuscaTudo();
                    }
                }
                catch
                {
                    Aviso.Text = $"Problema ao abrir o {itemFiltrado} !";
                }



            }
        }

        private void TxbFiltroTexto_Click(object sender, EventArgs e)
        {
            TxbFiltroTexto.ForeColor = Color.Black;
            TxbFiltroTexto.Text = "";
            TxbFiltroTexto.Focus();
        }


        // Metodo principal para a Busca de arquivos e pastas solicitadas a partir da pasta base
        private void BuscaTudo()
        {
            Aviso.Text = "";
            lsbMostraDir.Items.Clear();

            // Leitura dos objetos do Windows Form para processamento dos dados no BuscaUtil
            BuscaUtil.filtroNome = TxbFiltroNome.Text;
            string pastaBusca = TxbPastaBase.Text;
            BuscaUtil.pastaBusca = TxbPastaBase.Text;
            BuscaUtil.filtroConteudo = TxbFiltroTexto.Text;
            BuscaUtil.dataAcessoMinima = DtmAcesso.Text;
            BuscaUtil.dataCriacaoMinima = DtmCriacao.Text;


            //string[] retBuscaPastas = new string[0];    // array de retorno vazio


            // se caixa de texto da pasta esta vazio aborta
            if ((pastaBusca == "") || (pastaBusca == PASTA_BUSCA_DEFAULT))
            {
                Aviso.Text = "Insira um diretorio válido!";
                return;
            }

            // Aborta tambem se pasta nao exisir
            if (!Directory.Exists(pastaBusca))
            {
                Aviso.Text = "Diretório Não Existe!";
                return;
            }

            // Faz a busca nos diretorios da pastaBusca na profundiade necessaria

            BuscaUtil.BuscaTudoEmUmaPasta(pastaBusca, (int)NumProf.Value);
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAjuda helpForm = new frmAjuda();
            helpForm.ShowDialog(); // Abre o formulário de ajuda como um diálogo modal
        }

        private void btnResetConteudo_Click(object sender, EventArgs e)
        {
            TxbFiltroTexto.Text = "";
        }

        private void btnResetNome_Click(object sender, EventArgs e)
        {
            TxbFiltroNome.Text = "";
        }

        // Menu de configuracao 

        private void editorTxtMenuItem_Click(object sender, EventArgs e)
        {
            // Busca a Configuracao do editor de textos
            string editorTxt = Configuracao.GetValor("editorTxt");

            // cria um objeto inputBox 
            InputBox inputBox = new InputBox("Digite o endereço completo do editor", editorTxt);
            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                // Substitui o valor da configuração 
                Configuracao.AtualizaArquivoConfig("editorTxt", inputBox.InputText);
            }
        }

        private void editorDocMenuItem_Click(object sender, EventArgs e)
        {
            // Busca a Configuracao do editor Word
            string editorDoc = Configuracao.GetValor("editorDoc");

            // cria um objeto inputBox 
            InputBox inputBox = new InputBox("Digite o endereço completo do editor DOC", editorDoc);
            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                // Substitui o valor da configuração 
                Configuracao.AtualizaArquivoConfig("editorDoc", inputBox.InputText);
            }
        }
        private void editorXlsMenuItem_Click(object sender, EventArgs e)
        {
            // Busca a Configuracao do editor Excell
            string editorXls = Configuracao.GetValor("editorXls");

            // cria um objeto inputBox 
            InputBox inputBox = new InputBox("Digite o endereço completo do editor XLS", editorXls);
            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                // Substitui o valor da configuração 
                Configuracao.AtualizaArquivoConfig("editorXls", inputBox.InputText);
            }
        }

        private void visualizaPDFMenuItem_Click(object sender, EventArgs e)
        {
            // Busca a Configuracao do visualizador PDF
            string visualPDF = Configuracao.GetValor("visualPDF");

            // cria um objeto inputBox 
            InputBox inputBox = new InputBox("Digite o endereço completo do visualizador PDF", visualPDF);
            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                // Substitui o valor da configuração 
                Configuracao.AtualizaArquivoConfig("visualPDF", inputBox.InputText);
            }
        }

        private void visualizaImagemMenuItem_Click(object sender, EventArgs e)
        {
            // Busca a Configuracao do visualizador Imagem
            string visualImagem = Configuracao.GetValor("visualImagem");

            // cria um objeto inputBox 
            InputBox inputBox = new InputBox("Digite o endereço completo do visualizador Imagens", visualImagem);
            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                // Substitui o valor da configuração 
                Configuracao.AtualizaArquivoConfig("visualImagem", inputBox.InputText);
            }
        }






    }  // classe
}   // namespace

