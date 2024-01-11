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
    public class login
    {
        
        public string EmailId { get; set; }
        public string Password { get; set; }

    }
    public class LoginController : Controller
    {
        //private readonly string EmailId;
        //private readonly string Password;
        private readonly IRegistrationRepository _reg;
        private readonly string _configuration;

        //public LoginController(IConfiguration configuration)
        //{
        //    _Email = configuration.GetValue<string>("Login:Username");
        //    _password = configuration.GetValue<string>("Login:PasswordKey");

        //}

        public LoginController( IRegistrationRepository reg,IConfiguration configuration)
        {
            _reg = reg;
            _configuration = configuration.GetConnectionString("DbConnection");
            //EmailId = configuration.GetValue<string>("Login:Username");
            //Password = configuration.GetValue<string>("Login:Password");

        }
        // GET: LoginController
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Authentication(login log)
        
        {
            try
            {
                var outputreg = _reg.Login(log.EmailId, log.Password);

                if(outputreg==true)
                {
                    return Redirect("/VehicleMVC/index");
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid Email or password");
                    return View("Login");

                }

                //if (log.EmailId == EmailId && log.Password == Password)
                //{
                //    return Redirect("/VehicleMVC/index");
                //}
                //else
                //{
                //    ModelState.AddModelError("Password", "Invalid EmailId or password");
                //    return View("Login");
                //}

            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }

        // GET: LoginController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController1/Create
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

        // GET: LoginController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController1/Edit/5
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

        // GET: LoginController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController1/Delete/5
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
