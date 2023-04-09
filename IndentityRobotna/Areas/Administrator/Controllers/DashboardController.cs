using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndentityRobotna.Areas.Administrator.Controllers
{        [Area ("Administrator")]

    public class DashboardController : Controller
    {
        private UserManager<IdentityUser> userManger;
        private SignInManager<IdentityUser> signInManager;
        private RoleManager<IdentityRole> roleManager;

        public DashboardController(UserManager<IdentityUser> _userManger,
            SignInManager<IdentityUser> _signInManager, RoleManager<IdentityRole> _roleManager)

        {
            roleManager = _roleManager;
            signInManager = _signInManager;
            userManger = _userManger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RolesList()

        {
            return View(roleManager.Roles);
        }
        public IActionResult UserList()

        {
            return View(userManger.Users);
        }
    }
}
