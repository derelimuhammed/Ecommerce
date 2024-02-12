using AutoMapper;
using Business.DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            // AuthManager Mappings
            CreateMap<User, RegisterDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            //UserService Mappings
            CreateMap<User, UpdateProfileDTO>().ReverseMap();
            //Slider Manager Mappings
            CreateMap<Slider, SliderDTO>().ReverseMap();
            //Address Manager Mappings
            CreateMap<Address, AddressDTO>().ReverseMap();
            //Brand Manager Mappings
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Brand, BrandDetailDTO>().ReverseMap();
            //Option Manager Mappings
            CreateMap<ProductOptions, OptionDTO>().ReverseMap();
            CreateMap<ProductOptions, OptionsWithValuesDTO>().ReverseMap();
            //OptionValue Manager Mappings
            CreateMap<OptionValue, OptionValueDTO>().ReverseMap();
            CreateMap<OptionValue, OptionValuesWithOptionDTO>().ReverseMap();
            //Category Manager Mappings
            CreateMap<Category, CategoryDTO>().ReverseMap();
            //Product Manager Mappings
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, AdminProductDetailsDTO>().ReverseMap();
            CreateMap<ProductImage,ProductImageDTO>();
            CreateMap<ProductOptionValue, ProductOptionValueDetailDTO>()
                .ForMember(pov=>pov.OptionValue,povd=>povd.MapFrom(x=>x.OptionValue));
            CreateMap<Product, AdminProductDetailDTO>().ReverseMap();
            //Review Manager Mappings
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<Review, ReviewDetailDTO>();
            //Role Manager Mappings 
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<Order, AdminOrderDetailDTO>().ForMember(Ao => Ao.Id, o => o.MapFrom(opt => opt.Id));
            CreateMap<Order, UserOrderDTO>()
                .ForMember(Ao => Ao.OrderStatus, o => o.MapFrom(opt => opt.OrderStatus.Status))
                .ForMember(ao => ao.TotalPrice, o => o.MapFrom(opt => opt.TotalPrice.ToString("N")));
            CreateMap<Order, OrderDetailDTO>().ForMember(ao => ao.TotalPrice, o => o.MapFrom(opt => opt.TotalPrice.ToString("N")));
            CreateMap<User, UserDetailDTO>();
            CreateMap<Address, AddressDetailDTO>();
            CreateMap<OrderItem, OrderItemDetailDTO>()
                .ForMember(ao => ao.Price, o => o.MapFrom(opt => opt.Product.Price.ToString("N")))
                .ForMember(ao => ao.MainImage, o => o.MapFrom(opt => opt.Product.MainImage))
                .ForMember(ao => ao.Name, o => o.MapFrom(opt => opt.Product.Name));
            CreateMap<Product, AdminProductDetailsDTO>()
                .ForMember(ap => ap.Price, p => p.MapFrom(x => x.Price.ToString("N")))
                .ForMember(ap => ap.BrandName, p => p.MapFrom(x => x.Brand.Name))
                .ForMember(ap => ap.CategoryName, p => p.MapFrom(x => x.Category.Name));
            CreateMap<Product, ProductDetailDTO>();

        }

    }
}
