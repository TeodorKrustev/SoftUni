using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class GetSpecificMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly IBookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public GetSpecificMethodTests(BookManagerFixture fixture)
        {
            _bookManager = fixture.BookManager;
            _dbContext = fixture.DbContext;
        }

        [Fact]
        public async Task GetSpecificAsync_ShouldReturnCorrectElement()
        {
            //Arrange
            await DatabaseSeeder.SeedDatabaseAsync(_dbContext, (Business.BookManager)_bookManager);
            //Act
            var result = _bookManager.GetSpecificAsync("9780307743394");
            //Assert
            Assert.Equal("9780307743394", result.ISBN);
        }
    }
}
