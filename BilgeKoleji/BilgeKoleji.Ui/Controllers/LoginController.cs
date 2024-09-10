using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using BilgeKoleji.BLL.Abstract;
using BilgeKoleji.DTO;
using BilgeKoleji.Mapping.ConfigProfile;
using BilgeKoleji.Ui.CORE;
using BilgeKoleji.Ui.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BilgeKoleji.Ui.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        public LoginController(IUserService _userService, IRoleService _roleServive)
        {
            userService = _userService;
            roleService = _roleServive;


        }
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(LoginViewModel userModel)
        {
            var user = userService.FindwithUsernameandMail(userModel.UserName, userModel.Password);

            if (user != null)
            {
                user.roleDTO = roleService.getRole(user.Id);
                var userClaims = new List<Claim>()
                {
                    new Claim("UserDTO",BİlgeConvert.JsonSerialize(user))
                };

                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Home");

            }
            return View(user);
        }
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("UserLogin");
        }

        [HttpGet]
        public ActionResult AccessDenied()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserDTO dto)
        {
            dto.RoleId = 2;
            userService.newUser(dto);
            return RedirectToAction("UserLogin");
        }

    }
}
