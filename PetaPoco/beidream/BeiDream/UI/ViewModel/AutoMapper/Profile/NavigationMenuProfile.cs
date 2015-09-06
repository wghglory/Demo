using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BeiDream.Models.Account;

namespace BeiDream.UI.ViewModel.AutoMapper
{
    public class NavigationMenuProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<BeiDream_NavigationMenu, NavigationMenu>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.text, opt => opt.MapFrom(src => src.ShowName))
                .ForMember(dest => dest.leaf, opt => opt.MapFrom(src => src.IsLeaf));
        }
    }
}