namespace Sawmill.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? Дата { get; set; }
        public string? Замовник { get; set; }
        public int NumberId { get; set; }
        public string? Назва { get; set; }
        public int Висота { get; set; }
        public int Ширина{ get; set; }
        public int Довжина { get; set; }
        public int Кількість { get; set; }
        public int Ціна { get; set; }
        public string SessionId { get; set; }
      
    }
}
