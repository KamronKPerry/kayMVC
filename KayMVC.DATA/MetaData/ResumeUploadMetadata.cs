using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace KayMVC.DATA
{
    public class ResumeUploadMetadata
    {
        [Display(Name ="Resume Name")]
        [DataType(DataType.Upload)]
        public string ResumeName { get; set; }
        [Display(Name ="Current Resume?")]
        public bool isCurrent { get; set; }
        [Display(Name ="Date Uploaded")]
        [DataType(DataType.Date)]
        public System.DateTime UploadDate { get; set; }

    }
    [MetadataType(typeof(ResumeUploadMetadata))]
    public partial class ResumeUpload
    {
       
    }
}
