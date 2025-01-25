using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace YallaShopping_Razor.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required]
		//[Remote(action: "IsCategoryNameUnique", controller: "Category", ErrorMessage = "This Category Name already exists.")]
		[MaxLength(29)]
		[MinLength(3)]
		[DisplayName("Category Name")]
		public string Name { get; set; }
		[DisplayName("Display Order")]
		[Range(1, 100, ErrorMessage = "Display Order must be between 1-100")]
		public int DisplayOrder { get; set; }
	}
}
