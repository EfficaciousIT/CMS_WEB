using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TeacherDB : DBUtility
{
    string strQry = string.Empty;
    int Month;
    int Year;
    DataSet dsCal;
    DataTable dt = new DataTable();
    DataSet dsObj = new DataSet();
    DateTime dtcu = DateTime.Now;
    String strDateCu = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            GetData();////prsent sathi Calendar1_DayRender last la add kelay
                      //Session["School_id"] = "1";
                      //Session["UserType_id"] = "3";
                      //Session["User_id"] = "1";
                      //Session["Student_id"] = "0";
                      //Session["Standard_id"] = "5";
                      //Session["Division_id"] = "40";
            FillHolidayDataset();
            Details();
            FillAttendanceCount();
            FillLibraryDetails();
            FillInventory();
            FillNoticeDetails();
            TimeTable();
            FillLeaveDetail();
            fillFee();
            cumulativepers();
        }
        catch
        {

        }
        }
    public void cumulativepers()
    {
        try
        {
            strDateCu = dtcu.ToString("yyyy");
            ////string aaa = DateTime.Now.Year.ToString();
            strQry = "exec [usp_NewAdminDashboard] @type='AdminCumulative',@intSchool_Id='" + Session["School_id"] + "',@Year='" + strDateCu + "',@intUser_id='" + Convert.ToString(Session["User_id"]) + "'";
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
    protected void fillFee()
    {
        strQry = "exec [usp_FeePaidTillDateDivisionWise] @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@intDivision_id='" + Convert.ToString(Session["Division_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            lblDue.Text = "Due Till Date : Rs " + Convert.ToString(dsObj.Tables[0].Rows[0]["Due Till Date"]);
            lblRecd.Text = "Recd till date : Rs " + Convert.ToString(dsObj.Tables[0].Rows[0]["Amount"]);
        }
    }
    public void FillNoticeDetails()
    {
        try
        {
            strQry = "exec [usp_TeacherDashboard] @type='NoticeBoardNew',@intUser_id='" + Convert.ToString(Session["User_id"]) + "' ";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < dsObj.Tables[0].Rows.Count; k++)
                {
                    if (k == 0)
                    {
                        lblSubject1.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice1.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate1.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue Date"]);
                        lblEndDate1.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End Date"]);
                        Notice1.Visible = true;
                    }
                    if (k == 1)
                    {
                        lblSubject2.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice2.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate2.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue Date"]);
                        lblEndDate2.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End Date"]);
                        Notice2.Visible = true;
                    }
                    if (k == 2)
                    {
                        lblSubject3.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice3.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate3.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue Date"]);
                        lblEndDate3.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End Date"]);
                        Notice3.Visible = true;
                    }
                    if (k == 3)
                    {
                        lblSubject4.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice4.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate4.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue Date"]);
                        lblEndDate4.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End Date"]);
                        Notice4.Visible = true;
                    }
                    if (k == 4)
                    {
                        lblSubject5.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice5.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate5.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue Date"]);
                        lblEndDate5.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End Date"]);
                        Notice5.Visible = true;
                    }
                    if (k == 5)
                    {
                        lblSubject6.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice6.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate6.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue Date"]);
                        lblEndDate6.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End Date"]);
                        Notice6.Visible = true;
                    }
                    if (k == 6)
                    {
                        lblSubject7.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice7.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate7.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue Date"]);
                        lblEndDate7.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End Date"]);
                        Notice7.Visible = true;
                    }
                    if (k == 7)
                    {
                        lblSubject8.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice8.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate8.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue Date"]);
                        lblEndDate8.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End Date"]);
                        Notice8.Visible = true;
                    }
                    if (k == 8)
                    {
                        lblSubject9.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice9.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate9.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue Date"]);
                        lblEndDate9.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End Date"]);
                        Notice9.Visible = true;
                    }
                    if (k == 9)
                    {
                        lblSubject10.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Subject"]);
                        lblNotice10.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Notice"]);
                        lblIssueDate10.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["Issue Date"]);
                        lblEndDate10.Text = Convert.ToString(dsObj.Tables[0].Rows[k]["End Date"]);
                        Notice10.Visible = true;
                    }
                }
            }

        }
        catch
        {

        }
    }
    protected void TimeTable()
    {
        strQry = "exec usp_TimeTable @type='TeachertimeTable',@intTeacher_id='" + Convert.ToString(Session["User_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id=4";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvTimetable.DataSource = dsObj;
            grvTimetable.DataBind();
        }
        
    }
    public void FillLeaveDetail()
    {
        try
        {
            strQry = "exec [usp_TeacherDashboard] @type='StudentLeaveDashBoard',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@intDivision_id='" + Convert.ToString(Session["Division_id"]) + "'";
            dsObj = sGetDataset(strQry);
            Session["TeacherLeave"] = dsObj;
            grvLeaveStudent.DataSource = dsObj;
            grvLeaveStudent.DataBind();

            strQry = "exec [usp_TeacherDashboard] @type='TeacherLeave',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            Session["StudentLeave"] = dsObj;
            grvLeave.DataSource = dsObj;
            grvLeave.DataBind();
        }
        catch
        {

        }
    }
    protected void grvLeaveStudent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton lnk = (LinkButton)e.Row.FindControl("lnkDetail");
                Label lblLeave = (Label)e.Row.FindControl("lblLeaveId");
                lblLeave.Text = HttpUtility.UrlEncode(Encrypt(lblLeave.Text));
                string url = "frmViewTeacherDetail.aspx?LeaveId=" + lblLeave.Text;

                lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','height=245,left=50,top=200,addressbar=0')");
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
    protected void Details()
    {
        strQry = "exec usp_StudentDB @command='LastLoginTeacher',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            lastLogin.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Date"]);
        }
    }
    public void FillLibraryDetails()
    {
        try
        {
            //strQry = "Select intAssign_id,tblLibraryTrnDet.intLibrary_id,convert(varchar,dtAssignDate,103) 'Issue',convert(varchar,dtReturnDate,103) 'Return',  vchCategory_name 'Category',vchBook_name 'Book' from tblLibraryTrnDet inner join tblLibraryCardDet on tblLibraryCardDet.intLibrary_id=tblLibraryTrnDet.intLibrary_id inner join tblBookDetails on tblBookDetails.intBook_id=tblLibraryTrnDet.intBook_id inner join tblBookCategory on tblBookCategory.intCategory_id=tblBookDetails.intCategory_id where bitDeleteFlag=1 and intStudent_id='" + Convert.ToString(Session["Student_id"]) + "' and tblLibraryTrnDet.intschool_id='" + Convert.ToString(Session["School_id"]) + "' and tblLibraryCardDet.intschool_id='" + Convert.ToString(Session["School_id"]) + "' and tblBookCategory.intschool_id='" + Convert.ToString(Session["School_id"]) + "'  and dtActualRetDate is NULL";
            strQry = "exec [usp_TeacherDashboard] @type='Library',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intUser_id='" + Convert.ToString(Session["User_id"]) + "'";
            //
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvLibrary.DataSource = dsObj;
                grvLibrary.DataBind();
            }
            else
            {
                grvLibrary.DataSource = dsObj;
                grvLibrary.DataBind();
            }
        }
        catch
        {

        }
    }
    public void FillInventory()
    {
        try
        {
            strQry = "exec [usp_TeacherDashboard] @type='InventoryDetail',@intUser_id='" + Convert.ToString(Session["User_id"]) + "'";
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
    protected void grvInventory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
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
                    }
                    else
                    {
                        e.Row.BackColor = System.Drawing.Color.White;
                        e.Row.ForeColor = System.Drawing.Color.Blue;
                        e.Row.Font.Bold = false;
                    }
                }

            }
        }
        catch
        {

        }
    }
    protected void grvLibrary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblReturn = (Label)e.Row.FindControl("lblReturn");

                if (lblReturn.Text != "")
                {
                    if (Convert.ToDateTime(Convert.ToDateTime(lblReturn.Text).ToString("dd/MM/yyyy")) <= Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")))
                    {
                        e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#fd2b02");
                        e.Row.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                        e.Row.Font.Bold = true;
                    }
                    else
                    {
                        e.Row.BackColor = System.Drawing.Color.White;
                        e.Row.ForeColor = System.Drawing.Color.Blue;
                        e.Row.Font.Bold = false;
                    }
                }

            }
        }
        catch
        {

        }
        }
    public void FillAttendanceCount()
    {
        try
        {
            strQry = "exec [usp_TeacherDashboard] @type='StudentAttendance',@intDivision_id='" + Convert.ToString(Session["Division_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                lblStudentCnt.Text = "Student : " + Convert.ToString(dsObj.Tables[0].Rows[0]["Present"]) + " / " + Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
            }
           
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
            strQry = "exec [usp_TeacherDashboard] @type='FillCalendar',  @FirstDate='" + Convert.ToDateTime(FirstDt).ToString("yyyy/MM/dd") + "',@LastDate='" + Convert.ToDateTime(LastDt).ToString("yyyy/MM/dd") + "',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@intRole_Id='" + Convert.ToString(Session["UserType_id"]) + "'";
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
                monthNumber = CalAttendance.VisibleDate.Month + 2;
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
    //protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    //{
    //    try
    //    {
            
    //        if (e.Day.Date.DayOfWeek.ToString() == "Sunday")
    //        {
    //            //e.Cell.BackColor = System.Drawing.Color.IndianRed;
    //            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F14c57");
    //            return;
    //        }
    //        Boolean bln = false;
    //        DateTime nextDate;

    //        if (dsCal != null)
    //        {
    //            foreach (DataRow dr in dsCal.Tables[0].Rows)
    //            {

    //                nextDate = (DateTime)dr["Date"];



    //                if (nextDate == e.Day.Date)
    //                {

    //                    if ((string)dr["Type"] == "Holiday")
    //                    {
    //                        //e.Cell.BackColor = System.Drawing.Color.SkyBlue;
    //                        e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F14c57");
    //                        e.Cell.ToolTip = (string)dr["Name"];
    //                    }
    //                    else if ((string)dr["Type"] == "Vacation")
    //                    {
    //                        e.Cell.BackColor = System.Drawing.Color.BurlyWood;
    //                        e.Cell.ToolTip = (string)dr["Name"];
    //                    }
    //                    else if ((string)dr["Type"] == "Traning")
    //                    {
    //                        e.Cell.BackColor = System.Drawing.Color.Pink;
    //                        e.Cell.ToolTip = (string)dr["Name"];
    //                    }
    //                    //  e.Cell.Attributes.Add((string)dr["Name"], "1");
    //                }

    //            }

    //        }
    //    }
    //    catch
    //    {

    //    }
    //}
















    private DataSet GetData()
    {
        try
        {
            string startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("MM/dd/yyyy").Replace("-", "/");
            string endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(30).ToString("MM/dd/yyyy").Replace("-", "/");
            if (Convert.ToString(Session["UserType_id"]) == "3")
            {
                strQry = "exec usp_getAttendance @type='getCalenderAtt',@intUserType_id='3',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@FrmDt='" + startDate.Trim() + "',@EndDt='" + endDate.Trim() + "'";
                dsObj = sGetDataset(strQry);
                Session["Table"] = dsObj;
                return dsObj;
            }
            if (Convert.ToString(Session["UserType_id"]) == "5")
            {
                strQry = "exec usp_getAttendance @type='getCalenderAtt',@intUserType_id='3',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@FrmDt='" + startDate.Trim() + "',@EndDt='" + endDate.Trim() + "'";
                dsObj = sGetDataset(strQry);
                Session["Table"] = dsObj;
                return dsObj;
            }
            else
            {
                strQry = "exec usp_getAttendance @type='getCalenderAtt',@intUserType_id='" + Convert.ToString(Session["UserType_id"]) + "',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@FrmDt='" + startDate.Trim() + "',@EndDt='" + endDate.Trim() + "'";
                dsObj = sGetDataset(strQry);
                Session["Table"] = dsObj;
                return dsObj;
            }

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

            if (e.Day.Date.DayOfWeek.ToString() == "Sunday")
            {
                //e.Cell.BackColor = System.Drawing.Color.IndianRed;
                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F14c57");
                return;
            }
            Boolean bln = false;
            DateTime nextDate;

            if (dsCal != null)
            {
                foreach (DataRow dr in dsCal.Tables[0].Rows)
                {

                    nextDate = (DateTime)dr["Date"];



                    if (nextDate == e.Day.Date)
                    {

                        if ((string)dr["Type"] == "Holiday")
                        {
                            //e.Cell.BackColor = System.Drawing.Color.SkyBlue;
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F14c57");
                            e.Cell.ToolTip = (string)dr["Name"];
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
       
            if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F14c57");
                e.Cell.ToolTip = "Holiday";
                // return;
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
                    if (e.Day.Date.ToString("dd") == "15")
                    {
                        Month = e.Day.Date.Month;
                        Year = e.Day.Date.Year;
                       // ddlMonth.SelectedValue = Convert.ToString(Month);
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
          //  FillGrid();

        }
        catch (Exception ex)
        {

        }

    }
}