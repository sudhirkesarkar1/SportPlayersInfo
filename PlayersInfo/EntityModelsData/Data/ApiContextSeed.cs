using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using PlayersInfo.EntityModelsData.Models.Entities;
using Microsoft.Extensions.Logging;

namespace PlayersInfo.EntityModelsData.Data
{
    public class ApiContextSeed
    {
        public static async Task SeedAsync(ApiDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Countries.Any())
                {
                    var countriesData =
                        File.ReadAllText("./EntityModelsData/Data/SeedData/Countries.json");

                    var countries = JsonSerializer.Deserialize<List<Country>>(countriesData);

                    foreach (var country in countries)
                    {
                        context.Countries.Add(country);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Games.Any())
                {
                    var gamesData =
                        File.ReadAllText("./EntityModelsData/Data/SeedData/Games.json");

                    var games = JsonSerializer.Deserialize<List<Game>>(gamesData);

                    foreach (var game in games)
                    {
                        context.Games.Add(game);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Players.Any())
                {
                    var playersData =
                        File.ReadAllText("./EntityModelsData/Data/SeedData/Players.json");

                    var players = JsonSerializer.Deserialize<List<Player>>(playersData);

                    foreach (var player in players)
                    {
                        context.Players.Add(player);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ApiDbContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}