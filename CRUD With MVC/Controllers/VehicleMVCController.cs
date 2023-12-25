using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_With_MVC.Controllers
{
    public class VehicleMVCController : Controller
    {
        // GET: VehicleMVCController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VehicleMVCController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleMVCController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMVCController/Create
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

        // GET: VehicleMVCController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicleMVCController/Edit/5
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

        // GET: VehicleMVCController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleMVCController/Delete/5
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
