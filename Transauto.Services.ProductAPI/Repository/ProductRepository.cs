using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transauto.Services.ProductAPI.DbContexts;
using Transauto.Services.ProductAPI.Models;
using Transauto.Services.ProductAPI.Models.Dtos;

namespace Transauto.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        #region Private Fields

        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<Product>(productDto);
            if (product is not null && product.ProductId > 0)
                _db.Products.Update(product);
            else
                await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();

                if (product == null)
                    return false;

                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<Product> products = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        #endregion Public Methods
    }
}