namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Data;
    using Newtonsoft.Json;

    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            var games = JsonConvert.DeserializeObject<IEnumerable<ImportGameJsonModel>>(jsonString);

            foreach (var gameJson in games)
            {
                if (!IsValid(gameJson))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var game = new Game
                {
                    Name = gameJson.Name,
                    Price = gameJson.Price,
                    ReleaseDate = gameJson.ReleaseDate.Value,
                    Developer = context.Developers.FirstOrDefault(d => d.Name == gameJson.Developer) ?? new Developer { Name = gameJson.Developer },
                    Genre = context.Genres.FirstOrDefault(g => g.Name == gameJson.Genre) ?? new Genre { Name = gameJson.Genre }
                };

                foreach (var tagJson in gameJson.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(t => t.Name == tagJson) ?? new Tag { Name = tagJson };

                    game.GameTags.Add(new GameTag { Tag = tag });
                }

                context.Games.Add(game);
                context.SaveChanges();

                output.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Select(t => t.Tag).Count()} tags");

            }


            return output.ToString();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var output = new StringBuilder();

            var usersJson = JsonConvert.DeserializeObject<IEnumerable<ImportUserJsonModel>>(jsonString);

            foreach (var userJson in usersJson)
            {
                if (!IsValid(userJson))
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User
                {
                    FullName = userJson.FullName,
                    Username = userJson.Username,
                    Email = userJson.Email,
                    Age = userJson.Age
                };

                foreach (var cardJson in userJson.Cards)
                {
                    if (!IsValid(cardJson))
                    {
                        output.AppendLine("Invalid Data");
                        continue;
                    }

                    user.Cards.Add(new Card
                    {
                        Number = cardJson.Number,
                        Cvc = cardJson.CVC,
                        Type = cardJson.Type
                    });


                }

                if (user.Cards.Any())
                {
                    context.Users.Add(user);
                    context.SaveChanges();

                    output.AppendLine($"Imported {user.Username} with {user.Cards.Count()} cards");
                }

            }

            return output.ToString();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            const string root = "Purchases";
            var xmlSerializer = new XmlSerializer(typeof(ImportPurchasesXmlModel[]), new XmlRootAttribute(root));

            var readReader = new StringReader(xmlString);

            var purchasesDto = xmlSerializer.Deserialize(readReader) as ImportPurchasesXmlModel[];

            var output = new StringBuilder();
            foreach (var purchaseDto in purchasesDto)
            {
                if (!IsValid(purchaseDto))
                {
                    output.AppendLine("Invalid Data");
                }

                var game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.GameName);
                var card = context.Cards.FirstOrDefault(g => g.Number == purchaseDto.CardNumber);
                var IsEnumValid = Enum.TryParse<PurchaseType>(purchaseDto.Type, out PurchaseType key);

                if (game == null || card == null || IsEnumValid == false)
                {
                    output.AppendLine("Invalid Data");
                    continue;
                }

                var purchase = new Purchase
                {
                    Type = key,
                    ProductKey = purchaseDto.Key,
                    Card = card,
                    Game = game,
                    Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                };

                context.Purchases.Add(purchase);
                context.SaveChanges();

                output.AppendLine($"Imported {purchaseDto.GameName} for {purchase.Card.User.Username}");
            }

            return output.ToString();

        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}