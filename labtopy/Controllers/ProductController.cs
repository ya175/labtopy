using labtopy.DTO;
using labtopy.IRepositry;
using labtopy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace labtopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepositry productRepositry;

        public ProductController(IProductRepositry productRepositry)
        {
            this.productRepositry = productRepositry;


            
        }
        [HttpGet]
        public IActionResult ReadAll()
        {
            var products=productRepositry.ReadAll();

            //Map

            List<ProductDTO> productDTOs = products.Select(MapRepositry.MapToProductDTO).ToList();

            return  Ok(productDTOs);





        }
        [HttpGet]
        [Route("/id")]
        public IActionResult FindOne(int id)
        {
            var product=productRepositry.FindByIDWithCategoryImages(id);

            if (product != null)
            {
                //Map

                ProductDTO productDTO = MapRepositry.MapToProductDTO(product);

                return Ok(productDTO);
            }
            return NotFound();




        }

        [HttpGet]
        [Route("/name")]

        public IActionResult SearchByName(string name)
        {

            var products = productRepositry.SearchByName(name);
            if (products.Count > 0)
            {
                //Map

                List<ProductDTO> productDTOs = products.Select(MapRepositry.MapToProductDTO).ToList();

                return Ok(productDTOs);
            }
            return NotFound();

        }
        [HttpGet]
        [Route("/Brand/id")]

        public IActionResult SearchByCategory(int id)
        {
            var products = productRepositry.SearchByCategoryId(id);
            if (products.Count > 0)
            {
                //Map
                List<ProductDTO> productDTOs = products.Select(MapRepositry.MapToProductDTO).ToList();

                return Ok(productDTOs);
            }
            return NotFound();

        }
        
        [HttpGet]
        [Route("/min/max")]

        public IActionResult SearchByPrice(int min ,int max)
        {
            var products = productRepositry.SearchByPrice(min,max);
            if (products.Count > 0)
            {
                //Map
                List<ProductDTO> productDTOs = products.Select(MapRepositry.MapToProductDTO).ToList();

                return Ok(productDTOs);
            }
            return NotFound();

        }
        
        [HttpGet]
        [Route("/rating/rate")]

        public IActionResult SearchByRating(int rate)
        {
            var products = productRepositry.SearchByRating(rate);
            if (products.Count > 0)
            {
                //Map
                List<ProductDTO> productDTOs = products.Select(MapRepositry.MapToProductDTO).ToList();

                return Ok(productDTOs);
            }
            return NotFound();

        }

    }
}

