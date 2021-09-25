using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;

public partial class StaffDB : DBUtility
{
    string strQry = string.Empty;
    int Month;
    int Year;
    DataSet dsCal;
    DataTable dt = new DataTable();
    DataSet dsObj = new DataSet();
    string TeacherCnt, StaffCnt, TeacherPresent, StaffPresent;

    DateTime dtcu = DateTime.Now;
    String strDateCu = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                GetData();////////ma monthly           
                FillHolidayDataset();
                FillNoticeDetails();
                Details();
                FillFeeCollectionDetails();
                FillAttendanceCount();
                fillDrp();
                txtNotice.Focus();
                fillBusDetails();
                cumulativepers();
            }
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
            strQry = "exec [usp_StaffDashboard] @type='StaffCumulative',@intSchool_Id='" + Session["School_id"] + "',@Year='" + strDateCu + "',@intUser_id='" + Convert.ToString(Session["User_id"]) + "'";
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
    protected void fillDrp()
    {
        string strQry = "Execute dbo.usp_idcard @command='selectTypeofuser',@intSchool_id='" + Session["School_id"] + "' ";
        bool stcardp = sBindDropDownList(drpUserType, strQry, "vchUser_name", "intUserType_id");
        drpUserType.Items.Insert(1, "All");

        strQry = "Execute dbo.usp_idcard @command='SelectDepartment',@intSchool_id='" + Session["School_id"] + "' ";
        bool stcardp2 = sBindDropDownList(drpDepartment, strQry, "vchDepartment_name", "intDepartment");
        drpDepartment.Items.Insert(1, "All");
    }
    public void FillAttendanceCount()
    {
        try
        {
            strQry = "exec usp_StaffDashboard  @type='StudentCount',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                lblStudentCnt.Text = "Student : " + Convert.ToString(dsObj.Tables[0].Rows[0]["Present"]) + " / " + Convert.ToString(dsObj.Tables[0].Rows[0]["Count"]);
            }


            strQry = "exec usp_StaffDashboard  @type='StaffCount',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                StaffCnt = Convert.ToString(dsObj.Tables[0].Rows[0]["Count"]);
                StaffPresent = Convert.ToString(dsObj.Tables[0].Rows[0]["Present"]);
            }

            lblStaffCnt.Text = "Staff : " + Convert.ToString(Convert.ToInt32(StaffPresent)) + " / " + Convert.ToString(Convert.ToInt32(StaffCnt));

            strQry = "exec usp_StaffDashboard  @type='TeacherCount',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                TeacherCnt = Convert.ToString(dsObj.Tables[0].Rows[0]["Count"]);
                TeacherPresent = Convert.ToString(dsObj.Tables[0].Rows[0]["Present"]);

                lblTeacherCnt.Text = "Teacher : " + Convert.ToString(Convert.ToInt32(TeacherPresent)) + " / " + Convert.ToString(Convert.ToInt32(TeacherCnt));
            }

        }
        catch
        {

        }
    }
    protected void Details()
    {
        strQry = "exec usp_StaffDashboard @type='LastLoginStaff',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            lastLogin.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Date"]);
        }

    }
    protected void FillFeeCollectionDetails()
    {
        try
        {

            // strQry = "usp_FeePaidTillDate @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            strQry = "exec usp_getFeeTillDate @intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";////////////////////current///////////////
            //strQry = "exec usp_getFeeTillDateChapekar @intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {

                //lblDue.Text = "Total Fee : Rs " + Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Net Fee"]).ToString("#,##0");
                //lblRecd.Text = "Received Fee : Rs " + Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Paid Fee"]).ToString("#,##0");
                //lblPending.Text = "Pending Fee : Rs " + Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Pending Fee"]).ToString("#,##0");


                if (Convert.ToString(dsObj.Tables[0].Rows[0]["Total Fee"]) != "")
                {
                    lblDue.Text = "Total Fee : Rs " + Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Total Fee"]).ToString("#,##0");
                }
                else
                {
                    lblDue.Text = "Total Fee : Rs 0.00";
                }

                if (Convert.ToString(dsObj.Tables[0].Rows[0]["Total Paid Fee"]) != "")
                {
                    lblRecd.Text = "Received Fee : Rs " + Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Total Paid Fee"]).ToString("#,##0");
                }
                else
                {
                    lblRecd.Text = "Received Fee : Rs 0.00";
                }
                if (Convert.ToString(dsObj.Tables[0].Rows[0]["Total Pending Fee"]) != "")
                {
                    lblPending.Text = "Pending Fee : Rs " + Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Total Pending Fee"]).ToString("#,##0");
                }
                else
                {
                    lblPending.Text = "Pending Fee : Rs 0.00";
                }

                ////lblDue.Text = "Due Till Date : Rs " + Convert.ToString(dsObj.Tables[0].Rows[0]["Due"]);
                //lblDue.Text = "Due Till Date : Rs " + Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Due"]).ToString("#,##0");          
                ////lblRecd.Text = "Recd till date : Rs " + Convert.ToString(dsObj.Tables[0].Rows[0]["Recd"]);
                //lblRecd.Text = "Recd till date : Rs " + Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Recd"]).ToString("#,##0");
                //lblPending.Text = "Recd till date : Rs " + Convert.ToDecimal(dsObj.Tables[0].Rows[0]["Recd"]).ToString("#,##0");
            }
            else
            {
                lblDue.Text = "Due Till Date : Rs 0.00";
                lblRecd.Text = "Recd till date : Rs 0.00";
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
    public void FillNoticeDetails()
    {
        try
        {
            strQry = "usp_StaffDashboard @type='NoticeBoard',@SchoolId='" + Session["School_id"] + "'";
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
    public DataSet GetCurrentMonthData(DateTime FirstDt, DateTime LastDt)
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_StaffDashboard] @type='FillCalendar',  @FirstDate='" + Convert.ToDateTime(FirstDt).ToString("yyyy/MM/dd") + "',@LastDate='" + Convert.ToDateTime(LastDt).ToString("yyyy/MM/dd") + "',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@intRole_Id='" + Convert.ToString(Session["UserType_id"]) + "'";
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

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        string Day_Date = e.Day.Date.ToShortDateString();
        try
        {
            if (e.Day.Date.DayOfWeek.ToString() == "Sunday")
            {
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

            if (((DataSet)Session["TableAdm"] != null) && ((DataSet)Session["TableAdm"]).Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ((DataSet)Session["TableAdm"]).Tables[0].Rows)
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
        catch
        {

        }
    }

    protected void drpUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (drpUserType.Text == "All")
            {
                trStudent.Visible = false;
                trStaff.Visible = false;
            }
            else if (drpUserType.Text == "1")
            {
                trStudent.Visible = true;
                trStaff.Visible = false;

                string strQry = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
                bool st = sBindDropDownList(drpStandard, strQry, "Standard_name", "intStandard_id");
                drpStandard.Items.Insert(1, "All");
            }
            else if (drpUserType.Text == "3")
            {
                trStudent.Visible = false;
                trStaff.Visible = true;
            }
            else if (drpUserType.Text == "4")
            {
                trStudent.Visible = false;
                trStaff.Visible = false;
            }
        }
        catch
        {
        }

    }
    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            if (drpStandard.Text == "All")
            {
                drpStandard.Enabled = true;
                drpDivision.Enabled = false;
                drpStudent.Enabled = false;
            }

            else
            {
                drpDivision.Enabled = true;
                drpStudent.Enabled = true;

                int stat = Convert.ToInt32(drpStandard.SelectedItem.Value);
                string strQry = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "' ";
                bool st2 = sBindDropDownList(drpDivision, strQry, "vchDivisionName", "intDivision_id");
                drpDivision.Items.Insert(1, "All");
            }
        }
        catch
        {
        }

    }
    protected void drpDivision_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            if (drpDivision.Text == "All")
            {
                drpStudent.Enabled = false;
            }
            else
            {
                drpStudent.Enabled = true;
                int stat1 = Convert.ToInt32(drpStandard.SelectedItem.Value);

                int Div1 = Convert.ToInt32(drpDivision.SelectedItem.Value);

                string query3 = "Execute dbo.usp_NocticeBoard @command='DivisionStudent',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + stat1 + "',@intDivision_id='" + Div1 + "' ";
                bool st3 = sBindDropDownList(drpStudent, query3, "Name", "intStudent_id");
                drpStudent.Items.Insert(1, "All");
            }
        }
        catch
        {

        }
    }
    protected void drpDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (drpDepartment.Text == "All")
            {
                drpStaff.Enabled = false;
            }
            else
            {
                int typeid = Convert.ToInt32(drpUserType.SelectedItem.Value);
                int depid = Convert.ToInt32(drpDepartment.SelectedItem.Value);
                string query2 = "Execute [usp_StaffDashboard] @type='SelectStaffId',@SchoolId='" + Session["School_id"] + "',@intDepartment_id='" + depid + "'";
                bool st3 = sBindDropDownList(drpStaff, query2, "Name", "intTeacher_id");
                drpStaff.Items.Insert(1, "All");
                drpStaff.Enabled = true;
            }
        }
        catch
        {

        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        int j = 0;

        if (drpUserType.Text == "1" && drpStandard.Text == "All")
        {
            strQry = "usp_StaffDashboard @type='AllMessageToStudent',@SchoolId='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
                {
                    string strMobile1 = Convert.ToString(dsObj.Tables[0].Rows[i]["intBusAlert1"]);
                    string strMobile2 = Convert.ToString(dsObj.Tables[0].Rows[i]["intBusAlert2"]);

                    strMobile1 = "9820764572";
                    //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");
                }
            }
        }

        else if (drpUserType.Text == "1")
        {
            if (drpStandard.Text == "All")
            {
                strQry = "usp_StaffDashboard @type='AllMessageToStandard',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@STD='" + drpStandard.SelectedValue.Trim() + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
                    {
                        string strMobile1 = Convert.ToString(dsObj.Tables[0].Rows[i]["intBusAlert1"]);
                        string strMobile2 = Convert.ToString(dsObj.Tables[0].Rows[i]["intBusAlert2"]);

                        strMobile1 = "9820764572";
                        //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");
                    }
                }
            }
            else
            {
                if (drpDivision.Text == "All")
                {

                    strQry = "usp_StaffDashboard @type='AllMessageToDivision',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@STD='" + drpStandard.SelectedValue.Trim() + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
                        {
                            string strMobile1 = Convert.ToString(dsObj.Tables[0].Rows[i]["intBusAlert1"]);
                            string strMobile2 = Convert.ToString(dsObj.Tables[0].Rows[i]["intBusAlert2"]);

                            strMobile1 = "9820764572";
                            //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");
                        }
                    }


                }
                else
                {
                    if (drpStudent.Text == "All")
                    {
                        int stat1 = Convert.ToInt32(drpStandard.SelectedItem.Value);

                        int Div1 = Convert.ToInt32(drpDivision.SelectedItem.Value);

                        strQry = "usp_StaffDashboard @type='AllMessageToDivision',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@STD='" + drpStandard.SelectedValue.Trim() + "',@DIV='" + Div1 + "'";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
                            {
                                string strMobile1 = Convert.ToString(dsObj.Tables[i].Rows[0]["intBusAlert1"]);
                                string strMobile2 = Convert.ToString(dsObj.Tables[i].Rows[0]["intBusAlert2"]);

                                strMobile1 = "9820764572";
                                //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");
                            }
                        }


                    }
                    else
                    {
                        int stat1 = Convert.ToInt32(drpStandard.SelectedItem.Value);

                        int Div1 = Convert.ToInt32(drpDivision.SelectedItem.Value);

                        strQry = "usp_StaffDashboard @type='IndividualMessage',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@STD='" + drpStandard.SelectedValue.Trim() + "',@DIV='" + Div1 + "',@intStudentId='" + drpStudent.SelectedValue.Trim() + "'";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
                            {
                                string strMobile1 = Convert.ToString(dsObj.Tables[i].Rows[0]["intBusAlert1"]);
                                string strMobile2 = Convert.ToString(dsObj.Tables[i].Rows[0]["intBusAlert2"]);

                                strMobile1 = "9820764572";
                                POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");
                            }
                        }
                    }
                }
            }
        }
        else if (drpUserType.Text == "3")
        {
            if (drpDepartment.Text == "All")
            {
                strQry = "usp_StaffDashboard @type='AllStaff',@SchoolId='" + Session["School_id"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
                    {
                        string strMobile1 = Convert.ToString(dsObj.Tables[0].Rows[i]["intmobileNo"]);

                        strMobile1 = "9820764572";
                        //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");
                    }
                }

            }
            else
            {
                strQry = "usp_NocticeBoard @command='AllTeachersDepartment',@intschool_id='" + Session["School_id"] + "',@intDepartment_id='" + drpDepartment.SelectedValue.Trim() + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
                    {

                        string strMobile1 = Convert.ToString(dsObj.Tables[0].Rows[i]["intmobileNo"]);

                        strMobile1 = "9820764572";
                        //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");
                    }
                }

            }

        }
        else if (drpUserType.Text == "4")
        {
            try
            {
                string[] strMobile = new string[7];
                strMobile[0] = "7709430162";
                strMobile[1] = "9804135259";
                strMobile[2] = "8276995992";
                strMobile[3] = "9830171118";
                strMobile[4] = "7506480844";
                strMobile[5] = "9820943806";
                strMobile[6] = "8080847070";
                //strMobile[7] = "";//Run time error

                foreach (string mob in strMobile)
                {
                    POST("http://alerts.justnsms.com/api/v3/?method=sms&api_key=Ad68553890184f28bf0a8c8951f3a665f&to=" + mob + "&sender=EFFICA&message=" + txtNotice.Text.Trim() + "&format=json&custom=1,2&flash=0", "");
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }



            //if (drpDepartment.Text == "All")
            //{
            //    strQry = "usp_NocticeBoard @command='AllStaffNon',@intschool_id='" + Session["School_id"] + "'";
            //    dsObj = sGetDataset(strQry);
            //    if (dsObj.Tables[0].Rows.Count > 0)
            //    {
            //        for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
            //        {
            //            string strMobile1 = Convert.ToString(dsObj.Tables[0].Rows[i]["intmobileNo"]);

            //            strMobile1 = "9820764572";
            //            //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");

            //        }
            //    }

            //}
            //else
            //{
            //    if (drpStaff.Text == "All")
            //    {
            //        strQry = "usp_StaffDashboard @type='AllStaffDepartment',@SchoolId='" + Session["School_id"] + "',@intDepartment_id='" + drpDepartment.SelectedValue.Trim() + "'";
            //        dsObj = sGetDataset(strQry);
            //        if (dsObj.Tables[0].Rows.Count > 0)
            //        {
            //            for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
            //            {
            //                string strMobile1 = Convert.ToString(dsObj.Tables[i].Rows[0]["intmobileNo"]);

            //                strMobile1 = "9820764572";
            //                //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");
            //            }
            //        }
            //    }
            //    else
            //    {
            //        strQry = "usp_StaffDashboard @type='IndividualStaff',@SchoolId='" + Session["School_id"] + "',@intDepartment_id='" + drpDepartment.SelectedValue.Trim() + "',@intTeacher_id='" + drpStaff.SelectedValue.Trim() + "'";
            //        dsObj = sGetDataset(strQry);
            //        if (dsObj.Tables[0].Rows.Count > 0)
            //        {
            //            for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
            //            {
            //                string strMobile1 = Convert.ToString(dsObj.Tables[0].Rows[i]["intmobileNo"]);

            //                strMobile1 = "9820764572";
            //                //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");
            //            }
            //        }
            //    }

            //}

        }

        //if (drpStandard.Text == "All" && drpDivision.Text == "---Select---" && drpStudent.Text == "---Select---")
        //{
        //    string strStudent_id = drpStudent.SelectedValue.Trim();

        //    strQry = "usp_StaffDashboard @type='AllMessageToStudent',@SchoolId='" + Convert.ToString(Session["School_id"]) + "'";
        //    dsObj = sGetDataset(strQry);
        //    if (dsObj.Tables[0].Rows.Count > 0)
        //    {
        //        string strMobile1 = Convert.ToString(dsObj.Tables[0].Rows[0]["intBusAlert1"]);
        //        string strMobile2 = Convert.ToString(dsObj.Tables[0].Rows[0]["intBusAlert2"]);

        //        strMobile1 = "9820764572";
        //        //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");

        //    }
        //}
        //else if (drpStandard.Text != "All" && drpDivision.Text != "---Select---" && drpStudent.Text == "---Select---")
        //{
        //    if (drpDivision.Text == "All")
        //    {
        //        string strStudent_id = drpStudent.SelectedValue.Trim();
        //        strQry = "usp_StaffDashboard @type='AllMessageToDivision',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@STD='5'";
        //        dsObj = sGetDataset(strQry);
        //        if (dsObj.Tables[0].Rows.Count > 0)
        //        {
        //            string strMobile1 = Convert.ToString(dsObj.Tables[0].Rows[0]["intBusAlert1"]);
        //            string strMobile2 = Convert.ToString(dsObj.Tables[0].Rows[0]["intBusAlert2"]);

        //            strMobile1 = "9820764572";
        //            //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");

        //        }
        //    }
        //    else
        //    {
        //        if (drpDivision.Text == "All")
        //        {
        //            string strStudent_id = drpStudent.SelectedValue.Trim();
        //            strQry = "usp_StaffDashboard @type='IndividualMessage',@SchoolId='" + Convert.ToString(Session["School_id"]) + "'";
        //            dsObj = sGetDataset(strQry);
        //            if (dsObj.Tables[0].Rows.Count > 0)
        //            {
        //                string strMobile1 = Convert.ToString(dsObj.Tables[0].Rows[0]["intBusAlert1"]);
        //                string strMobile2 = Convert.ToString(dsObj.Tables[0].Rows[0]["intBusAlert2"]);

        //                strMobile1 = "9820764572";
        //                //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");

        //            }
        //        }
        //        else
        //        {
        //            if (drpDivision.Text != "All" && drpStudent.Text == "All")
        //            {
        //                string strStudent_id = drpStudent.SelectedValue.Trim();
        //                strQry = "usp_StaffDashboard @type='IndividualMessage',@SchoolId='" + Convert.ToString(Session["School_id"]) + "'";
        //                dsObj = sGetDataset(strQry);
        //                if (dsObj.Tables[0].Rows.Count > 0)
        //                {
        //                    string strMobile1 = Convert.ToString(dsObj.Tables[0].Rows[0]["intBusAlert1"]);
        //                    string strMobile2 = Convert.ToString(dsObj.Tables[0].Rows[0]["intBusAlert2"]);

        //                    strMobile1 = "9820764572";
        //                    //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");

        //                }
        //            }
        //            else
        //            {
        //                string strStudent_id = drpStudent.SelectedValue.Trim();
        //                strQry = "usp_StaffDashboard @type='IndividualMessage',@intStudentId='" + strStudent_id.Trim() + "'";

        //                dsObj = sGetDataset(strQry);
        //                if (dsObj.Tables[0].Rows.Count > 0)
        //                {
        //                    string strMobile1 = Convert.ToString(dsObj.Tables[0].Rows[0]["intBusAlert1"]);
        //                    string strMobile2 = Convert.ToString(dsObj.Tables[0].Rows[0]["intBusAlert2"]);

        //                    strMobile1 = "9820764572";
        //                    //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");

        //                }
        //            }

        //        }

        //    }

        //}
        //else if (drpStandard.Text != "All" && drpDivision.Text != "All" && drpStudent.Text != "---Select---")
        //{
        //    string strStudent_id = drpStudent.SelectedValue.Trim();
        //    strQry = "usp_StaffDashboard @type='IndividualMessage',@intStudentId='" + strStudent_id.Trim() + "'";
        //    dsObj = sGetDataset(strQry);
        //    if (dsObj.Tables[0].Rows.Count > 0)
        //    {
        //        string strMobile1 = Convert.ToString(dsObj.Tables[0].Rows[0]["intBusAlert1"]);
        //        string strMobile2 = Convert.ToString(dsObj.Tables[0].Rows[0]["intBusAlert2"]);

        //        strMobile1 = "9820764572";
        //        //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");

        //    }
        //}
        //else
        //{

        //}
    }
    private void POST(string url, string data)
    {
        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
        req.Method = "POST";
        req.Headers.Add(HttpRequestHeader.AcceptLanguage, "de-DE,de;q=0.8,en-US;q=0.7,en;q=0.3");

        req.Timeout = req.ReadWriteTimeout = 15000;

        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] dataBytes = encoding.GetBytes(data);
        req.ContentLength = dataBytes.Length;
        Stream stream = req.GetRequestStream();
        stream.Write(dataBytes, 0, dataBytes.Length);
        stream.Close();

        req.GetResponse();
    }
    protected void fillBusDetails()
    {
        strQry = "usp_StaffDashboard @type='BusDetails',@SchoolId='" + Convert.ToString(Session["School_id"]) + "'  ";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdBusCnt.DataSource = dsObj;
            grdBusCnt.DataBind();
        }
    }
    protected void grdBusCnt_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strDevice = grdBusCnt.DataKeys[e.Row.RowIndex].Values[0].ToString();
                string strStartTime = grdBusCnt.DataKeys[e.Row.RowIndex].Values[1].ToString();
                string strEndTime = grdBusCnt.DataKeys[e.Row.RowIndex].Values[2].ToString();

                LinkButton lnk = (LinkButton)e.Row.FindControl("lnkPresent");

                string url = "frmViewStudentCount.aspx?DeviceID=" + strDevice + "&time=" + strStartTime;

                lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=100,height=245,left=50,top=10,addressbar=0')");

                LinkButton lnkAbsent = (LinkButton)e.Row.FindControl("lnkAbsent");

                string urlAbsent = "frmViewAbsent.aspx?DeviceID=" + strDevice + "&time=" + strEndTime;

                lnkAbsent.Attributes.Add("onClick", "JavaScript: window.open('" + urlAbsent + "','','_blank','width=800,height=245,left=50,top=50,addressbar=0')");


                //lnk = (LinkButton)e.Row.FindControl("lnkAbsent");
                //staff = HttpUtility.UrlEncode(Encrypt("4"));
                //status = HttpUtility.UrlEncode(Encrypt("Absent"));
                //url = "ViewAdminDetail.aspx?Staff=" + staff + "&status=" + status;
                //lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");


                //lnk = (LinkButton)e.Row.FindControl("lnkLeave");
                //staff = HttpUtility.UrlEncode(Encrypt("4"));
                //status = HttpUtility.UrlEncode(Encrypt("Leave"));
                //url = "ViewAdminDetail.aspx?Staff=" + staff + "&status=" + status;
                //lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");



            }
        }
        catch (Exception ex)
        {

        }
    }















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
            if (Convert.ToString(Session["UserType_id"]) == "4")
            {
                strQry = "exec usp_getAttendance @type='getCalenderAtt',@intUserType_id='4',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@FrmDt='" + startDate.Trim() + "',@EndDt='" + endDate.Trim() + "'";
                dsObj = sGetDataset(strQry);
                Session["TableAdm"] = dsObj;
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
}