using BeezyBackend.Repository.Data;
using AutoMapper;

namespace BeezyBackend.Service
{
    public class Mapper : AutoMapper.Profile
    {
        //create map and use the created map
        public Mapper()
        {
            CreateMap<MovieDetails, IntelligentBillboard>()
                 .ForMember(dest => dest.Type, opts => opts.MapFrom(src => src.title));
        }
    }
}
