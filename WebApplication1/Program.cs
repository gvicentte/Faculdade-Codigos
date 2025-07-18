using System;
using System.Data.Common;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
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
                                await connection.OpenAsync();
                                if (connection.State == System.Data.ConnectionState.Open)
                                {
                                    Console.Write("Informe o nome do produto: ");
                                    string nome = Console.ReadLine() ?? string.Empty;
                                    Console.Write("Informe a descrição do produto: ");
                                    string? descricao = Console.ReadLine();
                                    Console.Write("Informe o preço do produto: ");
                                    decimal preco = Convert.ToDecimal(Console.ReadLine());
                                    Console.Write("Informe a quantidade em estoque: ");
                                    int quantidadeEstoque = Convert.ToInt32(Console.ReadLine());
                                    using (var cmd = new NpgsqlCommand("INSERT INTO produtos (nome, descricao, preco, quantidade_estoque) VALUES (@nome, @descricao, @preco, @quantidadeEstoque)", connection))
                                    {
                                        cmd.Parameters.AddWithValue("nome", nome);
                                        cmd.Parameters.AddWithValue("descricao", descricao);
                                        cmd.Parameters.AddWithValue("preco", preco);
                                        cmd.Parameters.AddWithValue("quantidadeEstoque", quantidadeEstoque);
                                        if (string.IsNullOrEmpty(nome) || preco <= 0 || quantidadeEstoque < 0)
                                        {
                                            Console.WriteLine("Dados inválidos. Por favor, tente novamente.\n");
                                            return;
                                        }
                                        await cmd.ExecuteNonQueryAsync();
                                        if (cmd.ExecuteNonQueryAsync().IsCompletedSuccessfully)
                                        {
                                            Console.WriteLine("Produto cadastrado com sucesso!\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Erro ao cadastrar o produto. Tente novamente.\n");
                                        }
                                    }
                                    connection.Close();
                                }
                                else
                                {
                                    Console.WriteLine("Falha ao conectar ao banco de dados. Tente novamente.");
                                    connection.Close();
                                    return;
                                }
                                // Aqui você pode adicionar a lógica para cadastrar um produto
                                break;
                            case 2:
                                Console.WriteLine("Listar Produtos selecionado.\n");
                                await connection.OpenAsync();
                                if (connection.State == System.Data.ConnectionState.Open)
                                {
                                    using (var cmd = new NpgsqlCommand("SELECT * FROM produtos", connection))
                                    {
                                        await using var reader = await cmd.ExecuteReaderAsync();
                                        if (reader.HasRows)
                                        {
                                            Console.WriteLine("Lista de Produtos:");
                                            while (await reader.ReadAsync())
                                            {
                                                Console.WriteLine($"ID: {reader.GetInt32(0)}, Nome: {reader.GetString(1)}, Descrição: {reader.GetString(2)}, Preço: {reader.GetDecimal(3)}, Quantidade em Estoque: {reader.GetInt32(4)}");
                                            }
                                            Console.WriteLine("\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Nenhum produto encontrado.\n");
                                        }
                                    }
                                    connection.Close();
                                }
                                else
                                {
                                    Console.WriteLine("Falha ao conectar ao banco de dados. Tente novamente.\n");
                                    connection.Close();
                                    return;
                                }
                                // Aqui você pode adicionar a lógica para listar produtos
                                break;
                            case 3:
                                Console.WriteLine("Obter Produto por ID selecionado.\n");
                                Console.Write("Informe o ID do produto: ");
                                int idProduto = Convert.ToInt32(Console.ReadLine());
                                await connection.OpenAsync();
                                if (connection.State == System.Data.ConnectionState.Open)
                                {
                                    using (var cmd = new NpgsqlCommand("SELECT * FROM produtos WHERE id = @id", connection))
                                    {
                                        cmd.Parameters.AddWithValue("id", idProduto);
                                        await using var reader = await cmd.ExecuteReaderAsync();
                                        if (await reader.ReadAsync())
                                        {
                                            Console.WriteLine($"ID: {reader.GetInt32(0)}, Nome: {reader.GetString(1)}, Descrição: {reader.GetString(2)}, Preço: {reader.GetDecimal(3)}, Quantidade em Estoque: {reader.GetInt32(4)}\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Produto não encontrado.\n");
                                        }
                                    }
                                    connection.Close();
                                }
                                else
                                {
                                    Console.WriteLine("Falha ao conectar ao banco de dados. Tente novamente.\n");
                                    connection.Close();
                                    return;
                                }
                                break;
                            // Aqui você pode adicionar a lógica para obter um produto por ID
                            case 4:
                                Console.WriteLine("Atualizar Produto selecionado.\n");
                                Console.Write("Informe o ID do produto a ser atualizado: ");
                                int idAtualizar = Convert.ToInt32(Console.ReadLine());
                                await connection.OpenAsync();
                                if (connection.State == System.Data.ConnectionState.Open)
                                {
                                    using (var cmd = new NpgsqlCommand("SELECT * FROM produtos WHERE id = @id", connection))
                                    {
                                        cmd.Parameters.AddWithValue("id", idAtualizar);
                                        await using var reader = await cmd.ExecuteReaderAsync();
                                        if (await reader.ReadAsync())
                                        {
                                            Console.WriteLine($"ID: {reader.GetInt32(0)}, Nome: {reader.GetString(1)}, Descrição: {reader.GetString(2)}, Preço: {reader.GetDecimal(3)}, Quantidade em Estoque: {reader.GetInt32(4)}");
                                            reader.Close(); // Fecha o leitor antes de atualizar

                                            Console.Write("Informe o novo nome do produto: ");
                                            string novoNome = Console.ReadLine() ?? string.Empty;
                                            Console.Write("Informe a nova descrição do produto: ");
                                            string? novaDescricao = Console.ReadLine();
                                            Console.Write("Informe o novo preço do produto: ");
                                            decimal novoPreco = Convert.ToDecimal(Console.ReadLine());
                                            Console.Write("Informe a nova quantidade em estoque: ");
                                            int novaQuantidadeEstoque = Convert.ToInt32(Console.ReadLine());

                                            using (var updateCmd = new NpgsqlCommand("UPDATE produtos SET nome = @nome, descricao = @descricao, preco = @preco, quantidade_estoque = @quantidadeEstoque WHERE id = @id", connection))
                                            {
                                                updateCmd.Parameters.AddWithValue("nome", novoNome);
                                                updateCmd.Parameters.AddWithValue("descricao", novaDescricao);
                                                updateCmd.Parameters.AddWithValue("preco", novoPreco);
                                                updateCmd.Parameters.AddWithValue("quantidadeEstoque", novaQuantidadeEstoque);
                                                updateCmd.Parameters.AddWithValue("id", idAtualizar);
                                                await updateCmd.ExecuteNonQueryAsync();
                                                Console.WriteLine("Produto atualizado com sucesso!\n");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Produto não encontrado.\n");
                                        }
                                    }
                                    connection.Close();
                                }
                                else
                                {
                                    Console.WriteLine("Falha ao conectar ao banco de dados. Tente novamente.\n");
                                    connection.Close();
                                    return;
                                }
                                // Aqui você pode adicionar a lógica para atualizar um produto
                                break;
                            case 5:
                                Console.WriteLine("Excluir Produto selecionado.\n");
                                Console.Write("Informe o ID do produto a ser excluído: ");
                                int idExcluir = Convert.ToInt32(Console.ReadLine());
                                await connection.OpenAsync();
                                if (connection.State == System.Data.ConnectionState.Open)
                                {
                                    using (var cmd = new NpgsqlCommand("DELETE FROM produtos WHERE id = @id", connection))
                                    {
                                        cmd.Parameters.AddWithValue("id", idExcluir);
                                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                                        if (rowsAffected > 0)
                                        {
                                            Console.WriteLine("Produto excluído com sucesso!\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Produto não encontrado ou já excluído.\n");
                                        }
                                    }
                                    connection.Close();
                                }
                                else
                                {
                                    Console.WriteLine("Falha ao conectar ao banco de dados. Tente novamente.\n");
                                    connection.Close();
                                    return;
                                }
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
                                await connection.OpenAsync();
                                if (connection.State == System.Data.ConnectionState.Open)
                                {
                                    Console.Write("Informe o nome do cliente: ");
                                    string cliente = Console.ReadLine() ?? string.Empty;
                                    Console.Write("Informe a data do pedido (dd/MM/yyyy): ");
                                    DateTime dataPedido = DateTime.Parse(Console.ReadLine() ?? string.Empty);
                                    Pedido pedido = new Pedido
                                    {
                                        Cliente = cliente,
                                        DataPedido = dataPedido
                                    };

                                    Console.Write("Quantos itens deseja adicionar ao pedido? ");
                                    int numeroItens = Convert.ToInt32(Console.ReadLine());

                                    for (int i = 0; i < numeroItens; i++)
                                    {
                                        Console.Write($"Informe o ID do produto {i + 1}: ");
                                        int produtoId = Convert.ToInt32(Console.ReadLine());
                                        Console.Write($"Informe a quantidade do produto {i + 1}: ");
                                        int quantidade = Convert.ToInt32(Console.ReadLine());

                                        // Aqui você pode buscar o produto pelo ID e obter o nome e preço
                                        // Simulando com dados fictícios
                                        string nomeProduto = "Produto Exemplo"; // Substitua pela lógica de busca real
                                        decimal precoUnitario = 10.00m; // Substitua pela lógica de busca real

                                        ItemPedido itemPedido = new ItemPedido
                                        {
                                            ProdutoId = produtoId,
                                            NomeProduto = nomeProduto,
                                            Quantidade = quantidade,
                                            PrecoUnitario = precoUnitario,
                                            ValorTotalItem = precoUnitario * quantidade
                                        };

                                        pedido.Itens.Add(itemPedido);
                                        pedido.ValorTotalPedido += itemPedido.ValorTotalItem;
                                    }

                                    // Aqui você pode salvar o pedido no banco de dados
                                    Console.WriteLine($"Pedido cadastrado com sucesso! Valor Total: {pedido.ValorTotalPedido:C}\n");
                                    connection.Close();
                                }
                                else
                                {
                                    Console.WriteLine("Falha ao conectar ao banco de dados. Tente novamente.\n");
                                    connection.Close();
                                    return;
                                }
                                // Aqui você pode adicionar a lógica para cadastrar um pedido
                                break;
                            case 2:
                                Console.WriteLine("Listar Pedidos selecionado.\n");
                                await connection.OpenAsync();
                                if (connection.State == System.Data.ConnectionState.Open)
                                {
                                    Console.Write("Informe o ID do pedido a ser listado: ");
                                    int idPedido = Convert.ToInt32(Console.ReadLine());
                                    using (var cmd = new NpgsqlCommand("SELECT * FROM pedidos WHERE id=@id", connection))
                                    {
                                        cmd.Parameters.AddWithValue("id", idPedido);
                                        await using var reader = await cmd.ExecuteReaderAsync();
                                        if (reader.HasRows)
                                        {
                                            Console.WriteLine("Lista de Pedidos:");
                                            while (await reader.ReadAsync())
                                            {
                                                Console.WriteLine($"ID: {reader.GetInt32(0)}, Cliente: {reader.GetString(1)}, Data: {reader.GetDateTime(2)}, Valor Total: {reader.GetDecimal(3)}");
                                            }
                                            Console.WriteLine("\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Nenhum pedido encontrado.\n");
                                        }
                                    }
                                    connection.Close();
                                }
                                else
                                {
                                    Console.WriteLine("Falha ao conectar ao banco de dados. Tente novamente.\n");
                                    connection.Close();
                                    return;
                                }
                                // Aqui você pode adicionar a lógica para listar pedidos
                                break;
                            case 3:
                                Console.WriteLine("Atualizar Pedido selecionado.\n");
                                await connection.OpenAsync();
                                if (connection.State == System.Data.ConnectionState.Open)
                                {
                                    Console.Write("Informe o ID do pedido a ser atualizado: ");
                                    int idAtualizarPedido = Convert.ToInt32(Console.ReadLine());
                                    using (var cmd = new NpgsqlCommand("SELECT * FROM pedidos WHERE id=@id", connection))
                                    {
                                        cmd.Parameters.AddWithValue("id", idAtualizarPedido);
                                        await using var reader = await cmd.ExecuteReaderAsync();
                                        if (await reader.ReadAsync())
                                        {
                                            Console.WriteLine($"ID: {reader.GetInt32(0)}, Cliente: {reader.GetString(1)}, Data: {reader.GetDateTime(2)}, Valor Total: {reader.GetDecimal(3)}");
                                            reader.Close(); // Fecha o leitor antes de atualizar

                                            Console.Write("Informe o novo nome do cliente: ");
                                            string novoCliente = Console.ReadLine() ?? string.Empty;
                                            Console.Write("Informe a nova data do pedido (dd/MM/yyyy): ");
                                            DateTime novaDataPedido = DateTime.Parse(Console.ReadLine() ?? string.Empty);

                                            using (var updateCmd = new NpgsqlCommand("UPDATE pedidos SET cliente = @cliente, data_pedido = @dataPedido WHERE id = @id", connection))
                                            {
                                                updateCmd.Parameters.AddWithValue("cliente", novoCliente);
                                                updateCmd.Parameters.AddWithValue("dataPedido", novaDataPedido);
                                                updateCmd.Parameters.AddWithValue("id", idAtualizarPedido);
                                                await updateCmd.ExecuteNonQueryAsync();
                                                Console.WriteLine("Pedido atualizado com sucesso!\n");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Pedido não encontrado.\n");
                                        }
                                    }
                                    connection.Close();
                                }
                                else
                                {
                                    Console.WriteLine("Falha ao conectar ao banco de dados. Tente novamente.\n");
                                    connection.Close();
                                    return;
                                }
                                // Aqui você pode adicionar a lógica para atualizar um pedido
                                break;
                            case 4:
                                Console.WriteLine("Excluir Pedido selecionado.\n");
                                await connection.OpenAsync();
                                if (connection.State == System.Data.ConnectionState.Open)
                                {
                                    Console.Write("Informe o ID do pedido a ser excluído: ");
                                    int idExcluirPedido = Convert.ToInt32(Console.ReadLine());
                                    using (var cmd = new NpgsqlCommand("DELETE FROM pedidos WHERE id = @id", connection))
                                    {
                                        cmd.Parameters.AddWithValue("id", idExcluirPedido);
                                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                                        if (rowsAffected > 0)
                                        {
                                            Console.WriteLine("Pedido excluído com sucesso!\n");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Pedido não encontrado ou já excluído.\n");
                                        }
                                    }
                                    connection.Close();
                                }
                                else
                                {
                                    Console.WriteLine("Falha ao conectar ao banco de dados. Tente novamente.\n");
                                    connection.Close();
                                    return;
                                }
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
    }
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
    }

    public class Pedido
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
        public decimal ValorTotalPedido { get; set; }
        public DateTime DataPedido { get; set; }
    }

    public class ItemPedido
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal ValorTotalItem { get; set; }
    }
}