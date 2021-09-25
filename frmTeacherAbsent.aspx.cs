using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmTeacherAbsent :DBUtility
{
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    string strQry;
    DataSet dsObj, dsAbsent;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           
                if (Session["UserType_id"] != null && Session["User_id"] != null || Session["Student_id"] != null)
                {
                    Label lblTitle = new Label();
                    lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
                    lblTitle.Visible = true;
                    lblTitle.Text = "Staff Absent Days Detail";

                    if (!IsPostBack)
                    {

                    FillCalDataset(Convert.ToInt32(DateTime.Now.Year), Convert.ToInt32(DateTime.Now.Month));
                    FillUserType();
                    FillDept();
                    FillTeacher();
                    ddlMonth1.SelectedValue = Convert.ToString(DateTime.Now.Month);
                    ddlMonth1_SelectedIndexChanged(null, null);
                    geturl();
                    TabContainer1.Visible = false;

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
    private DataSet GetData(DateTime FirstDt, DateTime LastDt)
    {
        try
        {
            strQry = "exec usp_getAttendance @type='getTeacherCalendarAbsentAtt',@intUser_id='" + Convert.ToString(ddlTeacher.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@FrmDt='" + FirstDt + "',@EndDt='" + LastDt + "',@month='" + Month + "',@year='"+ Year +"'";
            dsObj = sGetDataset(strQry);
            Session["Table"] = dsObj;
            return dsObj;
        }
        catch (Exception)
        {
            return dsObj;
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
            FillGrid(CalAttendance.VisibleDate.Year, Convert.ToInt32(ddlMonth1.SelectedValue));
            FillCalDataset(Convert.ToInt32(CalAttendance.VisibleDate.Year), Convert.ToInt32(ddlMonth1.SelectedValue));
            if (ddlTeacher.SelectedValue != "0")
            {
                TabContainer1.Visible = true;
            }
            else
            {
                TabContainer1.Visible = false;
            }

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

                        string status = Convert.ToString(dr["Status"]);
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
                        else if (status == "Early Reported Web")//manual
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Early(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Early Reported Web";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Leave")//manual
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Ontime(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Leave";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Late Reported Web")//manual
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Late(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Late Reported Web";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Present(From Web)")//attandance Issue
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Ontime(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Present(From Web)";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Out Of Office")//out of office
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=Yellow>Out Of Office</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Out Of Office";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Ontime Reported")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Ontime</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Ontime Reported";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        }
                        else if (status == "Late")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=maroon>Late</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Late";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#6699FF");

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
                        else
                        {
                            // e.Cell.Controls.Add(lc1);
                            e.Cell.ToolTip = "Absent";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                        }

                    }
                    //else
                    //{

                    //    if ((e.Day.Date <= DateTime.Now.Date) && (e.Cell.BackColor == System.Drawing.ColorTranslator.FromHtml("#FFFFFF")))
                    //    {
                    //        // e.Cell.Controls.Add(lc1);
                    //        e.Cell.ToolTip = "Absent";
                    //        e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                    //    }
                    //}

                }

            }
            FillGrid(CalAttendance.VisibleDate.Year,CalAttendance.VisibleDate.Month);

        }
        catch (Exception ex)
        {

        }

    }
    protected void FillCalDataset(int Y, int M)
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
        DateTime lastDate = GetFirstDayOfNextMonth(Month, Year);
        dsObj = GetData(firstDate, lastDate);
        //dsAbsent = createDataTable(); ;//createDataTable(firstDate, lastDate);
    }
    protected DateTime GetFirstDayOfNextMonth(int M, int Y)
    {
        DateTime lastDate;
        try
        {
            int monthNumber = M, yearNumber = Y;
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
    private DataSet createDataTable()
    {
        try
        {

            strQry = "exec usp_getAttendance @type='getTeacherAbsentAtt',@intUser_id='" + Convert.ToString(ddlTeacher.SelectedValue) + "',@month='" + Month + "',@year='" + Year + "',@intSchool_id='" + Session["School_id"] + "'";//,@FrmDt='" + FirstDt + "',@EndDt='" + LastDt + "'";

            dsObj = sGetDataset(strQry);
            Session["Attend"] = dsObj;
            return dsObj;
        }
        catch
        {
            return dsObj;
        }



    }
    public void FillGrid(int Year,int Month)
    {
        try
        {
            FillCalDataset(Year, Month);
            dsAbsent = createDataTable();
            grvAttendance.DataSource = dsAbsent;
            grvAttendance.DataBind();
        }
        catch (Exception)
        {


        }
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillTeacher();
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
    public void FillTeacher()
    {
        try
        {
            //if (ddlDept.SelectedValue != "0")
            //{


                strQry = "exec usp_FillDropDown @type='GetStaff',@intDept_id='" + Convert.ToString(ddlDept.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intUserType='" + Convert.ToString(ddlType.SelectedValue) + "'";
                sBindDropDownList(ddlTeacher, strQry, "Name", "intTeacher_id");

                //if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
                //    ddlTeacher.Items.Add(new ListItem("All", "-1"));
            //}
            //else
            //{
            //    ddlTeacher.DataSource = null;
            //    ddlTeacher.DataBind();
            //}



        }
        catch
        {


        }
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
                Year = CalAttendance.VisibleDate.Year;
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
                if (CalAttendance.VisibleDate.Year != 001)
                {
                    Year = CalAttendance.VisibleDate.Year + 1;
                }
                else
                {
                    Year = DateTime.Now.Year;
                }
                FillGrid(Year,Month);
                Month = 1;
                CalAttendance.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
                GetData(Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year), Convert.ToDateTime("30/" + Month.ToString().PadLeft(2, '0') + "/" + Year));
            }
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
                    exp.ExportGrid(grvAttendance, ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlTeacher.SelectedValue), Convert.ToString(ddlTeacher.SelectedItem.Text), Convert.ToString(ddlDept.SelectedItem.Text), "", ddlType.SelectedValue, ddlMonth1.SelectedItem.Text + " Month Attendance");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["UserType_Id"] + "',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";

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
                exp.Page_Load(null, null, grvAttendance, ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(), Convert.ToInt32(ddlTeacher.SelectedValue), Convert.ToString(ddlTeacher.SelectedItem.Text), Convert.ToString(ddlDept.SelectedItem.Text), "", ddlType.SelectedValue, ddlMonth1.SelectedItem.Text + " Month Attendance");

                strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonth1.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["UserType_Id"] + "',@vchReportFormat='Pdf',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";
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
}