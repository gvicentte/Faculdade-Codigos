using System;
using System.Data.Common;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Npgsql; // Npgsql is the .NET data provider for PostgreSQL

class Program
{
    const string connectionString = "Host=localhost;Username=postgres;Password=1508;Database=postgres"; //conectou ao banco dessa vez rodando pelo VsCode
    static async Task Main()
    {
        await using var connection = new NpgsqlConnection(connectionString);
        int opcoes = 0;
        Console.WriteLine();
        Console.WriteLine("Ola Seja Bem Vindo ao Sistema de Estoque, Produtos e Pedidos");
        while (opcoes != 3)
        {
            Console.WriteLine("Selecione uma das opcoes abaixo:");
            Console.WriteLine("1 - Sistema de Produtos");
            Console.WriteLine("2 - Sistema de Pedidos");
            Console.WriteLine("3 - Sair do Sistema");
            opcoes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (opcoes)
            {
                case 1:
                    Console.WriteLine("Seja Bem Vindo ao Sistema de Produtos\n");
                    int opcaoProduto = 0;
                    while (opcaoProduto != 6)
                    {
                        Console.WriteLine("Escolha uma das opcoes abaixo:");
                        Console.WriteLine("1 - Cadastrar Produto");
                        Console.WriteLine("2 - Listar Produtos");
                        Console.WriteLine("3 - Obter Produto por ID");
                        Console.WriteLine("4 - Atualizar Produto");
                        Console.WriteLine("5 - Excluir Produto");
                        Console.WriteLine("6 - Voltar ao Menu Principal");
                        opcaoProduto = Convert.ToInt32(Console.ReadLine());
                        switch (opcaoProduto)
                        {
                            case 1:
                                Console.WriteLine("Cadastrar Produto selecionado.\n");
                                // Aqui você pode adicionar a lógica para cadastrar um produto
                                break;
                            case 2:
                                Console.WriteLine("Listar Produtos selecionado.\n");
                                // Aqui você pode adicionar a lógica para listar produtos
                                break;
                            case 3:
                                Console.WriteLine("Obter Produto por ID selecionado.\n");
                                break;
                            // Aqui você pode adicionar a lógica para obter um produto por ID
                            case 4:
                                Console.WriteLine("Atualizar Produto selecionado.\n");
                                // Aqui você pode adicionar a lógica para atualizar um produto
                                break;
                            case 5:
                                Console.WriteLine("Excluir Produto selecionado.\n");
                                // Aqui você pode adicionar a lógica para excluir um produto
                                break;
                            case 6:
                                Console.WriteLine("Voltando ao Menu Principal...\n");
                                break;
                            default:
                                Console.WriteLine("Opcao invalida, tente novamente.\n");
                                break;
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Seja Bem Vindo ao Sistema de Pedidos\n");
                    int opcaoPedido = 0;
                    while (opcaoPedido != 5)
                    {
                        Console.WriteLine("Escolha uma das opcoes abaixo:");
                        Console.WriteLine("1 - Cadastrar Pedido");
                        Console.WriteLine("2 - Listar Pedido Especifico");
                        Console.WriteLine("3 - Atualizar Pedido");
                        Console.WriteLine("4 - Excluir Pedido");
                        Console.WriteLine("5 - Voltar ao Menu Principal");
                        opcaoPedido = Convert.ToInt32(Console.ReadLine());
                        switch (opcaoPedido)
                        {
                            case 1:
                                Console.WriteLine("Cadastrar Pedido selecionado.\n");
                                // Aqui você pode adicionar a lógica para cadastrar um pedido
                                break;
                            case 2:
                                Console.WriteLine("Listar Pedidos selecionado.\n");
                                // Aqui você pode adicionar a lógica para listar pedidos
                                break;
                            case 3:
                                Console.WriteLine("Atualizar Pedido selecionado.\n");
                                // Aqui você pode adicionar a lógica para atualizar um pedido
                                break;
                            case 4:
                                Console.WriteLine("Excluir Pedido selecionado.\n");
                                // Aqui você pode adicionar a lógica para excluir um pedido
                                break;
                            case 5:
                                Console.WriteLine("Voltando ao Menu Principal...\n");
                                break;
                            default:
                                Console.WriteLine("Opcao invalida, tente novamente.\n");
                                break;
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Voce escolheu Sair do Sistema de Estoque, Produtos e Pedidos.");
                    Console.WriteLine("Obrigado por usar o nosso Sistema!");
                    Console.WriteLine("Ate logo!\n");
                    return;
                default:
                    Console.WriteLine("Opcao invalida, tente novamente.\n");
                    break;
            }
        }
        /*string nome;
        Console.Write("Ola Informe seu nome: ");
        nome = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Ola seu nome e {0}", nome);
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Conectado ao banco de dados com sucesso!");
        }
        await using (var connection2 = new NpgsqlConnection(connectionString))
        {
            await connection2.OpenAsync();
            Console.WriteLine("Conectado ao banco de dados com sucesso!");
            await using var cmd = connection2.CreateCommand();
            cmd.CommandText = "INSERT INTO tab_unidades_atendimentos (nome, endereco, telefone) VALUES (@nome, @endereco, @telefone);";
            cmd.Parameters.AddWithValue("nome", nome);
            cmd.Parameters.AddWithValue("endereco", "Rua Tend Tudo, 123");
            cmd.Parameters.AddWithValue("telefone", "123456789");
            await cmd.ExecuteNonQueryAsync();
            cmd.CommandText = "SELECT * FROM tab_unidades_atendimentos;";
            await using var version = await cmd.ExecuteReaderAsync();
            while (await version.ReadAsync())
            {
                Console.WriteLine($"{version.GetValue(0)}, {version.GetValue(1)}, {version.GetValue(2)}, {version.GetValue(3)}");
            }
        }*/
    }
}