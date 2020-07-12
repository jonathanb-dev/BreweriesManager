using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistence;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest
{
    public class BeerTest
    {
        [Fact]
        public void GetAsync_ReturnsBeer()
        {
            /*Mock<DataContext> dataContext = new Mock<DataContext>();
            Mock<DbSet<Beer>> beerDbSet = new Mock<DbSet<Beer>>();

            beerDbSet.Setup(x => x.FindAsync(It.IsAny<int>())).Returns(Task.FromResult(new Beer()));*/
        }
    }
}