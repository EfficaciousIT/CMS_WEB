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
using System.Data.SqlClient;

public partial class frmTeachLeaveRequest : DBUtility
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label lblTitle = new Label();
            lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            lblTitle.Visible = true;
            lblTitle.Text = "Leave Application Detail";
            if (!IsPostBack)

            {
                checksession();
                geturl();

            
            }

            TabContainer1.Visible = true;
        }
        catch 
        {
        
        }
 
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

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        DateTime startdate = DateTime.Parse(txtfromdate.Text.Trim());
        DateTime enddate = DateTime.Parse(txttodate.Text.Trim());        
        TimeSpan t = enddate.Subtract(startdate);
        txtNoofDays.Text = Convert.ToString(t.Days);       
    }
    protected void DropDownDropcalender_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
