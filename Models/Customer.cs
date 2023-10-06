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
    public class Customer
    {
        public int action { get; set; }

        public int customer_id { get; set; }
       
        [Required(ErrorMessage ="*")]
        public string customer_name { get; set; }
       
        public string address_text { get; set; }
       
        public string contact_no { get; set; }
        [Required(ErrorMessage = "*")]
        public string email { get; set; }
        public string password { get; set; }

        public DataTable customerDT { get; set; }
    }
}