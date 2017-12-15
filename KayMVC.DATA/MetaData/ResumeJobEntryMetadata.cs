using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KayData
{
    class ResumeJobEntryMetadata
    {
        [Display(Name ="Responsibility")]
        public int EntryID { get; set; }
        [Display(Name ="Company Name")]
        public int CompanyID { get; set; }
        [Display(Name ="Start Date")]
        [DataType(DataType.Date)]
        public System.DateTime DateBegin { get; set; }
        [Display(Name ="End Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateEnd { get; set; }
        [Display(Name ="Relevant to current applications?")]
        public bool isRelevant { get; set; }
        [Required(ErrorMessage ="*Required")]
        [StringLength(50,ErrorMessage ="Max length 50 characters")]
        public string Title { get; set; }

    }
    [MetadataType(typeof(ResumeJobEntryMetadata))]
    public partial class ResumeJobEntry
    {
    }

}
