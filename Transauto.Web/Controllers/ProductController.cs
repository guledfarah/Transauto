using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transauto.Web.Models;
using Transauto.Web.Services.IServices;

namespace Transauto.Web.Controllers
{
    public class ProductController : Controller
    {
        #region Private Fields

        private readonly IProductService _productService;

        private ILogger<ProductController> _logger { get; }

        #endregion Private Fields

        #region Public Constructors

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> products = new();
            var responseDto = await _productService.GetAllProductsAsync<ResponseDto>();
            if (responseDto is not null && responseDto.IsSuccess)
                products = JsonConvert.DeserializeObject<List<ProductDto>>(responseDto.Result.ToString());
            return View(products);
        }

        public async Task<IActionResult> Details(int productId)
        {
            ProductDto products = new();
            var responseDto = await _productService.GetProductByIdAsync<ResponseDto>(productId);
            if (responseDto is not null && responseDto.IsSuccess)
                products = JsonConvert.DeserializeObject<ProductDto>(responseDto.Result.ToString());
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return View(productDto);

            try
            {
                ProductDto products = new();
                var responseDto = await _productService.CreateProductAsync<ResponseDto>(productDto);
                if (responseDto is not null && responseDto.IsSuccess)
                    products = JsonConvert.DeserializeObject<ProductDto>(responseDto.Result.ToString());
                return RedirectToAction(nameof(ProductIndex));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                ModelState.AddModelError("Error Adding a Product", ex.Message);
                return View(productDto);
            }
        }

        public async Task<IActionResult> Edit(int productId)
        {
            ProductDto products = new();
            var responseDto = await _productService.GetProductByIdAsync<ResponseDto>(productId);
            if (responseDto is not null && responseDto.IsSuccess)
            {
                products = JsonConvert.DeserializeObject<ProductDto>(responseDto.Result.ToString());
                return View(products);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductDto productDto)
        {
            if (HttpContext.Request.Method == SD.ApiType.GET.ToString())
                return View(productDto);

            if (!ModelState.IsValid)
                return View(productDto);

            try
            {
                ProductDto products = new();
                var responseDto = await _productService.UpdateProductAsync<ResponseDto>(productDto);
                if (responseDto is not null && responseDto.IsSuccess)
                    products = JsonConvert.DeserializeObject<ProductDto>(responseDto.Result.ToString());
                return RedirectToAction(nameof(ProductIndex));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                ModelState.AddModelError("Error Adding a Product", ex.Message);
                return View(productDto);
            }
        }

        public async Task<IActionResult> Delete(int productId)
        {
            ProductDto products = new();
            var responseDto = await _productService.DeleteProductAsync<ResponseDto>(productId);
            if (responseDto is not null && responseDto.IsSuccess)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
            return NotFound();
        }
        #endregion Public Methods
    }
}