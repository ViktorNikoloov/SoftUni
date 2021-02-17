using System;
using Microsoft.Data.SqlClient;

namespace _03.MinionNames
{
    class StartUp
    {
        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                string villainId = Console.ReadLine();

                SqlCommand command = new SqlCommand($"SELECT Name FROM Villains WHERE Id = {villainId}", sqlConnection);


            }

        }
    }
}
