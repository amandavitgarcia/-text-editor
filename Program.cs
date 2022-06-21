using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            //armazenando a resposta do usuário em um SHORT pois o número é pequeno. 
            short option = short.Parse(Console.ReadLine()); 

            //usando switch pra chamar as funções que temos
            switch(option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break; 
                default: Menu(); break;
            }
        }

         static void Abrir()
         {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                //ReadToEnd = le o arquivo até o final
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
         }

         static void Editar(){
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");

            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            //TUDO oq o usuário digitar será armazenado e salvo 
            string text = "";

            //para armazenar algo antes de executar o while, usa-se o DO
            do
            {
               //concatenando oq foi digitado com oq já estava digitado
                text += Console.ReadLine();
                //para quebrar uma linha no fim de cada leitura
                text += Environment.NewLine;
            }
            
            //caracteres de espaço são definidos pelo /n 
            //nesse while a condição é o usuário apertar ESC, para isso usamos o KEY que pega a tecla
            //se a tecla for diferente de ESC continua no laço de repetição
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);
         }

         static void Salvar(string text)
         {             
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            //pegando o TEXT e salvando no PATH(caminho informado pelo usuário)
            var path = Console.ReadLine();

            //os arquivos precisam ser abertos e fechados p/ evitar problemas na maquina 
            //Abrindo arquivo usando using para que ele feche sozinho após ser usado
            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu(); 
         }
    }
}
