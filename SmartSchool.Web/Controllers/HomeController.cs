using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartSchool.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartSchool.Web.Controllers
{
    [Authorize(Roles ="Student")]
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Install()
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));


            if (!roleManager.RoleExists("SysAdmin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "SysAdmin";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Student"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Student";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("SchoolAdmin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "SchoolAdmin";
                roleManager.Create(role);
            }

            if (UserManager.FindByName("SysAdmin") == null)
            {
                var user = new ApplicationUser { UserName = "SysAdmin", Email = "Admin@smartschool.com", EmailConfirmed = true };
                //user.UserProfile = new ACE.LMS.Web.Models.UserProfile
                //{
                //    IsActive = true,
                //    IsBlocked = false,
                //    HasCheckedTerms = true,
                //    RegistrationDate = DateTime.Now
                //};
                var result = UserManager.Create(user, "Admin@1234");
                UserManager.AddToRole(user.Id, "SysAdmin");
            }

            if (UserManager.FindByName("Admin") == null)
            {
                var user = new ApplicationUser { UserName = "Admin", Email = "Alchemy@smartschool.com", EmailConfirmed = true };
                //user.UserProfile = new ACE.LMS.Web.Models.UserProfile
                //{
                //    IsActive = true,
                //    IsBlocked = false,
                //    HasCheckedTerms = true,
                //    RegistrationDate = DateTime.Now
                //};
                var result = UserManager.Create(user, "Admin!1234");
                UserManager.AddToRole(user.Id, "SchoolAdmin");
            }

            return View();
        }
    }
}