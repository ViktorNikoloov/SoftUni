using System;
using System.Data;
using System.Text;

using Microsoft.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        private const string MinionsDbConnectionString = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            string minionId = Console.ReadLine();

            using SqlConnection sqlConnection = new SqlConnection(MinionsDbConnectionString);
            sqlConnection.Open();

            IncreaseMinionAgeById(minionId, sqlConnection);

            string newMinionsAgeAndName = GetMinionAgeAndName(minionId, sqlConnection);

            Console.WriteLine(newMinionsAgeAndName);
        }

        private static string GetMinionAgeAndName(string minionId, SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            string getNameAndAgeQuery =
                @"SELECT Name, Age 
                    FROM Minions 
                    WHERE Id = @Id";
            using SqlCommand getNameAndAgeCmd = new SqlCommand(getNameAndAgeQuery, sqlConnection);
            getNameAndAgeCmd.Parameters.AddWithValue("@id", minionId);

            using SqlDataReader dataReader = getNameAndAgeCmd.ExecuteReader();
            dataReader.Read();

            sb.AppendLine($"{dataReader["Name"]} - {dataReader["Age"]} years old");

            return sb.ToString().TrimEnd();
        }

        private static void IncreaseMinionAgeById(string minionId, SqlConnection sqlConnection)
        {
            string procedureName = "usp_GetOlder";

            using SqlCommand increaseAgeCmd = new SqlCommand(procedureName, sqlConnection);
            increaseAgeCmd.CommandType = CommandType.StoredProcedure;
            increaseAgeCmd.Parameters.AddWithValue("@id", minionId);

            increaseAgeCmd.ExecuteNonQuery();
        }
    }
}
