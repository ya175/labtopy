using labtopy.Models;

namespace labtopy.IRepositry
{
    public interface IProductRepositry
    {
        //crud

        // c

        public void Create(Product product);
        public void Update(Product product);
        public void Delete(Product product);
        public List<Product> ReadAll();
        public Product FindByID(int id);

        public Product FindByIDWithCategoryImages(int id);


        public List<Product> SearchByName(string name);

        public List<Product> SearchByCategoryId(int id);
        public List<Product> SearchByPrice(int Min, int Max);

        public List<Product> SearchByRating(int rating);
    }
}
