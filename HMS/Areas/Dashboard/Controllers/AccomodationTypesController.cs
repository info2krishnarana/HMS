using HMS.Areas.Dashboard.ViewModels;
using HMS.Entities;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Areas.Dashboard.Controllers
{
    public class AccomodationTypesController : Controller
    {
        AccomodationTypeService accomodationTypeService = new AccomodationTypeService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listing()
        {
            AccomodationTypeViewModel model = new AccomodationTypeViewModel();

            model.AccomodationTypes = accomodationTypeService.GetAllAccomodationTypes();
            return PartialView("_Listing", model);
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            AccomodationTypeActionViewModel model = new AccomodationTypeActionViewModel();
            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccomodationTypeActionViewModel model)
        {
            JsonResult jsonResult = new JsonResult();

            AccomodationType accomodationType = new AccomodationType();
            accomodationType.Name = model.Name;
            accomodationType.Description = model.Description;

            var result = accomodationTypeService.SaveAccomodationType(accomodationType);
            if (result)
            {
                jsonResult.Data = new { Success = true };
            }
            else
            {
                jsonResult.Data = new { Success = false, Message = "Enable to add Accomodation Tpype" };
            }
            return jsonResult;
        }
    }
}