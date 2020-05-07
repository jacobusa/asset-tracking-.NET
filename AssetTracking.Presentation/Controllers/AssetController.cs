using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetTracking.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AssetTracking.Domain;
using AssetTracking.Presentation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace AssetTracking.Presentation.Controllers
{
    public class AssetController : Controller
    {
        // GET: Asset
        public ActionResult Index()
        {
            var assets = AssetManager.GetAll();

            // When viewing all assets, use select list with 'All Types' option
            ViewBag.AssetTypes = GetAssetTypes();
            return View();
        }
        public IActionResult GetAssetsByType(int id)
        {
            return ViewComponent("AssetsByType", id);
        }


        // GET: Asset/Create
        public ActionResult Create()
        {
            // do not need all assets option when creating new asset
            ViewBag.NoIndexAssetTypes = NoIndexAssetTypes();
            return View();
        }


        // POST: Asset/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssetModel assetModel)
        {
            try
            {
                // create new Asset object from AssetModel
                var asset = new Asset
                {
                    TagNumber = assetModel.TagNumber,
                    AssetTypeId = assetModel.AssetTypeId,
                    //AssetType = AssetTypeManager.GetAssetTypeById(assetModel.AssetTypeId),
                    Manufacturer = assetModel.Manufacturer,
                    Model = assetModel.Model,
                    Description = assetModel.Description,
                    SerialNumber = assetModel.SerialNumber
                };

                // Pass in new Asset object to AssetManager to add into database
                AssetManager.Add(asset);
                return RedirectToAction("Index");
            }
            catch
            {
                // simply return if failed
                return View();
            }
        }

        // GET: Asset/Edit/5
        public ActionResult Edit(int id)
        {
            var asset = AssetManager.Find(id);
            var assetModel = new AssetModel
            {
                Id = asset.Id,
                TagNumber = asset.TagNumber,
                Manufacturer = asset.Manufacturer,
                AssetTypeId = asset.AssetTypeId,
                Description = asset.Description,
                Model = asset.Model,
                SerialNumber = asset.SerialNumber
            };
            ViewBag.AssetTypes = GetAssetTypes();
            return View(assetModel);
        }

        // POST: Asset/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AssetModel assetModel)
        {
            try
            {
                // create new Asset object from AssetModel
                var asset = new Asset
                {
                    Id = assetModel.Id,
                    TagNumber = assetModel.TagNumber,
                    AssetTypeId = assetModel.AssetTypeId,
                    Manufacturer = assetModel.Manufacturer,
                    Model = assetModel.Model,
                    Description = assetModel.Description,
                    SerialNumber = assetModel.SerialNumber
                };

                // Pass in new Asset object to AssetManager to update in database
                AssetManager.Update(asset);
                return RedirectToAction("Index");
            }
            catch
            {
                // return if action failed
                return View();
            }
        }

        // GET: Asset/Delete/5
        public ActionResult Delete(int id)
        {
            var asset = AssetManager.Find(id);
            var assetModel = new AssetModel
            {
                Id = asset.Id,
                TagNumber = asset.TagNumber,
                Manufacturer = asset.Manufacturer,
                AssetTypeId = asset.AssetTypeId,
                AssetTypeName = AssetTypeManager.GetAssetTypeById(asset.AssetTypeId).Name,
                Description = asset.Description,
                Model = asset.Model,
                SerialNumber = asset.SerialNumber
            };
            return View(assetModel);
        }

        // POST: Asset/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                AssetManager.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        protected IList GetAssetTypes()
        {
            // create collection of property types and assign as key value pairs
            var keyValueTypes = AssetTypeManager.GetAsKeyValuePairs();
            var selectListTypes = new SelectList(keyValueTypes, "Value", "Text");
            var listTypes = selectListTypes.ToList();

            // insert all types option to display all assets
            listTypes.Insert(0, new SelectListItem
            {
                Value = "0",
                Text = "All Types"
            });
            return listTypes;
        }
        protected IList NoIndexAssetTypes()
        {
            // create collection of property types and assign as key value pairs
            var keyValueTypes = AssetTypeManager.GetAsKeyValuePairs();
            var selectListTypes = new SelectList(keyValueTypes, "Value", "Text");
            var listTypes = selectListTypes.ToList();
            return listTypes;
        }
    }
}