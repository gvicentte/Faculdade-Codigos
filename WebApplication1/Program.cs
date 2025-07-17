using System;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Npgsql; // Npgsql is the .NET data provider for PostgreSQL

class Program
{
    static async Task Main()
    {
        string nome;
        Console.Write("Ola Informe seu nome: ");
        nome = Console.ReadLine();
        Console.WriteLine("Ola seu nome e {0}", nome);
        string connectionString = "Host=localhost;Username=postgres;Password=1508;Database=postgres"; //conectou ao banco dessa vez rodando pelo VsCode
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Conectado ao banco de dados com sucesso!");
        }
        await using (var connection2 = new NpgsqlConnection(connectionString))
        {
            await connection2.OpenAsync();
            await using (var cmd = connection2.CreateCommand())
            {
                cmd.CommandText = "SELECT version()";
                var version = await cmd.ExecuteScalarAsync();
                Console.WriteLine($"Versão do PostgreSQL: {version}");
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
}