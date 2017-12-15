using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KayData
{
    class AboutMetadata
    {
        [Required(ErrorMessage ="*Required")]
        [Display(Name = "Text")]
        public string Info { get; set; }
        [Display(Name = "Show On Page?")]
        public bool isActive { get; set; }
    }
    [MetadataType(typeof(AboutMetadata))]
    public partial class About
    {
    }
}
