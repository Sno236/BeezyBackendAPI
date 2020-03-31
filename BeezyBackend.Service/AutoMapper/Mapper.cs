using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BeezyBackendAPI.Models;
using BeezyBackendAPI.ViewModels;

namespace BeezyBackendAPI
{
    public class Mapper : AutoMapper.Profile
    {
        //create map and use the created map
        public Mapper()
        {
            CreateMap<Movie, MovieViewModel>()
                .ReverseMap();
        }
    }
}
