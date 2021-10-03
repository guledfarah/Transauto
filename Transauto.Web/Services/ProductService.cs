using System.Net.Http;
using System.Threading.Tasks;
using Transauto.Web.Models;
using Transauto.Web.Services.IServices;

namespace Transauto.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        #region Private Fields

        private readonly IHttpClientFactory _clientFactory;
        private readonly string EndPointPath = "api/products";

        #endregion Private Fields

        #region Public Constructors

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = productDto,
                Url = SD.ProductAPIBase + EndPointPath,
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Data = null,
                Url = SD.ProductAPIBase + EndPointPath + "/" + productId,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Data = null,
                Url = SD.ProductAPIBase + EndPointPath,
                AccessToken = ""
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Data = null,
                Url = SD.ProductAPIBase + EndPointPath + "/" + productId,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDto,
                Url = SD.ProductAPIBase + EndPointPath,
                AccessToken = ""
            });
        }

        #endregion Public Methods
    }
}