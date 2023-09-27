using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Produto> produtos = new List<Produto>();
    
    static void Main()
    {
        bool sair = false;

        while (!sair)
        {
            LimparTela(); // Limpa a tela antes de exibir as opções do menu

            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Adicionar Produto");
            Console.WriteLine("2 - Remover Produto pelo ID");
            Console.WriteLine("3 - Editar Nome do Produto pelo ID");
            Console.WriteLine("4 - Visualizar Todos os Produtos");
            Console.WriteLine("5 - Sair");

            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    AdicionarProduto();
                    break;
                case 2:
                    RemoverProduto();
                    break;
                case 3:
                    EditarNomeProduto();
                    break;
                case 4:
                    VisualizarProdutos();
                    break;
                case 5:
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void AdicionarProduto()
    {
        LimparTela();
        Console.WriteLine("Digite o nome do produto:");
        string nome = Console.ReadLine();
        
        int novoId = produtos.Count > 0 ? produtos.Max(p => p.Id) + 1 : 1;

        produtos.Add(new Produto { Id = novoId, Nome = nome });
        Console.WriteLine("Produto adicionado com sucesso!");
        Console.ReadLine();
    }

    static void RemoverProduto()
    {
        LimparTela();
        Console.WriteLine("Digite o ID do produto a ser removido:");
        int id = int.Parse(Console.ReadLine());

        Produto produtoParaRemover = produtos.FirstOrDefault(p => p.Id == id);

        if (produtoParaRemover != null)
        {
            produtos.Remove(produtoParaRemover);
            Console.WriteLine("Produto removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
        Console.ReadLine();
    }

    static void EditarNomeProduto()
    {
        LimparTela();
        Console.WriteLine("Digite o ID do produto a ser editado:");
        int id = int.Parse(Console.ReadLine());

        Produto produtoParaEditar = produtos.FirstOrDefault(p => p.Id == id);

        if (produtoParaEditar != null)
        {
            Console.WriteLine("Digite o novo nome do produto:");
            string novoNome = Console.ReadLine();
            produtoParaEditar.Nome = novoNome;
            Console.WriteLine("Nome do produto editado com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado.");
        }
        Console.ReadLine();
    }

    static void VisualizarProdutos()
    {
        LimparTela();
        Console.WriteLine("Lista de Produtos:");
        foreach (var produto in produtos)
        {
            Console.WriteLine("ID: " + produto.Id + ", Nome: " + produto.Nome);
        }
        Console.ReadLine();
    }

    static void LimparTela()
    {
        Console.Clear();
    }
}

class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
}
