using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NimapTask.Appdb;
using NimapTask.Models;

namespace NimapTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDal productDal;
        private readonly ApplicationDbContext context;
        private readonly CategoryDal categoryDal;

        public ProductController( ApplicationDbContext context,CategoryDal categoryDal)
        {
            this.context = context;
            this.productDal = new ProductDal(context);
            this.categoryDal = categoryDal;
            
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize=10)
        {
            try
            {
                int totalcount =await productDal.GetTotalCountAsync();
                var product =await productDal.GetProductsAsync(page, pageSize);
                
                ViewBag.Page = page;
                ViewBag.PageSize = pageSize;
                //ViewBag.TotalPages = (int)Math.Ceiling(totalcount / (double)pageSize);
                ViewBag.HasNext = page * pageSize < totalcount;
                ViewBag.HasPrev = page > 1;
                return View(product);

            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error loading products: {ex.Message}";
                return View(new List<Product>());
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await categoryDal.GetAllCategoriesAsync(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
          

            try
            {
                await productDal.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error saving product: {ex.Message}";
                return View(product);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await productDal.GetProductByIdAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = new SelectList(await categoryDal.GetAllCategoriesAsync(), "CategoryId", "CategoryName");
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
           

            try
            {
                await productDal.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error updating product: {ex.Message}";
                return View(product);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await productDal.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var product = await productDal.GetProductByIdAsync(id);
                if (product == null) return NotFound();

                await productDal.DeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Error deleting product: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }



    }
}
