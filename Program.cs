using System;
using System.IO;

namespace EditorTexto
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
            Console.WriteLine("O que vamos fazer hoje? :)");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair :(");

            short opcao = short.Parse(Console.ReadLine());

            switch (opcao)
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
            Console.WriteLine("Por favor, digite o caminho do caminho.");
            string path = Console.ReadLine();

            if ((File.Exists(path)))
            {
                using (var file = new StreamReader(path))
                {
                    string texto = file.ReadToEnd();
                    Console.Clear();
                    Console.WriteLine(texto);
                }
                Console.WriteLine("");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu inicial.");
                Console.ReadLine();
                Menu();
            }
            else
            {
                Console.WriteLine("O arquivo não foi encontrado");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu inicial.");
                Console.ReadLine();
                Menu();
            }

        }
        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto aqui. :) (Esc para sair)");
            Console.WriteLine("-------------------------");
            string texto = "";

            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(texto);
        }

        static void Salvar(string texto)
        {
            Console.Clear();
            Console.WriteLine("Por favor, digite o caminho para salvar o caminho.");
            string path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(texto);
            }
            Console.Clear();
            Console.WriteLine("Arquivo salvo com sucesso!");
            Console.WriteLine($"Caminho: {path}");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu inicial.");
            Console.ReadLine();
            Menu();
        }
    }
}
