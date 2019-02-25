using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PushNotificationCore.Controllers
{
    public class BaseController : Controller
    {
        public void MessageSuccess(string message)
        {                 
            this.TempData.Add("success", message);
        }
        public void MessageError(string message)
        {
            this.TempData.Add("error", message);
        }
        public void MessageInfo(string message)
        {
            this.TempData.Add("info", message);
        }
    }
}