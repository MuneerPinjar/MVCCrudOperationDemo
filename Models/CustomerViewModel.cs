using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrudOperationDemo.Models
{
    [Bind(Exclude = "action")]
    public class CustomerViewModel
    {
        public int action { get; set; }

        public int customer_id { get; set; }
       
     
        public string customer_name { get; set; }
        [Required(ErrorMessage ="* Address text is required")]
        public string address_text { get; set; }
       
        public string contact_no { get; set; }

        public string email { get; set; }
        [Required(ErrorMessage = "*")]
        public string password { get; set; }

        public DataTable customerDT { get; set; }
    }
}