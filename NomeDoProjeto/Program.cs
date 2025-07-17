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
    }
}