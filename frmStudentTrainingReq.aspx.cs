using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class frmStudentTrainingReq : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = createDataTable();
        GridView1.DataBind();         
    }
    private object createDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("training");
        dt.Columns.Add("startdate");
        dt.Columns.Add("endate");
        dt.Columns.Add("time");
        dt.Columns.Add("roomno");
        dt.Columns.Add("status");        

        DataRow dr1 = dt.NewRow();
        dr1["training"] = "Dance Training";
        dr1["startdate"] = "20-09-2014";
        dr1["endate"] = "25-09-2014";
        dr1["time"] = "05:30 PM";
        dr1["roomno"] = "201";
        dr1["status"] = "Applied";      
        dt.Rows.Add(dr1);        
        return dt;
    }

    private object filltrainingnotofication()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Title");
        dt.Columns.Add("Description");
        dt.Columns.Add("startdate");
        dt.Columns.Add("enddate");
        dt.Columns.Add("applicationdate");        

        DataRow dr1 = dt.NewRow();
        dr1["Title"] = "Dance Training";
        dr1["Description"] = "Need a dance training";
        dr1["startdate"] = "10-09-2014";
        dr1["enddate"] = "20-09-2014";
        dr1["applicationdate"] = "05-09-2014";        
        dt.Rows.Add(dr1);
        return dt;
    }
}
