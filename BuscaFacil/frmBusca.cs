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


//using static System.Net.WebRequestMethods;



namespace BuscaFacil
{

    //=============================================================================
    //  Açoes dos Objetos do Forms
    //=============================================================================
    public partial class FrmBusca : Form
    {
        // Define os objetos imagens
        Image imgLupa;
        Image imgDesfazer;

        // Criando uma pilha de arrays de strings para armazenar os
        //  caminhos das pastas que foram buscadas
        Stack<string> pilhaPastas = new Stack<string>();

        // Inicializacao do formulario Principal
        public void FrmPrincipal_Initialize()
        {
            lbl_arquivos_filtrados.Visible = false;
            lbl_arquivos.Visible = true;

            string data_null = null;
            DateTime dataConvertida;
            if (DateTime.TryParse(data_null, out dataConvertida))
            {
                dtm_criacao.Value = dataConvertida;
            }
            dtm_criacao.Text = data_null;

            try
            {
                // Carrega imagens para os botões
                this.imgLupa = Image.FromFile("./loupe.png");
                this.imgDesfazer = Image.FromFile("desfazer.png");
            }
            catch (Exception e)
            {
                MessageBox.Show("Problema na carga da imagem " + e.Message);
                Environment.Exit(1);
            }

            // Redimensionar as imagens e atribui-las aos botões

            Image resizedImage = ResizeImage(imgDesfazer, (int)(btnDesfazer.Width * 0.5), (int)(btnDesfazer.Height * 0.5));
            btnDesfazer.Image = resizedImage;
            btnDesfazer.Text = "";
        }

        private void TxtEscolheDir_Leave(object sender, EventArgs e)
        {
            if ((TxtEscolheDir.Text != "") && (TxtEscolheDir.Text != "Pasta Base de Busca"))
            {
                BuscaTudo();
            }
        }

        private void FrmPrincipal_Shown(object sender, EventArgs e)
        {
            FrmPrincipal_Initialize();
        }

        private void BtnBusca_Click(object sender, EventArgs e)
        {
            BuscaTudo();
        }

        private void BtnFecha_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnFolderBrowser_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string pastaBuscaSelecionada = dialog.SelectedPath;

                    // quando insere um valor no txtEscolheDir verifica se esta vazio , se nao estiver
                    // coloca o valor na pilha e habilita o botao de retorno
                    if (TxtEscolheDir.Text != "")
                    {
                        pilhaPastas.Push(TxtEscolheDir.Text);
                        btnDesfazer.Enabled = true;
                    }

                    TxtEscolheDir.Text = pastaBuscaSelecionada;
                }
            }
            BuscaTudo();
        }



        public FrmBusca()
        {
            InitializeComponent();
        }

        //=============================================================================
        //  Metodos Principais
        //=============================================================================


        //-----------------------------------------------------------------------------
        // Busca das pastas e arquivos solicitadas
        //-----------------------------------------------------------------------------

        public const string PASTA_BUSCA_DEFAULT = "Pasta Base de Busca";

        // Metodo principal para a Busca de arquivos e pastas solicitadas a partir da pasta base
        private void BuscaTudo()
        {
            // Limpa caixa de textos de saidas dos arquivos e pastas
            lsbMostraDir.Items.Clear();
            lsbMostraArquivos.Items.Clear();

            string[] retBuscaPastas = new string[0];    // array de retorno vazio

            // se caixa de texto da pasta esta vazio aborta
            string pastaBusca = TxtEscolheDir.Text;
            if ((pastaBusca == "") || (pastaBusca == PASTA_BUSCA_DEFAULT))
            {
                frmMsgTemp.ShowTimedMessageBox("Insira um diretorio válido!", "Mensagem", 1);
                //MessageBoxWithTimer.Show("Insira um diretorio válido!",200000 );
                TxtEscolheDir.Focus();
                return;
            }

            // Aborta tambem se pasta nao exisir
            if (!Directory.Exists(pastaBusca))
            {
                //Lixo.Show("Diretório Não Existe!", "Alerta", 1000);
                TxtEscolheDir.Focus();
                return;
            }

            // Apresenta na caixa de textos as pastas da pasta base
            //string[] retBuscaPastas = BuscaPastas(pastaBusca);    // so uma busca

            int prof = (int)numProf.Value;
            BuscaPastasEmUmaPastaRecur(pastaBusca, ref retBuscaPastas, prof); // so uma busca

            if ((retBuscaPastas.Length != 0) && (retBuscaPastas != null))
            {
                foreach (string dir in retBuscaPastas)
                {
                    lsbMostraDir.Items.Add("D> " + dir);
                }
            }
            else
            {
                MessageBox.Show("Nao ha pastas na pasta base");
            }


            // Faz a busca dos arquivos na primeira pasta
            string[] retBuscaArquivos = BuscaArquivos(pastaBusca);

            if ((retBuscaArquivos.Length != 0) && (retBuscaArquivos != null))
            {
                foreach (string dir in retBuscaArquivos)
                {
                    lsbMostraArquivos.Items.Add("A> " + dir);
                }
            }
            else
            {
                MessageBox.Show("Nao ha arquivos na pasta base");
            }
        }


        // Realiza a Busca de todas as pastas em uma pasta especifica de forma recursiva
        // param string pasta        -> pasta onde a busca deve ser feita
        //       string [] retPastas -> array de strings com a somatoria das pastas encontradas
        //       int prof            -> numero de niveis de pastas 
        //       
        // retorno array de string com as pastas 
        private string[] BuscaPastasEmUmaPastaRecur(string pasta, ref string[] retPastas, int prof)
        {
            string[] provBuscaPastas;
            bool retOK = false;

            provBuscaPastas = BuscaPastas(pasta, ref retOK);
            if (retOK)
            {
                retPastas = ConcatArraysStrings(retPastas, provBuscaPastas);

                if (prof > 1)
                {
                    foreach (string arq in provBuscaPastas)   // busca nesse nivel todas as pastas
                    {
                        BuscaPastasEmUmaPastaRecur(arq, ref retPastas, prof - 1); //Chama recursivamente 
                    }
                }
                return retPastas;
            }
            return retPastas;
        }

        // Concatena dois arrays de strings e devolve um terceiro 
        private string[] ConcatArraysStrings(string[] array1, string[] array2)
        {

            string[] resultado = new string[array1.Length + array2.Length];
            Array.Copy(array1, resultado, array1.Length);
            Array.Copy(array2, 0, resultado, array1.Length, array2.Length);

            return resultado;

        }



        // Realiza uma busca das pastas que estao em uma pasta base
        // Parametro um string com multiplas linhas
        //           bool retOK  - false se nao conseguiu acessar a pasta
        // Retorno : Array de strings com os diretorios 
        //
        private string[] BuscaPastas(string pastaBase, ref bool buscaOK)
        {
            try
            {
                string[] diretorios = Directory.GetDirectories(pastaBase);
                buscaOK = true;
                return diretorios;

            }
            catch (Exception)
            {
                string erro = "Problema no acesso ao " + pastaBase;
                string[] arrErro = new string[] { erro };
                buscaOK = false;
                return arrErro;
            }
        }


        // Obtém todos arquivos dentro da pastaBusca filtrando por  padrao e
        // de data de ata  de criacao e alteracao 
        // Param   -> string pastaBusca
        // Retorno -> array de strings com os arquivos
        private string[] BuscaArquivos(string pastaBusca)
        {
            string[] arrArquivos;

            try
            {
                if ((txtFiltro.Text == "") || (txtFiltro.Text == "Filto Nome Arquivo"))
                {
                    lbl_arquivos_filtrados.Visible = false;
                    lbl_arquivos.Visible = true;
                    arrArquivos = Directory.GetFiles(pastaBusca, "*", SearchOption.TopDirectoryOnly);
                }
                else
                {
                    arrArquivos = Directory.GetFiles(pastaBusca, txtFiltro.Text, SearchOption.TopDirectoryOnly);
                    lbl_arquivos_filtrados.Visible = true;
                    lbl_arquivos.Visible = false;
                }
            }
            catch (Exception)
            {
                string erro = "Problema";
                string[] arrErro = new string[] { erro };
                return arrErro;
            }

            // converte a matriz em lista de entrada e cria uma lista de saida
            List<string> lstArquivosSaida = new List<string>();

            // filtra pela data de criaçao e de acesso, criando uma lista de saida e
            //    transformando para array depois
            lstArquivosSaida = FiltraData(arrArquivos);

            // retorna array de strings
            return lstArquivosSaida.ToArray();
        }

        // Funcao que recebe uma lista de arquivos e retorna uma lista depois de fazer os filtros de datas
        // de criacao e de atualizacao
        // Parametro : array de strings com a lista a ser analisada
        // Retorno   : lista filtrada
        private List<string> FiltraData(string[] listaEntrada)
        {
            List<string> listaSaida = new List<string>();

            // Nenhum filtro ativo, simplesmente copia a lista inteira
            if ((chkCriacao.Checked == false) && (chkAcesso.Checked == false))
            {
                //listaSaida = listaEntrada.GetRange(0, listaEntrada.Count);
                listaSaida = Util.ConverteArrayAList(listaEntrada);

            } // somente a data de criacao 
            else if ((chkCriacao.Checked == true) && (chkAcesso.Checked == false))
            {
                foreach (string arquivo in listaEntrada)
                {
                    DateTime data_criacao = Directory.GetCreationTime(arquivo);

                    // Data criacao maior que o limite escolhido subtrai da lista
                    if (DateTime.Compare(data_criacao, Convert.ToDateTime(dtm_criacao.Text)) >= 0)
                    {
                        listaSaida.Add(arquivo);
                    }
                }
            } // somente a data de acesso
            else if ((chkCriacao.Checked == false) && (chkAcesso.Checked == true))
            {
                foreach (string arquivo in listaEntrada)
                {
                    DateTime data_acesso = Directory.GetLastWriteTime(arquivo);

                    // Data criacao menor que o limite escolhido subtrai da lista
                    if (DateTime.Compare(data_acesso, Convert.ToDateTime(dtm_acesso.Text)) >= 0)
                    {
                        listaSaida.Add(arquivo);
                    }
                }

            } // Ambos filtros ativos
            else
            {
                foreach (string arquivo in listaEntrada)
                {
                    DateTime data_acesso = Directory.GetLastWriteTime(arquivo);
                    DateTime data_criacao = Directory.GetCreationTime(arquivo);

                    // Data criacao menor que o limite escolhido subtrai da lista
                    if ((DateTime.Compare(data_acesso, Convert.ToDateTime(dtm_acesso.Text)) >= 0) &&
                        (DateTime.Compare(data_criacao, Convert.ToDateTime(dtm_criacao.Text)) >= 0))
                    {
                        listaSaida.Add(arquivo);
                    }
                }
            }

            return listaSaida;
        }

        //-----------------------------------------------------------------------------
        // Busca dos Arquivos com conteudo 
        //-----------------------------------------------------------------------------


        // Cria uma lista global onde serao armazenados os arquivos que tem o texto 
        List<string> lstFinalArqComTexto = new List<string>();

        // procura na profundidade escolhida a palavra definida no textBox dentro dos araquivos
        // Se a profundidade é Zero significa que nao ha limite na busca
        private void BtnBuscaTexto_Click(object sender, EventArgs e)
        {
            List<string> lstArqFiltroTexto = new List<string>();   // lista com os arquivos filtrados pelo texto 
            List<string> lstDinamicaPastasBusca = new List<string>();   // lista que vai receber as pastas onde devem ser feitas as buscas
            List<string> lstDinamicaArqBusca = new List<string>();   // lista que vai receber os arquivos onde devem ser feitas as buscas

            // Consegue a profundidade de Busca onde prof = 1 eh busca na pasta base e 0 eh busca sem limite
            int prof = (int)numProf.Value;


            lstFinalArqComTexto.Clear();    // apaga a lista

            // Se Texto a ser buscado eh nulo
            string buscaTexto = txb_textoBusca.Text;
            if (buscaTexto == "")
            {
                //Lixo.Show($"Não há Texto a ser procurado. Digite um texto !", "Alerta", 2000);
                return;
            }

            // Primeiras strings para pesquisa sao as da caixa de texto


            string pastaBusca = TxtEscolheDir.Text;


            FiltraTextoRecursivo(Util.ConverteStringAArray(pastaBusca), buscaTexto, prof);

            // Carrega no formulario de Resultados o produto final de todos os filtros
            frmResultados fr = new frmResultados();

            fr.Text = "Arquivos com o Texto Solicitado";
            fr.RtbResultado.Clear();
            fr.RtbResultado.Lines = lstFinalArqComTexto.ToArray();
            fr.ShowDialog();
            fr.Close();
        }


        // Faz uma busca recursiva a partir de um array de pastas em pastas arrPastas
        //  pelo texto buscaTexto com a profundidade prof
        //  profundidade é a quantidade de pastas que a busca deve ter 
        //  
        // Parametros string [] arrPastas   -> array de pastas onde a busca deve ser feita
        //            string buscaTexto     -> texto a ser buscado 
        //            int prof              -> profundidade
        //
        // Retorno eh feito na lista global lstFinalArqComTexto
        // todo : tirar a dependencia da lista global 
        private void FiltraTextoRecursivo(string[] arrPastas, string buscaTexto, int prof)
        {
            bool retOK = false;
            foreach (string stg in arrPastas)
            {
                MessageBox.Show("arrPastas:" + stg);
                //Console.WriteLine("arrPastas:" + stg);
            }
            MessageBox.Show("buscaTexto:" + buscaTexto);
            MessageBox.Show("prof:" + prof);    
            //Console.WriteLine("buscaTexto:" + buscaTexto);
            //Console.WriteLine("prof:" + prof);

            List<string> lstArqFiltradoTexto = new List<string>();   // lista com os arquivos filtrados pelo texto 
            List<string> lstDinamicaArqBusca = new List<string>();


            // faz uma busca nas pastas dentro do array de pastas
            // a primeira chamada o array so tem uma pasta
            foreach (string pasta in arrPastas)
            {
                //Console.WriteLine("pasta: " + pasta);
                MessageBox.Show("pasta: " + pasta);

                // Buscar dentro de cada pasta
                string[] retBuscaArquivos = BuscaArquivos(pasta);
                string[] arrArq = retBuscaArquivos;

                lstArqFiltradoTexto = FiltraTexto(arrArq, buscaTexto, pasta);

                // se a profundidade é maior que 1 segue para o proximo nivel
                if (prof > 1)

                {
                    // Coleta as pastas que estao disponiveis na pasta de entrada
                    string[] retBuscaPastas = BuscaPastas(pasta, ref retOK);
                    if (retOK)
                    {
                        string[] arrNovasPastas = retBuscaPastas;

                        // chama recursivamente o mesmo metodo diminuindo a profundidade
                        FiltraTextoRecursivo(arrNovasPastas, buscaTexto, prof - 1);
                    }
                }

                // adiciona cada string da lista lstArqFiltroTexto a lista lstFinalArqComTexto
                foreach (string arq in lstArqFiltradoTexto)
                {
                    lstFinalArqComTexto.Add(arq);
                }
            }
        }



        // Filtra lista de strings arqParaPesquisa todos arquivos de texto
        // que  contenham a palavra textoBuscado
        // Parametros :
        // array com strings de arquivos a serem analisados
        // String com texto a ser buscado
        // Retorno:
        // Lista com arquivos que satisfazem a busca  

        private List<string> FiltraTexto(string[] arqParaPesquisa, string textoBuscado, string pasta)
        {
            List<string> listaArquivosEncontrados = new List<string>();

            if ((arqParaPesquisa.Length != 0) && (arqParaPesquisa[0] == "Problema"))
            {
                string erroMensagem = "Nao pode acessar a pasta " + pasta;
                listaArquivosEncontrados.Add(erroMensagem);
                return listaArquivosEncontrados;
            }






            //string[] arrayDeStrings = arqParaPesquisa.Split('\n'); // cria um array com o string dividido 

            foreach (string arquivo in arqParaPesquisa)
            {

                // MsgTemp.Show("Analisando" + arquivo, "Alerta", 3000);
                string novaString = arquivo.TrimEnd();
                string extensao = Path.GetExtension(novaString);

                // Arquivos com extensões como .txt, .csv, .xml e .json são geralmente arquivos de texto.
                if (extensao == ".txt" || extensao == ".csv" || extensao == ".xml" || extensao == ".json"
                    || extensao == ".cs" || extensao == ".cpp" || extensao == ".c")
                {
                    try
                    {
                        string conteudoArquivo = System.IO.File.ReadAllText(arquivo);
                        if (conteudoArquivo.Contains(textoBuscado))
                        {
                            //MsgTemp.Show($"Arquivo {conteudoArquivo} tem texto: {textoBuscado} ", "Alerta", 2000);
                            listaArquivosEncontrados.Add(arquivo);
                        }
                    }
                    catch (Exception)
                    {
                        //MessageBoxWithTimer.Show("Esta é uma mensagem temporária!", 5); // 5 segundos
                        //Lixo.Show($"Arquivo com nome invalido {arquivo}", "Alerta", 1000);
                    }
                }
            }

            return listaArquivosEncontrados;
        }



        //=============================================================================
        //  Utilitarios
        //=============================================================================

        // Função que converte uma string com várias linhas em uma lista
        private List<string> ConverteStringAList(string input)
        {
            // Divide a string em linhas usando o caractere de nova linha
            string[] arrLines = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            // Converte o array em uma lista
            List<string> linesList = new List<string>(arrLines);

            return linesList; // Retorna a lista
        }

        // Função que converte uma string com várias linhas em um array



        // Função para redimensionar a imagem
        private Image ResizeImage(Image img, int maxWidth, int maxHeight)
        {
            // Calcula a proporção para manter o aspecto da imagem
            float ratioX = (float)maxWidth / img.Width;
            float ratioY = (float)maxHeight / img.Height;
            float ratio = Math.Min(ratioX, ratioY); // Mantém a proporção

            int newWidth = (int)(img.Width * ratio);
            int newHeight = (int)(img.Height * ratio);

            // Cria um novo Bitmap redimensionado
            Bitmap resizedImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(img, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

        int inicioPasta = 3;

        // Acao a ser executada quando se clica no item da lista
        private void lsbMostraDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbMostraDir.SelectedItem != null)
            {
                string itemSelecionado = lsbMostraDir.SelectedItem.ToString();

                // quando insere um valor no txtEscolheDir verifica se esta vazio , se nao estiver
                // coloca o valor na pilha e habilita o botao de retorno
                if (TxtEscolheDir.Text != "")
                {
                    pilhaPastas.Push(TxtEscolheDir.Text);  // armzena na pilha
                    btnDesfazer.Enabled = true;
                }

                if (TxtEscolheDir.Text != "")
                {
                    pilhaPastas.Push(TxtEscolheDir.Text);  // armzena na pilha
                    btnDesfazer.Enabled = true;
                }

                string itemFiltrado = itemSelecionado.Substring(3);

                TxtEscolheDir.Text = itemFiltrado;   // Coloca o item selecionado no campo de de busca e inicia a busca
                                                        // Extrai do string da pasta base o caminho da pasta a partir do terceiro caracter
                BuscaTudo();

                // Aqui você pode adicionar outras manipulações
                // Exemplo: Modificar o item selecionado
                // listBox1.Items[listBox1.SelectedIndex] = "Novo Nome";
            }
        }

        // botao que retorna os diretorios buscados anteriormente 
        private void btnRetorno_Click(object sender, EventArgs e)
        {
            if (pilhaPastas.Count > 1)
            {
                // Pop: Removendo a string do topo da pilha
                string stringRemovida = pilhaPastas.Pop();

                TxtEscolheDir.Text = stringRemovida;   // Coloca o item selecionado no campo de de busca e inicia a busca
                BuscaTudo();

            }

        }

        private void lsbMostraArquivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbMostraArquivos.SelectedItem != null)
            {
                string itemSelecionado = lsbMostraArquivos.SelectedItem.ToString();


                string itemFiltrado = itemSelecionado.Substring(3);

               


                string urlNotepad = Configuracao.GetValor("urlNotepad");

                if (!System.IO.File.Exists(urlNotepad))
                {
                    MessageBox.Show("Editor não encontrado.");
                    return;
                }

                try
                {
                    Process.Start(urlNotepad, itemFiltrado);
                }
                catch (Exception ex)
                {
                    // Trate qualquer exceção que possa ocorrer (por exemplo, aplicativo não encontrado)
                    //Console.WriteLine($"Erro ao abrir o editor: {ex.Message}");
                    MessageBox.Show($"Erro ao abrir o editor: {ex.Message}");
                }

                // LPSTC

            }

        }

        private void grbBuscaArquivo_Enter(object sender, EventArgs e)
        {

        }

        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Busca a Configuracao do notepad
            string urlNotepad = Configuracao.GetValor("urlNotepad");

            // cria um objeto inputBox 
            InputBox inputBox = new InputBox("Digite o endereço completo do editor", urlNotepad);
            if (inputBox.ShowDialog() == DialogResult.OK)
            {
                // Substitui o valor da configuração 
                Configuracao.SubstituiConfiguracao("urlNotepad", inputBox.InputText);
            }
        }


        private void TxtEscolheDir_MouseDown(object sender, MouseEventArgs e)
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
                        if (TxtEscolheDir.Text != "")
                        {
                            pilhaPastas.Push(TxtEscolheDir.Text);
                            btnDesfazer.Enabled = true;
                        }

                        TxtEscolheDir.Text = pastaBuscaSelecionada;
                    }
                }
                BuscaTudo();
            }
            else if (e.Button == MouseButtons.Left)
            {
                //if ((TxtEscolheDir.Text != "") && (TxtEscolheDir.Text != PASTA_BUSCA_DEFAULT))
                //{
                    BuscaTudo();
                //}
            }
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmAjuda fb = new frmAjuda(); // Substitua Form2 pelo nome do seu novo formulário
            fb.Show(); // Para mostrar o formulário

        }
    } // partial Class FrmPrincipal
}












/*
 * 
 Programa do IA para checar conteudo docx
 * 
 using System;
using System.IO;
using Xceed.Words.NET;

class Program
{
 static void Main(string[] args)
 {
     // Caminho do arquivo .docx
     string caminho = "caminho/para/seu/arquivo.docx";
     string searchTerm = "termo a ser procurado";

     try
     {
         // Verifica se o arquivo existe
         if (!File.Exists(caminho))
         {
             Console.WriteLine("Arquivo não encontrado.");
             return;
         }

         // Carrega o documento
         using (DocX document = DocX.Load(caminho))
         {
             // Procura pelo termo
             if (document.Text.Contains(searchTerm))
             {
                 Console.WriteLine($"O termo '{searchTerm}' foi encontrado no documento.");
             }
             else
             {
                 Console.WriteLine($"O termo '{searchTerm}' não foi encontrado no documento.");
             }
         }
     }
     catch (Exception ex)
     {
         Console.WriteLine($"Ocorreu um erro: {ex.Message}");
     }
 }
}
 * 
 */