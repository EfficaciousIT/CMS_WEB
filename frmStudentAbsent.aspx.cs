using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmStudentAbsent : DBUtility
{
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    string strQry = "";
    DataSet dsObj,dsCal;
    DataSet dsAbsent = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        
            if (Session["UserType_id"] != null && Session["User_id"] != null || Session["Student_id"] != null)
            {
                Label lblTitle = new Label();
                lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
                lblTitle.Visible = true;
                lblTitle.Text = "Students Absent Days Detail";
              if (!IsPostBack)
              {

                FillCalDataset(Convert.ToInt32(DateTime.Now.Year), Convert.ToInt32(DateTime.Now.Month));
                FillGrid(Convert.ToInt32(DateTime.Now.Year), Convert.ToInt32(DateTime.Now.Month));
                ddlMonth1.SelectedValue = Convert.ToString(DateTime.Now.Month);
                ddlMonth1_SelectedIndexChanged(null, null);
                FillSTD();
                geturl();
                FillYear();
                Teacher_Students();
            	}
            
        }
            else
            {
                Response.Redirect("~\\frmIndex.aspx", false);
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
            MessageBox("Problem Found");
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
    private DataSet GetData(DateTime FirstDt, DateTime LastDt)
    {
        try
        {
            strQry = "exec usp_getAttendance @type='getCalenderAbsentAtt',@intStudentId='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";//,@FrmDt='" + FirstDt + "',@EndDt='" + LastDt + "'";
            dsObj = sGetDataset(strQry);
            Session["Table"] = dsObj;
            return dsObj;
        }
        catch (Exception)
        {
            return dsObj;
        }


    }

    protected void FillCalDataset(int Y,int M)
    {
        if (CalAttendance.VisibleDate.Year == 0001)
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;

        }
        else
        {
            Year = Y;
            Month = M;
        }
        DateTime firstDate = new DateTime(Year, Month, 1);
        DateTime lastDate = GetFirstDayOfNextMonth(Month,Year);
        dsObj = GetData(firstDate, lastDate);
        dsAbsent=createDataTable(firstDate, lastDate);
    }
    protected DateTime GetFirstDayOfNextMonth(int M,int Y )
    {
        DateTime lastDate;
        try
        {
            int monthNumber=M, yearNumber=Y;
            if (CalAttendance.VisibleDate.Month == 12)
            {
                monthNumber = 1;
                yearNumber = yearNumber + 1;
            }
            else
            {
                monthNumber = monthNumber + 1;
                yearNumber = yearNumber;
            }
            lastDate = new DateTime(yearNumber, monthNumber, 1);
            return lastDate;
        }
        catch (Exception ex)
        {
            DateTime a = new DateTime(2014, 1, 1);
            return a;

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

        FillGrid(Convert.ToInt32(CalAttendance.VisibleDate.Year), Convert.ToInt32(ddlMonth1.SelectedValue));
            //FillCalDataset();
       
    }
    protected void CalAttendance_DayRender(object sender, DayRenderEventArgs e)
    {
        string Day_Date = e.Day.Date.ToShortDateString();

         if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
        {
            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F14C57");
            e.Cell.ToolTip = "Holiday";
           
        }

        if (e.Day.Date.Day.ToString() == "15")
        {
            ddlMonth1.SelectedValue = Convert.ToString(e.Day.Date.Month);
            ddlMonth1_SelectedIndexChanged(null, null);
        }

        try
        {
           
            if (((DataSet)Session["Table"] != null))
            {
                foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                {

                    string scheduledDate = Convert.ToDateTime(dr["LoginDateTime"]).ToShortDateString();
                    string scheduled_LoginTime = Convert.ToString(dr["Login"]);
                    string TeacherApprove =Convert.ToString(dr["teacherapproval"]);
                    string ParentApprove =Convert.ToString(dr["parentapproval"]);
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

                        string status = Convert.ToString(dr["status"]);
                        if (status == "Early")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=blue>Early</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Early";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#006600");

                        }
                        else if (status == "Present")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Present</font>" + "<br/>";
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Present</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Present";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Leave" && TeacherApprove == "Pending")//manual
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Early(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Leave Pending";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Leave" && TeacherApprove == "Approved")//manual
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Early(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Leave Approved";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#006600");

                        }
                        else if (status == "Leave" && TeacherApprove == "Rejected")
                        {
                            //lc2.Text = @"<br/>" + "<font size=1 color=black> Leave Approving </font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc2);
                            e.Cell.ToolTip = "Leave Rejected";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#9905af");
                        }
                        else if (status == "Absent")
                        {
                            //lc1.Text = @"<br/>" + "<font size=1 color=black>Absent</font>";
                            e.Cell.Controls.Add(lc1);
                            e.Cell.ToolTip = "Absent";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");

                        }
                        else if (status == "Leave Approving")
                        {
                            //lc2.Text = @"<br/>" + "<font size=1 color=black> Leave Approving </font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc2);
                            e.Cell.ToolTip = "Leave Approving";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#9905af");
                        }
                        else if (status == "Absent")
                        {
                            // e.Cell.Controls.Add(lc1);
                            e.Cell.ToolTip = "Absent";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                        }
                        

                    }
                    else
                    {

                        if ((e.Day.Date <= DateTime.Now.Date) && (e.Cell.BackColor == System.Drawing.ColorTranslator.FromHtml("#FFFFFF")))
                        {
                            // e.Cell.Controls.Add(lc1);
                            e.Cell.ToolTip = "Absent";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                        }
                    }

                }

            }
            FillGrid(Convert.ToInt32(CalAttendance.VisibleDate.Year), Convert.ToInt32(ddlMonth1.SelectedValue));

        }
        catch (Exception ex)
        {

        }

    }
    public void FillGrid(int Year,int Month)
    {
        try
        {
            FillCalDataset(Year,Month);
            grvAttendance.DataSource = dsAbsent;
            grvAttendance.DataBind();
        }
        catch (Exception)
        {


        }
    }
    private DataSet createDataTable(DateTime FirstDt, DateTime LastDt)
    {
        try
        {

            strQry = "exec usp_getAttendance @type='getAbsentAtt',@intStudentId='" + Convert.ToString(ddlStudent.SelectedValue) + "',@month='" + Month + "',@year='" + Year + "',@intSchool_id='" + Session["School_id"] + "',@FrmDt='" + FirstDt + "',@EndDt='" + LastDt + "'";

            dsObj = sGetDataset(strQry);
            Session["Attend"] = dsObj;
            return dsObj;
        }
        catch
        {
            return dsObj;
        }



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
                FillGrid(Year,Month);
                Month = 12;
                CalAttendance.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
                GetData(Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year), Convert.ToDateTime("30/" + Month.ToString().PadLeft(2, '0') + "/" + Year));
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
                Year = CalAttendance.VisibleDate.Year ;
            }
            else
            {
                Year = DateTime.Now.Year;
            }
            FillGrid(Year,Month);

            CalAttendance.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
            GetData(Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year), Convert.ToDateTime("30/" + Month.ToString().PadLeft(2, '0') + "/" + Year));

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
                Year = DateTime.Now.Year + 1;
                Month = 1;
                FillGrid(Year,Month);
                
                CalAttendance.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
                GetData(Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year), Convert.ToDateTime("30/" + Month.ToString().PadLeft(2, '0') + "/" + Year));
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
    public void FillStudentsAttendance()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_AttendanceSummery] @type='TotStudentsAttSummery',@Div='" + ddlDIV.SelectedValue + "',@Year='" + Convert.ToString(ddlYear.SelectedValue) + "',@intSchool_Id='" + Session["School_Id"] + "',@month='" + ddlMonths.SelectedValue + "'";
            dsObj = sGetDataset(strQry);
            grvStudSumm.DataSource = dsObj;
            grvStudSumm.DataBind();
        }
        catch
        {


        }
    }
    protected void grvStudSumm_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvStudSumm.PageIndex = e.NewPageIndex;
        grvStudSumm.DataBind();

        FillStudentsAttendance();
    }
    protected void grvAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvAttendance.PageIndex = e.NewPageIndex;
            grvAttendance.DataBind();
            FillGrid(Convert.ToInt32(CalAttendance.VisibleDate.Year), Convert.ToInt32(ddlMonth1.SelectedValue));
        }
        catch
        {
            
        }
    }



    protected void ImgXls_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ClsExportExcel exp = new ClsExportExcel();
            switch (TabContainer1.ActiveTabIndex)
            {
                case 1:
                    //  ExportGridToPDF(grvAttendance, "Attendance " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                    exp.ExportGrid(grvAttendance, ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), Convert.ToString(ddlStudent.SelectedItem.Text), Convert.ToString(ddlSTD.SelectedItem.Text), Convert.ToString(ddlDIV.SelectedItem.Text),"1", ddlMonth1.SelectedItem.Text + " Month Attendance");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["UserType_Id"] + "',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";

                    break;
                case 2:
                    //   ExportGrid(grdattendance, "AttendanceDetails " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                    exp.ExportGrid(grvStudSumm, ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), Convert.ToString(ddlStudent.SelectedItem.Text), Convert.ToString(ddlSTD.SelectedItem.Text), Convert.ToString(ddlDIV.SelectedItem.Text), "1", ddlMonths.SelectedItem.Text + " Month Attendance");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonths.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_Id"] + "',@intUserType='" + Session["User_Type"] + "',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                    break;

            }
            sExecuteQuery(strQry);

        }
        catch
        {

        }
    }
    protected void ImgPdf_Click(object sender, ImageClickEventArgs e)
    {
        ClsExportPdf exp = new ClsExportPdf();

        // exp.ExportGrid(grvAttendance, "FileName" + DateTime.Now, Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", "Att");

        switch (TabContainer1.ActiveTabIndex)
        {
            case 1:
                //  ExportGridToPDF(grvAttendance, "Attendance " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                exp.Page_Load(null, null, grvAttendance, ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), Convert.ToString(ddlStudent.SelectedItem.Text), Convert.ToString(ddlSTD.SelectedItem.Text), Convert.ToString(ddlDIV.SelectedItem.Text), "1", ddlMonth1.SelectedItem.Text + " Month Attendance");

                strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["UserType_Id"] + "',@vchReportFormat='Pdf',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                break;

            case 2:
                //  ExportGridToPDF(grvAttendance, "Attendance " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                exp.Page_Load(null, null, grvStudSumm, ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlStudent.SelectedValue), Convert.ToString(ddlStudent.SelectedItem.Text), Convert.ToString(ddlSTD.SelectedItem.Text), Convert.ToString(ddlDIV.SelectedItem.Text), "1", ddlMonths.SelectedItem.Text + " Month Attendance");

                strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonths.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["UserType_Id"] + "',@vchReportFormat='Pdf',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
                break;

        }
        sExecuteQuery(strQry);
    }
    protected void ImgDoc_Click(object sender, ImageClickEventArgs e)
    {
        switch (TabContainer1.ActiveTabIndex)
        {
            case 1:
                ExportToWord(grvAttendance, "StaffAbsentReport" + Convert.ToDateTime(DateTime.Now.Date).ToString("dd/MM/yyyy") + ".doc");
                break;

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
}