using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace _03.MinionNames
{
    public class StartUp
    {
        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string villainId = Console.ReadLine();
            string result = GetMinionsInfoAboutVillain(sqlConnection, villainId);
            Console.WriteLine(result);

        }

        private static string GetVillainName(SqlConnection sqlConnection, string villainId)
        {
            string getVillainNameQuery =
               @"SELECT Name 
                    FROM Villains 
                    WHERE Id = @villainId";

            using SqlCommand getVillainNameCmd = new SqlCommand(getVillainNameQuery, sqlConnection);
            getVillainNameCmd.Parameters.AddWithValue("@villainId", villainId);

            string villainName = getVillainNameCmd.ExecuteScalar()?.ToString();

            return villainName;
        }

        private static string GetVillainMinions(SqlConnection sqlConnection, string villainId)
        {
            StringBuilder sb = new StringBuilder();

            string getVillainMinionsQuery =
                    @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                             m.Name, 
                             m.Age
                        FROM MinionsVillains AS mv
                        JOIN Minions As m ON mv.MinionId = m.Id
                        WHERE mv.VillainId = @villainId
                        ORDER BY m.Name";

            using SqlCommand getVillainMinionsCmd = new SqlCommand(getVillainMinionsQuery, sqlConnection);
            getVillainMinionsCmd.Parameters.AddWithValue("@villainId", villainId);

            using SqlDataReader minionInfo = getVillainMinionsCmd.ExecuteReader();

            if (minionInfo.Read())
            {
                int row = 1;
                while (true)
                {
                    string minionName = minionInfo["Name"]?.ToString();
                    string minionAge = minionInfo["Age"]?.ToString();

                    sb.AppendLine($"{row}. {minionName} {minionAge}");

                    if (!minionInfo.Read())
                    {
                        break;
                    }
                    row++;
                }

            }
            else
            {
                sb.AppendLine("(no minions)");
            }

            return sb.ToString().TrimEnd();
        }


        private static string GetMinionsInfoAboutVillain(SqlConnection sqlConnection, string villainId)
        {
            StringBuilder sb = new StringBuilder();

            string villainName = GetVillainName(sqlConnection, villainId);
           

            if (villainName == null)
            {
                sb.AppendLine($"No villain with ID {villainId} exists in the database.");
            }
            else
            {
                string villainMinionsInfo = GetVillainMinions(sqlConnection, villainId);

                sb.AppendLine($"Villain: {villainName}");
                sb.AppendLine(villainMinionsInfo);
            }
                
            return sb.ToString().TrimEnd();
        }

       

        
    }
}
