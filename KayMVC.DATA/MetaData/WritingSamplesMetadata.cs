using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KayData.Metadata
{
    class WritingSamplesMetadata
    {
        public int SampleID { get; set; }
        [Display(Name ="Sample Name")]
        [Required(ErrorMessage="*Required")]
        [StringLength(50,ErrorMessage ="Max length 50 characters")]
        public string SampleTitle { get; set; }
        [Required(ErrorMessage ="*Required")]
        [Display(Name ="Why was this sample done, how is it relevant?")]
        public string SampleContext { get; set; }
        [Display(Name ="Additional information?")]
        public string SampleAdditionalContext { get; set; }
        [Display(Name ="Does it have a graphic sample friend?")]
        public Nullable<int> GraphicPairing { get; set; }

    }
    [MetadataType(typeof(WritingSamplesMetadata))]
    public partial class WritingSample
    {
    }

}
