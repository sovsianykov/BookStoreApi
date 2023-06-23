using System;
using AutoMapper;
using MyWebApi.Infra.Models;
using MyWebApi.Application.DTO;

namespace MyWebApi.Application
{
    public static class BookMapper
    {
        private static IMapper? _mapper;

        static BookMapper()
        {
            ConfigureMapper();
        }

        private static void ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, Dto>();
            });

            _mapper = config.CreateMapper();
        }


    }
}

