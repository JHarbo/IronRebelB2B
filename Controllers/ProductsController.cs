using System.Threading.Tasks;
using System;
using System.Linq;
using IronRebelB2B.Models;
using IronRebelB2B.Services;
using IronRebelB2B.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IronRebelB2B.Controllers
{
    [Route("api/collection")]
    public class ProductsController : Controller
    {

        [HttpGet("[action]")]
        public async Task<JsonResult> GetAll()
        {
            var service = new ProductService();

            int productsPerPage = 15;
            int productCount = await service.Count();
            int pageCount = (int)Math.Ceiling((double)(productCount / productsPerPage));

            Products list = await service.GetLimitedListAsync(productsPerPage);

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
        public async Task<JsonResult> GetNextPage(int pageNr)
        {
            var service = new ProductService();

            Products list = await service.GetPageAsync(15, pageNr);

            list.ProductList.Remove(list.ProductList.Find(item => item.Image == null));

            var response = list.ProductList
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

        public async Task<IActionResult> GetByCategory(string type)
        {
            var service = new ProductService();

            Products response = await service.GetAllAsync();

            List<Product> filtered = response.ProductList.FindAll(p => p.Tags.Equals(type));

            return View("Index", filtered);
        }
    }
}
