using AutoMapper;
using Transauto.Services.ProductAPI.Models;
using Transauto.Services.ProductAPI.Models.Dtos;

namespace Transauto.Services.ProductAPI
{
    public class MappingConfig
    {
        #region Public Methods

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });

            return mappingConfig;
        }

        #endregion Public Methods
    }
}