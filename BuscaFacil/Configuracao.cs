using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

//==========================================================================================
//  Classe que executa as tarefas referentes a configuracao
//  Configuracao          -> Construtor Padrao
//  
//  AtualizaArquivoConfig -> Escreve algum conteudo no arquivo de configuracao e atualiza dicionario
//  GetCaminhoConfig      -> Retorna endereço do arquivo de configuracao
//  GetValor              -> Retorna um valor de configuração a partir de uma chave
//  LeConfiguracao        -> Le a configuração do arquivo de configuração e armnazena do no dicionario
// 
//==========================================================================================

namespace BuscaFacil
{
    namespace BuscaFacil
    {
        public class Configuracao
        {
            public Configuracao() { }                                   // construtur padrao da classe

            private const string caminhoArqConfig = "buscafacil.cfg";    // Arquivo de Configuracao

            // dicionario privado que guarda todos as configurações lidas 
            private static Dictionary<string, string> configValues = new Dictionary<string, string>();


            // Atualiza o  arquivo de configuraçao
            // Se o arquivo de configuracao,
            //   nao exista cria o arquivo com o conteudo solicitado 
            //   exista e a chave nao estiver sendo utilizada acrescenta conteudo ao mesmo 
            //   caso exista e a chave ja estiver armazenado troca o valor
            // Ao final faz a leitura da configuracao atualizando o dicionario
            public static void AtualizaArquivoConfig(string chave, string valor)
            {
                string chaveValor = chave + "=" + valor;


                // Se o arquivo nao existe cria e insere chaveValor

                if (!File.Exists(caminhoArqConfig))
                {
                    // Cria o arquivo e escreve o conteúdo
                    using (StreamWriter writer = File.CreateText(caminhoArqConfig))
                    {
                        //BuscaUtil.SetAviso ("Arquivo de configuracao nao existe, criando " + chaveValor);
                        writer.WriteLine(chaveValor);
                    }
                }
                else  // se arquivo existe
                {
                    // verifica se sera necessario substituir o valor da chave 

                    // Lê todas as linhas do arquivo
                    List<string> linhas = new List<string>(); // Usando List para armazenar as linhas
                    linhas.AddRange(File.ReadAllLines(caminhoArqConfig));


                    File.Delete(caminhoArqConfig);

                    // Verifica se a lista está vazia
                    if (linhas == null || linhas.Count == 0)
                    {
                       // MessageBox.Show("Erro: O arquivo {caminhoArqConfig} esta vazio.");
                        //BuscaUtil.SetAviso("Erro: O arquivo {caminhoArqConfig} esta vazio.");
                        return;
                    }

                    // Substitui a linha que contém a string especificada
                    for (int i = 0; i < linhas.Count; i++)
                    {
                        if (linhas[i].Contains(chave))
                        {
                            linhas[i] = chaveValor; // Substitui a linha
                            break;
                        } else { 
                            linhas.Add(chaveValor);
                        }
                    }

                    string[] arrLista = linhas.ToArray();

                    Util.EscreveArquivoTexto(caminhoArqConfig, arrLista);

                }

               // MessageBox.Show("Configuração salva com sucesso!");
                //BuscaUtil.SetAviso("Configuração salva com sucesso!");
                Configuracao.LeConfiguracao();
            }

 
            // Retorna endereço do arquivo de configuracao
            public static string GetCaminhoConfig()
            {
                return caminhoArqConfig;
            }

            // Retorna um valor de configuração a partir de uma chave
            public static string GetValor(string chave)
            {
                LeConfiguracao();
                string valor = configValues.ContainsKey(chave) ? configValues[chave] : "";
                return valor;
            }

            // Le todos as chaves e valor de configuração do arquivo de configuração 
            //  armazena no dicionario de configuracao 
            //  retorna 0 se a operação for concluida com exito 
            public static int LeConfiguracao()
            {
                string url = Configuracao.GetCaminhoConfig();
                var resultado = Util.LerArquivoTexto(url);

                if (!resultado.sucesso)
                {
                    //MessageBox.Show("Falha na leitura do arquivo {url}");
                    //BuscaUtil.SetAviso("Falha na leitura do arquivo {url}");
                }

                string[] lines = resultado.conteudo.ToArray();

                foreach (string line in lines)
                {
                    // Ignora linhas vazias ou linhas que começam com #
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                        continue;

                    string[] parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();
                        configValues[key] = value; // Adiciona ao dicionário
                    }
                }

                return 0;
            }
        }
    }
}
