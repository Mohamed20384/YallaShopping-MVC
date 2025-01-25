using YallaShopping_Razor.Data;
using YallaShopping_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_CommerceRazor_Temp.Pages.Categories
{
	[BindProperties]
    public class EditModel : PageModel
    {
		private readonly AppDbContext _db;

		public Category category { get; set; }

		public EditModel(AppDbContext db)
		{
			_db = db;
		}

		public void OnGet(int id)
		{
			// Retrieve the category by id when the page loads
			category = _db.Categories.Find(id);
		}
		public IActionResult OnPost(Category category)
		{
			Category? originalCategory = _db.Categories.FirstOrDefault(c => c.Id == category.Id);

			if (originalCategory == null)
				return NotFound();

			if (originalCategory.Name != category.Name)
			{
				Category? categoryWithSameName = _db.Categories.FirstOrDefault(c => c.Name == category.Name);

				if (categoryWithSameName != null)
				{
					ModelState.AddModelError("category.Name", $"The Category Name '{category.Name}' is already taken.");
					return Page();
				}
			}

			if (ModelState.IsValid)
			{
				originalCategory.Name = category.Name;
				originalCategory.DisplayOrder = category.DisplayOrder;
				_db.SaveChanges();
				TempData["success"] = "Category Updated Successfully";

				return RedirectToPage("Index");
			}

			return Page();
		}
	}
}
