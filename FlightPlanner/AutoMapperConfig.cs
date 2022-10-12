using AutoMapper;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Requests;

namespace FlightPlanner
{
    public class AutoMapperConfig
    {
        public static IMapper CreateMapper()
        {
            //var config = new MapperConfiguration(
            //    cfg =>
            //    {
            //        cfg.CreateMap<AirportRequest, Airport>().ForMember(d => d.Id, options => options.Ignore()).ForMember(d => d.AirportCode, opt => opt.MapFrom(s => s.Airport));
            //        cfg.CreateMap<Airport, AirportRequest>();
            //        cfg.CreateMap<FlightRequest, Flight>();
            //        cfg.CreateMap<Flight, FlightRequest>();
            //    });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Flight, FlightRequest>();
                cfg.CreateMap<FlightRequest, Flight>();
                cfg.CreateMap<Airport, AirportRequest>()
                    .ForMember(dest => dest.Airport, opt => opt.MapFrom(a => a.AirportCode));
                cfg.CreateMap<AirportRequest, Airport>()
                    .ForMember(dest => dest.AirportCode, opt => opt.MapFrom(a => a.Airport))
                    .ForMember(dest => dest.Id, opt => opt.Ignore());
            });

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }
    }
}
