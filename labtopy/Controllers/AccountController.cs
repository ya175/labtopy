using labtopy.DTO;
using labtopy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace labtopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signIn;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signIn)
        {
            this.userManager = userManager;
            this.signIn = signIn;
        }


        [HttpPost]

        [Route("/SignUp")]
        public async Task<IActionResult> Registration(ApplicationUserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser() { UserName = userDTO.UserName,FirstName=userDTO.FirstName, LastName=userDTO.LastName,  Email = userDTO.Email, PasswordHash = userDTO.Password };

                var result = await userManager.CreateAsync(user, userDTO.Password);

                
                if (result.Succeeded)
                {
                    await signIn.SignInAsync(user, false);

                    return Ok(user);
                }
                else
                    return BadRequest(result.Errors);
            }
            return BadRequest(ModelState);    

        }

        [HttpPost]
       
        [Route("/LogIn")]
        public async Task<IActionResult> Login(LogInDTO userDTO)
        {

            if (ModelState.IsValid)
            {

                var user = await userManager.FindByNameAsync(userDTO.UserName);

                if (user != null)
                {
                    var check = await signIn.CheckPasswordSignInAsync(user, userDTO.Password, true);

                    if (check.Succeeded)
                    {
                        //cookie

                        await signIn.SignInAsync(user, userDTO.RememberMe);

                        return Ok(user);
                    }
                    else
                    {

                        return BadRequest("InValid UserName or Password");
                    }
                }
                else
                {



                    return BadRequest("InValid UserName or Password");
                }
                
            }
                return BadRequest("InValid UserName or Password");
        }

    }
}
