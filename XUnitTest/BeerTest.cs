using Domain.Models;
using Domain.Repos;
using Domain.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest
{
    public class BeerTest
    {
        private readonly IService<Beer> _service;

        public BeerTest()
        {
            Mock<IRepository<Beer>> beerRepo = new Mock<IRepository<Beer>>();

            List<Beer> beers = new List<Beer>()
            {
                new Beer
                {
                    Id = 1,
                    Name = "Test 1",
                    Price = 2.86M
                },
                new Beer
                {
                    Id = 2,
                    Name = "Test 2",
                    Price = 2.63M
                },
                new Beer
                {
                    Id = 3,
                    Name = "Test 3",
                    Price = 2.41M
                }
            };

            beerRepo.Setup(repo => repo.ListAsync()).ReturnsAsync(beers);

            beerRepo.Setup(repo => repo.GetAsync(It.IsAny<int>())).ReturnsAsync((int i) => beers.AsEnumerable().SingleOrDefault(x => x.Id == i));

            beerRepo.Setup(repo => repo.Add(It.IsAny<Beer>()))
                .Callback((Beer beer) =>
                {
                    beer.Id = beers.Count() + 1;
                    beers.Add(beer);
                }).Verifiable();

            beerRepo.Setup(repo => repo.Delete(It.IsAny<int>()))
                .Callback((Beer beer) =>
                {
                    beer.Id = beers.Count() - 1;
                    beers.Remove(beer);
                }).Verifiable();

            beerRepo.SetupAllProperties();

            //_service = new BeerService(beerRepo.Object);
        }

        [Fact]
        public async Task GetBeerById_returnsBeer()
        {
            // Arrange
            const int expected = 1;
            const int id = 1;

            // Act
            Beer beer = await _service.GetAsync(id);

            // Assert
            Assert.Equal(expected, beer.Id);
        }
    }
}