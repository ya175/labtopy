using labtopy.DTO;
using labtopy.IRepositry;
using labtopy.Models;
using labtopy.Repositry;
using labtopy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace labtopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        IContactUsRepositry contactUsRepositry;
        public ContactUsController(  IContactUsRepositry contactUsRepositry)
        {
            this.contactUsRepositry = contactUsRepositry;

        }


        [HttpPost]
        public IActionResult Create(ContactUsDTO contactUsDTO     )
        {
            if (ModelState.IsValid)
            {
                ContactUs contactUs = MapRepositry.MapToContactUs(contactUsDTO);

                contactUsRepositry.Create(contactUs);
            return Ok();
            }
            return BadRequest();

        }

    }
}
