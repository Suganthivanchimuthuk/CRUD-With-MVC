using DapperDataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_With_MVC.Controllers
{
    public class Registration
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
    public class RegistrationController : Controller
    {
        private readonly string UserName;
        private readonly string Password;
        private readonly string ConfirmPassword;
     

        //public RegistrationController(IConfiguration configuration, IRegistrationRepository reg)
        //{
        //    _reg = reg;
        //    _configuration = configuration.GetConnectionString("DbConnection");
        //    UserName = configuration.GetValue<string>("Login:Username");
        //    Password = configuration.GetValue<string>("Login:Password");
        //    Password = configuration.GetValue<string>("Login:Password");
        //    ConfirmPassword = configuration.GetValue<string>("Login:ConfirmPassword");


            // GET: RegistrationController
            public ActionResult Index()
            {
                return View("RegistrationPage");
            }


            // GET: RegistrationController/Details/5
            public ActionResult Details(int id)
            {
                return View();
            }

            // GET: RegistrationController/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: RegistrationController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(IFormCollection collection)
            {
                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            // GET: RegistrationController/Edit/5
            public ActionResult Edit(int id)
            {
                return View();
            }

            // POST: RegistrationController/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int id, IFormCollection collection)
            {
                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            // GET: RegistrationController/Delete/5
            public ActionResult Delete(int id)
            {
                return View();
            }

            // POST: RegistrationController/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(int id, IFormCollection collection)
            {
                try
                {
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
        }
    }

