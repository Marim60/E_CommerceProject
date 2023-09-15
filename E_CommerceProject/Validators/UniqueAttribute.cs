using E_CommerceProject.Areas.Identity.Pages.Account.Manage;
using E_CommerceProject.Data;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceProject.Validators
{
	public class UniqueAttribute : ValidationAttribute
	{
		private ApplicationDbContext db;
		public UniqueAttribute(ApplicationDbContext _Db)
		{
			db = _Db;
		}
		//protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		//{
		//	string? str = value as string;
		//	var entityType = validationContext.ObjectType;

		//	if (entityType == typeof(IndexModel))
		//	{
		//		var instructor = db.Accou.FirstOrDefault(i => i.Name == str);
		//		if (instructor == null)
		//		{
		//			return ValidationResult.Success;
		//		}
		//	}
		//	else if (entityType == typeof(Course))
		//	{
		//		var course = db.Courses.FirstOrDefault(i => i.Name == str);
		//		if (course == null)
		//		{
		//			return ValidationResult.Success;
		//		}
		//	}
		//	return new ValidationResult("Name is Already excit");
		//}
	}
}
