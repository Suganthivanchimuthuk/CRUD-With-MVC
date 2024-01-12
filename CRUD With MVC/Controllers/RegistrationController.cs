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
 
    public class RegistrationController : Controller
    {
        private readonly IRegistrationRepository _reg;
        private readonly string _configuration;
        public RegistrationController(IRegistrationRepository reg, IConfiguration configuration)
        {
            _reg = reg;
            _configuration = configuration.GetConnectionString("DbConnection");
        }


        // GET: RegistrationController
        public ActionResult Index()
            {
                return View("RegistrationPage");
            }
        public ActionResult List()
        {
            var res = _reg.GetRegistrations();
            return View("List",res);

        }


        // GET: RegistrationController/Details/5
        public ActionResult AuthenticationR(Registration reg)
        {
            try
            {
                var resultreg = _reg.Register(reg);


                if (resultreg == true)
                {
                    _reg.Insert(reg);

                    return Redirect("/Login/index");
                }
                else
                {
                    ModelState.AddModelError("ConfirmPassword", "Already Exist");
                    return View("RegistrationPage");
                }

            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }

        // GET: RegistrationController/Create
        public ActionResult Create()
        {
            try
            {
                return View("Create", new Registration());
            }
            catch
            {
                return View("Error");
            }
        }


        // POST: RegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Registration list)
        {
            try
            {
                var outputreg = _reg.Register(list);
                if(outputreg==true)
                {
                    _reg.Insert(list);

                    var result = _reg.GetRegistrations();
                    return View("Create", result);
                    //return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("ConfirmPassword", "Already Exist");
                    return View("Create", list);
                }

            }
            catch
            {
                return View("Error");
            }
        }

        // GET: RegistrationController/Edit/5
        public ActionResult Edit(int id)
        {           
                var res = _reg.FindByNumber(id);
                return View("Edit",res);            
         
        }

        // POST: RegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Registration reg)
        {
            try
            {
                var outputreg = _reg.Register(reg);
                if (outputreg == true)
                {
                     _reg.UpdateReg(id, reg);
                    var list = _reg.GetRegistrations();                  
                   
                    return View("Edit", list);

                    //return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("ConfirmPassword", "Already Exist");
                    return View("Edit", list);
                }
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        // GET: RegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var res = _reg.FindByNumber(id);
                return View("Delete",res);
            }
            catch
            {
                return View("Error");
            }
        }
    

        // POST: RegistrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Registrationid)
        {
            try
            {
                _reg.DeleteRegistration(Registrationid);

                var list = _reg.GetRegistrations();
                return View("View", list);
            }
            catch
            {
                return View("Error");
            }
        }
    }
}