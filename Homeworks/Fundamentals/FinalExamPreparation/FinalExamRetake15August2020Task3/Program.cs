using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace FinalExamRetake15August2020Task3
{
    class PieceInformation
    {
        public string Composer { get; set; }
        public string Key { get; set; }

        public PieceInformation(string composer, string key)
        {
            this.Composer = composer;
            this.Key = key;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, PieceInformation> pieces = new Dictionary<string, PieceInformation>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) //{piece}|{composer}|{key}
            {
                string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                PieceInformation information = new PieceInformation(input[1], input[2]);
                pieces.Add(input[0], information);

            }

            string[] commands = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            while (!commands.Contains("Stop"))
            {
                string command = commands[0];
                string piece = commands[1];

                if (command == "Add") //•	Add|{piece}|{composer}|{key} 
                {
                    string composer = commands[2];
                    string key = commands[3];

                    if (!pieces.ContainsKey(piece))
                    {
                        PieceInformation newPieces = new PieceInformation(composer, key);
                        pieces.Add(piece, newPieces);

                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (command == "Remove")
                {
                    if (!pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                    else
                    {
                        pieces.Remove(piece);

                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                }
                else if (command == "ChangeKey")
                {
                    string newKey = commands[2];

                    if (!pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                    else
                    {
                        pieces[piece].Key.Replace(pieces[piece].Key, newKey);

                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }

                }

                commands = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            }

            var sortedPieces = pieces.OrderBy(x => x.Key).OrderByDescending(x => x.Value.Composer).ToDictionary(x => x, y => y);

            //foreach (var item in sortedPieces)
            //{
            //    Console.WriteLine($"{piece.Key} -> Composer: {}, Key: {key}");
            //}
        }

        
    }
}
