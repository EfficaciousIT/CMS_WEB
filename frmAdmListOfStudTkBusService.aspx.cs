using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmAdmListOfStudTkBusService :DBUtility
{
    int outval, appval, teachappresul, resultval=0;
    public string strQry = string.Empty;
    public string appresult = string.Empty;
    public string query1 = string.Empty;
    public string query2 = string.Empty;
    public string stanv = string.Empty;
    public string divva = string.Empty;
    public string query15 = string.Empty;
 
    bool st, st1 = true;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTitle = new Label();
        lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
        lblTitle.Visible = true;
        lblTitle.Text = "List Of Students Taken Bus Services";
        if (!IsPostBack)
        {
            try
            {
                checksession();
                geturl();
                 query1 = "Execute dbo.usp_BusService @command='AdmStandStudTkBusService',@intSchool_id='" + Session["School_id"] + "'";
                 st = sBindDropDownListAll(Drop11, query1, "vchStandard_name", "intStandard_id");
                Drop11.SelectedValue = "A";
                 query2 = "Execute dbo.usp_BusService @command='AdmDiviStudTkBusService',@intSchool_id='" + Session["School_id"] + "'";
                 st1 = sBindDropDownListAll(Drop12, query2, "vchDivisionName", "intDivision_id");
                Drop12.SelectedValue = "A";
              

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

             query1 = "Execute dbo.usp_BusService @command='AdmRepoStudTkBusService',@intSchool_id='" + Session["School_id"] + "' ";

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
        
         stanv=Drop11.SelectedItem.Value;
        if (stanv != "A")
        {
            query2 = "Execute dbo.usp_BusService @command='AdmDSiviStudTkBusService',@intSchool_id='" + Session["School_id"] + "',@intStandard_id ='" + stanv + "' ";
             st1 = sBindDropDownListAll(Drop12, query2, "vchDivisionName", "intDivision_id");

            query1 = "Execute dbo.usp_BusService @command='AdmRepoStudTkBusStan',@intSchool_id='" + Session["School_id"] + "',@intStandard_id ='" + stanv + "' ";

            outval = sBindGrid(GridView1, query1);
        }
        else if (stanv == "A")
        {

            fillGrid();
            query2 = "Execute dbo.usp_BusService @command='AdmDiviStudTkBusService',@intSchool_id='" + Session["School_id"] + "'";
             st1 = sBindDropDownListAll(Drop12, query2, "vchDivisionName", "intDivision_id");
            Drop12.SelectedValue = "A";
    
        }
        else if (stanv == "0")
        {
            GridView1.Visible = false;
            Drop12.SelectedValue = "0";
        }
   
    }
    protected void Drop12_SelectedIndexChanged(object sender, EventArgs e)
    {
         stanv = Drop11.SelectedItem.Value;
         divva = Drop12.SelectedItem.Value;
        
        if (stanv == "A")
        {

            if (divva == "A")
            {
                query15 = "Execute dbo.usp_BusService @command='AdmRepoStudTkBusService',@intSchool_id='" + Session["School_id"] + "'";
                
            }
            else if (divva != "0")
            {
                query15 = "Execute dbo.usp_BusService @command='AdmRepoStudTkDivi',@intSchool_id='" + Session["School_id"] + "',@intDivision_id='" + divva + "'";
            }
       }
        else if (stanv != "0")
        {
            if (divva == "A")
            {
                query15 = "Execute dbo.usp_BusService @command='AdmRepoStudTkBusStan',@intSchool_id='" + Session["School_id"] + "',@intStandard_id ='" + stanv + "' ";
                
            }
            else if (divva != "0")
            {
                query15 = "Execute dbo.usp_BusService @command='AdmRepoSStanDiv',@intSchool_id='" + Session["School_id"] + "',@intStandard_id ='" + stanv + "' ,@intDivision_id='" + divva + "'";
            }
            
        }

      

        outval = sBindGrid(GridView1, query15);
    }
}