namespace VaporStore.DataProcessor
{
    using System;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;

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
            return "TODO";
        }
    }
}