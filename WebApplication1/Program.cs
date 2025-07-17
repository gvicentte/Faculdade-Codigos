using System;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Npgsql; // Npgsql is the .NET data provider for PostgreSQL

class Program
{
    const string connectionString = "Host=localhost;Username=postgres;Password=1508;Database=postgres"; //conectou ao banco dessa vez rodando pelo VsCode
    static async Task Main()
    {
        string nome;
        Console.Write("Ola Informe seu nome: ");
        nome = Console.ReadLine();
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
        }
    }
}
    /*static void ConnectToDatabase()
    {
        string connectionString = "Host=localhost;Username=postgres;Password=1508;Database=database";
        using(var connection=new NpgsqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Conectado ao banco de dados com sucesso!");
        }
    }*/
//}