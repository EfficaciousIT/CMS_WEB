using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmStudentTimeTable : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           
                if (Session["UserType_id"] != null && Session["User_id"] != null || Session["Student_id"] != null)
                {

                    //Label lblTitle = new Label();
                    //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
                    //lblTitle.Visible = true;
                    //lblTitle.Text = "Students Timetable";

                    if (!IsPostBack)
                    {

                    FillSTD();
                    FillDIV();
                    FillGrid();
                    ViewState["Time"] = "0";
                    geturl();
                }
                }
                else
                {
                    Response.Redirect("~\\frmIndex.aspx", false);
                }
            
        }
        catch
        {
            
        }
    }



    public void FillGrid()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "1" || Convert.ToString(Session["UserType_Id"]) == "2")
            {
                lblSTD.Visible = false;
                lblDIV.Visible = false;
                ddlSTD.Visible = false;
                ddlDIV.Visible = false;
                strQry = "exec usp_TimeTable @type='FillGrid',@STD='" + Convert.ToString(Session["Standard_id"]) + "',@DIV='" + Convert.ToString(Session["Division_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                grvTimetable.DataSource = dsObj;
                grvTimetable.DataBind();
                
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "3")
            {
                lblSTD.Visible = false;
                lblDIV.Visible = false;
                ddlSTD.Visible = false;
                ddlDIV.Visible = false;

                strQry = "exec usp_TimeTable @type='GetSTD_DIV',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intTeacher_id='" + Convert.ToString(Session["User_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    Session["Standard_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
                    Session["Division_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                }

                strQry = "";
                strQry = "exec usp_TimeTable @type='FillGrid',@STD='" + Convert.ToString(Session["Standard_id"]) + "',@DIV='" + Convert.ToString(Session["Division_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intTeacher_id='" + Convert.ToString(Session["User_id"]) + "'";
                dsObj = sGetDataset(strQry);
                grvTimetable.DataSource = dsObj;
                grvTimetable.DataBind();
            }
            else
            {
                lblSTD.Visible = true;
                lblDIV.Visible = true;
                ddlSTD.Visible = true;
                ddlDIV.Visible = true;
                strQry = "exec usp_TimeTable @type='FillGrid',@STD='" + Convert.ToString(ddlSTD.SelectedValue) + "',@DIV='" + ddlDIV.SelectedValue + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                grvTimetable.DataSource = dsObj;
                grvTimetable.DataBind();
            }
        }
        catch
        {
            
        }
    }
    public void FillSTD()
    {
        try
        {

        
            strQry = "exec [usp_getAttendance] @type='FillStd',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
            FillDIV();
            
        }
        catch
        {

        }
    }
    public void FillDIV()
    {
        try
        {
            strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlDIV, strQry, "vchDivisionName", "intDivision_id");
           
        }
        catch
        {

        }
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDIV();
        FillGrid();
    }
    protected void ddlDIV_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
  
    protected void grvTimetable_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblRecess =(Label)e.Row.FindControl("lblRecess");
                Label lblTime = (Label)e.Row.FindControl("lblPeriod");
                Label lblSrNo = (Label)e.Row.FindControl("lblSrno");
                

                if (lblRecess.Text == "1" || lblRecess.Text == "True")
                {
                   e.Row.BackColor = System.Drawing.Color.Silver;
                   e.Row.Font.Bold = true;
                   e.Row.ForeColor = System.Drawing.Color.Red;
                   e.Row.Cells[2].Text = "R";
                   e.Row.Cells[3].Text = "E";
                   e.Row.Cells[4].Text = "C";
                   e.Row.Cells[5].Text = "E";
                   e.Row.Cells[6].Text = "S";
                   e.Row.Cells[7].Text = "S";

                }
            }
        }
        catch
        {
            
        }
    }
   
}