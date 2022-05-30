using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO; // IO = INPUT/OUTPUT

namespace ByteBankImportacaoExportacao 
{ 
    partial class Program 
    { 
        static void Main(string[] args) 
        {


            File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText");

            Console.WriteLine("Arquivo escrevendo com a classe criado");

            var bytesArquivo = File.ReadAllBytes("contas.txt");

            Console.WriteLine($"Arquivo contas.txt possui {bytesArquivo.Length} bytes");



            var linhas = File.ReadAllLines("contas.txt");
            Console.WriteLine(linhas.Length);

            foreach (var linha in linhas)
            {
                Console.WriteLine(linha);
            }

            Console.ReadLine();

            Console.WriteLine("Digite seu Nome");
            var nome = Console.ReadLine();

            Console.WriteLine($"Seu nome é:  { nome}");

            UsarStreamDeEntrada();

            Console.WriteLine("Aplicação finalizada...");

            Console.ReadLine();
        }

        
    }
} 
 