//using System.ComponentModel.DataAnnotations;
//using E_Commerce_Web.Models;
//using Microsoft.EntityFrameworkCore; // Make sure to include this if needed

//namespace E_Commerce_Web.CustomValidationAttributes
//{
//	public class UniqueCategoryName : ValidationAttribute
//	{
//		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//		{
//			// Access the ApplicationDbContext from the validation context
//			var _db = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));

//			if (_db == null)
//			{
//				return new ValidationResult("Database context is not available.");
//			}

//			if (value == null)
//				return ValidationResult.Success;

//			string newName = value.ToString();
//			var CategoryWithSameName = _db.Categories.FirstOrDefault(c => c.Name == newName);

//			if (CategoryWithSameName != null)
//			{
//				return new ValidationResult("This Category Name already exists");
//			}

//			return ValidationResult.Success;
//		}
//	}
//}
