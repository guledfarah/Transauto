using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transauto.Services.ProductAPI.Models.Dtos;
using Transauto.Services.ProductAPI.Repository;

namespace Transauto.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        #region Private Fields

        private IProductRepository _productRepository;

        #endregion Private Fields

        #region Protected Fields

        protected ResponseDto _responseDto;

        #endregion Protected Fields

        #region Public Constructors

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._responseDto = new ResponseDto();
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                _responseDto.Result = await _productRepository.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responseDto;
        }

        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                _responseDto.Result = await _productRepository.GetProducts();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                _responseDto.Result = await _productRepository.GetProductById(id);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responseDto;
        }

        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] ProductDto productDto)
        {
            try
            {
                _responseDto.Result = await _productRepository.CreateUpdateProduct(productDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responseDto;
        }

        [HttpPut]
        public async Task<ResponseDto> Put([FromBody] ProductDto productDto)
        {
            try
            {
                _responseDto.Result = await _productRepository.CreateUpdateProduct(productDto);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _responseDto;
        }

        #endregion Public Methods
    }
}