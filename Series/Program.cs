using System;
using Series.Classes;

namespace Series
{
    class Program
    {

        static SerieRepositorio repositorioSerie = new SerieRepositorio();
        static FilmesRepositorio repositorioFilme = new FilmesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        Console.Clear();
                        ListarSeriesFilmes();
                        break;
                    case "2":
                        Console.Clear();
                        InserirSeriesFilmes();
                        break;
                    case "3":
                        Console.Clear();
                        AtualizarSerieFilme();
                        break;
                    case "4":
                        Console.Clear();
                        ExcluirSerieFilme();
                        break;
                    case "5":
                        Console.Clear();
                        VisualizarSerieFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                    opcaoUsuario = ObterOpcaoUsuario();
            }
                Console.WriteLine("Obrigado por utilizar os nossos serviços.");
                Console.ReadLine();
        }

        private static void ListarSeriesFilmes() 
        {
            Console.WriteLine("Listar Séries e Filmes");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Listar Filmes");
            Console.WriteLine("3 - Listar Séries ou Filmes");
            Console.WriteLine("C - Voltar");
            Console.WriteLine();

            string opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            switch (opcaousuario) 
            {
                case "1":
                    ListarSeries();
                    break;
                case "2":
                    ListarFilmes();
                    break;
                case "3":
                    ListarSeries();
                    Console.WriteLine();
                    ListarFilmes();
                    break;
                default:
                    Console.Clear();
                    break;
                }

        }
        private static void ListarSeries()
        {
            
            Console.WriteLine("Listar Séries");
            var listaSerie = repositorioSerie.List();

            if(listaSerie.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
            }
            foreach(var serie in listaSerie)
            {
                var excuido  = serie.retornaExluido();
                Console.WriteLine("#ID {0}: {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excuido ? "*Exluido*" : ""));
            }
        }

        private static void ListarFilmes() 
        {

            Console.WriteLine("Listar Filmes");
            var listaFilme = repositorioFilme.List();

            if (listaFilme.Count == 0)
            {
                Console.WriteLine("Nenhuma filme cadastrada.");
            }
            foreach (var filme in listaFilme)
            {
                var excuido = filme.retornaExluido();
                Console.WriteLine("#ID {0}: {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excuido ? "*Exluido*" : ""));
            }
        }

        private static void InserirSeriesFilmes()
        {
            Console.WriteLine("Inserir Série ou Filme");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();

            Console.WriteLine("1 - Inserir Série");
            Console.WriteLine("2 - Inserir Filme");
            Console.WriteLine("C - Voltar");
            Console.WriteLine();

            string opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            switch (opcaousuario)
            {
                case "1":
                    InserirSerie();
                    break;
                case "2":
                    InserirFilme();
                    break;
                default:
                    Console.Clear();
                    break;
            }

        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorioSerie.ProximoId(),
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao); 

            repositorioSerie.Insere(novaSerie);
        }
        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filmes novoFilme = new Filmes(id: repositorioFilme.ProximoId(),
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);

            repositorioFilme.Insere(novoFilme);
        }

        private static void AtualizarSerieFilme()
        {
            Console.WriteLine("Atualizar Série ou Filme");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();

            Console.WriteLine("1 - Atualizar Série");
            Console.WriteLine("2 - Atualizar Filme");
            Console.WriteLine("C - Voltar");
            Console.WriteLine();

            string opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            switch (opcaousuario)
            {
                case "1":
                    ListarSeries();
                    Console.WriteLine();
                    AtualizarSerie();
                    break;
                case "2":
                    ListarFilmes();
                    Console.WriteLine();
                    AtualizarFilme();
                    break;
                default:
                    Console.Clear();
                    break;
            }

        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digitar o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: indiceSerie,
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao); 

            repositorioSerie.Atualizar(indiceSerie, atualizaSerie);
        }

        private static void AtualizarFilme()
        {
            Console.WriteLine("Digitar o id do filme");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Filmes atualizaFilme = new Filmes(id: indiceFilme,
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          ano: entradaAno,
                                          descricao: entradaDescricao);

            repositorioFilme.Atualizar(indiceFilme, atualizaFilme);
        }
        private static void ExcluirSerieFilme()
        {
            Console.WriteLine("Exluir Série ou Filme");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();

            Console.WriteLine("1 - Excluir Série");
            Console.WriteLine("2 - Excluir Filme");
            Console.WriteLine("C - Voltar");
            Console.WriteLine();

            string opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            switch (opcaousuario)
            {
                case "1":
                    ListarSeries();
                    Console.WriteLine();
                    ExcluirSerie();
                    break;
                case "2":
                    ListarFilmes();
                    Console.WriteLine();
                    ExcluirFilme();
                    break;
                default:
                    Console.Clear();
                    break;
            }

        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digitar o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorioSerie.Excluir(indiceSerie);    
        }
        private static void ExcluirFilme()
        {
            Console.WriteLine("Digitar o id do filme");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositorioFilme.Excluir(indiceFilme);
        }

        private static void VisualizarSerieFilme()
        {
            Console.WriteLine("Visializar Série ou Filme");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();

            Console.WriteLine("1 - Visualizar Série");
            Console.WriteLine("2 - Visualizar Filme");
            Console.WriteLine("C - Voltar");
            Console.WriteLine();

            string opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            switch (opcaousuario)
            {
                case "1":
                    ListarSeries();
                    Console.WriteLine();
                    VisualizarSerie();
                    break;
                case "2":
                    ListarFilmes();
                    Console.WriteLine();
                    VisualizarFilme();
                    break;
                default:
                    Console.Clear();
                    break;
            }

        }
        private static void VisualizarSerie()
        {
            Console.WriteLine("Digitar o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorioSerie.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
            }
        
        private static void VisualizarFilme()
        {
            Console.WriteLine("Digitar o id do Filme");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorioFilme.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries e Filmes a seu dispor!!!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Séries e Filmes");
            Console.WriteLine("2 - Inserir nova Série ou Filme");
            Console.WriteLine("3 - Atualizar Série ou Filme");
            Console.WriteLine("4 - Exluir Série ou Filme");
            Console.WriteLine("5 - Visualizar Série ou Filme");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaousuario;
        }
    }
}
