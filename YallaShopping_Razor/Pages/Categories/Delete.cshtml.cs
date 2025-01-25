using YallaShopping_Razor.Data;
using YallaShopping_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_CommerceRazor_Temp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
		private readonly AppDbContext _db;

		public Category category { get; set; }

		public DeleteModel(AppDbContext db)
		{
			_db = db;
		}

		public void OnGet(int id)
		{
			// Retrieve the category by id when the page loads
			category = _db.Categories.Find(id);
		}
		public IActionResult OnPost(Category? category)
		{
			if (category == null)
			{
				return NotFound();
			}

			_db.Remove(category);
			_db.SaveChanges();
			TempData["success"] = "Category Deleted Successfully";
			return RedirectToPage("Index");
		}
	}
}
