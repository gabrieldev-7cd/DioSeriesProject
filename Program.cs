using System;

namespace DioSeriesLib
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "6":
                        BuscaGenero();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Digite uma opção válida!");
                    break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
        }

        public static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            foreach(int i in Enum.GetValues(typeof(Genero))) 
            {
                Console.WriteLine("{0} - {1}",i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genêro entre as opções acima ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série:");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie
            (
                id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            repositorio.Insere(novaSerie);
        }
       
        public static void AtualizarSerie()
        {

            Console.Write("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("\n\nDigite o genêro entre as opções acima ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série:");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie
            (
                id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        public static void BuscaGenero()
        {

            Console.WriteLine("-- Lista de Gêneros --\n\n");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o ID do Gênero: ");
            int genero = int.Parse(Console.ReadLine());
            var resultadoBusca = repositorio.BuscaPorGenero(genero);

            if(resultadoBusca.Count > 0)
            {
                Console.WriteLine("\n-- Lista de Series deste Gênero --\n\n");
                for(int i = 0; i < resultadoBusca.Count; i++)
                {
                    Console.WriteLine("\n\n"+resultadoBusca[i]);
                }
            }
            else
            {
                Console.WriteLine("\n\nNenhuma Série deste gênero foi encontrada!");
            }
        }

        public static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.Write("Deja Mesmo Excluir este dado (Y/n):");
            string option = Console.ReadLine();
            if (option == "Y" || option == "y")
            {
                repositorio.Exclui(indiceSerie);
                Console.WriteLine("Dado foi Excluído com Sucesso!");
            }
            else
            {
                Console.WriteLine("Ok o dado não foi excluido!");
            }
        }

        public static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine("\n\n"+serie);

        }

        public static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0} - {1}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*.Excluido" : "*.Ativo") );
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\n" +
                "Dio Séries a seu dispor!!!\n" +
                "Informe aopção desejada:\n \n" +
                "1 - Listar Séries\n" +
                "2 - Inserir nova Série\n" +
                "3 - Atualizar Série\n" +
                "4 - Excluir Série\n" +
                "5 - Visualizar Série\n" +
                "6 - Buscar por gênero\n" +
                "C - Limpar Tela\n" +
                "X - Sair\n"
            );

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
