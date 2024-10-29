using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Net.NetworkInformation;


// Classe Util vai conter todas as operacoes que sao de uso geral 
// nao especificas a uma tarefa

//  LerArquivoTexto
//  EscreveArquivoTexto
//  ConverteStringAArray
//  ConverteArrayAList

namespace BuscaFacil
{
    internal class Util
    {

        // Le conteudo de um arquivo retornando informação sobre se houve problemas
        // parametros : string caminhoArquivo -> endereço do carquivo a ser buscado 
        // retorno : tupla com:
        //           sucesso = 0 0 se a operação foi concluida com exito, -1 se nao 
        //           conteudo -> lista de strings com o conteudo do arquivo
        public static (List<string> conteudo, bool sucesso) LerArquivoTexto(string caminhoArquivo)
        {
            List<string> linhas = new List<string>();
            bool leituraBemSucedida = false;

            try
            {
                // Lê todas as linhas do arquivo e adiciona à lista
                linhas.AddRange(File.ReadAllLines(caminhoArquivo));
                leituraBemSucedida = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao ler o arquivo: " + ex.Message);
            }

            return (linhas, leituraBemSucedida);
        }

        // Escreve em arquivo texto
        // parametros : string caminhoArquivo -> endereço do arquivo a ser escrito
        // retorno : int -> 0 se a operação foi concluida com exito, -1 se nao
        public static int EscreveArquivoTexto(string caminhoArquivo, string[] linhas)
        {
            if ((caminhoArquivo.Length == 0) || (linhas.Length == 0))
            {
                MessageBox.Show(" {caminhoArquivo} inexistente ou {linhas} vazio");
                return -1;
            }

            // Salvar as linhas de volta no arquivo
            File.WriteAllLines(caminhoArquivo, linhas);

            return 0;
        }

        public static string[] ConverteStringAArray(string input)
        {
            // Divide a string em linhas usando o caractere de nova linha
            string[] linesArray = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return linesArray; // Retorna o array
        }

        // Função que converte um array em uma lista
        public static List<string> ConverteArrayAList(string[] array)
        {
            // Converte o array usando o construtor da List
            List<string> list = new List<string>(array);
            return list; // Retorna a lista
        }


    }
}
