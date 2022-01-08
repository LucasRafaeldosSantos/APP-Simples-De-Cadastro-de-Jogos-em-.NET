using System;

namespace DIO.AppCadastro
{
    class Program
    {
        static JogosRepositorio repositorio = new JogosRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                        ListarJogos();
                        break;
                    case "2":
                        InserirJogos();
                        break;
                    case "3":
                        AtualizarJogos();
                        break;
                    case "4":
                        ExcluirJogos();
                        break;
                    case "5":
                        VisualizarJogos();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                OpcaoUsuario = ObterOpcaoUsuario();
            }

            System.Console.WriteLine("Obrigado por utilizar os nossos serviços.");
            System.Console.ReadLine();
        }

        private static void ListarJogos()
        {
            System.Console.WriteLine("Listar Jogos");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhum jogo cadastrado.");
                return;
            }

            foreach (var jogos in lista)
            {
                var excluido = jogos.RetornaExcluido();

                System.Console.WriteLine("#ID {0}: - {1} - {2}", jogos.RetornaId(), jogos.RetornaTitulo(), excluido ? "*Excluído*" : "");
            }
        }

        private static void InserirJogos()
        {
            System.Console.WriteLine("Inserir novo jogo");

            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=net-6.0
            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=net-6.0
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título do jogo: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano de lançamento do jogo: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição do jogo: ");
            string entradaDescricao = Console.ReadLine();

            Jogos novoJogo = new Jogos(id: repositorio.ProximoId(),
                                       genero: (Genero)entradaGenero,
                                       titulo: entradaTitulo,
                                       ano: entradaAno,
                                       descricao: entradaDescricao);

            repositorio.Insere(novoJogo);
        }

        private static void AtualizarJogos()
        {
            System.Console.WriteLine("Digite o id do jogo: ");
            int indiceJogos = int.Parse(Console.ReadLine());

            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=net-6.0
            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=net-6.0
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o título do jogo: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.WriteLine("Digite o ano de lançamento do jogo: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite a descrição do jogo: ");
            string entradaDescricao = Console.ReadLine();

            Jogos atualizaJogos = new Jogos(id: indiceJogos,
                                       genero: (Genero)entradaGenero,
                                       titulo: entradaTitulo,
                                       ano: entradaAno,
                                       descricao: entradaDescricao);

            repositorio.Atualiza(indiceJogos, atualizaJogos);
        }

        private static void ExcluirJogos()
        {
            System.Console.WriteLine("Digite o id do jogo: ");
            int indiceJogos = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceJogos);
        }

        private static void VisualizarJogos()
        {
            System.Console.WriteLine("Digite o id do jogo: ");
            int indiceJogos = int.Parse(Console.ReadLine());

            var jogo = repositorio.RetornarPorId(indiceJogos);

            System.Console.WriteLine(jogo);
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Bem vindo ao serviço DIO Games!");
            System.Console.WriteLine("Informe a opção desejada:");

            System.Console.WriteLine("1 - Listar jogos");
            System.Console.WriteLine("2 - Inserir jogo");
            System.Console.WriteLine("3 - Atualizar jogo");
            System.Console.WriteLine("4 - Excluir jogo");
            System.Console.WriteLine("5 - Visualizar jogo");
            System.Console.WriteLine("C - Limpar tela");
            System.Console.WriteLine("X - Sair");

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}