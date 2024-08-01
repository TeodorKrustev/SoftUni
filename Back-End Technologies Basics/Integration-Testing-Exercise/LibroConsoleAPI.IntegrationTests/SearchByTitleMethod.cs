using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class SearchByTitleMethod : IClassFixture<BookManagerFixture>
    {
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public SearchByTitleMethod(BookManagerFixture fixture)
        {
            _bookManager = fixture.BookManager;
            _dbContext = fixture.DbContext;
        }

        [Fact]
        public async Task SearchByTitle_ShouldReturnCorrectBook()
        {
            //Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, _bookManager);
            //Act
            var result = await _bookManager.SearchByTitleAsync("Pride and Prejudice");
            //Assert
            Assert.Equal("Pride and Prejudice", result.FirstOrDefault().Title);
        }
    }
}
