using MovieTicketBooking.Entity;

namespace MovieTicketBooking.Models
{
    public class MapConfig
    {
        public static void RegisterMap()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<SignUpModel, UserAccount>();
                config.CreateMap<SignInModel, UserAccount>();
                config.CreateMap<SignUpNextModel, Theatre>()
                .ForMember(dest => dest.Status, opt =>opt.MapFrom(src=> "Request"));
                config.CreateMap<UserAccount, SignUpModel>();
                config.CreateMap<MovieModel, Movie>();
                config.CreateMap<Movie, MovieModel>();
            });
        }
    }
}