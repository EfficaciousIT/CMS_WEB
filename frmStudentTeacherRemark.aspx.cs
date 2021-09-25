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

public partial class frmStudentTeacherRemark : DBUtility
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Label lblTitle = new Label();
            lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            lblTitle.Visible = true;
            lblTitle.Text = "Teacher's Remark";
               
                if (!IsPostBack)
                {
                    checksession();
                    geturl();
                    gridfill();
                }
         
        }
        catch
        {
            throw;

        }

    }
    protected void gridfill()
    {

        if (Convert.ToString(Session["UserType_id"]) == "1")
        {
        string Disquery = "Execute dbo.usp_Profile @command='TeacherRemark',@intStudent_id='" + Session["Student_id"] + "',@intSchool_id='" + Session["School_id"] + "'";
        int Leavegrid = sBindGrid(GridView1, Disquery);
        GridView1.Columns[0].Visible = false;
        }
        else if (Convert.ToString(Session["UserType_id"]) == "3")
        {

        string Disquery1 = "Execute dbo.usp_Profile @command='TeacherRemarkView',@intUser_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";
        int Leavegrid1 = sBindGrid(GridView1, Disquery1);
        }

        else if (Convert.ToString(Session["UserType_id"]) == "5")
        {
        
        divDis.Visible=true;
        string query1 = "Execute dbo.usp_Profile @command='AdmRemarkViewSta',@intSchool_id='" + Session["School_id"] + "' ";
                bool st = sBindDropDownListAll(Drop11, query1, "vchStandard_name", "intStandard_id");
                Drop11.SelectedValue = "A";

            
        string Disquery1 = "Execute dbo.usp_Profile @command='AdmRemarkView',@intSchool_id='" + Session["School_id"] + "'";
        int Leavegrid1 = sBindGrid(GridView1, Disquery1);


        string query51 = "Execute dbo.usp_Profile @command='AdmReViewDiviAll',@intSchool_id='" + Session["School_id"] + "'";
        bool stva1 = sBindDropDownListAll(Drop12, query51, "vchDivisionName", "intDivision_id");
        Drop12.SelectedValue = "A";
        }
    }

    protected void Drop11_SelectedIndexChanged(object sender, EventArgs e)
    {
        string  stav1=Drop11.SelectedItem.Value;
      


        if (stav1 != "A")
        {
            string query51 = "Execute dbo.usp_Profile @command='AdmRemarkViewDivi',@intSchool_id='" + Session["School_id"] + "',@intstandard_id='" + stav1 + "' ";
            bool st = sBindDropDownListAll(Drop12, query51, "vchDivisionName", "intDivision_id");

            string query1 = "Execute dbo.usp_Profile @command='AdmRemarkViewS',@intSchool_id='" + Session["School_id"] + "',@intStandard_id ='" + stav1 + "' ";

            int outval = sBindGrid(GridView1, query1);
        }
        else if (stav1 == "A")
        {

           gridfill();
            //string query2 = "Execute dbo.usp_Profile @command='DiviStudTkBusService',@intSchool_id='" + Session["School_id"] + "',@intTeacher_id='" + Session["User_id"] + "' ";
            //bool st1 = sBindDropDownListAll(Drop12, query2, "vchDivisionName", "intDivision_id");
            //Drop12.SelectedValue = "A";
            // Drop12.SelectedValue = "A";
        }
        else if (stav1 == "0")
        {
            GridView1.Visible = false;
            Drop12.SelectedValue = "0";
        }


    }
    protected void Drop12_SelectedIndexChanged(object sender, EventArgs e)
    {
        string stav1 = Drop11.SelectedItem.Value;
        string dIVv1 = Drop12.SelectedItem.Value;

        string Disquery1 = "Execute dbo.usp_Profile @command='AdmRemarkViewSD',@intSchool_id='" + Session["School_id"] + "',@intstandard_id='" + stav1 + "',@intDivision_id='" + dIVv1 + "'  ";
        int Leavegrid1 = sBindGrid(GridView1, Disquery1);
       
        string query15 = null;
        if (stav1 == "A")
        {

            if (dIVv1 == "A")
            {
                query15 = "Execute dbo.usp_Profile @command='AdmRemarkView',@intSchool_id='" + Session["School_id"] + "' ";

            }
  
            else
            {
                query15 = "Execute dbo.usp_Profile @command='AdmRemarkViewD',@intSchool_id='" + Session["School_id"] + "',@intDivision_id='" + dIVv1 + "'";
            }
        }
       
        else
        {
            if (dIVv1 == "A")
            {
                query15 = "Execute dbo.usp_Profile @command='AdmRemarkViewS',@intSchool_id='" + Session["School_id"] + "',@intStandard_id ='" + stav1 + "' ";

            }
            else
            {
                query15 = "Execute dbo.usp_Profile @command='AdmRemarkViewSD',@intSchool_id='" + Session["School_id"] + "',@intstandard_id='" + stav1 + "',@intDivision_id='" + dIVv1 + "' ";
            }

        }

      int  outval = sBindGrid(GridView1, query15);

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
