using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;



//== BuscaUtil.cs ==========================================================================
//  Classe que executa as tarefas referentes as buscas 
//  
//  ResizeImage   -> Metodo para alterar o tamanho das imagens 
//  BuscaRecursiva ->  Realiza a Busca de todas as pastas em uma pasta especifica de forma recursiva
//  BuscaPastas   ->  Realiza uma busca das pastas que estao em uma pasta base (usado pelo metodo acima)
//  ConcatArraysStrings -> Concatena dois arrays de strings e devolve um terceiro 
//  FiltraPelasDatas -> Filtra a lista de arquivos de acordo com a data escolhida
//  FiltraPeloNome -> Filtra lista de strings arqParaPesquisa todos arquivos de texto
// 
//==========================================================================================


namespace BuscaFacil
{
    public class BuscaUtil
    {
        public const string PASTA_BUSCA_DEFAULT = "Pasta Base de Busca";
        public const string PASTA_FILTRO_NOME = "Filtro Nome Arquivo";
        public const string PASTA_FILTRO_CONTEUDO = "Texto a ser Buscado";

        static DateTime novecentos = new DateTime(1900, 1, 1);

        private static FrmBusca _form;

        // Construtor que recebe a referência para acessar a outra classe
        public BuscaUtil(FrmBusca form)
        {
            _form = form;
        }


        //=========================================================================================
        // Realiza uma busca das pastas e arquivos que estao em uma pasta base e imprime na ordem 
        // Parametro string pastabase - um string com multiplas linhas
        //           prof           - profundidade da busca-> profundidade de busca
        // Retorno : true se nao houve problemas
        //
        //=========================================================================================
        public static void BuscaTudoEmUmaPasta(string pastaBase, int prof)
        {

            // Mostrar os arquivos da pastaBase Inicial
            MostraArquivos(pastaBase);

            buscaRecursiva(pastaBase, prof);

        }

        // Faz uma busca de pastas na pastaBase, filtra 
        public static void buscaRecursiva(string pastaBase, int prof)
        {
            List<string> listaPastasFiltradas = new List<string>();
            List<string> ListaArquivosFiltrados = new List<string>();
            List<string> ListaTodasPastas = new List<string>();


            List<string> listaStringPastas = BuscaPastasEmUmaPasta(pastaBase);

            // Filtra as pastas se a lista de diretorios nao esta vazia
            FiltraPasta(listaStringPastas, pastaBase, ref listaPastasFiltradas);

            if (listaPastasFiltradas.Count > 0)
            {
                // Para cada pasta na lista de pastas
                foreach (string pasta in listaPastasFiltradas)
                {
                    _form.lsbMostraDir.Items.Add("D> " + pasta);
                    Console.WriteLine("D> " + pasta);
                }
            }

            if (listaStringPastas.Count > 0)
            {
                // Para cada pasta na lista de pastas
                foreach (string pasta in listaStringPastas)
                {
                    // Se profundidade de busca é maior que 1
                    if (prof > 1)
                    {
                        MostraArquivos(pasta);
                        buscaRecursiva(pasta, prof - 1);
                    }
                }
            }

        }








        //=========================================================================================
        // Metodo que recebe uma pastaBase . Pega os arquivos dela , filtra e envia para painel  
        // retorna true se tudo ocorreu bem 
        //=========================================================================================
        public static void MostraArquivos(string pastaBase)
        {
            List<string> ListaArquivosFiltrados = new List<string>();

            // todo: testar se é possivel usar so uma lista e iterar sobre ela


            // Pega todos os arquivos que estao na pastaBase que atendem as datas
            List<string> listaArquivosProv1 = new List<string>();
            listaArquivosProv1 = FiltraArquivosPelasDatas(pastaBase);

            // Filtrar pelo nome
            List<string> listaArquivosProv2 = new List<string>();
            listaArquivosProv2 = FiltraPeloNome(pastaBase, listaArquivosProv1);


            // Filtra por conteudo  a partir de listaArquivosProv2 para ListaArquivosFiltrados
            ListaArquivosFiltrados = FiltraArquivosPorConteudo(pastaBase, listaArquivosProv2);

            EnviaTela(ListaArquivosFiltrados, "A> ");
        }



        //=========================================================================================
        // Filtra todos os arquivos da pastaBase que estao dentro do intervalo de datas
        //=========================================================================================
        private static List<string> FiltraArquivosPelasDatas(string pastaBase)
        {
            // verifica se as datas estao no valor default, escrevendo nos flags o resultado (true se a data nao foi alterada ) 
            bool boolAcesso = (DateTime.Compare(novecentos, Convert.ToDateTime(_dataCriacaoMinima)) == 0);
            bool boolCriacao = (DateTime.Compare(novecentos, Convert.ToDateTime(_dataAcessoMinima)) == 0);

            List<string> listaArquivosFiltrados = new List<string>();

            if ((!boolAcesso) || (!boolCriacao))
            {
                try
                {
                    listaArquivosFiltrados = Directory.GetFiles(pastaBase).Where(arquivo =>
                    {
                        FileInfo info = new FileInfo(arquivo);
                        return info.CreationTime >= DateTime.Parse(_dataCriacaoMinima) || info.LastWriteTime >= DateTime.Parse(_dataCriacaoMinima);
                    }).ToList();
                }
                catch (Exception)
                {
                    _form.SetAviso($"Problema na Busca das arquivos em pasta");
                }


            }
            else
            {
                try
                {
                    listaArquivosFiltrados = Directory.GetFiles(pastaBase, "*").ToList();
                }
                catch (Exception)
                {
                    _form.SetAviso($"Problema na Busca das arquivos em pasta");
                }
            }
            return (listaArquivosFiltrados);
        }


        //=========================================================================================
        // filtra pelo nome do arquivo a partir de listaASerFiltrada
        // retorna lista filtrada
        //=========================================================================================
        private static List<string> FiltraPeloNome(string pastaBase, List<string> listaASerFiltrada)
        {
            List<string> listaFiltrada = new List<string>();   // lista de retorno

            try
            {
                if ((_filtroNome != "") && (_filtroNome != PASTA_FILTRO_NOME))
                {
                    foreach (string arq in listaASerFiltrada)
                    {
                        string arqSoNome = RetiraPastaBase(arq, pastaBase);

                        if (arqSoNome.Contains(_filtroNome))
                        {
                            listaFiltrada.Add(arq);    // adiciona esse arquivo
                        }
                    }
                }
                else  // copia todo o array para a lista
                {
                    listaFiltrada.AddRange(listaASerFiltrada);
                }
            }
            catch (Exception)
            {
                _form.SetAviso($"Problema na Busca das arquivos em pasta");
            }
            return (listaFiltrada);
        }



        //=========================================================================================
        // Filtra Lista de Arquivos por conteudo , volta lista filtrada
        //=========================================================================================
        private static List<string> FiltraArquivosPorConteudo(string pastaBase, List<string> listaASerFiltrada)
        {
            List<string> listaArquivosFiltrados = new List<string>();

            // Filtra por conteudo  a partir de listaArquivosProv2 para ListaArquivosFiltrados
            if ((_filtroConteudo != null) && (_filtroConteudo != PASTA_FILTRO_CONTEUDO))
            {
                // faz uma busca nas pastas dentro da lista de pastas da busca atual 
                foreach (string arq in listaASerFiltrada)
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(arq))
                        {
                            string linha;
                            bool encontrado = false;

                            while ((linha = sr.ReadLine()) != null)
                            {
                                if (linha.IndexOf(_filtroConteudo, StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    encontrado = true;
                                    break;
                                }
                            }

                            if (encontrado)
                            {
                                listaArquivosFiltrados.Add(arq);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        _form.SetAviso($"Problema na Filtro de conteudo de arquivos na {pastaBase}");
                    }
                }
            }
            else
            {
                listaArquivosFiltrados.AddRange(listaASerFiltrada);
            }
            return (listaArquivosFiltrados);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Pastas   LPSTC
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //=========================================================================================
        // Busca uma lista de pastas em uma pasta base
        //
        //=========================================================================================
        public static List<string> BuscaPastasEmUmaPasta(string pastaBase)
        {
            List<string> ListaTodasPastas = new List<string>();

            try
            {
                ListaTodasPastas.AddRange(Directory.GetDirectories(pastaBase)); // cria uma lista com todos as pastas da pastaBase
            }
            catch (Exception)
            {
                _form.SetAviso($"Problema na Busca das pastas na {pastaBase}");
            }

            return (ListaTodasPastas);
        }



        //=========================================================================================
        // Filtra todos as pastas da pastaBase que estao dentro do intervalo de datas
        //=========================================================================================
        private static List<string> FiltraPastasPelasDatas(List<string> listaPastas)
        {
            // verifica se as datas estao no valor default, escrevendo nos flags o resultado (true se a data nao foi alterada ) 
            bool boolPosteriorCriacao = (DateTime.Compare(DateTime.Parse(_dataCriacaoMinima), Convert.ToDateTime(_dataCriacaoMinima)) >= 0);
            bool boolPosteriorAtualizacao = (DateTime.Compare(DateTime.Parse(_dataAcessoMinima), Convert.ToDateTime(_dataAcessoMinima)) >= 0);

            List<string> listaPastasFiltradas = new List<string>();

            // Se precisa filtrar por data de acesso ou de criacao
            if ((listaPastas.Count != 0) && (!boolPosteriorCriacao || !boolPosteriorAtualizacao))
            {
                foreach (string pasta in listaPastas)
                {
                    try
                    {
                        DirectoryInfo diretorioInfo = new DirectoryInfo(pasta);
                        DateTime dataDeCriacao = diretorioInfo.CreationTime;
                        DateTime dataDeAtualizacao = diretorioInfo.LastWriteTime;
                    }
                    catch (Exception)
                    {
                        _form.SetAviso($"Problema no filtro das pastas");
                    }

                    listaPastasFiltradas.Add(pasta);

                }
            }
            else
            {
                listaPastasFiltradas = listaPastas.ToList();
            }


            return (listaPastasFiltradas);
        }


        //=========================================================================================
        // Realiza a Busca de todas as pastas em uma lista de pastas listaDePastas
        //   e retorna  listaPastasFiltradas filtradas por todas as consiçoes
        //   Importante entender que o filtro nao deve ser feito com o nome completo 
        //     deve ser retirado a parte da pasta base antes do filtro 
        // param    listaDePastas           -> lista de entrada 
        //          listaPastasFiltradas    -> lista filtrada  
        //=========================================================================================
        public static void FiltraPasta(List<string> listaDePastas, string pastaBase, ref List<string> listaPastasFiltradas)
        {
            listaPastasFiltradas.Clear();

            // Listas provisorias para filtrar as pastas
            List<string> ListaProv = new List<string>();

            // Se tem teste de conteudo retorna uma lista vazia porque diretorios nao tem conteudo
            if ((_filtroConteudo != "") && (_filtroConteudo != PASTA_FILTRO_CONTEUDO))
            {
                // Copiando os elementos da listaOriginal para listaCopia
                //listaPastasFiltradas.AddRange(listaDePastas);
                return;
            }

            // Se nao tem filtro de conteudo e a lista de pastas nao esta vazia
            //   filtra os diretorios por nome e por data de acesso e criacao 
            if (listaDePastas.Count != 0)
            {
                //// se o campo nao é vazio ou default filtra pelo nome, passando para ListaProv
                //// todos os strings que passam pelo filtro
                ListaProv = FiltraPeloNome(pastaBase, listaDePastas);

                listaPastasFiltradas = FiltraPastasPelasDatas(ListaProv);
            }
        }


        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //  Metodos auxiliares
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //=========================================================================================
        // Envia lista de strings para tela com um prefixo
        //=========================================================================================
        private static void EnviaTela(List<string> listaTela, string prefixo)
        {

            // mostra os arquivos filtrados
            foreach (string stg in listaTela)
            {
                _form.lsbMostraDir.Items.Add(prefixo + stg);
                Console.WriteLine(prefixo + stg);
            }

        }

        //=========================================================================================
        // Metodo  que retira a pasta Base do nome da pasta que esta sendo filtrada
        //=========================================================================================
        public static string RetiraPastaBase(string stringOriginal, string stringPrefixo)
        {

            //int numInicioFiltro = stringPrefixo.Length + 1;
            int numInicioFiltro = stringPrefixo.Length ;
            int tamStringFinal = stringOriginal.Length - numInicioFiltro;
            string pastaSoNome = stringOriginal.Substring(numInicioFiltro, tamStringFinal);
            return (pastaSoNome);
        }

        //=========================================================================================
        // Propiedades estaticas com get privado e set público
        //=========================================================================================
        private static string _dataAcessoMinima;
        public static string dataAcessoMinima
        {
            private get { return _dataAcessoMinima; }
            set { _dataAcessoMinima = value; }
        }

        private static string _dataCriacaoMinima;
        public static string dataCriacaoMinima
        {
            private get { return _dataCriacaoMinima; }
            set { _dataCriacaoMinima = value; }
        }

        private static string _filtroNome;
        public static string filtroNome
        {
            private get { return _filtroNome; }
            set { _filtroNome = value; }
        }

        private static string _pastaBusca;
        public static string pastaBusca
        {
            private get { return _pastaBusca; }
            set { _pastaBusca = value; }
        }

        private static string _filtroConteudo;
        public static string filtroConteudo
        {
            private get { return _filtroConteudo; }
            set { _filtroConteudo = value; }
        }

        private static int _prof;
        public static int prof
        {
            private get { return _prof; }
            set { _prof = value; }
        }

        //=========================================================================================
        // Função para redimensionar a imagem
        //=========================================================================================
        public static Image ResizeImage(Image img, int maxWidth, int maxHeight)
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


        //=========================================================================================
        // Concatena dois arrays de strings e devolve um terceiro 
        //=========================================================================================
        public static string[] ConcatArraysStrings(string[] array1, string[] array2)
        {

            string[] resultado = new string[array1.Length + array2.Length];
            Array.Copy(array1, resultado, array1.Length);
            Array.Copy(array2, 0, resultado, array1.Length, array2.Length);

            return resultado;
        }








    }  // public class BuscaUtil

} // namespace BuscaFacil



    