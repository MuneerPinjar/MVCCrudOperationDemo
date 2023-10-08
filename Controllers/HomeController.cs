using MiddleLayer;
using MiddleLayer.Model;
using MVCCrudOperationDemo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCCrudOperationDemo.Controllers
{

   

    public class HomeController : Controller
    {
        public CustomerMiddleLayer customerMiddleLayer;
        public HomeController()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["bootcampdb"].ConnectionString);
            customerMiddleLayer = new CustomerMiddleLayer(sqlConnection);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult registration()
        {
            Customer customerViewModel = new Customer();

            customerViewModel.customerDT = GetRegistrationData(customerViewModel);
            return View(customerViewModel); 
        }
        
        DataTable GetRegistrationData(Customer customerViewModel)
        {
            customerViewModel.action = 2;// Pass action to get data
            return customerMiddleLayer.CustomerCRUD(customerViewModel, "UserRegistration");
        }

        [HttpPost]
        public ActionResult registration(CustomerViewModel model)
        {
            if(ModelState.IsValid)
            {
                DataTable dt =  new DataTable();
                model.action = model.customer_id > 0 ? 4 : 1;

                Customer customer = new Customer();
                customer.action = model.action;
                customer.customer_id = model.customer_id;
                customer.customer_name = model.customer_name;
                customer.address_text = model.address_text;
                customer.password = model.password;
                customer.email = model.email;
                customer.contact_no = model.contact_no;

                dt = customerMiddleLayer.CustomerCRUD(customer, "UserRegistration");
                if(dt != null) { 
                
                    if(dt.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dt.Rows[0]["StatusCode"]) == 1)
                        {
                            ViewBag.StatusCode = dt.Rows[0]["StatusCode"];
                            ViewBag.Msg = dt.Rows[0]["Msg"];


                            //Bind Data after Data saved to db
                            ModelState.Clear();
                            Customer modelNew = new Customer();
                            modelNew.customerDT = GetRegistrationData(modelNew);

                        }
                    }
                    else
                    {
                        ViewBag.Msg = "Something went wrong!! NO rows returned from DB ";
                    }
                }


            }
            else
            {
                ViewBag.Msg = "Something went wrong!! Check ModelState";
            }

            return View(model);

        }


    }
}