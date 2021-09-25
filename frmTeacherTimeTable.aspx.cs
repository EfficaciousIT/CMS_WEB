using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmTeacherTimeTable : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
       
            if (Session["UserType_id"] != null && Session["User_id"] != null || Session["Student_id"] != null)
            {
                //Label lblTitle = new Label();
                //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
                //lblTitle.Visible = true;
                //lblTitle.Text = "Lecture Schedule Detail";
                if (!IsPostBack)
                {
                    FillDept();
                    //FillTeacher();
                    FillGrid();
                    ViewState["Time"] = "0";
                    geturl();
                }
            }
            else
            {
                Response.Redirect("~\\index.aspx", false);
            }
        
    }
    public void FillDept()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_TimeTable] @type='GetDept',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlDept, strQry, "vchDepartment_name", "intDepartment");
        }
        catch 
        {
            
        }
    }
    public void FillTeacher()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_TimeTable @type='GetTeacher',@Dept='" + Convert.ToString(ddlDept.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlTeacher, strQry, "Name", "intTeacher_id");
        }
        catch 
        {
            
        }
    }
    public void FillGrid()
    {
        try
        {



                if (Convert.ToString(Session["UserType_Id"]) == "4" || Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
                {
                    selection.Visible = true;
                    lblDept.Visible = true;
                    lblTeacher.Visible = true;
                    ddlTeacher.Visible = true;
                    ddlDept.Visible = true;
                    strQry = "exec usp_TimeTable @type='TeachertimeTable',@intTeacher_id='" + Convert.ToString(ddlTeacher.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                    dsObj = sGetDataset(strQry);
                    grvTimetable.DataSource = dsObj;
                    grvTimetable.DataBind();

                }
                else if (Convert.ToString(Session["UserType_Id"]) == "3")
                {
                    lblDept.Visible = false;
                    lblTeacher.Visible = false;
                    ddlTeacher.Visible = false;
                    ddlDept.Visible = false;
                    selection.Visible = false;
                    strQry = "exec usp_TimeTable @type='TeachertimeTable',@intTeacher_id='" + Convert.ToString(Session["User_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                    dsObj = sGetDataset(strQry);
                    dsObj = sGetDataset(strQry);
                    grvTimetable.DataSource = dsObj;
                    grvTimetable.DataBind();
                }

        }
        catch
        {

        }
    }
    protected void grvTimetable_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblRecess = (Label)e.Row.FindControl("lblRecess");
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
    protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillGrid();
        }
        catch 
        {
            
        }
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillTeacher();
            FillGrid();
        }
        catch
        {
            
        }
    }
}