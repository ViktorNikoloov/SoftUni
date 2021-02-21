using System;

using Microsoft.Data.SqlClient;

namespace _06.RemoveVillain
{
    public class StartUp
    {
        private const string MinionsDbConnectionString = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            string villainId = Console.ReadLine();

            using SqlConnection sqlConnection = new SqlConnection(MinionsDbConnectionString);
            sqlConnection.Open();

            string villainName = GetVillainName(villainId, sqlConnection);
            if (villainName != null)
            {
                int releasedMinions = RealeaseVillainMinions(villainId, sqlConnection);
                DeleteVillianFromDb(villainId, sqlConnection);

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{releasedMinions} minions were released.");
            }
            else
            {
                Console.WriteLine("No such villain was found.");
            }
        }

        private static int RealeaseVillainMinions(string villainId, SqlConnection sqlConnection)
        {
            string realeaseMinionsQuery =
                @"DELETE 
                    FROM MinionsVillains 
                    WHERE VillainId = @villainId";
            using SqlCommand realeaseMinionsCmd = new SqlCommand(realeaseMinionsQuery, sqlConnection);
            realeaseMinionsCmd.Parameters.AddWithValue("@villainId", villainId);

            int affectedRows = realeaseMinionsCmd.ExecuteNonQuery();

            return affectedRows;
        }

        private static void DeleteVillianFromDb(string villainId, SqlConnection sqlConnection)
        {
            string deleteVillianQuery =
                @"DELETE 
                    FROM Villains
                    WHERE Id = @villainId";
            using SqlCommand deleteVillainCmd = new SqlCommand(deleteVillianQuery, sqlConnection);
            deleteVillainCmd.Parameters.AddWithValue("@villainId", villainId);

            deleteVillainCmd.ExecuteNonQuery();
        }

        private static string GetVillainName(string villainId, SqlConnection sqlConnection)
        {
            string villainName = null;

            string getVillainNameQuery =
                @"SELECT Name 
                    FROM Villains 
                    WHERE Id = @villainId";
            using SqlCommand getVillainNameCmd = new SqlCommand(getVillainNameQuery, sqlConnection);
            getVillainNameCmd.Parameters.AddWithValue("@villainId", villainId);

            using SqlDataReader dataReader = getVillainNameCmd.ExecuteReader();
            if (dataReader.Read())
            {
                villainName = dataReader["Name"]?.ToString();
            }

            return villainName;
        }
    }
}
