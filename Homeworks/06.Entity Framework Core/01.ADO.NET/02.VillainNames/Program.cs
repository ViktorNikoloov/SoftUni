using System;
using Microsoft.Data.SqlClient;

namespace _02.VillainNames
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection("Server=.\\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;"))
            {
                sqlConnection.Open();
                string query = 
                    "SELECT v.Name, " +
                    "COUNT(mv.VillainId) AS MinionsCount  " +
                        "FROM Villains AS v " +
                        "JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
                    "GROUP BY v.Id, v.Name HAVING COUNT(mv.VillainId) > 3 " +
                    "ORDER BY COUNT(mv.VillainId)";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataReader sqlDataReader = command.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Console.WriteLine($"{sqlDataReader["Name"]} - {sqlDataReader["MinionsCount"]}");
                }
            }
        }
    }
}
