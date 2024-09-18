using JWTAuth.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JWTAuth.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(AccountLoginModel viewModel)
        {

            try
            {
                if (!ModelState.IsValid)
                    return View("Index", viewModel);

                string encryptedPwd = viewModel.Password;
                var userPassword = Convert.ToString(ConfigurationManager.AppSettings["config:Password"]);
                var userName = Convert.ToString(ConfigurationManager.AppSettings["config:Username"]);
                if(encryptedPwd.Equals(userPassword) && viewModel.Email.Equals(userName))
                {
                    var roles = new string[] {"SuperAdmin","Admin" };
                    var jwtSecurityToken = Authentication.GenerateJwtToken(userName, roles.ToList());
                    Session["LoginedIn"]= userName;
                    Session["Token"] = jwtSecurityToken;
                    var validUserName = Authentication.ValidateToken(jwtSecurityToken);
                    //return RedirectToAction("Index","Home",new {token=jwtSecurityToken});
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invailid User Name or Password.");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("","Invailid User Name or Password.");
            }

            return View("Index", viewModel);
        }




        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Account");
        }



    }
}