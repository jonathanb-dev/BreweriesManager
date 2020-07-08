using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            List<Brewery> breweries = GetBreweries();
            List<Wholesaler> wholesalers = GetWholesalers();
            List<Beer> beers = GetBeers();

            if (!context.Breweries.Any())
            {
                context.Breweries.AddRange(breweries);
            }

            if (!context.Wholesalers.Any())
            {
                context.Wholesalers.AddRange(wholesalers);
            }

            if (!context.Beers.Any())
            {
                context.Beers.AddRange(beers);
            }

            if (context.ChangeTracker.HasChanges())
            {
                context.SaveChanges();
            }
        }

        private static List<Brewery> GetBreweries()
        {
            return new List<Brewery>
                {
                    new Brewery
                    {
                        Name = "Abbaye de Grimbergen",
                    },
                    new Brewery
                    {
                        Name = "Abbaye de Leffe"
                    },
                    new Brewery
                    {
                        Name = "Abbaye de Chimay"
                    }
                };
        }

        private static List<Wholesaler> GetWholesalers()
        {
            return new List<Wholesaler>
                {
                    new Wholesaler
                    {
                        Name = "Grossiste A"
                    },
                    new Wholesaler
                    {
                        Name = "Grossiste B"
                    },
                    new Wholesaler
                    {
                        Name = "Grossiste C"
                    }
                };
        }

        private static List<Beer> GetBeers()
        {
            return new List<Beer>
                {
                    new Beer
                    {
                        Name = "Grimbergen blonde",
                        Price = 2.47M/*,
                        Brewery = GetBreweries().Where(x => x.Name == "").First()*/
                    },
                    new Beer
                    {
                        Name = "Grimbergen brune",
                        Price = 2.59M
                    },
                    new Beer
                    {
                        Name = "Leffe blonde",
                        Price = 2.51M
                    },
                    new Beer
                    {
                        Name = "Leffe brune",
                        Price = 2.63M
                    },
                    new Beer
                    {
                        Name = "Chimay bleue",
                        Price = 2.82M
                    }
                };
        }
    }
}