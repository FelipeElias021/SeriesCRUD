using System;
using SysEnum = System.Enum;
using SeriesCRUD.Classes;
using SeriesCRUD.Enum;

namespace SeriesCRUD
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario;

            do
            {
                opcaoUsuario = Menu();

                switch (opcaoUsuario)
                {
                    case "1":
                        GetAll();
                        break;
                    case "2":
                        Add();
                        break;
                    case "3":
                        Update();
                        break;
                    case "4":
                        Delete();
                        break;
                    case "5":
                        GetById();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            } while (opcaoUsuario != "X");
        }

        private static void GetAll()
        {
            Console.WriteLine("Listando Séries:\n");

            var lista = repositorio.GetAll();

            if (lista.Count == 0)
            {
                Console.WriteLine("Ainda não há séries adicionadas!");
                return;
            }

            foreach (var serie in lista)
            {
                if (!serie.GetExcluido())
                {
                    Console.WriteLine($"#ID {serie.GetId()} - {serie.GetTitulo()}");
                }
            }
        }

        private static void Add()
        {
            Console.WriteLine("Adicionando Nova Série:\n");

            Serie novaSerie = PegarDados(repositorio.NextId());

            repositorio.Add(novaSerie);
        }

        private static void Update()
        {
            Console.WriteLine("Atualizando Série:\n");

            Console.Write("Digite o ID da série: ");
            int id = int.Parse(Console.ReadLine());

            Serie serieAtualizada = PegarDados(id);

            repositorio.Update(id, serieAtualizada);
        }

        private static void Delete()
        {
            Console.WriteLine("Deletando Série:\n");

            Console.Write("Digite o ID da série: ");
            int id = int.Parse(Console.ReadLine());

            repositorio.Delete(id);
        }

        private static void GetById()
        {
            Console.Write("Digite o ID da série: ");
            int id = int.Parse(Console.ReadLine());

            var serie = repositorio.GetByID(id);

            if (serie.GetExcluido() == false)
            {
                Console.WriteLine(serie);
            }
            else
            {
                Console.WriteLine("Série não existe");
            }
        }

        private static Serie PegarDados(int id)
        {
            foreach (int i in SysEnum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i}\t- {SysEnum.GetName(typeof(Genero), i)}");
            }
            Console.Write("Digite o número do gênero entre as opções acima: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Ano de início: ");
            string ano = Console.ReadLine();

            Console.Write("Temporadas: ");
            int temporadas = int.Parse(Console.ReadLine());

            var serie = new Serie(id, (Genero)genero, titulo, descricao, ano, temporadas);

            return serie;
        }

        private static string Menu()
        {
            Console.WriteLine("\nSelecione a opção desejada");

            Console.WriteLine("> 1. Listar séries");
            Console.WriteLine("> 2. Inserir nova série");
            Console.WriteLine("> 3. Atualizar série");
            Console.WriteLine("> 4. Excluir série");
            Console.WriteLine("> 5. Visualizar série");
            Console.WriteLine("> C. Limpar Tela");
            Console.WriteLine("> X. Sair");
            Console.Write("> ");

            string opcaoUsuario = Console.ReadLine().ToUpper().Trim();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
