using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YallaShopping_Razor.Data;
using YallaShopping_Razor.Models;

namespace YallaShopping_Razor.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;
        public Category Category{ get; set; }
        public CreateModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
		public IActionResult OnPost(Category category)
		{
			Category? categoryWithSameName = _db.Categories.FirstOrDefault(c => c.Name == category.Name);

			if (categoryWithSameName != null)
			{
				ModelState.AddModelError("category.Name", $"The Category Name '{category.Name}' is already taken");
			}
			if (ModelState.IsValid)
			{
				_db.Add(category);
				_db.SaveChanges();
				TempData["success"] = "Category Created Successfully";
				return RedirectToPage("Index");
			}
			return Page();
		}
	}
}
