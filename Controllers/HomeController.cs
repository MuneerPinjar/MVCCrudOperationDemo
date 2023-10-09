
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
        //public CustomerMiddleLayer customerMiddleLayer;
        //public HomeController()
        //{
        //    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["bootcampdb"].ConnectionString);
        //    customerMiddleLayer = new CustomerMiddleLayer(sqlConnection);
        //}

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        //public ActionResult registration()
        //{
        //    Customer customerViewModel = new Customer();

        //    customerViewModel.customerDT = GetRegistrationData(customerViewModel);
        //    return View(customerViewModel); 
        //}

        //DataTable GetRegistrationData(Customer customerViewModel)
        //{
        //    customerViewModel.action = 2;// Pass action to get data
        //    return customerMiddleLayer.CustomerCRUD(customerViewModel, "UserRegistration");
        //}

        //[HttpPost]
        //public ActionResult registration(CustomerViewModel model)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        DataTable dt =  new DataTable();
        //        model.action = model.customer_id > 0 ? 4 : 1;

        //        Customer customer = new Customer();
        //        customer.action = model.action;
        //        customer.customer_id = model.customer_id;
        //        customer.customer_name = model.customer_name;
        //        customer.address_text = model.address_text;
        //        customer.password = model.password;
        //        customer.email = model.email;
        //        customer.contact_no = model.contact_no;

        //        dt = customerMiddleLayer.CustomerCRUD(customer, "UserRegistration");
        //        if(dt != null) { 

        //            if(dt.Rows.Count > 0)
        //            {
        //                if (Convert.ToInt32(dt.Rows[0]["StatusCode"]) == 1)
        //                {
        //                    ViewBag.StatusCode = dt.Rows[0]["StatusCode"];
        //                    ViewBag.Msg = dt.Rows[0]["Msg"];


        //                    //Bind Data after Data saved to db
        //                    ModelState.Clear();
        //                    Customer modelNew = new Customer();
        //                    modelNew.customerDT = GetRegistrationData(modelNew);

        //                }
        //            }
        //            else
        //            {
        //                ViewBag.Msg = "Something went wrong!! NO rows returned from DB ";
        //            }
        //        }


        //    }
        //    else
        //    {
        //        ViewBag.Msg = "Something went wrong!! Check ModelState";
        //    }

        //    return View(model);

        //}


        //public JsonResult edit_customer(int customer_id)

        //{

        //    Customer model = new Customer();

        //    try

        //    {

        //        model.action = 3;

        //        model.customer_id = customer_id;

        //        DataTable dt = customerMiddleLayer.CustomerCRUD(model, "UserRegistration");

        //        if (dt != null && dt.Rows.Count > 0)

        //        {

        //            model.customer_id = Convert.ToInt32(dt.Rows[0]["customer_id"]);

        //            model.customer_name = dt.Rows[0]["customer_name"].ToString();

        //            model.address_text = dt.Rows[0]["address_text"].ToString();

        //            model.contact_no = dt.Rows[0]["contact_no"].ToString();

        //            model.email = dt.Rows[0]["email"].ToString();

        //            model.password = dt.Rows[0]["password"].ToString();

        //        }

        //    }

        //    catch (Exception ex)

        //    {

        //    }

        //    return Json(model, JsonRequestBehavior.AllowGet);

        //}



        MiddlerLayer objML = new MiddlerLayer();

        public ActionResult Index()

        {

            return View();

        }

        [HttpGet]
        public ActionResult registration()

        {

            Customer objModel = new Customer();

            objModel.customerDT = GetRegistrationData(objModel);

            return View(objModel);

        }

        [HttpPost]

        public ActionResult registration(Customer model)

        {



            if (ModelState.IsValid)

            {

                DataTable dtt = new DataTable();

                model.action = model.customer_id > 0 ? 4 : 1; //Pass Action To Insert And Update Data

                dtt = objML.CustomerCRUD(model, "UserRegistration");

                if (dtt.Rows.Count > 0)

                {

                    if (Convert.ToInt32(dtt.Rows[0]["StatusCode"]) == 1)

                    {

                        ViewBag.StatusCode = dtt.Rows[0]["StatusCode"];

                        ViewBag.Msg = dtt.Rows[0]["Msg"];



                        //BindDataAfter DataSaved

                        ModelState.Clear();

                        model = new Customer();

                        model.customerDT = GetRegistrationData(model);

                    }

                }

                else

                {

                    ViewBag.Msg = "Something Went Wrong !";

                }

            }

            else

            {

                ViewBag.Msg = "Something Went Wrong !";

            }

            return View(model);

        }



        DataTable GetRegistrationData(Customer model)

        {

            model.action = 2; //Pass Action To Get Data

            return objML.CustomerCRUD(model, "UserRegistration");

        }

        public JsonResult edit_customer(int customer_id)

        {

            Customer model = new Customer();

            try

            {

                model.action = 3;

                model.customer_id = customer_id;

                DataTable dt = objML.CustomerCRUD(model, "UserRegistration");

                if (dt != null && dt.Rows.Count > 0)

                {

                    model.customer_id = Convert.ToInt32(dt.Rows[0]["customer_id"]);

                    model.customer_name = dt.Rows[0]["customer_name"].ToString();

                    model.address_text = dt.Rows[0]["address_text"].ToString();

                    model.contact_no = dt.Rows[0]["contact_no"].ToString();

                    model.email = dt.Rows[0]["email"].ToString();

                    model.password = dt.Rows[0]["password"].ToString();

                }

            }

            catch (Exception ex)

            {

            }

            return Json(model, JsonRequestBehavior.AllowGet);

        }


    }
}