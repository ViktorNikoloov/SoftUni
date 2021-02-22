using System;
using System.Collections.Generic;

using Microsoft.Data.SqlClient;

namespace _07.PrintAllMinionNames
{
    public class StartUp
    {
        private const string MinionsDbConnectionString = @"Server=.\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;";

        static void Main(string[] args)
        {
           using SqlConnection sqlConnection = new SqlConnection(MinionsDbConnectionString);
            sqlConnection.Open();

            List<string> allMinionsNames = GiveAllMinionNames(sqlConnection);
            PrintNamesByCondition(allMinionsNames);
        }

        private static void PrintNamesByCondition(List<string> allMinionsNames)
        {
            /*prints all minion names from the minions table in the following order: 
            first record, last record, first + 1, last - 1, first + 2, last - 2 … first + n, last - n.*/

            int namesCount = allMinionsNames.Count;
            int index = 0;

            for (int i = 0; i < namesCount / 2; i++)
            {
                Console.WriteLine(allMinionsNames[index]);
                Console.WriteLine(allMinionsNames[namesCount - index - 1]);

                index++;
            }

            if (namesCount % 2 != 0)
            {
                Console.WriteLine(allMinionsNames[namesCount / 2]);
            }

        }

        private static List<string> GiveAllMinionNames(SqlConnection sqlConnection)
        {
            List<string> minionNames = new List<string>();

            string allMinionNamesQuery = 
                @"SELECT Name 
                    FROM Minions";
            using SqlCommand allMinionNamesCmd = new SqlCommand(allMinionNamesQuery, sqlConnection);

            using SqlDataReader currName = allMinionNamesCmd.ExecuteReader();
            while (currName.Read())
            {
                minionNames.Add(currName["Name"].ToString());
            }

            return minionNames;
        }
    }
}
