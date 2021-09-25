using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewTeacherDashboard : DBUtility
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
            if (!IsPostBack)
            {
                FillLoginDetails();
                FillPersonal();
                FillExam();
                LiveLecture();
                FillAttendanceCount();
                FillLeaveDetail();
                Lectureschedule();
                FillExamSubject();
                FillDept();
                FillNoticeBoard();
                FillLibraryDetails();
                FillInventory();
                fillUnReadMessage();
            }
           
            FillHolidayDataset();
            Script();
        }
        catch 
        {
            
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
                    lblMsgCount.Text = Convert.ToString(ds.Tables[0].Rows[0][0]);
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
    public void FillLoginDetails()
    {
        try
        {
            strQry = "exec [usp_TeacherDashboard]  @type='Log',@intUser_id='" + Convert.ToString(Session["User_id"]) + "'";
            dsObj = sGetDataset(strQry);
            grvLastLogin.DataSource = dsObj;
            grvLastLogin.DataBind();

        }
        catch
        {

        }
    }
    public void Lectureschedule()
    {
        try
        {
            strQry = "exec [usp_TeacherDashboard] @type='TeacherTimeTable',@intTeacher_id='" + Convert.ToString(Session["User_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindGrid(grvLec, strQry);
        }
        catch
        {
            
        }
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
    public DataSet GetCurrentMonthData(DateTime FirstDt, DateTime LastDt)
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_TeacherDashboard] @type='FillCalendar',  @FirstDate='" + Convert.ToDateTime(FirstDt).ToString("yyyy/MM/dd") + "',@LastDate='" + Convert.ToDateTime(LastDt).ToString("yyyy/MM/dd") + "',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "'";
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
            if (CalEvents.VisibleDate.Month == 12 || CalEvents.VisibleDate.Month == 11)
            {
                monthNumber = 1;
                yearNumber = DateTime.Now.Year + 1;
            }
            else
            {
                monthNumber = CalEvents.VisibleDate.Month + 2;
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
    public void FillPersonal()
    {
        try
        {
            strQry = "exec [usp_TeacherDashboard] @type='TitleBar',@intUser_id='" + Convert.ToString(Session["User_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ImgAdmin.Attributes.Add("src", "images\\" + Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]) + "");
                lblWelcomeName.Text = "Hello "+ Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirst_Name"]);
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
            grvStudent.DataSource = dsObj;
            grvStudent.DataBind();

            strQry = "exec [usp_TeacherDashboard] @type='TeacherMonthCount',@intUser_id='" + Convert.ToString(Session["User_id"]) + "'";
            dsObj = sGetDataset(strQry);
            grvTeacher.DataSource = dsObj;
            grvTeacher.DataBind();
        }
        catch 
        {
            
        }
    }

    public void LiveLecture()
    {
        try
        {
            strQry = "exec [usp_TeacherDashboard] @type='LiveLecture',@Schoolid='" + Convert.ToString(Session["School_Id"]) + "',@intDivision_id='" + Convert.ToString(Session["Division_id"]) + "'";
            //sBindGrid(grvLectureAtt, strQry);
            dsObj = sGetDataset(strQry);
            grvLectureAtt.DataSource = dsObj;
            grvLectureAtt.DataBind();
        }
        catch
        {

        }
    }
    public void FillExam()
    {
        try
        {
            strQry = "exec [usp_TeacherDashboard] @type='ExamSchedule',@intSchool_id='" + Session["School_id"] + "',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@intDivision_id='" + Convert.ToString(Session["Division_id"]) + "'";
            dsObj = sGetDataset(strQry);
            grvExam.DataSource = dsObj;
            grvExam.DataBind();
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                divExams.Visible = true;
                grvExam.Visible = true;
            }
            else
            {
                divExams.Visible = false;
                grvExam.Visible = false;
            }
        }
        catch
        {

        }
    }
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
    protected void grvStudent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = (LinkButton)e.Row.FindControl("lnkPresent");
                string status = HttpUtility.UrlEncode(Encrypt("Present"));
                string url = "frmViewTeacherDetail.aspx?Type=" + HttpUtility.UrlEncode(Encrypt("Student")) + "&status=" + status;
                lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");


                lnk = (LinkButton)e.Row.FindControl("lnkAbsent");
                status = HttpUtility.UrlEncode(Encrypt("Absent"));
                url = "frmViewTeacherDetail.aspx?Type=" + HttpUtility.UrlEncode(Encrypt("Student")) + "&status=" + status;
                lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");


                lnk = (LinkButton)e.Row.FindControl("lnkLeave");
                status = HttpUtility.UrlEncode(Encrypt("Leave"));
                url = "frmViewTeacherDetail.aspx?Type=" + HttpUtility.UrlEncode(Encrypt("Student")) + "&status=" + status;
                lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");
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
            ScriptManager.RegisterStartupScript((Page)(HttpContext.Current.Handler), typeof(Page), "script", "setInterval(function() { window.location=window.location;}," + Convert.ToString(dsObj.Tables[0].Rows[0][0]) + ");", true);
        }
        catch
        {

        }
    }
    protected void btnSet_Click(object sender, EventArgs e)
    {
        try
        {
            strQry = "exec [usp_NewAdminDashboard] @type='RefreshPage',@UserId='" + Convert.ToString(Session["User_Id"]) + "',@RefreshTime=" + Convert.ToString(ddlSet.SelectedValue) + "";
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
    public void FillLeaveDetail()
    {
        try
        {
            strQry = "exec [usp_TeacherDashboard] @type='StudentLeave',@SchoolId='" + Convert.ToString(Session["School_id"]) + "',@intDivision_id='" + Convert.ToString(Session["Division_id"]) + "'";
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
    public SortDirection dir
    {
        get
        {
            if (ViewState["dirState"] == null)
            {
                ViewState["dirState"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["dirState"];
        } 
        set
        {
            ViewState["dirState"] = value;
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
protected void grvLeaveStudent_Sorting(object sender, GridViewSortEventArgs e)
{
    try
    {
          DataTable dt = new DataTable();
            dsObj=(DataSet)Session["TeacherLeave"];
            dt = dsObj.Tables[0];
        {
            string SortDir = string.Empty;
            if (dir == SortDirection.Ascending)
            {
                dir = SortDirection.Descending;
                SortDir = "Desc";
            }
            else
            {
                dir = SortDirection.Ascending;
                SortDir = "Asc";
            }
            DataView sortedView = new DataView(dt);
            sortedView.Sort = e.SortExpression + " " + SortDir;
            grvLeaveStudent.DataSource = sortedView;
            grvLeaveStudent.DataBind();
        }
    }
    catch (Exception)
    {
        
    }
}

public void FillExamSubject()
{
    try
    {
        strQry = "exec [usp_TeacherDashboard]  @type='ExamSubject',@intUser_id='" + Convert.ToString(Session["User_id"]) + "'";
        dsObj = sGetDataset(strQry);
        grvExamSub.DataSource = dsObj;
        grvExamSub.DataBind();
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
            string status = HttpUtility.UrlEncode(Encrypt("Present"));
            string url = "frmViewTeacherDetail.aspx?Type="+HttpUtility.UrlEncode(Encrypt("Teacher"))+"&status=" + status;
            lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");


            lnk = (LinkButton)e.Row.FindControl("lnkAbsent");
            status = HttpUtility.UrlEncode(Encrypt("Absent"));
            url = "frmViewTeacherDetail.aspx?Type=" + HttpUtility.UrlEncode(Encrypt("Teacher")) + "&status=" + status;
            lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");


            lnk = (LinkButton)e.Row.FindControl("lnkLeave");
            status = HttpUtility.UrlEncode(Encrypt("Leave"));
            url = "frmViewTeacherDetail.aspx?Type=" + HttpUtility.UrlEncode(Encrypt("Teacher")) + "&status=" + status;
            lnk.Attributes.Add("onClick", "JavaScript: window.open('" + url + "','','_blank','width=1000,height=245,left=50,top=200,addressbar=0')");
        }

    }
    catch
    {
        
    }
}
protected void lnkExamName_Click(object sender, EventArgs e)
{
    try
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow grvRow = (GridViewRow)lnk.NamingContainer;
        int rowIndex = grvRow.RowIndex;
        LinkButton lnkName = (LinkButton)grvExam.Rows[rowIndex].FindControl("lnkExamName");
        lblExamName.Text = Convert.ToString(lnkName.Text);
        strQry = "exec [usp_StudentDashboard] @type='ExamDetail',@intExam_id='" + Convert.ToString(grvExam.DataKeys[rowIndex].Value) + "',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@intDivision_id='" + Convert.ToString(Session["Division_id"]) + "',@intSchool_id='" + Session["School_id"] + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvExamDetails.DataSource = dsObj;
            grvExamDetails.DataBind();
            ModalPopupExtender1.Show();
        }
    }
    catch
    {

    }
}
protected void lnkExamName_Click1(object sender, EventArgs e)
{
    try
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow grvRow = (GridViewRow)lnk.NamingContainer;
        int rowIndex = grvRow.RowIndex;
        LinkButton lnkName = (LinkButton)grvExamSub.Rows[rowIndex].FindControl("lnkExamName");
        lblExamName.Text = Convert.ToString(lnkName.Text);
        strQry = "exec [usp_StudentDashboard] @type='ExamDetail',@intExam_id='" + Convert.ToString(grvExamSub.DataKeys[rowIndex].Value) + "',@intstandard_id='" + Convert.ToString(Session["Standard_id"]) + "',@intDivision_id='" + Convert.ToString(Session["Division_id"]) + "',@intSchool_id='" + Session["School_id"] + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvExamDetails.DataSource = dsObj;
            grvExamDetails.DataBind();
            ModalPopupExtender1.Show();
        }
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
public void FillNoticeBoard()
{
    try
    {
        strQry = "exec [usp_TeacherDashboard] @type='NoticeBoardNew',@intUser_id='" + Convert.ToString(Session["User_id"]) + "' ";

        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdNotice.DataSource = dsObj;
            grdNotice.DataBind();
        }
        //Table tbl = new Table();
        ////  TableRow tr = new TableRow();

        //TableHeaderCell th = new TableHeaderCell();
        //TableCell td = new TableCell();
        ////tbl.Width = 500;
        //tbl.CaptionAlign = TableCaptionAlign.Top;
        //Label data = new Label();
        //for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
        //{
        //    TableRow tr = new TableRow();
        //    td = new TableCell();
        //    data.Font.Underline = true;
        //    data.Text = "Subject :" + Convert.ToString(dsObj.Tables[0].Rows[i]["vchSubject"]) + " (From : " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtIssue_date"]) + " To " + Convert.ToString(dsObj.Tables[0].Rows[i]["dtEnd_date"]) + ")";
        //    th.Controls.Add(data);
        //    tr.Cells.Add(th);
        //    tbl.Rows.Add(tr);

        //    TableRow tr1 = new TableRow();
        //    TableCell td1 = new TableCell();
        //    data.Text = Convert.ToString(dsObj.Tables[0].Rows[i]["vchNotice"]);
        //    td1.Controls.Add(data);
        //    tr1.Cells.Add(td1);
        //    tbl.Rows.Add(tr1);
        //}
        //divNoticeBorad.Controls.Add(tbl);
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
    public void fillUnReadMessage()
    {
        strQry = "exec [usp_TeacherDashboard] @type='PendingMessage',@intUser_id='" + Convert.ToString(Session["User_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdMessage.DataSource = dsObj;
            grdMessage.DataBind();
        }
        else
        {
            grdMessage.DataSource = dsObj;
            grdMessage.DataBind();
        }
    }
    protected void grvLibrary_RowDataBound(object sender, GridViewRowEventArgs e)
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
}