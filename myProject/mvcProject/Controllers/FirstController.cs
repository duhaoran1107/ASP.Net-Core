using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvcProject.Models;

namespace mvcProject.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;

        public FirstController(ILogger<FirstController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            this._logger.LogWarning("First页面加载了");

            #region ViewData
            base.ViewData["User"] = (new CurrentUser()
            {
                Id = 1,
                Name = "杜浩然",
                Age = 23,
                Email = "1931209209@qq.com",
                Password = "123456",
                LoginTime = DateTime.Now
            });
            #endregion

            #region ViewBag
            base.ViewBag.User = (new CurrentUser()
            {
                Id = 1,
                Name = "杜浩然",
                Age = 23,
                Email = "1931209209@qq.com",
                Password = "123456",
                LoginTime = DateTime.Now
            });
            #endregion

            #region TempData
            base.TempData["User"] = (new CurrentUser()
            {
                Id = 1,
                Name = "杜浩然",
                Age = 23,
                Email = "1931209209@qq.com",
                Password = "123456",
                LoginTime = DateTime.Now
            });
            #endregion

            #region Session
            if (string.IsNullOrWhiteSpace(this.HttpContext.Session.GetString("CurrentUserSession")))
            {
                base.HttpContext.Session.SetString("CurrentUserSession",
                    Newtonsoft.Json.JsonConvert.SerializeObject(new CurrentUser()
                    {
                        Id = 1,
                        Name = "杜浩然",
                        Age = 23,
                        Email = "1931209209@qq.com",
                        Password = "123456",
                        LoginTime = DateTime.Now
                    }));
            }
            #endregion

            #region Model
            return View(new CurrentUser
            {
                Id = 1,
                Name = "杜浩然",
                Age = 23,
                Email = "1931209209@qq.com",
                Password = "123456",
                LoginTime = DateTime.Now
            });
            #endregion

        }
    }
}
