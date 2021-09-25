using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmPreSchoAbseBus :DBUtility
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
        lblTitle.Text = "Bus Absent Details";
        if (!IsPostBack)
        {
            try
            {

                if (Convert.ToString(Session["UserType_id"]) == "3")
                {
                    fillGrid();
                }
                else if(Convert.ToString(Session["UserType_id"]) == "5" )
                {
                    fillGridA();
                }
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

            string query1 = "Execute dbo.usp_BusService @command='PreSchoAbseBus',@intSchool_id='" + Session["School_id"] + "',@intTeacher_id='" + Session["User_id"] + "'";

               outval = sBindGrid(GridView1, query1);
      
        }
        catch (Exception ex)
        {
        }
    }

    protected void fillGridA()
    {
        try
        {

            string query1 = "Execute dbo.usp_BusService @command='PreSchoAbseBusA',@intSchool_id='" + Session["School_id"] + "'";

            outval = sBindGrid(GridView1, query1);

        }
        catch (Exception ex)
        {
        }
    }

    
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
      
       
      
    }
    protected void Gridview1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
     {
         try
         {
             GridView1.PageIndex = e.NewPageIndex;

             if (Convert.ToString(Session["UserType_id"]) == "3")
             {
                 fillGrid();
             }
             else if (Convert.ToString(Session["UserType_id"]) == "5")
             {
                 fillGridA();

             }
         }
         catch 
         {
         
         }

     
     }



    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}