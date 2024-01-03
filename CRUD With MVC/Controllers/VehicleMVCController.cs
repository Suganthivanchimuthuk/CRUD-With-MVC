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
    public class VehicleMVCController : Controller
    {
        private readonly IVehicleInfoRepository _obj;
        private readonly ILocationRepository _loc;
        private readonly string _connectionstring;
      
        public VehicleMVCController(IVehicleInfoRepository result, IConfiguration configuration,ILocationRepository loc)
        {

            _obj = result;
            _loc = loc;
            _connectionstring = configuration.GetConnectionString("DbConnection");
        }
        // GET: VehicleMVCController
        public ActionResult Index()
        {
            try
            {
                var res = _obj.GetVehicleInfoSP();
                return View("List", res);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: VehicleMVCController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var result = _obj.ReadVehicleInfoByNumber(id);
                return View("Details", result);
            }
            catch
            {
                return View("Error");

            }
        }


            // GET: VehicleMVCController/Create
        public ActionResult Create()
        {
           
            var get = new VehicleInfo();
            get.Locations = _loc.GetAllLocations().ToList();
            return View("Create", get);
         }

            // POST: VehicleMVCController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
         public ActionResult Created(VehicleInfo value)
         {
                try
                {
                    _obj.InsertSP(value);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View("Error");
                }
         }

        // GET: VehicleMVCController/Edit/5
        public ActionResult Edit(long id)
        {
            try
            {
                var get = _obj.ReadVehicleInfoByNumber(id);
                get.Locations = _loc.GetAllLocations().ToList();
                return View("Edit", get);
            }
            catch
            {
                return View("Error");
            } 
        }


        // POST: VehicleMVCController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VehicleInfo values)
        {
            try
            {
                _obj.UpdateVehicleInfoSP(id, values);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }


        // GET: VehicleMVCController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var num = _obj.ReadVehicleInfoByNumber(id);
                return View("Delete", num);
            }
            catch
            {
                return View("Error");
            }
        }

            // POST: VehicleMVCController/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
        public ActionResult Deletebynum(int id)
        {
           try
           {
                  _obj.DeleteVehicleInfoSP(id);
                  return RedirectToAction(nameof(Index));
           }
            catch
           {
                      return View("Error");
           }
        }
    }
            
}
            
