using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CinemaApp.Data.Common.EntityValidation.Movie;

namespace CinemaApp.Data.Configuration
{

    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> entity)
        {
            entity
                .HasQueryFilter(m => m.IsDeleted == false);
            entity.HasData(this.SeedMovies());
        }

        private List<Movie> SeedMovies()
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie()
                {
                    Id = Guid.Parse("ae50a5ab-9642-466f-b528-3cc61071bb4c"),
                    Title = "Harry Potter and the Goblet of Fire",
                    Genre = "Fantasy",
                    ReleaseDate = new DateTime(2005, 11, 01),
                    Director = "Mike Newel",
                    Duration = 157,
                    Description = "Harry Potter and the Goblet of Fire is a 2005 fantasy film directed by Mike Newell from a screenplay by Steve Kloves. It is based on the 2000 novel Harry Potter and the Goblet of Fire by J. K. Rowling.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTI1NDMyMjExOF5BMl5BanBnXkFtZTcwOTc4MjQzMQ@@._V1_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("777634e2-3bb6-4748-8e91-7a10b70c78ac"),
                    Title = "Lord of the Rings",
                    Genre = "Fantasy",
                    ReleaseDate = new DateTime(2001, 05, 01),
                    Director = "Peter Jackson",
                    Duration = 178,
                    Description = "The Lord of the Rings: The Fellowship of the Ring is a 2001 epic high fantasy adventure film directed by Peter Jackson from a screenplay by Fran Walsh, Philippa Boyens, and Jackson, based on 1954's The Fellowship of the Ring, the first volume of the novel The Lord of the Rings by J. R. R. Tolkien.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BNzIxMDQ2YTctNDY4MC00ZTRhLTk4ODQtMTVlOWY4NTdiYmMwXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("68fb84b9-ef2a-402f-b4fc-595006f5c275"),
                    Title = "Inception",
                    Genre = "Sci-Fi",
                    ReleaseDate = new DateTime(2010, 07, 16),
                    Director = "Christopher Nolan",
                    Duration = 148,
                    Description = "A thief who enters the dreams of others to steal secrets is given the inverse task: planting an idea into someone's mind.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("02b52bb0-1c2b-49a4-ba66-6d33f81d38d1"),
                    Title = "The Dark Knight",
                    Genre = "Action",
                    ReleaseDate = new DateTime(2008, 07, 18),
                    Director = "Christopher Nolan",
                    Duration = 152,
                    Description = "Batman faces the Joker, who seeks to create chaos in Gotham through psychological warfare.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_FMjpg_UX1000_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("16376cc6-b3e0-4bf7-a0e4-9cbd1490522c"),
                    Title = "Interstellar",
                    Genre = "Sci-Fi",
                    ReleaseDate = new DateTime(2014, 11, 07),
                    Director = "Christopher Nolan",
                    Duration = 169,
                    Description = "A group of explorers travel through a wormhole in space in search of a new habitable planet.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BYzdjMDAxZGItMjI2My00ODA1LTlkNzItOWFjMDU5ZDJlYWY3XkEyXkFqcGc@._V1_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("811a1a9e-61a8-4f6f-acb0-55a252c2b713"),
                    Title = "Avatar",
                    Genre = "Sci-Fi",
                    ReleaseDate = new DateTime(2009, 12, 18),
                    Director = "James Cameron",
                    Duration = 162,
                    Description = "A paraplegic Marine is sent to the moon Pandora on a mission but becomes torn between following orders and protecting an alien civilization.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMDEzMmQwZjctZWU2My00MWNlLWE0NjItMDJlYTRlNGJiZjcyXkEyXkFqcGc@._V1_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("ab2c3213-48a7-41ea-9393-45c60ef813e6"),
                    Title = "Titanic",
                    Genre = "Romance",
                    ReleaseDate = new DateTime(1997, 12, 19),
                    Director = "James Cameron",
                    Duration = 195,
                    Description = "A love story unfolds on the doomed voyage of the Titanic.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BYzYyN2FiZmUtYWYzMy00MzViLWJkZTMtOGY1ZjgzNWMwN2YxXkEyXkFqcGc@._V1_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("844d9abd-104d-41ab-b14a-ce059779ad91"),
                    Title = "The Matrix",
                    Genre = "Sci-Fi",
                    ReleaseDate = new DateTime(1999, 03, 31),
                    Director = "Lana Wachowski, Lilly Wachowski",
                    Duration = 136,
                    Description = "A computer hacker learns about the true nature of his reality and his role in the war against its controllers.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BN2NmN2VhMTQtMDNiOS00NDlhLTliMjgtODE2ZTY0ODQyNDRhXkEyXkFqcGc@._V1_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("54082f99-023b-4d68-89ac-44c00a0958d0"),
                    Title = "Forrest Gump",
                    Genre = "Drama",
                    ReleaseDate = new DateTime(1994, 07, 06),
                    Director = "Robert Zemeckis",
                    Duration = 142,
                    Description = "The story of a man with a kind heart and an incredible life journey.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BNDYwNzVjMTItZmU5YS00YjQ5LTljYjgtMjY2NDVmYWMyNWFmXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("bf9ff8b3-3209-4b18-9f4b-5172c45b73f9"),
                    Title = "Gladiator",
                    Genre = "Action",
                    ReleaseDate = new DateTime(2000, 05, 05),
                    Director = "Ridley Scott",
                    Duration = 155,
                    Description = "A betrayed Roman general seeks revenge against the corrupt emperor who murdered his family and sent him into slavery.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/f/fb/Gladiator_%282000_film_poster%29.png"
                },
                new Movie()
                {
                    Id = Guid.Parse("e00208b1-cb12-4bd4-8ac1-36ab62f7b4c9"),
                    Title = "The Shawshank Redemption",
                    Genre = "Drama",
                    ReleaseDate = new DateTime(1994, 09, 23),
                    Director = "Frank Darabont",
                    Duration = 142,
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMDAyY2FhYjctNDc5OS00MDNlLThiMGUtY2UxYWVkNGY2ZjljXkEyXkFqcGc@._V1_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("4491b6f5-2a11-4c4c-8c6b-c371f47d2152"),
                    Title = "Pulp Fiction",
                    Genre = "Crime",
                    ReleaseDate = new DateTime(1994, 10, 14),
                    Director = "Quentin Tarantino",
                    Duration = 154,
                    Description = "The lives of two hitmen, a boxer, and a gangster intertwine in four tales of violence and redemption.",
                    ImageUrl = "https://www.tallengestore.com/cdn/shop/products/PulpFiction-JohnTravoltaAndSamuelLJackson-MovieStill1_d3db6d19-235a-45aa-97b2-ab690665c224.jpg?v=1684129898"
                },
                new Movie()
                {
                    Id = Guid.Parse("5c7e7b5f-9f2c-4a0f-8a8b-1e5d6c7f8a90"),
                    Title = "The Godfather",
                    Genre = "Crime",
                    ReleaseDate = new DateTime(1972, 03, 24),
                    Director = "Francis Ford Coppola",
                    Duration = 175,
                    Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTFiYzQwNzctY2QzNC00N2EwLTllMzgtYzQxM2Q4YmY4YjQxXkEyXkFqcGc@._V1_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("6d8f8c60-a03d-4b10-9b9c-2f6e7d8a9b01"),
                    Title = "The Silence of the Lambs",
                    Genre = "Thriller",
                    ReleaseDate = new DateTime(1991, 02, 14),
                    Director = "Jonathan Demme",
                    Duration = 118,
                    Description = "A young FBI cadet seeks the help of an imprisoned and manipulative cannibal killer to catch another serial murderer.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BNGFiY2Y4MDctYjM4NS00YzEwLWEyYjItN2I1NmM2NDk3YjFjXkEyXkFqcGc@._V1_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("7e9a9d71-b14e-4c21-acad-3a7f8e9bac12"),
                    Title = "The Green Mile",
                    Genre = "Drama",
                    ReleaseDate = new DateTime(1999, 12, 10),
                    Director = "Frank Darabont",
                    Duration = 189,
                    Description = "A prison guard discovers that a gentle giant on death row possesses a mysterious gift.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTkxYzY3OTYtNGJkOC00M2YyLTg4ZDItYzM3M2Y2YzM4Y2QyXkEyXkFqcGc@._V1_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("8fabae82-c25f-4d32-bdbe-4b809facbd23"),
                    Title = "The Departed",
                    Genre = "Crime",
                    ReleaseDate = new DateTime(2006, 10, 06),
                    Director = "Martin Scorsese",
                    Duration = 151,
                    Description = "An undercover cop and a mole in the police attempt to identify each other while infiltrating an Irish gang in Boston.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTM0NTQ2NjY0NV5BMl5BanBnXkFtZTcwMDkzMzQzMw@@._V1_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("90bcbb93-d360-4e43-cecf-5c91a0bcde34"),
                    Title = "The Prestige",
                    Genre = "Mystery",
                    ReleaseDate = new DateTime(2006, 10, 20),
                    Director = "Christopher Nolan",
                    Duration = 130,
                    Description = "Two rival magicians engage in a bitter battle of secrets, sacrifice, and obsession in Victorian London.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTM0NTQ2NjY0NV5BMl5BanBnXkFtZTcwMDkzMzQzMw@@._V1_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("a1cdcca4-e471-4f54-dfd0-6da2b1cede45"),
                    Title = "Whiplash",
                    Genre = "Drama",
                    ReleaseDate = new DateTime(2014, 10, 10),
                    Director = "Damien Chazelle",
                    Duration = 106,
                    Description = "A promising young drummer enrolls at a cutthroat music conservatory where his demanding instructor pushes him to greatness.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTQ4NjQzNzA2OF5BMl5BanBnXkFtZTgwMDQ0NzgxMzE@._V1_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("b2deddb5-f582-4065-eed1-7eb3c2def056"),
                    Title = "Parasite",
                    Genre = "Thriller",
                    ReleaseDate = new DateTime(2019, 05, 30),
                    Director = "Bong Joon Ho",
                    Duration = 132,
                    Description = "A struggling family gradually infiltrates the household of a wealthy family with unexpected consequences.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTYwMTQ0NTYyNV5BMl5BanBnXkFtZTgwMTQ0NzQ4NjM@._V1_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("c3efeed6-0693-4176-f0e2-8fc4d3ef1067"),
                    Title = "The Lion King",
                    Genre = "Animation",
                    ReleaseDate = new DateTime(1994, 06, 24),
                    Director = "Roger Allers, Rob Minkoff",
                    Duration = 88,
                    Description = "A young lion prince flees his kingdom after the death of his father and learns the true meaning of responsibility.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTQ4NzA0NzQyNV5BMl5BanBnXkFtZTgwMTU0NjQxMzE@._V1_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("d4f0ffe7-17a4-4287-a1f3-90d5e4f02178"),
                    Title = "Saving Private Ryan",
                    Genre = "War",
                    ReleaseDate = new DateTime(1998, 07, 24),
                    Director = "Steven Spielberg",
                    Duration = 169,
                    Description = "A group of soldiers searches for a paratrooper whose brothers have been killed in combat during World War II.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTQ4NzA0NzQyNV5BMl5BanBnXkFtZTgwMTU0NjQxMzE@._V1_.jpg"
                },
                new Movie()
                {
                    Id = Guid.Parse("e50100f8-28b5-4398-b204-a1e6f5013289"),
                    Title = "Back to the Future",
                    Genre = "Adventure",
                    ReleaseDate = new DateTime(1985, 07, 03),
                    Director = "Robert Zemeckis",
                    Duration = 116,
                    Description = "A teenager travels back in time and accidentally interferes with the meeting of his parents.",
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTQ4NzA0NzQyNV5BMl5BanBnXkFtZTgwMTU0NjQxMzE@._V1_.jpg"
                }
            };

            return movies;
        }
    }
}
