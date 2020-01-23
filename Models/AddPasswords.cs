using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LastPassApplication.Models
{
    public class AddPasswords
    {

        public int ID { get; set; }
        public int LoginID { get; set; }
        public string UrlName { get; set; }
        public string NameSite { get; set; }
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string SitePassword { get; set; }
        public string Notes { get; set; }


       
       
    }
}