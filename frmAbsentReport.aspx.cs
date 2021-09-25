using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;

public partial class frmAbsentReport : DBUtility
{
    string strQry = "";
    int Year=DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    DataSet dsObj = new DataSet();
    DataSet dsAbsent = new DataSet();
    SqlDataAdapter daObj = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserType_id"] != null && (Session["User_Id"] != null || Session["Student_id"] != null))
        {
            //Label lblTile = new Label();
            //lblTile = (Label)Page.Master.FindControl("lblPageTitle");
            //lblTile.Visible = true;
            //lblTile.Text = "Absent Days Details";
            if (!IsPostBack)
            {

                ddlMonth.SelectedValue = Convert.ToString(DateTime.Now.Month);
                ddlMonth_SelectedIndexChanged(null, null);
                FillCalDataset(Convert.ToInt32(DateTime.Now.Year), Convert.ToInt32(DateTime.Now.Month));
                FillGrid();
            }



        }


        else
        {
            Response.Redirect("~\\frmIndex.aspx", false);
        }
    }
    protected void FillCalDataset(int Y, int M)
    {
        if (Calendar1.VisibleDate.Year == 0001)
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;

        }
        else
        {
            Year = Y;
            Month = M;
        }
        DateTime firstDate = new DateTime(Y, M, 1);
        DateTime lastDate = GetFirstDayOfNextMonth();
        dsObj = GetData(firstDate, lastDate);
        dsAbsent = createDataTable();//createDataTable(firstDate, lastDate);
    }
    protected DateTime GetFirstDayOfNextMonth()
    {
        DateTime lastDate;
        try
        {
            int monthNumber, yearNumber;
            if (Calendar1.VisibleDate.Month == 12)
            {
                monthNumber = 1;
                yearNumber = DateTime.Now.Year + 1;
            }
            else
            {
                monthNumber = DateTime.Now.Month + 1;
                yearNumber = DateTime.Now.Year;
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
    private DataSet GetData(DateTime FirstDt, DateTime LastDt)
    {
        try
        {

            if (Session["UserType_id"].ToString() == "1" || Session["UserType_id"].ToString() == "2")
            {

                strQry = "exec usp_getAttendance @type='getCalenderAbsentAtt',@intUserType_id='" + Convert.ToString(Session["UserType_id"]) + "',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_id='" + Session["School_id"] + "',@FrmDt='" + FirstDt + "',@EndDt='" + LastDt + "'";
                dsObj = sGetDataset(strQry);
            }
            else
            {

                strQry = "exec usp_getAttendance @type='getTeacherCalendarAbsentAtt',@intUserType_id='" + Convert.ToString(Session["UserType_id"]) + "',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@intSchool_id='" + Session["School_id"] + "',@FrmDt='" + FirstDt + "',@EndDt='" + LastDt + "'";
                dsObj = sGetDataset(strQry);
            }



            Session["Table"] = dsObj;
            return dsObj;
        }
        catch (Exception)
        {
            return dsObj;
        }


    }
    public void FillGrid()
    {
        try
        {
            dsAbsent = createDataTable();
            gridAttendance.DataSource = dsAbsent;
            gridAttendance.DataBind();
            if (Session["UserType_id"] != null)
            {


                if (Session["UserType_id"].ToString() == "1" || Session["UserType_id"].ToString() == "2")
                {
                    gridAttendance.Columns[0].Visible = false;
                    gridAttendance.Columns[1].Visible = false;
                    gridAttendance.Columns[5].Visible = true;
                    gridAttendance.Columns[6].Visible = true;
                    gridAttendance.Columns[7].Visible = true;
                    gridAttendance.Columns[8].Visible = true;
                    gridAttendance.Columns[9].Visible = false;
                    gridAttendance.Columns[10].Visible = false;
                }
                else // if (Session["UserType_id"] == "3")
                {
                    gridAttendance.Columns[0].Visible = false;
                    gridAttendance.Columns[1].Visible = false;
                    gridAttendance.Columns[5].Visible = false;
                    gridAttendance.Columns[6].Visible = false;
                    gridAttendance.Columns[7].Visible = false;
                    gridAttendance.Columns[8].Visible = false;
                    gridAttendance.Columns[9].Visible = true;
                    gridAttendance.Columns[10].Visible = true;
                }


                  
                
               
            }
            else
            {

                Response.Redirect("~\\index\\frmLogin.aspx", false);
            }


        }
        catch (Exception)
        {


        }
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        try
        {
             string Day_Date = e.Day.Date.ToShortDateString();

        if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
        {
            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F14c57");
            e.Cell.ToolTip = "Holiday";
            //return;
        }
        if (e.Day.Date.ToString("dd") == "15")
        {
            Month = e.Day.Date.Month;
            Year = e.Day.Date.Year;
            ddlMonth.SelectedValue = Convert.ToString(Month);
        }
       
            if (((DataSet)Session["Table"] != null))
            {
                foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                {

                    string scheduledDate = Convert.ToDateTime(dr["LoginDateTime"]).ToShortDateString();
                    string scheduled_LoginTime = Convert.ToString(dr["Login"]);
                    string scheduled_LogoutTime = dr["LogoutDateTime"].ToString();
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

                        string status = Convert.ToString(dr["Status"]);
                        if (status == "Early")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=blue>Early</font>";
                            //e.Cell.Controls.Add(lc);
                            //e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");
                            e.Cell.ToolTip = "Early";

                        }
                        else if (status == "Present")
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Present</font>" + "<br/>";
                            //e.Cell.Controls.Add(lc);
                            //e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");
                            e.Cell.ToolTip = "Present";

                        }
                        else if (status == "Leave")//manual
                        {
                            //lc.Text = @"<br/>" + "<font size=1 color=black>Early(Web)</font>" + "<br/>" + scheduled_LoginTime;
                            // e.Cell.Controls.Add(lc);
                            e.Cell.ToolTip = "Leave";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");
                        }
                        //}
                        //else if (status == "Ontime Reported Web")//manual
                        //{
                        //    lc.Text = @"<br/>" + "<font size=1 color=black>Ontime(Web)</font>" + "<br/>" + scheduled_LoginTime;
                        //    e.Cell.Controls.Add(lc);
                        //    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        //}
                        //else if (status == "Late Reported Web")//manual
                        //{
                        //    lc.Text = @"<br/>" + "<font size=1 color=black>Late(Web)</font>" + "<br/>" + scheduled_LoginTime;
                        //    e.Cell.Controls.Add(lc);
                        //    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        //}
                        //else if (status == "Present(From Web)")//attandance Issue
                        //{
                        //    lc.Text = @"<br/>" + "<font size=1 color=black>Ontime(Web)</font>" + "<br/>" + scheduled_LoginTime;
                        //    e.Cell.Controls.Add(lc);
                        //    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        //}
                        //else if (status == "Out Of Office")//out of office
                        //{
                        //    lc.Text = @"<br/>" + "<font size=1 color=Yellow>Out Of Office</font>" + "<br/>" + scheduled_LoginTime;
                        //    e.Cell.Controls.Add(lc);
                        //    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        //}
                        //else if (status == "Ontime Reported")
                        //{
                        //    lc.Text = @"<br/>" + "<font size=1 color=black>Ontime</font>" + "<br/>" + scheduled_LoginTime;
                        //    e.Cell.Controls.Add(lc);
                        //    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        //}
                        //else if (status == "Late Reported")
                        //{
                        //    lc.Text = @"<br/>" + "<font size=1 color=maroon>Late</font>" + "<br/>" + scheduled_LoginTime;
                        //    e.Cell.Controls.Add(lc);
                        //    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7BBC20");

                        //}
                        if (status == "Absent")
                        {
                            lc1.Text = @"<br/>" + "<font size=1 color=black>Absent</font>";
                           // e.Cell.Controls.Add(lc1);
                            e.Cell.ToolTip="Absent";
                            e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");

                        } 
                        //else if (status == "Leave Approving")
                        //{
                        //    lc2.Text = @"<br/>" + "<font size=1 color=black> Leave Approving </font>" + "<br/>" + scheduled_LoginTime;
                        //    e.Cell.Controls.Add(lc2);
                        //    e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#9905af");
                        //}

                    }
                    else
                    {

                        //e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#7f16ab");
                    }

                }
            }
              FillGrid();
        }
        catch (Exception)
        {
            
        }
       
       

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

    }
    private DataSet createDataTable()//createDataTable(DateTime FirstDt, DateTime LastDt)
    {
        try
        {
            
                if (Session["UserType_id"].ToString() == "1" || Session["UserType_id"].ToString() == "2")
                {
                    strQry = "exec usp_getAttendance @type='getAbsentAtt',@intUserType_id='" + Convert.ToString(Session["UserType_id"]) + "',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "',@intStudentId='" + Convert.ToString(Session["Student_id"]) + "',@month='" + Convert.ToString(Month) + "',@year='" + Convert.ToString(Year) + "',@intSchool_id='" + Session["School_id"] + "'";//,@FrmDt='" + FirstDt + "',@EndDt='" + LastDt + "'";
                    dsObj = sGetDataset(strQry);
                }
                else // if (Session["UserType_id"] == "3")
                {
                    strQry = "exec usp_getAttendance @type='getTeacherAbsentAtt',@intUserType_id='" + Convert.ToString(Session["UserType_id"]) + "',@intUser_id='" + Convert.ToString(Session["UserId"]) + "',@month='" + Convert.ToString(Month) + "',@year='" + Convert.ToString(Year) + "',@intSchool_id='" + Session["School_id"] + "'";//,@FrmDt='" + FirstDt + "',@EndDt='" + LastDt + "'";
                    dsObj = sGetDataset(strQry);
                }


           
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
            if (ddlMonth.SelectedValue != "1")
            {
                ddlMonth.SelectedValue = Convert.ToString((Convert.ToInt32(ddlMonth.SelectedValue) - 1));
                ddlMonth_SelectedIndexChanged(null, null);
            }
            else
            {
                ddlMonth.SelectedValue = Convert.ToString(12);
                if (Calendar1.VisibleDate.Year != 001)
                {
                    Year = Calendar1.VisibleDate.Year - 1;
                }
                else
                {
                    Year = DateTime.Now.Year;
                }
                FillGrid();
                Month = 12;
                Calendar1.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
                GetData(Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year), Convert.ToDateTime("30/" + Month.ToString().PadLeft(2, '0') + "/" + Year));
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
            if (Calendar1.VisibleDate.Year != 001)
            {
                Year = Calendar1.VisibleDate.Year;
            }
            else
            {
                Year = DateTime.Now.Year;
            }
            FillGrid();

            Calendar1.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
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
            if (ddlMonth.SelectedValue != "12")
            {
                ddlMonth.SelectedValue = Convert.ToString((Convert.ToInt32(ddlMonth.SelectedValue) + 1));
                ddlMonth_SelectedIndexChanged(null, null);
            }
            else
            {
                ddlMonth.SelectedValue = Convert.ToString(1);
                if (Calendar1.VisibleDate.Year != 001)
                {
                    Year = Calendar1.VisibleDate.Year + 1;
                }
                else
                {
                    Year = DateTime.Now.Year;
                }
                FillGrid();
                Month = 1;
                Calendar1.VisibleDate = Convert.ToDateTime("01/" + Month.ToString().PadLeft(2, '0') + "/" + Year);
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

            //switch (TabContainer1.ActiveTabIndex)
            //{
            //    case 1:
            //        ExportGrid(gridAttendance, "AbsentReport " + DateTime.Now + ".xls", "application/vnd.ms-excel");
            //        break;
            //}
            ClsExportExcel exp = new ClsExportExcel();
            switch (TabContainer1.ActiveTabIndex)
            {
                case 1:
                    //  ExportGridToPDF(grvAttendance, "Attendance " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                    exp.ExportGrid(gridAttendance, ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(),0, "", "","", "1", ddlMonth.SelectedItem.Text + " Month Attendance");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["UserType_Id"] + "',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";

                    break;
            }


         
        }
        catch
        {

        }
    }
    protected void ImgPdf_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
          
            //switch (TabContainer1.ActiveTabIndex)
            //{
            //    case 1:
            //        ExportGridToPDF(gridAttendance, "AbsentReport " + DateTime.Now + ".pdf", "application/pdf");
            //        break;
            //}
            ClsExportPdf pdf = new ClsExportPdf();
            switch (TabContainer1.ActiveTabIndex)
            {
                case 1:
                    //  ExportGridToPDF(grvAttendance, "Attendance " + DateTime.Now + ".pdf", "application/vnd.ms-excel");
                    pdf.Page_Load(null, null, gridAttendance, ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString(),0, "", "","", "1", ddlMonth.SelectedItem.Text + " Month Attendance");

                    strQry = "exec [usp_ReportDetails]  @type='InsertReportDetail',@vchRptName='" + ddlMonth.SelectedItem.Text + " Month Attendance" + " " + DateTime.Now.ToShortDateString() + "',@intUserid='" + Session["User_id"] + "',@intUserType='" + Session["UserType_Id"] + "',@vchReportFormat='Excel',@intSchoolId='" + Session["School_id"] + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "'";

                    break;
            }
            
        }
        catch
        {

        }
    }
}
