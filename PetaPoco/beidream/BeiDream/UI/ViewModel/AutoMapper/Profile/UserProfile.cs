using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BeiDream.Models.Account;

namespace BeiDream.UI.ViewModel.AutoMapper
{
    public class UserProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<BeiDream_User, LoginModel>();
        }
    }
}