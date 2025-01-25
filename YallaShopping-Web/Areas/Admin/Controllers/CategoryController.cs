using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YallaShopping.DataAccess.Data;
using YallaShopping.DataAccess.Repository.IRepository;
using YallaShopping.Models;
using YallaShopping.Utility;

namespace YallaShopping_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.Category.GetAll().ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            Category? categoryWithSameName = _unitOfWork.Category.Get(c => c.Name == category.Name);

            if (categoryWithSameName != null)
            {
                ModelState.AddModelError("Name", $"The Category Name '{category.Name}' is already taken");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View("Create", category);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Category? selectedCategory = _unitOfWork.Category.Get(c => c.Id == id);
            if (selectedCategory == null)
                return NotFound();
            return View(selectedCategory);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            Category? originalCategory = _unitOfWork.Category.Get(c => c.Id == category.Id);

            if (originalCategory == null)
                return NotFound();

            if (originalCategory.Name != category.Name)
            {
                Category? categoryWithSameName = _unitOfWork.Category.Get(c => c.Name == category.Name);

                if (categoryWithSameName != null)
                {
                    ModelState.AddModelError("Name", $"The Category Name '{category.Name}' is already taken.");
                    return View("Edit", category);
                }
            }

            if (ModelState.IsValid)
            {
                originalCategory.Name = category.Name;
                originalCategory.DisplayOrder = category.DisplayOrder;
                _unitOfWork.Category.Update(originalCategory);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated Successfully";

                return RedirectToAction("Index");
            }

            return View("Edit", category);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            Category? selectedCategory = _unitOfWork.Category.Get(c => c.Id == id);
            if (selectedCategory == null)
                return NotFound();
            return View(selectedCategory);
        }

        [HttpPost]
        public IActionResult DeletePost(Category? category)
        {
            if (category == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
