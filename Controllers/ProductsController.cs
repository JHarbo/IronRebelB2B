using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using IronRebelB2B.Models;
using IronRebelB2B.Services;
using IronRebelB2B.ViewModels;
using IronRebelB2B.Utilities;


namespace IronRebelB2B.Controllers
{
    [Route("api/collection")]
    public class ProductsController : Controller
    {
        private readonly ProductService service;
        private static readonly int PRODUCTS_PER_PAGE = 15;
        public ProductsController(IOptions<ShopifyCredentials> options)
        {
            service = new ProductService(options.Value);
        }

        [HttpGet("[action]")]
        public async Task<JsonResult> GetAll()
        {
            Products list = await service.GetAllAsync();

            List<ProductCardViewModel> response = list.ProductList
                .Select(x => new ProductCardViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageSrc = x.Image.Src,
                    Variants = x.Variants.Select(y => new ProductCardViewModel.Variant
                    {
                        Title = y.Title,
                        InventoryQuantity = y.InventoryQuantity
                    })
                }).ToList();

            return Json(response);
        }

        [HttpGet("[action]")]
        public async Task<JsonResult> GetPage(int page)
        {
            Products list = await service.GetPageAsync(PRODUCTS_PER_PAGE, page);

            List<ProductCardViewModel> response = list.ProductList
                .Select(x => new ProductCardViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        ImageSrc = x.Image.Src,
                        Variants = x.Variants.Select(y => new ProductCardViewModel.Variant
                        {
                            Title = y.Title,
                            InventoryQuantity = y.InventoryQuantity
                        })
                    })
                .CatchExceptions()
                .ToList();

            return Json(response);
        }

        [HttpGet("[action]")]
        public async Task<JsonResult> GetPageCount()
        {
            var response = await service.Count();

            response = (int)Math.Ceiling((decimal)response/PRODUCTS_PER_PAGE);

            return Json(new { count = response });
        }

        public async Task<IActionResult> GetByCategory(string type)
        {
            Products response = await service.GetAllAsync();

            List<Product> filtered = response.ProductList.FindAll(p => p.Tags.Equals(type));

            return View("Index", filtered);
        }
    }
}
