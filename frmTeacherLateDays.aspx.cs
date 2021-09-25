using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmTeacherLateDays : DBUtility
{
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    string strQry;
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           

                if (Session["UserType_id"] != null && Session["User_id"] != null || Session["Student_id"] != null)
                {
                    Label lblTitle = new Label();
                    lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
                    lblTitle.Visible = true;
                    lblTitle.Text = "Staff Late Days Detail";
                    if (!IsPostBack)
                    {
                    GetData();
                    FillUserType();
                    FillDept();
                    FillTeacher();
                    ddlMonth1.SelectedValue = Convert.ToString(DateTime.Now.Month);
                    ddlMonth1_SelectedIndexChanged(null, null);
                    geturl();
                }
                }
                else
                {
                    Response.Redirect("~\\frmIndex.aspx", false);
                }
            
        }
        catch (Exception)
        {

        }
    }
    private DataSet GetData()
    {
        try
        {
            strQry = "exec usp_getAttendance @type='getTeacherCalenderLateAtt   ',@intUser_id='" + Convert.ToString(ddlTeacher.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            Session["Table"] = dsObj;
            return dsObj;
        }
        catch (Exception)
        {
            return dsObj;
        }


    }
    public void FillUserType()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_FillDropDown] @type='StaffUserType',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlType, strQry, "vchUser_name", "intUserType_id");


           
        }
        catch
        {
            MessageBox("Problem Found");
        }
    }
    public void MessageBox(string msg)
    {
        try
        {
            string script = "alert(\"" + msg + "\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

        }
        catch (Exception)
        {
            // return msg;
        }
    }
    public void FillDept()
    {
        try
        {

            strQry = "exec usp_FillDropDown @type='TrainingDepartment',@intSchool_id='" + Session["School_id"] + "',@intUserType='" + Convert.ToString(ddlType.SelectedValue) + "'";
            sBindDropDownList(ddlDept, strQry, "vchDepartment_name", "intDepartment");
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillGrid();
            GetData();
        }
        catch (Exception)
        {

        }
    }
    protected void CalAttendance_DayRender(object sender, DayRenderEventArgs e)
    {
        string Day_Date = e.Day.Date.ToShortDateString();

        if (e.Day.Date.Day.ToString() == "15")
        {
            ddlMonth1.SelectedValue = Convert.ToString(e.Day.Date.Month);
            ddlMonth1_SelectedIndexChanged(null, null);
        }

        try
        {
            if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F14C57");
                e.Cell.ToolTip = "Holiday";
                return;
            }
            if (((DataSet)Session["Table"] != null))
            {
                foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                {

                    string scheduledDate = Convert.ToDateTime(dr["LoginDateTime"]).ToShortDateString();
                    string scheduled_LoginTime = Convert.ToString(dr["Login"]);
                    string scheduled_LogoutTime = dr["LogoutDateTime"].ToString();
                    string WeekDay = dr["vchDay"].ToString();
                    if (scheduled_LogoutTime == "")
                    {
                        scheduled_LogoutTime = "0";
                    }
                    else
                    {
                        scheduled_LogoutTime = Convert.ToString(dr["LogoutDateTime"]);
                    }
                    if (e.Day.Date.ToString("dd") == "15")
                    {
                        Month = e.Day.Date.Month;
                        Year = e.Day.Date.Year;
                        ddlMonth1.SelectedValue = Convert.ToString(Month);
                    }
                    if (scheduledDate.Equals(Day_Date))
                    {


                        LinkButton lb = new LinkButton();
                        LiteralControl lc = new LiteralControl();
                        LiteralControl lc1 = new LiteralControl();
                        LiteralControl lc2 = new LiteralControl();

                        string status = Convert.ToString(dr["Present_Status"]);
                        if (status == "Early")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=blue>Early</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Early";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#006600");

                        }
                       
                        
                        else if (status == "Late")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=maroon>Late</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Late";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#6699FF");

                        }
                       

                    }
                    else
                    {

                       
                    }

                }

            }
            FillGrid();

        }
        catch (Exception ex)
        {

        }

    }
    private object createDataTable()
    {
        try
        {

            strQry = "exec usp_getAttendance @type='getTeacherLateAtt',@intUser_id='" + Convert.ToString(ddlTeacher.SelectedValue) + "',@month='" + Month + "',@year='" + Year + "'";

            dsObj = sGetDataset(strQry);
            Session["Attend"] = dsObj;
            return dsObj;
        }
        catch
        {
            return 0;
        }



    }
    public void FillGrid()
    {
        try
        {
            grvLate.DataSource = createDataTable();
            grvLate.DataBind();
        }
        catch (Exception)
        {


        }
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillTeacher();
    }
    public void FillTeacher()
    {
        try
        {
            strQry = "exec usp_FillDropDown @type='GetStaff',@intDept_id='" + Convert.ToString(ddlDept.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intUserType='" + Convert.ToString(ddlType.SelectedValue) + "'";
                sBindDropDownList(ddlTeacher, strQry, "Name", "intTeacher_id");
           
        }
        catch
        {


        }
    }
    protected void grvLate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvLate.PageIndex = e.NewPageIndex;
        FillGrid();
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDept();
        FillTeacher();
    }
    protected void lnkPrevious_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlMonth1.SelectedValue != "1")
            {
                ddlMonth1.SelectedValue = Convert.ToString((Convert.ToInt32(ddlMonth1.SelectedValue) - 1));
                ddlMonth1_SelectedIndexChanged(null, null);
            }
            else
            {
                ddlMonth1.SelectedValue = Convert.ToString(12);
                if (CalAttendance.VisibleDate.Year != 001)
                {
                    Year = CalAttendance.VisibleDate.Year-1;
                }
                else
                {
                    Year = DateTime.Now.Year;
                }
                FillGrid();
                Month = 12;
                CalAttendance.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
                GetData();
            }
        }
        catch
        {

        }
    }
    protected void ddlMonth1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Month = Convert.ToInt32(ddlMonth1.SelectedValue);
            if (CalAttendance.VisibleDate.Year != 001)
            {
                Year = CalAttendance.VisibleDate.Year;
            }
            else
            {
                Year = DateTime.Now.Year;
            }
            FillGrid();

            CalAttendance.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
            GetData();

        }
        catch
        {

        }
    }
    protected void lnkNext_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlMonth1.SelectedValue != "12")
            {
                ddlMonth1.SelectedValue = Convert.ToString((Convert.ToInt32(ddlMonth1.SelectedValue) + 1));
                ddlMonth1_SelectedIndexChanged(null, null);
            }
            else
            {
                ddlMonth1.SelectedValue = Convert.ToString(1);
                Month = 1;
                Year = DateTime.Now.Year + 1;
                FillGrid();

                CalAttendance.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
                GetData();
            }
        }
        catch
        {
        }
    }
}