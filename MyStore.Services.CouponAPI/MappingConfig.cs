using AutoMapper;
using MyStore.Services.CouponAPI.Models;
using MyStore.Services.CouponAPI.Models.DTO;

namespace MyStore.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();

            });

            return mapper;
        }
    }
}

