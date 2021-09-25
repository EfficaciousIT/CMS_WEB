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

public partial class NewAdminDashBoard : DBUtility
{
    string strQry = string.Empty;
    int Month;
    int Year;
    DataSet dsCal;
    DataTable dt = new DataTable();
    DataSet dsObj = new DataSet();  
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Page.Header.DataBind(); 
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {
                    //   HFUserId.Value = Convert.ToString(Session["User_Id"]);
                    //HFUserType.Value = Convert.ToString(Session["UserType_Id"]);
                    fillBusDetails();
                    FillPersonal();
                    FillAttendanceCount();
                    FillStaffLeaves();
                    RefreshPage();
                    FillBusDetail();
                    LiveLecture();
                    FillDept();
                    FillLoginDetails();
                    fillDrp();
                    FillLoginDetails();
                    FillUpcomingEvents();
                    // FillStaff();
                }
            
                FillHolidayDataset();
                FillStaffLeaves();
                FillNoticeBoard();
               Script();
            }
            else
            {
                Response.Redirect("~\\frmIndex.aspx", false);
            }
        }
        catch(Exception ex)
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
    public void Script()
    {
        try
        {
            strQry = "$(document).ready(function () {";
            strQry += "$('.lightbox').hide();";
         //   strQry += " });";
           // strQry += "$(function(){";
            strQry += "$('.Setting').click(function () {";
            strQry += "$('.lightbox').fadeIn(500);";
            strQry += "});";
            strQry += "$('#closeLightbox').click(function () {";
            strQry += "$('.lightbox').fadeOut(500);";
            strQry += "});";
            strQry += "});";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", strQry, true);


            strQry = "$(document).ready(function () {";
            strQry += "$('#login-trigger').click(function () {";
            strQry += "$(this).next('#login-content').slideToggle();";
            strQry += "$(this).toggleClass('active');";
            strQry += "if ($(this).hasClass('active')) $(this).find('span').html('&#x25B2;')";
            strQry += "else $(this).find('span').html('&#x25BC;')";
            strQry += "});";
            strQry += "$('#set-trigger').click(function () {";
            strQry += "$(this).next('#set-content').slideToggle();";
            strQry += "$(this).toggleClass('active');";
            strQry += "if ($(this).hasClass('active')) $(this).find('span').html('&#x25B2;')";
            strQry += "else $(this).find('span').html('&#x25BC;')";
            strQry += "});";
            strQry += "});";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", strQry, true);
        }
        catch 
        {
            
        }
    }
    public void FillNoticeBoard()
    {
        try
        {
            strQry = "usp_NewAdminDashboard @type='NoticeBoard',@SchoolId='" + Session["School_id"] + "'";

            dsObj = sGetDataset(strQry);

            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grdNotice.DataSource = dsObj;
                grdNotice.DataBind();
            }
            else
            {
                grdNotice.DataSource = dsObj;
                grdNotice.DataBind();
            }
            //Table tbl = new Table();
            ////  TableRow tr = new TableRow();

            //TableHeaderCell th = new TableHeaderCell();
            //TableCell td = new TableCell();
            ////  tbl.Width = 500;
            //tbl.CaptionAlign = TableCaptionAlign.Top;

            //for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
            //{
            //    Label data = new Label();
            //    TableRow tr = new TableRow();
            //    td = new TableCell();
            //    data.Font.Underline = true;
            //    //data.Text = "Subject :" + Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubject"]) + " (From : " + Convert.ToString(dsObj.Tables[0].Rows[0]["dtIssue_date"]) + " To " + Convert.ToString(dsObj.Tables[0].Rows[0]["dtEnd_date"]) + ")";
            //    //th.Controls.Add(data);
            //    //tr.Cells.Add(th);
            //    //tbl.Rows.Add(tr);

            //    TableRow tr1 = new TableRow();
            //    TableCell td1 = new TableCell();
            //    data.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchNotice"]);
            //    td1.Controls.Add(data);
            //    tr1.Cells.Add(td1);
            //    tbl.Rows.Add(tr1);
            //    divNoticeBorad.Controls.Add(tbl);

            //}

        }
        catch
        {

        }
    }
    public void FillLoginDetails()
    {
        try
        {
            strQry = "exec [usp_NewAdminDashboard] @type='StudentLog',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@UserId='" + Convert.ToString(Session["User_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvLastLogin.DataSource = dsObj;
                grvLastLogin.DataBind();
            }           

        }
        catch
        {

        }
    }
    public void FillUpcomingEvents()
    {
        try
        {
            strQry = "exec [usp_NewAdminDashboard] @type='UpcomingEvents',@SchoolId='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grdUpcomingEvents.DataSource = dsObj;
                grdUpcomingEvents.DataBind();
            }

        }
        catch
        {

        }
    }
    public void RefreshPage()
    {
        try
        {
            strQry = "exec [usp_NewAdminDashboard] @type='GetRefreshPage',@UserId='" + Convert.ToString(Session["User_id"]) + "'";
            dsObj = sGetDataset(strQry);
            ScriptManager.RegisterStartupScript((Page)(HttpContext.Current.Handler), typeof(Page), "script", "setInterval(function() { window.location=window.location;},"+ Convert.ToString(dsObj.Tables[0].Rows[0][0]) +");", true);
        }
        catch 
        {
            
        }
    }
    public void FillPersonal()
    {
        try
        {
            strQry = "exec [usp_NewAdminDashboard] @type='AdminTitleBar',@UserId='" + Convert.ToString(Session["User_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ImgAdmin.Attributes.Add("src", "images\\"+ Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) +"");
                lblWelcomeName.Text = "Good " + Convert.ToString(dsObj.Tables[0].Rows[0]["Session"]) + " " + Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]); 
            }
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
            UserType = Convert.ToString(HttpContext.Current.Session["UserType_id"]);
            Id = Convert.ToString(HttpContext.Current.Session["User_id"]);
            string school = Convert.ToString(HttpContext.Current.Session["School_id"]);
            strQry = "exec [usp_ChartStaffAttendance] @type='MsgNotification',@UserType='" + UserType + "',@StaffId='" + Id + "',@SchoolId='" + school + "'";
            DataSet ds = new DataSet();
            ds = sGetDataset(strQry);
            Label lblMsgCount = new Label();
            if (ds.Tables[0].Rows.Count > 0)
            {
              
               
                if (Convert.ToString(ds.Tables[0].Rows[0][0]) != "")
                {
                    lblMsgCount.Text = Convert.ToString("0");
                    //lblMsgCount.Text = Convert.ToString(ds.Tables[0].Rows[0][0]);
                }
                else
                {
                    lblMsgCount.Text = "0";
                }
               
            }
            return lblMsgCount.Text;
        }
        catch
        {
            return "false";

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
     [System.Web.Services.WebMethod]

    public static List<clsDropDownList> FillStaff(string Dept)
    {
        
            string strQry = "exec [usp_AdminDashboard] @type='FillStaff',@SchoolId='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "',@Dept='" + Convert.ToString(Dept) + "'";
            string Result = string.Empty;
            DataTable dt = new DataTable();
            List<clsDropDownList> lst = new List<clsDropDownList>();  
            dt = sGetDatatable(strQry, "Table");

            if (dt.Rows.Count != 0)
            {
                HttpContext.Current.Session["Type"] = dt.Rows[0]["intUserType_id"].ToString();
                foreach (DataRow dtrow in dt.Rows)
                {
                    clsDropDownList staff = new clsDropDownList();
                    staff.DataValueField = Convert.ToInt32(dtrow["intTeacher_id"].ToString());
                    staff.DataTextField = dtrow["Name"].ToString();
                    lst.Add(staff);
                }
            }

            return lst;
        
       
    }
    protected void FillHolidayDataset()
    {
        if (CalEvents.VisibleDate.Year == 0001)
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;

        }
        else
        {
            //Year = CalAttendance.VisibleDate.Year;
            //Month = CalAttendance.VisibleDate.Month - 1;
            Month = CalEvents.VisibleDate.Month;
            Year = CalEvents.VisibleDate.Year;
        }
        DateTime firstDate = new DateTime(Year, Month, 1);
        CalEvents.VisibleDate = new DateTime(Year, Month, 1);
        DateTime lastDate = GetFirstDayOfNextMonth();
        dsObj = GetCurrentMonthData(firstDate, lastDate);
    }

    protected DateTime GetFirstDayOfNextMonth()
    {
        DateTime lastDate;
        try
        {
            int monthNumber, yearNumber;
            if (CalEvents.VisibleDate.Month == 12 || CalEvents.VisibleDate.Month == 11)
            {
                monthNumber = 1;
                yearNumber = DateTime.Now.Year + 1;
            }
            else
            {
                monthNumber = CalEvents.VisibleDate.Month + 1;
                yearNumber = CalEvents.VisibleDate.Year;
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

    public void LiveLecture()
    {
        try
        {
            strQry = "exec [usp_NewAdminDashboard] @type='LiveLecture',@Schoolid='" + Convert.ToString(Session["School_Id"]) + "'";
            //sBindGrid(grvLectureAtt, strQry);
            dsObj = sGetDataset(strQry);
            grvLectureAtt.DataSource = dsObj;
            grvLectureAtt.DataBind();
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
            strQry = "exec [usp_AdminDashboard] @type='FillCalendar',  @FirstDate='" + Convert.ToDateTime(FirstDt).ToString("yyyy/MM/dd") + "',@LastDate='" + Convert.ToDateTime(LastDt).ToString("yyyy/MM/dd") + "',@SchoolId='" + Convert.ToString(Session["School_id"]) + "'";
            dsCal = sGetDataset(strQry);
            return dsCal;
        }
        catch (Exception)
        {
            return dsObj;
        }
    }

    public void FillStaffLeaves()
    {
        try
        {
            strQry = "exec usp_NewAdminDashboard  @type='StaffLeaves',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
            //sBindGrid(grvLeaveStatus, strQry);
            dsObj = sGetDataset(strQry);
            grvLeaveStatus.DataSource = dsObj;
            grvLeaveStatus.DataBind();
            Session["StaffLeave"] = dsObj;
        }
        catch
        {

        }
    }
    public void FillAttendanceCount()
    {
        try
        {
            strQry = "exec usp_NewAdminDashboard  @type='StudentCount',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
           // sBindGrid(grvStudent, strQry);
            dsObj = sGetDataset(strQry);
            grvStudent.DataSource = dsObj;
            grvStudent.DataBind();

            strQry = "exec usp_NewAdminDashboard  @type='StaffCount',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
            //sBindGrid(grvStaff, strQry);
            dsObj = sGetDataset(strQry);
            grvStaff.DataSource = dsObj;
            grvStaff.DataBind();

            strQry = "exec usp_NewAdminDashboard  @type='TeacherCount',@SchoolId='" + Convert.ToString(Session["School_Id"]) + "'";
           // sBindGrid(grvTeacher, strQry);
            dsObj = sGetDataset(strQry);
            grvTeacher.DataSource = dsObj;
            grvTeacher.DataBind();
        }
        catch 
        {
            
        }
    }
    public void FillBusDetail()
    {
        try
        {
            strQry = "exec [usp_NewAdminDashboard] @type='BusDetail',@SchoolId='"+ Convert.ToString(Session["School_id"]) +"'";
            dsObj = sGetDataset(strQry);
            grvBusAtt.DataSource = dsObj;
            grvBusAtt.DataBind();
        }
        catch 
        {
            
        }
    }
    protected void CalEvents_DayRender(object sender, DayRenderEventArgs e)
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
        }
        catch
        {

        }
    }
    protected void grvBusAtt_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (grvBusAtt.Columns[0].HeaderText == "Bus Name")
                {
                    Label lbl=new Label();
                        strQry= "Route Name: " +Convert.ToString(dsObj.Tables[0].Rows[e.Row.RowIndex]["vchRoute_name"]) ;
                        strQry += " Trip Name: " + Convert.ToString(dsObj.Tables[0].Rows[e.Row.RowIndex]["vchTrip_name"]);
                        strQry += " Driver Name: " + Convert.ToString(dsObj.Tables[0].Rows[e.Row.RowIndex]["vchDriverFirst_name"]);
                        
                  
                    e.Row.ToolTip = strQry;
                }

                LinkButton lnk = (LinkButton)e.Row.FindControl("lnkPresent");
                Label lblBus = (Label)e.Row.FindControl("lblBusId");
                strQry = HttpUtility.UrlEncode(Encrypt(Convert.ToString(lblBus.Text)));
                string status = HttpUtility.UrlEncode(Encrypt("Present"));
                string url = "ViewAdminDetail.aspx?BusId=" + strQry + "&status=" + status;
                lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");


                LinkButton lnk1 = (LinkButton)e.Row.FindControl("lnkAbsent");
                Label lblBus1 = (Label)e.Row.FindControl("lblBusId");
                strQry = HttpUtility.UrlEncode(Encrypt(Convert.ToString(lblBus1.Text)));
                status = HttpUtility.UrlEncode(Encrypt("Absent"));
                url = "ViewAdminDetail.aspx?BusId=" + strQry + "&status=" + status;
                lnk1.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");
       
            }
        }
        catch
        {
            
        }
    }

    [WebMethod]
    public static string btnSend_Click(string txtMsg,string ddlName)
    {
        try
        {
            string GroupId, strQry;
            DataSet dsObj = new DataSet();
            
            if (txtMsg != "")
            {

                strQry = string.Empty;
                strQry = "exec usp_MessageMst @type='CheckExist',@intUser_id2='" + Convert.ToString(HttpContext.Current.Session["User_Id1"]) + "',@intUserType_id2='" + Convert.ToString(HttpContext.Current.Session["UserType_Id"]) + "',@intUser_id='" + Convert.ToString(ddlName) + "',@intUserType_id='" + Convert.ToString(HttpContext.Current.Session["Type"]) + "',@intSchool_Id='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "'";
                dsObj = new DataSet();
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    HttpContext.Current.Session["GrpId"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intGroup_id"]);
                    HttpContext.Current.Session["MemId"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intGrpMem_Id"]);


                    strQry = string.Empty;
                    strQry = "exec [usp_MessageMst] @type='UpdateNotification',@intGrpMember_Id='" + HttpContext.Current.Session["MemId"].ToString() + "',@intSchool_Id='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "'";
                    sExecuteQuery(strQry);
                }
                else
                {
                    strQry = string.Empty;
                    //strQry = "exec usp_GroupMsg_Mst @type='Insert',@vchGroup_name='Private',@vchGroupType='Private',@intGroupCreatedBy='" + HttpContext.Current.Session["User_Id"] + "',@intUser_id='" + HttpContext.Current.Session["User_Id"] + "',@intInsertedBy='" + HttpContext.Current.Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@intSchool_Id='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "'";
                    
                    //26-11-2014  This will adding group details as well as created gropu member detail also
                    strQry = "exec [usp_GroupMemberMsg_Mst] @type='Insert',@vchGroup_name='Private',@vchGroupType='Private',@intGroupCreatedByType='" + Convert.ToString(HttpContext.Current.Session["UserType_Id"]) + "',@intUserType_id='" + Convert.ToString(HttpContext.Current.Session["UserType_Id"]) + "',@intGroupCreatedBy='" + HttpContext.Current.Session["User_Id1"] + "',@intStudent_id='" + Convert.ToString(HttpContext.Current.Session["UserType_Id"] == "1" ? HttpContext.Current.Session["User_Id1"] : "0") + "',@intUser_id='" + Convert.ToString(HttpContext.Current.Session["UserType_Id"] == "1" ? "0" : HttpContext.Current.Session["User_Id1"]) + "',@intInsertedBy='" + HttpContext.Current.Session["User_Id1"] + "',@vchInsertedIp='" + GetSystemIP() + "',@intSchool_Id='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "'";
                    if (sExecuteQuery(strQry) != -1)
                    {
                        strQry = string.Empty;
                        strQry = "exec [usp_GroupMsg_Mst] @type='LastInsertedId',@intSchool_Id='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "'";
                        dsObj = new DataSet();
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            HttpContext.Current.Session["GrpId"] = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
                            GroupId = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
                            strQry = string.Empty;
                            //strQry = "exec usp_GroupMemberMsg_Mst @type='InsertMember',@intGroup_id='" + Convert.ToString(GroupId) + "',@intUser_id='" + Convert.ToString(HttpContext.Current.Session["User_Id"]) + "',@intUserType_id='" + Convert.ToString(HttpContext.Current.Session["UserType_Id"]) + "',@intInsertedBy='" + HttpContext.Current.Session["User_Id"] + "',@vchInsertedIp='" + Convert.ToString(GetSystemIP()) + "',@intSchool_Id='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "'";
                               
                            //if (sExecuteQuery(strQry) != -1)
                            //{
                                strQry = string.Empty;
                                strQry = "exec usp_GroupMemberMsg_Mst @type='InsertMember',@intGroup_id='" + Convert.ToString(GroupId) + "',@intUser_id='" + Convert.ToString(HttpContext.Current.Session["Type"].ToString() == "1" ? "0" : ddlName) + "',@intStudent_id='" + Convert.ToString(HttpContext.Current.Session["Type"] == "1" ? ddlName : "0") + "',@intUserType_id='" + Convert.ToString(HttpContext.Current.Session["Type"]) + "',@intInsertedBy='" + HttpContext.Current.Session["User_Id1"] + "',@vchInsertedIp='" + Convert.ToString(GetSystemIP()) + "',@intSchool_Id='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "'";
                            
                                sExecuteQuery(strQry);

                                 strQry = string.Empty;
                                 strQry = "exec [usp_GroupMsg_Mst] @type='LastInsertedId',@intSchool_Id='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "'";
                                    dsObj = new DataSet();
                                    dsObj = sGetDataset(strQry);
                                    if (dsObj.Tables[0].Rows.Count > 0)
                                    {
                                        HttpContext.Current.Session["MemId"] = dsObj.Tables[0].Rows[0][0];

                                        strQry = string.Empty;
                                        strQry = "exec [usp_MessageMst] @type='UpdateNotification',@intGrpMember_Id='" + HttpContext.Current.Session["MemId"].ToString() + "',@intSchool_Id='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "'";
                                        sExecuteQuery(strQry);
                                    }
                            //}
                        }
                    }

                }


           


                dsObj = new DataSet();
                strQry = string.Empty;
                strQry = "exec usp_MessageMst @type='Insert',@intGroupid='" + HttpContext.Current.Session["GrpId"] + "',@intGrpMember_Id='" + HttpContext.Current.Session["MemId"] + "',@intUser_SenderId='" + Convert.ToString(HttpContext.Current.Session["User_Id1"]) + "',@intUser_ReceiveType='" + Convert.ToString(HttpContext.Current.Session["Type"]) + "',@intUser_ReceiveId='" + Convert.ToString(ddlName) + "',@intInserted_by='" + HttpContext.Current.Session["User_Id1"] + "',@Inserted_IP='" + GetSystemIP() + "',@Message='" + Convert.ToString(txtMsg.Trim()) + "',@intSchool_Id='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    return txtMsg;
                   // OpenChat();
                }
                else
                {
                    return "false";
                }
            }
            return txtMsg;
        }
        catch (Exception)
        {
            return "false";
        }
       
    }

    protected void grvLeaveStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvLeaveStatus.PageIndex=e.NewPageIndex;
            grvLeaveStatus.DataSource = Session["StaffLeave"];
            grvLeaveStatus.DataBind();
            
        }
        catch 
        {
            
        }
    }
    protected void grvLectureAtt_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

        }
        catch 
        {
            
        }
    }
    protected void lnkDetail_Click(object sender, EventArgs e)
    {
        try
        {
            int Index = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            int id = (int)grvLeaveStatus.DataKeys[Index].Value;
           // int rowindex = grvLeaveDetail.DataKeys[row.RowIndex].Value;
            strQry = "exec [usp_NewAdminDashboard] @type='Staff_Leave_Detail',@SchoolId='" + Session["School_id"].ToString() + "',@intLeaveApplocation_id='" + id.ToString() + "'";
            dsObj = sGetDataset(strQry);
            //grvLeaveDetail.DataSource=dsObj;
            //grvLeaveDetail.DataBind();
          //  ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "PopUpShow();", true);  
        }
        catch 
        {
            
        }
    }
    protected void grvLeaveStatus_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

               
                LinkButton lnk = (LinkButton)e.Row.FindControl("lnkDetail");
                Label lblLeave = (Label)e.Row.FindControl("lblLeaveId");
                lblLeave.Text = HttpUtility.UrlEncode(Encrypt(lblLeave.Text));
                string url = "ViewAdminDetail.aspx?LeaveId=" + lblLeave.Text;

                lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','height=245,left=50,top=200,addressbar=0')");
            }
        }
        catch (Exception)
        { }
    }
    protected void grvStaff_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = (LinkButton)e.Row.FindControl("lnkPresent");
                string staff = HttpUtility.UrlEncode(Encrypt("4"));
                string status = HttpUtility.UrlEncode(Encrypt("Present"));
                string url = "ViewAdminDetail.aspx?Staff=" + staff + "&status=" + status;

                lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");


                 lnk = (LinkButton)e.Row.FindControl("lnkAbsent");
                 staff = HttpUtility.UrlEncode(Encrypt("4"));
                 status = HttpUtility.UrlEncode(Encrypt("Absent"));
                 url = "ViewAdminDetail.aspx?Staff=" + staff+"&status="+status;
                 lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");


                 lnk = (LinkButton)e.Row.FindControl("lnkLeave");
                 staff = HttpUtility.UrlEncode(Encrypt("4"));
                 status = HttpUtility.UrlEncode(Encrypt("Leave"));
                 url = "ViewAdminDetail.aspx?Staff=" + staff + "&status=" + status;
                 lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");



            }
        }
        catch 
        {
            
        }
    }
    protected void grvTeacher_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = (LinkButton)e.Row.FindControl("lnkPresent");
                string staff = HttpUtility.UrlEncode(Encrypt("3"));
                string status = HttpUtility.UrlEncode(Encrypt("Present"));
                string url = "ViewAdminDetail.aspx?Staff=" + staff + "&status=" + status;
                lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");

             


                lnk = (LinkButton)e.Row.FindControl("lnkAbsent");
                staff = HttpUtility.UrlEncode(Encrypt("3"));
                status = HttpUtility.UrlEncode(Encrypt("Absent"));
                url = "ViewAdminDetail.aspx?Staff=" + staff + "&status=" + status;
                lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");


                lnk = (LinkButton)e.Row.FindControl("lnkLeave");
                staff = HttpUtility.UrlEncode(Encrypt("3"));
                status = HttpUtility.UrlEncode(Encrypt("Leave"));
                url = "ViewAdminDetail.aspx?Staff=" + staff + "&status=" + status;
                lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");
            }
          
        }
        catch 
        {
            
        }
    }
    protected void grvBusAtt_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            strQry = HttpUtility.UrlEncode(Encrypt(Convert.ToString(grvBusAtt.DataKeys[e.NewEditIndex].Value)));
            string status = HttpUtility.UrlEncode(Encrypt("Present"));
            string url = "ViewAdminDetail.aspx?BusId=" + strQry + "&status=" + status;
            grvBusAtt.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");
        }
        catch
        {

        }
    }
    protected void grvBusAtt_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            strQry = HttpUtility.UrlEncode(Encrypt(Convert.ToString(grvBusAtt.DataKeys[e.RowIndex].Value)));
            string status = HttpUtility.UrlEncode(Encrypt("Present"));
            string url = "ViewAdminDetail.aspx?BusId=" + strQry + "&status=" + status;
            grvBusAtt.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");
        }
        catch 
        {
            
        }
    }
    protected void btnSet_Click(object sender, EventArgs e)
    {
        try
        {
            strQry = "exec [usp_NewAdminDashboard] @type='RefreshPage',@UserId='" + Convert.ToString(Session["User_Id"]) + "',@RefreshTime=" + Convert.ToString(ddlSet.SelectedValue) +"";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Refresh Time Assigned Successfully");
                RefreshPage();
            }
        }
        catch
        {
            
        }
    }
    protected void CalEvents_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        try
        {
            FillHolidayDataset();
        }
        catch 
        {
        }
    }
    protected void CalEvents_VisibleMonthChanged1(object sender, MonthChangedEventArgs e)
    {
        try
        {
            FillHolidayDataset();
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
            strQry = "usp_NewAdminDashboard @type='AllMessageToStudent',@SchoolId='" + Convert.ToString(Session["School_id"]) + "'";
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
                strQry = "usp_NewAdminDashboard @type='AllMessageToStandard',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@STD='" + drpStandard.SelectedValue.Trim() + "'";
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

                    strQry = "usp_NewAdminDashboard @type='AllMessageToDivision',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@STD='" + drpStandard.SelectedValue.Trim() + "'";
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

                        strQry = "usp_NewAdminDashboard @type='AllMessageToDivision',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@STD='" + drpStandard.SelectedValue.Trim() + "',@DIV='" + Div1 + "'";
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

                        strQry = "usp_NewAdminDashboard @type='IndividualMessage',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@STD='" + drpStandard.SelectedValue.Trim() + "',@DIV='" + Div1 + "',@intStudentId='" + drpStudent.SelectedValue.Trim() + "'";
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
                strQry = "usp_NewAdminDashboard @type='AllStaff',@SchoolId='" + Session["School_id"] + "'";
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
            if (drpDepartment.Text == "All")
            {
                strQry = "usp_NocticeBoard @command='AllStaffNon',@intschool_id='" + Session["School_id"] + "'";
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
                if (drpStaff.Text == "All")
                {
                    strQry = "usp_NewAdminDashboard @type='AllStaffDepartment',@SchoolId='" + Session["School_id"] + "',@intDepartment_id='" + drpDepartment.SelectedValue.Trim() + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i <= dsObj.Tables[0].Rows.Count - 1; i++)
                        {
                            string strMobile1 = Convert.ToString(dsObj.Tables[i].Rows[0]["intmobileNo"]);

                            strMobile1 = "9820764572";
                            //POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + strMobile1.Trim() + "&msg=" + txtNotice.Text.Trim() + "&alert=1", "");
                        }
                    }
                }
                else
                {
                    strQry = "usp_NewAdminDashboard @type='IndividualStaff',@SchoolId='" + Session["School_id"] + "',@intDepartment_id='" + drpDepartment.SelectedValue.Trim() + "',@intTeacher_id='" + drpStaff.SelectedValue.Trim() + "'";
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

        }

        //if (drpStandard.Text == "All" && drpDivision.Text == "---Select---" && drpStudent.Text == "---Select---")
        //{
        //    string strStudent_id = drpStudent.SelectedValue.Trim();

        //    strQry = "usp_NewAdminDashboard @type='AllMessageToStudent',@SchoolId='" + Convert.ToString(Session["School_id"]) + "'";
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
        //        strQry = "usp_NewAdminDashboard @type='AllMessageToDivision',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@STD='5'";
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
        //            strQry = "usp_NewAdminDashboard @type='IndividualMessage',@SchoolId='" + Convert.ToString(Session["School_id"]) + "'";
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
        //                strQry = "usp_NewAdminDashboard @type='IndividualMessage',@SchoolId='" + Convert.ToString(Session["School_id"]) + "'";
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
        //                strQry = "usp_NewAdminDashboard @type='IndividualMessage',@intStudentId='" + strStudent_id.Trim() + "'";

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
        //    strQry = "usp_NewAdminDashboard @type='IndividualMessage',@intStudentId='" + strStudent_id.Trim() + "'";
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
    protected void drpUserType_SelectedIndexChanged(object sender, EventArgs e)
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
            trStaff.Visible = true;
        }
    }
    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void drpDivision_SelectedIndexChanged(object sender, EventArgs e)
    {       

        try
        {
            int stat1 = Convert.ToInt32(drpStandard.SelectedItem.Value);

            int Div1 = Convert.ToInt32(drpDivision.SelectedItem.Value);

            string query3 = "Execute dbo.usp_NocticeBoard @command='DivisionStudent',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + stat1 + "',@intDivision_id='" + Div1 + "' ";
            bool st3 = sBindDropDownList(drpStudent, query3, "Name", "intStudent_id");
            drpStudent.Items.Insert(1, "All");
        }
        catch
        {

        }
    }
    protected void drpDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpDepartment.Text == "All")
        {
            drpStaff.Enabled = false;
        }
        else
        {
            int typeid = Convert.ToInt32(drpUserType.SelectedItem.Value);
            int depid = Convert.ToInt32(drpDepartment.SelectedItem.Value);
            string query2 = "Execute [usp_NewAdminDashboard] @type='SelectStaffId',@SchoolId='" + Session["School_id"] + "',@intDepartment_id='" + depid + "'";
            bool st3 = sBindDropDownList(drpStaff, query2, "Name", "intTeacher_id");
            drpStaff.Items.Insert(1, "All");
            drpStaff.Enabled = true;
        }
    }
    protected void fillBusDetails()
    {
        strQry = "usp_NewAdminDashboard @type='BusDetails',@SchoolId='" + Convert.ToString(Session["School_id"]) + "'  ";
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

                lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=800,height=245,left=50,top=200,addressbar=0')");

                LinkButton lnkAbsent = (LinkButton)e.Row.FindControl("lnkAbsent");

                string urlAbsent = "frmViewAbsent.aspx?DeviceID=" + strDevice + "&time=" + strEndTime;

                lnkAbsent.Attributes.Add("onClick", "JavaScript: window.open('" + urlAbsent + "','','_blank','width=800,height=245,left=50,top=200,addressbar=0')");


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
        catch(Exception ex)
        {

        }
    }
}