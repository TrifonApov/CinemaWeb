using AutoMapper;
using CinemaApp.Services.AutoMapping;
using CinemaApp.Services.Models.Movie;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using static CinemaApp.GCommon.OutputMessages.Movie;
using static CinemaApp.GCommon.ApplicationConstants;
using static CinemaApp.GCommon.ViewModelValidation.Movie;
namespace CinemaApp.Web.ViewModels.Movie
{
    public class MovieFormViewModel : IMapFrom<MovieDetailsViewModel>, IMapTo<MovieDetailsViewModel>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = TitleRequiredMessage)]
        [MinLength(TitleMinLength, ErrorMessage = TitleMinLengthMessage)]
        [MaxLength(TitleMaxLength, ErrorMessage = TitleMaxLengthMessage)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = GenreRequiredMessage)]
        [MinLength(GenreMinLength, ErrorMessage = GenreMinLengthMessage)]
        [MaxLength(GenreMaxLength, ErrorMessage = GenreMaxLengthMessage)]
        public string Genre { get; set; } = null!;

        [Required(ErrorMessage = DirectorRequiredMessage)]
        [MinLength(DirectorNameMinLength, ErrorMessage = DirectorNameMinLengthMessage)]
        [MaxLength(DirectorNameMaxLength, ErrorMessage = DirectorNameMaxLengthMessage)]
        public string Director { get; set; } = null!;

        [Required(ErrorMessage = DurationRequiredMessage)]
        [Range(DurationMin, DurationMax,ErrorMessage = DurationRangeMessage)]
        public int Duration { get; set; }

        [Required(ErrorMessage = ReleaseDateRequiredMessage)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = DescriptionRequiredMessage)]
        [MinLength(DescriptionMinLength, ErrorMessage = DescriptionMinLengthMessage)]
        [MaxLength(DescriptionMaxLength, ErrorMessage = DescriptionMaxLengthMessage)]
        public string Description { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength, ErrorMessage = ImageUrlMaxLengthMessage)]
        public string? ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<MovieDetailsDto, MovieFormViewModel>()
                .ForMember(d => d.ImageUrl,
                    y => y.MapFrom(s => s.ImageUrl ?? DefaultImageUrl));

            configuration.CreateMap<MovieFormViewModel, MovieDetailsDto>()
                .ForMember(d => d.Id, option => option.Ignore());
        }
    }
}
