
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