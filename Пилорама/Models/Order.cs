namespace Пилорама.Models
{
    public class Order
    {
        public int orderId { get; set; }
        public string? Замовник { get; set; }
        public string? Назва { get; set; }
        public int Висота { get; set; }
        public int Ширина{ get; set; }
        public int Довжина { get; set; }
        public int Кількість { get; set; }
        public double Об_єм { get; set; }
        public int Ціна { get; set; }
        public double Сума { get; set; }
    }
}
