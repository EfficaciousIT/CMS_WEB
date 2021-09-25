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

public partial class frmStudentTeacherRemarkP : DBUtility
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
               
                if (!IsPostBack)
                {
                    checksession();
                    geturl();
                    gridfill();
                    DropDown5.SelectedValue = DateTime.Now.Month.ToString();
                }
         
        }
        catch
        {
            throw;

        }

    }
    protected void gridfill()
    {

        if (Convert.ToString(Session["UserType_id"]) == "2")
        {
            string Disquery = "Execute dbo.usp_Profile @command='TeacherRemarkP',@intStudent_id='" + Session["Student_id"] + "',@intSchool_id='" + Session["School_id"] + "'";
        int Leavegrid = sBindGrid(GridView1, Disquery);
        GridView1.Columns[0].Visible = false;
        }
       

       
    }


    protected void DropDown5_SelectedIndexChanged(object sender, EventArgs e)
    {

        int monid = Convert.ToInt32(DropDown5.SelectedItem.Value);

        string Disquery = "Execute dbo.usp_Profile @command='TeacherRemarkPMon',@intStudent_id='" + Session["Student_id"] + "',@intSchool_id='" + Session["School_id"] + "',@month_id='" + monid + "'";
        int grvDetail1 = sBindGrid(GridView1, Disquery);


    }

  
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        gridfill();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        gridfill();
    }
}
