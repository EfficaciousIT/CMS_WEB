using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmStudentLateDays : DBUtility
{
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        

            if (Session["UserType_id"] != null && Session["User_id"] != null || Session["Student_id"] != null)
            {
                Label lblTitle = new Label();
                lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
                lblTitle.Visible = true;
                lblTitle.Text = "Students Late Days Detail";

                if (!IsPostBack)
                {
                GetData();
                ddlMonth1.SelectedValue = Convert.ToString(DateTime.Now.Month);
                ddlMonth1_SelectedIndexChanged(null, null);
                FillSTD();
                geturl();
                Teacher_Students();
                FillYear();
                ddlYear.SelectedValue = Convert.ToString(DateTime.Now.Year);
                ddlMonths.SelectedValue = Convert.ToString(DateTime.Now.Month);
              //  TabContainer1.Visible = false;
            }
            }
            else
            {
                Response.Redirect("~\\frmIndex.aspx", false);
            }
        
    }
    public void Teacher_Students()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "3")
            {

                strQry = "exec usp_TimeTable @type='GetSTD_DIV',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intTeacher_id='" + Convert.ToString(Session["User_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    ddlSTD.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
                    // ddlSTD_SelectedIndexChanged(null, null);
                    FillDIV();
                    ddlDIV.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                    ddlSTD.Enabled = false;
                    ddlDIV.Enabled = false;
                    FillStudent();
                }
            }
        }
        catch
        {

        }
    }
    private DataSet GetData()
    {
        try
        {
            strQry = "exec usp_getAttendance @type='getCalenderLateAtt',@intStudentId=" + Convert.ToString(ddlStudent.SelectedValue) + ",@intSchool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            Session["Table"] = dsObj;
            return dsObj;
        }
        catch (Exception)
        {
            return dsObj;
        }


    }
    protected void Linkbtndepositamt_Click(object sender, EventArgs e)
    {
    }
    public void FillSTD()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
                FillDIV();
            }
            else
            {

                strQry = "exec [usp_getAttendance] @type='FillStd',@TeacherId='" + Convert.ToString(Session["User_id"]) + "',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
                FillDIV();
            }
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
            FillStudent();
        }
        catch
        {

        }
    }
    public void FillStudent()
    {
        try
        {
            strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlStudent, strQry, "Name", "intStudent_id");


        }
        catch
        {

        }
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDIV();
    }
    protected void ddlDIV_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStudent();
    }
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStudent.SelectedValue != "0")
        {
            //TabContainer1.Visible = true;
            FillGrid();
            GetData();
            FillStudentsAttendance();
        }
        else
        {
            //TabContainer1.Visible = false;
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
    private object createDataTable()
    {
        try
        {

            strQry = "exec usp_getAttendance @type='getLateAtt',@intStudentId='" + Convert.ToString(ddlStudent.SelectedValue) + "',@month='" + Month + "',@year='" + Year + "',@intSchool_id='" + Session["School_id"] + "'";

            dsObj = sGetDataset(strQry);
            Session["Attend"] = dsObj;
            return dsObj;
        }
        catch
        {
            return 0;
        }



    }

    protected void grvLate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvLate.PageIndex = e.NewPageIndex;
        FillGrid();
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
                    Year = CalAttendance.VisibleDate.Year - 1;
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
                if (CalAttendance.VisibleDate.Year != 001)
                {
                    Year = CalAttendance.VisibleDate.Year + 1;
                }
                else
                {
                    Year = DateTime.Now.Year;
                }
                FillGrid();
                Month = 1;
                CalAttendance.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
                GetData();
            }
        }
        catch
        {
        }
    }
    public void FillStudentsAttendance()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_AttendanceSummery] @type='TotStudentsAttSummery',@Div='" + ddlDIV.SelectedValue + "',@intSchool_Id='" + Session["School_Id"] + "',@month='" + ddlMonths.SelectedValue + "',@year='" + ddlYear.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            grvStudSumm.DataSource = dsObj;
            grvStudSumm.DataBind();
        }
        catch
        {


        }
    }
    public void FillYear()
    {
        try
        {
            int count = ddlYear.Items.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                ddlYear.Items.Remove(ddlYear.Items[i].Value);
               
            }
            for (int i = 2005; i <= DateTime.Now.Year; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
               
            }
        }
        catch
        {

        }
    }
    protected void ddlMonths_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillStudentsAttendance();
        }
        catch
        {
            
        }
    }
    protected void grvStudSumm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvStudSumm.PageIndex = e.NewPageIndex;
            grvStudSumm.DataBind();

            FillStudentsAttendance();
        }
        catch 
        {
            
        }
    }

    protected void ImgXls_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            grvStudSumm.AllowPaging = false;
            ClsExportExcel exp = new ClsExportExcel();
            switch (TabContainer1.ActiveTabIndex)
            {
                case 1:
                    //  ExportGridToPDF(grvAttendance, "Attendance " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                    exp.ExportGrid(grvLate, ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), Convert.ToString(ddlStudent.SelectedItem.Text), Convert.ToString(ddlSTD.SelectedItem.Text), Convert.ToString(ddlDIV.SelectedItem.Text), "1", ddlMonth1.SelectedItem.Text + " Month Attendance");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["UserType_Id"] + "',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";

                    break;
                case 2:
                    //   ExportGrid(grdattendance, "AttendanceDetails " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                    exp.ExportGrid(grvStudSumm, "" + " " + ddlMonths.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(),  Convert.ToInt32(ddlStudent.SelectedValue), Convert.ToString(ddlStudent.SelectedItem.Text), Convert.ToString(ddlSTD.SelectedItem.Text), Convert.ToString(ddlDIV.SelectedItem.Text), "1", ddlMonths.SelectedItem.Text + " Month Attendance");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonths.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_Id"] + "',@intUserType='" + Session["User_Type"] + "',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                    break;

              
            }
            sExecuteQuery(strQry);
            grvStudSumm.AllowPaging = true;
        }
        catch
        {

        }
    }
    protected void ImgPdf_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            ClsExportPdf exp = new ClsExportPdf();

            // exp.ExportGrid(grvAttendance, "FileName" + DateTime.Now, Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", "Att");

            switch (TabContainer1.ActiveTabIndex)
            {
                case 1:
                    //  ExportGridToPDF(grvAttendance, "Attendance " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                    exp.Page_Load(null, null, grvLate, ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), 0, "", "", "", "", ddlMonth1.SelectedItem.Text + " Month Attendance");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["UserType_Id"] + "',@vchReportFormat='Pdf',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                     break;
                case 2:
                    //   ExportGrid(grdattendance, "AttendanceDetails " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                    exp.Page_Load(null, null, grvStudSumm, ddlMonths.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), 0, "", "", "", "1", ddlMonths.SelectedItem.Text + " Month Attendance");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonths.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_Id"] + "',@intUserType='" + Session["User_Type"] + "',@vchReportFormat='Pdf',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                    break;

            }
            sExecuteQuery(strQry);


        }
        catch
        {

        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillStudentsAttendance();
        }
        catch 
        {
            
        } 
    }
    protected void ImgDoc_Click(object sender, ImageClickEventArgs e)
    {
        
    }
}