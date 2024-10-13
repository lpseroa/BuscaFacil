using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace BuscaFacil
{
    namespace BuscaFacil
    {
        public class Configuracao
        {
            public Configuracao() { }                           // construtur padrao da classe
            private const string caminhoArqConfig = "centopeia.cfg";     // Caminho do arquivo de configuração

            // dicionario que guarda todos as configurações lidas 
            private static Dictionary<string, string> configValues = new Dictionary<string, string>();


            // 
            public static int SalvaDado(string nome, string valor)
            {
                string total = nome + "=" + valor;
                EscreveNoArquivo(total);
                MessageBox.Show("Configuração salva com sucesso!");
                return 0;
            }

            // Se o arquivo de configuracao existe, se ja existe adiciona o conteudo
            //  caso nao exista cria o arquivo com o conteudo solicitado 
            // caso exista acrescenta conteudo ao mesmo 
            static void EscreveNoArquivo(string conteudo)
            {
                // Verifica se o arquivo já existe
                if (!File.Exists(caminhoArqConfig))
                {
                    // Cria o arquivo e escreve o conteúdo
                    using (StreamWriter writer = File.CreateText(caminhoArqConfig))
                    {
                        MessageBox.Show("Arquivo de configuracao nao existe, criando " + conteudo); 
                        writer.WriteLine(conteudo);
                    }
                }
                else
                {
                    // Se o arquivo já existir, adiciona o conteúdo
                    using (StreamWriter writer = File.AppendText(caminhoArqConfig))
                    {
                        MessageBox.Show("Arquivo de configuracao existe, acrescentando " + conteudo);
                        writer.WriteLine(conteudo);
                    }
                }

                Configuracao.LeConfiguracao();
            }

            public static string GetUrl()
            {
                return caminhoArqConfig;
            }

            //
            //
            public static void SubstituiConfiguracao(string nomeConfig, string novaConfig)
            {
                string configTotal = nomeConfig + "=" + novaConfig;

                // Verifica se o arquivo existe
                if (!File.Exists(caminhoArqConfig))
                {
                    MessageBox.Show("Arquivo {caminhoArqConfig} não encontrado.");
                    EscreveNoArquivo(configTotal);
                    return;
                }

                // Lê todas as linhas do arquivo
                List<string> linhas = new List<string>(); // Usando List para armazenar as linhas
                linhas.AddRange(File.ReadAllLines(caminhoArqConfig));

                // Verifica se a lista está vazia
                if (linhas == null || linhas.Count == 0)
                {
                    MessageBox.Show("O arquivo {caminhoArqConfig} esta vazio.");
                    return;
                }

                bool flgExiste = false;
                // Substitui a linha que contém a string especificada
                for (int i = 0; i < linhas.Count; i++)
                {
                    if (linhas[i].Contains(nomeConfig))
                    {
                        flgExiste = true;
                        linhas[i] = configTotal; // Substitui a linha
                        break;
                    }
                    if (!flgExiste)
                    {
                        linhas.Add(configTotal);
                    }
                }

                string[] arrLista =  linhas.ToArray();


                Util.EscreveArquivoTexto(caminhoArqConfig, arrLista);

                Configuracao.LeConfiguracao();
            }


            // Pega um valor de configuração a partir de uma chave
            public static string GetValor(string chave)
            {
                LeConfiguracao();
                string valor = configValues.ContainsKey(chave) ? configValues[chave] : "";
                return valor;
            }



            // le todos as chaves de configuração do arquivo de configuração e
            // retorna 0 se a operação for concluida com exito 
            public static int LeConfiguracao()
            {
                string url = Configuracao.GetUrl();
                var resultado = Util.LerArquivoTexto(url);

                if (!resultado.sucesso)
                {
                    MessageBox.Show("Falha na leitura do arquivo {url}");
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
