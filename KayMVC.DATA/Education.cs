//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KayMVC.DATA
{
    using System;
    using System.Collections.Generic;
    
    public partial class Education
    {
        public int EducationID { get; set; }
        public int InstitutionID { get; set; }
        public string DegreeName { get; set; }
        public Nullable<int> GPA { get; set; }
        public Nullable<System.DateTime> Completion { get; set; }
        public string Major { get; set; }
        public string Minor { get; set; }
        public string MajorEmphasis { get; set; }
        public string MinorEmphasis { get; set; }
    
        public virtual Institution Institution { get; set; }
    }
}