using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KayData
{
    class GraphicsSampleMetadata
    {
        [Display(Name ="Image Name")]
        [DataType(DataType.Upload)]
        public string ImageName { get; set; }
        [Display(Name ="Active?")]
        public bool IsActive { get; set; }
        public string Information { get; set; }
        [Display(Name ="Graphic Title")]
        [Required(ErrorMessage ="*Required")]
        public string GraphicTitle { get; set; }

    }
    [MetadataType(typeof(GraphicsSampleMetadata))]
    public partial class GraphicsSample
    {
    }

}
