using labtopy.Data;
using labtopy.IRepositry;
using labtopy.Models;

namespace labtopy.Repositry
{
    public class ContactUsRepositry : IContactUsRepositry
    {
        ApplicationDbContext context;
        public ContactUsRepositry(ApplicationDbContext context)
        {
            this.context = context;

        }
        public void Create(Models.ContactUs contactUs)
        {
            context.ContactUss.Add(contactUs);  
            context.SaveChanges();

         }

       
    }
}
