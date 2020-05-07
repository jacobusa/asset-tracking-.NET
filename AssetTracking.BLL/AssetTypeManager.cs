using AssetTracking.Data;
using AssetTracking.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AssetTracking.BLL
{
    public class AssetTypeManager
    {
        public static List<AssetType> GetAll()
        {
            var context = new AssetContext();

            //Include Asset Navigation Property
            var assets = context.AssetTypes.Include(a => a.Assets).ToList();
            return assets;
        }
        public static AssetType GetAssetTypeById(int id)
        {
            var context = new AssetContext();
            var assetType = context.AssetTypes.Find(id);
            return assetType;
        }
        public static void Add(AssetType assetType)
        {
            var context = new AssetContext();
            context.AssetTypes.Add(assetType);
            context.SaveChanges();
        }
        public static IList GetAsKeyValuePairs()
        {
            var context = new AssetContext();
            var types = context.AssetTypes.Select(type => new
            {
                Value = type.Id,
                Text = type.Name
            }).ToList();
            return types;
        }
        public static void Delete(int id)
        {
            var context = new AssetContext();
            var assetType = context.AssetTypes.Find(id);
            context.AssetTypes.Remove(assetType);
            context.SaveChanges();
        }
    }
}
