using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetTracking.BLL;
using AssetTracking.Domain;
using AssetTracking.Presentation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetTracking.Presentation.Controllers
{
    public class AssetTypeController : Controller
    {
        // GET: AssetType
        public ActionResult Index()
        {
            // because there is no view component for this Controller, we need to convert
            // AssetType objects from database to AssetTypeModels to be used in View

            var assetTypes = AssetTypeManager.GetAll();
            List<AssetTypeModel> assetTypeModels =  new List<AssetTypeModel>();

            // Loop through AssetType List to convert to AssetTypeModel and add to list
            foreach (AssetType type in assetTypes)
            {
                assetTypeModels.Add(new AssetTypeModel { Id = type.Id, Name = type.Name });
            }

            return View(assetTypeModels);
        }


        // GET: AssetType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssetTypeModel assetTypeModel)
        {
            try
            {
                // Create new AssetType object from model to pass into database
                var assetType = new AssetType
                {
                    Id = assetTypeModel.Id,
                    Name = assetTypeModel.Name
                };
                AssetTypeManager.Add(assetType);
                return RedirectToAction("Index", "Asset");
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetType/Delete/5
        public ActionResult Delete(int id)
        {
            var assetType = AssetTypeManager.GetAssetTypeById(id);
            var assetTypeModel = new AssetTypeModel
            {
                Id = assetType.Id,
                Name = assetType.Name
            };

            return View(assetTypeModel);
        }

        // POST: AssetType/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AssetTypeModel assetTypeModel)
        {
            ViewBag.ErrorMessage = "";
            var assetType = AssetTypeManager.GetAssetTypeById(id);
            if (AssetManager.GetAllByAssetType(id).Count != 0)
            {
                // cannot delete AssetType if this type has assets in database
                ViewBag.ErrorMessage = "Cannot Delete Type if it has assets being tracked";
                return View(assetTypeModel);
            }
            else
            {
                // no assets of AssetType in database so it is safe to delete
                AssetTypeManager.Delete(id);
                return RedirectToAction("Index", "AssetType");
            }
        }
    }
}