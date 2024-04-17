using labtopy.Data;
using labtopy.IRepositry;
using labtopy.Models;
using Microsoft.EntityFrameworkCore;

namespace labtopy.Repositry
{
    public class ProductRepositry:IProductRepositry
    {
        ApplicationDbContext context;
        public ProductRepositry(ApplicationDbContext context)
        {
            this.context = context;
            
        }
        public void Create(Product product)
        {
            var check = FindByID(product.Id);
            if(check==null)
            {
                context.Products.Add(product);
                context.SaveChanges();
            }    


        }

        public void Update(Product product)
        {
            var oldProduct = FindByID(product.Id);
            if (oldProduct != null)
            {
                oldProduct.Price=product.Price;
                oldProduct.Description=product.Description;
                oldProduct.CategoryID=product.CategoryID;
                oldProduct.Discount=product.Discount;
                oldProduct.Name=product.Name;
                oldProduct.Model=product.Model;
                oldProduct.Rating=product.Rating;
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            var check = FindByID(product.Id);
            if (check != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }


        }

        public List<Product> ReadAll()
        {
            return context.Products.Include(e => e.Category).Include(e => e.ProductImages).ToList();
        }

        public Product FindByID(int id)
        {
            return context.Products.Find(id);


        }
    public Product FindByIDWithCategoryImages(int id)
        {
            return context.Products.Where(e => e.Id == id).Include(e => e.Category).Include(e => e.ProductImages).FirstOrDefault();

        }
        public List<Product> SearchByCategoryId(int id)
        {

            return context.Products.Where(e=>e.CategoryID==id).Include(e => e.Category).Include(e => e.ProductImages).ToList();
        } 
        public List<Product> SearchByName(string name)
        {

            return context.Products.Where(e=>e.Name.Contains(name)).Include(e => e.Category).Include(e => e.ProductImages).ToList();
        }
        public List<Product> SearchByPrice(int Min ,int Max)
        {

            return context.Products.Where(e=>e.Price>Min &&e.Price<Max).Include(e => e.Category).Include(e => e.ProductImages).ToList();
        }
        
        public List<Product> SearchByRating(int rating)
        {

            return context.Products.Where(e=>e.Rating==rating).Include(e => e.Category).Include(e => e.ProductImages).ToList();
        }

    }
}
