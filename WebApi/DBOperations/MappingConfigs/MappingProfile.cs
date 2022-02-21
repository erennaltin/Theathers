using AutoMapper;
using WebApi.Models;
using static WebApi.DBOperations.TheatherOperations.CreateTheather.CreateTheatherCommand;
using WebApi.DBOperations.TheatherOperations.GetTheatherDetail;
using WebApi.DBOperations.TheatherOperations.GetTheathers;


namespace WebApi.DBOperations.MappingConfigs {
  public class MappingProfile : Profile {
    public MappingProfile(){
      CreateMap<CreateTheatherModel, TheatherModel>();
      CreateMap<TheatherModel, TheatherDetailViewModel>().ForMember(dest => dest.Date, opt=> opt.MapFrom(src => src.Date.Date.ToString("dd/MM/yyy")));
      CreateMap<TheatherModel, TheathersViewModel>().ForMember(dest => dest.Date, opt=> opt.MapFrom(src => src.Date.Date.ToString("dd/MM/yyy")));
    }
  }
}