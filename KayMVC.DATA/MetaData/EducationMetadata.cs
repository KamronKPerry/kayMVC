using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KayData
{
    class EducationMetadata
    {
        public int EducationID { get; set; }
        [Display(Name ="Degree Title")]
        [Required(ErrorMessage ="*Required")]
        [StringLength(100,ErrorMessage ="Max length 100 characters")]
        public string DegreeName { get; set; }
        public Nullable<int> GPA { get; set; }
        [Display(Name ="Completion Date")]
        public Nullable<System.DateTime> Completion { get; set; }
        [Display(Name ="Major")]
        [StringLength(50,ErrorMessage ="Max length 50 characters")]
        public string Major { get; set; }
        [Display(Name ="Minor")]
        [StringLength(50, ErrorMessage = "Max length 50 characters")]
        public string Minor { get; set; }
        [Display(Name ="Major Emphasis")]
        [StringLength(100, ErrorMessage = "Max length 100 characters")]
        public string MajorEmphasis { get; set; }
        [Display(Name ="Minor Emphasis")]
        [StringLength(100, ErrorMessage = "Max length 100 characters")]
        public string MinorEmphasis { get; set; }

    }
    [MetadataType(typeof(EducationMetadata))]
    public partial class Education
    {
    }

}
