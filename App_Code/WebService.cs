using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;
using System.Data;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    string connectionString = ConfigurationManager.ConnectionStrings["esms"].ToString();    
    string sp_Name = String.Empty;
    SqlConnection Conn = null;
    SqlCommand Cmd;
    DataSet ds;
    SqlDataAdapter da;
    string strQry = string.Empty;
    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool Post_AndroidRegId(String regid)
    {
        if (string.IsNullOrEmpty(regid))
            return false;
        try
        {

            strQry = "Proc_PushData_Android @User_RegId=' " + regid.Trim() + "'";            
            Conn = new SqlConnection(connectionString);
            Cmd = new SqlCommand(strQry, Conn);
            Conn.Open();
            Cmd.ExecuteNonQuery();
            Conn.Close();
            return false;

        }

        catch (Exception ex)
        {
            return false;
        }

        finally
        {
            if (sp_Name != null)
                sp_Name = null;
            if (Conn != null)
                Conn.Dispose();
        }
    }
    
}

