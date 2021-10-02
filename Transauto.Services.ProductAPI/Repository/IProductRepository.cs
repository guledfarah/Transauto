using System.Collections.Generic;
using System.Threading.Tasks;
using Transauto.Services.ProductAPI.Models.Dtos;

namespace Transauto.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        #region Public Methods

        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);

        Task<bool> DeleteProduct(int productId);

        Task<ProductDto> GetProductById(int productId);

        Task<IEnumerable<ProductDto>> GetProducts();

        #endregion Public Methods
    }
}