using System;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace _04.AddMinion
{
    public class StartUp
    {
        private const string MinionsDBConnectionString = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            string[] minionInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] minionInfo = minionInput[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            string minionName = minionInfo[0];
            string minionAge = minionInfo[1];
            string minionTownInfo = minionInfo[2];

            string[] villaiInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string villainName = villaiInput[1];

            using SqlConnection sqlConnection = new SqlConnection(MinionsDBConnectionString);
            sqlConnection.Open();
            
            string villainId = GetVillainId(villainName, sqlConnection);
            if (villainId == null)
            {
                AddVillainIntoDB(villaiInput[1], sqlConnection);
                villainId = GetVillainId(villainName, sqlConnection);
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            string TownId = IsMinionTownExist(minionTownInfo, sqlConnection);
            if (TownId == null)
            {
                AddMinionTown(minionTownInfo, sqlConnection);
                TownId = IsMinionTownExist(minionTownInfo, sqlConnection);

                Console.WriteLine($"Town {minionTownInfo} was added to the database.");
            }

             AddMinionIntoDB(minionName, minionAge, TownId, sqlConnection);

            string minionID = GetMinionId(minionName, sqlConnection);

            SetMinionToBeServantOfTheVillain(minionID, villainId, sqlConnection);

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static void SetMinionToBeServantOfTheVillain(string minionId, string villainId, SqlConnection sqlConnection)
        {
            string servantQuery = 
                @"INSERT INTO MinionsVillains (MinionId, VillainId)         
                    VALUES (@villainId, @minionId)";
            SqlCommand servantCommand = new SqlCommand(servantQuery, sqlConnection);
            servantCommand.Parameters.AddRange(new[]
            {
                new SqlParameter("@villainId", villainId),
                new SqlParameter("@minionId", minionId)
            });

            servantCommand.ExecuteNonQuery();
        }

        private static string GetMinionId(string minionName, SqlConnection sqlConnection)
        {
            string minionIdQuery = @"SELECT Id FROM Minions WHERE Name = @Name";
            SqlCommand minionIdCmd = new SqlCommand(minionIdQuery, sqlConnection);
            minionIdCmd.Parameters.AddWithValue("@Name", minionName);

            string minionId = minionIdCmd.ExecuteScalar()?.ToString();

            return minionId;
        }

        private static string GetVillainId(string villanName, SqlConnection sqlConnection)
        {
            string villainIdQuery = @"SELECT Id FROM Villains WHERE Name = @Name";
            SqlCommand villainIdCmd = new SqlCommand(villainIdQuery, sqlConnection);
            villainIdCmd.Parameters.AddWithValue("@Name", villanName);

            string villainId = villainIdCmd.ExecuteScalar()?.ToString();

            return villainId;
        }

        private static void AddVillainIntoDB(string villainName, SqlConnection sqlConnection)
        {
            string addVillainQuery = 
                @"INSERT INTO Villains (Name, EvilnessFactorId)  
                    VALUES (@villainName, 4)";
            using SqlCommand addVillain = new SqlCommand(addVillainQuery, sqlConnection);
            addVillain.Parameters.AddWithValue("@villainName", villainName);

            addVillain.ExecuteNonQuery();
        }

        static void AddMinionIntoDB(string minionName, string minionAge, string minionTownInfo, SqlConnection sqlConnection)
        {
            string addMinionQuery =
                @"INSERT INTO Minions (Name, Age, TownId) 
                    VALUES (@name, @age, @townId)";

            using SqlCommand addNewMinion = new SqlCommand(addMinionQuery, sqlConnection);
            addNewMinion.Parameters.AddRange(new[]
            {
                new SqlParameter("@name", minionName),
                new SqlParameter("@age", minionAge),
                new SqlParameter("@townId", minionTownInfo)
            });

            addNewMinion.ExecuteNonQuery();
        }

        private static string IsMinionTownExist(string minionTown, SqlConnection sqlConnection)
        {
            string sqlVillainCommandQuery = @"SELECT Id FROM Towns WHERE Name = @townName";
            using SqlCommand MinionTownCommand = new SqlCommand(sqlVillainCommandQuery, sqlConnection);
            MinionTownCommand.Parameters.AddWithValue("@townName", minionTown);

            string isMinionTownExist = MinionTownCommand.ExecuteScalar()?.ToString();

            return isMinionTownExist;
        }

        private static void AddMinionTown(string minionTown, SqlConnection sqlConnection)
        {
            string addTownQuery = 
                @"INSERT INTO Towns (Name) 
                    VALUES (@townName)";

            using SqlCommand addMinionTownCmd = new SqlCommand(addTownQuery, sqlConnection);
            addMinionTownCmd.Parameters.AddWithValue("@townName", minionTown);

            addMinionTownCmd.ExecuteNonQuery();
        }
    }
}
