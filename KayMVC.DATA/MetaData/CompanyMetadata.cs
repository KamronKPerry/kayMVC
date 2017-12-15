using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KayData
{
    class CompanyMetadata
    {
        [Display(Name ="Company Name")]
        [Required(ErrorMessage ="*Required")]
        [StringLength(50,ErrorMessage ="Max length 50 characters")]
        public string Company_Name { get; set; }
        [StringLength(50,ErrorMessage ="Max length 50 characters")]
        public string Address { get; set; }
        [Required(ErrorMessage ="*Required")]
        [StringLength(50,ErrorMessage ="Max Length 50 characters")]
        public string City { get; set; }
        [Required(ErrorMessage ="*Required")]
        [StringLength(maximumLength:2,ErrorMessage ="Please use abbreviation.", MinimumLength =2)]
        public string State { get; set; }
        [StringLength(maximumLength: 5,ErrorMessage ="Max length 5 characters",MinimumLength = 5)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage ="Must be a number.")]
        public string Zip { get; set; }
    }
    [MetadataType(typeof(CompanyMetadata))]
    public partial class Company
    {
    }
}
