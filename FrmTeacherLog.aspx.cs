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

public partial class FrmTeacherLog : DBUtility
{
    protected void Page_Load(object sender, EventArgs e)

    {
        try
        {
            Label lblTitle = new Label();
            lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            lblTitle.Visible = true;
            lblTitle.Text = "Teacher Log Detail";
            if (!IsPostBack)
            {
                checksession();
                geturl();
                DropDownList5.SelectedValue = DateTime.Now.Month.ToString();
                 filldata();
               


            }
        }
        catch 
        
        {
        }
    }

    protected void filldata()
                {
                string Disquery = "Execute dbo.usp_log @command='Teacherlog',@intUser_id='" + Session["User_id"] + "',@intschool_id='" + Session["School_id"] + "',@intUserType_id='" + Session["UserType_id"] + "'";
                int Leavegrid = sBindGrid(Gridlog1, Disquery);

                string Disquery1 = "Execute dbo.usp_log @command='Teacherlogall',@intUser_id='" + Session["User_id"] + "',@intschool_id='" + Session["School_id"] + "',@intUserType_id='" + Session["UserType_id"] + "'";
                int Leavegrid1 = sBindGrid(Gridlog2, Disquery1);
                }
    protected void Gridlog1_PageIndexChanging(object sender, EventArgs e)
    {

    }
    protected void Gridlog1_RowCancelingEdit(object sender, EventArgs e)
    {

    }
    protected void Gridlog1_RowDeleting(object sender, EventArgs e)
    {

    }
    protected void Gridlog1_RowEditing(object sender, EventArgs e)
    {

    }
    protected void Gridlog2_PageIndexChanging(object sender,GridViewPageEventArgs e)
    {
        Gridlog2.PageIndex = e.NewPageIndex;
        filldata();


    }
    protected void Gridlog2_RowCancelingEdit(object sender, EventArgs e)
    {

    }
    protected void Gridlog2_RowDeleting(object sender, EventArgs e)
    {

    }
    protected void Gridlog2_RowEditing(object sender, EventArgs e)
    {

    }
    
   
   
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {


        int monid = Convert.ToInt32(DropDownList5.SelectedItem.Value);

        string Disquery1 = "Execute dbo.usp_log @command='Teacherlogallmon',@intUser_id='" + Session["User_id"] + "',@intschool_id='" + Session["School_id"] + "',@monid='" + monid + "',@intUserType_id='" + Session["UserType_id"] + "'";
        int Leavegrid1 = sBindGrid(Gridlog2, Disquery1);

    }
   

}