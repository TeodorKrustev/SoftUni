using MongoDB.Driver;
using MoviesLibraryAPI.Controllers;
using MoviesLibraryAPI.Controllers.Contracts;
using MoviesLibraryAPI.Data.Models;
using MoviesLibraryAPI.Services;
using MoviesLibraryAPI.Services.Contracts;
using System.ComponentModel.DataAnnotations;

namespace MoviesLibraryAPI.XUnitTests
{
    public class XUnitIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly MoviesLibraryXUnitTestDbContext _dbContext;
        private readonly IMoviesLibraryController _controller;
        private readonly IMoviesRepository _repository;

        public XUnitIntegrationTests(DatabaseFixture fixture)
        {
            _dbContext = fixture.DbContext;
            _repository = new MoviesRepository(_dbContext.Movies);
            _controller = new MoviesLibraryController(_repository);

            InitializeDatabaseAsync().GetAwaiter().GetResult();
        }

        private async Task InitializeDatabaseAsync()
        {
            await _dbContext.ClearDatabaseAsync();
        }

        [Fact]
        public async Task AddMovieAsync_WhenValidMovieProvided_ShouldAddToDatabase()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 120,
                Rating = 7.5
            };

            // Act
            await _controller.AddAsync(movie);

            // Assert
            var resultMovie = await _dbContext.Movies.Find(m => m.Title == "Test Movie").FirstOrDefaultAsync();
            Xunit.Assert.NotNull(resultMovie);
            Xunit.Assert.Equal("Test Movie", resultMovie.Title);
            Xunit.Assert.Equal("Test Director", resultMovie.Director);
            Xunit.Assert.Equal(2022, resultMovie.YearReleased);
            Xunit.Assert.Equal("Action", resultMovie.Genre);
            Xunit.Assert.Equal(120, resultMovie.Duration);
            Xunit.Assert.Equal(7.5, resultMovie.Rating);
        }

        [Fact]
        public async Task AddMovieAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            var invalidMovie = new Movie
            {
                YearReleased = 2022,
                Genre = "Action",
                Duration = 120,
                Rating = 7.5
            };

            // Act and Assert
            var exception = await Xunit.Assert.ThrowsAsync<ValidationException>(() => _controller.AddAsync(invalidMovie));
            Xunit.Assert.Equal("Movie is not valid.", exception.Message);
        }

        [Fact]
        public async Task DeleteAsync_WhenValidTitleProvided_ShouldDeleteMovie()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };
            await _controller.AddAsync(movie);

            //Act
            await _controller.DeleteAsync(movie.Title);

            // Assert
            var resultMovie = await _dbContext.Movies.Find(m => m.Title == movie.Title).FirstOrDefaultAsync();
            Assert.Null(resultMovie);
        }
        
        [Xunit.Theory]
        [Xunit.InlineData(null)]
        [Xunit.InlineData("")]
        [Xunit.InlineData(" ")]
        public async Task DeleteAsync_WhenTitleIsNull_ShouldThrowArgumentException(string invalidName)
        {
            // Act and Assert
            Xunit.Assert.ThrowsAsync<ArgumentException>(() => _controller.DeleteAsync(invalidName));
        }

        [Fact]
        public async Task DeleteAsync_WhenTitleDoesNotExist_ShouldThrowInvalidOperationException()
        {
            // Act and Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _controller.DeleteAsync("invalid Name"));
            
        }

        [Fact]
        public async Task GetAllAsync_WhenNoMoviesExist_ShouldReturnEmptyList()
        {
            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetAllAsync_WhenMoviesExist_ShouldReturnAllMovies()
        { 
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

        await _controller.AddAsync(movie);

        var secondMovie = new Movie
        {
            Title = "Dune",
            Director = "Great Director",
            YearReleased = 2022,
            Genre = "Action",
            Duration = 200,
            Rating = 9.1
        };

        await _controller.AddAsync(secondMovie);

        //Act
        var result = await _controller.GetAllAsync();

        // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByTitle_WhenTitleExists_ShouldReturnMatchingMovie()
        {
            
        // Arrange
        var firstMovie = new Movie
        {
            Title = "Test Movie",
            Director = "Test Director",
            YearReleased = 2022,
            Genre = "Action",
            Duration = 86,
            Rating = 7.5
        };

        var secondMovie = new Movie
        {
            Title = "Dune",
            Director = "Great Director",
            YearReleased = 2022,
            Genre = "Action",
            Duration = 200,
            Rating = 9.1
        };

                await _dbContext.Movies.InsertManyAsync(new[] { firstMovie, secondMovie });

            //Act
            var result = await _controller.GetByTitle(firstMovie.Title);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(firstMovie.Title, result.Title);
            Assert.Equal(firstMovie.Director, result.Director);
            Assert.Equal(firstMovie.YearReleased, result.YearReleased);
            Assert.Equal(firstMovie.Genre, result.Genre);
            Assert.Equal(firstMovie.Duration, result.Duration);
            Assert.Equal(firstMovie.Rating, result.Rating);
        }

        [Fact]
        public async Task GetByTitle_WhenTitleDoesNotExist_ShouldReturnNull()
        {
            // Act
            var result = await _controller.GetByTitle("Without Title");

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public async Task SearchByTitleFragmentAsync_WhenTitleFragmentExists_ShouldReturnMatchingMovies()
        {
            // Arrange
            var firstMovie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            var secondMovie = new Movie
            {
                Title = "Dune",
                Director = "Great Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 200,
                Rating = 9.1
            };

            await _dbContext.Movies.InsertManyAsync(new[] { firstMovie, secondMovie });

            // Act
            var result = await _controller.SearchByTitleFragmentAsync("Test Movie");

            // Assert // Should return one matching movie
            Assert.Equal(1, result.Count());
            var movieResult = result.First();
            Assert.Equal(firstMovie.Title, movieResult.Title);
        }

        [Fact]
        public async Task SearchByTitleFragmentAsync_WhenNoMatchingTitleFragment_ShouldThrowKeyNotFoundException()
        {
            // Act and Assert
            Assert.ThrowsAsync<KeyNotFoundException>(() => _controller.SearchByTitleFragmentAsync("No Matching Fragment"));
        }

        [Fact]
        public async Task UpdateAsync_WhenValidMovieProvided_ShouldUpdateMovie()
        {
            // Arrange
            var movie = new Movie
            {
                Title = "Test Movie",
                Director = "Test Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            var secondMovie = new Movie
            {
                Title = "Dune",
                Director = "Great Director",
                YearReleased = 2022,
                Genre = "Action",
                Duration = 200,
                Rating = 9.1
            };

            await _dbContext.Movies.InsertManyAsync(new[] { movie, secondMovie });

            // Modify
            var movieToUpdate = await _dbContext.Movies.Find(x => x.Title == movie.Title).FirstOrDefaultAsync();

            movieToUpdate.Title = "Test Movie UPDATED";
            movieToUpdate.Rating = 10;

            // Act
            await _controller.UpdateAsync(movie);

            // Assert
            var updatedMovie = await _dbContext.Movies.Find(x => x.Title == movieToUpdate.Title).FirstOrDefaultAsync();
            Assert.NotNull(updatedMovie);
            Assert.Equal(movieToUpdate.Rating, updatedMovie.Rating);

        }

        [Fact]
        public async Task UpdateAsync_WhenInvalidMovieProvided_ShouldThrowValidationException()
        {
            // Arrange
            // Movie without required fields
            // Arrange
            var invalidMovie = new Movie
            {
                Genre = "Action",
                Duration = 86,
                Rating = 7.5
            };

            // Act and Assert
            Assert.ThrowsAsync<ValidationException>(() => _controller.UpdateAsync(invalidMovie));
        }
    }
}
