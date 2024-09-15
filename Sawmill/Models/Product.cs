
namespace Sawmill.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }

        //public Product(int id, string name, string description, string image)
        //{
        //    this.ProductId = id;
        //    this.Name = name;
        //    this.Description = description;
        //    this.Image = image;
        //}

        public string getName() { return this.Name; }
        public string getDescription() { return this.Description; }
        public int getProductId() { return this.ProductId; }
        public string getImage() { return this.Image; }
    }
}
