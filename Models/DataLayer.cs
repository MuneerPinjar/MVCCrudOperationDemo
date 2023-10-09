using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace MVCCrudOperationDemo.Models
{
    public class DataLayer
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["bootcampdb"].ConnectionString);

        public DataTable ExecProc(string ProName, SqlParameter[] Param)

        {

            DataTable dt = new DataTable();

            try

            {

                con.Open();

                SqlCommand cmd = new SqlCommand(ProName, con);

                cmd.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter prm in Param)

                {

                    cmd.Parameters.Add(prm);

                }

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                adp.Fill(dt);

            }

            catch (Exception)

            {

            }

            finally

            {

                con.Close();

            }

            return dt;

        }
    }
}