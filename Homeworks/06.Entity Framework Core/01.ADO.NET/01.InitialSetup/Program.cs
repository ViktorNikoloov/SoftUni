using System;
using Microsoft.Data.SqlClient;

namespace _01.InitialSetup
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection masterSqlConnection = new SqlConnection("Server=.\\SQLEXPRESS;Database=master;Integrated Security=true;"))
            {
                masterSqlConnection.Open();
                SqlCommand createmMinionsDB = new SqlCommand("create database MinionsDB", masterSqlConnection);
                createmMinionsDB.ExecuteNonQuery();
            }

            using (SqlConnection minionsDbSqlConnection = new SqlConnection("Server=.\\SQLEXPRESS;Database=MinionsDB;Integrated security=true;"))
            {
                minionsDbSqlConnection.Open();

                foreach (var query in GetCreateTableStatments())
                {
                    ExecuteNonQuery(query, minionsDbSqlConnection);
                }

                foreach (var query in GetInsertTableStatments())
                {
                    ExecuteNonQuery(query, minionsDbSqlConnection);
                }
            }

        }

        private static string[] GetCreateTableStatments()
        {
            string[] result = new string[]
            {
                "CREATE TABLE Countries " +
                "(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))",

                "CREATE TABLE Towns" +
                "(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT REFERENCES Countries(Id))",

                "CREATE TABLE Minions" +
                "(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT REFERENCES Towns(Id))",

                "CREATE TABLE EvilnessFactors" +
                "(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))",

                "CREATE TABLE Villains " +
                "(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT REFERENCES EvilnessFactors(Id))",

                "CREATE TABLE MinionsVillains " +
                "(MinionId INT REFERENCES Minions(Id),VillainId INT REFERENCES Villains(Id),PRIMARY KEY(MinionId, VillainId))"
            };

            return result;
        }

        private static string[] GetInsertTableStatments()
        {
            string[] statemets = new string[]
            {
                "INSERT INTO Countries ([Name]) VALUES " +
                "('Bulgaria')," +
                "('England')," +
                "('Cyprus')," +
                "('Germany')," +
                "('Norway')",

                "INSERT INTO Towns ([Name], CountryCode) VALUES " +
                "('Plovdiv', 1)," +
                "('Varna', 1)," +
                "('Burgas', 1)," +
                "('Sofia', 1)," +
                "('London', 2)," +
                "('Southampton', 2)," +
                "('Bath', 2)," +
                "('Liverpool', 2)," +
                "('Berlin', 3)," +
                "('Frankfurt', 3)," +
                "('Oslo', 4)",

                "INSERT INTO Minions (Name,Age, TownId) VALUES" +
                "('Bob', 42, 3)," +
                "('Kevin', 1, 1)," +
                "('Bob ', 32, 6)," +
                "('Simon', 45, 3)," +
                "('Cathleen', 11, 2)," +
                "('Carry ', 50, 10)," +
                "('Becky', 125, 5)," +
                "('Mars', 21, 1)," +
                "('Misho', 5, 10)," +
                "('Zoe', 125, 5)," +
                "('Json', 21, 1)",

                "INSERT INTO EvilnessFactors (Name) VALUES " +
                "('Super good')," +
                "('Good')," +
                "('Bad'), " +
                "('Evil')," +
                "('Super evil')",

                "INSERT INTO Villains (Name, EvilnessFactorId) VALUES " +
                "('Gru',2)," +
                "('Victor',1)," +
                "('Jilly',3)," +
                "('Miro',4)," +
                "('Rosen',5)," +
                "('Dimityr',1)," +
                "('Dobromir',2)",

                "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES " +
                "(4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)"
            };

            return statemets;
        }

        private static void ExecuteNonQuery(string query, SqlConnection connection)
        {
            using (SqlCommand createCommand = new SqlCommand(query, connection))
            {
                createCommand.ExecuteNonQuery();
            }
        }
    }
}
