using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmAdminDashboard : DBUtility  
{
    string strQry = "";
    int id;
    int Month;
    int Year;
    DataSet dsCal;
    DataTable dt = new DataTable();
    DataSet dsObj = new DataSet();  
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {
                    HFUserId.Value = Convert.ToString(Session["User_Id"]);
                    HFUserType.Value = Convert.ToString(Session["UserType_Id"]);
                    //pnlBusAbsent.Attributes.Add("display","none");
                    //pnlBusPresnt.Attributes.Add("display", "none");
                    //pnlMonthLy.Attributes.Add("display", "none");
                    //pnlStudAbsentAtt.Attributes.Add("display", "none");
                    //pnlStudLateAtt.Attributes.Add("display", "none");
                    FillCount();
                    FillSTD();
                    FillDIV();
                    FillGrid();
                    FillSchoolChart();
                    FillStaffCount();
                    FillStudCount();
                    FillLiveLecture();
                    FillHolidayDataset();
                    FillStaffAtt();
                    FillSchoolNotifyPackage();
                    FillBusTravel();
                    FillHolidayDataset();
                    FillParentNotifyPackage();
                    FillStudentOutOfClass();
                    FillSTD_DIV_Attendance();
                    geturl();
                    FillDept();
                    FillNoticeBoard();
                    FillStaff();
                }
                FillHolidayDataset();
                FillSchoolChart();
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
    public void FillDept()
    {
        try
        {
            strQry = "exec [usp_AdminDashboard] @type='FillDepartment',@SchoolId='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlDept, strQry, "Dept", "intDepartment");
        }
        catch
        {
            
            
        }    
    }
    public void FillStaff()
    {
        try
        {
            strQry = "exec [usp_AdminDashboard] @type='FillStaff',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@Dept='" + Convert.ToString(ddlDept.SelectedValue) + "'";
            sBindDropDownList(ddlTeacher, strQry, "Name", "intTeacher_id");
        }
        catch
        {


        }
    }
    public void FillNoticeBoard()
    {
        try
        {
            strQry = "exec [usp_AdminDashboard] @type='NoticeBoard' ";
            if (Convert.ToString(Session["UserType_id"]) == "2")
            {
                // strQry =strQry + " ,@StudentId='" + Convert.ToString(Session["Student_id"]) + "'";
            }
            dsObj = sGetDataset(strQry);
            //Table tbl = new Table();
            ////  TableRow tr = new TableRow();

            //TableHeaderCell th = new TableHeaderCell();
            //TableCell td = new TableCell();
            //tbl.Width = 500;
            //tbl.CaptionAlign = TableCaptionAlign.Top;
            //Label data = new Label();
            for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
            {
                Table tbl = new Table();
                //  TableRow tr = new TableRow();

                TableHeaderCell th = new TableHeaderCell();
                TableCell td = new TableCell();
                tbl.Width = 500;
                tbl.CaptionAlign = TableCaptionAlign.Top;
                Label data = new Label();

                TableRow tr = new TableRow();
                td = new TableCell();
                data.Font.Underline = true;
                data.Text = "Subject :" + Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubject"]) + " (From : " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtIssue_date"]) + " To " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtEnd_date"]) + ")";
                th.Controls.Add(data);
                tr.Cells.Add(th);
                tbl.Rows.Add(tr);

                TableRow tr1 = new TableRow();
                TableCell td1 = new TableCell();
                data.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchNotice"]);
                td1.Controls.Add(data);
                tr1.Cells.Add(td1);
                tbl.Rows.Add(tr1);
                divNoticeBorad.Controls.Add(tbl);
            }
           
        }
        catch
        {

        }
    }

    public object createDataTable(int UserType,int UserId) // To view Staff Monthly Attendance 
    {
        try
        {
            strQry = "exec usp_getAttendance @type='getAtt',@intUserType_id='" + UserType + "',@intUser_id='" + UserId + "',@month='" + Convert.ToString(DateTime.Now.Month) + "',@year='" + Convert.ToString(DateTime.Now.Year) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            Session["Attend"] = dsObj;
            return dsObj;
        }
        catch
        {
            return 0;
        }



    }
    protected void FillHolidayDataset()
    {
        if (CalAttendance.VisibleDate.Year == 0001)
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;

        }
        else
        {
            //Year = CalAttendance.VisibleDate.Year;
            //Month = CalAttendance.VisibleDate.Month - 1;
            Month = CalAttendance.VisibleDate.Month;
            Year = CalAttendance.VisibleDate.Year;
        }
        DateTime firstDate = new DateTime(Year, Month, 1);
        CalAttendance.VisibleDate = new DateTime(Year, Month, 1);
        DateTime lastDate = GetFirstDayOfNextMonth();
        dsObj = GetCurrentMonthData(firstDate, lastDate);
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


    public DataSet GetCurrentMonthData(DateTime FirstDt, DateTime LastDt)
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_AdminDashboard] @type='FillCalendar',  @FirstDate='" + Convert.ToDateTime(FirstDt).ToString("yyyy/MM/dd") + "',@LastDate='" + Convert.ToDateTime(LastDt).ToString("yyyy/MM/dd") + "',@SchoolId='" + Convert.ToString(Session["School_id"]) + "'";
            dsCal = sGetDataset(strQry);
            return dsCal;
        }
        catch (Exception)
        {
            return dsObj;
        }
    }
    public void FillSTD()
    {
        try
        {
            strQry = "exec usp_AdminDashboard @type='FillSTD',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
           
            ddlSTD.DataSource = dsObj.Tables[0];
            ddlSTD.DataTextField = "vchStandard_name";
            ddlSTD.DataValueField = "intstandard_id";
            ddlSTD.DataBind();

            ddlSTD.Items.Add(new ListItem("All", "0"));
            ddlSTD.SelectedValue = "0";


            ddlPSTD.DataSource = dsObj.Tables[0];
            ddlPSTD.DataTextField = "vchStandard_name";
            ddlPSTD.DataValueField = "intstandard_id";
            ddlPSTD.DataBind();

            ddlPSTD.Items.Add(new ListItem("All", "0"));
            ddlPSTD.SelectedValue = "0";
        }
        catch
        {

        }
    }
    public void FillDIV()
    {
        try
        {
            strQry = "exec usp_AdminDashboard @type='FillDIV',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "',@STD='"+ Convert.ToString(ddlSTD.SelectedValue) +"'";
            //sBindDropDownList(ddlDIV, strQry, "vchDivisionName", "intDivision_id");
            dsObj = sGetDataset(strQry);
            ddlDIV.DataSource = dsObj;
            ddlDIV.DataTextField = "vchDivisionName";
            ddlDIV.DataValueField = "intDivision_id";
            ddlDIV.DataBind();
            ddlDIV.Items.Add(new ListItem("All", "0"));
            ddlDIV.SelectedValue = "0";
        }
        catch
        {

        }
    }
    [System.Web.Services.WebMethod]
    public static string Notification(string UserType, string Id)
    {
        try
        {
            string strQry = "";
            strQry = "exec [usp_ChartStaffAttendance] @type='MsgNotification',@UserType='" + UserType + "',@StaffId='" + Id + "'";
            DataSet ds = new DataSet();
            ds = sGetDataset(strQry);
            Label lblMsgCount = new Label();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblMsgCount.Text = Convert.ToString(ds.Tables[0].Rows[0][0]);
            }
            return lblMsgCount.Text;
        }
        catch
        {
            return "false";

        }
    }
    public void FillSchoolChart()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_AdminDashboard @type='DepartMentAllocation',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
            dt = sGetDatatable(strQry, "Chart");
            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }

            ChrtSchoolAtt.Series[0].Points.DataBindXY(x, y);
            ChrtSchoolAtt.Series[0].IsValueShownAsLabel = true;


            //ChrtSchoolAtt.se

            int point = Convert.ToInt32(ChrtSchoolAtt.Series[0].Points.Count);
            Boolean pointAdd = false;




           

            ChrtSchoolAtt.ChartAreas["ChartArea"].Area3DStyle.Enable3D = true;
            ChrtSchoolAtt.Legends[0].Enabled = true;
        }
        catch
        {

        }
    }
    public void FillGrid()
    {
        try
        {
            strQry = "exec usp_AdminDashboard  @type='StaffLeaves',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindGrid(grvLeaveStatus, strQry);
        }
        catch 
        {
            
        }
    }

    private DataSet GetData(int UserType,int UserId)
    {
        try
        {

            strQry = "exec usp_getAttendance @type='getCalenderAtt',@intUserType_id='" + UserType + "',@intUser_id='" + Convert.ToString(UserId) + "',@intStudentId='0',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            Session["StaffCal"] = dsObj;
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
                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF6600");
                e.Cell.ToolTip = "Holiday";
                // return;
            }
            if (((DataSet)Session["StaffCal"] != null))
            {
                foreach (DataRow dr in ((DataSet)Session["StaffCal"]).Tables[0].Rows)
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
                        else if (status == "Leave Approving")
                        {
                            //lc2.Text = @"<br/>" + "<font size=1 color=black> Leave Approving </font>" + "<br/>" + scheduled_LoginTime;
                            e.Cell.Controls.Add(lc2);
                            e.Cell.ToolTip = "Leave Approving";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#9905af");
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

            ModalCalendar.Show();
            FillSchoolChart(); 
        }
        catch (Exception ex)
        {

        }

    }

    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           
                FillDIV();
                FillStudCount();
                FillSchoolChart();
            
        }
        catch
        {
            
        }
    }

    public void FillStudCount()
    {
        try
        {
            strQry = "exec usp_AdminDashboard @type='StudentPresentCount',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "',@STD='" + Convert.ToString(ddlSTD.SelectedValue) + "',@DIV='" + Convert.ToString(ddlDIV.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0 && Convert.ToInt32(dsObj.Tables[0].Rows[0]["TotCount"]) > 0 && Convert.ToInt32(dsObj.Tables[0].Rows[0]["Count"]) > 0)
            {
                lblTotStud.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotCount"]);
                lblTotPresentStud.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Count"]);
            }
            else
            {
                 lblTotStud.Text ="0";
                 lblTotPresentStud.Text = "0";
            }
        }
        catch 
        {
            
        }
    }
    public void FillStaffCount()
    {
        try
        {
            strQry = "exec usp_AdminDashboard @type='StaffPresentCount',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                lblTotStaff.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotCount"]);
                lblTotStaffPresent.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Count"]);
            }
            else
            {
                lblTotStaff.Text = "0";
                lblTotStaffPresent.Text = "0";
            }
        }
        catch
        {

        }
    }
protected void  ddlDIV_SelectedIndexChanged(object sender, EventArgs e)
{
    try 
	{
        if (ddlDIV.SelectedValue != "0")
        {
            FillStudCount();
            FillSchoolChart();
        }
        else
        {
            lblTotStud.Text = "0";
            lblTotPresentStud.Text ="0";
        }

	}
	catch 
	{
	}
}
protected void grvLeaveStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
{
    try
    {
        grvLeaveStatus.PageIndex = e.NewPageIndex;
        grvLeaveStatus.DataBind();
        FillGrid();
    }
    catch
    {
        
    }
}
public void FillCount()
{
    try
    {
        strQry = "";
        strQry = "exec usp_AdminDashboard @type='AllCount',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            lblNoOfStudent.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Student"]);
            lblNoOfStaff.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Staff"]);
            lblNoOfDept.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Department"]);
            lblNoOfAdmin.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Admin"]);
            
        }
    }
    catch 
    {
        
    }
}
protected void CalAttendance_DayRender(object sender, DayRenderEventArgs e)
{
    try
    {
        if (e.Day.Date.Day.ToString() == "15")
        {
            Month = e.Day.Date.Month;
            Year = e.Day.Date.Year;
        }
        if (e.Day.Date.DayOfWeek.ToString() == "Sunday")
        {
            e.Cell.BackColor = System.Drawing.Color.IndianRed;
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
                        e.Cell.BackColor = System.Drawing.Color.SkyBlue;
                        e.Cell.ToolTip = (string)dr["Name"];
                    }
                    else if ((string)dr["Type"] == "Vacation")
                    {
                        e.Cell.BackColor = System.Drawing.Color.Green;
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

        FillSchoolChart();
    }
    catch (Exception)
    {

    }
}
public void FillStudentOutOfClass()
{
    try
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Roll");
        dt.Columns.Add("Name");
        dt.Columns.Add("STD");
        dt.Columns.Add("DIV");

        DataRow dr = dt.NewRow();
        dr["Roll"] = "05";
        dr["Name"] = "Ashish Salunkhe";
        dr["STD"] = "5th";
        dr["DIV"] = "A";
        dt.Rows.Add(dr);

         dr = dt.NewRow();
        dr["Roll"] = "15";
        dr["Name"] = "Neha Pawar";
        dr["STD"] = "8th";
        dr["DIV"] = "C";
        dt.Rows.Add(dr);

        grvStudentOutOfClass.DataSource = dt;
        grvStudentOutOfClass.DataBind();
    }
    catch
    {

    }
}
    

public void FillSTD_DIV_Attendance()
{
    try
    {
        try
        {
            strQry = string.Empty;
            strQry = "exec [usp_AdminDashboard] @type='Student_Attendance',@SchoolId='"+ Convert.ToString(Session["School_Id"]) +"'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvAttendanceDetail.DataSource = dsObj;
                grvAttendanceDetail.DataBind();
            }
            else
            {
                grvAttendanceDetail.DataSource = null;
                grvAttendanceDetail.DataBind();
            }
          
        }
        catch
        {

        }
    }
    catch 
    {
        
    }
}
public void FillStudentLateAttDetail(int DivID)
{
    try
    {

        strQry = string.Empty;
        strQry = "exec [usp_AdminDashboard] @type='Late_Absent_Student',@status='Late',@DIV='" + DivID + "',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
        dsObj = sGetDataset(strQry);
        grvStudLate.DataSource = dsObj;
        grvStudLate.DataBind();
 
    }
    catch 
    {
        
    }
}
public void FillStudentAbsentDetail(int DivID)
{
    try
    {
        strQry = string.Empty;
        strQry = "exec [usp_AdminDashboard] @type='Late_Absent_Student',@status='Absent',@DIV='" + DivID + "',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
        dsObj = sGetDataset(strQry);
        grvStudAbsent.DataSource = dsObj;
        grvStudAbsent.DataBind();
       
    }
    catch
    {

    }
}
public void FillStaffAtt()
{
    try
    {
        strQry = string.Empty;
        strQry = "exec [usp_AdminDashboard] @type='Staff_Attendance',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvStaffAtt.DataSource = dsObj;
            grvStaffAtt.DataBind();
        }
    }
    catch
    {

    }
}

public void FillStaffAttDetail(int UserType,int UserId) 
{
    try
    {
        grvMonthyAtt.DataSource = createDataTable(UserType, UserId);
        grvMonthyAtt.DataBind();
    }
    catch 
    {
        
    }
}
protected void grvStaffAtt_RowCommand(object sender, GridViewCommandEventArgs e)
{
    try
    {
        if (e.CommandName == "View")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int UserId = Convert.ToInt32(grvStaffAtt.DataKeys[index].Value);
            Label lblUserType = (Label)grvStaffAtt.Rows[index].FindControl("lblUserType");
            int UserType_Id = Convert.ToInt32(lblUserType.Text);
            FillStaffAttDetail(UserType_Id,UserId);
            ModalStaffAtt.Show();
            FillSchoolChart();
        }
        else if (e.CommandName == "Calendar")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int UserId = Convert.ToInt32(grvStaffAtt.DataKeys[index].Value);
            Label lblUserType = (Label)grvStaffAtt.Rows[index].FindControl("lblUserType");
            int UserType_Id = Convert.ToInt32(lblUserType.Text);
            GetData(UserType_Id, UserId);
            ModalCalendar.Show();
            FillSchoolChart();
        }
    }
    catch
    {
        
    }
}

protected void grvAttendanceDetail_RowEditing(object sender, GridViewEditEventArgs e) // Detail Of Late Students
{
    try
    {
        int i = Convert.ToInt32(grvAttendanceDetail.DataKeys[e.NewEditIndex].Value);
        FillStudentLateAttDetail(i);
        ModalStudLateAtt.Show();
        FillSchoolChart();
    }
    catch
    {

    }
}
protected void grvAttendanceDetail_RowDeleting(object sender, GridViewDeleteEventArgs e) // Detail Of Absent Students
{
    try
    {
        int i = Convert.ToInt32(grvAttendanceDetail.DataKeys[e.RowIndex].Value);
        FillStudentAbsentDetail(i);
        ModalStudAbsentAtt.Show();
        FillSchoolChart();
    }
    catch 
    {
        
        throw;
    }
}
public void FillLiveLecture()
{
    try
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("STD");
        dt.Columns.Add("DIV");
        dt.Columns.Add("Staff");
        dt.Columns.Add("Lec");
        dt.Columns.Add("Time");
        dt.Columns.Add("TempStaff");

        DataRow dr = dt.NewRow();
        dr["STD"] = "1st";
        dr["DIV"] = "A";
        dr["Staff"] = "Rakesh Shah";
        dr["Lec"] = "English";
        dr["Time"] = "8:00 AM";
        dr["TempStaff"] = "No";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["STD"] = "1st";
        dr["DIV"] = "B";
        dr["Staff"] = "Renuka Kale";
        dr["Lec"] = "Marathi";
        dr["Time"] = "8:05 AM";
        dr["TempStaff"] = "Yes";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["STD"] = "2nd";
        dr["DIV"] = "B";
        dr["Staff"] = "Raj Yadav";
        dr["Lec"] = "Sanskrit";
        dr["Time"] = "8:10 AM";
        dr["TempStaff"] = "No";
        dt.Rows.Add(dr);

        grvLectureAtt.DataSource = dt;
        grvLectureAtt.DataBind();
        FillSchoolChart();
    }
    catch 
    {
        
    }
}

public void FillBusTravel()
{
    try
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("Route");
        dt.Columns.Add("Trip");
        dt.Columns.Add("BusName");
        dt.Columns.Add("Driver");
        dt.Columns.Add("STD");
        dt.Columns.Add("ATD");
       

        DataRow dr = dt.NewRow();
        dr["Route"] = "Vashi-Sanpada";
        dr["Trip"] = "V-S";
        dr["BusName"] = "MH-3562";
        dr["Driver"] = "Anil";
        dr["STD"] = "7:00 AM";
        dr["ATD"] = "7:05 AM";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Route"] = "Nerul-Sanpada";
        dr["Trip"] = "N-S";
        dr["BusName"] = "MH-3002";
        dr["Driver"] = "Rakesh";
        dr["STD"] = "7:00 AM";
        dr["ATD"] = "7:15 AM";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["Route"] = "Panvel-Sanpada";
        dr["Trip"] = "P-S";
        dr["BusName"] = "MH-3001";
        dr["Driver"] = "Ramesh";
        dr["STD"] = "7:00 AM";
        dr["ATD"] = "7:01 AM";
        dt.Rows.Add(dr);

        grvBusAtt.DataSource = dt;
        grvBusAtt.DataBind();
    }
    catch 
    {
    }
}

public void FillSchoolNotifyPackage()
{
    try
    {
        strQry = string.Empty;
        strQry = "exec [usp_AdminDashboard] @type='SchoolPackage',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
        dsObj = sGetDataset(strQry);
        grvSchoolNotify.DataSource = dsObj;
        grvSchoolNotify.DataBind();
        FillSchoolChart();
    }
    catch 
    {
        
    }
}
public void FillBusPresentDetail()
{
    try
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("STD");
        dt.Columns.Add("DIV");
        dt.Columns.Add("RollNo");
        dt.Columns.Add("StudName");

        DataRow dr = dt.NewRow();
        dr["STD"] = "1st";
        dr["DIV"] = "A";
        dr["RollNo"] = "12";
        dr["StudName"] = "Ashok Varma";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["STD"] = "2nd";
        dr["DIV"] = "A";
        dr["RollNo"] = "22";
        dr["StudName"] = "Raj Varma";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["STD"] = "3rd";
        dr["DIV"] = "C";
        dr["RollNo"] = "21";
        dr["StudName"] = "Anita Naik";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["STD"] = "4th";
        dr["DIV"] = "C";
        dr["RollNo"] = "12";
        dr["StudName"] = "Raj Yadav";
        dt.Rows.Add(dr);

        grvBusPresentDetails.DataSource = dt;
        grvBusPresentDetails.DataBind();
    }
    catch 
    {
        
    }
}
public void FillBusAbsent()
{
    try
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("STD");
        dt.Columns.Add("DIV");
        dt.Columns.Add("RollNo");
        dt.Columns.Add("StudName");

        DataRow dr = dt.NewRow();
        dr["STD"] = "1st";
        dr["DIV"] = "A";
        dr["RollNo"] = "02";
        dr["StudName"] = "Vinayak Varma";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["STD"] = "2nd";
        dr["DIV"] = "A";
        dr["RollNo"] = "42";
        dr["StudName"] = "Sonal Varma";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["STD"] = "3rd";
        dr["DIV"] = "C";
        dr["RollNo"] = "23";
        dr["StudName"] = "Poonam Naik";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["STD"] = "4th";
        dr["DIV"] = "C";
        dr["RollNo"] = "02";
        dr["StudName"] = "Rahul Yadav";
        dt.Rows.Add(dr);

        grvBusAbsentDetails.DataSource = dt;
        grvBusAbsentDetails.DataBind();
        FillSchoolChart();
    }
    catch
    {

    }
}
protected void grvAttendanceDetail_SelectedIndexChanged(object sender, EventArgs e)
{

}

protected void grvBusAtt_RowEditing(object sender, GridViewEditEventArgs e)
{
    try
    {

        FillBusPresentDetail();
        ModalBusPresnt.Show();
        FillSchoolChart();
    }
    catch
    {
        
    }
}
protected void grvBusAtt_RowDeleting(object sender, GridViewDeleteEventArgs e)
{
    try
    {
        FillBusAbsent();
        ModalBusAbsnt.Show();
        FillSchoolChart();
    }
    catch
    {
        
    }
}
public void FillSchoolNotifyPackageDetail(int PackageId)
{
    try
    {
        strQry = string.Empty;
        strQry = "exec [usp_AdminDashboard] @type='SchoolPackageDetail',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "',@intPackage_id='" + PackageId + "'";
        dsObj = sGetDataset(strQry);

        grvSchoolNotifyDetail.DataSource = dsObj;
        grvSchoolNotifyDetail.DataBind();
        FillSchoolChart();
    }
    catch
    {
        
    }
}

public void FillParentNotifyPackage()
{
    try
    {
        strQry = string.Empty;
        strQry = "exec [usp_AdminDashboard] @type='SchoolPackage',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
        dsObj = sGetDataset(strQry);
        
        grvParentNotify.DataSource = dsObj;
        grvParentNotify.DataBind();

        FillSchoolChart();
    }
    catch 
    {
        

    }
}
protected void ImgDetail0_Click(object sender, ImageClickEventArgs e)
{
   
}
public void FillParentNotifyDetail(int PackageId)
{
    try
    {
        strQry = string.Empty;
        strQry = "exec [usp_AdminDashboard]  @type='FillCurrentPackage',@STD='" + Convert.ToString(ddlPSTD.SelectedValue) + "',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "',@DIV='" + Convert.ToString(Convert.ToString(ddlPDIV.SelectedValue)) + "',@PackageId='" + PackageId + "'";
        dsObj = sGetDataset(strQry);
        grvParentNotifyDetail.DataSource = dsObj;
        grvParentNotifyDetail.DataBind();
    }
    catch
    {

    }
}

protected void grvSchoolNotify_RowDeleting(object sender, GridViewDeleteEventArgs e)
{
    int i = (int)grvSchoolNotify.DataKeys[e.RowIndex].Value;
    FillSchoolNotifyPackageDetail(i);
    ModalSchool.Show();
    FillSchoolChart();
}
protected void grvParentNotify_RowDeleting(object sender, GridViewDeleteEventArgs e)
{
    FillSTD();
    ddlPSTD_SelectedIndexChanged(null, null);
    int PackageId = (int)grvParentNotify.DataKeys[e.RowIndex].Value;
    ViewState["PackageId"] = PackageId;
    FillParentNotifyDetail(PackageId);
    ModalPopupExtender5.Show();
    FillSchoolChart();
}

protected void CalAttendance_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
{
    FillHolidayDataset();
}
protected void CalAttendance_SelectionChanged(object sender, EventArgs e)
{
    FillHolidayDataset();
}
protected void ddlPSTD_SelectedIndexChanged(object sender, EventArgs e)
{
    try
    {
        strQry = "exec usp_AdminDashboard @type='FillDIV',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "',@STD='" + Convert.ToString(ddlPSTD.SelectedValue) + "'";
        //sBindDropDownList(ddlDIV, strQry, "vchDivisionName", "intDivision_id");
        dsObj = sGetDataset(strQry);
        ddlPDIV.DataSource = dsObj;
        ddlPDIV.DataTextField = "vchDivisionName";
        ddlPDIV.DataValueField = "intDivision_id";
        ddlPDIV.DataBind();
        ddlPDIV.Items.Add(new ListItem("All", "0"));
        ddlPDIV.SelectedValue = "0";


        FillParentNotifyDetail(Convert.ToInt32(ViewState["PackageId"]));
        ModalPopupExtender5.Show();
    }
    catch
    {
        
    }
}
protected void ddlPDIV_SelectedIndexChanged(object sender, EventArgs e)
{
    try
    {
        FillParentNotifyDetail(Convert.ToInt32(ViewState["PackageId"]));
        ModalPopupExtender5.Show();
    }
    catch 
    {
        
    }
}
protected void grvParentNotifyDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
{
    try
    {
        grvParentNotifyDetail.PageIndex = e.NewPageIndex;
        FillParentNotifyDetail(Convert.ToInt32(ViewState["PackageId"]));
        grvParentNotifyDetail.DataBind();
        ModalPopupExtender5.Show();
    }
    catch 
    {
        
    }

}
protected void lnkLeaveApproved_Click(object sender, EventArgs e)
{
    try
    {
        LinkButton Action = (LinkButton)sender;
        GridViewRow grvRow = (GridViewRow)Action.NamingContainer;
        int index = grvRow.RowIndex;
        Label lblLeaveId = (Label)grvLeaveStatus.Rows[index].FindControl("lblLeaveId");
        Label lblUserId = (Label)grvLeaveStatus.Rows[index].FindControl("lblUserId");
        Label lblUserType = (Label)grvLeaveStatus.Rows[index].FindControl("lblUserTypeID");
        lblLeaveAction.Text = Convert.ToString(grvLeaveStatus.Rows[index].Cells[1].Text);
        ViewState["UserId"] = Convert.ToString(lblUserId.Text);
        ViewState["LeaveId"] = Convert.ToString(lblLeaveId.Text);
        ViewState["UserTypeId"] = Convert.ToString(lblUserType.Text);
        ViewState["Frm"] = Convert.ToString(grvLeaveStatus.Rows[index].Cells[5].Text);
        ViewState["To"] = Convert.ToString(grvLeaveStatus.Rows[index].Cells[6].Text);
        ModalLeaveRemark.Show();
    }
    catch 
    {
    }
}
protected void btnSubmit_Click(object sender, EventArgs e)
{
    try
    {
        strQry = "exec [usp_AdminDashboard] @type='UpdateStaffLeave',@bitAdminApproval='" + Convert.ToString(rdbAction.SelectedValue) + "',@vchAdminRemark='" + Convert.ToString(txtRemark.Text) + "',@intLeaveApplocation_id='" + Convert.ToString(ViewState["LeaveId"]) + "'";
        if (sExecuteQuery(strQry) != -1)
        {
            //Added By Tushar On 04/02/2015
            if (rdbAction.SelectedValue == "1")
            {
                strQry = "exec usp_getAttendance @type='StaffLeaveEntry',@intUserType_id='" + Convert.ToString(ViewState["UserTypeId"]) + "',@intUser_id='" + Convert.ToString(ViewState["UserId"]) + "',@FrmDt='" + Convert.ToDateTime(ViewState["Frm"]).ToString("MM/dd/yyyy") + "',@EndDt='" + Convert.ToDateTime(ViewState["To"]).ToString("MM/dd/yyyy") + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                if (sExecuteQuery(strQry) == -1)
                {
                    MessageBox("Problem Found");
                }
                else
                {
                    MessageBox("Record Saved Successfully");
                    FillGrid();
                }
            }
            else
            {
                strQry = "exec usp_getAttendance @type='staffCancelLeaveEntry',@intUserType_id='" + Convert.ToString(ViewState["UserTypeId"]) + "',@intUser_id='" + Convert.ToString(ViewState["UserId"]) + "',@FrmDt='" + Convert.ToDateTime(ViewState["Frm"]).ToString("MM/dd/yyyy") + "',@EndDt='" + Convert.ToDateTime(ViewState["To"]).ToString("MM/dd/yyyy") + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                if (sExecuteQuery(strQry) == -1)
                {
                    MessageBox("Problem Found");
                }
                else
                {
                    MessageBox("Record Saved Successfully");
                    FillGrid();
                }
            }
                
           
        }

        //End
    }
    catch
    {
        
    }
}
protected void CalStaffAtt_SelectionChanged(object sender, EventArgs e)
{
    ModalCalendar.Show();
}
protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
{
    try
    {
        FillStaff();
    }
    catch 
    {
        
    }
}
protected void btnSend_Click(object sender, EventArgs e)
{
    try
    {
        checksession();

        if (ddlDept.Visible == true)
        {
            if (ddlDept.SelectedValue == "0")
            {
                MessageBox("Please Select Department First");
                return;
            }
        }
        else if (ddlTeacher.Visible == true)
        {
            if (ddlTeacher.SelectedValue == "0")
            {
                MessageBox("Please Select Name First");
                return;
            }
        }


        string GroupId;

        if (txtMsg.Text != "")
        {


            strQry = string.Empty;
            strQry = "exec usp_MessageMst @type='CheckExist',@intUser_id2='" + Convert.ToString(Session["User_Id"]) + "',@intUserType_id2='" + Convert.ToString(Session["UserType_Id"]) + "',@intUser_id='" + Convert.ToString(ddlTeacher.SelectedValue) + "',@intUserType_id='" + Convert.ToString("3") + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = new DataSet();
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                Session["GrpId"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intGroup_id"]);
                Session["MemId"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intGrpMem_Id"]);


                strQry = string.Empty;
                strQry = "exec [usp_MessageMst] @type='UpdateNotification',@intGrpMember_Id='" + Session["MemId"].ToString() + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                sExecuteQuery(strQry);
            }
            else
            {
                strQry = string.Empty;
                //strQry = "exec usp_GroupMsg_Mst @type='Insert',@vchGroup_name='Private',@vchGroupType='Private',@intGroupCreatedBy='" + Session["User_Id"] + "',@intUser_id='" + Session["User_Id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";

                //26-11-2014  This will adding group details as well as created gropu member detail also
                strQry = "exec [usp_GroupMemberMsg_Mst] @type='Insert',@vchGroup_name='Private',@vchGroupType='Private',@intGroupCreatedByType='" + Convert.ToString(Session["UserType_Id"]) + "',@intUserType_id='" + Convert.ToString(Session["UserType_Id"]) + "',@intGroupCreatedBy='" + Session["User_Id"] + "',@intStudent_id='" + Convert.ToString("0") + "',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    strQry = string.Empty;
                    strQry = "exec [usp_GroupMsg_Mst] @type='LastInsertedId',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                    dsObj = new DataSet();
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        Session["GrpId"] = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
                        GroupId = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
                        strQry = string.Empty;
                        //strQry = "exec usp_GroupMemberMsg_Mst @type='InsertMember',@intGroup_id='" + Convert.ToString(GroupId) + "',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@intUserType_id='" + Convert.ToString(Session["UserType_Id"]) + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + Convert.ToString(GetSystemIP()) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";

                        //if (sExecuteQuery(strQry) != -1)
                        //{
                        strQry = string.Empty;
                        strQry = "exec usp_GroupMemberMsg_Mst @type='InsertMember',@intGroup_id='" + Convert.ToString(GroupId) + "',@intUser_id='" + Convert.ToString(ddlTeacher.SelectedValue) + "',@intStudent_id='" + Convert.ToString("0") + "',@intUserType_id='" + Convert.ToString("3") + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + Convert.ToString(GetSystemIP()) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";

                        sExecuteQuery(strQry);

                        strQry = string.Empty;
                        strQry = "exec [usp_GroupMsg_Mst] @type='LastInsertedId',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                        dsObj = new DataSet();
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            Session["MemId"] = dsObj.Tables[0].Rows[0][0];

                            strQry = string.Empty;
                            strQry = "exec [usp_MessageMst] @type='UpdateNotification',@intGrpMember_Id='" + Session["MemId"].ToString() + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
                            sExecuteQuery(strQry);
                        }
                        //}
                    }
                }

            }





            dsObj = new DataSet();
            strQry = string.Empty;
            strQry = "exec usp_MessageMst @type='Insert',@intGroupid='" + Session["GrpId"] + "',@intGrpMember_Id='" + Session["MemId"] + "',@intUser_SenderId='" + Convert.ToString(Session["User_Id"]) + "',@intUser_ReceiveType='" + Convert.ToString("3") + "',@intUser_ReceiveId='" + Convert.ToString(ddlTeacher.SelectedValue) + "',@intInserted_by='" + Session["User_Id"] + "',@Inserted_IP='" + GetSystemIP() + "',@Message='" + Convert.ToString(txtMsg.Text.Trim()) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                txtMsg.Text = "";
               // OpenChat();
            }
            else
            {
                MessageBox("Problem Found! ");
            }
        }
    }
    catch (Exception)
    {

        throw;
    }
}
protected void btnApply_Click(object sender, EventArgs e)
{
    try
    {
        strQry = "exec [usp_AdminDashboard] @type='InsertNoticeBoard',@vchNotice='"+ Convert.ToString(txtNotice.Text) +"'";
        sExecuteQuery(strQry);
        FillNoticeBoard();
    }
    catch 
    {
        
    }
}
}