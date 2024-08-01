using LibroConsoleAPI.Business;
using LibroConsoleAPI.Business.Contracts;
using LibroConsoleAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroConsoleAPI.IntegrationTests.XUnit
{
    public class GetAllBooksMethodTests : IClassFixture<BookManagerFixture>
    {
        private readonly BookManager _bookManager;
        private readonly TestLibroDbContext _dbContext;

        public GetAllBooksMethodTests(BookManagerFixture fixture)
        {
            _bookManager = fixture.BookManager;
            _dbContext = fixture.DbContext;
        }

        [Fact]
        public async Task GetAllBooksAsync_ShouldReturnAllBook()
        {
            //Arrange
            await DatabaseSeeder.SeedDatabaseAsync( _dbContext, _bookManager);

            //Act
            var result = _bookManager.GetAllAsync();

            //Assert


        }
    }
}
