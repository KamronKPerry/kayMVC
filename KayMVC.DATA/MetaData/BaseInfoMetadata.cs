using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KayData
{
    class BaseInfoMetadata
    {
        [Required(ErrorMessage ="*Required")]
        [StringLength(50,ErrorMessage ="Max length 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage ="*Required")]
        [StringLength(50, ErrorMessage = "Max length 50 characters")]
        public string Address { get; set; }
        [Required(ErrorMessage = "*Required")]
        [StringLength(50, ErrorMessage = "Max length 50 characters")]
        public string City { get; set; }
        [Required(ErrorMessage = "*Required")]
        [StringLength(2,ErrorMessage ="Please use 2 character abbreviation",MinimumLength =2)]
        public string State { get; set; }
        [Required(ErrorMessage = "*Required")]
        [StringLength(14,ErrorMessage ="Max length 14 characters")]
        [RegularExpression(@"^[0-9]+$",ErrorMessage ="Must be comprised of numbers")]
        [Display(Name ="Phone Number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "*Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*Required")]
        [Display(Name="Display?")]
        public bool isCurrent { get; set; }

    }
    [MetadataType(typeof(BaseInfoMetadata))]
    public partial class BaseInfo
    {
    }
}
