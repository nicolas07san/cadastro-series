using Dio.Series.Entities;
using Dio.Series.Enum;

class Program
{
    static SerieRepositorio repositorio = new SerieRepositorio();
    private static void Main(string[] args)
    {
        string opcaoDoUsuario = ObterOpcaoUsuario();

        while(opcaoDoUsuario != "X")
        {
            switch(opcaoDoUsuario)
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
                case "C":
                    Console.Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            opcaoDoUsuario = ObterOpcaoUsuario();
        }
        
    }

    private static void ListarSeries()
    {
        var lista =  repositorio.Lista();

        if(lista.Count == 0)
        {
            Console.WriteLine("Nenhuma série cadastrada.");
            return;
        }

        foreach(Serie serie in lista)
        {
            Console.WriteLine("#ID {0}: {1} - [{2}]", serie.retornaId(), serie.retornaTitulo(), serie.retornaExcluido() ? "Não Disponível" : "Disponível");
        }
    }

    private static void InserirSerie()
    {
        Console.WriteLine("Inserir nova série");

        foreach(int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
        }

        Console.Write("Digite o genêro entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título da Série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de Ínicio da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição da Série: ");
        string entradaDescricao = Console.ReadLine();

        Serie novaSerie = new Serie(Id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

        repositorio.Insere(novaSerie);

        Console.WriteLine();
        Console.WriteLine("--- Série adicionada com sucesso. ---");
        
    }

    private static void AtualizarSerie()
    {
        Console.Write("Digite o id da série: ");
        int entradaId = int.Parse(Console.ReadLine());

        foreach(int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
        }
        
        Console.Write("Digite o gênero dentre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título da série: ");
        string entradaTitulo = Console.ReadLine();
        
        Console.Write("Digite o Ano de Ínicio da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite a Descrição da Série: ");
        string entradaDescricao = Console.ReadLine();

        Serie novaSerie = new Serie(Id: entradaId, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

        repositorio.Atualiza(entradaId, novaSerie);

        Console.WriteLine();
        Console.WriteLine("--- Série atualizada com sucesso. ---");


    }

    private static void ExcluirSerie()
    {
        Console.Write("Digite o ID da série: ");
        int entradaId = int.Parse(Console.ReadLine());

        repositorio.Exclui(entradaId);
    }

    private static void VisualizarSerie()
    {
        Console.Write("Digite o ID da série: ");
        int entradaId = int.Parse(Console.ReadLine());

        Serie serie = repositorio.RetornaPorId(entradaId);

        Console.WriteLine(serie);
    }

    private static string ObterOpcaoUsuario()
    {
        Console.WriteLine();

        Console.WriteLine("Digital Innovation One Séries ao seu dispor!!!");
        Console.WriteLine("Informe a opção desejada");

        Console.WriteLine("1 - Listar séries");
        Console.WriteLine("2 - Inserir nova série");
        Console.WriteLine("3 - Atualizar série");
        Console.WriteLine("4 - Excluir série");
        Console.WriteLine("5 - Visualizar série");
        Console.WriteLine("C - Limpar tela");
        Console.WriteLine("X - Sair");

        Console.WriteLine();

        string opcaoDoUsuario = Console.ReadLine().ToUpper();
        
        Console.WriteLine();

        return opcaoDoUsuario;
    }
}
