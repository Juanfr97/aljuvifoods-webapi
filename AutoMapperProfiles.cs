using aljuvifoods_webapi.DTOs.Order;
using aljuvifoods_webapi.DTOs.OrderProduct;
using aljuvifoods_webapi.DTOs.Product;
using aljuvifoods_webapi.DTOs.User;
using aljuvifoods_webapi.Models;
using AutoMapper;

namespace aljuvifoods_webapi
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserCDTO>();
            CreateMap<UserCDTO, User>();

            CreateMap<Product, ProductCDTO>();
            CreateMap<ProductCDTO, Product>();

            CreateMap<OrderProduct, OrderProductCDTO>();
            CreateMap<OrderProductCDTO, OrderProduct>();

            CreateMap<Order, OrderCDTO>();
            CreateMap<OrderCDTO, Order>();
        }

    }
}
