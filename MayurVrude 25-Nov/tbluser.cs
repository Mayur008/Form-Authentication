//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MayurVrude_25_Nov
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbluser
    {
        public long c_userid { get; set; }
        [Required]
        [Display(Name = "User Name")]
       public string c_username { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string c_password { get; set; }
        [Required]

        [Display(Name = "User Type")]
        public int c_usertype { get; set; }
        public String StrUsertype { get; set; }
    }
}
