using System;
using System.Linq;
using System.Text;

using Microsoft.Data.SqlClient;

namespace _08.IncreaseMinionAge
{
    public class StartUp
    {
        private const string MinionsDbConnectionString = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            string[] minionsId = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            using SqlConnection sqlConnection = new SqlConnection(MinionsDbConnectionString);
            sqlConnection.Open();

            ChangeNameAndIncreaseAge(minionsId, sqlConnection);
            string namesAndAges = GiveNamesAndAgesOfTheMinions(minionsId, sqlConnection);

            Console.WriteLine(namesAndAges);
        }

        private static string GiveNamesAndAgesOfTheMinions(string[] minionsId, SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            string namesAndAgesQuery =
                @"SELECT Name, Age FROM Minions";
            using SqlCommand namesAndAgesCmd = new SqlCommand(namesAndAgesQuery, sqlConnection);
            using SqlDataReader currNameAndAge = namesAndAgesCmd.ExecuteReader();

            foreach (var id in minionsId)
            {
                currNameAndAge.Read();
                namesAndAgesCmd.Parameters.AddWithValue("@Id", id);
                namesAndAgesCmd.Parameters.Clear();
                sb.AppendLine($"{currNameAndAge["Name"]} {currNameAndAge["Age"]}");
            }

            return sb.ToString().TrimEnd();
        }

        private static void ChangeNameAndIncreaseAge(string[] minionsId, SqlConnection sqlConnection)
        {
            string changeNameAndIncreaseAgeQuery =
                @"UPDATE Minions
                    SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), 
                        Age += 1
                    WHERE Id = @Id";
            using SqlCommand changeNameAndIncreaseAgeCmd = new SqlCommand(changeNameAndIncreaseAgeQuery, sqlConnection);

            foreach (var id in minionsId)
            {
                changeNameAndIncreaseAgeCmd.Parameters.AddWithValue("@Id", id);
                changeNameAndIncreaseAgeCmd.ExecuteNonQuery();
                changeNameAndIncreaseAgeCmd.Parameters.Clear();
            }

        }
    }
}
