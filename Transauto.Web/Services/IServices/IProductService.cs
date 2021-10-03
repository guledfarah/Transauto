using System.Threading.Tasks;
using Transauto.Web.Models;

namespace Transauto.Web.Services.IServices
{
    public interface IProductService
    {
        #region Public Methods

        Task<T> CreateProductAsync<T>(ProductDto productDto);

        Task<T> DeleteProductAsync<T>(int productId);

        Task<T> GetAllProductsAsync<T>();

        Task<T> GetProductByIdAsync<T>(int productId);

        Task<T> UpdateProductAsync<T>(ProductDto productDto);

        #endregion Public Methods
    }
}