namespace VaporStore.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var data = context
                .Genres
                .ToList()
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games.Select(ga => new
                    {
                        Id = ga.Id,
                        Title = ga.Name,
                        Developer = ga.Developer.Name,
                        Tags = string.Join(", ", ga.GameTags.Select(t => t.Tag.Name)),
                        Players = ga.Purchases.Count()
                    })
                    .Where(g=>g.Players > 0)
                    .OrderByDescending(x => x.Players)
                    .ThenBy(x => x.Id),
                    TotalPlayers = g.Games.Sum(p => p.Purchases.Count)
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToList();
                
            var jsonGames = JsonConvert.SerializeObject(data, Formatting.Indented);

            return jsonGames;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var data = context
                .Users
                .Where(u => u.Cards.Any(p => p.Purchases.Any()))
                .Select(u => new UserModel()
                {
                    Username = u.Username,
                    Purchases = u.Cards
                        .Where(p => p.Purchases.Any(t => t.Type.ToString() == storeType))
                        .Select(p => new UserPurchasesModel()
                        {
                            Card = p.Number,
                            Cvc = p.Cvc,
                            Date = DateTime.Parse(p.Purchases.Select(x => x.Date).ToString()),
                            Game = p.Purchases.Select(g => new UserPurchasesGameModel()
                            {
                                Title = g.Game.Name,
                                Genre = g.Game.Genre.ToString(),
                                Price = g.Game.Price
                            })
                             .ToArray()

                        })
                        .OrderByDescending(x=>x.Date)
                        .ToArray(),
                    TotalSpent = u.Cards
                   .Sum(p => p.Purchases.Where(p => p.Type.ToString() == storeType)
                   .Sum(g => g.Game.Price))


                })
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.Username)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserModel[]), new XmlRootAttribute("Users"));
            var textWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");


            xmlSerializer.Serialize(textWriter, data, ns);

            return textWriter.ToString().TrimEnd();
        }
    }
}