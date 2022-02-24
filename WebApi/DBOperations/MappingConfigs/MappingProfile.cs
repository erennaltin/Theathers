using AutoMapper;
using WebApi.Models.Entities;
using static WebApi.DBOperations.TheatherOperations.Commands.CreateTheather.CreateTheatherCommand;
using WebApi.DBOperations.TheatherOperations.Queries.GetTheatherDetail;
using WebApi.DBOperations.TheatherOperations.Queries.GetTheathers;


namespace WebApi.DBOperations.MappingConfigs {
  public class MappingProfile : Profile {
    public MappingProfile(){
      CreateMap<CreateTheatherModel, TheatherModel>();
      CreateMap<TheatherModel, TheatherDetailViewModel>().ForMember(dest => dest.Date, opt=> opt.MapFrom(src => src.Date.Date.ToString("dd/MM/yyy")));
      CreateMap<TheatherModel, TheathersViewModel>().ForMember(dest => dest.Date, opt=> opt.MapFrom(src => src.Date.Date.ToString("dd/MM/yyy")));
    }
  }
}