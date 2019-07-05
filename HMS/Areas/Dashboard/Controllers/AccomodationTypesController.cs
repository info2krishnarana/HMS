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
        public ActionResult Action(int? id)
        {
            AccomodationTypeActionViewModel model = new AccomodationTypeActionViewModel();
            if (id.HasValue)
            {
                var accomodationType = accomodationTypeService.GetAccomodationTypeById(id.Value);
                model.ID = accomodationType.ID;
                model.Name = accomodationType.Name;
                model.Description = accomodationType.Description;
            }
            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(AccomodationTypeActionViewModel model)
        {
            var result = false;
            JsonResult jsonResult = new JsonResult();

            AccomodationType accomodationType = new AccomodationType();

            if (model.ID > 0)
            {
                accomodationType = accomodationTypeService.GetAccomodationTypeById(model.ID);

                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;

                result = accomodationTypeService.UpdateAccomodationType(accomodationType);
            }
            else
            {
                accomodationType.Name = model.Name;
                accomodationType.Description = model.Description;

                result = accomodationTypeService.SaveAccomodationType(accomodationType);
            }
            if (result)
            {
                jsonResult.Data = new { Success = true };
            }
            else
            {
                jsonResult.Data = new { Success = false, Message = "Enable to perform action on Accomodation Tpype" };
            }
            return jsonResult;
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            AccomodationTypeActionViewModel model = new AccomodationTypeActionViewModel();

            var accomodationType = accomodationTypeService.GetAccomodationTypeById(id);

            model.ID = accomodationType.ID;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(AccomodationTypeActionViewModel model)
        {
            var result = false;
            JsonResult jsonResult = new JsonResult();

            AccomodationType accomodationType = new AccomodationType();

            accomodationType = accomodationTypeService.GetAccomodationTypeById(model.ID);

            result = accomodationTypeService.DeleteAccomodationType(accomodationType);

            if (result)
            {
                jsonResult.Data = new { Success = true };
            }
            else
            {
                jsonResult.Data = new { Success = false, Message = "Enable to perform action on Accomodation Tpype" };
            }
            return jsonResult;
        }
    }
}