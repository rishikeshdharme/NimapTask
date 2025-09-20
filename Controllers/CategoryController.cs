using Microsoft.AspNetCore.Mvc;
using NimapTask.Appdb;
using NimapTask.Models;

namespace NimapTask.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryDal categoryDal;
        private readonly ApplicationDbContext ap;

        public CategoryController(ApplicationDbContext ap)
        {
            categoryDal = new CategoryDal(ap);

        }
        public async Task<IActionResult> Index()
        {
            var categories = await categoryDal.GetAllCategoriesAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            try
            {
                if (category != null)
                {
                    await categoryDal.AddCategoryAsync(category);

                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "Invalid category data");
                return View(category);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Something went wrong" + ex.Message);
                return View(category);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await categoryDal.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            try
            {
                if (category != null)
                {
                    await categoryDal.UpdateCategoryAsync(category);
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Invalid category data");
                return View(category);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error updating category: " + ex.Message);
                return View(category);
            }


        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category =await categoryDal.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                await categoryDal.DeleteCategoryAsync(id);
                return RedirectToAction(nameof(Index));

            }catch(Exception ex)
            {
                ViewBag.Error = "Error deleting category: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await categoryDal.GetCategoryByIdAsync(id);
            return View(category);
        }
        



    }
}
