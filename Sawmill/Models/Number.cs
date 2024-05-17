using System.ComponentModel.DataAnnotations;

namespace Sawmill.Models
{
    public class Number
    {
        public int id { get; set; }

        public string date { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string Замовник { get; set; } = string.Empty;
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Номер телефону може містити тільки цифри, символ '+' та дужки, і повинен бути від 10 до 15 символів.")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Номер телефону повинен містити від 10 до 15 символів.")]
        public string Номер_телефону { get; set; } = string.Empty;

        public string Ім_я { get; set; } = string.Empty;

        public string Населений_пункт { get; set; } = string.Empty;

    }
}
