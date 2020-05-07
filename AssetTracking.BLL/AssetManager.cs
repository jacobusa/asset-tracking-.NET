using AssetTracking.Data;
using AssetTracking.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssetTracking.BLL
{
    public class AssetManager
    {
        public static List<Asset> GetAll()
        {
            var context = new AssetContext();
            var assets = context.Assets.Include(a => a.AssetType).ToList(); //Include AssetType Navigation Property
            return assets;
        }
        public static List<Asset> GetAllByAssetType(int id)
        {
            var context = new AssetContext();

            // Include the AssetType navigation property
            var assets = context.Assets.Where(i => i.AssetTypeId == id).Include(a => a.AssetType).ToList();
            return assets;
        }
        public static void Add(Asset asset)
        {
            var context = new AssetContext();
            context.Assets.Add(asset);
            context.SaveChanges();
        }
        public static Asset Find(int id)
        {
            var context = new AssetContext();
            var asset = context.Assets.Find(id);
            return asset;
        }
        public static void Update(Asset asset)
        {
            // Get Asset that is already in the database
            var context = new AssetContext();
            int id = asset.Id;
            var originalAsset = context.Assets.Find(id);

            // Change properties of that asset to the properties of the Asset object being passed in
            originalAsset.Id = asset.Id;
            originalAsset.TagNumber = asset.TagNumber;
            originalAsset.AssetTypeId = asset.AssetTypeId;
            originalAsset.Manufacturer = asset.Manufacturer;
            originalAsset.Model = asset.Model;
            originalAsset.Description = asset.Description;
            originalAsset.SerialNumber = asset.SerialNumber;

            //Save changes to DB
            context.SaveChanges();
        }
        public static void Delete(int id)
        {
            var context = new AssetContext();
            var originalAsset = context.Assets.Find(id);
            context.Assets.Remove(originalAsset);
            context.SaveChanges();
        }
    }
}
