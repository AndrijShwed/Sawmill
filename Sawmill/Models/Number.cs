using System.ComponentModel.DataAnnotations;

namespace Sawmill.Models
{
    public class Number
    {
        public int id { get; set; }

        public string date { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string Замовник { get; set; } = string.Empty;
        
        public string Номер_телефону { get; set; } = string.Empty;

        public string Ім_я { get; set; } = string.Empty;

        public string Населений_пункт { get; set; } = string.Empty;

    }
}
