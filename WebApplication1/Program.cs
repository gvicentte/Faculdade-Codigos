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
            // Removed invalid argument from CreateCommand
            await using var cmd = connection2.CreateCommand();
            cmd.CommandText = "SELECT * FROM tab_bibliotecarias;";
            //cmd.CommandText = "SELECT * FROM tab_bibliotecarias";
            await using var version = await cmd.ExecuteReaderAsync();
            while (await version.ReadAsync())
            {
                Console.WriteLine(version.GetString(0));
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