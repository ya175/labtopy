using labtopy.Models;

namespace labtopy.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public int Rating { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string CategoryName { get; set; }
        public List<string> ImageUrl { get; set; }
        //public string ImageUrl { get; set; }



    }
}
