using System.ComponentModel.DataAnnotations;

namespace PetShopProjectWebApplication.ViewModels
{
	public class AddCategoryViewModel
	{
		[Required]
		public string? Name { get; set; }
	}
}
