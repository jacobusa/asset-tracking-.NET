using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetTracking.Presentation.Models
{
    public class AssetModel
    {
        public int Id { get; set; }
        public string TagNumber { get; set; }
        public int AssetTypeId { get; set; }
        //public AssetType AssetType { get; set; }    // navigation property
        [Display (Name= "Type Name")]
        public string AssetTypeName { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
    }
}
