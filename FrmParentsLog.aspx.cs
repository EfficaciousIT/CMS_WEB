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

public partial class FrmParentsLog : DBUtility
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTitle = new Label();
        lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
        lblTitle.Visible = true;
        lblTitle.Text = "Login Logs";
        try
        {

            if (!IsPostBack)
            {

                checksession();
                geturl();

                DropDownList5.SelectedValue = DateTime.Now.Month.ToString();
                DropDownList1.SelectedValue = DateTime.Now.Month.ToString();
                string cumon=DateTime.Now.Month.ToString();
                filldata();
                 

            }
        }
        catch
        { 
        
        }
    }
 
    protected void filldata()
                {
                string Disquery = "Execute dbo.usp_log @command='parentslog1',@intUser_id='" + Session["User_id"] + "',@intschool_id='" + Session["School_id"] + "'";
                int Leavegrid = sBindGrid(Gridlog1, Disquery);

                string Disquery1 = "Execute dbo.usp_log @command='parentslogall',@intUser_id='" + Session["User_id"] + "',@intschool_id='" + Session["School_id"] + "'";
                int Leavegrid1 = sBindGrid(Gridlog2, Disquery1);


                string DisRepoquery1 = "Execute dbo.usp_log @command='parents5log',@intUser_id='" + Session["User_id"] + "',@intschool_id='" + Session["School_id"] + "'";
                int Leavegrid2 = sBindGrid(Gridlog3, DisRepoquery1);

                string DisRepoquery2 = "Execute dbo.usp_log @command='parentstudlog',@intUser_id='" + Session["User_id"] + "',@intschool_id='" + Session["School_id"] + "'";
                int Leavegrid3 = sBindGrid(Gridlog4, DisRepoquery2);
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
    protected void Gridlog3_PageIndexChanging(object sender, EventArgs e)
    {

    }
    protected void Gridlog3_RowCancelingEdit(object sender, EventArgs e)
    {

    }
    protected void Gridlog3_RowDeleting(object sender, EventArgs e)
    {

    }
    protected void Gridlog3_RowEditing(object sender, EventArgs e)
    {

    }
    protected void Gridlog4_PageIndexChanging(object sender,GridViewPageEventArgs e)
    {
        Gridlog4.PageIndex=e.NewPageIndex;
        filldata();
    }
    protected void Gridlog4_RowCancelingEdit(object sender, EventArgs e)
    {

    }
    protected void Gridlog4_RowDeleting(object sender, EventArgs e)
    {

    }
    protected void Gridlog4_RowEditing(object sender, EventArgs e)
    {

    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {


        int monid = Convert.ToInt32(DropDownList5.SelectedItem.Value);
        
        string Disquery1 = "Execute dbo.usp_log @command='parentslogallmon',@intUser_id='" + Session["User_id"] + "',@intschool_id='" + Session["School_id"] + "',@monid='" + monid + "'";
        int Leavegrid1 = sBindGrid(Gridlog2, Disquery1);

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {


        int monid = Convert.ToInt32(DropDownList1.SelectedItem.Value);
        string Disquery1 = "Execute dbo.usp_log @command='ParentStudentMon',@intUser_id='" + Session["User_id"] + "',@intschool_id='" + Session["School_id"] + "',@monid='" + monid + "'";
        int Leavegrid1 = sBindGrid(Gridlog4, Disquery1);

    }

}