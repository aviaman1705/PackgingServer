using AutoMapper;
using PackgingAPI.Models;
using PackgingAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackgingAPI
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<History, HistoryViewModel>()
            .ForMember(dest =>
            dest.Id,
            opt => opt.MapFrom(src => src.Id))
            .ForMember(dest =>
            dest.ProductName,
            opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest =>
            dest.Instruction,
            opt => opt.MapFrom(src => src.Instruction))
            .ForMember(dest =>
            dest.Sku,
            opt => opt.MapFrom(src => src.Sku))
            .ForMember(dest =>
            dest.CreatedDate,
            opt => opt.MapFrom(src => src.CreatedDate))
            .ForMember(dest =>
            dest.Place,
            opt => opt.MapFrom(src => src.Place))
            .ForMember(dest =>
            dest.ProductName,
            opt => opt.MapFrom(src => src.Product.Name));

            CreateMap<Product, ProductViewModel>();

            CreateMap<Product, ListItemViewModel>()
               .ForMember(dest =>
               dest.Value,
               opt => opt.MapFrom(src => src.ProductId))
               .ForMember(dest =>
               dest.Key,
               opt => opt.MapFrom(src => src.Name));

            CreateMap<ProductToCreateViewModel, Product>()
           .ForMember(dest =>
           dest.Image,
           opt => opt.MapFrom(src => src.Image))
           .ForMember(dest =>
           dest.Name,
           opt => opt.MapFrom(src => src.Name))
           .ForMember(dest =>
           dest.Sku,
           opt => opt.MapFrom(src => src.Sku))
           .ForMember(dest =>
           dest.Sku,
           opt => opt.MapFrom(src => src.Sku))
           .ForMember(dest =>
           dest.Sorting,
           opt => opt.MapFrom(src => src.Sorting));



            CreateMap<ProductPlaceViewModel, ProductPlace>()
           .ForMember(dest =>
           dest.Count,
           opt => opt.MapFrom(src => src.Count))
           .ForMember(dest =>
           dest.Instruction,
           opt => opt.MapFrom(src => src.Instruction))
           .ForMember(dest =>
           dest.PlaceId,
           opt => opt.MapFrom(src => src.PlaceId))
           .ForMember(dest =>
           dest.ProductId,
           opt => opt.MapFrom(src => src.ProductId));

            CreateMap<ProductPlace, ProductPlaceGridViewModel>()
          .ForMember(dest =>
          dest.Instruction,
          opt => opt.MapFrom(src => src.Instruction))
          .ForMember(dest =>
          dest.Sku,
          opt => opt.MapFrom(src => src.Product.Sku))
          .ForMember(dest =>
          dest.PlaceName,
          opt => opt.MapFrom(src => src.Place.Name))
          .ForMember(dest =>
          dest.WarehousesTypeId,
          opt => opt.MapFrom(src => src.WarehousesTypeId));


            CreateMap<ProductPlace, EditInventoryBalance>()
       .ForMember(dest =>
       dest.InventoryBalanceID,
       opt => opt.MapFrom(src => src.ProductPlaceId))
       .ForMember(dest =>
       dest.Instruction,
       opt => opt.MapFrom(src => src.Instruction))
       .ForMember(dest =>
       dest.Name,
       opt => opt.MapFrom(src => src.Product.Name))
       .ForMember(dest =>
       dest.Place,
       opt => opt.MapFrom(src => src.Place.Name))
        .ForMember(dest =>
       dest.Warhouse,
       opt => opt.MapFrom(src => src.WarehousesType.Title))
         .ForMember(dest =>
       dest.Count,
       opt => opt.MapFrom(src => src.Count));

            CreateMap<ProductPlace, SearchProductViewModel>()
       .ForMember(dest =>
       dest.ProductPlaceId,
       opt => opt.MapFrom(src => src.ProductPlaceId))
       .ForMember(dest =>
       dest.Instruction,
       opt => opt.MapFrom(src => src.Instruction))
       .ForMember(dest =>
       dest.Sku,
       opt => opt.MapFrom(src => src.Product.Sku))
       .ForMember(dest =>
       dest.ProductName,
       opt => opt.MapFrom(src => src.Product.Name))
        .ForMember(dest =>
       dest.WarehousesTypeName,
       opt => opt.MapFrom(src => src.WarehousesType.Title));

            CreateMap<Place, ListItemViewModel>()
                .ForMember(dest =>
                dest.Value,
                opt => opt.MapFrom(src => src.PlaceId))
                .ForMember(dest =>
                dest.Key,
                opt => opt.MapFrom(src => src.Name));

            CreateMap<Place, PlaceViewModel>();
        }
    }
}
