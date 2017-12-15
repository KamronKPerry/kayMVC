using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KayData
{
    class ResponsibilityMetadata
    {
        [Display(Name ="Job Entry")]
        public int EntryID { get; set; }
        [Required(ErrorMessage="*Required")]
        [StringLength(150,ErrorMessage ="Max length 150 characters")]
        [Display(Name ="Responsibility Title")]
        public string Responsibility1 { get; set; }


    }
    [MetadataType(typeof(ResponsibilityMetadata))]
    public partial class Responsibility
    {
    }

}
