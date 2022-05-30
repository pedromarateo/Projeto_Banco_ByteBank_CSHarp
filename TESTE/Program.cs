
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTE
{
    partial class Program
    {
        static void Main(string[] args)
        {
            TestaEscrita();
            Console.ReadLine();
        }

        


        static void CriarArquiloDiretoDoConsole()
        {
            using (var fs = Console.OpenStandardInput())
            using(var fss = new FileStream("ArquivoPedro2.txt", FileMode.Create))
            {
                var buffer = new byte[1024];
                while (true)
                {
                    
                    var bytesLidos = fs.Read(buffer, 0, 1024);
                    fss.Write(buffer, 0, bytesLidos);
                    fss.Flush();
                    Console.WriteLine($"Bytes Lidos: {bytesLidos}");
                }
                
            }
        }

        static void CriarArquivo()
        {
            using(var fs = new FileStream("ArquivoNovoPedro.csv", FileMode.Create))
            using (var escritor = new StreamWriter(fs, Encoding.UTF8))
            {
                int cont = 1;
                while (cont <= 291)
                {
                    escritor.WriteLine($"Dragon Ball Episódio {cont}");
                    cont++;
                }
                
                Console.WriteLine($"Arquivo Criado com sucesso! O total de episódios foi {cont} Obrigado por usar o C#");

            }
        }

        static void LeituraDeArquivo()
        {
            using (var fs = new FileStream("contas.txt", FileMode.Open))
            using (var leitor = new StreamReader(fs))
            {
                while (!leitor.EndOfStream)
                {
                    var leitorArquivoLido = leitor.ReadLine();
                    var conta = ConversorDeArquivoParaContaCorrente(leitorArquivoLido);
                    Console.WriteLine($"Nova conta: ag.{conta.Agencia}/n.{conta.Numero}/saldo: {conta.Saldo}/ Nome: {conta.Titular.Nome}");
                }
                
            }
        }

        static ContaCorrente ConversorDeArquivoParaContaCorrente(string arquivoLido)
        {
            string[] campos = arquivoLido.Split(',');
            var agencia = campos[0];
            var numero = campos[1];
            var saldo = campos[2].Replace('.', ',');
            var titular = new Cliente();
            titular.Nome = campos[3];

            var agenciaParaInt = int.Parse(agencia);
            var numeroParaInt = int.Parse(numero);
            var saldoParaDouble = double.Parse(saldo);

            var novaConta = new ContaCorrente(agenciaParaInt, numeroParaInt);
            novaConta.Depositar(saldoParaDouble);
            novaConta.Titular = titular;

            return novaConta;
        }

    }
}
