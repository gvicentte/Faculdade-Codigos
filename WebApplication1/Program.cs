using System;
using Npgsql; // Npgsql is the .NET data provider for PostgreSQL

class Program
{
    static void Main()
    {
        string nome;
        Console.Write("Ola Informe seu nome: ");
        nome = Console.ReadLine();
        Console.WriteLine("Ola seu nome e {0}", nome);
        string connectionString = "Host=localhost;Username=postgres;Password=1508;Database=database";
        using(var connection=new NpgsqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Conectado ao banco de dados com sucesso!");
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