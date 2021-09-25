using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
public partial class frmMonthlyAttendance : DBUtility
{
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    DataSet dsObj = new DataSet();
    string[] xAxis;
    int[] yAxis;
    DataTable dt = new DataTable();
    string strQry = "";
    //string strCOn = System.Configuration.ConfigurationManager.ConnectionStrings["esmsCentralModel"].ConnectionString;
    SqlConnection sqlCon = new SqlConnection();
    int Present = 0, Absent = 0, Late = 0, Leave = 0, Tot = 0, TotDay = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Session["School_id"] = "1";
            //Session["UserType_id"] = "1";
            //Session["User_id"] = "0";
            //Session["Student_id"] = "372";
            //Session["Standard_id"] = "5";
            //Session["Division_id"] = "40";
            fillSummery();
            FillPersonlDetail();
            GetData();
            ddlMonth.SelectedValue = Convert.ToString(DateTime.Now.Month);
            ddlMonth_SelectedIndexChanged(null, null);
            //FillYear();
            //ddlYear1.SelectedValue = Convert.ToString(DateTime.Now.Year);
            //lYear2.SelectedValue = Convert.ToString(DateTime.Now.Year);
            //FillSummeryAttendatce();
            if (Convert.ToString(Session["UserType_id"]) == "5" || Convert.ToString(Session["UserType_id"]) == "4" || Convert.ToString(Session["UserType_id"]) == "3" || Convert.ToString(Session["UserType_id"]) == "6")
            {
                //TabContainer1.Tabs[2].Visible = false;
                //TabContainer1.Tabs[3].Visible = false;
                topFive.Visible = false;
            }
            else
            {
                //TabContainer1.Tabs[2].Visible = true;
                //TabContainer1.Tabs[3].Visible = true;
                topFive.Visible = true;
            }
        }
        
    }

    public void FillPersonlDetail()
    {
        try
        {
            if (Convert.ToString(Session["UserType_id"]) == "1")
            {
                strQry = "exec [usp_StudentDashboard] @type='S_DetailNew',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);
                lblFullname.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Fullname"]);
                ImgProfile.ImageUrl = "~\\images\\Profile\\Students\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);

                strQry = "usp_welcomename @command='" + Convert.ToString(Session["UserType_id"]) + "',@UserID='" + Convert.ToString(Session["Student_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
                {
                    lblSTDNm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["STD"]);
                    lblDIVNm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["DIV"]);
                }
                else
                {
                    lblSTDNm.Text = Convert.ToString("");
                    lblDIVNm.Text = Convert.ToString("");
                }

                strQry = "usp_attendance @command='PresentAbsent',@Month='" + Convert.ToString(DateTime.Now.Month) + "',@Year='" + Convert.ToString(DateTime.Now.Year) + "',@intStudent_Id='" + Convert.ToString(Session["Student_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
                {
                    lblPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Present"]);
                    lblAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Absent"]);
                }
                else
                {
                    lblSTDNm.Text = Convert.ToString("0");
                    lblDIVNm.Text = Convert.ToString("0");                    
                }

                strQry = "exec [usp_AttendanceSummery] @type='Top5Student',@Div='" + Convert.ToString(Session["Division_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@Year='" + Convert.ToString(DateTime.Now.Year) + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
                {
                    lblTop1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Name"]);
                    lblTop11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Day"]);

                    lblTop2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Name"]);
                    lblTop12.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Day"]);

                    lblTop3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Name"]);
                    lblTop13.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Day"]);

                    lblTop4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Name"]);
                    lblTop14.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Day"]);

                    lblTop5.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Name"]);
                    lblTop15.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Day"]);
                }                
            }
            if (Convert.ToString(Session["UserType_id"]) == "2")
            {
                strQry = "exec [usp_StudentDashboard] @type='S_DetailNew',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
                dsObj = sGetDataset(strQry);
                lblFullname.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Fullname"]);
                ImgProfile.ImageUrl = "~\\images\\Profile\\Students\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["Image"]);

                strQry = "usp_welcomename @command='" + Convert.ToString(Session["UserType_id"]) + "',@UserID='" + Convert.ToString(Session["Student_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
                {
                    lblSTDNm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["STD"]);
                    lblDIVNm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["DIV"]);
                }
                else
                {
                    lblSTDNm.Text = Convert.ToString("");
                    lblDIVNm.Text = Convert.ToString("");
                }

                strQry = "usp_attendance @command='PresentAbsent',@Month='" + Convert.ToString(DateTime.Now.Month) + "',@Year='" + Convert.ToString(DateTime.Now.Year) + "',@intStudent_Id='" + Convert.ToString(Session["Student_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
                {
                    lblPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Present"]);
                    lblAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Absent"]);
                }
                else
                {
                    lblSTDNm.Text = Convert.ToString("0");
                    lblDIVNm.Text = Convert.ToString("0");
                }

                strQry = "exec [usp_AttendanceSummery] @type='Top5Student',@Div='" + Convert.ToString(Session["Division_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@Year='" + Convert.ToString(DateTime.Now.Year) + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
                {
                    lblTop1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Name"]);
                    lblTop11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Day"]);

                    lblTop2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Name"]);
                    lblTop12.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Day"]);

                    lblTop3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Name"]);
                    lblTop13.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Day"]);

                    lblTop4.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Name"]);
                    lblTop14.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Day"]);

                    lblTop5.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Name"]);
                    lblTop15.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Day"]);
                }
            }
            else if (Convert.ToString(Session["UserType_id"]) == "3")
            {
                Panel1.Visible = false;
                strQry = "exec [usp_TeacherDashboard] @type='TitleBarTeacher',@intUser_id='" + Convert.ToString(Session["User_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    ImgProfile.Attributes.Add("src", "images\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    lblFullname.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                }

                strQry = "usp_attendance @command='PresentAbsentTeacher',@Month='" + Convert.ToString(DateTime.Now.Month) + "',@Year='" + Convert.ToString(DateTime.Now.Year) + "',@intStudent_Id='" + Convert.ToString(Session["User_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
                {
                    lblPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Present"]);
                    lblAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Absent"]);
                }
                else
                {
                    lblSTDNm.Text = Convert.ToString("0");
                    lblDIVNm.Text = Convert.ToString("0");
                }
            }
            else if (Convert.ToString(Session["UserType_id"]) == "4")
            {
                Panel1.Visible = false;
                strQry = "exec [usp_StaffDashboard] @type='TitleBarStaff',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@intuserType_id='" + Convert.ToString(Session["UserType_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    ImgProfile.Attributes.Add("src", "images\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    lblFullname.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                }

                strQry = "usp_attendance @command='PresentAbsentStaff',@Month='" + Convert.ToString(DateTime.Now.Month) + "',@Year='" + Convert.ToString(DateTime.Now.Year) + "',@intStudent_Id='" + Convert.ToString(Session["User_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
                {
                    lblPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Present"]);
                    lblAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Absent"]);
                }
                else
                {
                    lblSTDNm.Text = Convert.ToString("0");
                    lblDIVNm.Text = Convert.ToString("0");
                }
            }
            else if (Convert.ToString(Session["UserType_id"]) == "5")
            {             
                Panel1.Visible = false;
                strQry = "exec [usp_TeacherDashboard] @type='TitleBarAdmin',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@intuserType_id='" + Convert.ToString(Session["UserType_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    ImgProfile.Attributes.Add("src", "images\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                    lblFullname.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
                }

                strQry = "usp_attendance @command='PresentAbsentAdmin',@Month='" + Convert.ToString(DateTime.Now.Month) + "',@Year='" + Convert.ToString(DateTime.Now.Year) + "',@intStudent_Id='" + Convert.ToString(Session["User_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
                {
                    lblPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Present"]);
                    lblAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Absent"]);
                }
                else
                {
                    lblSTDNm.Text = Convert.ToString("0");
                    lblDIVNm.Text = Convert.ToString("0");
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
    
    //public void FillYear()
    //{
    //    try
    //    {
    //        int count = ddlYear1.Items.Count;
    //        for (int i = count - 1; i >= 0; i--)
    //        {

    //            ddlYear1.Items.Remove(ddlYear1.Items[i].Value);
    //            //ddlYear2.Items.Remove(ddlYear2.Items[i].Value);
    //        }
    //        for (int i = 2005; i <= DateTime.Now.Year; i++)
    //        {

    //            ddlYear1.Items.Add(new System.Web.UI.WebControls.ListItem(i.ToString(), i.ToString()));
    //            //ddlYear2.Items.Add(new System.Web.UI.WebControls.ListItem(i.ToString(), i.ToString()));
    //        }
    //    }
    //    catch
    //    {
    //        MessageBox("Problem Found");
    //    }
    //}

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

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        string Day_Date = e.Day.Date.ToShortDateString();

        if (e.Day.Date.Day.ToString() == "15")
        {
            ddlMonth.SelectedValue = Convert.ToString(e.Day.Date.Month);
            ddlMonth_SelectedIndexChanged(null, null);
        }
        try
        {
            if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F14c57");
                e.Cell.ToolTip = "Holiday";
                // return;
            }
            if (((DataSet)Session["Table"] != null) && ((DataSet)Session["Table"]).Tables[0].Rows.Count > 0 )
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
                        ddlMonth.SelectedValue = Convert.ToString(Month);
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
            FillGrid();

        }
        catch (Exception ex)
        {

        }

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        int Month = CalAttendance.VisibleDate.Month;
        FillGrid();
    }

    public object createDataTable()
    {
        try
        {
            if (Convert.ToString(Session["UserType_id"]) == "1" || Convert.ToString(Session["UserType_id"]) == "1")
            {
                strQry = "exec usp_getAttendance @type='getAtt',@intUserType_id='1',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@month='" + Convert.ToString(Month) + "',@year='" + Convert.ToString(Year) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                Session["Attend"] = dsObj;
                return dsObj;
            }
            else if (Convert.ToString(Session["UserType_id"]) == "2" || Convert.ToString(Session["UserType_id"]) == "2")
            {
                strQry = "exec usp_getAttendance @type='getAtt',@intUserType_id='2',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@month='" + Convert.ToString(Month) + "',@year='" + Convert.ToString(Year) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                Session["Attend"] = dsObj;
                return dsObj;
            }
            else if (Convert.ToString(Session["UserType_id"]) == "3" || Convert.ToString(Session["UserType_id"]) == "3")
            {
                strQry = "exec usp_getAttendance @type='getAtt',@intUserType_id='3',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@month='" + Convert.ToString(Month) + "',@year='" + Convert.ToString(Year) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                Session["Attend"] = dsObj;
                return dsObj;
            }
            else if (Convert.ToString(Session["UserType_id"]) == "4" || Convert.ToString(Session["UserType_id"]) == "4")
            {
                strQry = "exec usp_getAttendance @type='getAtt',@intUserType_id='4',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@month='" + Convert.ToString(Month) + "',@year='" + Convert.ToString(Year) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                Session["Attend"] = dsObj;
                return dsObj;
            }
            else if (Convert.ToString(Session["UserType_id"]) == "5" || Convert.ToString(Session["UserType_id"]) == "5")
            {
                strQry = "exec usp_getAttendance @type='getAtt',@intUserType_id='5',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@month='" + Convert.ToString(Month) + "',@year='" + Convert.ToString(Year) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                Session["Attend"] = dsObj;
                return dsObj;
            }
            else
            {
                strQry = "exec usp_getAttendance @type='getAtt',@intUserType_id='3',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@month='" + Convert.ToString(Month) + "',@year='" + Convert.ToString(Year) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                Session["Attend"] = dsObj;
                return dsObj;
            }
           
        }
        catch
        {
            return 0;
        }

    }
    protected void grvAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvAttendance.PageIndex = e.NewPageIndex;
            grvAttendance.DataBind();
            FillGrid();
        }
        catch (Exception)
        {

        }

    }
    protected void lnkPrevious_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlMonth.SelectedValue != "1")
            {
                ddlMonth.SelectedValue = Convert.ToString((Convert.ToInt32(ddlMonth.SelectedValue) - 1));
                ddlMonth_SelectedIndexChanged(null, null);
            }
            else
            {
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
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Month = Convert.ToInt32(ddlMonth.SelectedValue);
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
            if (ddlMonth.SelectedValue != "12")
            {
                ddlMonth.SelectedValue = Convert.ToString((Convert.ToInt32(ddlMonth.SelectedValue) + 1));
                ddlMonth_SelectedIndexChanged(null, null);
            }
            else
            {
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
                // CalAttendance.VisibleDate = DateTime.ParseExact("" + ddlMonth.Text.Trim() + "/27/" + Year + "", "MM/dd/yyyy", CultureInfo.InvariantCulture);
                GetData();
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
            grvAttendance.DataSource = createDataTable();
            grvAttendance.DataBind();
        }
        catch (Exception)
        {


        }
    }
    //protected void ddlYear1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    FillSummeryAttendatce();
    //}

    //public void FillSummeryAttendatce()
    //{
    //    try
    //    {
    //        strQry = "";
    //        if (Convert.ToString(Session["UserType_Id"]) == "1" || Convert.ToString(Session["UserType_Id"]) == "2")
    //        {
    //            strQry = "exec usp_AttendanceSummery @type='StudentAttendance',@intStudent_Id='" + Session["Student_Id"] + "',@intSchool_Id='" + Session["School_Id"] + "',@Year='" + ddlYear1.SelectedValue + "'";
    //        }
    //        else
    //        {
    //            strQry = "exec usp_AttendanceSummery @type='StaffAttendance',@intUser_Id='" + Session["User_id"] + "',@intSchool_Id='" + Session["School_Id"] + "',@Year='" + ddlYear1.SelectedValue + "',@intUserType_Id='" + Convert.ToString(Session["UserType_Id"]) + "'";
    //        }
    //        dsObj = sGetDataset(strQry);
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            grvSummery.DataSource = dsObj;
    //            grvSummery.DataBind();
    //            FillFooter();
    //            grvSummery.DataBind();

    //        }
    //        else
    //        {
    //            grvSummery.DataSource = dsObj;//null
    //            grvSummery.DataBind();
    //        }

    //    }
    //    catch
    //    {

    //    }
    //}

    
    //public void FillFooter()
    //{
    //    try
    //    {
    //        int i = 0;
    //        for (int j = 0; j < grvSummery.Rows.Count; j++)
    //        {
    //            for (int k = 1; k < grvSummery.Columns.Count; k++)
    //            {
    //                i = Convert.ToInt32(grvSummery.Rows[j].Cells[k].Text);

    //                if (grvSummery.Columns[k].HeaderText == "Present")
    //                {
    //                    Present += i;
    //                    grvSummery.Columns[k].FooterText = Present.ToString();
    //                }
    //                else if (grvSummery.Columns[k].HeaderText == "Absent")
    //                {
    //                    Absent += i;
    //                    grvSummery.Columns[k].FooterText = Absent.ToString();
    //                }
    //                else if (grvSummery.Columns[k].HeaderText == "Leave")
    //                {
    //                    Leave += i;
    //                    grvSummery.Columns[k].FooterText = Leave.ToString();
    //                }
    //                else if (grvSummery.Columns[k].HeaderText == "Total")
    //                {
    //                    Tot += i;
    //                    grvSummery.Columns[k].FooterText = Tot.ToString();
    //                }
    //                else if (grvSummery.Columns[k].HeaderText == "Late")
    //                {
    //                    Late += i;
    //                    grvSummery.Columns[k].FooterText = Late.ToString();
    //                }
    //                else if (grvSummery.Columns[k].HeaderText == "Total Days")
    //                {
    //                    TotDay += i;
    //                    grvSummery.Columns[k].FooterText = TotDay.ToString();
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception)
    //    {

    //    }
    //}
    protected void ImgPdf_Click(object sender, ImageClickEventArgs e)
    {

        ClsExportPdf exp = new ClsExportPdf();

        // exp.ExportGrid(grvAttendance, "FileName" + DateTime.Now, Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", "Att");
        if (Convert.ToString(Session["UserType_id"]) == "1" || Convert.ToString(Session["UserType_id"]) == "1")
        {
            strQry = "exec [usp_ReportDetails] @type='StudentDetails',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intSchoolId='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            //StudentName = string.Empty;
            //STD = string.Empty;
            //DIV = string.Empty;
            //StudentName = Convert.ToString(dsObj.Tables[0].Rows[0]["Name"]);
            //STD = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStandard_name"]);
            //DIV = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
            //RollNo = Convert.ToInt32(dsObj.Tables[0].Rows[0]["RollNo"]);
        }
        else
        {
            strQry = "exec [usp_ReportDetails] @type='TeacherDetails',@intUserid='" + Convert.ToString(Session["User_id"]) + "',@intUserType='" + Convert.ToString(Session["UserType_id"]) + "'";
            dsObj = sGetDataset(strQry);
            //StudentName = string.Empty;
            //STD = string.Empty;
            //DIV = string.Empty;
            //StudentName = Convert.ToString(dsObj.Tables[0].Rows[0]["Name"]);
            //STD = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDepartment_name"]);
            //DIV = string.Empty;
            //RollNo = Convert.ToInt32(dsObj.Tables[0].Rows[0]["intTeacher_id"]);
        }


        

        //switch (TabContainer1.ActiveTabIndex)
        //{
        //    case 1:
        //        ExportGridToPDF(grvAttendance, "Attendance " + DateTime.Now + ".pdf", "application/pdf");
        //        break;
        //    case 2:
        //        ExportGridToPDF(grvSummery, "AttendanceSummary " + DateTime.Now + ".pdf", "application/pdf");
        //        break;

        //    case 3:
        //        ExportGridToPDF(grvTopAtt, "Top5Attendance " + DateTime.Now + ".pdf", "application/pdf");
        //        break;

        //}
    }
    protected void ImgXls_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ClsExportExcel exp = new ClsExportExcel();

            // exp.ExportGrid(grvAttendance, "FileName" + DateTime.Now, Convert.ToInt32(ddlStudent.SelectedValue), ddlStudent.SelectedItem.Text, ddlSTD.SelectedItem.Text, ddlDIV.SelectedItem.Text, "1", "Att");
            if (Convert.ToString(Session["UserType_id"]) == "1" || Convert.ToString(Session["UserType_id"]) == "1")
            {
                strQry = "exec [usp_ReportDetails] @type='StudentDetails',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intSchoolId='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                //StudentName = string.Empty;
                //STD = string.Empty;
                //DIV = string.Empty;
                //StudentName = Convert.ToString(dsObj.Tables[0].Rows[0]["Name"]);
                //STD = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStandard_name"]);
                //DIV = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
                //RollNo = Convert.ToInt32(dsObj.Tables[0].Rows[0]["RollNo"]);
            }
            else
            {
                strQry = "exec [usp_ReportDetails] @type='TeacherDetails',@intUserid='" + Convert.ToString(Session["User_id"]) + "',@intUserType='" + Convert.ToString(Session["UserType_id"]) + "'";
                dsObj = sGetDataset(strQry);
                //StudentName = string.Empty;
                //STD = string.Empty;
                //DIV = string.Empty;
                //StudentName = Convert.ToString(dsObj.Tables[0].Rows[0]["Name"]);
                //STD = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDepartment_name"]);
                //DIV = string.Empty;
                //RollNo = Convert.ToInt32(dsObj.Tables[0].Rows[0]["intTeacher_id"]);
            }

            
            //switch (TabContainer1.ActiveTabIndex)
            //{
            //    case 1:
            //        ExportGrid(grvAttendance, "Attendance " + DateTime.Now + ".xls", "application/vnd.ms-excel");
            //        break;
            //    case 2:
            //        ExportGrid(grvSummery, "AttendanceSummary " + DateTime.Now + ".xls", "application/vnd.ms-excel");
            //        break;

            //    case 3:
            //        ExportGrid(grvTopAtt, "Top5Attendance " + DateTime.Now + ".xls", "application/vnd.ms-excel");
            //        break;

            //}

        }
        catch
        {

        }
    }

    protected void fillSummery()
    {
        //strQry = "usp_NewAttendanceSummery @command='select',@intstudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intAcademic_id='1'";

        if (Convert.ToString(Session["Student_id"]) == "0")
        {
            strQry = "usp_NewAttendanceSummery @command='selectStaff',@intuser_id='" + Convert.ToString(Session["User_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intUserType_id='" + Convert.ToString(Session["UserType_id"]) + "'";
        }
        else
        {
            strQry = "usp_NewAttendanceSummery @command='select',@intstudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intUserType_id='" + Convert.ToString(Session["UserType_id"]) + "'";
        }

        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            string strMonth = string.Empty;
            string strYear = string.Empty;
            for (int i = 0; i <= dsObj.Tables[0].Rows.Count-1; i++)
            {
                strMonth = Convert.ToString(dsObj.Tables[0].Rows[i]["Month"]);
                strYear = Convert.ToString(dsObj.Tables[0].Rows[i]["Year"]);

                if (strMonth == "1")
                {
                    lblJanPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Present"]);
                    lblJanAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Absent"]);
                    lblJanYear.Text = Convert.ToString(strYear);
                        
                }
                if (strMonth == "2")
                {
                    lblFebPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Present"]);
                    lblFebAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Absent"]);
                    lblFebYear.Text = Convert.ToString(strYear);

                }
                if (strMonth == "3")
                {
                    lblMarchPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Present"]);
                    lblMarchAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Absent"]);
                    lblmarchYear.Text = Convert.ToString(strYear);

                }
                if (strMonth == "4")
                {
                    lblAprilPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Present"]);
                    lblAprilAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Absent"]);
                    lblAprilYear.Text = Convert.ToString(strYear);

                }

                /////////////////////////////

                if (strMonth == "5")
                {
                    lblMayPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Present"]);
                    lblMayAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Absent"]);
                    lblMayYear.Text = Convert.ToString(strYear);

                }
                if (strMonth == "6")
                {
                    lblJunePresent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Present"]);
                    lblJuneAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Absent"]);
                    lblJuneYear.Text = Convert.ToString(strYear);

                }
                if (strMonth == "7")
                {
                    lblJulyPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Present"]);
                    lblJulyAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Absent"]);
                    lbljulyYear.Text = Convert.ToString(strYear);

                }
                if (strMonth == "8")
                {
                    lblAugustPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Present"]);
                    lblAugustAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Absent"]);
                    lblAugustYear.Text = Convert.ToString(strYear);

                }

                /////////////////////////////
                if (strMonth == "9")
                {
                    lblSeptemberPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Present"]);
                    lblSeptemberAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Absent"]);
                    lblSeptemberYear.Text = Convert.ToString(strYear);

                }
                if (strMonth == "10")
                {
                    lblOctoberPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Present"]);
                    lblOctoberAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Absent"]);
                    lblOctoberYear.Text = Convert.ToString(strYear);

                }
                if (strMonth == "11")
                {
                    lblNovemberPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Present"]);
                    lblNovemberAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Absent"]);
                    lblNovemberYear.Text = Convert.ToString(strYear);

                }
                if (strMonth == "12")
                {
                    lblDecemberPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Present"]);
                    lblDecemberAbsent.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["Absent"]);
                    lblDecemberYear.Text = Convert.ToString(strYear);
                }


            }
        }
    }

    protected void grvAttendance_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lnkStatus = (e.Row.FindControl("lblStatus") as Label);
            if (lnkStatus.Text == "Absent")
            {
                Label lblLate = (e.Row.FindControl("lblLate") as Label);
                lblLate.Text = "---";
            }
            
        }
    }
    //protected void grvSummery_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        int i = 0;

    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            int count = grvSummery.Rows.Count + 1;



    //        }//
    //    }
    //    catch
    //    {

    //    }
    //}
}