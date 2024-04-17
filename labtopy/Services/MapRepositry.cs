using labtopy.DTO;
using labtopy.Models;

namespace labtopy.Services
{
    static public class MapRepositry
    {
        public static ProductDTO MapToProductDTO(Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name= product.Name,
                Price= product.Price,
                Model= product.Model,
                Description= product.Description,
                Discount= product.Discount,
                CategoryName = product.Category.Name,
                Rating=product.Rating,
                ImageUrl = product.ProductImages.Select(e=>e.ImageUrl).ToList()


            };
        }

        public static ContactUs MapToContactUs(ContactUsDTO contactUsDTO)
        {
            return new ContactUs
            {
                Name=contactUsDTO.Name,
                Email=contactUsDTO.Email,
                Message=contactUsDTO.Message,
            };
        }
    }
}
