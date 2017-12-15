using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KayData
{
    class SkillMetadata
    {
        public int SkillID { get; set; }
        [Required(ErrorMessage="*Required")]
        [Display(Name ="Skill Name")]
        [StringLength(50,ErrorMessage ="Max length 50 characters")]
        public string SkillName { get; set; }
        [Display(Name ="Highlight?")]
        public bool Highlight { get; set; }

    }
    [MetadataType(typeof(SkillMetadata))]
    public partial class Skill
    {
    }

}
