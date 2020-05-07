using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AssetTracking.Domain
{
    [Table("AssetType")]
    public class AssetType
    {
        //[Key, ForeignKey("AssetTypeId")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Asset> Assets { get; set; }  // navigation property
    }
}
