using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmListOfStudTkBusService :DBUtility
{
    int outval, appval,teachappresul;
    int resultval;
    string strQry, appresult;

    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTitle = new Label();
        lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
        lblTitle.Visible = true;
        lblTitle.Text = "Student Details";
        if (!IsPostBack)
        {
            try
            {
                checksession();
                geturl();
                string query1 = "Execute dbo.usp_BusService @command='StandStudTkBusService',@intSchool_id='" + Session["School_id"] + "',@intTeacher_id='" + Session["User_id"] + "' ";
                bool st = sBindDropDownListAll(Drop11, query1, "vchStandard_name", "intStandard_id");
                Drop11.SelectedValue = "A";
                string query2 = "Execute dbo.usp_BusService @command='DiviStudTkBusService',@intSchool_id='" + Session["School_id"] + "',@intTeacher_id='" + Session["User_id"] + "' ";
                bool st1 = sBindDropDownListAll(Drop12, query2, "vchDivisionName", "intDivision_id");
                Drop12.SelectedValue = "A";
                //drop11
                //drop12

                fillGrid();
            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }
    protected void fillGrid()
    {
        try
        {
            
               string query1 = "Execute dbo.usp_BusService @command='RepoStudTkBusService',@intSchool_id='" + Session["School_id"] + "',@intTeacher_id='" + Session["User_id"] + "' ";

               outval = sBindGrid(GridView1, query1);
     
        }
        catch (Exception ex)
        {
        }
    }

    
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
      
       
      
    }

    protected void Drop11_SelectedIndexChanged(object sender, EventArgs e)
    {
        string query2, query1;
        string stanv=Drop11.SelectedItem.Value;
        if (stanv != "A")
        {
            query2 = "Execute dbo.usp_BusService @command='DSiviStudTkBusService',@intSchool_id='" + Session["School_id"] + "',@intTeacher_id='" + Session["User_id"] + "',@intStandard_id ='" + stanv + "' ";
            bool st1 = sBindDropDownListAll(Drop12, query2, "vchDivisionName", "intDivision_id");

             query1 = "Execute dbo.usp_BusService @command='RepoStudTkBusStan',@intSchool_id='" + Session["School_id"] + "',@intTeacher_id='" + Session["User_id"] + "',@intStandard_id ='" + stanv + "' ";

            outval = sBindGrid(GridView1, query1);
        }
        else if (stanv == "A")
        {

            fillGrid();
            query2 = "Execute dbo.usp_BusService @command='DiviStudTkBusService',@intSchool_id='" + Session["School_id"] + "',@intTeacher_id='" + Session["User_id"] + "' ";
            bool st1 = sBindDropDownListAll(Drop12, query2, "vchDivisionName", "intDivision_id");
            Drop12.SelectedValue = "A";
           // Drop12.SelectedValue = "A";
        }
        else if (stanv == "0")
        {
            GridView1.Visible = false;
            Drop12.SelectedValue = "0";
        }
   
    }
    protected void Drop12_SelectedIndexChanged(object sender, EventArgs e)
    {
        string stanv = Drop11.SelectedItem.Value;
        string divva = Drop12.SelectedItem.Value;
        string query15 = null;
        if (stanv == "A")
        {

            if (divva == "A")
            {
                 query15 = "Execute dbo.usp_BusService @command='RepoStudTkBusService',@intSchool_id='" + Session["School_id"] + "',@intTeacher_id='" + Session["User_id"] + "' ";
                
            }
                  // else if (divva != "0")
            else 
            {
                query15 = "Execute dbo.usp_BusService @command='RepoStudTkDivi',@intSchool_id='" + Session["School_id"] + "',@intTeacher_id='" + Session["User_id"] + "',@intDivision_id='" + divva + "'";
            }
       }
          //  else if (stanv != "0")
        else 
        {
            if (divva == "A")
            {
                query15 = "Execute dbo.usp_BusService @command='RepoStudTkBusStan',@intSchool_id='" + Session["School_id"] + "',@intTeacher_id='" + Session["User_id"] + "',@intStandard_id ='" + stanv + "' ";
                
            }
            else
            {
                query15 = "Execute dbo.usp_BusService @command='RepoSStanDiv',@intSchool_id='" + Session["School_id"] + "',@intTeacher_id='" + Session["User_id"] + "',@intStandard_id ='" + stanv + "' ,@intDivision_id='" + divva + "'";
            }
            
        }

      

        outval = sBindGrid(GridView1, query15);
    }
}