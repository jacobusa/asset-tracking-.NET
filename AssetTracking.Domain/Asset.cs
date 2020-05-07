using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetTracking.Domain
{
    [Table("Asset")]
    public class Asset
    {
        public int Id { get; set; }
        [Required]
        public string TagNumber { get; set; }
        //[Key, ForeignKey("Id")]
        public int AssetTypeId { get; set; }
        //[Required]
        public AssetType AssetType { get; set; }    // navigation property
        [Required]
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SerialNumber { get; set; }
    }
}
