using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
	public class GuestResponse
	{
		[Required(ErrorMessage = "Укажите своё имя")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Укажите свой email")]
		[RegularExpression(".+\\@.+\\..+", ErrorMessage = "Введите корректный email")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Введите корректный телефон")]
		public string Phone { get; set; }
		[Required(ErrorMessage = "Укажите, примите ли участие")]
		public bool? WillAttend { get; set; }
	}
}