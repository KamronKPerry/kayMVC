using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KayData
{
    class AchievementMetadata
    {
        [Required(ErrorMessage ="*Required")]
        [StringLength(50,ErrorMessage ="Max length 50 characters")]
        public string Name { get; set; }
        [Display(Name="Display On Front Page?")]
        public bool Hightlight { get; set; }

    }
    [MetadataType(typeof(AchievementMetadata))]
    public partial class Achievement
    {
    }
}
