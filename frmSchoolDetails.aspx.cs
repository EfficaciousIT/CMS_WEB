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

public partial class frmSchoolDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = createDataTable();
        GridView1.DataBind();
    }
    private object createDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Schoolname");
        dt.Columns.Add("Shortname");
        dt.Columns.Add("Contactperson");
        dt.Columns.Add("MobileNo");
        dt.Columns.Add("Email");
        dt.Columns.Add("Studentcapacity");
        dt.Columns.Add("State");
        dt.Columns.Add("City");


        DataRow dr = dt.NewRow();
        dr["Schoolname"] = "St.xavier";
        dr["Shortname"] = "St.xavier";
        dr["Contactperson"] = "Mr.paul";
        dr["MobileNo"] = "9820764572";
        dr["Email"] = "paul@xyz.com";
        dr["Studentcapacity"] = "500";
        dr["State"] = "Maharashtra";
        dr["City"] = "Mumbai";
        dt.Rows.Add(dr);
        return dt;
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("frmSchoolEntry.aspx");
    }
}
