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

public partial class frmAjaxLeaveMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["userstatus"]) == "student" || Convert.ToString(Session["userstatus"]) == "teacher" || Convert.ToString(Session["userstatus"]) == "parent")
            {
                TabPanel5.Visible = false;
                TabPanel4.Visible = false;
            }
            if (Convert.ToString(Session["userstatus"]) == "teacher" || Convert.ToString(Session["userstatus"]) == "parent")
            {
                TabPanel6.Visible = true;
                TabPanel3.Visible = true;
            }
            else if (Convert.ToString(Session["userstatus"]) == "student")
            {
                TabPanel6.Visible = true;
                TabPanel3.Visible = true;
            }

            GridView5.DataSource = createDataTable();
            GridView5.DataBind();
            GridView1.DataSource = createDataTable();
            GridView1.DataBind();

            GridView4.DataSource = fillEditable();
            GridView4.DataBind();
        }
    }
    private object createDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Application Date");
        dt.Columns.Add("From Date");
        dt.Columns.Add("To Date");
        dt.Columns.Add("Reason");
        dt.Columns.Add("Total no of Days");
        dt.Columns.Add("Parent Approval");
        dt.Columns.Add("Parent Approval date");
        dt.Columns.Add("Teachers Approval");
        dt.Columns.Add("Teachers Approval date");


        DataRow dr = dt.NewRow();
        dr["Application Date"] = "29-07-2014";
        dr["From Date"] = "12-08-2014";
        dr["To Date"] = "15-08-2014";
        dr["Reason"] = "illness";
        dr["Total no of Days"] = "3";
        dr["Parent Approval"] = "Yes";
        dr["Parent Approval date"] = "29-07-2014";
        dr["Teachers Approval"] = "Pending";
        dr["Teachers Approval date"] = "None";
        dt.Rows.Add(dr);
        return dt;
    }
    protected object fillEditable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ApplicationDate");
        dt.Columns.Add("FromDate");
        dt.Columns.Add("ToDate");
        dt.Columns.Add("Reason");        
        dt.Columns.Add("TotalnofDays");

        DataRow dr = dt.NewRow();
        dr["ApplicationDate"] = "29-07-2014";
        dr["FromDate"] = "12-08-2014";
        dr["ToDate"] = "15-08-2014";
        dr["Reason"] = "illness";
        dr["TotalnofDays"] = "3";
        dt.Rows.Add(dr);
        return dt;
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_PageIndexChanging(object sender, EventArgs e)
    {

    }
    protected void GridView2_RowCancelingEdit(object sender, EventArgs e)
    {

    }
    protected void GridView2_RowDeleting(object sender, EventArgs e)
    {

    }
    protected void GridView2_RowEditing(object sender, EventArgs e)
    {

    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView4_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
    }
    protected void GridView4_DataBound(object sender, EventArgs e)
    {
        
    }
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Image img = (Image)e.Row.FindControl("btnEdit");
            img.Attributes.Add("onclick", "window.open('Default2.aspx','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=200,width=330,top=150,left=500');return false");
        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        DateTime startdate = DateTime.Parse(txtfromdate.Text.Trim());
        DateTime enddate = DateTime.Parse(txttodate.Text.Trim());        
        TimeSpan t = enddate.Subtract(startdate);
        txtNoofDays.Text = Convert.ToString(t.Days);       
    }
}
