using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KayData
{
    class InstitutionMetadata
    {
        [Required(ErrorMessage ="*Required")]
        [Display(Name ="Institution Name")]
        [StringLength(100,ErrorMessage ="Max length 100 characters")]
        public string InstitutionName { get; set; }
        [Required(ErrorMessage = "*Required")]
        [Display(Name = "City")]
        [StringLength(50,ErrorMessage ="*Max length 50 characters")]
        public string InstitutionCity { get; set; }
        [Required(ErrorMessage = "*Required")]
        [Display(Name = "State")]
        [StringLength(2,ErrorMessage ="Use two character abbreviation",MinimumLength = 2)]
        public string InstitutionState { get; set; }

    }
    [MetadataType(typeof(InstitutionMetadata))]
    public partial class Institution
    {
    }

}
