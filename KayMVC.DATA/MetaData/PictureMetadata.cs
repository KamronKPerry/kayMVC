using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KayData
{
    class PictureMetadata
    {
        [Required(ErrorMessage="*Required")]
        [StringLength(100,ErrorMessage ="Max length 100 characters")]
        [Display(Name ="Image")]
        [DataType(DataType.Upload)]
        public string ImageName { get; set; }
        [Display(Name ="Display?")]
        public bool isCurrent { get; set; }
    }
    [MetadataType(typeof(PictureMetadata))]
    public partial class Picture
    {
    }

}
