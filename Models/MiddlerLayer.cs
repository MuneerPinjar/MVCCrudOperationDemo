
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MVCCrudOperationDemo.Models
{
    public class MiddlerLayer
    {
        DataLayer objDL = new DataLayer();

        public DataTable CustomerCRUD(Customer Objp, string ProcName)

        {

            DataTable dtt = new DataTable();

            SqlParameter[] param = new SqlParameter[]

            {

                new SqlParameter("@action",Objp.action),

                new SqlParameter("@customer_id",Objp.customer_id),

                new SqlParameter("@customer_name",Objp.customer_name),

                new SqlParameter("@address_text",Objp.address_text),

                new SqlParameter("@contact_no",Objp.contact_no),

                new SqlParameter("@email",Objp.email),

                new SqlParameter("@password",Objp.password)

            };

            dtt = objDL.ExecProc(ProcName, param);

            return dtt;

        }



        public DataTable AutoCompele(string ProcName)

        {

            DataTable dtt = new DataTable();

            SqlParameter[] param = new SqlParameter[]

            {

            };

            dtt = objDL.ExecProc(ProcName, param);

            return dtt;

        }
    }
}