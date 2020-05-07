using AssetTracking.BLL;
using AssetTracking.Domain;
using AssetTracking.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetTracking.Presentation.ViewComponents
{
    public class AssetsByTypeViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<Asset> assets = null;

            // check if selected text is "All Types" and return all assets if true, otherwise only return selection
            if (id==0)
            {
                assets = AssetManager.GetAll();
            }
            else
            {
                assets = AssetManager.GetAllByAssetType(id);
            }

            var viewModel = assets.Select(asset => new AssetModel {
                Id = asset.Id,
                TagNumber = asset.TagNumber,
                AssetTypeId = asset.AssetTypeId,
                AssetTypeName = asset.AssetType.Name,
                Manufacturer = asset.Manufacturer,
                Model = asset.Model,
                Description = asset.Description,
                SerialNumber = asset.SerialNumber
            }).ToList();

            return View(viewModel);
        }
    }
}
