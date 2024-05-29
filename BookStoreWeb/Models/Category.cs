using System.ComponentModel.DataAnnotations;

namespace BookStoreWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [MaxLength(30, ErrorMessage = "Длина категории не должны превышать 30 символов")]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage = "Значение должно быть в диапазоне от 1 до 100")]
        public int DisplayOrder { get; set; }
    }
}
