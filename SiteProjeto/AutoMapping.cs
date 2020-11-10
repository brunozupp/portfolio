using AutoMapper;
using Infrastructure.Models;
using Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteProjeto
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            // <to,from>
            CreateMap<Detail, DetailViewModel>();
            CreateMap<DetailViewModel, Detail>();
        }
    }
}
