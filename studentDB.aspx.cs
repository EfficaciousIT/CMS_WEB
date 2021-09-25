using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class studentDB : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();

    int Month;
    int Year;
    DataSet dsCal;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //string strdate = Convert.ToDateTime(DateTime.Now.Date).ToString("MM/dd/yyyy").Replace("-","/");

            //Session["School_id"] = "1";
            //Session["UserType_id"] = "1";
            //Session["User_id"] = "0";
            //Session["Student_id"] = "372";
            //Session["Standard_id"] = "5";
            //Session["Division_id"] = "40";
            //Session["strUserType"] = "1";
            fillGrid();
            Details();
            FillNoticeDetails();
            FillHoliday();
            FillLibraryDetails();
            FillInventory();
            FillLeave();
            fillFee();
            fillHomeworkCount();
            totalCount();
            GetData();
            FillBookDetails();
            FillHolidayDataset();
            FillChartGrid();
        }
        catch
        {

        }
        }
      public void FillChartGrid()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_FeesAssignSTD @type='FillGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + 1 + "',@intSTD_Id='" + 1 + "',@intCat_Id='" + 1 + "'";
            dsObj = sGetDataset(strQry);
            grv1Detail.DataSource = dsObj;
            grv1Detail.DataBind();

        }
        catch
        {

        }
    }
    protected void FillHolidayDataset()
    {
        try
        {
            if (CalAttendance.VisibleDate.Year == 0001)
            {
                Year = DateTime.Now.Year;
                Month = DateTime.Now.Month;

            }
            else
            {
                Month = CalAttendance.VisibleDate.Month;
                Year = CalAttendance.VisibleDate.Year;
            }
            DateTime firstDate = new DateTime(Year, Month, 1);
            CalAttendance.VisibleDate = new DateTime(Year, Month, 1);
            DateTime lastDate = GetFirstDayOfNextMonth();
            dsObj = GetCurrentMonthData(firstDate, lastDate);
        }
        catch
        {

        }
        }
    public DataSet GetCurrentMonthData(DateTime FirstDt, DateTime LastDt)
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_AdminDashboard] @type='FillCalendar',  @FirstDate='" + Convert.ToDateTime(FirstDt).ToString("yyyy/MM/dd") + "',@LastDate='" + Convert.ToDateTime(LastDt).ToString("yyyy/MM/dd") + "',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@intRole_Id='" + Convert.ToString(Session["UserType_id"]) + "'";
            dsCal = sGetDataset(strQry);
            return dsCal;
        }
        catch (Exception)
        {
            return dsObj;
        }
    }
    protected DateTime GetFirstDayOfNextMonth()
    {
        DateTime lastDate;
        try
        {
            int monthNumber, yearNumber;
            if (CalAttendance.VisibleDate.Month == 12 || CalAttendance.VisibleDate.Month == 11)
            {
                monthNumber = 1;
                yearNumber = DateTime.Now.Year + 1;
            }
            else
            {
                monthNumber = CalAttendance.VisibleDate.Month + 1;
                yearNumber = CalAttendance.VisibleDate.Year;
            }
            lastDate = new DateTime(yearNumber, monthNumber, 1);
            return lastDate;
        }

        catch (Exception ex)
        {
            DateTime a = new DateTime(DateTime.Now.Year, 1, 1);
            return a;

        }

    }
    protected void FillBookDetails()
    {
        strQry = "usp_tblBookAssign  @command='selectStudent',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
        {
            grvLibrary.DataSource = dsObj;
            grvLibrary.DataBind();
        }

    }
    protected void fillHomeworkCount()
    {
        try
        {
            strQry = "exec usp_StudentDB @command='HomeworkCount',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                lblHomework.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["total"]) + " Subject's";
            }
            else
            {
                lblHomework.Text = "No Homework today";
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
            string startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("MM/dd/yyyy").Replace("-", "/");
            string endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(30).ToString("MM/dd/yyyy").Replace("-", "/");

            strQry = "exec usp_getAttendance @type='getCalenderAtt',@intUserType_id='" + Convert.ToString(Session["UserType_id"]) + "',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@FrmDt='" + startDate.Trim() + "',@EndDt='" + endDate.Trim() + "'";
            dsObj = sGetDataset(strQry);
            Session["Table"] = dsObj;
            return dsObj;
        }
        catch (Exception)
        {
            return dsObj;
        }


    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        string Day_Date = e.Day.Date.ToShortDateString();
        
        try
        {
            if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F14c57");
                e.Cell.ToolTip = "Holiday";
                // return;
            }
            Boolean bln = false;
            DateTime nextDate;

            if (dsCal != null)
            {
                foreach (DataRow dr in dsCal.Tables[0].Rows)
                {

                    nextDate = (DateTime)dr["Date"];

                    LiteralControl lc = new LiteralControl();

                    if (nextDate == e.Day.Date)
                    {

                        if ((string)dr["Type"] == "Holiday")
                        {
                            //e.Cell.BackColor = System.Drawing.Color.SkyBlue;
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F14c57");
                            e.Cell.ToolTip = (string)dr["Name"];
                            e.Cell.Controls.Add(lc);
                            //lc.Text = @"<br/>" + Convert.ToString((string)dr["Name"]).Replace("Holiday: ", "");
                            //lc.Text = @"<br/>" + "<font size=1 color=blue>Holiday</font>" + "<br/>" + Convert.ToString((string)dr["Name"]);

                        }
                        else if ((string)dr["Type"] == "Vacation")
                        {
                            e.Cell.BackColor = System.Drawing.Color.BurlyWood;
                            e.Cell.ToolTip = (string)dr["Name"];
                        }
                        else if ((string)dr["Type"] == "Traning")
                        {
                            e.Cell.BackColor = System.Drawing.Color.Pink;
                            e.Cell.ToolTip = (string)dr["Name"];
                        }
                        //  e.Cell.Attributes.Add((string)dr["Name"], "1");
                    }

                }

            }


            if (((DataSet)Session["Table"] != null) && ((DataSet)Session["Table"]).Tables[0].Rows.Count > 0)
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
                        else if (status == "Ontime Reported Web")//manual
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Ontime(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Ontime Reported Web";
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
                        else if (status == "Leave")
                        {
                            //lc2.Text = @"<br/>" + "<font size=1 color=black> Leave Approving </font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc2);
                            e.Cell.ToolTip = "Leave";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6600");
                        }

                    }
                    else
                    {

                        //if (e.Day.Date<=DateTime.Now.Date)
                        //{
                        //    //lc1.Text = @"<br/>" + "<font size=1 color=black>Absent</font>";

                        //    e.Cell.ToolTip = "Absent";
                        //    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");

                        //}
                    }

                }

            }
            

        }
        catch (Exception ex)
        {

        }

    }

    protected void fillGrid()
    {
        strQry = "exec usp_TimeTable @type='FillGridDB',@STD='" + Convert.ToString(Session["Standard_id"]) + "',@DIV='" + Convert.ToString(Session["Division_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        grvTimetable.DataSource = dsObj;
        grvTimetable.DataBind();
    }

    public void totalCount()
    {
        try
        {
            strQry = "exec [usp_StudentDashboard] @type='Top5Student',@DivId='" + Session["Division_id"] + "',@intSchool_Id='" + Session["School_id"] + "',@Year='2018',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(dsObj.Tables[0].Rows[0]["SelfCount"]) != "")
                {
                    string[] strAry = Convert.ToString(dsObj.Tables[0].Rows[0]["SelfCount"]).Split('/');

                    double p = (double)(Convert.ToDouble(strAry[0]) / Convert.ToDouble(strAry[1])) * 100;

                    string s = Convert.ToString(p);

                    if (s.Length > 5)
                    {
                        lblcumulative.Text = Convert.ToString(s.Substring(0, 5));
                    }
                    else
                    {
                        lblcumulative.Text = Convert.ToString(s);
                    }
                }


            }
        }
        catch
        {

        }
        }

    protected void Details()
    {
        strQry = "exec usp_StudentDB @command='selectTime',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            lastLogin.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Date"]);
            lblExamDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["ExamDate"]);
            lblSubject.Text = "Exam : "+ Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectname"]);
            lblTitle.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Exam"]);
            lblTitle.Visible = false;
        }
        
    }
    public void FillNoticeDetails()
    {
        try
        {
            strQry = "exec [usp_StudentDashboard] @type='NoticeBoard',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@DivId='" + Convert.ToString(Session["Division_id"]) + "',@StudentId='" + Convert.ToString(Session["Student_id"]) + "' ";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                {
                    if (k == 0)
                    {
                        lblSubject1.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice1.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate1.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue_Date"]);
                        lblEndDate1.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End_Date"]);
                        Notice1.Visible = true;
                    }
                    if (k == 1)
                    {
                        lblSubject2.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice2.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate2.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue_Date"]);
                        lblEndDate2.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End_Date"]);
                        Notice2.Visible = true;
                    }
                    if (k == 2)
                    {
                        lblSubject3.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice3.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate3.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue_Date"]);
                        lblEndDate3.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End_Date"]);
                        Notice3.Visible = true;
                    }
                    if (k == 3)
                    {
                        lblSubject4.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice4.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate4.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue_Date"]);
                        lblEndDate4.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End_Date"]);
                        Notice4.Visible = true;
                    }
                    if (k == 4)
                    {
                        lblSubject5.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice5.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate5.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue_Date"]);
                        lblEndDate5.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End_Date"]);
                        Notice5.Visible = true;
                    }
                    if (k == 5)
                    {
                        lblSubject6.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice6.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate6.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue_Date"]);
                        lblEndDate6.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End_Date"]);
                        Notice6.Visible = true;
                    }
                    if (k == 6)
                    {
                        lblSubject7.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice7.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate7.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue_Date"]);
                        lblEndDate7.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End_Date"]);
                        Notice7.Visible = true;
                    }
                    if (k == 7)
                    {
                        lblSubject8.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice8.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate8.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue_Date"]);
                        lblEndDate8.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End_Date"]);
                        Notice8.Visible = true;
                    }
                    if (k == 8)
                    {
                        lblSubject9.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice9.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate9.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue_Date"]);
                        lblEndDate9.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End_Date"]);
                        Notice9.Visible = true;
                    }
                    if (k == 9)
                    {
                        lblSubject10.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice10.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate10.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue_Date"]);
                        lblEndDate10.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End_Date"]);
                        Notice10.Visible = true;
                    }
                }
            }

        }
        catch
        {

        }
    }
    public void FillHoliday()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ChartStudentAttendance @type='FillHoliday',@SchoolId='" + Session["School_Id"] + "',@month='" + Convert.ToString(DateTime.Now.Month) + "',@Year='" + Convert.ToString(DateTime.Now.Year) + "'";
            dsObj = sGetDataset(strQry);
            grvHoliday.DataSource = dsObj;
            grvHoliday.DataBind();


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
                    e.Row.Cells[0].Text = "-";
                    e.Row.Cells[1].Text = "-";
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



        //if (grvTimetable.Rows.Count > 1)
        //{
        //    for (int i = 0; i < grvTimetable.Rows.Count - 1; i++)
        //    {
        //        if (i == 4)
        //        {
        //            grvTimetable.Rows[i].Visible = false;
                    
        //        }
        //        if (i == 4)
        //        {                    
        //            e.Row.Cells[0].Text = "5";
        //            e.Row.Cells[0].Font.Bold = true;
        //        }
        //        if (i == 5)
        //        {                   
        //            e.Row.Cells[0].Text = "6";
        //            e.Row.Cells[0].Font.Bold = true;
        //        }
        //        if (i == 6)
        //        {
        //            e.Row.Cells[0].Text = "7";
        //            e.Row.Cells[0].Font.Bold = true;
        //        }
        //    }
        //}
    }
    public void FillLibraryDetails()
    {
        try
        {
            //strQry = "Select intAssign_id,tblLibraryTrnDet.intLibrary_id,convert(varchar,dtAssignDate,103) 'Issue',convert(varchar,dtReturnDate,103) 'Return',  vchCategory_name 'Category',vchBook_name 'Book' from tblLibraryTrnDet inner join tblLibraryCardDet on tblLibraryCardDet.intLibrary_id=tblLibraryTrnDet.intLibrary_id inner join tblBookDetails on tblBookDetails.intBook_id=tblLibraryTrnDet.intBook_id inner join tblBookCategory on tblBookCategory.intCategory_id=tblBookDetails.intCategory_id where bitDeleteFlag=1 and intStudent_id='" + Convert.ToString(Session["Student_id"]) + "' and tblLibraryTrnDet.intschool_id='" + Convert.ToString(Session["School_id"]) + "' and tblLibraryCardDet.intschool_id='" + Convert.ToString(Session["School_id"]) + "' and tblBookCategory.intschool_id='" + Convert.ToString(Session["School_id"]) + "'  and dtActualRetDate is NULL";
            strQry = "exec [usp_StudentDashboard] @type='LibraryDetail',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
            //
            dsObj = sGetDataset(strQry);
            grvLibrary.DataSource = dsObj;
            grvLibrary.DataBind();
            
        }
        catch
        {

        }
    }
    protected void grvLibrary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblReturn = (Label)e.Row.FindControl("lblReturn");
            // Label lblActual = (Label)e.Row.FindControl("lblActual");

            //if (lblReturn.Text != "")
            //{
            //    if (Convert.ToDateTime(Convert.ToDateTime(lblReturn.Text).ToString("dd/MM/yyyy")) <= Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")))
            //    {
            //        //e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#fd2b02");
            //        //e.Row.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            //        e.Row.BackColor = System.Drawing.Color.Orange;
            //        e.Row.ForeColor = System.Drawing.Color.White;
            //        //e.Row.Font.Bold = true;
            //    }
            //}

        }
    }
    public void FillInventory()
    {
        try
        {
            strQry = "exec [usp_StudentDashboard] @type='InventoryDetail',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
            dsObj = sGetDataset(strQry);            
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvInventory.DataSource = dsObj;
                grvInventory.DataBind();
            }
            else
            {
                grvInventory.DataSource = dsObj;
                grvInventory.DataBind();
            }
        }
        catch
        {

        }
    }
    public void fillFee()
    {
        try
        {
            strQry = "exec [usp_pendingFeeDB] @intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["Standard_id"]) + "',@intstudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grdFeeDetails.DataSource = dsObj;
                grdFeeDetails.DataBind();
            }
            else
            {
                grdFeeDetails.DataSource = dsObj;
                grdFeeDetails.DataBind();
            }
        }
        catch
        {

        }
    }
    protected void grvInventory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblReturn = (Label)e.Row.FindControl("lblReturn");
            Label lblActual = (Label)e.Row.FindControl("lblActual");

            if (lblReturn.Text != "" || lblActual.Text == "")
            {
                if (Convert.ToDateTime(Convert.ToDateTime(lblReturn.Text).ToString("dd/MM/yyyy")) <= Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")))
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#fd2b02");
                    e.Row.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    //e.Row.BackColor = System.Drawing.Color.Orange;
                    //e.Row.ForeColor = System.Drawing.Color.White;
                    //e.Row.Font.Bold = true;
                }
            }

        }
    }
    public void FillLeave()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_StudentDashboard] @type='StudentLeaves',@SchoolId='" + Session["School_Id"] + "',@month='" + Convert.ToString(DateTime.Now.Month) + "',@Year='" + Convert.ToString(DateTime.Now.Year) + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
            dsObj = sGetDataset(strQry);

            
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    grvLeaveStatus.DataSource = dsObj;
            //    grvLeaveStatus.DataBind();
            //}
            //else
            //{
                grvLeaveStatus.DataSource = dsObj;
                grvLeaveStatus.DataBind();
        //    }
        }
        catch (Exception)
        {

            throw;
        }
    }
}