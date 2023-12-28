using DapperDataAccessLayer;
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
        public readonly IVehicleInfoRepository obj;
        public VehicleMVCController()
        {
            obj = new VehicleInfoRepository();
        }
        // GET: VehicleMVCController
        public ActionResult Index()
        {
            var res = obj.GetVehicleInfoSP();
            return View("List",res);
        }

        // GET: VehicleMVCController/Details/5
        public ActionResult Details(int id)
        {
            var result = obj.ReadVehicleInfoByNumber(id);
            return View("ReadByNumber",result);
        }

        // GET: VehicleMVCController/Create
        public ActionResult Create()
        {
            return View("Create",new VehicleInfo());
        }

        // POST: VehicleMVCController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Created(VehicleInfo value)
        {
            try
            {
                obj.InsertSP(value);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleMVCController/Edit/5
        public ActionResult Edit(long id)
        {
            var res = obj.ReadVehicleInfoByNumber(id);
            return View("Update",res);
        }

        // POST: VehicleMVCController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehicleInfo values)
        {
            try
            {
                obj.UpdateVehicleInfoSP(id, values);
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
            var num = obj.ReadVehicleInfoByNumber(id);
            return View("Delete",num);
        }

        // POST: VehicleMVCController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletebynum(int Id)
        {
            try
            {
                obj.DeleteVehicleInfoSP(Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
