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
            List<Beer> beers = GetBeers(breweries, wholesalers);

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

        private static List<Beer> GetBeers(List<Brewery> breweries, List<Wholesaler> wholesalers)
        {
            return new List<Beer>
                {
                    new Beer
                    {
                        Name = "Grimbergen blonde",
                        Price = 2.47M,
                        Brewery = breweries.AsEnumerable().Where(x => x.Name.Contains("Grimbergen")).First(),
                        WholesalerBeers = new List<WholesalerBeer>()
                            {
                                new WholesalerBeer { Wholesaler = wholesalers.AsEnumerable().Where(x => x.Name.Contains("B")).First(), Stock = 7 }
                            }
                    },
                    new Beer
                    {
                        Name = "Grimbergen brune",
                        Price = 2.59M,
                        Brewery = breweries.AsEnumerable().Where(x => x.Name.Contains("Grimbergen")).First(),
                        WholesalerBeers = new List<WholesalerBeer>()
                            {
                                new WholesalerBeer { Wholesaler = wholesalers.AsEnumerable().Where(x => x.Name.Contains("A")).First(), Stock = 4 },
                                new WholesalerBeer { Wholesaler = wholesalers.AsEnumerable().Where(x => x.Name.Contains("C")).First(), Stock = 9 }
                            }
                    },
                    new Beer
                    {
                        Name = "Leffe blonde",
                        Price = 2.51M,
                        Brewery = breweries.AsEnumerable().Where(x => x.Name.Contains("Leffe")).First(),
                        WholesalerBeers = new List<WholesalerBeer>()
                            {
                                new WholesalerBeer { Wholesaler = wholesalers.AsEnumerable().Where(x => x.Name.Contains("A")).First(), Stock = 13 },
                                new WholesalerBeer { Wholesaler = wholesalers.AsEnumerable().Where(x => x.Name.Contains("B")).First(), Stock = 19 }
                            }
                    },
                    new Beer
                    {
                        Name = "Leffe brune",
                        Price = 2.63M,
                        Brewery = breweries.AsEnumerable().Where(x => x.Name.Contains("Leffe")).First(),
                        WholesalerBeers = new List<WholesalerBeer>()
                            {
                                new WholesalerBeer { Wholesaler = wholesalers.AsEnumerable().Where(x => x.Name.Contains("C")).First(), Stock = 5 }
                            }
                    },
                    new Beer
                    {
                        Name = "Chimay bleue",
                        Price = 2.82M,
                        Brewery = breweries.AsEnumerable().Where(x => x.Name.Contains("Chimay")).First(),
                        WholesalerBeers = new List<WholesalerBeer>()
                            {
                                new WholesalerBeer { Wholesaler = wholesalers.AsEnumerable().Where(x => x.Name.Contains("C")).First(), Stock = 3 }
                            }
                    }
                };
        }
    }
}