using System;
using System.Collections.Generic;

using Microsoft.Data.SqlClient;

namespace _05.ChangeTownNamesCasing
{
    public class StartUp
    {
        private const string MinionsDbConnectionString = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            using SqlConnection sqlConnection = new SqlConnection(MinionsDbConnectionString);
            sqlConnection.Open();

            string affectedRows = ChangeTownNames(countryName, sqlConnection);
            Console.WriteLine($"{affectedRows} town names were affected.");

            List<string> changedNames = GiveChangedNames(countryName, sqlConnection);
            Console.WriteLine($"[{string.Join(", ", changedNames)}]");
        }

        private static List<string> GiveChangedNames(string countryName, SqlConnection sqlConnection)
        {
            List<string> names = new List<string>();

            string giveChangedNamesQuery = 
                @"SELECT t.Name 
                    FROM Towns as t
                    JOIN Countries AS c ON c.Id = t.CountryCode
                    WHERE c.Name = @countryName";
            using SqlCommand giveChangedNamesCmd = new SqlCommand(giveChangedNamesQuery, sqlConnection);
            giveChangedNamesCmd.Parameters.AddWithValue("@countryName", countryName);

            SqlDataReader name = giveChangedNamesCmd.ExecuteReader();

            while (name.Read())
            {
                names.Add(name["Name"].ToString());
            }

            return names;
        }

        private static string ChangeTownNames(string countryName, SqlConnection sqlConnection)
        {
            string changeNameCmdQuery =
                @"UPDATE Towns
                    SET Name = UPPER(Name)
                    WHERE CountryCode = (
                                         SELECT c.Id 
                                         FROM Countries AS c 
                                         WHERE c.Name = @countryName
                                        )";

            using SqlCommand changeNamesCmd = new SqlCommand(changeNameCmdQuery, sqlConnection);
            changeNamesCmd.Parameters.AddWithValue("@countryName", countryName);

            string affectedRows = changeNamesCmd.ExecuteNonQuery().ToString();

            return affectedRows;
        }
    }
}
