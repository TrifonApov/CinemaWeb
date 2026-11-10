namespace CinemaApp.Web.Infrastructure.Utilities
{
    using Contracts;

    public class SlugGenerator : ISlugGenerator
    {
        public string GenerateSlug(string input)
        {
            string[] words = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.ToLowerInvariant())
                .ToArray();

            return string.Join("-", words);
        }
    }
}
