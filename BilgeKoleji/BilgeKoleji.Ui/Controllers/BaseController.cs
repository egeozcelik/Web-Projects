using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BilgeKoleji.DTO;
using BilgeKoleji.Ui.CORE;
using Microsoft.AspNetCore.Mvc;

namespace BilgeKoleji.Ui.Controllers
{
    public class BaseController : Controller
    {
        public UserDTO CurrentUser
        {
            get
            {
                var userDTOjson = HttpContext.User.Claims.FirstOrDefault(z => z.Type == "UserDTO").Value;
                return BİlgeConvert.JsonDeSerializeUserDTO(userDTOjson);
            }
        }
    }
}
