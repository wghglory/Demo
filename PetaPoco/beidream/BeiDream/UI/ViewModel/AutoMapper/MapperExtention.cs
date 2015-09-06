using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace BeiDream.UI.ViewModel.AutoMapper
{
    public static class MapperExtention
    {
        public static TDestination ToDestination<TSource, TDestination>(this TSource model)
        {
            return Mapper.Map<TSource, TDestination>(model);
        }
        public static TDestination ToDestination<TSource, TDestination>(this TSource model, TDestination DaoModel)
        {
            return Mapper.Map<TSource, TDestination>(model, DaoModel);
        }
    }
}