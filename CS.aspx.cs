using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    [WebMethod]
    public static string[] GetCustomers(string prefix)
    {
        List<string> customers = new List<string>();
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["esms"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                //cmd.CommandText = "select vchstudentfirst_name+' '+vchstudentlast_name as vchstudentfirst_name,intstudent_id from Student_Master where vchstudentfirst_name like @SearchText + '%'";
                cmd.CommandText = "select vchstudentfirst_name+' '+vchstudentlast_name as vchstudentfirst_name,intstudent_id,vchStandard_name+'/'+vchDivisionName as vchStandard_name,intAddmission_id from Student_Master inner join tblstandard_master on Student_Master.intstanderd_id=tblstandard_master.intstandard_id inner join tblDivision_master on Student_Master.intDivision_id=tblDivision_master.intDivision_id where (vchstudentfirst_name like @SearchText + '%') OR (vchstudentlast_name like @SearchText + '%')";
                cmd.Parameters.AddWithValue("@SearchText", prefix);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(string.Format("{0}-{1}-{2}-{3}", sdr["vchstudentfirst_name"], sdr["intstudent_id"], sdr["vchStandard_name"], sdr["intAddmission_id"]));
                    }
                }
                conn.Close();
            }
        }
        return customers.ToArray();
    }


    protected void Submit(object sender, EventArgs e)
    {
        string customerName = Request.Form[txtSearch.UniqueID];
        string customerId = Request.Form[hfCustomerId.UniqueID];
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + customerName + "\\nID: " + customerId + "');", true);
    }
}
