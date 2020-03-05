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
                config.CreateMap<TheatreModel, Theatre>();
            });
        }
    }
}