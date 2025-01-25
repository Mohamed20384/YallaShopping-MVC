using YallaShopping_Razor.Data;
using YallaShopping_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_CommerceRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        public List<Category> CategoryList { get; set; }
        public IndexModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            CategoryList=_db.Categories.ToList();
        }
    }
}
