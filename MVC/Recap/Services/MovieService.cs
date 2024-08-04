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
                DurationInMinutes = 148,
                ImagePath = "images/inception.webp"
            },
            new Movie
            {
                MovieId = 2,
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                Genre = "Crime",
                ReleaseDate = new DateTime(1972, 3, 24),
                Rating = 9.2,
                DurationInMinutes = 175,
                ImagePath = "images/godfather.jpg"
            },
            new Movie
            {
                MovieId = 3,
                Title = "The Dark Knight",
                Director = "Christopher Nolan",
                Genre = "Action",
                ReleaseDate = new DateTime(2008, 7, 18),
                Rating = 9.0,
                DurationInMinutes = 152,
                ImagePath = "images/dark-knight.jpg"
            },
            new Movie
            {
                MovieId = 4,
                Title = "Pulp Fiction",
                Director = "Quentin Tarantino",
                Genre = "Crime",
                ReleaseDate = new DateTime(1994, 10, 14),
                Rating = 8.9,
                DurationInMinutes = 154,
                ImagePath = "images/pulp-fiction.jpg"
            },
            new Movie
            {
                MovieId = 5,
                Title = "Schindler's List",
                Director = "Steven Spielberg",
                Genre = "Biography",
                ReleaseDate = new DateTime(1993, 12, 15),
                Rating = 8.9,
                DurationInMinutes = 195,
                ImagePath = "images/schindlers-list.jpg"
            },
            new Movie
            {
                MovieId = 6,
                Title = "The Shawshank Redemption",
                Director = "Frank Darabont",
                Genre = "Drama",
                ReleaseDate = new DateTime(1994, 9, 23),
                Rating = 9.3,
                DurationInMinutes = 142,
                ImagePath = "images/shawshank.png"
            },
            new Movie
            {
                MovieId = 7,
                Title = "Forrest Gump",
                Director = "Robert Zemeckis",
                Genre = "Drama",
                ReleaseDate = new DateTime(1994, 7, 6),
                Rating = 8.8,
                DurationInMinutes = 142,
                ImagePath = "images/forrest-gump.jpg"
            },
            new Movie
            {
                MovieId = 8,
                Title = "Fight Club",
                Director = "David Fincher",
                Genre = "Drama",
                ReleaseDate = new DateTime(1999, 10, 15),
                Rating = 8.8,
                DurationInMinutes = 139,
                ImagePath = "images/fight-club.jpg"
            },
            new Movie
            {
                MovieId = 9,
                Title = "The Matrix",
                Director = "Lana Wachowski, Lilly Wachowski",
                Genre = "Sci-Fi",
                ReleaseDate = new DateTime(1999, 3, 31),
                Rating = 8.7,
                DurationInMinutes = 136,
                ImagePath = "images/the-matrix.webp"
            },
            new Movie
            {
                MovieId = 10,
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Director = "Peter Jackson",
                Genre = "Fantasy",
                ReleaseDate = new DateTime(2001, 12, 19),
                Rating = 8.8,
                DurationInMinutes = 178,
                ImagePath = "images/lord-of-the-rings.jpg"
            },
            new Movie
            {
                MovieId = 11,
                Title = "Halloween",
                Director = "John Carpenter",
                Genre = "Horror",
                ReleaseDate = new DateTime(1978, 10, 25),
                Rating = 7.7,
                DurationInMinutes = 91,
                ImagePath = "images/halloween.jpg"
            },
            new Movie
            {
                MovieId = 12,
                Title = "Evil Dead",
                Director = "Sam Raimi",
                Genre = "Horror",
                ReleaseDate = new DateTime(1981, 10, 15),
                Rating = 7.4,
                DurationInMinutes = 91,
                ImagePath = "images/evil-dead.jpg"
            },
            new Movie
            {
                MovieId = 13,
                Title = "Jackie Brown",
                Director = "Quentin Tarantino",
                Genre = "Crime",
                ReleaseDate = new DateTime(1997, 12, 25),
                Rating = 8.3,
                DurationInMinutes = 154,
                ImagePath = "images/jackie-brown.jpg"
            },
            new Movie
            {
                MovieId = 14,
                Title = "Jaws",
                Director = "Steven Spielberg",
                Genre = "Thriller",
                ReleaseDate = new DateTime(1975, 06, 20),
                Rating = 8.9,
                DurationInMinutes = 130,
                ImagePath = "images/jaws.webp"
            },
            new Movie
            {
                MovieId = 15,
                Title = "Breakfast at Tiffany's",
                Director = "Blake Edwards",
                Genre = "Romance",
                ReleaseDate = new DateTime(1961, 10, 05),
                Rating = 7.6,
                DurationInMinutes = 115,
                ImagePath = "images/breakfast.jpg"
            },
             new Movie
            {
                MovieId = 16,
                Title = "Upgrade",
                Director = "Leigh Whannell",
                Genre = "Thriller",
                ReleaseDate = new DateTime(2018, 06, 01),
                Rating = 7.5,
                DurationInMinutes = 100,
                ImagePath = "images/upgrade.jpg"
            },
               new Movie
            {
                MovieId = 17,
                Title = "Blade Runner 2049",
                Director = "Denis Villeneuve",
                Genre = "Sci-fi",
                ReleaseDate = new DateTime(2017, 10, 06),
                Rating = 9,
                DurationInMinutes = 163,
                ImagePath = "images/blade-runner.png"
            },
             new Movie
            {
                MovieId = 18,
                Title = "Mother!",
                Director = "Darren Aronofsky",
                Genre = "Sci-fi",
                ReleaseDate = new DateTime(2017, 09, 15),
                Rating = 6.6,
                DurationInMinutes = 121,
                ImagePath = "images/mother.webp"
            },

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
