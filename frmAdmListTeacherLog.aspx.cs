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

public partial class frmAdmListTeacherLog : DBUtility
{
    DataSet dsObj = new DataSet();
    
    DataSet dsObj1 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!IsPostBack)
            {
                checksession();
                geturl();
           
                listparengrid.Visible = false;
                string query1 = "Execute dbo.usp_Profile @command='SeleDepart',@intSchool_id='" + Session["School_id"] + "' ";
                bool st = sBindDropDownListAll(DropDownList1, query1, "vchDepartment_name", "intDepartment");

                string query2 = "Execute dbo.usp_Profile @command='SeleTeachId',@intSchool_id='" + Session["School_id"] + "' ";
                bool st2 = sBindDropDownListAll(DropDownList2, query2, "Name", "intTeacher_id");
                DropDownList1.SelectedValue = "A";
                DropDownList2.SelectedValue = "A";
                filldata();
            }
        }
        catch (Exception ex)
        {
        
        }
    }
    protected void filldata()
    {
        try
        {

            string  Depa = DropDownList1.SelectedItem.Value;
            string  DID = DropDownList2.SelectedItem.Value;
            string Disquery;
            if (DID == "A" && Depa == "A")
            {

                Disquery = "Execute dbo.usp_log @command='LiTeaclogvl',@intschool_id='" + Session["School_id"] + "'";
                int Leavegrid = sBindGrid(GridViliTeachdvl, Disquery);
            }
            else if (DID == "A" && Depa != "A")
            {
                Disquery = "Execute dbo.usp_log @command='LiTeaclogAll',@intschool_id='" + Session["School_id"] + "',@intDepartment_id='" + Depa + "'";
                int Leavegrid = sBindGrid(GridViliTeachdvl, Disquery);
            
            }
            else if (DID != "A" && Depa == "A")
            {
                Disquery = "Execute dbo.usp_log @command='LiTeaclogv2',@intUser_id='" + DID + "',@intschool_id='" + Session["School_id"] + "'";
                int Leavegrid = sBindGrid(GridViliTeachdvl, Disquery);
            }
            else if (DID != "A" && Depa != "A")
            {

                Disquery = "Execute dbo.usp_log @command='LiTeaclogV3',@intUser_id='" + DID + "',@intschool_id='" + Session["School_id"] + "',@intDepartment_id='" + Depa + "'";
                int Leavegrid = sBindGrid(GridViliTeachdvl, Disquery);
            }
           
        
         }
        catch
        { 

        }

    }

    protected void GridViliTeachdvl_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
    }
    protected void GridViliTeachdvl_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridViliTeachdvl_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      
       
    }
  
    protected void DropDownList37_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void DropDownList38_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownL1_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            int stat = Convert.ToInt32(DropDownList1.SelectedItem.Value);
         
            string query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "' ";
            bool st2 = sBindDropDownListAll(DropDownList1, query2, "vchDivisionName", "intDivision_id");
        }
        catch
        {

        }

    }
    protected void DropDownL2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int stat1 = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            int Div1 = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            
            string query3 = "Execute dbo.usp_Profile @command='RemarkRollNo',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "' ";

            bool st3 = sBindDropDownListAll(DropDownList1, query3, "Name", "intStudent_id");
        }
        catch
        {

        }
    }

    protected void GridViliTeachdvl_RowCancelingEdit(object sender, EventArgs e)
    {

    }
    protected void GridViliTeachdvl_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    
    }

    protected void GridViliTeachdvl_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViliTeachdvl.PageIndex = e.NewPageIndex;
        filldata();
    }
    protected void GridViliTeachdvl_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
 
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        
        
        string selDepar = DropDownList1.SelectedItem.Value;
        if (selDepar == "A")
        {
            string query2 = "Execute dbo.usp_Profile @command='SeleTeachIdDepaAll',@intSchool_id='" + Session["School_id"] + "'";
            bool st2 = sBindDropDownListAll(DropDownList2, query2, "Name", "intTeacher_id");
            DropDownList2.SelectedValue = "A";
        }
        else if (selDepar != "0")
        {
            string query2 = "Execute dbo.usp_Profile @command='SeleTeachIdDepa',@intSchool_id='" + Session["School_id"] + "',@intsubject_id='" + selDepar + "' ";
            bool st2 = sBindDropDownListAll(DropDownList2, query2, "Name", "intTeacher_id");
            DropDownList2.SelectedValue="A";
        }
        filldata();
        }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        filldata();
    }
}


