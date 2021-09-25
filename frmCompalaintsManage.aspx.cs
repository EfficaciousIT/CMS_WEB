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

public partial class frmCompalaintsManage : DBUtility
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label lblTitle = new Label();
            lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            lblTitle.Visible = true;
            lblTitle.Text = "Compaints Detail";
            if (!IsPostBack)
            {
                checksession();
                geturl();

            }
            GridView1.DataSource = createDataTable();
            GridView1.DataBind();
        }
        catch
        { 
        
        
        }
        }
    private object createDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("schoolname");
        dt.Columns.Add("Complaint");
        dt.Columns.Add("datetime");
        dt.Columns.Add("time");
        dt.Columns.Add("name");
        dt.Columns.Add("Mobile");
        dt.Columns.Add("Email");

        DataRow dr = dt.NewRow();
        dr["schoolname"] = "st.Xavier";
        dr["Complaint"] = "Login device is not working";
        dr["datetime"] = "01-05-2014 10:29 PM";
        dr["time"] = "10:29 PM";
        dr["name"] = "saurabh sukla";
        dr["Mobile"] = "9988998899";
        dr["Email"] = "saurabh.shukla@xavier.com";
        dt.Rows.Add(dr);
        return dt;
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
}
