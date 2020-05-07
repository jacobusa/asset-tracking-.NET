using AssetTracking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetTracking.Presentation.Models
{
    public class AssetTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public ICollection<Asset> Assets { get; set; }  // navigation property
    }
}
