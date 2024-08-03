using Recap.Interfaces;
using Recap.Models;

namespace Recap.Services;

public class MovieService : IMovieService
{
    private readonly List<Movie> _movies;

    public MovieService()
    {
        _movies = new List<Movie>
        {
            new Movie
            {
                MovieId = 1,
                Title = "Inception",
                Director = "Christopher Nolan",
                Genre = "Sci-Fi",
                ReleaseDate = new DateTime(2010, 7, 16),
                Rating = 8.8,
                DurationInMinutes = 148
            },
            new Movie
            {
                MovieId = 2,
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                Genre = "Crime",
                ReleaseDate = new DateTime(1972, 3, 24),
                Rating = 9.2,
                DurationInMinutes = 175
            },
            new Movie
            {
                MovieId = 3,
                Title = "The Dark Knight",
                Director = "Christopher Nolan",
                Genre = "Action",
                ReleaseDate = new DateTime(2008, 7, 18),
                Rating = 9.0,
                DurationInMinutes = 152
            },
            new Movie
            {
                MovieId = 4,
                Title = "Pulp Fiction",
                Director = "Quentin Tarantino",
                Genre = "Crime",
                ReleaseDate = new DateTime(1994, 10, 14),
                Rating = 8.9,
                DurationInMinutes = 154
            },
            new Movie
            {
                MovieId = 5,
                Title = "Schindler's List",
                Director = "Steven Spielberg",
                Genre = "Biography",
                ReleaseDate = new DateTime(1993, 12, 15),
                Rating = 8.9,
                DurationInMinutes = 195
            },
            new Movie
            {
                MovieId = 6,
                Title = "The Shawshank Redemption",
                Director = "Frank Darabont",
                Genre = "Drama",
                ReleaseDate = new DateTime(1994, 9, 23),
                Rating = 9.3,
                DurationInMinutes = 142
            },
            new Movie
            {
                MovieId = 7,
                Title = "Forrest Gump",
                Director = "Robert Zemeckis",
                Genre = "Drama",
                ReleaseDate = new DateTime(1994, 7, 6),
                Rating = 8.8,
                DurationInMinutes = 142
            },
            new Movie
            {
                MovieId = 8,
                Title = "Fight Club",
                Director = "David Fincher",
                Genre = "Drama",
                ReleaseDate = new DateTime(1999, 10, 15),
                Rating = 8.8,
                DurationInMinutes = 139
            },
            new Movie
            {
                MovieId = 9,
                Title = "The Matrix",
                Director = "Lana Wachowski, Lilly Wachowski",
                Genre = "Sci-Fi",
                ReleaseDate = new DateTime(1999, 3, 31),
                Rating = 8.7,
                DurationInMinutes = 136
            },
            new Movie
            {
                MovieId = 10,
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Director = "Peter Jackson",
                Genre = "Fantasy",
                ReleaseDate = new DateTime(2001, 12, 19),
                Rating = 8.8,
                DurationInMinutes = 178
            }
        };
    }

    public void AddMovie(Movie movie)
    {
        // programmatically increment highest ID
        movie.MovieId = _movies.Max(m => m.MovieId) + 1;
        _movies.Add(movie);
    }

    public List<Movie> GetMovies()
    {
        return _movies;
    }
}
